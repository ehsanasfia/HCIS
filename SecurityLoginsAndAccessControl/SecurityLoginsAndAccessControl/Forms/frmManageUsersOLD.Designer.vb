<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageUsersOLD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.grdMngUsers = New System.Windows.Forms.DataGridView
        Me.UserNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FirstNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DisabledDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PersonalNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descriptions = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cMnu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.کاربرجدیدToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.حذفکاربرToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ویرایشکاربرToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.تغییرکلمهعبورToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.تعیینسطحدسترسیToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.فعالسازیToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.دسترسیبهنرمافزارهاToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TblUsersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS = New SecurityLoginsAndAccessControl.DS
        Me.btnNewUser = New System.Windows.Forms.Button
        Me.btnChangePassword = New System.Windows.Forms.Button
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnChangePermissions = New System.Windows.Forms.Button
        Me.btnRemoveUser = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.TblUsersTableAdapter = New SecurityLoginsAndAccessControl.DSTableAdapters.tblUsersTableAdapter
        Me.btnEditUser = New System.Windows.Forms.Button
        Me.btnManageUserApplication = New System.Windows.Forms.Button
        Me.TblApplicationDepartmentsTableAdapter = New SecurityLoginsAndAccessControl.DSTableAdapters.tblApplicationDepartmentsTableAdapter
        CType(Me.grdMngUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cMnu1.SuspendLayout()
        CType(Me.TblUsersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdMngUsers
        '
        Me.grdMngUsers.AllowUserToAddRows = False
        Me.grdMngUsers.AllowUserToDeleteRows = False
        Me.grdMngUsers.AllowUserToResizeRows = False
        Me.grdMngUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdMngUsers.AutoGenerateColumns = False
        Me.grdMngUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grdMngUsers.BackgroundColor = System.Drawing.SystemColors.Window
        Me.grdMngUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.grdMngUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdMngUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserNameDataGridViewTextBoxColumn, Me.FirstNameDataGridViewTextBoxColumn, Me.LastNameDataGridViewTextBoxColumn, Me.DisabledDataGridViewCheckBoxColumn, Me.PersonalNoDataGridViewTextBoxColumn, Me.Descriptions})
        Me.grdMngUsers.ContextMenuStrip = Me.cMnu1
        Me.grdMngUsers.DataSource = Me.TblUsersBindingSource
        Me.grdMngUsers.Location = New System.Drawing.Point(159, 70)
        Me.grdMngUsers.Name = "grdMngUsers"
        Me.grdMngUsers.ReadOnly = True
        Me.grdMngUsers.RowHeadersVisible = False
        Me.grdMngUsers.RowHeadersWidth = 20
        Me.grdMngUsers.RowTemplate.Height = 18
        Me.grdMngUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdMngUsers.Size = New System.Drawing.Size(492, 267)
        Me.grdMngUsers.TabIndex = 10
        '
        'UserNameDataGridViewTextBoxColumn
        '
        Me.UserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName"
        Me.UserNameDataGridViewTextBoxColumn.FillWeight = 89.54314!
        Me.UserNameDataGridViewTextBoxColumn.HeaderText = "نام کاربری"
        Me.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn"
        Me.UserNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.UserNameDataGridViewTextBoxColumn.Width = 82
        '
        'FirstNameDataGridViewTextBoxColumn
        '
        Me.FirstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName"
        Me.FirstNameDataGridViewTextBoxColumn.FillWeight = 89.54314!
        Me.FirstNameDataGridViewTextBoxColumn.HeaderText = "نام"
        Me.FirstNameDataGridViewTextBoxColumn.Name = "FirstNameDataGridViewTextBoxColumn"
        Me.FirstNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.FirstNameDataGridViewTextBoxColumn.Width = 46
        '
        'LastNameDataGridViewTextBoxColumn
        '
        Me.LastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName"
        Me.LastNameDataGridViewTextBoxColumn.FillWeight = 89.54314!
        Me.LastNameDataGridViewTextBoxColumn.HeaderText = "نام خانوادگی"
        Me.LastNameDataGridViewTextBoxColumn.Name = "LastNameDataGridViewTextBoxColumn"
        Me.LastNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.LastNameDataGridViewTextBoxColumn.Width = 97
        '
        'DisabledDataGridViewCheckBoxColumn
        '
        Me.DisabledDataGridViewCheckBoxColumn.DataPropertyName = "Disabled"
        Me.DisabledDataGridViewCheckBoxColumn.FillWeight = 80.0!
        Me.DisabledDataGridViewCheckBoxColumn.HeaderText = "غیر فعال"
        Me.DisabledDataGridViewCheckBoxColumn.Name = "DisabledDataGridViewCheckBoxColumn"
        Me.DisabledDataGridViewCheckBoxColumn.ReadOnly = True
        Me.DisabledDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DisabledDataGridViewCheckBoxColumn.Width = 56
        '
        'PersonalNoDataGridViewTextBoxColumn
        '
        Me.PersonalNoDataGridViewTextBoxColumn.DataPropertyName = "PersonalNo"
        Me.PersonalNoDataGridViewTextBoxColumn.FillWeight = 60.0!
        Me.PersonalNoDataGridViewTextBoxColumn.HeaderText = "شماره پرسنلی"
        Me.PersonalNoDataGridViewTextBoxColumn.Name = "PersonalNoDataGridViewTextBoxColumn"
        Me.PersonalNoDataGridViewTextBoxColumn.ReadOnly = True
        Me.PersonalNoDataGridViewTextBoxColumn.Width = 109
        '
        'Descriptions
        '
        Me.Descriptions.DataPropertyName = "Descriptions"
        Me.Descriptions.FillWeight = 89.54314!
        Me.Descriptions.HeaderText = "توضیحات"
        Me.Descriptions.Name = "Descriptions"
        Me.Descriptions.ReadOnly = True
        Me.Descriptions.Width = 75
        '
        'cMnu1
        '
        Me.cMnu1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cMnu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.کاربرجدیدToolStripMenuItem, Me.حذفکاربرToolStripMenuItem, Me.ویرایشکاربرToolStripMenuItem, Me.ToolStripSeparator1, Me.تغییرکلمهعبورToolStripMenuItem, Me.تعیینسطحدسترسیToolStripMenuItem, Me.فعالسازیToolStripMenuItem, Me.دسترسیبهنرمافزارهاToolStripMenuItem})
        Me.cMnu1.Name = "cMnu1"
        Me.cMnu1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cMnu1.Size = New System.Drawing.Size(195, 186)
        '
        'کاربرجدیدToolStripMenuItem
        '
        Me.کاربرجدیدToolStripMenuItem.Name = "کاربرجدیدToolStripMenuItem"
        Me.کاربرجدیدToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.کاربرجدیدToolStripMenuItem.Text = "کاربر جدید"
        '
        'حذفکاربرToolStripMenuItem
        '
        Me.حذفکاربرToolStripMenuItem.Name = "حذفکاربرToolStripMenuItem"
        Me.حذفکاربرToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.حذفکاربرToolStripMenuItem.Text = "حذف کاربر"
        '
        'ویرایشکاربرToolStripMenuItem
        '
        Me.ویرایشکاربرToolStripMenuItem.Name = "ویرایشکاربرToolStripMenuItem"
        Me.ویرایشکاربرToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ویرایشکاربرToolStripMenuItem.Text = "ویرایش کاربر"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(191, 6)
        '
        'تغییرکلمهعبورToolStripMenuItem
        '
        Me.تغییرکلمهعبورToolStripMenuItem.Name = "تغییرکلمهعبورToolStripMenuItem"
        Me.تغییرکلمهعبورToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.تغییرکلمهعبورToolStripMenuItem.Text = "تغییر کلمه عبور"
        '
        'تعیینسطحدسترسیToolStripMenuItem
        '
        Me.تعیینسطحدسترسیToolStripMenuItem.Name = "تعیینسطحدسترسیToolStripMenuItem"
        Me.تعیینسطحدسترسیToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.تعیینسطحدسترسیToolStripMenuItem.Text = "تعیین سطح دسترسی"
        '
        'فعالسازیToolStripMenuItem
        '
        Me.فعالسازیToolStripMenuItem.Name = "فعالسازیToolStripMenuItem"
        Me.فعالسازیToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.فعالسازیToolStripMenuItem.Text = "فعال سازی"
        '
        'دسترسیبهنرمافزارهاToolStripMenuItem
        '
        Me.دسترسیبهنرمافزارهاToolStripMenuItem.Name = "دسترسیبهنرمافزارهاToolStripMenuItem"
        Me.دسترسیبهنرمافزارهاToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.دسترسیبهنرمافزارهاToolStripMenuItem.Text = "دسترسی به نرم افزارها"
        '
        'TblUsersBindingSource
        '
        Me.TblUsersBindingSource.DataMember = "tblUsers"
        Me.TblUsersBindingSource.DataSource = Me.DS
        '
        'DS
        '
        Me.DS.DataSetName = "DS"
        Me.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnNewUser
        '
        Me.btnNewUser.Location = New System.Drawing.Point(12, 70)
        Me.btnNewUser.Name = "btnNewUser"
        Me.btnNewUser.Size = New System.Drawing.Size(141, 33)
        Me.btnNewUser.TabIndex = 1
        Me.btnNewUser.Text = "کاربر جدید"
        Me.btnNewUser.UseVisualStyleBackColor = True
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(12, 187)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(141, 33)
        Me.btnChangePassword.TabIndex = 3
        Me.btnChangePassword.Text = "تغییر کلمه عبور"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'txtUserName
        '
        Me.txtUserName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserName.Location = New System.Drawing.Point(439, 21)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(128, 22)
        Me.txtUserName.TabIndex = 7
        '
        'txtFirstName
        '
        Me.txtFirstName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFirstName.Location = New System.Drawing.Point(290, 21)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(116, 22)
        Me.txtFirstName.TabIndex = 8
        '
        'txtLastName
        '
        Me.txtLastName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLastName.Location = New System.Drawing.Point(90, 21)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(116, 22)
        Me.txtLastName.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(573, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "نام کاربری"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(412, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "نام"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(212, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "نام خانوادگی"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFirstName)
        Me.GroupBox1.Controls.Add(Me.txtLastName)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(639, 52)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "محدود کردن لیست کاربران بر اساس"
        '
        'btnChangePermissions
        '
        Me.btnChangePermissions.Location = New System.Drawing.Point(12, 226)
        Me.btnChangePermissions.Name = "btnChangePermissions"
        Me.btnChangePermissions.Size = New System.Drawing.Size(141, 33)
        Me.btnChangePermissions.TabIndex = 4
        Me.btnChangePermissions.Text = "تعیین سطح دسترسی"
        Me.btnChangePermissions.UseVisualStyleBackColor = True
        '
        'btnRemoveUser
        '
        Me.btnRemoveUser.Location = New System.Drawing.Point(12, 109)
        Me.btnRemoveUser.Name = "btnRemoveUser"
        Me.btnRemoveUser.Size = New System.Drawing.Size(141, 33)
        Me.btnRemoveUser.TabIndex = 2
        Me.btnRemoveUser.Text = "حذف کاربر"
        Me.btnRemoveUser.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(12, 304)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(141, 33)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "خروج"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'TblUsersTableAdapter
        '
        Me.TblUsersTableAdapter.ClearBeforeFill = True
        '
        'btnEditUser
        '
        Me.btnEditUser.Location = New System.Drawing.Point(12, 148)
        Me.btnEditUser.Name = "btnEditUser"
        Me.btnEditUser.Size = New System.Drawing.Size(141, 33)
        Me.btnEditUser.TabIndex = 2
        Me.btnEditUser.Text = "ویرایش کاربر"
        Me.btnEditUser.UseVisualStyleBackColor = True
        '
        'btnManageUserApplication
        '
        Me.btnManageUserApplication.Location = New System.Drawing.Point(12, 265)
        Me.btnManageUserApplication.Name = "btnManageUserApplication"
        Me.btnManageUserApplication.Size = New System.Drawing.Size(141, 33)
        Me.btnManageUserApplication.TabIndex = 5
        Me.btnManageUserApplication.Text = "دسترسی به نرم افزارها"
        Me.btnManageUserApplication.UseVisualStyleBackColor = True
        '
        'TblApplicationDepartmentsTableAdapter
        '
        Me.TblApplicationDepartmentsTableAdapter.ClearBeforeFill = True
        '
        'frmManageUsers
        '
        Me.AcceptButton = Me.btnNewUser
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(663, 358)
        Me.Controls.Add(Me.grdMngUsers)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnManageUserApplication)
        Me.Controls.Add(Me.btnNewUser)
        Me.Controls.Add(Me.btnEditUser)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnRemoveUser)
        Me.Controls.Add(Me.btnChangePermissions)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManageUsers"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مدیریت کاربران"
        CType(Me.grdMngUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cMnu1.ResumeLayout(False)
        CType(Me.TblUsersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdMngUsers As System.Windows.Forms.DataGridView
    Friend WithEvents DS As SecurityLoginsAndAccessControl.DS
    Friend WithEvents TblUsersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TblUsersTableAdapter As SecurityLoginsAndAccessControl.DSTableAdapters.tblUsersTableAdapter
    Friend WithEvents btnNewUser As System.Windows.Forms.Button
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnChangePermissions As System.Windows.Forms.Button
    Friend WithEvents کاربرجدیدToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents تغییرکلمهعبورToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents تعیینسطحدسترسیToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents حذفکاربرToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents فعالسازیToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEditUser As System.Windows.Forms.Button
    Friend WithEvents ویرایشکاربرToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FirstNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisabledDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PersonalNoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descriptions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnManageUserApplication As System.Windows.Forms.Button
    Friend WithEvents TblApplicationDepartmentsTableAdapter As SecurityLoginsAndAccessControl.DSTableAdapters.tblApplicationDepartmentsTableAdapter
    Friend WithEvents دسترسیبهنرمافزارهاToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents btnRemoveUser As System.Windows.Forms.Button
    Public WithEvents cMnu1 As System.Windows.Forms.ContextMenuStrip
End Class
