Imports System.Runtime.InteropServices
Imports System
Imports System.Text
Imports Microsoft.WindowsAPICodePack.Shell.PropertySystem
Imports MS.WindowsAPICodePack.Internal
Imports MyHotKeys.ShellHelpers

Module WindowsMessageHelpers

    Friend APP_ID As String = My.Application.Info.ProductName '"Microsoft.Samples.DesktopToastsSample" 'eig CONST

    Friend Function TryCreateShortcut() As Boolean
        Dim shortcutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Microsoft\Windows\Start Menu\Programs\" & My.Application.Info.ProductName & ".lnk"
        If (Not System.IO.File.Exists(shortcutPath)) Then
            InstallShortcut(shortcutPath)
            Return True
        End If
        Return False
    End Function

    Private Sub InstallShortcut(shortcutPath As String)

        ' Find the path to the current executable
        Dim exePath As String = Process.GetCurrentProcess().MainModule.FileName
        Dim newShortcut As IShellLinkW = CType(New CShellLink(), IShellLinkW)

        ' Create a shortcut to the exe
        ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetPath(exePath))
        ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetArguments(""))

        ' Open the shortcut property store, set the AppUserModelId property
        Dim newShortcutProperties As IPropertyStore = CType(newShortcut, IPropertyStore)

        'Dim appId As PropVariant = New PropVariant(APP_ID)
        'With appId
        '    ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.SetValue(SystemProperties.System.AppUserModel.ID, appId))
        '    ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.Commit())
        'End With

        ' Commit the shortcut to disk
        Dim newShortcutSave As IPersistFile = CType(newShortcut, IPersistFile)

        ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutSave.Save(shortcutPath, True))
    End Sub
End Module

Namespace ShellHelpers

    Enum STGM As Long

        STGM_READ ' = 0x00000000L

        STGM_WRITE

        '0x00000001L

        STGM_READWRITE

        '0x00000002L

        STGM_SHARE_DENY_NONE

        '0x00000040L

        STGM_SHARE_DENY_READ

        '0x00000030L

        STGM_SHARE_DENY_WRITE

        '0x00000020L

        STGM_SHARE_EXCLUSIVE

        '0x00000010L

        STGM_PRIORITY

        '0x00040000L

        STGM_CREATE

        '0x00001000L

        STGM_CONVERT

        '0x00020000L

        STGM_FAILIFTHERE

        ' 0x00000000L

        STGM_DIRECT

        '0x00000000L

        STGM_TRANSACTED

        '0x00010000L

        STGM_NOSCRATCH

        '0x00100000L

        STGM_NOSNAPSHOT

        '0x00200000L

        STGM_SIMPLE

        '0x08000000L

        STGM_DIRECT_SWMR

        '0x00400000L

        STGM_DELETEONRELEASE

        '0x04000000L
    End Enum

    Class ShellIIDGuid

        Friend Const IShellLinkW As String = "000214F9-0000-0000-C000-000000000046"

        Friend Const CShellLink As String = "00021401-0000-0000-C000-000000000046"

        Friend Const IPersistFile As String = "0000010b-0000-0000-C000-000000000046"

        Friend Const IPropertyStore As String = "886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99"
    End Class

    <ComImport(), _
     Guid(ShellIIDGuid.IShellLinkW), _
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Interface IShellLinkW

        Function GetPath(ByVal pszFile As StringBuilder, ByVal cchMaxPath As Integer, ByVal pfd As IntPtr, ByVal fFlags As UInteger) As UInt32

        Function GetIDList(ByRef ppidl As IntPtr) As UInt32

        Function SetIDList(ByVal pidl As IntPtr) As UInt32

        Function GetDescription(ByVal pszFile As StringBuilder, ByVal cchMaxName As Integer) As UInt32

        Function SetDescription(ByVal pszName As String) As UInt32

        Function GetWorkingDirectory(ByVal pszDir As StringBuilder, ByVal cchMaxPath As Integer) As UInt32

        Function SetWorkingDirectory(ByVal pszDir As String) As UInt32

        Function GetArguments(ByVal pszArgs As StringBuilder, ByVal cchMaxPath As Integer) As UInt32

        Function SetArguments(ByVal pszArgs As String) As UInt32

        Function GetHotKey(ByRef wHotKey As Short) As UInt32

        Function SetHotKey(ByVal wHotKey As Short) As UInt32

        Function GetShowCmd(ByRef iShowCmd As UInteger) As UInt32

        Function SetShowCmd(ByVal iShowCmd As UInteger) As UInt32

        Function GetIconLocation(ByRef pszIconPath As StringBuilder, ByVal cchIconPath As Integer, ByRef iIcon As Integer) As UInt32

        Function SetIconLocation(ByVal pszIconPath As String, ByVal iIcon As Integer) As UInt32

        Function SetRelativePath(ByVal pszPathRel As String, ByVal dwReserved As UInteger) As UInt32

        Function Resolve(ByVal hwnd As IntPtr, ByVal fFlags As UInteger) As UInt32

        Function SetPath(ByVal pszFile As String) As UInt32
    End Interface

    <ComImport(), _
     Guid(ShellIIDGuid.IPersistFile), _
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Interface IPersistFile

        Function GetCurFile(ByVal pszFile As StringBuilder) As UInt32

        Function IsDirty() As UInt32

        Function Load(ByVal pszFileName As String, ByVal dwMode As STGM) As UInt32

        Function Save(ByVal pszFileName As String, ByVal fRemember As Boolean) As UInt32

        Function SaveCompleted(ByVal pszFileName As String) As UInt32
    End Interface

    <ComImport(), _
     Guid(ShellIIDGuid.IPropertyStore), _
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Interface IPropertyStore

        Function GetCount(ByRef propertyCount As UInteger) As UInt32

        Function GetAt(ByVal propertyIndex As UInteger, ByRef key As PropertyKey) As UInt32

        Function GetValue(ByRef key As PropertyKey, ByVal pv As PropVariant) As UInt32

        Function SetValue(ByRef key As PropertyKey, ByVal pv As PropVariant) As UInt32

        Function Commit() As UInt32
    End Interface

    <ComImport(), _
     Guid(ShellIIDGuid.CShellLink), _
     ClassInterface(ClassInterfaceType.None)> _
    Class CShellLink
    End Class

    Public Class ErrorHelper

        Public Shared Sub VerifySucceeded(ByVal hresult As UInt32)
            If (hresult > 1) Then
                Throw New Exception(("Failed with HRESULT: " + hresult.ToString("X")))
            End If
        End Sub
    End Class
End Namespace