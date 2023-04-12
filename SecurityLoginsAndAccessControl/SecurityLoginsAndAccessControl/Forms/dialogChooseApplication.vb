﻿Imports System.Windows.Forms

Public Class dialogChooseApplication

    Private User As User
    Public ChoosenDepartment As Short, ChoosenDepartmentName As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TblApplicationDepartmentsBindingSource.Position >= 0 Then
            ChoosenDepartment = CType(TblApplicationDepartmentsBindingSource.Current, DataRowView).Item("IDint")
            ChoosenDepartmentName = DS.Vw_DepartmentParents.Select("IDint = " + CType(TblApplicationDepartmentsBindingSource.Current, DataRowView).Item("IDint").ToString).First.Item("Name")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else : MessageBox.Show("ابتدا بخش مورد نظر حود را انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dialogChooseApplication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'TODO: This line of code loads data into the 'DS.department' table. You can move, or remove it, as needed.
            Me.DepartmentTableAdapter.Fill(Me.DS.Vw_DepartmentParents)
            For Each row In DS.Vw_DepartmentParents
                If row.IDInt = 127 Then
                    row.Name = "داروخانه فوق تخصصی"
                End If
            Next
            'TODO: This line of code loads data into the 'DS.tblApplicationDepartments' table. You can move, or remove it, as needed.
            Me.TblApplicationDepartmentsTableAdapter.FillbyApplicationName(Me.DS.tblApplicationDepartments, (New ApplicationServices.ApplicationBase).Info.AssemblyName)
            If DS.tblApplicationDepartments.Rows.Count <= 0 Then
                Me.Close()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.ChoosenDepartment = 0
                Exit Sub
            End If

            If Not User.Username = "administrator" Then
                Me.TblApplicationDepartmentsTableAdapter.FillByUserID(Me.DS.tblApplicationDepartments, User.UserID)
            End If

        Catch ex As SqlClient.SqlException
            If ex.Message Like "?server was not found?" Then
                MessageBox.Show("خطا در اتصال به سرور" + vbCrLf + "لطفاً با مدیر سیستم تماس بگیرید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            ElseIf ex.Message.Contains("HCIS.dbo.Department") Then
                Me.Close()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.ChoosenDepartment = 0
                Exit Sub
            Else
                MessageBox.Show(ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub New(ByVal User As User)
        Me.User = User
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        If TblApplicationDepartmentsBindingSource.Position >= 0 Then
            OK_Button_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        MessageBox.Show(e.Exception.Message)
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TblApplicationDepartmentsBindingSource.Position >= 0 Then
                OK_Button_Click(Nothing, Nothing)
            End If
        End If
    End Sub
End Class
