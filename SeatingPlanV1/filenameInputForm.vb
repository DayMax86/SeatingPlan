Public Class filenameInputForm

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If tab = "room" Then
            If caller = "save" Then
                Form1.Room.SaveToFile(tbxFilename.Text())
            ElseIf caller = "open" Then
                Form1.Room.openFile(tbxFilename.Text())
            End If
        ElseIf tab = "pupil" Then
            If caller = "save" Then
                Form1.savePupilRoster(tbxFilename.Text())
            ElseIf caller = "open" Then
                Form1.openPupilRoster(tbxFilename.Text())
                Form1.updatePupilRoster()
            End If
        ElseIf tab = "seatingPlan" Then
            If caller = "save" Then
                Form1.SeatingPlan.saveToFile(tbxFilename.Text())
            ElseIf caller = "open" Then
                Form1.SeatingPlan.openFile(tbxFilename.Text())
            End If
        End If
        Me.Hide()
    End Sub

    Public caller As String
    Public tab As String

End Class