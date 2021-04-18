using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Generic;


namespace BLL
{
    public class DICorr
    {
        public Model.DICoffT0 CorrCompute(double[,] std_DI12)
        {
            Model.DICoffT0 DICoff = new Model.DICoffT0();

            if (std_DI12.Length == 12 * 6)
            {
                double[] bias = new double[6];
                double[,] MAM = new double[3, 6];//一阶代表行、二阶代表列
                double[] scale = new double[6];
                double[,] cosM = new double[3, 6];

                double BT_local = Model.ConstV.Instance.BT_local;
                double BAD_local = Model.ConstV.Instance.BAD_local;
                double BV = -BT_local * Math.Sin(Math.PI * BAD_local / 180.0);
                //double BH = BT_local * Math.Cos(Math.PI * BAD_local / 180.0);

                //计算Bias
                bias[0] = (std_DI12[0, 0] + std_DI12[0, 2] + std_DI12[0, 5] + std_DI12[0, 7]) / 4;
                bias[1] = (std_DI12[1, 1] + std_DI12[1, 3] + std_DI12[1, 4] + std_DI12[1, 6]) / 4;
                bias[2] = (std_DI12[2, 8] + std_DI12[2, 9] + std_DI12[2, 10] + std_DI12[2, 11]) / 4;
                bias[3] = (std_DI12[3, 0] + std_DI12[3, 2] + std_DI12[3, 5] + std_DI12[3, 7]) / 4;
                bias[4] = (std_DI12[4, 1] + std_DI12[4, 3] + std_DI12[4, 4] + std_DI12[4, 6]) / 4;
                bias[5] = (std_DI12[5, 8] + std_DI12[5, 9] + std_DI12[5, 10] + std_DI12[5, 11]) / 4;

                //计算MAM
                for (int i = 0; i < 3; i++)
                {
                    //注意MAM中的i代表行，std_DI12中的i代表列
                    MAM[i, 0] = (std_DI12[i, 0] - std_DI12[i, 2] - std_DI12[i, 5] + std_DI12[i, 7]) / 4;
                    MAM[i, 1] = (std_DI12[i, 1] - std_DI12[i, 3] - std_DI12[i, 4] + std_DI12[i, 6]) / 4;
                    MAM[i, 2] = (std_DI12[i, 8] + std_DI12[i, 9] - std_DI12[i, 10] - std_DI12[i, 11]) / 4;

                    MAM[i, 3] = (std_DI12[i + 3, 0] - std_DI12[i + 3, 2] - std_DI12[i + 3, 5] + std_DI12[i + 3, 7]) / 4 / BV;
                    MAM[i, 4] = (std_DI12[i + 3, 1] - std_DI12[i + 3, 3] - std_DI12[i + 3, 4] + std_DI12[i + 3, 6]) / 4 / BV;
                    MAM[i, 5] = (std_DI12[i + 3, 8] + std_DI12[i + 3, 9] - std_DI12[i + 3, 10] - std_DI12[i + 3, 11]) / 4 / BV;
                }

                //计算scale
                for (int i = 0; i < 3; i++)
                {
                    scale[i] = 1 / Math.Sqrt(MAM[i, 0] * MAM[i, 0] + MAM[i, 1] * MAM[i, 1] + MAM[i, 2] * MAM[i, 2]);

                    if (Double.IsInfinity(scale[i]))
                        scale[i] = 1;

                    scale[i+3] = 1 / Math.Sqrt(MAM[i, 3] * MAM[i, 3] + MAM[i, 4] * MAM[i, 4] + MAM[i, 5] * MAM[i, 5]);
                    if (Double.IsInfinity(scale[i + 3]))
                        scale[i + 3] = 1;
                }

                //计算位置校正系数
                for (int r = 0; r < 3; r++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        cosM[r, col] = MAM[r, col] * scale[r];
                        cosM[r, col + 3] = MAM[r, col + 3] * scale[r + 3];
                    }
                }

                //计算逆矩阵
                double[,] cosMA = new double[3, 3];
                double[,] cosMM = new double[3, 3];
                double[,] cosRA = new double[3, 3];
                double[,] cosRM = new double[3, 3];
                for (int r = 0; r < 3; r++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        cosMA[r, col] = cosM[r, col];
                        cosMM[r, col] = cosM[r, col + 3];
                    }
                }

                cosRA = new DenseMatrix(cosMA).Inverse().ToArray();
                cosRM = new DenseMatrix(cosMM).Inverse().ToArray();


                //写入float类型数据
                for (int i = 0; i < 6; i++)
                {
                    DICoff.bias[i] = (float)bias[i];

                    DICoff.scale[i] = (float)scale[i];
                }
                for (int r = 0; r < 3; r++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (Double.IsNaN(cosRA[r, col]) || Double.IsInfinity(cosRA[r, col]))
                            DICoff.posA[r * 3 + col] = 0; 
                        else
                            DICoff.posA[r * 3 + col] = (float)cosRA[r, col];

                        if (Double.IsNaN(cosRM[r, col]) || Double.IsInfinity(cosRM[r, col]))
                            DICoff.posM[r * 3 + col] = 0; 
                        else
                            DICoff.posM[r * 3 + col] = (float)cosRM[r, col];

                    }
                }
            }
            return DICoff;
        }
    }
}
