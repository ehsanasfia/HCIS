Public Class frmBazneshaste

    Private Sub dpDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dpStartDate.Validating, dpEndDate.Validating
        Try
            If CType(sender, FarsiLibrary.Win.Controls.FADatePicker).SelectedDateTime Is Nothing Then
                MessageBox.Show("تاریخ وارد شده معتبر نمی باشد" + vbNewLine + "لطفاً تاریخ صحیح را وارد نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmRptPatients_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dpStartDate.SelectedDateTime = Date.Now
        dpEndDate.SelectedDateTime = Date.Now

    End Sub
    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        Try
            BazneshasteTableAdapter.Fill(DS.bazneshaste, dpStartDate.Text, dpEndDate.Text)
            Dim rpt As New rptBazneshaste
            rpt.SetDataSource(DS)
            rpt.SetParameterValue("StartDate", dpStartDate.Text)
            rpt.SetParameterValue("EndDate", dpEndDate.Text)
            Dim diag As New dialogPrint2(rpt)
            Me.Close()
            diag.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class