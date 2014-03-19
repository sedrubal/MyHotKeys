Public Interface MHKPlugInPack

    ''' <summary>
    ''' Code, that should be executed, when MyHotKeys is loading this PluginPack
    ''' </summary>
    Sub Initialize(ByVal Environment As [Interface].MHKEnvironment)

    ''' <summary>
    ''' The Name of the PlugInPack (Is shown also in ContextMenu)
    ''' </summary>
    ReadOnly Property Name() As String

    ''' <summary>
    ''' The Icon (as Image) for the PlugInPack. You can also say: Return Nothing
    ''' </summary>
    ReadOnly Property Icon() As System.Drawing.Image

    ''' <summary>
    ''' All single PlugIns belonging to this pack
    ''' </summary>
    ReadOnly Property PlugIns() As List(Of MHKPlugIn)

    ''' <summary>
    ''' If you want, that the user can configurate your plugin, return true
    ''' </summary>
    ReadOnly Property IsConfigureable As Boolean

    ''' <summary>
    ''' The action that be executed, when the user want to configurate your plugin. You can show a form as dialog or as a form... BUT don't set the HotKey: this is managed by the program
    ''' </summary>
    Sub Config()

    ''' <summary>
    ''' Reset all Settings.
    ''' </summary>
    Sub ResetSettings()

    ''' <summary>
    ''' Save all Settings
    ''' </summary>
    Sub SaveSettings()

    ''' <summary>
    ''' Code, that should be executed, when MyHotKeys is closing
    ''' </summary>
    Sub Dispose()

End Interface