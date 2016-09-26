Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Friend Class StringEncryptorDecryptor
    Public Shared Function Decrypt(ByVal cipherText As String, ByVal Password As String) As String
        Try
            Dim cipherData As Byte() = Convert.FromBase64String(cipherText)
            Dim bytes As New Rfc2898DeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
            Dim buffer2 As Byte() = StringEncryptorDecryptor.Decrypt(cipherData, bytes.GetBytes(&H20), bytes.GetBytes(&H10))
            Return Encoding.Unicode.GetString(buffer2)
        Catch obj1 As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function Decrypt(ByVal cipherData As Byte(), ByVal Password As String) As Byte()
        Dim bytes As New Rfc2898DeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
        Return StringEncryptorDecryptor.Decrypt(cipherData, bytes.GetBytes(&H20), bytes.GetBytes(&H10))
    End Function

    Public Shared Function Decrypt(ByVal cipherData As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
        Try
            Dim stream As New MemoryStream
            Dim rijndael As Rijndael = rijndael.Create
            rijndael.Key = Key
            rijndael.IV = IV
            Dim stream2 As New CryptoStream(stream, rijndael.CreateDecryptor, CryptoStreamMode.Write)
            stream2.Write(cipherData, 0, cipherData.Length)
            stream2.Close()
            Return stream.ToArray
        Catch obj1 As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Sub Decrypt(ByVal fileIn As String, ByVal fileOut As String, ByVal Password As String)
        Dim num2 As Integer
        Dim stream As New FileStream(fileIn, FileMode.Open, FileAccess.Read)
        Dim stream2 As New FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write)
        Dim bytes As New Rfc2898DeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
        Dim rijndael As Rijndael = rijndael.Create
        rijndael.Key = bytes.GetBytes(&H20)
        rijndael.IV = bytes.GetBytes(&H10)
        Dim stream3 As New CryptoStream(stream2, rijndael.CreateDecryptor, CryptoStreamMode.Write)
        Dim count As Integer = &H1000
        Dim buffer As Byte() = New Byte(count - 1) {}
        Do
            num2 = stream.Read(buffer, 0, count)
            stream3.Write(buffer, 0, num2)
        Loop While (num2 <> 0)
        stream3.Close()
        stream.Close()
    End Sub

    Public Shared Function EncryptByte(ByVal clearData As Byte(), ByVal Password As String) As Byte()
        Dim bytes As New Rfc2898DeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
        Return StringEncryptorDecryptor.EncryptByte(clearData, bytes.GetBytes(&H20), bytes.GetBytes(&H10))
    End Function

    Public Shared Function EncryptByte(ByVal clearData As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
        Dim stream As New MemoryStream
        Dim rijndael As Rijndael = rijndael.Create
        rijndael.Key = Key
        rijndael.IV = IV
        Dim stream2 As New CryptoStream(stream, rijndael.CreateEncryptor, CryptoStreamMode.Write)
        stream2.Write(clearData, 0, clearData.Length)
        stream2.Close()
        Return stream.ToArray
    End Function

    Public Shared Sub EncryptByte(ByVal fileIn As String, ByVal fileOut As String, ByVal Password As String)
        Dim num2 As Integer
        Dim stream As New FileStream(fileIn, FileMode.Open, FileAccess.Read)
        Dim stream2 As New FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write)
        Dim bytes As New Rfc2898DeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
        Dim rijndael As Rijndael = rijndael.Create
        rijndael.Key = bytes.GetBytes(&H20)
        rijndael.IV = bytes.GetBytes(&H10)
        Dim stream3 As New CryptoStream(stream2, rijndael.CreateEncryptor, CryptoStreamMode.Write)
        Dim count As Integer = &H1000
        Dim buffer As Byte() = New Byte(count - 1) {}
        Do
            num2 = stream.Read(buffer, 0, count)
            stream3.Write(buffer, 0, num2)
        Loop While (num2 <> 0)
        stream3.Close()
        stream.Close()
    End Sub

    Public Shared Function EncryptString(ByVal clearText As String, ByVal Password As String) As String
        Dim clearData As Byte() = Encoding.Unicode.GetBytes(clearText)
        Dim bytes As New PasswordDeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
        Return StringEncryptorDecryptor.ToAllAlphabets(Convert.ToBase64String(StringEncryptorDecryptor.EncryptByte(clearData, bytes.GetBytes(&H20), bytes.GetBytes(&H10)))).Substring(0, 10)
    End Function

    Private Shared Function IntToInt(ByVal x As Integer) As Integer
        Dim num As Integer = 0
        Do While (x > 0)
            num = (num + (x Mod 10))
            x = (x / 10)
        Loop
        If (num < 10) Then
            Return num
        End If
        Return StringEncryptorDecryptor.IntToInt(num)
    End Function

    Private Shared Function ToAllAlphabets(ByVal InputStr As String) As String
        Dim chArray As Char() = InputStr.ToCharArray
        Dim index As Integer = 0
        Dim str As String = ""
        'index
        For index = 0 To chArray.Length - 1
            If Char.IsDigit(chArray(index)) Then
                str = (str & chArray(index).ToString)
            Else
                Dim x As Integer = Asc(chArray(index))
                str = (str & StringEncryptorDecryptor.IntToInt(x).ToString)
            End If
        Next index
        Return str
    End Function

End Class
