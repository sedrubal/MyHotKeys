'hier müssen alle öffentlichen members aufgeführt werden, welche die schnittstelle transportieren soll.
Public Interface MHKPlugIn

    ''' <summary>
    ''' Code, that should be executed, when the HotKey is pressed
    ''' </summary>
    Sub Run(ByVal MyHotKeysMainClass As MHKEnvironment)

    ''' <summary>
    ''' The Name of the PlugIn (Is shown also in ContextMenu)
    ''' </summary>
    ReadOnly Property Name() As String

    ''' <summary>
    ''' The Icon (as Image) for the PlugIn. You can also say: Return Nothing
    ''' </summary>
    ReadOnly Property Icon() As System.Drawing.Image

    ''' <summary>
    ''' The default HotKey value for the plugin's action.
    ''' </summary>
    Property HotKey As System.Windows.Forms.Keys

    ''' <summary>
    ''' Wenn das PlugIn z.B. einen Tastendruck simuliert, dann müssen alle Tasten losgelassen werden. Dazu kann hier true zurückgegeben werden, dass mit der Ausführung kurz gewartet wird
    ''' </summary>
    ReadOnly Property needsKeyReleaseTime As Boolean

    ' ''' <summary>
    ' ''' The Parent pack of this plugin
    ' ''' </summary>
    'ReadOnly Property ParentPack As MHKPlugInPack

    ''' <summary>
    ''' Reset the HotKey
    ''' </summary>
    Sub ResetKotKey()

End Interface