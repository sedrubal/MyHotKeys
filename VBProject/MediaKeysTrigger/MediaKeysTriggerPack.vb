Public Class MediaKeysTriggerPack
    Implements [Interface].MHKPlugInPack

    Public Sub Initialize(ByVal Environment As [Interface].MHKEnvironment) Implements [Interface].MHKPlugInPack.Initialize
    End Sub

    Public ReadOnly Property Name As String Implements [Interface].MHKPlugInPack.Name
        Get
            Return "MediaKeysTrigger"
        End Get
    End Property

    Public ReadOnly Property Icon As System.Drawing.Image Implements [Interface].MHKPlugInPack.Icon
        Get
            Return My.Resources.Metro_Note_klein
        End Get
    End Property

    Public ReadOnly Property PlugIns As List(Of [Interface].MHKPlugIn) Implements [Interface].MHKPlugInPack.PlugIns
        Get
            Return New List(Of [Interface].MHKPlugIn)({New PlayPause(), New _Stop(), New Previous(), New _Next()})
        End Get
    End Property

    Public ReadOnly Property IsConfigurable As Boolean Implements [Interface].MHKPlugInPack.IsConfigureable
        Get
            Return False ' True
        End Get
    End Property

    Public Sub Config() Implements [Interface].MHKPlugInPack.Config
        'Dim cnfgDialog As ConfigurationDialog = New ConfigurationDialog()
        'cnfgDialog.ShowDialog()
        'cnfgDialog.Dispose()
        Throw New ArgumentException("Nothing to configure")
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
