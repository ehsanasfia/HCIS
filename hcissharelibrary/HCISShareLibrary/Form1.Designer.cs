namespace HCISShareLibrary
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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.spuAllDBPersoninsureResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNationalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonnelNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFatherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHomePhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsureName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsuranceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuAllDBPersoninsureResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(209, 118);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Location = new System.Drawing.Point(303, 184);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(180, 120);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(180, 120);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.spuAllDBPersoninsureResultBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(209, 71);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // spuAllDBPersoninsureResultBindingSource
            // 
            this.spuAllDBPersoninsureResultBindingSource.DataSource = typeof(HCISShareLibrary.Data.Spu_AllDBPerson_insureResult);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNationalCode,
            this.colPersonnelNo,
            this.colFirstname,
            this.colLastname,
            this.colFatherName,
            this.colBirthDate,
            this.colHomePhone,
            this.colInsureName,
            this.colInsuranceNo,
            this.colExpDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colNationalCode
            // 
            this.colNationalCode.FieldName = "NationalCode";
            this.colNationalCode.Name = "colNationalCode";
            this.colNationalCode.Visible = true;
            this.colNationalCode.VisibleIndex = 0;
            // 
            // colPersonnelNo
            // 
            this.colPersonnelNo.FieldName = "PersonnelNo";
            this.colPersonnelNo.Name = "colPersonnelNo";
            this.colPersonnelNo.Visible = true;
            this.colPersonnelNo.VisibleIndex = 1;
            // 
            // colFirstname
            // 
            this.colFirstname.FieldName = "Firstname";
            this.colFirstname.Name = "colFirstname";
            this.colFirstname.Visible = true;
            this.colFirstname.VisibleIndex = 2;
            // 
            // colLastname
            // 
            this.colLastname.FieldName = "Lastname";
            this.colLastname.Name = "colLastname";
            this.colLastname.Visible = true;
            this.colLastname.VisibleIndex = 3;
            // 
            // colFatherName
            // 
            this.colFatherName.FieldName = "FatherName";
            this.colFatherName.Name = "colFatherName";
            this.colFatherName.Visible = true;
            this.colFatherName.VisibleIndex = 4;
            // 
            // colBirthDate
            // 
            this.colBirthDate.FieldName = "BirthDate";
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.Visible = true;
            this.colBirthDate.VisibleIndex = 5;
            // 
            // colHomePhone
            // 
            this.colHomePhone.FieldName = "HomePhone";
            this.colHomePhone.Name = "colHomePhone";
            this.colHomePhone.Visible = true;
            this.colHomePhone.VisibleIndex = 6;
            // 
            // colInsureName
            // 
            this.colInsureName.FieldName = "InsureName";
            this.colInsureName.Name = "colInsureName";
            this.colInsureName.Visible = true;
            this.colInsureName.VisibleIndex = 7;
            // 
            // colInsuranceNo
            // 
            this.colInsuranceNo.FieldName = "InsuranceNo";
            this.colInsuranceNo.Name = "colInsuranceNo";
            this.colInsuranceNo.Visible = true;
            this.colInsuranceNo.VisibleIndex = 8;
            // 
            // colExpDate
            // 
            this.colExpDate.FieldName = "ExpDate";
            this.colExpDate.Name = "colExpDate";
            this.colExpDate.Visible = true;
            this.colExpDate.VisibleIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 278);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.textEdit1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spuAllDBPersoninsureResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource spuAllDBPersoninsureResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonnelNo;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstname;
        private DevExpress.XtraGrid.Columns.GridColumn colLastname;
        private DevExpress.XtraGrid.Columns.GridColumn colFatherName;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn colHomePhone;
        private DevExpress.XtraGrid.Columns.GridColumn colInsureName;
        private DevExpress.XtraGrid.Columns.GridColumn colInsuranceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colExpDate;
    }
}

