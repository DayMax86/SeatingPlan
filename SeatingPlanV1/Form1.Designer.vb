<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.RoomPanel = New System.Windows.Forms.Panel()
        Me.btnSaveToFile = New System.Windows.Forms.Button()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblCurrentlySelected = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbxRemoveDesk = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbxSampleTeacherDesk = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbxSamplePCDesk = New System.Windows.Forms.PictureBox()
        Me.pbxSampleDesk = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.nudNILevel = New System.Windows.Forms.NumericUpDown()
        Me.lblNI = New System.Windows.Forms.Label()
        Me.lblAGAT = New System.Windows.Forms.Label()
        Me.tickAGAT = New System.Windows.Forms.CheckBox()
        Me.lblSEN = New System.Windows.Forms.Label()
        Me.tickSEN = New System.Windows.Forms.CheckBox()
        Me.ddbGender = New System.Windows.Forms.ComboBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.tbxPupilSurname = New System.Windows.Forms.TextBox()
        Me.lblEnterSurname = New System.Windows.Forms.Label()
        Me.tbxPupilForename = New System.Windows.Forms.TextBox()
        Me.lblEnterForename = New System.Windows.Forms.Label()
        Me.lbxPupilRoster = New System.Windows.Forms.ListBox()
        Me.btnAddPupil = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lbxPupils = New System.Windows.Forms.ListBox()
        Me.btnCreateSeatingPlan = New System.Windows.Forms.Button()
        Me.PlanPanel = New System.Windows.Forms.Panel()
        Me.lblNumberOfPupils = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.pbxRemoveDesk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSampleTeacherDesk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSamplePCDesk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSampleDesk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.nudNILevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'RoomPanel
        '
        Me.RoomPanel.Location = New System.Drawing.Point(3, 3)
        Me.RoomPanel.Name = "RoomPanel"
        Me.RoomPanel.Size = New System.Drawing.Size(934, 703)
        Me.RoomPanel.TabIndex = 0
        '
        'btnSaveToFile
        '
        Me.btnSaveToFile.Location = New System.Drawing.Point(1228, 606)
        Me.btnSaveToFile.Name = "btnSaveToFile"
        Me.btnSaveToFile.Size = New System.Drawing.Size(77, 36)
        Me.btnSaveToFile.TabIndex = 14
        Me.btnSaveToFile.Text = "Save to file"
        Me.btnSaveToFile.UseVisualStyleBackColor = True
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(1228, 648)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(77, 36)
        Me.btnOpenFile.TabIndex = 15
        Me.btnOpenFile.Text = "Open file"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(1228, 690)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(77, 36)
        Me.btnClear.TabIndex = 16
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1200, 738)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblCurrentlySelected)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.pbxRemoveDesk)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.pbxSampleTeacherDesk)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.pbxSamplePCDesk)
        Me.TabPage1.Controls.Add(Me.RoomPanel)
        Me.TabPage1.Controls.Add(Me.pbxSampleDesk)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1192, 712)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Room layout"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblCurrentlySelected
        '
        Me.lblCurrentlySelected.AutoSize = True
        Me.lblCurrentlySelected.Location = New System.Drawing.Point(1001, 227)
        Me.lblCurrentlySelected.Name = "lblCurrentlySelected"
        Me.lblCurrentlySelected.Size = New System.Drawing.Size(139, 13)
        Me.lblCurrentlySelected.TabIndex = 18
        Me.lblCurrentlySelected.Text = "Currently Selected : Nothing"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1058, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Remove Desk"
        '
        'pbxRemoveDesk
        '
        Me.pbxRemoveDesk.Image = CType(resources.GetObject("pbxRemoveDesk.Image"), System.Drawing.Image)
        Me.pbxRemoveDesk.Location = New System.Drawing.Point(1002, 174)
        Me.pbxRemoveDesk.Name = "pbxRemoveDesk"
        Me.pbxRemoveDesk.Size = New System.Drawing.Size(50, 50)
        Me.pbxRemoveDesk.TabIndex = 16
        Me.pbxRemoveDesk.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1058, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Teacher's Desk"
        '
        'pbxSampleTeacherDesk
        '
        Me.pbxSampleTeacherDesk.Image = Global.SeatingPlanV1.My.Resources.Resources.TeacherDesk
        Me.pbxSampleTeacherDesk.Location = New System.Drawing.Point(1002, 118)
        Me.pbxSampleTeacherDesk.Name = "pbxSampleTeacherDesk"
        Me.pbxSampleTeacherDesk.Size = New System.Drawing.Size(50, 50)
        Me.pbxSampleTeacherDesk.TabIndex = 14
        Me.pbxSampleTeacherDesk.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1058, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "PC Desk"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1058, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Desk"
        '
        'pbxSamplePCDesk
        '
        Me.pbxSamplePCDesk.Image = Global.SeatingPlanV1.My.Resources.Resources.PCDesk
        Me.pbxSamplePCDesk.Location = New System.Drawing.Point(1002, 62)
        Me.pbxSamplePCDesk.Name = "pbxSamplePCDesk"
        Me.pbxSamplePCDesk.Size = New System.Drawing.Size(50, 50)
        Me.pbxSamplePCDesk.TabIndex = 11
        Me.pbxSamplePCDesk.TabStop = False
        '
        'pbxSampleDesk
        '
        Me.pbxSampleDesk.Image = Global.SeatingPlanV1.My.Resources.Resources.Desk
        Me.pbxSampleDesk.Location = New System.Drawing.Point(1002, 6)
        Me.pbxSampleDesk.Name = "pbxSampleDesk"
        Me.pbxSampleDesk.Size = New System.Drawing.Size(50, 50)
        Me.pbxSampleDesk.TabIndex = 10
        Me.pbxSampleDesk.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblNumberOfPupils)
        Me.TabPage2.Controls.Add(Me.btnEdit)
        Me.TabPage2.Controls.Add(Me.btnDelete)
        Me.TabPage2.Controls.Add(Me.nudNILevel)
        Me.TabPage2.Controls.Add(Me.lblNI)
        Me.TabPage2.Controls.Add(Me.lblAGAT)
        Me.TabPage2.Controls.Add(Me.tickAGAT)
        Me.TabPage2.Controls.Add(Me.lblSEN)
        Me.TabPage2.Controls.Add(Me.tickSEN)
        Me.TabPage2.Controls.Add(Me.ddbGender)
        Me.TabPage2.Controls.Add(Me.lblGender)
        Me.TabPage2.Controls.Add(Me.tbxPupilSurname)
        Me.TabPage2.Controls.Add(Me.lblEnterSurname)
        Me.TabPage2.Controls.Add(Me.tbxPupilForename)
        Me.TabPage2.Controls.Add(Me.lblEnterForename)
        Me.TabPage2.Controls.Add(Me.lbxPupilRoster)
        Me.TabPage2.Controls.Add(Me.btnAddPupil)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1192, 712)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pupil roster"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(643, 231)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(146, 36)
        Me.btnEdit.TabIndex = 15
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(643, 186)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(146, 36)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'nudNILevel
        '
        Me.nudNILevel.Location = New System.Drawing.Point(935, 251)
        Me.nudNILevel.Name = "nudNILevel"
        Me.nudNILevel.Size = New System.Drawing.Size(158, 20)
        Me.nudNILevel.TabIndex = 13
        '
        'lblNI
        '
        Me.lblNI.AutoSize = True
        Me.lblNI.Location = New System.Drawing.Point(879, 251)
        Me.lblNI.Name = "lblNI"
        Me.lblNI.Size = New System.Drawing.Size(49, 13)
        Me.lblNI.TabIndex = 120
        Me.lblNI.Text = "NI level :"
        '
        'lblAGAT
        '
        Me.lblAGAT.AutoSize = True
        Me.lblAGAT.Location = New System.Drawing.Point(886, 200)
        Me.lblAGAT.Name = "lblAGAT"
        Me.lblAGAT.Size = New System.Drawing.Size(42, 13)
        Me.lblAGAT.TabIndex = 110
        Me.lblAGAT.Text = "AGAT :"
        '
        'tickAGAT
        '
        Me.tickAGAT.AutoSize = True
        Me.tickAGAT.Location = New System.Drawing.Point(934, 200)
        Me.tickAGAT.Name = "tickAGAT"
        Me.tickAGAT.Size = New System.Drawing.Size(15, 14)
        Me.tickAGAT.TabIndex = 10
        Me.tickAGAT.UseVisualStyleBackColor = True
        '
        'lblSEN
        '
        Me.lblSEN.AutoSize = True
        Me.lblSEN.Location = New System.Drawing.Point(893, 167)
        Me.lblSEN.Name = "lblSEN"
        Me.lblSEN.Size = New System.Drawing.Size(35, 13)
        Me.lblSEN.TabIndex = 104
        Me.lblSEN.Text = "SEN :"
        '
        'tickSEN
        '
        Me.tickSEN.AutoSize = True
        Me.tickSEN.Location = New System.Drawing.Point(934, 166)
        Me.tickSEN.Name = "tickSEN"
        Me.tickSEN.Size = New System.Drawing.Size(15, 14)
        Me.tickSEN.TabIndex = 8
        Me.tickSEN.UseVisualStyleBackColor = True
        '
        'ddbGender
        '
        Me.ddbGender.FormattingEnabled = True
        Me.ddbGender.Items.AddRange(New Object() {"Boy", "Girl"})
        Me.ddbGender.Location = New System.Drawing.Point(934, 112)
        Me.ddbGender.Name = "ddbGender"
        Me.ddbGender.Size = New System.Drawing.Size(159, 21)
        Me.ddbGender.TabIndex = 7
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(856, 112)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(72, 13)
        Me.lblGender.TabIndex = 102
        Me.lblGender.Text = "Pupil gender :"
        '
        'tbxPupilSurname
        '
        Me.tbxPupilSurname.Location = New System.Drawing.Point(934, 69)
        Me.tbxPupilSurname.Name = "tbxPupilSurname"
        Me.tbxPupilSurname.Size = New System.Drawing.Size(159, 20)
        Me.tbxPupilSurname.TabIndex = 5
        '
        'lblEnterSurname
        '
        Me.lblEnterSurname.AutoSize = True
        Me.lblEnterSurname.Location = New System.Drawing.Point(849, 72)
        Me.lblEnterSurname.Name = "lblEnterSurname"
        Me.lblEnterSurname.Size = New System.Drawing.Size(79, 13)
        Me.lblEnterSurname.TabIndex = 101
        Me.lblEnterSurname.Text = "Pupil surname :"
        '
        'tbxPupilForename
        '
        Me.tbxPupilForename.Location = New System.Drawing.Point(934, 28)
        Me.tbxPupilForename.Name = "tbxPupilForename"
        Me.tbxPupilForename.Size = New System.Drawing.Size(159, 20)
        Me.tbxPupilForename.TabIndex = 3
        '
        'lblEnterForename
        '
        Me.lblEnterForename.AutoSize = True
        Me.lblEnterForename.Location = New System.Drawing.Point(845, 31)
        Me.lblEnterForename.Name = "lblEnterForename"
        Me.lblEnterForename.Size = New System.Drawing.Size(83, 13)
        Me.lblEnterForename.TabIndex = 100
        Me.lblEnterForename.Text = "Pupil forename :"
        '
        'lbxPupilRoster
        '
        Me.lbxPupilRoster.FormattingEnabled = True
        Me.lbxPupilRoster.Location = New System.Drawing.Point(6, 6)
        Me.lbxPupilRoster.Name = "lbxPupilRoster"
        Me.lbxPupilRoster.Size = New System.Drawing.Size(600, 693)
        Me.lbxPupilRoster.TabIndex = 1
        '
        'btnAddPupil
        '
        Me.btnAddPupil.Location = New System.Drawing.Point(643, 125)
        Me.btnAddPupil.Name = "btnAddPupil"
        Me.btnAddPupil.Size = New System.Drawing.Size(146, 55)
        Me.btnAddPupil.TabIndex = 0
        Me.btnAddPupil.Text = "Add"
        Me.btnAddPupil.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lbxPupils)
        Me.TabPage3.Controls.Add(Me.btnCreateSeatingPlan)
        Me.TabPage3.Controls.Add(Me.PlanPanel)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1192, 712)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Create seating plan"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lbxPupils
        '
        Me.lbxPupils.FormattingEnabled = True
        Me.lbxPupils.Location = New System.Drawing.Point(943, 71)
        Me.lbxPupils.Name = "lbxPupils"
        Me.lbxPupils.Size = New System.Drawing.Size(232, 628)
        Me.lbxPupils.TabIndex = 3
        '
        'btnCreateSeatingPlan
        '
        Me.btnCreateSeatingPlan.Location = New System.Drawing.Point(943, 5)
        Me.btnCreateSeatingPlan.Name = "btnCreateSeatingPlan"
        Me.btnCreateSeatingPlan.Size = New System.Drawing.Size(232, 60)
        Me.btnCreateSeatingPlan.TabIndex = 2
        Me.btnCreateSeatingPlan.Text = "Create seating plan"
        Me.btnCreateSeatingPlan.UseVisualStyleBackColor = True
        '
        'PlanPanel
        '
        Me.PlanPanel.Location = New System.Drawing.Point(3, 3)
        Me.PlanPanel.Name = "PlanPanel"
        Me.PlanPanel.Size = New System.Drawing.Size(924, 696)
        Me.PlanPanel.TabIndex = 1
        '
        'lblNumberOfPupils
        '
        Me.lblNumberOfPupils.AutoSize = True
        Me.lblNumberOfPupils.Location = New System.Drawing.Point(612, 6)
        Me.lblNumberOfPupils.Name = "lblNumberOfPupils"
        Me.lblNumberOfPupils.Size = New System.Drawing.Size(95, 13)
        Me.lblNumberOfPupils.TabIndex = 121
        Me.lblNumberOfPupils.Text = "Number of pupils : "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1341, 762)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.btnSaveToFile)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.pbxRemoveDesk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSampleTeacherDesk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSamplePCDesk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSampleDesk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.nudNILevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RoomPanel As System.Windows.Forms.Panel
    Friend WithEvents pbxSampleDesk As System.Windows.Forms.PictureBox
    Friend WithEvents btnSaveToFile As System.Windows.Forms.Button
    Friend WithEvents btnOpenFile As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lbxPupilRoster As System.Windows.Forms.ListBox
    Friend WithEvents btnAddPupil As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ddbGender As System.Windows.Forms.ComboBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents tbxPupilSurname As System.Windows.Forms.TextBox
    Friend WithEvents lblEnterSurname As System.Windows.Forms.Label
    Friend WithEvents tbxPupilForename As System.Windows.Forms.TextBox
    Friend WithEvents lblEnterForename As System.Windows.Forms.Label
    Friend WithEvents lblSEN As System.Windows.Forms.Label
    Friend WithEvents tickSEN As System.Windows.Forms.CheckBox
    Friend WithEvents nudNILevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblNI As System.Windows.Forms.Label
    Friend WithEvents lblAGAT As System.Windows.Forms.Label
    Friend WithEvents tickAGAT As System.Windows.Forms.CheckBox
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbxSamplePCDesk As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pbxRemoveDesk As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pbxSampleTeacherDesk As System.Windows.Forms.PictureBox
    Friend WithEvents lblCurrentlySelected As System.Windows.Forms.Label
    Friend WithEvents PlanPanel As System.Windows.Forms.Panel
    Friend WithEvents lbxPupils As System.Windows.Forms.ListBox
    Friend WithEvents btnCreateSeatingPlan As System.Windows.Forms.Button
    Friend WithEvents lblNumberOfPupils As System.Windows.Forms.Label

End Class
