Public Class Form2
    Dim SettingsFile As String
    Dim CookiePath As String

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sr As IO.StreamReader

        ' set file path and file pointer
        CookiePath = System.Environment.GetFolderPath(Environment.SpecialFolder.Cookies)
        SettingsFile = CookiePath & "\ARASSendToSettings.txt"

        If IO.File.Exists(SettingsFile) = True Then
            sr = New IO.StreamReader(SettingsFile)
            txtServer.Text = sr.ReadLine
            txtVault.Text = sr.ReadLine
            txtDatabase.Text = sr.ReadLine
            sr.Close()
        Else
            ' make a quess
            txtServer.Text = "http://localhost/InnovatorServer"
            txtVault.Text = "http://localhost/InnovatorServer/vault"
            txtDatabase.Text = "InnovatorSolutions"
        End If

    End Sub

    Private Sub butSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Dim sw As IO.StreamWriter
        sw = New IO.StreamWriter(SettingsFile, False)
        sw.WriteLine(txtServer.Text)
        sw.WriteLine(txtVault.Text)
        sw.WriteLine(txtDatabase.Text)
        sw.Close()
        Me.Close()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.Close()
    End Sub
End Class