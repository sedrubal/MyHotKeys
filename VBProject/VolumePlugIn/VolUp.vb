Imports System.Windows.Forms

Public Class VolUp
    Implements [Interface].MHKPlugIn

    Public Sub Run(ByVal Environment As [Interface].MHKEnvironment) Implements [Interface].MHKPlugIn.Run
        'Threading.Thread.Sleep(CInt(My.Settings.HKDelay))
        Call keybd_event(CByte(System.Windows.Forms.Keys.VolumeUp), 0, KEYEVENTF_KEYDOWN, 0)
        Call keybd_event(CByte(System.Windows.Forms.Keys.VolumeUp), 0, KEYEVENTF_KEYUP, 0)
    End Sub

    Public ReadOnly Property Name As String Implements [Interface].MHKPlugIn.Name
        Get
            Return "Volume +"
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements [Interface].MHKPlugIn.Icon
        Get
            Return My.Resources.VolUp
        End Get
    End Property

    Public ReadOnly Property NeedsKeyReleaseTime As Boolean Implements [Interface].MHKPlugIn.needsKeyReleaseTime
        Get
            Return True
        End Get
    End Property

    Public Property HotKey As System.Windows.Forms.Keys Implements [Interface].MHKPlugIn.HotKey
        Get
            Return My.Settings.VolUpHK
        End Get
        Set(value As System.Windows.Forms.Keys)
            My.Settings.VolUpHK = value
        End Set
    End Property

    Public Sub Reset() Implements [Interface].MHKPlugIn.ResetKotKey
        My.Settings.VolUpHK = Keys.Up Or Keys.Shift Or Keys.Control
    End Sub
End Class
