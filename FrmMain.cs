using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TSB
{
    public partial class FrmMain : Form
    {

        private int pos12_id = 0;

        private Model.DICoffT0 DICoff;

        private ExcelOp xlsOp;

        private void dGVr_init()
        {
            dGVr.Rows.Add("Bias", "", "", "", "", "", "");
            dGVr.Rows.Add("Scale", "", "", "", "", "", "");
            dGVr.Rows.Add("CosX", "", "", "", "", "", "");
            dGVr.Rows.Add("CosY", "", "", "", "", "", "");
            dGVr.Rows.Add("CosZ", "", "", "", "", "", "");
        }

        public FrmMain()
        {
            InitializeComponent();

            dGVr_init();

            Enum_CommPort();

            cbB_Tool.SelectedIndex = 0;
            cbB_Rate.Text = "115200";
            cbB_Rate.Enabled = false;
        }
        private void cbB_Tool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbB_Tool.Text == "Thrubit连斜")
            {
                Model.ConstV.Instance.Tool_Addr = 0x0F;

                cbB_Rate.Text = "115200";
            }
            else if(cbB_Tool.Text == "方位伽马")
            {
                Model.ConstV.Instance.Tool_Addr = 0xD2;

                cbB_Rate.Text = "19200";
            }
            else if (cbB_Tool.Text == "近钻头")
            {
                Model.ConstV.Instance.Tool_Addr = 0xD2;
                cbB_Rate.Text = "19200";
            }
            else
            {
                cbB_Rate.Enabled = true;
            }
        }

        private void Enum_CommPort()
        {
            string[] portList = System.IO.Ports.SerialPort.GetPortNames();

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(portList);
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void Btn_PortEnum_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                Enum_CommPort();
            }));
        }

        private void Btn_PortOpen_Click(object sender, EventArgs e)
        {
            //this.Invoke(new Action(() =>
            //{
                if (Tsb.Instance.port_is_open())
                {
                    Tsb.Instance.port_close();
                    btn_PortOpen.Text = "打开";
                    btn_PortOpen.BackColor = Color.Gray;
                }
                else
                {
                    if (comboBox1.Text != "")
                    {
                        try
                        {
                            int baud ;
                            if (cbB_Tool.Text == "Thrubit连斜")
                            {
                                Model.ConstV.Instance.Tool_Addr = 0x0F;
                            }
                            else if (cbB_Tool.Text == "方位伽马")
                            {
                                Model.ConstV.Instance.Tool_Addr = 0xD2;
                            }
                            else if (cbB_Tool.Text == "近钻头")
                            {
                                Model.ConstV.Instance.Tool_Addr = 0xD2;
                            }
                            else
                            {
                                try
                                {
                                    Model.ConstV.Instance.Tool_Addr = int.Parse(cbB_Tool.Text, System.Globalization.NumberStyles.HexNumber);
                                }
                                catch
                                {
                                    MessageBox.Show("仪器地址输入错误！");

                                    return;
                                }
                            }

                            int.TryParse(cbB_Rate.Text, out baud);

                            Tsb.Instance.port_open(comboBox1.Text, baud);
                                btn_PortOpen.Text = "关闭";
                                btn_PortOpen.BackColor = Color.Green;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "串口输入错误");
                        }

                    }
                }
            //}));

        }


        private void update_dgv(int com_id)
        {
            this.Invoke(new Action(() =>
            {
                int id = dGv.Rows.Add();
                dGv.Rows[id].Cells[0].Value = id;
                dGv.FirstDisplayedScrollingRowIndex = id;

                for (int i = 0; i < 6; i++)
                {
                    short val = (short)(Tsb.rx_msg_buf[com_id, 2 * i + 8] + (Tsb.rx_msg_buf[com_id, 2 * i + 9] << 8));
                    float fval = val / 10000.0f;
                    dGv.Rows[id].Cells[i + 1].Value = string.Format("{0:f4}", fval);
                }
            }));

            Tsb.tsb_cb_buf[com_id] -= update_dgv;
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {

            if (Tsb.Instance.tsb_tx_frame(Model.ConstV.Instance.Tool_Addr, 0x69, null, update_dgv))
            {
                ;
            }

        }

        private void DGv_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int col = 1; col < dGv.Columns.Count; col++)
            {
                dGv2.Rows[pos12_id].Cells[col].Value = dGv.Rows[e.RowIndex].Cells[col].Value;
            }
            if (pos12_id < 11)
                pos12_id++;
        }

        private void DGv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (dGv.Rows[e.RowIndex].Selected == true)
                    {
                        contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    }
                }
            }
        }

        private void dGv2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void ContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip2.Close();
            if (e.ClickedItem != null)
            {
                int pos;
                if (Int32.TryParse(e.ClickedItem.ToString().Substring(2), out pos))
                {
                    if ((pos > 0) && (pos <= 12) && (dGv.SelectedRows.Count > 0))
                    {
                        for (int col = 1; col < dGv.Columns.Count; col++)
                        {
                            dGv2.Rows[pos - 1].Cells[col].Value = dGv.SelectedRows[0].Cells[col].Value;
                        }
                    }
                }
                pos12_id = pos - 1;
                if (pos12_id < 11)
                    pos12_id++;
            }
        }


        private void ContextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)//从文件导入  
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "TXT files (*.txt)|*.txt";

            DialogResult dr = openFileDialog.ShowDialog();

            if (dr == DialogResult.OK && openFileDialog.FileName.Length > 0)
            {

                StreamReader sr = new StreamReader(openFileDialog.FileName, Encoding.Default);

                int line_num = 0;
                while (!sr.EndOfStream)
                {
                    string[] items = sr.ReadLine().Split('\t');

                    if (items.Length == 6)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            dGv2.Rows[line_num].Cells[i + 1].Value = items[i];
                        }
                    }
                    else
                    {
                        break;
                    }

                    line_num++;
                    if (line_num >= 12)
                        break;

                }
                sr.Close();
            }
        }

        private void UpdatePosInfo()
        {
            double BT_local;
            double BAD_local;

            if (Double.TryParse(textBox_LocalBT.Text, out BT_local))
            {
                if (Double.TryParse(textBox_LocalBAD.Text, out BAD_local))
                {
                    dGv2.Rows.Clear();

                    double BV = -BT_local * Math.Sin(Math.PI * BAD_local / 180.0);
                    double BH = -BT_local * Math.Cos(Math.PI * BAD_local / 180.0);

                    dGv2.Rows.Add(1, 1, 0, 0, BV, 0, BH);
                    dGv2.Rows.Add(2, 0, 1, 0, 0, BV, BH);
                    dGv2.Rows.Add(3, -1, 0, 0, -BV, 0, BH);
                    dGv2.Rows.Add(4, 0, -1, 0, 0, -BV, BH);
                    dGv2.Rows.Add(5, 0, -1, 0, 0, -BV, -BH);
                    dGv2.Rows.Add(6, -1, 0, 0, -BV, 0, -BH);
                    dGv2.Rows.Add(7, 0, 1, 0, 0, BV, -BH);
                    dGv2.Rows.Add(8, 1, 0, 0, BV, 0, -BH);
                    dGv2.Rows.Add(9, 0, 0, 1, BH, 0, BV);
                    dGv2.Rows.Add(10, 0, 0, 1, -BH, 0, BV);
                    dGv2.Rows.Add(11, 0, 0, -1, BH, 0, -BV);
                    dGv2.Rows.Add(12, 0, 0, -1, -BH, 0, -BV);
                }
            }
        }



        private void FrmMain_Shown(object sender, EventArgs e)
        {
            UpdatePosInfo();

            Tsb.Instance.task_tsb_rx.Start();
        }

        private void Btn_UpdateInfo_Click(object sender, EventArgs e)
        {
            UpdatePosInfo();
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            dGv.Rows.Clear();
        }

        private void SPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            ;
        }




        private void Btn_DICorrRecord_Click(object sender, EventArgs e)//刻度系数保存到.bds文件
        {
            byte[] send_buf = new byte[128];

            string di_code = textBox_DI_Code.Text;
            if (di_code.Length != 4)
            {
                MessageBox.Show("测斜编号输入不正确！");
                return;
            }

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            for (int i = 0; i < 4; i++)
                send_buf[i] = (byte)(di_code[i]);

            send_buf[4] = (byte)(year / 100);
            send_buf[5] = (byte)(year % 100);
            send_buf[6] = (byte)month;
            send_buf[7] = (byte)day;

            for (int i = 0; i < 6; i++)
            {
                byte[] bt = BitConverter.GetBytes(DICoff.bias[i]);
                Buffer.BlockCopy(bt, 0, send_buf, 8 + i * 4, 4);

                byte[] bt2 = BitConverter.GetBytes(DICoff.scale[i]);
                Buffer.BlockCopy(bt2, 0, send_buf, 32 + i * 4, 4);
            }

            for (int i = 0; i < 9; i++)
            {
                byte[] bt = BitConverter.GetBytes(DICoff.posA[i]);
                Buffer.BlockCopy(bt, 0, send_buf, 56 + i * 4, 4);

                byte[] bt2 = BitConverter.GetBytes(DICoff.posM[i]);
                Buffer.BlockCopy(bt2, 0, send_buf, 92 + i * 4, 4);
            }

            string di_cal_date = DateTime.Today.ToString("yyyy-MM-dd");

            SaveFileDialog dialog = new SaveFileDialog();

            dialog.FileName = di_code + "(" + di_cal_date + ")" + ".bds";

            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK && dialog.FileName.Length > 0)
            {
                FileStream fs = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);

                fs.Write(send_buf, 0, send_buf.Length);

                
                //fs.Flush();
                fs.Close();
            }
        }

        private void btn_DICorrTRecord_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                xlsOp = new ExcelOp(openFileDialog1.FileName, 1);

                float[] DICorrPara = new float[36];//bias,scale

                //bias
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        float.TryParse(xlsOp.CellRd(23 + 2 * row, col + 3), out DICorrPara[0 + row * 3 + col]);//Ax,Ay,Az

                        float.TryParse(xlsOp.CellRd(3 + 2 * row, col + 3), out DICorrPara[9 + row * 3 + col]);//Mx,My,Mz
                    }
                }
                //scale
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        float.TryParse(xlsOp.CellRd(24 + 2 * row, col + 3), out DICorrPara[18 + row * 3 + col]);//Ax,Ay,Az

                        float.TryParse(xlsOp.CellRd(4 + 2 * row, col + 3), out DICorrPara[27 + row * 3 + col]);//Mx,My,Mz
                    }
                }

                xlsOp.ExcelClose();

                byte[] send_buf = new byte[144];

                for (int i = 0; i < 36; i++)
                {
                    byte[] bt = BitConverter.GetBytes(DICorrPara[i]);
                    Buffer.BlockCopy(bt, 0, send_buf, i * 4, 4);
                }

                string di_code = textBox_DI_Code.Text;
                if (di_code.Length < 4)
                    di_code = di_code.PadLeft(4);

                FileStream fs = new FileStream(Path.GetDirectoryName(openFileDialog1.FileName)
                                                + "\\" + di_code + ".bdsT",
                                                FileMode.Create, FileAccess.Write);
                fs.Write(send_buf, 0, send_buf.Length);
                fs.Close();
            }
        }
        private void DICorrSend_CallBack(int com_id)
        {
            this.Invoke(new Action(() =>
            {
                if (Tsb.rx_msg_buf[com_id, 7] == 4)
                {
                    MessageBox.Show("配置成功！");
                }
                else
                    MessageBox.Show("失败！");
            }));

            Tsb.tsb_cb_buf[com_id] -= DICorrSend_CallBack;
        }

        private void Btn_DICorr_Send_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "BDS files (*.bds)|*.bds";
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                if (fs.Length == 128)
                {
                    byte[] send_buf = new byte[128];
                    fs.Read(send_buf, 0, 128);
                    fs.Close();

                    if (Tsb.Instance.tsb_tx_frame(Model.ConstV.Instance.Tool_Addr, 0x6A, send_buf, DICorrSend_CallBack))
                    {
                    }
                }
                else
                {
                    MessageBox.Show("文件尺寸不正确，请确认文件是否正确！");
                }
            }
        }
        private void btn_DICorrT_Send_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "BDS files (*.bdsT)|*.bdsT";
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                if (fs.Length == 144)
                {
                    byte[] send_buf = new byte[144];
                    fs.Read(send_buf, 0, 144);
                    fs.Close();

                    if (Tsb.Instance.tsb_tx_frame(Model.ConstV.Instance.Tool_Addr, 0x6B, send_buf, DICorrSend_CallBack))
                    {
                    }
                }
                else
                {
                    MessageBox.Show("文件尺寸不正确，请确认文件是否正确！");
                }
            }
        }

        private void DICorrRead_CallBack(int com_id)
        {
            this.Invoke(new Action(() =>
            {
                if (Tsb.rx_msg_buf[com_id, 7] == 4)
                {
                    char[] tool_id = new char[4];
                    for (int i = 0; i < 4; i++)
                        tool_id[i] = (char)Tsb.rx_msg_buf[com_id, 8 + i];

                    string str = new string(tool_id);

                    int cali_year_h = Tsb.rx_msg_buf[com_id, 12];
                    int cali_year_l = Tsb.rx_msg_buf[com_id, 13];
                    int cali_month = Tsb.rx_msg_buf[com_id, 14];
                    int cali_date = Tsb.rx_msg_buf[com_id, 15];

                    str = str + "("
                            + cali_year_h.ToString() + cali_year_l.ToString() + "-"
                            + cali_month.ToString() + "-"
                            + cali_date.ToString() + ")";

                    MessageBox.Show(str);
                }
                else
                    MessageBox.Show("获取失败！");
            }));

            Tsb.tsb_cb_buf[com_id] -= DICorrSend_CallBack;
        }


        private void btn_DICorr_RdPara_Click(object sender, EventArgs e)
        {
            Tsb.Instance.tsb_tx_frame(Model.ConstV.Instance.Tool_Addr, 0x6D, null, DICorrRead_CallBack);
        }

        private void btn_CorrCompute_Click(object sender, EventArgs e)//计算刻度系数
        {
            double[,] std_DI12 = new double[6, 12];

            //从dGv2中读取数据
            for (int col = 0; col < 6; col++)
            {
                for (int i = 0; i < 12; i++)
                {
                    Double.TryParse(dGv2.Rows[i].Cells[col + 1].Value.ToString(), out std_DI12[col, i]);
                }
            }

            DICoff = new BLL.DICorr().CorrCompute(std_DI12);//计算并更新校正系数

            //显示计算结果
            for (int i = 0; i < 6; i++)
            {
                dGVr.Rows[0].Cells[i+1].Value = string.Format("{0:f4}", DICoff.bias[i]);
                dGVr.Rows[1].Cells[i+1].Value = string.Format("{0:f4}", DICoff.scale[i]);
            }

            for (int i = 0; i < 3; i++)
            {
                for (int col = 0; col < 3; col++)
                {
                    dGVr.Rows[i + 2].Cells[col + 1].Value = string.Format("{0:f4}", DICoff.posA[i * 3 + col]);
                    dGVr.Rows[i + 2].Cells[col + 4].Value = string.Format("{0:f4}", DICoff.posM[i * 3 + col]);
                }
            }

            btn_DICorrRecord.Enabled = true;
        }


    }
}
