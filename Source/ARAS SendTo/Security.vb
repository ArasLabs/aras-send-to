Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text


Module Security

    ' Diese Funktionen sind aus dem ARAS Handbuch und 
    ' dienen der Passwortverschlüsselung. Passworte
    ' werden verschlüsselt an Innovator übergeben
    '-----------------------------------------------------
    Public Function ConvertPasswordToMD5(ByVal plainPasswd As String) As String
        Dim MD5Passwd As String = ""
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim ascii As ASCIIEncoding = New ASCIIEncoding()
        Dim data As Byte() = ascii.GetBytes(plainPasswd)
        Dim result As Byte() = md5.ComputeHash(data)
        'Convert the MD5 result to Hexadecimal string
        MD5Passwd = BinaryToHex(result)
        Return (MD5Passwd.ToLower())
    End Function
    ' Use this function to convert your MD5
    ' hash 16 bytes array to 32 hexadecimals string.
    ' Note: This code taken from www.gotdotnet.com - Topic: Function to convert your MD5 16 byte hash to 32 hexadecimals 
    Public Function BinaryToHex(ByVal BinaryArray As Byte()) As String
        Dim result As String = ""
        Dim lowerByte As Long
        Dim upperByte As Long
        Dim singleByte As Byte

        For Each singleByte In BinaryArray

            lowerByte = singleByte And 15
            upperByte = singleByte >> 4

            result += NumberToHex(upperByte)
            result += NumberToHex(lowerByte)
        Next
        Return (result)
    End Function

    ' Convert the number to hexadecimal
    ' Note: This code taken from www.gotdotnet.com - Topic: Function to convert your MD5 16 byte hash to 32 hexadecimals 
    Public Function NumberToHex(ByVal Number As Long) As Char
        If Number > 9 Then
            Return Convert.ToChar(65 + (Number - 10))
        Else
            Return Convert.ToChar(48 + Number)
        End If
    End Function
End Module
