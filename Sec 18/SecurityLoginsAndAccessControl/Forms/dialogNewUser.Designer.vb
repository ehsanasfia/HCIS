<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dialogNewUser
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
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.numPersonalNo = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDescriptions = New System.Windows.Forms.TextBox
        Me.chkOption = New System.Windows.Forms.CheckBox
        Me.cmbOptionSelection = New System.Windows.Forms.ComboBox
        Me.cmbSex = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.numPersonalNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(90, 12)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(142, 22)
        Me.txtUserName.TabIndex = 1
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(90, 40)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(142, 22)
        Me.txtFirstName.TabIndex = 3
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(90, 67)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(142, 22)
        Me.txtLastName.TabIndex = 4
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(241, 14)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(153, 18)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "نام کاربری غیر فعال باشد"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "نام"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "نام خانوادگی"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "شماره پرسنلی"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 14)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "نام کاربری"
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.Location = New System.Drawing.Point(214, 216)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(108, 23)
        Me.btnSubmit.TabIndex = 9
        Me.btnSubmit.Text = "تایید"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(94, 216)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "انصراف"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'numPersonalNo
        '
        Me.numPersonalNo.Location = New System.Drawing.Point(329, 68)
        Me.numPersonalNo.Maximum = New Decimal(New Integer() {1874919423, 2328306, 0, 0})
        Me.numPersonalNo.Name = "numPersonalNo"
        Me.numPersonalNo.Size = New System.Drawing.Size(75, 22)
        Me.numPersonalNo.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "توضیحات"
        '
        'txtDescriptions
        '
        Me.txtDescriptions.Location = New System.Drawing.Point(90, 95)
        Me.txtDescriptions.Multiline = True
        Me.txtDescriptions.Name = "txtDescriptions"
        Me.txtDescriptions.Size = New System.Drawing.Size(313, 60)
        Me.txtDescriptions.TabIndex = 6
        '
        'chkOption
        '
        Me.chkOption.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkOption.AutoSize = True
        Me.chkOption.Location = New System.Drawing.Point(15, 192)
        Me.chkOption.Name = "chkOption"
        Me.chkOption.Size = New System.Drawing.Size(68, 18)
        Me.chkOption.TabIndex = 10
        Me.chkOption.Text = "option1"
        Me.chkOption.UseVisualStyleBackColor = True
        Me.chkOption.Visible = False
        '
        'cmbOptionSelection
        '
        Me.cmbOptionSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbOptionSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOptionSelection.FormattingEnabled = True
        Me.cmbOptionSelection.Location = New System.Drawing.Point(214, 188)
        Me.cmbOptionSelection.Name = "cmbOptionSelection"
        Me.cmbOptionSelection.Size = New System.Drawing.Size(190, 22)
        Me.cmbOptionSelection.TabIndex = 11
        Me.cmbOptionSelection.Visible = False
        '
        'cmbSex
        '
        Me.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSex.FormattingEnabled = True
        Me.cmbSex.Items.AddRange(New Object() {"زن", "مرد"})
        Me.cmbSex.Location = New System.Drawing.Point(90, 161)
        Me.cmbSex.Name = "cmbSex"
        Me.cmbSex.Size = New System.Drawing.Size(142, 22)
        Me.cmbSex.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "جنسیت"
        '
        'dialogNewUser
        '
        Me.AcceptButton = Me.btnSubmit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(416, 253)
        Me.Controls.Add(Me.cmbSex)
        Me.Controls.Add(Me.cmbOptionSelection)
        Me.Controls.Add(Me.chkOption)
        Me.Controls.Add(Me.txtDescriptions)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.numPersonalNo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtUserName)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dialogNewUser"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "کابر جدید"
        CType(Me.numPersonalNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents numPersonalNo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescriptions As System.Windows.Forms.TextBox
    Friend WithEvents chkOption As System.Windows.Forms.CheckBox
    Friend WithEvents cmbOptionSelection As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
