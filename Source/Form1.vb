Public Class Form1

#Region "Public definitions"
    ' Innovator connection, login and instance variables
    Dim MyConnection As Aras.IOM.HttpServerConnection
    Dim MyInnovator As Aras.IOM.Innovator
    Dim Server As String
    Dim Vault As String
    Dim Database As String
    Dim usr As String
    Dim pwd As String

    ' path to the windows standard folders "Send To" and "Cookies"
    Dim CookiePath As String
    Dim SendToPath As String

    ' Array with all files for check in
    Dim CheckInFile() As String

    ' file with login information if the user did save it
    ' this file is saved in cookies, the password is coded
    Dim LoginDataFile As String


    Dim item_type As String
    Dim number_server_assigned As Boolean
    Dim DocID As String
    Dim ExistingLoginCredentials As Boolean = False
#End Region

#Region "Form Close Event"
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Disconnect from Innovator in any case if the form is closing 
        Disconnect(MyConnection)
    End Sub
#End Region

#Region "Form Load Event"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   
        ' prepare the checkin process after the user started the program

        ' set gui
        butExitOK.Visible = False
        butExitError.Visible = False
        txtDocNumber.Visible = False
        txtDocNumber.Text = Nothing
        butShow.Visible = False

        ' Get Path Information and set Filepointers
        CookiePath = System.Environment.GetFolderPath(Environment.SpecialFolder.Cookies)
        SendToPath = System.Environment.GetFolderPath(Environment.SpecialFolder.SendTo)
        LoginDataFile = CookiePath & "\ARASSendToInfos.txt"

        ' see whether login credentials exist and set login data accordingly
        If IO.File.Exists(LoginDataFile) Then
            ' login data are existing, load it 
            Dim sr As IO.StreamReader
            sr = New IO.StreamReader(LoginDataFile)
            usr = sr.ReadLine
            pwd = sr.ReadLine
            item_type = sr.ReadLine
            number_server_assigned = sr.ReadLine
            sr.Close()
            txtUser.Text = usr
            txtPwd.Text = pwd
            txtItemType.Text = item_type
            cbRememberME.Checked = True
            ExistingLoginCredentials = True
            hide_login()
            lblStatus.Text = "Enter Document Properties and Save"
        Else
            ' User has to enter this information manually. 
            ' Help user with default document item type
            cbRememberME.Checked = False
            item_type = "Document"
            txtItemType.Text = item_type
            lblStatus.Text = "Enter Login Data, Document Properties and save"
        End If

        ' Set number genration methode in the form
        If number_server_assigned = True Then
            rb1.Checked = False
            rb2.Checked = True
        Else
            rb1.Checked = True
            rb2.Checked = False
        End If

        ' read parameters Windows (send to) sent to us. 
        ' the file list selected by the user starts with parameter 2
        ' Exit if the File List contains a directory
        Dim argC As Integer = 0
        Dim dirInfo As IO.DirectoryInfo
        For Each arg As String In Environment.GetCommandLineArgs()
            ReDim Preserve CheckInFile(argC)
            CheckInFile(argC) = arg
            argC += 1
            dirInfo = New IO.DirectoryInfo(arg)
            If dirInfo.Extension.Length = 0 Then
                MessageBox.Show("Your Selection contains at least one Directory. Only files are allowed for Check-In. Select the files only and start again.", "Cannot Check-In Directories", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Next arg

        '' manual file pointer for debuging
        'argC = 3
        'ReDim CheckInFile(1)
        'CheckInFile(1) = "C:\Users\anwender\Documents\Allemann Aktuell\Test.txt"


        ' if no second parameter received, we can not proceed (this happens
        ' e.g. if the program strarts not from the 'send to' action and receives
        ' no command line arguments)
        If argC = 1 Then
            lblStatus.Text = "No File for Check in received"
            butExitError.Visible = True
            butOK.Visible = False
            butCancel.Visible = False
        End If

    End Sub

#End Region

#Region "User did click Save and started the Check-In Process"
    Private Sub butOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click

        ' in worst case, exit sub in a controlled way
        Try
            ' let user know we are working
            lblStatus.Text = "Please Wait....."
            Me.Refresh()
            Cursor.Current = Cursors.WaitCursor

            ' save login credentials if user wants to
            ' save password md5 coded if the user entered it new
            ' if we read the login data at start, the password is already coded
            ' delete the login data file if user uncheckes the remember flag
            If cbRememberME.Checked = True Then
                Dim sw As IO.StreamWriter
                sw = New IO.StreamWriter(LoginDataFile, False)
                sw.WriteLine(txtUser.Text)
                If ExistingLoginCredentials = True Then
                    sw.WriteLine(txtPwd.Text)
                Else
                    sw.WriteLine(ConvertPasswordToMD5(txtPwd.Text))
                End If

                sw.WriteLine(txtItemType.Text)
                If rb2.Checked = True Then
                    sw.WriteLine("true")
                Else
                    sw.WriteLine("false")
                End If
                sw.Close()
            Else
                If IO.File.Exists(LoginDataFile) Then IO.File.Delete(LoginDataFile)
            End If

            ' check number. if number mode is set to manual, user must enter a number or exit
            If rb1.Checked = True Then
                If txtDocNumber.Text = Nothing Then
                    txtDocNumber.BackColor = Color.Red
                    lblStatus.Text = "Enter a Number"
                    Exit Sub
                Else
                    txtDocNumber.BackColor = Color.White
                End If
            End If


            ' Read Connection Parameter (Server, Vault, Database)
            ' if we dont find connection parameter file, ask user for it and exit
            If getConnectionParameter(Server, Vault, Database) = False Then
                MessageBox.Show("Could not find Connection Parameters, please define first and save", "Connection Parameters not found")
                Dim frmSettings As New Form2
                frmSettings.ShowDialog()
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            ' connect to Innovator
            ' if user did enter the plain password, convert it
            ' Exit if connection fails
            If ExistingLoginCredentials = True Then
                If Connect(MyConnection, MyInnovator, txtUser.Text, txtPwd.Text, Server, Vault, Database) = False Then
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
            Else
                If Connect(MyConnection, MyInnovator, txtUser.Text, ConvertPasswordToMD5(txtPwd.Text), Server, Vault, Database) = False Then
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
            End If



            ' Create Doc Item
            Dim MyDocItem As Aras.IOM.Item = MyInnovator.newItem(txtItemType.Text, "add")
            MyDocItem.setProperty("item_number", txtDocNumber.Text)
            MyDocItem.setProperty("name", txtDocumentname.Text)
            MyDocItem.setProperty("description", txtDescription.Text)
            MyDocItem.setProperty("classification", txtClass.Text)

            ' Create file Item's and Relationships. if user selected many files
            ' create file item and relationship for all of them
            Dim I As Integer = 1
            For I = 1 To CheckInFile.Length - 1
                Dim MyFileItem As Aras.IOM.Item = MyInnovator.newItem("File", "add")
                MyFileItem.setFileName(CheckInFile(I))
                'MyFileItem.attachPhysicalFile(CheckInFile(I))
                Dim MyRelItem As Aras.IOM.Item = MyInnovator.newItem(txtItemType.Text & " File", "add")
                MyDocItem.addRelationship(MyRelItem)
                MyRelItem.setRelatedItem(MyFileItem)
            Next

            ' execute "add"
            Dim MyResult As Aras.IOM.Item
            MyResult = MyDocItem.apply()

            'remember doc id
            DocID = MyDocItem.getID

            ' process error messages
            If MyResult.isError = True Then
                lblStatus.Text = "Check in Failed Code: " & MyResult.getErrorCode
                butExitError.Visible = True
                butExitOK.Visible = False
                butOK.Visible = False
                butCancel.Visible = False
                MessageBox.Show(MyResult.getErrorDetail, "Check in Failed")
            Else
                lblStatus.Text = "Check in Successful"
                butExitError.Visible = False
                butExitOK.Visible = True
                butOK.Visible = False
                butCancel.Visible = False
                ' Delete Local Files after check-in
                If cbDeleteLocalFiles.checked = True Then
                    For I = 1 To CheckInFile.Length - 1
                        IO.File.Delete(CheckInFile(I))
                    Next
                End If
            End If

            ' thats it
            Cursor.Current = Cursors.Default
            Exit Sub
        Catch ex As Exception
            lblStatus.Text = "undefined Error"
            MessageBox.Show(ex.Message.ToString, "Undefined Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor.Current = Cursors.Default
            Exit Sub
        End Try

    End Sub
#End Region

#Region "all other User driven events on the Form (buttons)"
    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.Close()
    End Sub

    Private Sub butSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSettings.Click
        Dim frmSettings As New Form2
        frmSettings.ShowDialog()
    End Sub

    Private Sub butExitOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExitOK.Click
        Me.Close()
    End Sub

    Private Sub butExitError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExitError.Click
        Me.Close()
    End Sub
    Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
        txtDocNumber.Visible = rb1.Checked
    End Sub
    Private Sub rb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb2.CheckedChanged
        txtDocNumber.Visible = rb1.Checked
    End Sub

    Private Sub butHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butHelp.Click
        Dim help As New Dialog1
        help.Show()
    End Sub

    Private Sub hide_login()
        If cbRememberME.Checked = False Then
            MessageBox.Show("Enter Login Information first and Check Remember me", "Can not Hide Login Info")
            Exit Sub
        End If
        grpLogin.Visible = False
        grpProperties.Location = New Point(12, 12)
        butShow.Visible = True
        pnlButton.Location = New Point(12, 350)
        Me.Size = New Point(426, 440)
    End Sub
    Private Sub show_login()
        grpLogin.Visible = True
        grpProperties.Location = New Point(12, 146)
        butShow.Visible = False
        pnlButton.Location = New Point(12, 475)
        Me.Size = New Point(426, 555)
    End Sub
    Private Sub butHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butHide.Click
        hide_login()
    End Sub

    Private Sub butShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butShow.Click
        show_login()
    End Sub
    Private Sub txtPwd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPwd.KeyDown
        ExistingLoginCredentials = False
    End Sub

#End Region

#Region "Subroutine to read class structure from the selected Item Type"
    Private Sub GetClasses()

        ' Get class structure from the selected Item Type and build the sctructure in a Tree View

        ' Required Input: 
        '       the name of the Item Type we want to read the Class Structure from
        '       (in this case we read this value from the form)
        Dim ItemTypeName As String = txtItemType.Text

        ' Required GUI Control to show the Class Structure:
        ' in our case, the structure gets build in the Tree View Control
        ' tvClass. The control tvClass must already exist on the form calling this sub


        ' read Classstructure from the selected Item Type. The class structure is stored
        ' as an XML structure in a Tex Field named "class_structure" 
        Dim ClassStructure As String
        Dim MyDocClass As Aras.IOM.Item = MyInnovator.newItem("ItemType", "get")
        MyDocClass.setAttribute("select", "name")
        MyDocClass.setAttribute("select", "class_structure")
        MyDocClass.setProperty("name", ItemTypeName)
        MyDocClass.setPropertyCondition("name", "eq")
        Dim MyResult1 As Aras.IOM.Item = MyDocClass.apply()
        ClassStructure = MyResult1.getItemByIndex(0).getProperty("class_structure", "nothing")

        ' if the class_structure exists, analyse it and build the tree view control
        If ClassStructure <> "nothing" Then
            Dim CS As String = ClassStructure
            Dim tn As New TreeNode
            Dim NextIsSub As Boolean = False
            Dim OneUp As Boolean = False
            Dim LastNode As New TreeNode

            ' Loop trough all Tags of the XML file
            ' read all Elements in <...>, analyse them and fill tre tree
            Do
                ' Read the first Tag in the XML-String
                Dim Tag As String
                Dim TagName As String
                Dim I1, I2 As Integer
                I1 = CS.IndexOf("<")
                I2 = CS.IndexOf(">", 1)
                Tag = CS.Substring(I1, I2 - I1 + 1)

                'remove the TAG we just read from the string. in the next loop
                ' we will get the next TAG as the first TAG in the String
                CS = CS.Substring(I2 - I1 + 1)

                ' Read Tag Name from The TAG by removing all other characters
                Try
                    TagName = Tag.Substring(Tag.IndexOf(Chr(34)) + 1)
                    TagName = TagName.Substring(0, TagName.IndexOf(Chr(34)))
                Catch ex As Exception
                    TagName = Tag
                End Try

                ' if no node exists in the tree so far, create first node
                If tvClass.Nodes.Count = 0 Then
                    ' first node
                    tn = New TreeNode
                    tn.Name = Tag
                    tn.Text = TagName
                    tvClass.Nodes.Add(tn)
                    LastNode = tn
                Else
                    ' build second to many node in the tree
                    If Tag = "</class>" Then ' move one level up in treeview, no node to add
                        Dim pn As New TreeNode
                        pn = LastNode.Parent
                        LastNode = New TreeNode
                        LastNode = pn
                    Else
                        ' add new node as sister, son or sister of the last parant
                        If NextIsSub = True Then ' subnode of last
                            tn = New TreeNode
                            tn.Name = Tag
                            tn.Text = TagName
                            LastNode.Nodes.Add(tn)
                            LastNode = tn
                        End If
                        If NextIsSub = False Then ' sisternode of last node
                            tn = New TreeNode
                            tn.Name = Tag
                            tn.Text = TagName
                            Dim SisterNode As New TreeNode
                            SisterNode = LastNode.Parent
                            SisterNode.Nodes.Add(tn)
                            LastNode = tn
                        End If
                    End If
                End If


                ' decide depending on the end of the tag string
                ' what type of tag the next one will be
                If Tag.EndsWith("/>") Then
                    NextIsSub = False           ' Next is Sister to last
                Else
                    NextIsSub = True            ' Next is Sub Element from last
                End If
                If Tag.EndsWith("/class>") Then
                    OneUp = True                ' Class end, next is sister to last's parent
                    NextIsSub = False
                Else
                    OneUp = False               ' Next is in any case on the same level or deeper
                End If
            Loop Until CS.Length < 1
        End If

        tvClass.Nodes(0).Expand()

    End Sub
#End Region

#Region "Start Get Class Structure Process (Get Class Button Click)"

    Private Sub butGetClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetClass.Click

        ' Connect to Innovator and get Class Structure for the Item Type


        ' Read Connection Parameter (Server, Vault, Database)
        ' if we dont find connection parameter file, ask user for it and exit
        If getConnectionParameter(Server, Vault, Database) = False Then
            MessageBox.Show("Could not find Connection Parameters, please define first and save", "Connection Parameters not found")
            Dim frmSettings As New Form2
            frmSettings.ShowDialog()
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        ' connect to Innovator
        ' if user did enter the plain password, convert it
        ' Exit if connection fails 
        Cursor.Current = Cursors.WaitCursor
        If ExistingLoginCredentials = True Then
            If Connect(MyConnection, MyInnovator, txtUser.Text, txtPwd.Text, Server, Vault, Database) = False Then
                Cursor.Current = Cursors.Default
                Exit Sub
            End If
        Else
            If Connect(MyConnection, MyInnovator, txtUser.Text, ConvertPasswordToMD5(txtPwd.Text), Server, Vault, Database) = False Then
                Cursor.Current = Cursors.Default
                Exit Sub
            End If
        End If

        ' Get Classes if connection successfull
        GetClasses()
        Cursor.Current = Cursors.Default
    End Sub
#End Region

#Region "Tree View Events"
    Private Sub tvClass_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvClass.AfterSelect
        ' Build the Class String in the Required Form if the user is clicking around
        ' in the tree view
        txtClass.Text = tvClass.SelectedNode.Text
        Dim I As Integer
        Dim CurrentNode As New TreeNode
        CurrentNode = tvClass.SelectedNode
        For I = 1 To tvClass.SelectedNode.Level
            Dim P As New TreeNode
            P = CurrentNode.Parent
            txtClass.Text = P.Text & "/" & txtClass.Text
            CurrentNode = P
        Next
        txtClass.Text = "/" & txtClass.Text
    End Sub
#End Region


End Class

