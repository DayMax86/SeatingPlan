Public Class Room

    Private pPanel As Panel
    Private pWidth As Integer
    Private pHeight As Integer
    Private pPositions As Position(,)

    Public Function getPosition(ByVal x As Integer, ByVal y As Integer) As Position
        Return pPositions(x, y)
    End Function

    Public Sub New(ByVal width As Integer, ByVal height As Integer, ByRef panel As Panel)

        Dim square As Square
        Dim position As Position
        Dim x, y As Integer

        pPanel = panel
        pWidth = width
        pHeight = height

        ReDim pPositions(width, height)

        For x = 0 To width
            For y = 0 To height
                square = New Square
                square.Width = 50
                square.Height = 50
                square.Left = x * 50
                square.Top = y * 50
                panel.Controls.Add(square)
                position = New Position(x, y, square, Me)
                pPositions(x, y) = position
            Next
        Next

    End Sub

    Public Sub PlaceItem(ByVal item As RoomItem, ByVal x As Integer, ByVal y As Integer)
        Dim position As Position
        Try
            If TypeOf (item) Is TeacherDesk Then
                For x = 0 To Width
                    For y = 0 To Width
                        If TypeOf (pPositions(x, y).Item) Is TeacherDesk Then
                            Throw New Exception("Only one teacher desk is allowed in a room")
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        position = pPositions(x, y)
        position.setItem(item)
    End Sub

    'Public Sub PlacePupil(ByVal pupil As Pupil, ByVal x As Integer, ByVal y As Integer)
    '    Dim position As Position
    '    position = pPositions(x, y)
    '    Try
    '        REM check that it is a valid placement
    '        CheckPlacement(pupil, x, y)
    '        position.SetPupil(pupil)
    '    Catch ex As Exception
    '        MsgBox("Error : " & ex.Message)
    '    End Try
    'End Sub

    Public Sub OnClick(ByVal item As RoomItem, ByVal x As Integer, ByVal y As Integer)
        Dim position As Position
        position = pPositions(x, y)

        Try
            If TypeOf (item) Is TeacherDesk Then
                For x = 0 To Width
                    For y = 0 To Width
                        If TypeOf (pPositions(x, y).Item) Is TeacherDesk Then
                            Throw New Exception("Only one teacher desk is allowed in a room")
                        End If
                    Next
                Next
            End If

            If item Is Nothing Then
                position.removeItem()
            Else
                position.setItem(item)
            End If
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try
        Form1.SeatingPlan.importRoomLayout(pPositions)
    End Sub

    Private Sub CheckPlacement(ByVal pupil As Pupil, ByVal x As Integer, ByVal y As Integer)

        REM check that there is not already a pupil in the seat
        If Not pPositions(x, y).IsEmpty Then
            Throw New Exception("There is already a pupil in the seat " & x & " , " & y)
        End If

        REM check boy/girl
        Dim tempPupil As Pupil = Nothing
        REM is there anything to the left? (is it the end of the grid)
        If x <> 0 Then
            REM check to the left
            If Not pPositions(pupil.X - 1, y).IsEmpty() Then
                tempPupil = pPositions(pupil.X - 1, y).Pupil
                If tempPupil.Gender = pupil.Gender Then
                    Throw New Exception("Boy/Girl rule broken at " & tempPupil.X & "," & y)
                End If
            End If
        End If
        REM is there anything to the right? (is it the end of the grid)
        If x <> Form1.RoomSize Then
            REM check to the right
            If Not pPositions(pupil.X + 1, y).IsEmpty() Then
                tempPupil = pPositions(pupil.X + 1, y).Pupil
                If tempPupil.Gender = pupil.Gender Then
                    Throw New Exception("Boy/Girl rule broken at " & tempPupil.X & "," & y)
                End If
            End If
        End If
        REM is there anything underneath? (is it the end of the grid)
        If y <> Form1.RoomSize Then
            REM check downwards
            If Not pPositions(x, pupil.Y + 1).IsEmpty() Then
                tempPupil = pPositions(x, pupil.Y + 1).Pupil
                If tempPupil.Gender = pupil.Gender Then
                    Throw New Exception("Boy/Girl rule broken at " & x & "," & tempPupil.Y)
                End If
            End If
        End If
        REM is there anything above? (is it the end of the grid)
        If y <> 0 Then
            REM check upwards
            If Not pPositions(x, pupil.Y - 1).IsEmpty() Then
                tempPupil = pPositions(x, pupil.Y - 1).Pupil
                If tempPupil.Gender = pupil.Gender Then
                    Throw New Exception("Boy/Girl rule broken at " & x & "," & tempPupil.Y)
                End If
            End If
        End If
    End Sub

    Public Sub SaveToFile(ByVal filename As String)

        Dim x As Integer
        Dim y As Integer
        Dim objWriter As New System.IO.StreamWriter(filename)

        For x = 0 To Me.Width
            For y = 0 To Me.Height - 1
                If TypeOf (pPositions(x, y).Item) Is Desk Then
                    objWriter.WriteLine("1")
                ElseIf TypeOf (pPositions(x, y).Item) Is PCDesk Then
                    objWriter.WriteLine("2")
                ElseIf TypeOf (pPositions(x, y).Item) Is TeacherDesk Then
                    objWriter.WriteLine("3")
                Else
                    objWriter.WriteLine("0")
                End If
            Next
        Next
        objWriter.Close()

    End Sub

    Public Sub openFile(ByVal filename As String)

        Dim objReader As New System.IO.StreamReader(filename)
        Dim tempInput As String
        clear()
        For x = 0 To Me.Width
            For y = 0 To Me.Height - 1
                tempInput = objReader.ReadLine()
                If tempInput = "1" Then
                    OnClick(New Desk(), x, y)
                ElseIf tempInput = "2" Then
                    OnClick(New PCDesk(), x, y)
                ElseIf tempInput = "3" Then
                    OnClick(New TeacherDesk(), x, y)
                End If
            Next
        Next
        FileClose(1)
    End Sub

    Public Sub clear()
        For x = 0 To Me.Width
            For y = 0 To Me.Height
                If Not pPositions(x, y).IsEmpty Then
                    pPositions(x, y).removeItem()
                End If
            Next
        Next
        Form1.SeatingPlan.clear()
    End Sub

    Public Property Panel As Panel
        Get
            Return pPanel
        End Get
        Set(value As Panel)
            pPanel = value
        End Set
    End Property

    Public Property Width As Integer
        Get
            Return pWidth
        End Get
        Set(value As Integer)
            pWidth = value
        End Set
    End Property

    Public Property Height As Integer
        Get
            Return pHeight
        End Get
        Set(value As Integer)
            pHeight = value
        End Set
    End Property


End Class
