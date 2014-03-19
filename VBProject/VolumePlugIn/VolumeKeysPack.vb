Public Class VolumeKeysPack
    Implements [Interface].MHKPlugInPack

    Public Sub Config() Implements [Interface].MHKPlugInPack.Config
        'Dim cnfgDialog As ConfigurationDialog = New ConfigurationDialog()
        'cnfgDialog.ShowDialog()
        'cnfgDialog.Dispose()
        Throw New ArgumentException("Nothing to configure")
    End Sub

    Public Sub Dispose() Implements [Interface].MHKPlugInPack.Dispose

    End Sub

    Public ReadOnly Property Icon As Drawing.Image Implements [Interface].MHKPlugInPack.Icon
        Get
            Return My.Resources.VolUp
        End Get
    End Property

    Public Sub Initialize(ByVal Environment As [Interface].MHKEnvironment) Implements [Interface].MHKPlugInPack.Initialize

    End Sub

    Public ReadOnly Property IsConfigureable As Boolean Implements [Interface].MHKPlugInPack.IsConfigureable
        Get
            Return False 'True
        End Get
    End Property

    Public ReadOnly Property Name As String Implements [Interface].MHKPlugInPack.Name
        Get
            Return "Volume Pack"
        End Get
    End Property

    Public ReadOnly Property PlugIns As List(Of [Interface].MHKPlugIn) Implements [Interface].MHKPlugInPack.PlugIns
        Get
            Return New List(Of [Interface].MHKPlugIn)({New VolUp(), New VolDown(), New Mute()})
        End Get
    End Property

    Public Sub ResetSettings() Implements [Interface].MHKPlugInPack.ResetSettings
        My.Settings.Reset()
    End Sub

    Public Sub SaveSettings() Implements [Interface].MHKPlugInPack.SaveSettings
        My.Settings.Save()
    End Sub

End Class
