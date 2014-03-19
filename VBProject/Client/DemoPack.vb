Public Class DemoPack
    Implements [Interface].MHKPlugInPack

    Public Sub Initialize(ByVal Environment As [Interface].MHKEnvironment) Implements [Interface].MHKPlugInPack.Initialize
    End Sub

    Public ReadOnly Property Name As String Implements [Interface].MHKPlugInPack.Name
        Get
            Return "Demo Plugin"
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements [Interface].MHKPlugInPack.Icon
        Get
            Return New System.Drawing.Bitmap(40, 40)
        End Get
    End Property

    Public ReadOnly Property PlugIns As List(Of [Interface].MHKPlugIn) Implements [Interface].MHKPlugInPack.PlugIns
        Get
            Return New List(Of [Interface].MHKPlugIn)({New DemoPlugIn, New DemoPlugIn2})
        End Get
    End Property

    Public ReadOnly Property IsConfigurable As Boolean Implements [Interface].MHKPlugInPack.IsConfigureable
        Get
            Return True
        End Get
    End Property

    Public Sub Config() Implements [Interface].MHKPlugInPack.Config
        MsgBox("Hier können Sie einen Dialog zum Bearbeiten bestimmter Eigenschaften (nicht HotKey) öffnen")
    End Sub

    Public Sub ResetSettings() Implements [Interface].MHKPlugInPack.ResetSettings
        My.Settings.Reset()
    End Sub

    Public Sub SaveSettings() Implements [Interface].MHKPlugInPack.SaveSettings
        My.Settings.Save()
    End Sub

    Public Sub Dispose() Implements [Interface].MHKPlugInPack.Dispose
    End Sub
End Class