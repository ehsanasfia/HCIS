Public Class frmMain
    Private User As SecurityLoginsAndAccessControl.User
    Private buttonType As String, StartDate As String, EndDate As String, ProcedureName As String, FileName As String, tableName As String
    Private PT As New PersianToolS.PersinToolsClass
    Private dataS As New DataSet
    Private sumOfPayment As Int64, JobStatus As Integer = 0
    Private QA As New ReaderDatasetTableAdapters.QueriesTableAdapter

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim Cmd As New SqlClient.SqlCommand
        Dim Conn As New SqlClient.SqlConnection(My.Settings.HospitalConnectionString)
        Dim pc As New Globalization.PersianCalendar()
        Try
            Cmd.Connection = Conn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = ProcedureName
            Cmd.CommandTimeout = 1200
            Cmd.Parameters.Add("FromDate", SqlDbType.Char, 10)
            Cmd.Parameters.Add("ToDate", SqlDbType.Char, 10)
            Cmd.Parameters("FromDate").Value = StartDate
            Cmd.Parameters("ToDate").Value = EndDate
            Dim dta As New SqlClient.SqlDataAdapter(Cmd)
            dataS = New ReaderDataset
            dta.Fill(dataS.Tables(tableName))
            sumOfPayment = 0
            For Each row In dataS.Tables(tableName).Rows
                sumOfPayment += Val(row("PayMent"))
            Next

          


            'Throw New Exception("حجم فایل ایجاد شده زیاد است" + vbNewLine + "سیستم قادر به پردازش نمی باشد")
            JobStatus = 100
        Catch ex As Exception
            JobStatus = 0
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS.showsarpaee' table. You can move, or remove it, as needed.
        Me.ShowsarpaeeTableAdapter.Fill(Me.DS.showsarpaee)


        Dim diagLogin As New SecurityLoginsAndAccessControl.dialogLogin()
        Me.Hide()
        If diagLogin.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.User = diagLogin.User
            Dim upc As New SecurityLoginsAndAccessControl.UserPermissionsController(User.Username)
            upc.GetMenuPermissions(mainMenu, MyClass.Name)
            Me.Show()
        Else
            Application.Exit()
            Exit Sub
        End If
        mnuSave.Visible = False
    End Sub

    Public Sub New()
        Threading.Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.GetCultureInfo("fa-IR")
        Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo("fa-IR")
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Select Case JobStatus
            Case 100
                mnuSave.Visible = True
                tsStatusLabel.Text = "مجموع هزینه پرونده های دریافت شده :  " + Strings.FormatCurrency(sumOfPayment, 0)
                tsStatusLabel.ForeColor = SystemColors.ControlText
                grdFile.Visible = True
            Case 0
                mnuSave.Visible = False
                tsStatusLabel.Text = "خطا"
                grdFile.Visible = False
        End Select
        grdFile.DataSource = dataS
        grdFile.DataMember = tableName
      

        Dim col As DataGridViewTextBoxColumn
        For Each col In grdFile.Columns
            Select Case col.Name
                Case "PersonalNo"
                    col.HeaderText = "شماره پرسنلی"
                Case "PersonnelNo"
                    col.HeaderText = "شماره پرسنلی"
                Case "MedicalID"
                    col.HeaderText = "شناسه پزشکی"
                Case "Relation"
                    col.HeaderText = "کد نسبت"
                Case "DocumentID"
                    col.HeaderText = "شماره پرونده"
                Case "Description"
                    col.HeaderText = "توضیحات"
                Case "PayMent"
                    col.HeaderText = "هزینه"
                    col.DefaultCellStyle.Format = "C0"
                Case "ResidentDate"
                    col.HeaderText = "تاریخ پذیرش"
                    col.DefaultCellStyle.Format = "0000/00/00"
                Case "EndResidentDate"
                    col.HeaderText = "تاریخ ترخیص"
                    col.DefaultCellStyle.Format = "0000/00/00"
                    grdFile.Sort(col, System.ComponentModel.ListSortDirection.Ascending)
                Case "VisitDate"
                    col.HeaderText = "تاریخ ویزیت"
                    col.DefaultCellStyle.Format = "0000/00/00"
                    grdFile.Sort(col, System.ComponentModel.ListSortDirection.Ascending)
                Case "DocDate"
                    col.HeaderText = "تاریخ مراجعه"
                    col.DefaultCellStyle.Format = "0000/00/00"
                    grdFile.Sort(col, System.ComponentModel.ListSortDirection.Ascending)
                Case Else
                    col.Visible = False
            End Select
        Next

        If tableName = "NonXml" Then
            'نمایش گرید جهت دیدن اطلاعات سرپایی ها
            GridControl1.Visible = True
            Me.ShowsarpaeeTableAdapter.Fill(Me.DS.showsarpaee)
        End If
        grdFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                dataS.Tables(tableName).WriteXml(SaveFileDialog1.FileName)
                MessageBox.Show("فایل با موفقیت ذخیره گردید", "ذخیره سازی", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub خروجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub mnuRetrive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRetrive.Click, mnuRetriveBastari.Click, mnuRetriveKharej.Click
        If BackgroundWorker1.IsBusy Then
            MessageBox.Show("نرم افزار در حال پردازش درخواست قبلی شما می باشد" + vbCrLf + "لطفاً صبر کنید", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Sub
        End If
        buttonType = CType(sender, ToolStripMenuItem).Name.Substring(10)
        Dim diag As New dialogInputDate()
        diag.dpStartDate.SelectedDateTime = DateTime.Now
        diag.dpEndDate.SelectedDateTime = DateTime.Now
        Select Case buttonType
            Case ""
                diag.lbl.Text = "دریافت اطلاعات مربوط به پرونده های سرپایی بازنشستگان"
                ProcedureName = "CreateASD"
                tableName = "NonXml"
                If tableName = "NonXml" Then
                   

                    GridControl1.Visible = True

                End If
            Case "Bastari"
                diag.lbl.Text = "دریافت اطلاعات مربوط به پرونده های بستری بازنشستگان"
                ProcedureName = "CreateASDBastari"
                tableName = "ResXml"
                If tableName = "ResXml" Then
                    GridControl1.Visible = False
                End If
            Case "Kharej"
                diag.lbl.Text = "دریافت اطلاعات مربوط به پرونده های خارج از سازمان بازنشستگان"
                ProcedureName = "CreateASDkharej"
                tableName = "OutXml"
                If tableName = "OutXml" Then
                    GridControl1.Visible = False
                End If
            Case Else
                Exit Sub
        End Select
        If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
            StartDate = diag.dpStartDate.Text
            EndDate = diag.dpEndDate.Text
            If DateTime.Parse("0621/02/17") = PT.PersianToDate(StartDate) Or DateTime.Parse("0621/02/17") = PT.PersianToDate(EndDate) Then
                MessageBox.Show("تاریخ وارد شده معتبر نمی باشد،لطفا تاریخ صحیح را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Exit Sub
            End If
            StartDate = PT.DateToPersian(PT.PersianToDate(StartDate)).ShortDate
            EndDate = PT.DateToPersian(PT.PersianToDate(EndDate)).ShortDate
            Try
                tsStatusLabel.Text = "در حال دریافت اطلاعات، لطفاً صبر کنید ..."
                tsStatusLabel.ForeColor = Color.Red
                BackgroundWorker1.RunWorkerAsync()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub مدیریتکاربرانToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles مدیریتکاربرانToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy Then
            MessageBox.Show("نرم افزار در حال پردازش درخواست قبلی شما می باشد" + vbCrLf + "لطفاً صبر کنید", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            Exit Sub
        End If
        Dim frmManageUsers As New SecurityLoginsAndAccessControl.frmManageUsers(User.Username, MyClass.Name, mainMenu)
        frmManageUsers.ShowDialog()
        Dim upc As New SecurityLoginsAndAccessControl.UserPermissionsController(User.Username)
        upc.GetMenuPermissions(mainMenu, MyClass.Name)
        If sumOfPayment <= 0 Then
            mnuSave.Visible = False
        End If
    End Sub

    Private Sub خواندنفایلToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خواندنفایلToolStripMenuItem.Click
        GridControl1.Visible = False
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                dataS = New DataSet
                dataS.ReadXml(OpenFileDialog1.FileName)
                Dim table As DataTable
                Dim uploadTable As New ReaderDataset.Tbl_Baz_FileLoadDataTable
                Dim tableName As String = ""
                For Each table In dataS.Tables
                    If table.Rows.Count > 0 Then
                        tableName = table.TableName
                    End If
                Next
                sumOfPayment = 0
                For Each row As DataRow In dataS.Tables(tableName).Rows
                    sumOfPayment += Val(row("PayMent"))
                Next
                For Each row As DataRow In dataS.Tables(tableName).Rows
                    Dim uploadRow As ReaderDataset.Tbl_Baz_FileLoadRow = uploadTable.NewRow()
                    For Each field As DataColumn In row.Table.Columns
                        Select Case field.ColumnName
                            Case "PersonnelNo"
                                uploadRow("PersonalNo") = row(field.ColumnName)
                            Case Else
                                uploadRow(field.ColumnName) = row(field.ColumnName)
                        End Select
                    Next
                    uploadTable.AddTbl_Baz_FileLoadRow(uploadRow)
                Next

                Dim uploadAdapter As New ReaderDatasetTableAdapters.Tbl_Baz_FileLoadTableAdapter

                QA.ClearFileLoadTableQuery()
                'MessageBox.Show(uploadAdapter.Connection.ConnectionTimeout)
                uploadAdapter.Update(uploadTable)
                uploadAdapter.Fill(uploadTable)

                tsStatusLabel.Text = "مجموع هزینه فایل انتخاب شده :  " + Strings.FormatCurrency(sumOfPayment, 0)
                tsStatusLabel.ForeColor = SystemColors.ControlText

                grdFile.DataSource = uploadTable 'dataS
                'grdFile.DataMember = tableName
                Dim col As DataGridViewTextBoxColumn
                For Each col In grdFile.Columns
                    Select Case col.Name
                        Case "FirstName"
                            col.HeaderText = "نام"
                        Case "LastName"
                            col.HeaderText = "نام خانوادگی"
                        Case "PersonalNo"
                            col.HeaderText = "شماره پرسنلی"
                        Case "PersonnelNo"
                            col.HeaderText = "شماره پرسنلی"
                        Case "MedicalID"
                            col.HeaderText = "شناسه پزشکی"
                        Case "Relation"
                            col.HeaderText = "کد نسبت"
                        Case "DocumentID"
                            col.HeaderText = "شماره پرونده"
                            col.Visible = False
                        Case "Description"
                            col.HeaderText = "توضیحات"
                        Case "PayMent"
                            col.HeaderText = "هزینه"
                            col.DefaultCellStyle.Format = "C0"
                        Case "MedicalService"
                            col.HeaderText = "کد خدمت"
                            If tableName = "NonXml" Then
                                col.Visible = True
                            Else
                                col.Visible = False
                            End If
                        Case "ResidentDate"
                            col.HeaderText = "تاریخ پذیرش"
                            col.DefaultCellStyle.Format = "0000/00/00"
                            If tableName = "ResXml_error" Then
                                col.Visible = True
                            Else
                                col.Visible = False
                            End If
                        Case "EndResidentDate"
                            col.HeaderText = "تاریخ ترخیص"
                            col.DefaultCellStyle.Format = "0000/00/00"
                            grdFile.Sort(col, System.ComponentModel.ListSortDirection.Ascending)
                            If tableName = "ResXml_error" Then
                                col.Visible = True
                            Else
                                col.Visible = False
                            End If
                        Case "VisitDate"
                            col.HeaderText = "تاریخ ویزیت"
                            col.DefaultCellStyle.Format = "0000/00/00"
                            grdFile.Sort(col, System.ComponentModel.ListSortDirection.Ascending)
                            If tableName = "NonXml_error" Then
                                col.Visible = True
                            Else
                                col.Visible = False
                            End If
                        Case "DocDate"
                            col.HeaderText = "تاریخ مراجعه"
                            col.DefaultCellStyle.Format = "0000/00/00"
                            grdFile.Sort(col, System.ComponentModel.ListSortDirection.Ascending)
                            If tableName = "OutXml_error" Then
                                col.Visible = True
                            Else
                                col.Visible = False
                            End If
                        Case Else
                            col.Visible = False
                    End Select
                Next
                grdFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub فیزیوتراپیToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles فیزیوتراپیToolStripMenuItem.Click
        Me.Hide()
        frmBazneshaste.ShowDialog()
        Me.Show()
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText

        If e.Column.FieldName = "" Then e.DisplayText = (e.RowHandle + 1).ToString
    End Sub

    Private Sub چاپToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles چاپToolStripMenuItem.Click

        Try
            GridView1.ShowPrintPreview()
        Catch ex As Exception

        End Try

    End Sub


End Class
