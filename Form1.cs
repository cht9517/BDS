using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TSB
{
    public partial class FrmMain : Form
    {

        private double BT_local = 0.491;
        private double BAD_local = 45.5;//当地磁倾角

        private int pos12_id = 0;


        public FrmMain()
        {
            InitializeComponent();
        }


        private void Btn_PortEnum_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                string[] portList = System.IO.Ports.SerialPort.GetPortNames();

                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(portList);
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }));
        }

        private void Btn_PortOpen_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
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
                            Tsb.Instance.port_open(comboBox1.Text);
                            btn_PortOpen.Text = "关闭";
                            btn_PortOpen.BackColor = Color.Green;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "串口输入错误");
                        }

                    }
                }
            }));

        }


        private void update_dgv(int com_id)
        {
            this.Invoke(new Action(() =>
            {
                int id = dGv.Rows.Add();
                dGv.Rows[id].Cells[0].Value = id;
                dGv.FirstDisplayedScrollingRowIndex = id;

                for(int i=0; i<6; i++)
                {
                    short val = (short)(Tsb.rx_msg_buf[com_id, 2 * i + 8] + (Tsb.rx_msg_buf[com_id, 2 * i + 9] << 8));
                    float fval = val / 10000.0f;
                    dGv.Rows[id].Cells[i+1].Value = string.Format("{0:f4}", fval);
                }
            }));

            Tsb.tsb_cb_buf[com_id] -= update_dgv;
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {

            if (Tsb.Instance.tsb_tx_frame(0x0f, 0x69, null, update_dgv))
            {
                //int id = dGv.Rows.Add();
                //dGv.Rows[id].Cells[0].Value = id;
                //dGv.FirstDisplayedScrollingRowIndex = id;
            }

        }

        private void DGv_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for(int col=1; col <dGv.Columns.Count; col++)
            {
                dGv2.Rows[pos12_id].Cells[col].Value = dGv.Rows[e.RowIndex].Cells[col].Value;
            }
            if(pos12_id < 11)
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

        private void ContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem != null)
            {
                int pos;
                if(Int32.TryParse(e.ClickedItem.ToString().Substring(2), out pos))
                {
                    if ((pos > 0) && (pos <= 12) && (dGv.SelectedRows.Count > 0))
                    {
                        for (int col = 1; col < dGv.Columns.Count; col++)
                        {
                            dGv2.Rows[pos-1].Cells[col].Value = dGv.SelectedRows[0].Cells[col].Value;
                        }
                    }
                }

                if (pos12_id < 11)
                    pos12_id++;
            }
        }

        private void DGv2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private ExcelOp xlsOp;
        private void ContextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            DialogResult dr = saveFileDialog1.ShowDialog();

            if (dr == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {

                xlsOp = new ExcelOp(saveFileDialog1.FileName, 1);

                for (int row = 0; row < 12; row++)
                {
                    for (int col = 1; col < dGv.Columns.Count; col++)
                    {
                        xlsOp.CellWr(row+1 , col, string.Format("{0: 0.0000;-0.0000}", dGv2.Rows[row].Cells[col].Value));
                    }
                }

                xlsOp.ExcelSave(saveFileDialog1.FileName);

                xlsOp.ExcelClose();

                /*txt 文件操作
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                for (int row = 0; row < 12; row++)
                {
                    string str = "";
                    for (int col = 1; col < dGv.Columns.Count; col++)
                    {
                        str += string.Format("{0: 0.0000;-0.0000}", dGv2.Rows[row].Cells[col].Value) + ",";
                    }
                    sw.WriteLine(str.Substring(0, str.Length - 1));
                }

                sw.Flush();

                sw.Close();
                fs.Close();

                System.Diagnostics.Process.Start("notepad.exe", saveFileDialog1.FileName);*/
            }
        }

        private void UpdatePosInfo()
        {
            if (Double.TryParse(textBox_LocalBT.Text, out BT_local))
            {
                if (Double.TryParse(textBox_LocalBAD.Text, out BAD_local))
                {
                    dGv2.Rows.Clear();

                    double BV = BT_local * Math.Sin(Math.PI * BAD_local / 180.0);
                    double BH = BT_local * Math.Cos(Math.PI * BAD_local / 180.0);

                    dGv2.Rows.Add(1, 1, 0, 0, -BV, 0, -BH);
                    dGv2.Rows.Add(2, 0, 1, 0, 0, -BV, -BH);
                    dGv2.Rows.Add(3, -1, 0, 0, BV, 0, -BH);
                    dGv2.Rows.Add(4, 0, -1, 0, 0, BV, -BH);
                    dGv2.Rows.Add(5, 0, -1, 0, 0, BV, BH);
                    dGv2.Rows.Add(6, -1, 0, 0, BV, 0, BH);
                    dGv2.Rows.Add(7, 0, 1, 0, 0, -BV, BH);
                    dGv2.Rows.Add(8, 1, 0, 0, -BV, 0, BH);
                    dGv2.Rows.Add(9, 0, 0, 1, -BH, 0, -BV);
                    dGv2.Rows.Add(10, 0, 0, 1, BH, 0, -BV);
                    dGv2.Rows.Add(11, 0, 0, -1, -BH, 0, BV);
                    dGv2.Rows.Add(12, 0, 0, -1, +BH, 0, BV);
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


        private void DICorrSend_CallBack(int com_id)
        {
            this.Invoke(new Action(() =>
            {
                if(Tsb.rx_msg_buf[com_id, 7] == 4)
                {
                    MessageBox.Show("配置成功！");
                }
                else
                    MessageBox.Show("失败！");
            }));

            Tsb.tsb_cb_buf[com_id] -= DICorrSend_CallBack;
        }

        private void Btn_DICorrRecord_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                xlsOp = new ExcelOp(openFileDialog1.FileName, 1);

                float[] DICorrPara = new float[30];//bias,scale,pos

                for (int col = 0; col < 6; col++)
                {
                    float.TryParse(xlsOp.CellRd(17, col + 1), out DICorrPara[col]);//bias

                    float.TryParse(xlsOp.CellRd(27, col + 1), out DICorrPara[col + 6]);//scale
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        float.TryParse(xlsOp.CellRd(36 + i, j + 1), out DICorrPara[12 + i * 3 + j]);//pos_A
                        float.TryParse(xlsOp.CellRd(36 + i, j + 4), out DICorrPara[21 + i * 3 + j]);//pos_M
                    }
                }

                xlsOp.ExcelClose();

                string di_code = textBox_DI_Code.Text;
                if (di_code.Length < 4)
                    di_code = di_code.PadLeft(4);

                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                int day = DateTime.Now.Day;

                byte[] send_buf = new byte[128];

                for (int i = 0; i < 4; i++)
                    send_buf[i] = (byte)(di_code[i]);
                send_buf[4] = (byte)(year / 100);
                send_buf[5] = (byte)(year % 100);
                send_buf[6] = (byte)month;
                send_buf[7] = (byte)day;

                string di_cal_date = DateTime.Today.ToString("yyyy-MM-dd");

                for (int i = 0; i < 30; i++)
                {
                    byte[] bt = BitConverter.GetBytes(DICorrPara[i]);
                    Buffer.BlockCopy(bt, 0, send_buf, 8 + i * 4, 4);
                }

                FileStream fs = new FileStream(Path.GetDirectoryName(openFileDialog1.FileName)
                                                + "\\" + di_code + "(" + di_cal_date + ")" + ".bds",
                                                FileMode.Create, FileAccess.Write);
                fs.Write(send_buf, 0, send_buf.Length);
                fs.Close();
            }
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

                    if (Tsb.Instance.tsb_tx_frame(0x0f, 0x6A, send_buf, DICorrSend_CallBack))
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
                            + cali_year_h.ToString() + cali_year_l.ToString() +"-" 
                            + cali_month.ToString() + "-" 
                            + cali_date.ToString()+ ")";

                    MessageBox.Show(str);
                }
                else
                    MessageBox.Show("获取失败！");
            }));

            Tsb.tsb_cb_buf[com_id] -= DICorrSend_CallBack;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Tsb.Instance.tsb_tx_frame(0x0f, 0x6D, null, DICorrRead_CallBack);


        }
    }
}
