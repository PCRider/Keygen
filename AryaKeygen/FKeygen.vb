
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System
Imports System.Globalization
Imports System.Exception
Imports System.Management
Imports AryaSoftLock
Imports Microsoft.Win32

Public Class FKeygen

    Private Sub FKeygen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim getter As New CpuIdGetter
        Me.THardCode.Text = getter.ComputerHardWare_ID
        Dim HardCode = Me.THardCode.Text.Replace("-", "")
        Dim SerialCode = Me.TSerial.Text.Replace("-", "")
        Me.TActCode.Text = StringEncryptorDecryptor.EncryptString(SerialCode, HardCode)
    End Sub

    Private Sub BRegen_Click(sender As System.Object, e As System.EventArgs) Handles BRegen.Click
        Dim HardCode = Me.THardCode.Text.Replace("-", "")
        Dim SerialCode = Me.TSerial.Text.Replace("-", "")
        Me.TActCode.Text = StringEncryptorDecryptor.EncryptString(SerialCode, HardCode)
    End Sub

    Private Sub BReg_Click(sender As System.Object, e As System.EventArgs) Handles BReg.Click
        Dim key As RegistryKey
        Try
            Dim writer As New StreamWriter(New FileStream("SerialConfig.cfg", FileMode.Create, FileAccess.Write))
            writer.WriteLine(Me.TSerial.Text.Replace("-", ""))
            writer.WriteLine(Me.TActCode.Text)
            writer.Flush()
            writer.Close()
            key = Registry.CurrentUser.CreateSubKey("software\AryaTranslator\AryaTranslatorSerial", RegistryKeyPermissionCheck.ReadWriteSubTree)
            key.OpenSubKey("software\AryaTranslator\AryaTranslatorSerial", True)
            key.SetValue("SerialNumber", Me.TSerial.Text.Replace("-", ""), RegistryValueKind.String)
            key.SetValue("Activation", Me.TActCode.Text, RegistryValueKind.String)
            key.Flush()
            key.Close()
        Catch obj1 As Exception
            Try
                key = Registry.CurrentUser.CreateSubKey("software\AryaTranslator\AryaTranslatorSerial", RegistryKeyPermissionCheck.ReadWriteSubTree)
                key.OpenSubKey("software\AryaTranslator\AryaTranslatorSerial", True)
                key.SetValue("SerialNumber", Me.TSerial.Text.Replace("-", ""), RegistryValueKind.String)
                key.SetValue("Activation", Me.TActCode.Text, RegistryValueKind.String)
                key.Flush()
                key.Close()
            Catch obj2 As Exception
            End Try
        End Try
    End Sub
End Class



'Friend Class StringEncryptorDecryptor
'    ' Methods
'    Public Shared Function Decrypt(ByVal cipherText As String, ByVal Password As String) As String
'        Try
'            Dim cipherData As Byte() = Convert.FromBase64String(cipherText)
'            Dim bytes As New PasswordDeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
'            Dim buffer2 As Byte() = StringEncryptorDecryptor.Decrypt(cipherData, bytes.GetBytes(&H20), bytes.GetBytes(&H10))
'            Return Encoding.Unicode.GetString(buffer2)
'        Catch obj1 As Exception
'            Return Nothing
'        End Try
'    End Function

'    Public Shared Function Decrypt(ByVal cipherData As Byte(), ByVal Password As String) As Byte()
'        Dim bytes As New PasswordDeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
'        Return StringEncryptorDecryptor.Decrypt(cipherData, bytes.GetBytes(&H20), bytes.GetBytes(&H10))
'    End Function

'    Public Shared Function Decrypt(ByVal cipherData As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
'        Try
'            Dim stream As New MemoryStream
'            Dim rijndael As Rijndael = rijndael.Create
'            rijndael.Key = Key
'            rijndael.IV = IV
'            Dim stream2 As New CryptoStream(stream, rijndael.CreateDecryptor, CryptoStreamMode.Write)
'            stream2.Write(cipherData, 0, cipherData.Length)
'            stream2.Close()
'            Return stream.ToArray
'        Catch obj1 As Exception
'            Return Nothing
'        End Try
'    End Function

