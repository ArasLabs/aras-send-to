Module Connection


    Function getConnectionParameter(ByRef Server As String, ByRef Vault As String, ByRef Database As String) As Boolean

        ' read connection parameters (Server, Vault, Database)
        ' return true if parameters found, false if not

        Dim Cookiepath As String
        Dim settingsfile As String

        Cookiepath = System.Environment.GetFolderPath(Environment.SpecialFolder.Cookies)
        settingsfile = Cookiepath & "\ARASSendToSettings.txt"

        Try
            Dim sr As IO.StreamReader
            sr = New IO.StreamReader(settingsfile)
            Server = sr.ReadLine
            Vault = sr.ReadLine
            Database = sr.ReadLine
            sr.Close()
            Return True
        Catch ex As Exception
            Server = ""
            Vault = ""
            Database = ""
            Return False
        End Try

    End Function

    Function Connect(ByRef myConnection, ByRef myInnovator, ByVal usr, ByVal pwd, ByVal Server, ByVal Vault, ByVal Database) As Boolean

        ' connect to Server and create innovator instance

        Dim login_result As Aras.IOM.Item = Nothing

        Try
            myConnection = Aras.IOM.IomFactory.CreateHttpServerConnection(Server & "/Server/InnovatorServer.aspx", Database, usr, pwd)
            login_result = myConnection.Login()
        Catch ex As Exception
            Form1.lblStatus.Text = "Connection failed at all, Check Settings. Code: " & login_result.getErrorCode
            Return False
            Exit Function
        End Try

        If login_result.isError() Then
            myInnovator = Nothing
            Form1.lblStatus.Text = "Connection failed, Check Settings and Login data. Code: " & login_result.getErrorCode
            Return False
            Exit Function
        Else
            myInnovator = New Aras.IOM.Innovator(myConnection)
            Form1.lblStatus.Text = "Connection Successful"
            Return True
            Exit Function
        End If
    End Function

    Function Disconnect(ByRef myconnection)
        ' disconnect
        Try
            myconnection.Logout()
            Form1.lblStatus.Text = "Disconnected"
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
