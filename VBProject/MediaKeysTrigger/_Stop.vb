Imports System.Windows.Forms

Public Class _Stop
    Implements [Interface].MHKPlugIn

    Public Sub Run(ByVal Environment As [Interface].MHKEnvironment) Implements [Interface].MHKPlugIn.Run
        'Threading.Thread.Sleep(CInt(My.Settings.HKDelay))
        Call keybd_event(VK_MEDIA_STOP, 0, 0, 0) 'Key down
        Call keybd_event(VK_MEDIA_STOP, 0, 2, 0)
    End Sub

    Public ReadOnly Property Name As String Implements [Interface].MHKPlugIn.Name
        Get
            Return "Wiedergabe Stop"
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements [Interface].MHKPlugIn.Icon
        Get
            Return My.Resources._Stop
        End Get
    End Property

    Public ReadOnly Property NeedsKeyReleaseTime As Boolean Implements [Interface].MHKPlugIn.needsKeyReleaseTime
        Get
            Return True
        End Get
    End Property

    Public Property HotKey As System.Windows.Forms.Keys Implements [Interface].MHKPlugIn.HotKey
        Get
            Return My.Settings._StopHK
        End Get
        Set(value As System.Windows.Forms.Keys)
            My.Settings._StopHK = value
        End Set
    End Property

    Public Sub Reset() Implements [Interface].MHKPlugIn.ResetKotKey
        My.Settings.PlayPauseHK = Keys.End Or Keys.Shift Or Keys.Control
    End Sub
End Class