'    Public Shared Sub Decrypt(ByVal fileIn As String, ByVal fileOut As String, ByVal Password As String)
'        Dim num2 As Integer
'        Dim stream As New FileStream(fileIn, FileMode.Open, FileAccess.Read)
'        Dim stream2 As New FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write)
'        Dim bytes As New PasswordDeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
'        Dim rijndael As Rijndael = rijndael.Create
'        rijndael.Key = bytes.GetBytes(&H20)
'        rijndael.IV = bytes.GetBytes(&H10)
'        Dim stream3 As New CryptoStream(stream2, rijndael.CreateDecryptor, CryptoStreamMode.Write)
'        Dim count As Integer = &H1000
'        Dim buffer As Byte() = New Byte(count - 1) {}
'        Do
'            num2 = stream.Read(buffer, 0, count)
'            stream3.Write(buffer, 0, num2)
'        Loop While (num2 <> 0)
'        stream3.Close()
'        stream.Close()
'    End Sub

'    Public Shared Function EncryptByte(ByVal clearData As Byte(), ByVal Password As String) As Byte()
'        Dim bytes As New PasswordDeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
'        Return StringEncryptorDecryptor.EncryptByte(clearData, bytes.GetBytes(&H20), bytes.GetBytes(&H10))
'    End Function

'    Public Shared Function EncryptByte(ByVal clearData As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
'        Dim stream As New MemoryStream
'        Dim rijndael As Rijndael = rijndael.Create
'        rijndael.Key = Key
'        rijndael.IV = IV
'        Dim stream2 As New CryptoStream(stream, rijndael.CreateEncryptor, CryptoStreamMode.Write)
'        stream2.Write(clearData, 0, clearData.Length)
'        stream2.Close()
'        Return stream.ToArray
'    End Function

'    Public Shared Sub EncryptByte(ByVal fileIn As String, ByVal fileOut As String, ByVal Password As String)
'        Dim num2 As Integer
'        Dim stream As New FileStream(fileIn, FileMode.Open, FileAccess.Read)
'        Dim stream2 As New FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write)
'        Dim bytes As New PasswordDeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
'        Dim rijndael As Rijndael = rijndael.Create
'        rijndael.Key = bytes.GetBytes(&H20)
'        rijndael.IV = bytes.GetBytes(&H10)
'        Dim stream3 As New CryptoStream(stream2, rijndael.CreateEncryptor, CryptoStreamMode.Write)
'        Dim count As Integer = &H1000
'        Dim buffer As Byte() = New Byte(count - 1) {}
'        Do
'            num2 = stream.Read(buffer, 0, count)
'            stream3.Write(buffer, 0, num2)
'        Loop While (num2 <> 0)
'        stream3.Close()
'        stream.Close()
'    End Sub

'    Public Shared Function EncryptString(ByVal clearText As String, ByVal Password As String) As String
'        Dim clearData As Byte() = Encoding.Unicode.GetBytes(clearText)
'        Dim bytes As New PasswordDeriveBytes(Password, New Byte() {&H49, &H76, &H61, 110, &H20, &H4D, &H65, 100, &H76, &H65, 100, &H65, &H76})
'        Return StringEncryptorDecryptor.ToAllAlphabets(Convert.ToBase64String(StringEncryptorDecryptor.EncryptByte(clearData, bytes.GetBytes(&H20), bytes.GetBytes(&H10)))).Substring(0, 10)
'    End Function

'    Private Shared Function IntToInt(ByVal x As Integer) As Integer
'        Dim num As Integer = 0
'        Do While (x > 0)
'            num = (num + (x Mod 10))
'            x = (x / 10)
'        Loop
'        If (num < 10) Then
'            Return num
'        End If
'        Return StringEncryptorDecryptor.IntToInt(num)
'    End Function

'    Private Shared Function ToAllAlphabets(ByVal InputStr As String) As String
'        Dim chArray As Char() = InputStr.ToCharArray
'        Dim index As Integer = 0
'        Dim str As String = ""
'        'index()
'        For index = 0 To chArray.Length - 1
'            If Char.IsDigit(chArray(index)) Then
'                str = (str & chArray(index).ToString)
'            Else
'                Dim x As Integer = AscW(chArray(index))
'                str = (str & StringEncryptorDecryptor.IntToInt(x).ToString)
'            End If
'        Next index
'        Return str
'    End Function

'    Shared Sub EncryptString(textBox As TextBox, textBox1 As TextBox)
'        Throw New NotImplementedException
'    End Sub

