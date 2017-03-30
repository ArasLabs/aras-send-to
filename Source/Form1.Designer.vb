<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.txtPwd = New System.Windows.Forms.TextBox
        Me.cbRememberME = New System.Windows.Forms.CheckBox
        Me.butOK = New System.Windows.Forms.Button
        Me.butCancel = New System.Windows.Forms.Button
        Me.butExitOK = New System.Windows.Forms.Button
        Me.butExitError = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtDocumentname = New System.Windows.Forms.TextBox
        Me.grpLogin = New System.Windows.Forms.GroupBox
        Me.butHide = New System.Windows.Forms.Button
        Me.butSettings = New System.Windows.Forms.Button
        Me.txtItemType = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grpProperties = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtClass = New System.Windows.Forms.TextBox
        Me.butGetClass = New System.Windows.Forms.Button
        Me.tvClass = New System.Windows.Forms.TreeView
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDocNumber = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.rb1 = New System.Windows.Forms.RadioButton
        Me.rb2 = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.butHelp = New System.Windows.Forms.Button
        Me.butShow = New System.Windows.Forms.Button
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.cbDeleteLocalFiles = New System.Windows.Forms.CheckBox
        Me.StatusStrip1.SuspendLayout()
        Me.grpLogin.SuspendLayout()
        Me.grpProperties.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(96, 19)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(139, 20)
        Me.txtUser.TabIndex = 0
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(96, 45)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(139, 20)
        Me.txtPwd.TabIndex = 1
        '
        'cbRememberME
        '
        Me.cbRememberME.AutoSize = True
        Me.cbRememberME.Location = New System.Drawing.Point(96, 71)
        Me.cbRememberME.Name = "cbRememberME"
        Me.cbRememberME.Size = New System.Drawing.Size(139, 17)
        Me.cbRememberME.TabIndex = 2
        Me.cbRememberME.Text = "Remember me next time"
        Me.cbRememberME.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Image = CType(resources.GetObject("butOK.Image"), System.Drawing.Image)
        Me.butOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butOK.Location = New System.Drawing.Point(9, 292)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(56, 23)
        Me.butOK.TabIndex = 20
        Me.butOK.Text = "Save"
        Me.butOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Location = New System.Drawing.Point(71, 292)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(51, 23)
        Me.butCancel.TabIndex = 21
        Me.butCancel.Text = "Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butExitOK
        '
        Me.butExitOK.Location = New System.Drawing.Point(128, 292)
        Me.butExitOK.Name = "butExitOK"
        Me.butExitOK.Size = New System.Drawing.Size(139, 23)
        Me.butExitOK.TabIndex = 110
        Me.butExitOK.Text = "Check In Successful, Exit"
        Me.butExitOK.UseVisualStyleBackColor = True
        '
        'butExitError
        '
        Me.butExitError.Location = New System.Drawing.Point(273, 292)
        Me.butExitError.Name = "butExitError"
        Me.butExitError.Size = New System.Drawing.Size(110, 23)
        Me.butExitError.TabIndex = 100
        Me.butExitError.Text = "Check In failed, Exit"
        Me.butExitError.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Password"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 509)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(420, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(45, 17)
        Me.ToolStripStatusLabel1.Text = "Status: "
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(121, 17)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'txtDocumentname
        '
        Me.txtDocumentname.Location = New System.Drawing.Point(95, 72)
        Me.txtDocumentname.Name = "txtDocumentname"
        Me.txtDocumentname.Size = New System.Drawing.Size(288, 20)
        Me.txtDocumentname.TabIndex = 7
        '
        'grpLogin
        '
        Me.grpLogin.Controls.Add(Me.butHide)
        Me.grpLogin.Controls.Add(Me.butSettings)
        Me.grpLogin.Controls.Add(Me.txtItemType)
        Me.grpLogin.Controls.Add(Me.Label4)
        Me.grpLogin.Controls.Add(Me.txtPwd)
        Me.grpLogin.Controls.Add(Me.txtUser)
        Me.grpLogin.Controls.Add(Me.cbRememberME)
        Me.grpLogin.Controls.Add(Me.Label2)
        Me.grpLogin.Controls.Add(Me.Label1)
        Me.grpLogin.Location = New System.Drawing.Point(12, 12)
        Me.grpLogin.Name = "grpLogin"
        Me.grpLogin.Size = New System.Drawing.Size(394, 128)
        Me.grpLogin.TabIndex = 11
        Me.grpLogin.TabStop = False
        Me.grpLogin.Text = "Login Data"
        '
        'butHide
        '
        Me.butHide.Location = New System.Drawing.Point(252, 17)
        Me.butHide.Name = "butHide"
        Me.butHide.Size = New System.Drawing.Size(131, 23)
        Me.butHide.TabIndex = 10
        Me.butHide.Text = "Hide Login Info"
        Me.butHide.UseVisualStyleBackColor = True
        '
        'butSettings
        '
        Me.butSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butSettings.Location = New System.Drawing.Point(252, 43)
        Me.butSettings.Name = "butSettings"
        Me.butSettings.Size = New System.Drawing.Size(131, 23)
        Me.butSettings.TabIndex = 200
        Me.butSettings.Text = "Change Server Settings"
        Me.butSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.butSettings.UseVisualStyleBackColor = True
        '
        'txtItemType
        '
        Me.txtItemType.Location = New System.Drawing.Point(96, 95)
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.Size = New System.Drawing.Size(139, 20)
        Me.txtItemType.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Item Type"
        '
        'grpProperties
        '
        Me.grpProperties.BackColor = System.Drawing.SystemColors.Control
        Me.grpProperties.Controls.Add(Me.cbDeleteLocalFiles)
        Me.grpProperties.Controls.Add(Me.Label8)
        Me.grpProperties.Controls.Add(Me.txtClass)
        Me.grpProperties.Controls.Add(Me.butGetClass)
        Me.grpProperties.Controls.Add(Me.tvClass)
        Me.grpProperties.Controls.Add(Me.txtDescription)
        Me.grpProperties.Controls.Add(Me.Label7)
        Me.grpProperties.Controls.Add(Me.txtDocNumber)
        Me.grpProperties.Controls.Add(Me.Label6)
        Me.grpProperties.Controls.Add(Me.Label5)
        Me.grpProperties.Controls.Add(Me.rb1)
        Me.grpProperties.Controls.Add(Me.rb2)
        Me.grpProperties.Controls.Add(Me.butExitError)
        Me.grpProperties.Controls.Add(Me.Label3)
        Me.grpProperties.Controls.Add(Me.butExitOK)
        Me.grpProperties.Controls.Add(Me.butOK)
        Me.grpProperties.Controls.Add(Me.butCancel)
        Me.grpProperties.Controls.Add(Me.txtDocumentname)
        Me.grpProperties.Location = New System.Drawing.Point(12, 146)
        Me.grpProperties.Name = "grpProperties"
        Me.grpProperties.Size = New System.Drawing.Size(394, 321)
        Me.grpProperties.TabIndex = 12
        Me.grpProperties.TabStop = False
        Me.grpProperties.Text = "Document Properties"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "Classification"
        '
        'txtClass
        '
        Me.txtClass.Location = New System.Drawing.Point(95, 139)
        Me.txtClass.Name = "txtClass"
        Me.txtClass.ReadOnly = True
        Me.txtClass.Size = New System.Drawing.Size(288, 20)
        Me.txtClass.TabIndex = 118
        '
        'butGetClass
        '
        Me.butGetClass.Location = New System.Drawing.Point(9, 165)
        Me.butGetClass.Name = "butGetClass"
        Me.butGetClass.Size = New System.Drawing.Size(75, 23)
        Me.butGetClass.TabIndex = 117
        Me.butGetClass.Text = "Get Classes"
        Me.butGetClass.UseVisualStyleBackColor = True
        '
        'tvClass
        '
        Me.tvClass.FullRowSelect = True
        Me.tvClass.Location = New System.Drawing.Point(95, 165)
        Me.tvClass.Name = "tvClass"
        Me.tvClass.Size = New System.Drawing.Size(288, 98)
        Me.tvClass.TabIndex = 115
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(95, 99)
        Me.txtDescription.MaxLength = 128
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(288, 37)
        Me.txtDescription.TabIndex = 112
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Description"
        '
        'txtDocNumber
        '
        Me.txtDocNumber.Location = New System.Drawing.Point(95, 46)
        Me.txtDocNumber.Name = "txtDocNumber"
        Me.txtDocNumber.Size = New System.Drawing.Size(288, 20)
        Me.txtDocNumber.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Doc Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Doc Number"
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Location = New System.Drawing.Point(95, 22)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(60, 17)
        Me.rb1.TabIndex = 4
        Me.rb1.TabStop = True
        Me.rb1.Text = "Manuel"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Location = New System.Drawing.Point(159, 22)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(101, 17)
        Me.rb2.TabIndex = 5
        Me.rb2.TabStop = True
        Me.rb2.Text = "Server assigned"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Documentname"
        '
        'butHelp
        '
        Me.butHelp.Image = CType(resources.GetObject("butHelp.Image"), System.Drawing.Image)
        Me.butHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butHelp.Location = New System.Drawing.Point(9, 3)
        Me.butHelp.Name = "butHelp"
        Me.butHelp.Size = New System.Drawing.Size(52, 23)
        Me.butHelp.TabIndex = 202
        Me.butHelp.Text = "Help"
        Me.butHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.butHelp.UseVisualStyleBackColor = True
        '
        'butShow
        '
        Me.butShow.Location = New System.Drawing.Point(71, 3)
        Me.butShow.Name = "butShow"
        Me.butShow.Size = New System.Drawing.Size(100, 23)
        Me.butShow.TabIndex = 203
        Me.butShow.Text = "Show Login Info"
        Me.butShow.UseVisualStyleBackColor = True
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.butShow)
        Me.pnlButton.Controls.Add(Me.butHelp)
        Me.pnlButton.Location = New System.Drawing.Point(12, 475)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(394, 29)
        Me.pnlButton.TabIndex = 113
        '
        'cbDeleteLocalFiles
        '
        Me.cbDeleteLocalFiles.AutoSize = True
        Me.cbDeleteLocalFiles.Location = New System.Drawing.Point(9, 269)
        Me.cbDeleteLocalFiles.Name = "cbDeleteLocalFiles"
        Me.cbDeleteLocalFiles.Size = New System.Drawing.Size(239, 17)
        Me.cbDeleteLocalFiles.TabIndex = 120
        Me.cbDeleteLocalFiles.Text = "Delete Local File(s) after successful Check-In"
        Me.cbDeleteLocalFiles.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(420, 531)
        Me.Controls.Add(Me.pnlButton)
        Me.Controls.Add(Me.grpProperties)
        Me.Controls.Add(Me.grpLogin)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "ARAS SendTo (Check in Files to ARAS Innovator)"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpLogin.ResumeLayout(False)
        Me.grpLogin.PerformLayout()
        Me.grpProperties.ResumeLayout(False)
        Me.grpProperties.PerformLayout()
        Me.pnlButton.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents cbRememberME As System.Windows.Forms.CheckBox
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents butExitOK As System.Windows.Forms.Button
    Friend WithEvents butExitError As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtDocumentname As System.Windows.Forms.TextBox
    Friend WithEvents grpLogin As System.Windows.Forms.GroupBox
    Friend WithEvents grpProperties As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents butSettings As System.Windows.Forms.Button
    Friend WithEvents txtItemType As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtDocNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents butHelp As System.Windows.Forms.Button
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents butHide As System.Windows.Forms.Button
    Friend WithEvents butShow As System.Windows.Forms.Button
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents tvClass As System.Windows.Forms.TreeView
    Friend WithEvents butGetClass As System.Windows.Forms.Button
    Friend WithEvents txtClass As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbDeleteLocalFiles As System.Windows.Forms.CheckBox

End Class
