Public Class Form1
    Public Room As Room
    Public SeatingPlan As SeatingPlan
    Public Const RoomSize As Integer = 20

    Public TempItem As RoomItem
    Public TempPupil As Pupil
    Dim alPupilRoster As ArrayList

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        NameCaptureForm.Hide()

        Room = New Room(RoomSize, RoomSize, RoomPanel)
        SeatingPlan = New SeatingPlan(RoomSize, RoomSize, PlanPanel)

        pbxSampleDesk.Tag = New Desk()
        pbxSamplePCDesk.Tag = New PCDesk()
        pbxSampleTeacherDesk.Tag = New TeacherDesk()

        alPupilRoster = New ArrayList()

    End Sub

    Private Sub pbxSampleDesk_Click(sender As System.Object, e As System.EventArgs) Handles pbxSampleDesk.Click
        TempItem = pbxSampleDesk.Tag
        refreshLabels()
    End Sub

    Private Sub pbxSamplePCDesk_Click(sender As System.Object, e As System.EventArgs) Handles pbxSamplePCDesk.Click
        TempItem = pbxSamplePCDesk.Tag
        refreshLabels()
    End Sub

    Private Sub pbxSampleTeacherDesk_Click(sender As System.Object, e As System.EventArgs) Handles pbxSampleTeacherDesk.Click
        TempItem = pbxSampleTeacherDesk.Tag
        refreshLabels()
    End Sub

    Private Sub pbxRemoveDesk_Click(sender As System.Object, e As System.EventArgs) Handles pbxRemoveDesk.Click
        TempItem = Nothing
        lblCurrentlySelected.Text = "Currently selected : " & "Remove desk"
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveToFile.Click
        Dim form As New filenameInputForm()
        form.caller = "save"
        If TabControl1.SelectedIndex = 0 Then
            form.tab = "room"
        ElseIf TabControl1.SelectedIndex = 1 Then
            form.tab = "pupil"
        ElseIf TabControl1.SelectedIndex = 2 Then
            form.tab = "seatingPlan"
        End If
        form.Show()
        refreshLabels()
    End Sub

    Private Sub btnOpenFile_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenFile.Click
        Dim form As New filenameInputForm()
        form.caller = "open"
        If TabControl1.SelectedIndex = 0 Then
            form.tab = "room"
        ElseIf TabControl1.SelectedIndex = 1 Then
            form.tab = "pupil"
        ElseIf TabControl1.SelectedIndex = 2 Then
            form.tab = "seatingPlan"
        End If
        form.Show()
        refreshLabels()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        If TabControl1.SelectedIndex = 0 Then
            Room.clear()
        End If
        If TabControl1.SelectedIndex = 1 Then
            alPupilRoster.Clear()
            updatePupilRoster()
        End If
        If TabControl1.SelectedIndex = 2 Then
            SeatingPlan.clear()
        End If
        refreshLabels()
    End Sub


    Private Sub btnAddPupil_Click(sender As System.Object, e As System.EventArgs) Handles btnAddPupil.Click
        Dim tempGender As Pupil.GenderType
        If ddbGender.Text = "Boy" Then
            tempGender = Pupil.GenderType.Boy
        Else
            tempGender = Pupil.GenderType.Girl
        End If
        Dim tempPupil As New Pupil(tbxPupilForename.Text, tbxPupilSurname.Text, tempGender, tickSEN.Checked, tickAGAT.Checked, nudNILevel.Value)
        alPupilRoster.Add(tempPupil)
        updatePupilRoster()
        'SeatingPlan.importPupilRoster(alPupilRoster)
        refreshLabels()
    End Sub

    Public Sub updatePupilRoster()
        lbxPupilRoster.Items.Clear()
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
            lbxPupilRoster.Items.Add(Pupil.forename & " " & Pupil.surname & " - " & Pupil.Gender.ToString() & " - " & tempSEN & " - " & tempAGAT & " - " & Pupil.NILevel)
        Next
        refreshLabels()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

        Dim tempAl As ArrayList
        tempAl = New ArrayList()

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
            If (Pupil.forename & " " & Pupil.surname & " - " & Pupil.Gender.ToString() & " - " & tempSEN & " - " & tempAGAT & " - " & Pupil.NILevel) = lbxPupilRoster.SelectedItem Then
                tempAl.Add(Pupil)
            End If
        Next

        For Each Pupil As Pupil In tempAl
            alPupilRoster.Remove(Pupil)
        Next

        updatePupilRoster()
        refreshLabels()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click

        Dim tempAl As ArrayList
        tempAl = New ArrayList()

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
            If (Pupil.forename & " " & Pupil.surname & " - " & Pupil.Gender.ToString() & " - " & tempSEN & " - " & tempAGAT & " - " & Pupil.NILevel) = lbxPupilRoster.SelectedItem Then
                tbxPupilForename.Text = Pupil.forename
                tbxPupilSurname.Text = Pupil.surname
                ddbGender.Text = Pupil.Gender.ToString()
                If Pupil.SEN Then
                    tickSEN.Checked = True
                Else
                    tickSEN.Checked = False
                End If
                If Pupil.AGAT Then
                    tickAGAT.Checked = True
                Else
                    tickAGAT.Checked = False
                End If
                nudNILevel.Value = Pupil.NILevel
                tempAl.Add(Pupil)
            End If
        Next

        For Each Pupil As Pupil In tempAl
            alPupilRoster.Remove(Pupil)
        Next

        updatePupilRoster()
        refreshLabels()
    End Sub

    Public Sub refreshLabels()
        If Not TempItem Is Nothing Then
            lblCurrentlySelected.Text = "Currently selected : " & TempItem.name
        End If
        lblNumberOfPupils.Text = "Number of pupils : " & alPupilRoster.Count
    End Sub

    Public Sub savePupilRoster(ByVal filename As String)
        Dim objWriter As New System.IO.StreamWriter(filename)
        For Each pupil As Pupil In alPupilRoster
            objWriter.WriteLine(pupil.forename)
            objWriter.WriteLine(pupil.surname)
            objWriter.WriteLine(pupil.Gender.ToString())
            Dim tempAGAT As String
            If pupil.AGAT Then
                tempAGAT = "AGAT"
            Else
                tempAGAT = "X"
            End If
            Dim tempSEN As String
            If pupil.SEN Then
                tempSEN = "SEN"
            Else
                tempSEN = "X"
            End If
            objWriter.WriteLine(tempSEN)
            objWriter.WriteLine(tempAGAT)
            objWriter.WriteLine(pupil.NILevel)
        Next
        objWriter.Close()
    End Sub

    Public Sub openPupilRoster(filename As String)
        Dim counter As Integer = 0
        Dim x As Integer = 0
        FileOpen(1, filename, OpenMode.Input)
        Do While Not EOF(1)
            LineInput(1)
            counter += 1
        Loop
        FileClose(1)
        counter = (counter / 7)
        Dim objReader As New System.IO.StreamReader(filename)
        'counter = alPupilRoster.Count
        alPupilRoster.Clear()

        Do
            Dim forename As String
            Dim surname As String
            Dim gender As Pupil.GenderType
            Dim SEN As Boolean
            Dim AGAT As Boolean
            Dim NILevel As Integer

            forename = objReader.ReadLine()
            surname = objReader.ReadLine()
            Dim tempGender As String
            tempGender = objReader.ReadLine()
            If tempGender = "Boy" Then
                gender = Pupil.GenderType.Boy
            ElseIf tempGender = "Girl" Then
                gender = Pupil.GenderType.Girl
            End If
            Dim tempSEN As String
            tempSEN = objReader.ReadLine()
            If tempSEN = "SEN" Then
                SEN = True
            ElseIf tempSEN = "X" Then
                SEN = False
            End If
            Dim tempAGAT As String
            tempAGAT = objReader.ReadLine()
            If tempAGAT = "AGAT" Then
                AGAT = True
            ElseIf tempAGAT = "X" Then
                AGAT = False
            End If
            NILevel = objReader.ReadLine()

            Dim tempPupil As New Pupil(forename, surname, gender, SEN, AGAT, NILevel)
            alPupilRoster.Add(tempPupil)

            forename = Nothing
            surname = Nothing
            gender = Nothing
            SEN = Nothing
            AGAT = Nothing
            NILevel = Nothing

            x += 1

        Loop While Not x > counter
        objReader.Close()

        'SeatingPlan.importPupilRoster(alPupilRoster)
    End Sub

    Private Sub btnCreateSeatingPlan_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateSeatingPlan.Click
        SeatingPlan.importPupilRoster(alPupilRoster)
        SeatingPlan.createSeatingPlan()
    End Sub
End Class
