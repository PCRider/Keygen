Imports Microsoft.Win32
Imports System.IO

Public Class Keygen

    Private Sub Keygen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim getter As New CpuIdGetter
        Me.txtCpuId.Text = getter.ComputerHardWare_ID
        'Dim strArray As String() = Me.txtCpuId.Text.Split(New Char() {"-"c})
        Dim password As String = Me.txtCpuId.Text.Replace("-", "")
        Dim Serial As String = SerialBox.Text.Replace("-", "")
        Dim Activation As String
        Activation = StringEncryptorDecryptor.EncryptString(Serial, password)
        Me.ActivationBox.Text = Activation

    End Sub

    Private Sub Regen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Regen.Click
        Dim password As String = Me.txtCpuId.Text.Replace("-", "")
        Dim Serial As String = SerialBox.Text.Replace("-", "")
        Dim Activation As String
        Activation = StringEncryptorDecryptor.EncryptString(Serial, password)
        Me.ActivationBox.Text = Activation
    End Sub
    Private Sub SaveFile(ByVal Serial As String, ByVal Activation As String)
        Dim key As RegistryKey
        Try
            Dim writer As New StreamWriter(New FileStream("SerialConfig.cfg", FileMode.Create, FileAccess.Write))
            writer.WriteLine(Serial)
            writer.WriteLine(Activation)
            writer.Flush()
            writer.Close()
            key = Registry.CurrentUser.CreateSubKey("software\AryaTranslator\AryaTranslatorSerial", RegistryKeyPermissionCheck.ReadWriteSubTree)
            key.OpenSubKey("software\AryaTranslator\AryaTranslatorSerial", True)
            key.SetValue("SerialNumber", Serial, RegistryValueKind.String)
            key.SetValue("Activation", Activation, RegistryValueKind.String)
            key.Flush()
            key.Close()
        Catch obj1 As Exception
            Try
                key = Registry.CurrentUser.CreateSubKey("software\AryaTranslator\AryaTranslatorSerial", RegistryKeyPermissionCheck.ReadWriteSubTree)
                key.OpenSubKey("software\AryaTranslator\AryaTranslatorSerial", True)
                key.SetValue("SerialNumber", Serial, RegistryValueKind.String)
                key.SetValue("Activation", Activation, RegistryValueKind.String)
                key.Flush()
                key.Close()
            Catch obj2 As Exception
            End Try
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.SaveFile(Me.SerialBox.Text, Me.ActivationBox.Text)
    End Sub
End Class
