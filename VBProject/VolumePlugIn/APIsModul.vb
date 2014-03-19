Imports System.Runtime.InteropServices

Module APIsModul

#Region "Volume"
    Friend Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Friend Const KEYEVENTF_KEYDOWN As Integer = 0
    Friend Const KEYEVENTF_KEYUP As Integer = 2
#End Region

End Module
