Imports System.Drawing.Graphics
Imports System.Drawing.Font

Public Class Square
    ' Private pPosition As Position
    Private pHighlight As Boolean
    Private pImage As Bitmap
    Private pItem As RoomItem
    Private pPupil As Pupil

    Public Property Position As Position
        Get
            Return Me.Tag
        End Get
        Set(ByVal value As Position)
            Me.Tag = value
        End Set
    End Property

    Public Property Image As Bitmap
        Get
            Return pImage
        End Get
        Set(ByVal value As Bitmap)
            pImage = value
            Me.BackgroundImage = pImage
        End Set
    End Property

    Public Property Item As RoomItem
        Get
            Return pItem
        End Get
        Set(value As RoomItem)
            pItem = value
        End Set
    End Property

    Public Property Pupil As Pupil
        Get
            Return pPupil
        End Get
        Set(value As Pupil)
            pPupil = value
        End Set
    End Property

    Private Sub Square_MouseEnter(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseEnter
        SetHighlight(True)
    End Sub

    Private Sub Square_MouseLeave(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseLeave
        SetHighlight(False)
    End Sub

    Private Sub SetHighlight(ByVal highlight As Boolean)
        pHighlight = highlight
        Me.Refresh()
    End Sub

    Private Sub Square_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If Not Position.Pupil Is Nothing Then
            e.Graphics.DrawString(Position.Pupil.forename(0).ToString(), DefaultFont, Brushes.White, 2, 2)
            e.Graphics.DrawString(Position.Pupil.surname, DefaultFont, Brushes.White, 2, 12)
        End If

        If pHighlight Then
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, Me.Width - 1, Me.Height - 1)
            Dim caption As String = Position.Xpos & "," & Position.Ypos
            e.Graphics.DrawString(caption, SystemFonts.DefaultFont, Brushes.DarkBlue, 5, 5)
        End If
    End Sub

    Private Sub Square_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click
        Form1.Room.OnClick(Form1.TempItem, Me.Position.Xpos, Me.Position.Ypos)
    End Sub
End Class
