namespace SATAService
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblDay = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblCount = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblServiceType = new DevExpress.XtraEditors.LabelControl();
            this.btnSendPhyData = new DevExpress.XtraEditors.SimpleButton();
            this.btnSendVisitData = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton8 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(32265, 32152);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(477, 174);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(249, 41);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "ارسال اطلاعات داروخانه";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(613, 48);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(113, 26);
            this.textEdit1.TabIndex = 2;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(397, 48);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.Size = new System.Drawing.Size(121, 26);
            this.textEdit2.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(732, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 19);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "از تاریخ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(526, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 19);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "لغایت";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(598, 115);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(109, 19);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "روز درحال ارسال";
            // 
            // lblDay
            // 
            this.lblDay.Location = new System.Drawing.Point(483, 115);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(44, 19);
            this.lblDay.TabIndex = 4;
            this.lblDay.Text = "lblDay";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(477, 221);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(249, 41);
            this.simpleButton3.TabIndex = 1;
            this.simpleButton3.Text = "ارسال اطلاعات آزمایشگاه";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(477, 268);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(249, 44);
            this.simpleButton4.TabIndex = 5;
            this.simpleButton4.Text = "ارسال اطلاعات خدمات تشخیصی";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(662, 140);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 19);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "شماره";
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(483, 140);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(59, 19);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "lblCount";
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(477, 318);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(249, 44);
            this.simpleButton5.TabIndex = 5;
            this.simpleButton5.Text = "ارسال اطلاعات خدمات کلینیکی";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(598, 90);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(131, 19);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "بخش در حال ارسال";
            // 
            // lblServiceType
            // 
            this.lblServiceType.Location = new System.Drawing.Point(483, 90);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(52, 19);
            this.lblServiceType.TabIndex = 4;
            this.lblServiceType.Text = "lblType";
            // 
            // btnSendPhyData
            // 
            this.btnSendPhyData.Location = new System.Drawing.Point(477, 416);
            this.btnSendPhyData.Name = "btnSendPhyData";
            this.btnSendPhyData.Size = new System.Drawing.Size(249, 42);
            this.btnSendPhyData.TabIndex = 9;
            this.btnSendPhyData.Text = "ارسال اطلاعات فیزیوتراپی";
            this.btnSendPhyData.Click += new System.EventHandler(this.btnSendPhyData_Click);
            // 
            // btnSendVisitData
            // 
            this.btnSendVisitData.Location = new System.Drawing.Point(477, 368);
            this.btnSendVisitData.Name = "btnSendVisitData";
            this.btnSendVisitData.Size = new System.Drawing.Size(249, 42);
            this.btnSendVisitData.TabIndex = 8;
            this.btnSendVisitData.Text = "ارسال اطلاعات ویزیت ها";
            this.btnSendVisitData.Click += new System.EventHandler(this.btnSendVisitData_Click);
            // 
            // simpleButton6
            // 
            this.simpleButton6.Location = new System.Drawing.Point(477, 464);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(249, 41);
            this.simpleButton6.TabIndex = 1;
            this.simpleButton6.Text = "ارسال اطلاعات دندانپزشکی";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // simpleButton7
            // 
            this.simpleButton7.Location = new System.Drawing.Point(181, 174);
            this.simpleButton7.Name = "simpleButton7";
            this.simpleButton7.Size = new System.Drawing.Size(249, 41);
            this.simpleButton7.TabIndex = 1;
            this.simpleButton7.Text = "ارسال خدمات در بخش بستری";
            this.simpleButton7.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // simpleButton8
            // 
            this.simpleButton8.Location = new System.Drawing.Point(181, 221);
            this.simpleButton8.Name = "simpleButton8";
            this.simpleButton8.Size = new System.Drawing.Size(249, 41);
            this.simpleButton8.TabIndex = 1;
            this.simpleButton8.Text = "ارسال سایر خدمات بخش بستری";
            this.simpleButton8.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 582);
            this.Controls.Add(this.btnSendPhyData);
            this.Controls.Add(this.btnSendVisitData);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblServiceType);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton8);
            this.Controls.Add(this.simpleButton7);
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblDay;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblCount;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblServiceType;
        private DevExpress.XtraEditors.SimpleButton btnSendPhyData;
        private DevExpress.XtraEditors.SimpleButton btnSendVisitData;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private DevExpress.XtraEditors.SimpleButton simpleButton8;
    }
}

