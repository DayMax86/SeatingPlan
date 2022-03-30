Public Class RoomItem

    Private pImage As Bitmap
    Private pPosition As Position
    Private pName As String

    Public Sub New(ByVal image As Bitmap, ByVal name As String)
        pImage = image
        pName = name
    End Sub

    Public Sub New()

    End Sub

    Public Property Image As Bitmap
        Get
            Return pImage
        End Get
        Set(value As Bitmap)
            pImage = value
        End Set
    End Property

    Public Property Position As Position
        Get
            Return pPosition
        End Get
        Set(ByVal value As Position)
            pPosition = value
        End Set
    End Property

    Public Property name As String
        Get
            Return pName
        End Get
        Set(value As String)
            pName = value
        End Set
    End Property

End Class
