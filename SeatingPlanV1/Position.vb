Imports System.Drawing.Graphics

Public Class Position
    Private pX, pY As Integer
    Private pSquare As Square
    Private pRoom As Room
    Private pSeatingPlan As SeatingPlan
    Private pItem As RoomItem
    Private pPupil As Pupil

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal square As Square, ByVal Room As Room)
        pX = x
        pY = y
        pSquare = square
        pSquare.Position = Me
        pRoom = Room
    End Sub

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal square As Square, ByVal SeatingPlan As SeatingPlan)
        pX = x
        pY = y
        pSquare = square
        pSquare.Position = Me
        pSeatingPlan = SeatingPlan
    End Sub

    'Public Sub SetPupil(ByRef pupil As Pupil)
    '    If Not IsNothing(pItem) Or Not IsNothing(pPupil) Then
    '        Throw New Exception("Already an item/pupil here!")
    '    End If
    '    pPupil = pupil
    '    pSquare.BackgroundImage = pupil.Image
    '    pSquare.ShowPupil(pupil)
    'End Sub

    Public Function IsEmpty() As Boolean
        Return IsNothing(pItem)
    End Function

    Public Sub removeItem()
        Me.setItem(Nothing)
    End Sub

    Public ReadOnly Property Xpos
        Get
            Return pX
        End Get
    End Property

    Public ReadOnly Property Ypos
        Get
            Return pY
        End Get
    End Property

    Public ReadOnly Property Item As RoomItem
        Get
            Return pItem
        End Get
        'Set(value As RoomItem)
        'pItem = value
        'If pItem Is Nothing Then
        '    pSquare.Image = Nothing
        'Else
        '    pSquare.Image = value.Image
        'End If
        'End Set
    End Property

    Public Sub setItem(ByVal item As RoomItem)
        pItem = item
        If pItem Is Nothing Then
            pSquare.Image = Nothing
        Else
            pSquare.Image = item.Image
        End If
    End Sub

    Public Property Pupil As Pupil
        Get
            Return pPupil
        End Get
        Set(value As Pupil)
            pPupil = value
        End Set
    End Property

    Public Property Square As Square
        Get
            Return pSquare
        End Get
        Set(value As Square)
            pSquare = value
        End Set
    End Property

End Class
