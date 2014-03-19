Imports System.Windows.Forms

Public Class Mute
    Implements [Interface].MHKPlugIn

    Public Sub Run(ByVal Environment As [Interface].MHKEnvironment) Implements [Interface].MHKPlugIn.Run
        'Threading.Thread.Sleep(CInt(My.Settings.HKDelay))
        Call keybd_event(CByte(System.Windows.Forms.Keys.VolumeMute), 0, KEYEVENTF_KEYDOWN, 0)
        Call keybd_event(CByte(System.Windows.Forms.Keys.VolumeMute), 0, KEYEVENTF_KEYUP, 0)
    End Sub

    Public ReadOnly Property Name As String Implements [Interface].MHKPlugIn.Name
        Get
            Return "Mute"
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements [Interface].MHKPlugIn.Icon
        Get
            Return My.Resources.Mute
        End Get
    End Property

    Public ReadOnly Property NeedsKeyReleaseTime As Boolean Implements [Interface].MHKPlugIn.needsKeyReleaseTime
        Get
            Return True
        End Get
    End Property

    Public Property HotKey As Keys Implements [Interface].MHKPlugIn.HotKey
        Get
            Return My.Settings.MuteHK
        End Get
        Set(value As Keys)
            My.Settings.MuteHK = value
        End Set
    End Property

    Public Sub Reset() Implements [Interface].MHKPlugIn.ResetKotKey
        My.Settings.MuteHK = Keys.Down Or Keys.Shift Or Keys.Control
    End Sub
End Class
