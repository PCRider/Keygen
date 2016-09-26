Imports System.Globalization
Imports System.Exception
Imports System.Management

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
