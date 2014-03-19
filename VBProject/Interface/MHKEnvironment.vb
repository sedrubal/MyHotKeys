Imports System.Windows.Forms

Public Interface MHKEnvironment
    Inherits IDisposable

    ReadOnly Property MySettingsDialog As System.Windows.Forms.Form

    Property Active() As Boolean

    Sub ShowMessage(ByVal Header As Object, Optional ByVal Content1 As Object = "", _
                                    Optional ByVal ResultButtons As String() = Nothing, Optional ByVal ResultActions As Action() = Nothing, _
                                    Optional ByVal BackColor As Drawing.Color = Nothing)

    Sub ShowToast(ByVal Header As String, ByVal Content1 As Object, Optional ByVal Content2 As Object = "", Optional ByVal LargeImage As System.Drawing.Image = Nothing, _
                                Optional ByVal AppLogo As System.Drawing.Image = Nothing, Optional ByVal Duration As Integer = 7000, Optional ByVal BackColor As Drawing.Color = Nothing, _
                                Optional ByVal ActionBoxClick As Action = Nothing, _
                                Optional ByVal Sound As String = "Default", Optional ByVal BoldHeader As Boolean = True)

    Sub ShowMusicInfoBox(ByVal Content1 As Object, Optional ByVal Content2 As Object = "", Optional ByVal LargeImage As System.Drawing.Image = Nothing, _
                                    Optional ByVal ActionPrevious As Action = Nothing, Optional ByVal ActionPlay As Action = Nothing, Optional ByVal ActionPause As Action = Nothing, _
                                    Optional ByVal ActionNext As Action = Nothing, Optional ByVal ActionBoxClick As Action = Nothing, _
                                    Optional ByVal DelegateGetVolume As Func(Of Integer) = Nothing, Optional ByVal DelegateSetVolume As Action(Of Integer) = Nothing, _
                                    Optional ByVal isPlaying As Boolean = True, Optional ByVal Duration As Integer = 2000, Optional ByVal BackColor As Drawing.Color = Nothing)

#Region "Fehlerbehandlung"

    Sub ShowError(ByVal Header As String, Optional ByVal Info As String = Nothing)

#End Region

#Region "Klasse"

    Sub UpdateCMS(Optional ByVal Active As Boolean = Nothing)

    Sub ClearCMS()

#End Region

#Region "Deklarationen d. Steuerelemente"
    Property NotifyIcon As NotifyIcon
#End Region

#Region "Globale Tastaturabfrage"

    ReadOnly Property PlugInDictionary As Dictionary(Of Keys, [Interface].MHKPlugIn)

    Sub BuildDictionary()

    Sub RegisterHotkeys(Optional ByVal SupressErrors As Boolean = False)

    Function CheckDoubleHKs() As String

    Sub UnRegisterHotkeys(Optional ByVal SupressErrors As Boolean = False)

    Sub RegUnregHotKey(HotKey As Keys, Register As Boolean, Optional ByVal SupressErrors As Boolean = False)

    Sub RegUnregPlugInHKs(ByVal Register As Boolean, Optional ByVal SupressErrors As Boolean = False)

#End Region

#Region "PlugIns"

    Sub InitializePlugins()

    Sub DisposePlugIns()

    ReadOnly Property AllPlugInPacks() As List(Of [Interface].MHKPlugInPack)

    ReadOnly Property AllPlugIns() As List(Of [Interface].MHKPlugIn)

    Sub ReloadPlugIns()

#End Region

End Interface
