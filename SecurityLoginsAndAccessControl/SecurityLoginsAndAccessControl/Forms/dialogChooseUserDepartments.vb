﻿Imports System.Windows.Forms
Imports System.Linq

Public Class dialogChooseUserDepartments
    Private User As User
    Private AppName As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Dim oldRow As DS.tblUserAccessibleDepartmentsRow
            For Each oldRow In DS.tblUserAccessibleDepartments.Rows
                oldRow.Delete()
            Next
            Dim row As DataGridViewRow
            For Each row In DataGridView1.Rows
                If row.Cells.Item("Accesible").Value Then
                    If (DS.tblUserAccessibleDepartments.Select("AppAccessibleID = " + row.Cells.Item("ID").Value.ToString)).Count = 0 Then
                        Dim newRow As DS.tblUserAccessibleDepartmentsRow = DS.tblUserAccessibleDepartments.NewRow
                        newRow.AppAccessibleID = row.Cells.Item("ID").Value
                        newRow.UserID = User.UserID
                        DS.tblUserAccessibleDepartments.AddtblUserAccessibleDepartmentsRow(newRow)
                    End If
                End If
            Next

            TblUserAccessibleDepartmentsTableAdapter.Update(DS.tblUserAccessibleDepartments)

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dialogChooseUserDepartments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DS.tblUserAccessibleDepartments' table. You can move, or remove it, as needed.
        Me.TblUserAccessibleDepartmentsTableAdapter.FillByUserID(Me.DS.tblUserAccessibleDepartments, User.UserID)
        'TODO: This line of code loads data into the 'DS.tblApplicationDepartments' table. You can move, or remove it, as needed.
        Me.TblApplicationDepartmentsTableAdapter.FillbyApplicationName(Me.DS.tblApplicationDepartments, AppName)
        'TODO: This line of code loads data into the 'DS.department' table. You can move, or remove it, as needed.
        Me.DepartmentTableAdapter.Fill(Me.DS.Vw_DepartmentParents)

        Dim row As DataGridViewRow
        For Each row In DataGridView1.Rows
            row.Cells.Item("Accesible").Value = IIf((DS.tblUserAccessibleDepartments.Select("AppAccessibleID = " + row.Cells.Item("ID").Value.ToString)).Count = 0, False, True)
        Next

        Dim doctorApplication = (New DSTableAdapters.tblApplicationsTableAdapter).GetData().SingleOrDefault(Function(c) c.ApplicationName = "Doctor")

        If Not doctorApplication Is Nothing AndAlso User.ApplicationID = doctorApplication.ApplicationID Then
            Try
                Dim hosDS = New HospitalDataSet
                Dim dta = New HospitalDataSetTableAdapters.DoctorVisitTypeTableAdapter
                dta.FillByUserID(hosDS.DoctorVisitType, User.UserID)
                Dim depTable = TblApplicationDepartmentsTableAdapter.GetData()
                For Each docRow As HospitalDataSet.DoctorVisitTypeRow In hosDS.DoctorVisitType.Rows
                    Dim newRow = DS.tblApplicationDepartments.NewtblApplicationDepartmentsRow()
                    newRow.AppID = doctorApplication.ApplicationID
                    newRow.DepID = docRow.depID
                    If DS.tblApplicationDepartments.SingleOrDefault(Function(c) c.DepID = newRow.DepID) Is Nothing Then
                        DS.tblApplicationDepartments.AddtblApplicationDepartmentsRow(newRow)
                    End If
                Next
                DS.tblApplicationDepartments.AcceptChanges()
            Catch ex As Exception

            End Try
        End If


    End Sub

    Public Sub New(ByVal User As User)
        Me.User = User
        Me.AppName = (New ApplicationServices.ApplicationBase).Info.AssemblyName
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal User As User, ByVal appname As String)
        Me.User = User
        Me.AppName = appname
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

    End Sub
End Class