'End Class
Public Class CpuIdGetter
    ' Methods
    Private Sub CPUCode2Serial()
        Dim startIndex As Integer = (Me.CPUCode.Length / 4)
        Dim s As String = Me.CPUCode.Substring(0, (startIndex - 1))
        Dim str2 As String = Me.CPUCode.Substring(startIndex, (startIndex - 1))
        Dim str3 As String = Me.CPUCode.Substring((startIndex * 2), (startIndex - 1))
        Dim str4 As String = Me.CPUCode.Substring((startIndex * 3), (startIndex - 1))
        Dim num3 As UInt64 = UInt64.Parse(s, NumberStyles.AllowHexSpecifier)
        Dim num4 As UInt64 = UInt64.Parse(str2, NumberStyles.AllowHexSpecifier)
        Dim num5 As UInt64 = UInt64.Parse(str3, NumberStyles.AllowHexSpecifier)
        Dim num6 As UInt64 = UInt64.Parse(str4, NumberStyles.AllowHexSpecifier)
        s = num3.ToString
        Do While (s.Length < 5)
            s = ("0" & s)
        Loop
        str2 = num4.ToString
        Do While (str2.Length < 5)
            str2 = ("0" & str2)
        Loop
        str3 = num5.ToString
        Do While (str3.Length < 5)
            str3 = ("0" & str3)
        Loop
        str4 = num6.ToString
        Do While (str4.Length < 5)
            str4 = ("0" & str4)
        Loop
        Me.TempSrial = String.Concat(New String() {s, "-", str2, "-", str3, "-", str4})
    End Sub

    Private Sub MakeHardwareID()
        Me.ComputerHardWare_ID = ""
        Dim num As Integer = 0
        Dim num2 As Integer = 0
        'num
        For num = 0 To Me.TempSrial.Length - 1
            num2 += 1
            If (num2 = 6) Then
                num2 = 0
                Me.ComputerHardWare_ID = (Me.ComputerHardWare_ID & "-")
            Else
                Dim ch As Char = Me.TempSrial.Chars(num)
                Dim s As String = ch.ToString
                Dim str2 As String = "0"
                If (num < Me.BaseBoardSerial.Length) Then
                    str2 = Me.BaseBoardSerial.Chars(num).ToString
                End If
                Me.ComputerHardWare_ID = (Me.ComputerHardWare_ID & ((Integer.Parse(s) + Integer.Parse(str2)) Mod 10).ToString)
            End If
        Next num
    End Sub

    Private Function GetCPUCode() As String
        Dim str As String = "Win32_Processor"
        Dim str2 As String = ""
        Dim searcher As New ManagementObjectSearcher(("select ProcessorId from " & str))
        Dim obj2 As ManagementObject
        For Each obj2 In searcher.Get
            Dim data As PropertyData
            For Each data In obj2.Properties
                str2 = CStr(data.Value)
                Exit For
            Next
            Exit For
        Next
        Me.CPUCode = str2
        Return str2
    End Function

    Private Function GetBaseBoardCode() As String
        Dim str As String = "Win32_BaseBoard"
        Dim str2 As String = ""
        Dim searcher As New ManagementObjectSearcher(("select SerialNumber from " & str))
        Dim obj2 As ManagementObject
        For Each obj2 In searcher.Get
            Dim data As PropertyData
            For Each data In obj2.Properties
                str2 = CStr(data.Value)
                Exit For
            Next
            Exit For
        Next
        Me.BaseBoardCode = str2
        Return str2
    End Function

    Private Function SaveCPUCode() As String
        Me.CPUCode2 = Me.CPUCode
        Return Me.CPUCode
    End Function

    Private Sub BaseBoardCode2Serial()
        Dim length As Integer = Me.BaseBoardCode.Length
        Dim num2 As Integer = 0
        Dim num3 As Integer = 0
        Dim str As String = ""
        num2 = (length - 1)
        Do While (num2 >= 0)
            Dim s As String = Me.BaseBoardCode.Chars(num2).ToString
            Try
                Integer.Parse(s)
            Catch obj1 As Exception
                Dim ch As Char = s.Chars(0)
                Dim num4 As Integer = AscW(ch)
                s = (num4 Mod 10).ToString
            End Try
            num3 += 1
            If (num3 = 6) Then
                str = (str & "-")
                num3 = 1
            End If
            str = (str & s)
            num2 -= 1
        Loop
        Me.BaseBoardSerial = str
    End Sub

    Public Sub New()
        Try
            Me.CPUCode = ""
            Me.CPUCode2 = ""
            Me.TempSrial = ""
            Me.GetCPUCode()
            Me.SaveCPUCode()
            Me.CPUCode2Serial()
            Me.GetBaseBoardCode()
            Me.BaseBoardCode2Serial()
            Me.MakeHardwareID()
        Catch obj1 As Exception
            Me.CPUCode = ""
            Me.CPUCode2 = ""
            Me.TempSrial = ""
        End Try
    End Sub


    ' Fields
    Private CPUSerial As String
    Private BaseBoardSerial As String
    Private CPUCode As String
    Private CPUCode2 As String
    Private TempSrial As String
    Private BaseBoardCode As String
    Public ComputerHardWare_ID As String
End Class


