Public Class Pupil

    Implements IComparable

    Private pPosition As Position
    Private pForename As String
    Private pSurname As String
    Private pSEN As Boolean
    Private pAGAT As Boolean
    Private pNILevel As Integer
    Private pX As Integer
    Private pY As Integer

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Dim p1 As Pupil = CType(obj, Pupil)
        If Me.NILevel < p1.NILevel Then
            Return 1
        ElseIf Me.NILevel > p1.NILevel Then
            Return -1
        Else
            Return 0
        End If
    End Function

    Public Enum GenderType
        Boy
        Girl
    End Enum

    Private pGender As GenderType
    'Private pName As String

    Public Sub New(ByVal Gender As GenderType, ByVal name As String, ByVal x As Integer, ByVal y As Integer)
        pGender = Gender
        'pName = name
        pX = x
        pY = y
    End Sub

    Public Sub New(ByVal forename As String, ByVal surname As String, ByVal gender As GenderType, ByVal sen As Boolean, ByVal agat As Boolean, ByVal nilevel As Integer)
        pForename = forename
        pSurname = surname
        pGender = gender
        pSEN = sen
        pAGAT = agat
        pNILevel = nilevel
    End Sub

    Public Sub New()

    End Sub

    Public Property NILevel As Integer
        Get
            Return pNILevel
        End Get
        Set(value As Integer)
            pNILevel = value
        End Set
    End Property

    Public Property forename As String
        Get
            Return pForename
        End Get
        Set(value As String)
            pForename = value
        End Set
    End Property

    Public Property surname As String
        Get
            Return pSurname
        End Get
        Set(value As String)
            pSurname = value
        End Set
    End Property

    Public Property SEN As Boolean
        Get
            Return pSEN
        End Get
        Set(value As Boolean)
            pSEN = value
        End Set
    End Property

    Public Property AGAT As Boolean
        Get
            Return pAGAT
        End Get
        Set(value As Boolean)
            pAGAT = value
        End Set
    End Property

    Public Property Gender As GenderType
        Get
            Return pGender
        End Get
        Set(value As GenderType)
            pGender = value
        End Set
    End Property

    'Public Overloads ReadOnly Property Name As String
    '    Get
    '        Return pName
    '    End Get
    'End Property

    Public Overloads Property Position As Position
        Get
            Return pPosition
        End Get
        Set(ByVal value As Position)
            pPosition = value
        End Set
    End Property

    Public Property X As Integer
        Get
            Return pX
        End Get
        Set(value As Integer)
            pX = value
        End Set
    End Property

    Public Property Y As Integer
        Get
            Return pY
        End Get
        Set(value As Integer)
            pY = value
        End Set
    End Property

End Class
