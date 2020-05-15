namespace TSB
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sPort1 = new System.IO.Ports.SerialPort(this.components);
            this.dGv = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Az = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.My = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.位置2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.位置12ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dGv2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.textBox_LocalGT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_LocalBT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_LocalBAD = new System.Windows.Forms.TextBox();
            this.btn_UpdateInfo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_DICorr_Send = new System.Windows.Forms.Button();
            this.textBox_DI_Code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_DICorrRecord = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_PortOpen = new System.Windows.Forms.Button();
            this.Btn_PortEnum = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGv)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGv2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sPort1
            // 
            this.sPort1.BaudRate = 19200;
            this.sPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SPort1_DataReceived);
            // 
            // dGv
            // 
            this.dGv.AllowUserToAddRows = false;
            this.dGv.AllowUserToDeleteRows = false;
            this.dGv.AllowUserToResizeColumns = false;
            this.dGv.AllowUserToResizeRows = false;
            this.dGv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Ax,
            this.Ay,
            this.Az,
            this.Mx,
            this.My,
            this.Mz});
            this.dGv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dGv.Location = new System.Drawing.Point(575, 235);
            this.dGv.Name = "dGv";
            this.dGv.RowHeadersWidth = 30;
            this.dGv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dGv.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGv.RowTemplate.Height = 23;
            this.dGv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGv.ShowCellErrors = false;
            this.dGv.ShowCellToolTips = false;
            this.dGv.ShowEditingIcon = false;
            this.dGv.ShowRowErrors = false;
            this.dGv.Size = new System.Drawing.Size(595, 302);
            this.dGv.TabIndex = 4;
            this.dGv.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGv_CellMouseDown);
            this.dGv.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGv_RowHeaderMouseDoubleClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.HeaderText = "序号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Width = 65;
            // 
            // Ax
            // 
            this.Ax.HeaderText = "Ax";
            this.Ax.Name = "Ax";
            this.Ax.ReadOnly = true;
            this.Ax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ax.Width = 80;
            // 
            // Ay
            // 
            this.Ay.HeaderText = "Ay";
            this.Ay.Name = "Ay";
            this.Ay.ReadOnly = true;
            this.Ay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ay.Width = 80;
            // 
            // Az
            // 
            this.Az.HeaderText = "Az";
            this.Az.Name = "Az";
            this.Az.ReadOnly = true;
            this.Az.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Az.Width = 80;
            // 
            // Mx
            // 
            this.Mx.HeaderText = "Mx";
            this.Mx.Name = "Mx";
            this.Mx.ReadOnly = true;
            this.Mx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Mx.Width = 80;
            // 
            // My
            // 
            this.My.HeaderText = "My";
            this.My.Name = "My";
            this.My.ReadOnly = true;
            this.My.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.My.Width = 80;
            // 
            // Mz
            // 
            this.Mz.HeaderText = "Mz";
            this.Mz.Name = "Mz";
            this.Mz.ReadOnly = true;
            this.Mz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Mz.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.位置2ToolStripMenuItem,
            this.位置3ToolStripMenuItem,
            this.位置4ToolStripMenuItem,
            this.位置5ToolStripMenuItem,
            this.位置6ToolStripMenuItem,
            this.位置7ToolStripMenuItem,
            this.位置8ToolStripMenuItem,
            this.位置9ToolStripMenuItem,
            this.位置10ToolStripMenuItem,
            this.位置11ToolStripMenuItem,
            this.位置12ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 268);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenuItem1.Text = "位置1";
            // 
            // 位置2ToolStripMenuItem
            // 
            this.位置2ToolStripMenuItem.Name = "位置2ToolStripMenuItem";
            this.位置2ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置2ToolStripMenuItem.Text = "位置2";
            // 
            // 位置3ToolStripMenuItem
            // 
            this.位置3ToolStripMenuItem.Name = "位置3ToolStripMenuItem";
            this.位置3ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置3ToolStripMenuItem.Text = "位置3";
            // 
            // 位置4ToolStripMenuItem
            // 
            this.位置4ToolStripMenuItem.Name = "位置4ToolStripMenuItem";
            this.位置4ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置4ToolStripMenuItem.Text = "位置4";
            // 
            // 位置5ToolStripMenuItem
            // 
            this.位置5ToolStripMenuItem.Name = "位置5ToolStripMenuItem";
            this.位置5ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置5ToolStripMenuItem.Text = "位置5";
            // 
            // 位置6ToolStripMenuItem
            // 
            this.位置6ToolStripMenuItem.Name = "位置6ToolStripMenuItem";
            this.位置6ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置6ToolStripMenuItem.Text = "位置6";
            // 
            // 位置7ToolStripMenuItem
            // 
            this.位置7ToolStripMenuItem.Name = "位置7ToolStripMenuItem";
            this.位置7ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置7ToolStripMenuItem.Text = "位置7";
            // 
            // 位置8ToolStripMenuItem
            // 
            this.位置8ToolStripMenuItem.Name = "位置8ToolStripMenuItem";
            this.位置8ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置8ToolStripMenuItem.Text = "位置8";
            // 
            // 位置9ToolStripMenuItem
            // 
            this.位置9ToolStripMenuItem.Name = "位置9ToolStripMenuItem";
            this.位置9ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置9ToolStripMenuItem.Text = "位置9";
            // 
            // 位置10ToolStripMenuItem
            // 
            this.位置10ToolStripMenuItem.Name = "位置10ToolStripMenuItem";
            this.位置10ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置10ToolStripMenuItem.Text = "位置10";
            // 
            // 位置11ToolStripMenuItem
            // 
            this.位置11ToolStripMenuItem.Name = "位置11ToolStripMenuItem";
            this.位置11ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置11ToolStripMenuItem.Text = "位置11";
            // 
            // 位置12ToolStripMenuItem
            // 
            this.位置12ToolStripMenuItem.Name = "位置12ToolStripMenuItem";
            this.位置12ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.位置12ToolStripMenuItem.Text = "位置12";
            // 
            // dGv2
            // 
            this.dGv2.AllowUserToAddRows = false;
            this.dGv2.AllowUserToDeleteRows = false;
            this.dGv2.AllowUserToResizeColumns = false;
            this.dGv2.AllowUserToResizeRows = false;
            this.dGv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGv2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGv2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dGv2.Location = new System.Drawing.Point(3, 235);
            this.dGv2.Name = "dGv2";
            this.dGv2.RowHeadersWidth = 20;
            this.dGv2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dGv2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGv2.RowTemplate.Height = 23;
            this.dGv2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dGv2.ShowCellErrors = false;
            this.dGv2.ShowCellToolTips = false;
            this.dGv2.ShowEditingIcon = false;
            this.dGv2.ShowRowErrors = false;
            this.dGv2.Size = new System.Drawing.Size(566, 302);
            this.dGv2.TabIndex = 6;
            this.dGv2.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGv2_CellMouseDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "位置";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Ax";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Ay";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Az";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Mx";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "My";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Mz";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // textBox_LocalGT
            // 
            this.textBox_LocalGT.Enabled = false;
            this.textBox_LocalGT.Location = new System.Drawing.Point(17, 45);
            this.textBox_LocalGT.Name = "textBox_LocalGT";
            this.textBox_LocalGT.Size = new System.Drawing.Size(120, 26);
            this.textBox_LocalGT.TabIndex = 8;
            this.textBox_LocalGT.Text = "1.000";
            this.textBox_LocalGT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "当地重力场模量(g)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "当地磁场模量(Gs)";
            // 
            // textBox_LocalBT
            // 
            this.textBox_LocalBT.Location = new System.Drawing.Point(160, 45);
            this.textBox_LocalBT.Name = "textBox_LocalBT";
            this.textBox_LocalBT.Size = new System.Drawing.Size(120, 26);
            this.textBox_LocalBT.TabIndex = 13;
            this.textBox_LocalBT.Text = "0.491";
            this.textBox_LocalBT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "当地磁倾角(°)";
            // 
            // textBox_LocalBAD
            // 
            this.textBox_LocalBAD.Location = new System.Drawing.Point(299, 45);
            this.textBox_LocalBAD.Name = "textBox_LocalBAD";
            this.textBox_LocalBAD.Size = new System.Drawing.Size(120, 26);
            this.textBox_LocalBAD.TabIndex = 15;
            this.textBox_LocalBAD.Text = "45.5";
            this.textBox_LocalBAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_UpdateInfo
            // 
            this.btn_UpdateInfo.AutoSize = true;
            this.btn_UpdateInfo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btn_UpdateInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UpdateInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_UpdateInfo.Location = new System.Drawing.Point(441, 42);
            this.btn_UpdateInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_UpdateInfo.Name = "btn_UpdateInfo";
            this.btn_UpdateInfo.Size = new System.Drawing.Size(88, 28);
            this.btn_UpdateInfo.TabIndex = 16;
            this.btn_UpdateInfo.Text = "更新信息";
            this.btn_UpdateInfo.UseVisualStyleBackColor = true;
            this.btn_UpdateInfo.Click += new System.EventHandler(this.Btn_UpdateInfo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_DICorr_Send);
            this.groupBox1.Controls.Add(this.textBox_DI_Code);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_DICorrRecord);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBox_LocalGT);
            this.groupBox1.Controls.Add(this.btn_UpdateInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_LocalBAD);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_LocalBT);
            this.groupBox1.Location = new System.Drawing.Point(3, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 181);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // btn_DICorr_Send
            // 
            this.btn_DICorr_Send.Location = new System.Drawing.Point(387, 136);
            this.btn_DICorr_Send.Name = "btn_DICorr_Send";
            this.btn_DICorr_Send.Size = new System.Drawing.Size(124, 29);
            this.btn_DICorr_Send.TabIndex = 25;
            this.btn_DICorr_Send.Text = "发送校正参数";
            this.btn_DICorr_Send.UseVisualStyleBackColor = true;
            this.btn_DICorr_Send.Click += new System.EventHandler(this.Btn_DICorr_Send_Click);
            // 
            // textBox_DI_Code
            // 
            this.textBox_DI_Code.Location = new System.Drawing.Point(103, 136);
            this.textBox_DI_Code.MaxLength = 4;
            this.textBox_DI_Code.Name = "textBox_DI_Code";
            this.textBox_DI_Code.Size = new System.Drawing.Size(79, 26);
            this.textBox_DI_Code.TabIndex = 24;
            this.textBox_DI_Code.Text = "1901";
            this.textBox_DI_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBox_DI_Code, "请输入4位ASCII字符");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "测斜编号";
            // 
            // btn_DICorrRecord
            // 
            this.btn_DICorrRecord.Location = new System.Drawing.Point(197, 135);
            this.btn_DICorrRecord.Name = "btn_DICorrRecord";
            this.btn_DICorrRecord.Size = new System.Drawing.Size(147, 29);
            this.btn_DICorrRecord.TabIndex = 8;
            this.btn_DICorrRecord.Text = "读取系数生成文件";
            this.btn_DICorrRecord.UseVisualStyleBackColor = true;
            this.btn_DICorrRecord.Click += new System.EventHandler(this.Btn_DICorrRecord_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(360, 88);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(59, 20);
            this.checkBox6.TabIndex = 22;
            this.checkBox6.Text = "Az反";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(295, 88);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(59, 20);
            this.checkBox5.TabIndex = 21;
            this.checkBox5.Text = "Az反";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(230, 88);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(59, 20);
            this.checkBox4.TabIndex = 20;
            this.checkBox4.Text = "Mx反";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(147, 88);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(59, 20);
            this.checkBox3.TabIndex = 19;
            this.checkBox3.Text = "Az反";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(82, 88);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 20);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Ay反";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 20);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Ax反";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Clear);
            this.groupBox2.Controls.Add(this.btn_PortOpen);
            this.groupBox2.Controls.Add(this.Btn_PortEnum);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.btn_Send);
            this.groupBox2.Location = new System.Drawing.Point(575, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 181);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(23, 145);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(84, 29);
            this.btn_Clear.TabIndex = 7;
            this.btn_Clear.Text = "清空记录";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // btn_PortOpen
            // 
            this.btn_PortOpen.Location = new System.Drawing.Point(195, 39);
            this.btn_PortOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btn_PortOpen.Name = "btn_PortOpen";
            this.btn_PortOpen.Size = new System.Drawing.Size(75, 31);
            this.btn_PortOpen.TabIndex = 6;
            this.btn_PortOpen.Text = "打开";
            this.btn_PortOpen.UseVisualStyleBackColor = true;
            this.btn_PortOpen.Click += new System.EventHandler(this.Btn_PortOpen_Click);
            // 
            // Btn_PortEnum
            // 
            this.Btn_PortEnum.AutoSize = true;
            this.Btn_PortEnum.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Btn_PortEnum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_PortEnum.Location = new System.Drawing.Point(23, 42);
            this.Btn_PortEnum.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_PortEnum.Name = "Btn_PortEnum";
            this.Btn_PortEnum.Size = new System.Drawing.Size(84, 28);
            this.Btn_PortEnum.TabIndex = 5;
            this.Btn_PortEnum.Text = "串口选择";
            this.Btn_PortEnum.UseVisualStyleBackColor = true;
            this.Btn_PortEnum.Click += new System.EventHandler(this.Btn_PortEnum_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(115, 43);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(464, 136);
            this.btn_Send.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(124, 38);
            this.btn_Send.TabIndex = 3;
            this.btn_Send.Text = "发送命令";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip2_ItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "写入文件";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "读取校正参数";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dGv2);
            this.Controls.Add(this.dGv);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "BDS标定软件";
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dGv)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGv2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort sPort1;
        private System.Windows.Forms.DataGridView dGv;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dGv2;
        private System.Windows.Forms.ToolStripMenuItem 位置2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 位置12ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Az;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mx;
        private System.Windows.Forms.DataGridViewTextBoxColumn My;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mz;
        private System.Windows.Forms.TextBox textBox_LocalGT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_LocalBT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_LocalBAD;
        private System.Windows.Forms.Button btn_UpdateInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_PortOpen;
        private System.Windows.Forms.Button Btn_PortEnum;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button btn_DICorrRecord;
        private System.Windows.Forms.TextBox textBox_DI_Code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_DICorr_Send;
        private System.Windows.Forms.Button button1;
    }
}

