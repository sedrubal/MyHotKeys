Public Class DemoPlugIn
    Implements [Interface].MHKPlugIn

    Public Sub Run(ByVal Environment As [Interface].MHKEnvironment) Implements [Interface].MHKPlugIn.Run
        MsgBox("Der Code von DemoPlugIn1 würde hier ausgeführt werden...")
    End Sub

    Public ReadOnly Property Name As String Implements [Interface].MHKPlugIn.Name
        Get
            Return "Demo Plugin"
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
            Return My.Settings.DemoHotKey
        End Get
        Set(value As System.Windows.Forms.Keys)
            My.Settings.DemoHotKey = value
        End Set
    End Property

    Public Sub Reset() Implements [Interface].MHKPlugIn.ResetKotKey
        My.Settings.DemoHotKey = Windows.Forms.Keys.Control Or Windows.Forms.Keys.Alt Or Windows.Forms.Keys.Shift Or Windows.Forms.Keys.D
    End Sub
End Class
