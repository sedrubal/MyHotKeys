Imports System.Windows.Forms

Public Class VolDown
    Implements [Interface].MHKPlugIn

    Public Sub Run(ByVal Environment As [Interface].MHKEnvironment) Implements [Interface].MHKPlugIn.Run
        'Threading.Thread.Sleep(CInt(My.Settings.HKDelay))
        Call keybd_event(CByte(System.Windows.Forms.Keys.VolumeDown), 0, KEYEVENTF_KEYDOWN, 0)  ' Taste runter
        Call keybd_event(CByte(System.Windows.Forms.Keys.VolumeDown), 0, KEYEVENTF_KEYUP, 0)    ' Taste rauf
    End Sub

    Public ReadOnly Property Name As String Implements [Interface].MHKPlugIn.Name
        Get
            Return "Volume -"
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements [Interface].MHKPlugIn.Icon
        Get
            Return My.Resources.VolDown
        End Get
    End Property

    Public ReadOnly Property NeedsKeyReleaseTime As Boolean Implements [Interface].MHKPlugIn.needsKeyReleaseTime
        Get
            Return True
        End Get
    End Property

    Public Property HotKey As System.Windows.Forms.Keys Implements [Interface].MHKPlugIn.HotKey
        Get
            Return My.Settings.VolDownHK
        End Get
        Set(value As System.Windows.Forms.Keys)
            My.Settings.VolDownHK = value
        End Set
    End Property

    Public Sub Reset() Implements [Interface].MHKPlugIn.ResetKotKey
        My.Settings.VolDownHK = Keys.Down Or Keys.Shift Or Keys.Control
    End Sub
End Class
