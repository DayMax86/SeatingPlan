Public Class NameCaptureForm
    Public NameToReturn As String
    Private Sub btnSubmitName_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmitName.Click
        NameToReturn = tbxNameBox.Text
        Me.Hide()
        tbxNameBox.Text = ""
    End Sub
End Class