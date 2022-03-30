Public Class SeatingPlan
    'Implements IComparer

    'Inherits Room

    Private pPanel As Panel
    Private pWidth As Integer
    Private pHeight As Integer
    Private pPositions As Position(,)
    Private pPupilRoster As ArrayList
    Dim alAllPupils As ArrayList

    Public Sub New(ByVal width As Integer, ByVal height As Integer, ByRef panel As Panel)
        'MyBase.New(Form1.RoomSize, Form1.RoomSize, Form1.PlanPanel, Type.PLAN)

        pPupilRoster = New ArrayList
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


        alAllPupils = New ArrayList

    End Sub

    Public Sub importRoomLayout(ByVal positions(,) As Position)
        For i As Integer = 0 To pWidth
            For j As Integer = 0 To pHeight
                pPositions(i, j).removeItem()
            Next
        Next
        Dim item As RoomItem
        For x = 0 To pWidth
            For y = 0 To pHeight
                item = positions(x, y).Item
                pPositions(x, y).setItem(item)
            Next
        Next
    End Sub

    Public Sub clear()
        For x = 0 To pWidth
            For y = 0 To pHeight
                If Not pPositions(x, y).IsEmpty Then
                    pPositions(x, y).removeItem()
                End If
            Next
        Next
        REM needs to clear the pupil list as well as the room layout
    End Sub

    Public Sub importPupilRoster(ByVal alPupilRoster As ArrayList)

        Form1.lbxPupils.Items.Clear()

        For Each Pupil As Pupil In alPupilRoster
            Dim tempAGAT As String
            If Pupil.AGAT Then
                tempAGAT = "AGAT"
            Else
                tempAGAT = "X"
            End If
            Dim tempSEN As String
            If Pupil.SEN Then
                tempSEN = "SEN"
            Else
                tempSEN = "X"
            End If
            Form1.lbxPupils.Items.Add(Pupil.forename & " " & Pupil.surname & " - " & Pupil.Gender.ToString() & " - " & tempSEN & " - " & tempAGAT & " - " & Pupil.NILevel)
        Next
        For Each pupil As Pupil In alPupilRoster
            pPupilRoster.Add(pupil)
        Next
    End Sub



    Public Sub createSeatingPlan()

        Try

            'STEP 1 - locate the teacher's desk

            Dim teacherDeskX As Integer
            Dim teacherDeskY As Integer

            For x = 0 To pWidth
                For y = 0 To pHeight
                    ' pPositions(x, y) = Form1.Room.getPosition(x, y)
                    If TypeOf (pPositions(x, y).Item) Is TeacherDesk Then
                        teacherDeskX = x
                        teacherDeskY = y
                    End If
                Next
            Next

            'STEP 2 - create separate arraylists for both the AGAT and SEN pupils

            Dim alSEN As ArrayList
            alSEN = New ArrayList
            Dim alAGAT As ArrayList
            alAGAT = New ArrayList
            Dim alRest As ArrayList
            alRest = New ArrayList


            For Each Pupil As Pupil In pPupilRoster
                REM there will be an error if a pupil is both SEN and AGAT.
                If Pupil.SEN Then
                    alSEN.Add(Pupil)
                    'If Pupil.Gender = SeatingPlanV1.Pupil.GenderType.Boy Then
                    '    alSENboy.Add(Pupil)
                    'ElseIf Pupil.Gender = SeatingPlanV1.Pupil.GenderType.Girl Then
                    '    alSENgirl.Add(Pupil)
                    'End If
                ElseIf Pupil.AGAT Then
                    alAGAT.Add(Pupil)
                Else
                    alRest.Add(Pupil)
                End If
            Next

            Dim count As Integer = 0
            Dim currentGender As Pupil.GenderType = Pupil.GenderType.Boy

            Dim alDistances As ArrayList
            alDistances = New ArrayList()
            Dim dist As Double

            For x = 0 To Me.pWidth
                For y = 0 To Me.pHeight
                    If Not pPositions(x, y).IsEmpty And TypeOf (pPositions(x, y).Item) Is Desk Or TypeOf (pPositions(x, y).Item) Is PCDesk Then
                        REM use pythagoras to work out the distances between the individual desks and the teacher's desk.
                        dist = Math.Sqrt((Math.Pow((teacherDeskX - x), 2)) + (Math.Pow((teacherDeskY - y), 2)))
                        alDistances.Add(New Distance(dist, x, y))
                    End If
                Next
            Next

            REM before anything else we need to know the amount of girls and boys in each category- SEN, regular and AGAT.
            Dim boyCountSEN, girlCountSEN, boyCountNormal, girlCountNormal, boyCountAGAT, girlCountAGAT As Integer
            For Each Pupil As Pupil In alSEN
                If Pupil.Gender = SeatingPlanV1.Pupil.GenderType.Boy Then
                    boyCountSEN += 1
                Else
                    girlCountSEN += 1
                End If
            Next
            For Each Pupil As Pupil In alRest
                If Pupil.Gender = SeatingPlanV1.Pupil.GenderType.Boy Then
                    boyCountNormal += 1
                Else
                    girlCountNormal += 1
                End If
            Next
            For Each Pupil As Pupil In alAGAT
                If Pupil.Gender = SeatingPlanV1.Pupil.GenderType.Boy Then
                    boyCountAGAT += 1
                Else
                    girlCountAGAT += 1
                End If
            Next

            REM create one arraylist with all the pupils in, all in boy/girl order.
            REM add the SEN pupils to it first in boy/girl order
            REM there may be an uneven distribution of boys and girls in a class which must be accounted for using the totals calculated above
            Dim tempAlSEN As ArrayList = New ArrayList
            Do While alSEN.Count <> 0
                For Each Pupil As Pupil In alSEN
                    If Pupil.Gender = currentGender Or (boyCountSEN = 0 Or girlCountSEN = 0) Then
                        If currentGender = SeatingPlanV1.Pupil.GenderType.Boy And boyCountSEN = 0 Then
                            currentGender = SeatingPlanV1.Pupil.GenderType.Girl
                            'Continue For
                        ElseIf currentGender = SeatingPlanV1.Pupil.GenderType.Girl And girlCountSEN = 0 Then
                            currentGender = SeatingPlanV1.Pupil.GenderType.Boy
                            'Continue For
                        End If
                        tempAlSEN.Add(Pupil)
                        alAllPupils.Add(Pupil)
                        'switch gender
                        If currentGender = SeatingPlanV1.Pupil.GenderType.Boy Then
                            boyCountSEN -= 1
                            currentGender = SeatingPlanV1.Pupil.GenderType.Girl
                        ElseIf currentGender = SeatingPlanV1.Pupil.GenderType.Girl Then
                            girlCountSEN -= 1
                            currentGender = SeatingPlanV1.Pupil.GenderType.Boy
                        End If

                    End If
                Next
                'add the pupils in the correct boy/girl order and then remove them from the list.
                For Each Pupil As Pupil In tempAlSEN
                    If alSEN.Contains(Pupil) Then
                        alSEN.Remove(Pupil)
                    End If
                Next
            Loop
            REM add the pupils who aren't AGAT or SEN based on their NI level and their gender.
            alRest.Sort()
            Dim tempAlRest As ArrayList = New ArrayList
            Do While alRest.Count <> 0
                For Each Pupil As Pupil In alRest
                    If Pupil.Gender = currentGender Or (boyCountNormal = 0 Or girlCountNormal = 0) Then
                        If currentGender = SeatingPlanV1.Pupil.GenderType.Boy And boyCountNormal = 0 Then
                            currentGender = SeatingPlanV1.Pupil.GenderType.Girl
                            'Continue For
                        ElseIf currentGender = SeatingPlanV1.Pupil.GenderType.Girl And girlCountNormal = 0 Then
                            currentGender = SeatingPlanV1.Pupil.GenderType.Boy
                            'Continue For
                        End If
                        tempAlRest.Add(Pupil)
                        alAllPupils.Add(Pupil)
                        'switch gender
                        If currentGender = SeatingPlanV1.Pupil.GenderType.Boy Then
                            boyCountNormal -= 1
                            currentGender = SeatingPlanV1.Pupil.GenderType.Girl
                        ElseIf currentGender = SeatingPlanV1.Pupil.GenderType.Girl Then
                            girlCountNormal -= 1
                            currentGender = SeatingPlanV1.Pupil.GenderType.Boy
                        End If
                    End If
                Next
                For Each Pupil As Pupil In tempAlRest
                    If alRest.Contains(Pupil) Then
                        alRest.Remove(Pupil)
                    End If
                Next
            Loop

            REM add the remaining AGAT pupils to the end of the list
            For Each Pupil As Pupil In alAGAT
                If Pupil.Gender = currentGender Or boyCountAGAT = 0 Or girlCountAGAT = 0 Then
                    If currentGender = SeatingPlanV1.Pupil.GenderType.Boy And boyCountAGAT = 0 Then
                        currentGender = SeatingPlanV1.Pupil.GenderType.Girl
                        'Continue For
                    ElseIf currentGender = SeatingPlanV1.Pupil.GenderType.Girl And girlCountAGAT = 0 Then
                        currentGender = SeatingPlanV1.Pupil.GenderType.Boy
                        'Continue For
                    End If
                    alAllPupils.Add(Pupil)
                    If currentGender = SeatingPlanV1.Pupil.GenderType.Boy Then
                        boyCountAGAT -= 1
                        currentGender = SeatingPlanV1.Pupil.GenderType.Girl
                    ElseIf currentGender = SeatingPlanV1.Pupil.GenderType.Girl Then
                        girlCountAGAT -= 1
                        currentGender = SeatingPlanV1.Pupil.GenderType.Boy
                    End If
                End If
            Next


            Dim stepper As Integer = 0
            Dim refreshedStepper As Integer = 0
            Dim alternative As Boolean = False
            alDistances.Sort()
            If alDistances.Count < alAllPupils.Count Then
                Throw New Exception("there isn't enough desks for that many pupils!")
            Else
                For Each Distance As Distance In alDistances
                    alternative = False
                    If Not stepper >= alAllPupils.Count Then
                        refreshedStepper = 0
                        Do While Not pPositions(alDistances(refreshedStepper).x, alDistances(refreshedStepper).y).Pupil Is Nothing
                            refreshedStepper += 1
                        Loop
                        Distance = alDistances(refreshedStepper)
                        REM need to add some validation for the boy/girl arrangement as they don't end up in order after having been placed within the room.
                        REM check upwards
                        If Not pPositions(Distance.x, Distance.y + 1).Pupil Is Nothing Then
                            If pPositions(Distance.x, Distance.y + 1).Pupil.Gender = alAllPupils(stepper).gender Then
                                REM place in the next distance.
                                pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil = alAllPupils(stepper)
                                REM must also set the x and y values for the pupils since they are used when saving and opening the seating plan files.
                                'pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil.X = alDistances(stepper + 1).x
                                'pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil.Y = alDistances(stepper + 1).y
                                alternative = True
                            End If
                        End If
                        REM check downwards
                        If Not pPositions(Distance.x, Distance.y - 1).Pupil Is Nothing Then
                            If pPositions(Distance.x, Distance.y - 1).Pupil.Gender = alAllPupils(stepper).gender Then
                                REM place in the next distance.
                                pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil = alAllPupils(stepper)
                                REM must also set the x and y values for the pupils since they are used when saving and opening the seating plan files.
                                'pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil.X = alDistances(stepper + 1).x
                                'pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil.Y = alDistances(stepper + 1).y
                                alternative = True
                            End If
                        End If
                        REM check left
                        If Not pPositions(Distance.x - 1, Distance.y).Pupil Is Nothing Then
                            If pPositions(Distance.x - 1, Distance.y).Pupil.Gender = alAllPupils(stepper).gender Then
                                REM place in the next distance.
                                pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil = alAllPupils(stepper)
                                REM must also set the x and y values for the pupils since they are used when saving and opening the seating plan files.
                                'pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil.X = alDistances(stepper + 1).x
                                'pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil.Y = alDistances(stepper + 1).y
                                alternative = True
                            End If
                        End If
                        REM check right
                        If Not pPositions(Distance.x + 1, Distance.y).Pupil Is Nothing Then
                            If pPositions(Distance.x + 1, Distance.y).Pupil.Gender = alAllPupils(stepper).gender Then
                                REM place in the next distance.
                                pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil = alAllPupils(stepper)
                                REM must also set the x and y values for the pupils since they are used when saving and opening the seating plan files.
                                'pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil.X = alDistances(stepper + 1).x
                                'pPositions(alDistances(stepper + 1).x, alDistances(stepper + 1).y).Pupil.Y = alDistances(stepper + 1).y
                                alternative = True
                            End If
                        End If
                        If Not alternative Then
                            pPositions(Distance.x, Distance.y).Pupil = alAllPupils(stepper)
                            'pPositions(Distance.x, Distance.y).Pupil.X = alDistances(stepper).x
                            'pPositions(Distance.x, Distance.y).Pupil.Y = alDistances(stepper).y
                        End If
                        stepper += 1
                        Distance.used = True
                    Else
                        Exit For
                    End If
                Next
            End If

            'REM must also set the x and y values for the pupils since they are used when saving and loading seating plan files.
            'For Each Distance As Distance In alDistances
            '    If Distance.used = True Then
            '        pPositions(Distance.x, Distance.y).Pupil.X = Distance.x
            '        pPositions(Distance.x, Distance.y).Pupil.Y = Distance.y
            '    End If
            'Next

            For x = 0 To pWidth
                For y = 0 To pHeight
                    Dim tempPupil As Pupil
                    tempPupil = pPositions(x, y).Pupil
                    If alAllPupils.Contains(tempPupil) Then

                    End If
                Next
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub saveToFile(ByVal filename As String)
        Dim objWriter As New System.IO.StreamWriter(filename)
        'For Each Pupil As Pupil In alAllPupils
        '    objWriter.WriteLine(Pupil.forename)
        '    objWriter.WriteLine(Pupil.surname)
        '    objWriter.WriteLine(Pupil.Gender.ToString())
        '    Dim tempAGAT As String
        '    If Pupil.AGAT Then
        '        tempAGAT = "AGAT"
        '    Else
        '        tempAGAT = "X"
        '    End If
        '    Dim tempSEN As String
        '    If Pupil.SEN Then
        '        tempSEN = "SEN"
        '    Else
        '        tempSEN = "X"
        '    End If
        '    objWriter.WriteLine(tempSEN)
        '    objWriter.WriteLine(tempAGAT)
        '    objWriter.WriteLine(Pupil.NILevel)
        '    objWriter.WriteLine(Pupil.X)
        '    objWriter.WriteLine(Pupil.Y)
        'Next

        'Dim tempDeskType As String
        For x = 0 To pWidth
            For y = 0 To pHeight
                REM the information about the desk to be saved
                If Not pPositions(x, y).Item Is Nothing Then
                    If TypeOf (pPositions(x, y).Item) Is Desk Then
                        objWriter.WriteLine("1")
                    ElseIf TypeOf (pPositions(x, y).Item) Is PCDesk Then
                        objWriter.WriteLine("2")
                    ElseIf TypeOf (pPositions(x, y).Item) Is TeacherDesk Then
                        objWriter.WriteLine("3")
                    End If
                Else
                    objWriter.WriteLine("null")
                End If
                REM the information about the pupil
                If pPositions(x, y).Pupil Is Nothing Then
                    objWriter.WriteLine("null")
                Else
                    Dim tempPupil As Pupil
                    tempPupil = pPositions(x, y).Pupil
                    objWriter.WriteLine(tempPupil.forename)
                    objWriter.WriteLine(tempPupil.surname)
                    objWriter.WriteLine(tempPupil.Gender.ToString())
                    Dim tempAGAT As String
                    If tempPupil.AGAT Then
                        tempAGAT = "AGAT"
                    Else
                        tempAGAT = "X"
                    End If
                    Dim tempSEN As String
                    If tempPupil.SEN Then
                        tempSEN = "SEN"
                    Else
                        tempSEN = "X"
                    End If
                    objWriter.WriteLine(tempSEN)
                    objWriter.WriteLine(tempAGAT)
                    objWriter.WriteLine(tempPupil.NILevel)
                End If
            Next
        Next
        objWriter.Close()
    End Sub

    Public Sub openFile(ByVal filename As String)
        'Dim counter As Integer = 0
        'Dim x As Integer = 0
        'FileOpen(1, filename, OpenMode.Input)
        'Do While Not EOF(1)
        '    LineInput(1)
        '    counter += 1
        'Loop
        'FileClose(1)
        'counter = (counter / 9)
        'Dim objReader As New System.IO.StreamReader(filename)
        'alAllPupils.Clear()

        'Do
        '    Dim forename As String
        '    Dim surname As String
        '    Dim gender As Pupil.GenderType
        '    Dim SEN As Boolean
        '    Dim AGAT As Boolean
        '    Dim NILevel As Integer

        '    forename = objReader.ReadLine()
        '    surname = objReader.ReadLine()
        '    Dim tempGender As String
        '    tempGender = objReader.ReadLine()
        '    If tempGender = "Boy" Then
        '        gender = Pupil.GenderType.Boy
        '    ElseIf tempGender = "Girl" Then
        '        gender = Pupil.GenderType.Girl
        '    End If
        '    Dim tempSEN As String
        '    tempSEN = objReader.ReadLine()
        '    If tempSEN = "SEN" Then
        '        SEN = True
        '    ElseIf tempSEN = "X" Then
        '        SEN = False
        '    End If
        '    Dim tempAGAT As String
        '    tempAGAT = objReader.ReadLine()
        '    If tempAGAT = "AGAT" Then
        '        AGAT = True
        '    ElseIf tempAGAT = "X" Then
        '        AGAT = False
        '    End If
        '    NILevel = objReader.ReadLine()

        '    Dim tempPupil As New Pupil(forename, surname, gender, SEN, AGAT, NILevel)
        '    tempPupil.X = objReader.ReadLine()
        '    tempPupil.Y = objReader.ReadLine()
        '    alAllPupils.Add(tempPupil)

        '    forename = Nothing
        '    surname = Nothing
        '    gender = Nothing
        '    SEN = Nothing
        '    AGAT = Nothing
        '    NILevel = Nothing

        '    x += 1

        'Loop While Not x > counter


        Dim objReader As New System.IO.StreamReader(filename)
        For x = 0 To pWidth
            For y = 0 To pHeight
                Dim tempInput As String
                tempInput = objReader.ReadLine()
                REM what kind of desk was there?
                Select Case tempInput
                    Case "null"
                        pPositions(x, y).setItem(Nothing)
                    Case "1"
                        pPositions(x, y).setItem(New Desk())
                    Case "2"
                        pPositions(x, y).setItem(New PCDesk())
                    Case "3"
                        pPositions(x, y).setItem(New TeacherDesk())
                End Select
                REM pupil information
                tempInput = objReader.ReadLine()
                If tempInput = "null" Then
                    pPositions(x, y).Pupil = Nothing
                Else
                    pPositions(x, y).Pupil = New Pupil()
                    pPositions(x, y).Pupil.forename = tempInput
                    pPositions(x, y).Pupil.surname = objReader.ReadLine()
                    Dim tempGender As String = objReader.ReadLine()
                    If tempGender = "boy" Then
                        pPositions(x, y).Pupil.Gender = Pupil.GenderType.Boy
                    Else
                        pPositions(x, y).Pupil.Gender = Pupil.GenderType.Girl
                    End If
                    Dim tempSEN As String = objReader.ReadLine()
                    If tempSEN = "X" Then
                        pPositions(x, y).Pupil.SEN = False
                    Else
                        pPositions(x, y).Pupil.SEN = True
                    End If
                    Dim tempAGAT As String = objReader.ReadLine()
                    If tempAGAT = "X" Then
                        pPositions(x, y).Pupil.AGAT = False
                    Else
                        pPositions(x, y).Pupil.AGAT = True
                    End If
                    pPositions(x, y).Pupil.NILevel = objReader.ReadLine()
                End If
            Next
        Next

        objReader.Close()
        importSeatingPlan(alAllPupils)
    End Sub

    Public Sub importSeatingPlan(ByVal alPupils As ArrayList)
        For Each Pupil As Pupil In alPupils
            pPositions(Pupil.X, Pupil.Y).Pupil = Pupil
            pPositions(Pupil.X, Pupil.Y).setItem(New Desk)
        Next
    End Sub


    Public Class Distance
        Implements IComparable

        Private pDistance As Double
        Private pX As Integer
        Private pY As Integer
        Public used As Boolean
        'Private pPupil As Pupil

        Public Sub New(ByVal Distance As Double, ByVal X As Integer, ByVal Y As Integer)
            pDistance = Distance
            pX = X
            pY = Y
        End Sub

        Public Property distance As Double
            Get
                Return pDistance
            End Get
            Set(value As Double)
                pDistance = value
            End Set
        End Property

        Public Property x As Integer
            Get
                Return pX
            End Get
            Set(value As Integer)
                pX = value
            End Set
        End Property

        Public Property y As Integer
            Get
                Return pY
            End Get
            Set(value As Integer)
                pY = value
            End Set
        End Property

        Public Function CompareTo(x As Object) As Integer Implements IComparable.CompareTo
            Dim d1 As Distance = CType(x, Distance)

            If (Me.distance > d1.distance) Then
                Return 1
            ElseIf (Me.distance < d1.distance) Then
                Return -1
            Else
                Return 0
            End If

        End Function
    End Class
End Class
