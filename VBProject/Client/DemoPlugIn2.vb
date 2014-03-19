Public Class DemoPlugIn2
    Implements [Interface].MHKPlugIn

    Public Sub Run(ByVal Environment As [Interface].MHKEnvironment) Implements [Interface].MHKPlugIn.Run
        MsgBox("PlugIn 2 würde laufen")
    End Sub

    Public ReadOnly Property Name As String Implements [Interface].MHKPlugIn.Name
        Get
            Return "DemoPlugIn 2"
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements [Interface].MHKPlugIn.Icon
        Get
            Return New System.Drawing.Bitmap(40, 40)
        End Get
    End Property

    Public ReadOnly Property NeedsKeyReleaseTime As Boolean Implements [Interface].MHKPlugIn.needsKeyReleaseTime
        Get
            Return False
        End Get
    End Property

    Public Property HotKey As System.Windows.Forms.Keys Implements [Interface].MHKPlugIn.HotKey
        Get
            Return My.Settings.Demo2HotKey
        End Get
        Set(value As System.Windows.Forms.Keys)
            My.Settings.Demo2HotKey = value
        End Set
    End Property

    Public Sub Reset() Implements [Interface].MHKPlugIn.ResetKotKey
        My.Settings.Demo2HotKey = Windows.Forms.Keys.Control Or Windows.Forms.Keys.Alt Or Windows.Forms.Keys.Shift Or Windows.Forms.Keys.S
    End Sub
End Class
