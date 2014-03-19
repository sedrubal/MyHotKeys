Imports System.Runtime.InteropServices

Module APIsModul

#Region "MediaKeys senden"
    <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Unicode, EntryPoint:="keybd_event", ExactSpelling:=True, SetLastError:=True)> _
    Public Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, _
     ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    End Sub

    Friend Const Key_NONE As Integer = &H0
    Friend Const VK_MEDIA_PLAY_PAUSE As Byte = &HB3  'PlayPause
    Friend Const VK_MEDIA_STOP = &HB2   ' Stop
    Friend Const VK_MEDIA_NEXT_TRACK = &HB0   'Next
    Friend Const VK_MEDIA_Prev_TRACK = &HB1   'prev
#End Region

End Module
