Option Strict Off
Imports System.IO

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Controls
Imports Windows.UI.Notifications
Imports Windows.Data.Xml.Dom

Public Class MainClass
    'Implements System.IDisposable
    Implements [Interface].MHKEnvironment

    Private _mySettingsDialog As System.Windows.Forms.Form
    ReadOnly Property MySettingsDialog As System.Windows.Forms.Form Implements [Interface].MHKEnvironment.MySettingsDialog
        Get
            Return Me._mySettingsDialog
        End Get
    End Property

    Private _active As Boolean
    Public Property Active() As Boolean Implements [Interface].MHKEnvironment.Active
        Get
            Return _active
        End Get
        Set(ByVal value As Boolean)
            If value <> _active Then
                If value Then
                    Dim mes As String = Me.CheckDoubleHKs()
                    If Not String.IsNullOrWhiteSpace(mes) Then
                        ShowMessage("Folgende HotKeys wurden doppelt belegt. Bitte legen Sie neue HotKeys fest.", mes)
                        MySettingsDialog.Show()
                    Else
                        Me.RegisterHotkeys(True)
                    End If
                Else
                    Me.UnRegisterHotkeys(True)
                End If
                _active = value
            End If
            Me.ActiveToolStripMenuItem.Checked = value
        End Set
    End Property

#Region "Meldungen"

    Public Sub ShowMessage(ByVal Header As Object, Optional ByVal Content1 As Object = "", _
                                    Optional ByVal ResultButtons As String() = Nothing, Optional ByVal ResultActions As Action() = Nothing, _
                                    Optional ByVal BackColor As Drawing.Color = Nothing) Implements [Interface].MHKEnvironment.ShowMessage
        SECore.Win8Design.Win8MessageBox.ShowMessage(Header, Content1, ResultButtons, ResultActions, BackColor)
    End Sub
    Public Shared Sub ShowMessageStatic(ByVal Header As Object, Optional ByVal Content1 As Object = "", _
                                Optional ByVal ResultButtons As String() = Nothing, Optional ByVal ResultActions As Action() = Nothing, _
                                Optional ByVal BackColor As Drawing.Color = Nothing)
        SECore.Win8Design.Win8MessageBox.ShowMessage(Header, Content1, ResultButtons, ResultActions, BackColor)
    End Sub

    Public Sub ShowToast(ByVal Header As String, ByVal Content1 As Object, Optional ByVal Content2 As Object = "", Optional ByVal LargeImage As System.Drawing.Image = Nothing, _
                                Optional ByVal AppLogo As System.Drawing.Image = Nothing, Optional ByVal Duration As Integer = 7000, Optional ByVal BackColor As Drawing.Color = Nothing, _
                                Optional ByVal ActionBoxClick As Action = Nothing, _
                                Optional ByVal Sound As String = "Default", Optional ByVal BoldHeader As Boolean = True) Implements [Interface].MHKEnvironment.ShowToast
        'SECore.Win8Design.Win8ToastNotification.ShowToast(Header, Content1, Content2, LargeImage, AppLogo, Duration, BackColor, ActionBoxClick, Sound, BoldHeader)








        'HACK ToDo: AppID von anderen, alles in DLL oder in SE Core Software Foo EXE, ... http://msdn.microsoft.com/de-de/library/windows/apps/hh761494.aspx
        'HACK ToDo: http://msdn.microsoft.com/de-de/library/windows/apps/hh868254.aspx

        Dim toastXml As XmlDocument = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04)
        Dim stringElements As XmlNodeList = toastXml.GetElementsByTagName("text")
        Dim i As Integer = 0
        'Do While (i < stringElements.Length)
        '    stringElements(i).AppendChild(toastXml.CreateTextNode(("Line " & i)))
        '    i = (i + 1)
        'Loop
        stringElements(0).AppendChild(toastXml.CreateTextNode(Header))
        If TypeOf Content1 Is String Then stringElements(1).AppendChild(toastXml.CreateTextNode(CStr(Content1)))
        If TypeOf Content2 Is String Then stringElements(2).AppendChild(toastXml.CreateTextNode(CStr(Content2)))

        Dim toastNode As IXmlNode = toastXml.SelectSingleNode("/toast")
        Dim audio As XmlElement = toastXml.CreateElement("audio")
        toastNode.AppendChild(audio)

        'CType(toastNode, XmlElement).SetAttribute("duration", "long")

        'audio.SetAttribute("src", "ms-winsoundevent:Notification.Looping.Alarm")
        'audio.SetAttribute("loop", "true")

        audio.SetAttribute("silent", "true")

        'audio.SetAttribute("src", "ms-winsoundevent:Notification.IM")

        'Dim imagePath As String = ("file:///" & Path.GetFullPath("toastImageAndText.png"))
        'Dim imageElements As XmlNodeList = toastXml.GetElementsByTagName("image")
        'imageElements(0).Attributes.GetNamedItem("src").NodeValue = imagePath
        Dim toast As ToastNotification = New ToastNotification(toastXml)
        'toast.Activated += ToastActivated()
        'toast.Dismissed = (toast.Dismissed + ToastDismissed)
        'toast.Failed = (toast.Failed + ToastFailed)
        ' Show the toast. Be sure to specify the AppUserModelId on your application's shortcut!
        ToastNotificationManager.CreateToastNotifier(APP_ID).Show(toast)
    End Sub
    
    Public Sub ShowMusicInfoBox(ByVal Content1 As Object, Optional ByVal Content2 As Object = "", Optional ByVal LargeImage As System.Drawing.Image = Nothing, _
                                    Optional ByVal ActionPrevious As Action = Nothing, Optional ByVal ActionPlay As Action = Nothing, Optional ByVal ActionPause As Action = Nothing, _
                                    Optional ByVal ActionNext As Action = Nothing, Optional ByVal ActionBoxClick As Action = Nothing, _
                                    Optional ByVal DelegateGetVolume As Func(Of Integer) = Nothing, Optional ByVal DelegateSetVolume As Action(Of Integer) = Nothing, _
                                    Optional ByVal isPlaying As Boolean = True, Optional ByVal Duration As Integer = 2000, Optional ByVal BackColor As Drawing.Color = Nothing) Implements [Interface].MHKEnvironment.ShowMusicInfoBox
        SECore.Win8Design.Win8MusicInfo.ShowMusicInfo(Content1, Content2, LargeImage, ActionPrevious, ActionPlay, ActionPause, ActionNext, ActionBoxClick, DelegateGetVolume, DelegateSetVolume, isPlaying, Duration, BackColor)
    End Sub

#Region "Fehlerbehandlung"
    Friend Sub ShowError(ByVal Header As String, Optional ByVal Info As String = Nothing) Implements [Interface].MHKEnvironment.ShowError
        largeErrorDescriptionHeader = Header
        largeErrorDescription = Info
        Me.ShowToast(largeErrorDescriptionHeader, largeErrorDescription, , , SettingsDialog.Icon.ToBitmap(), , Color.DarkSeaGreen, AddressOf ShowlargeErrorDescription, "Error")
    End Sub

    Private Shared largeErrorDescription As String, largeErrorDescriptionHeader As String
    Private Sub ShowlargeErrorDescription()
        If Not String.IsNullOrWhiteSpace(largeErrorDescription) And Not String.IsNullOrWhiteSpace(largeErrorDescriptionHeader) Then
            ShowMessage(largeErrorDescriptionHeader, largeErrorDescription, {"Kopieren", "Schließen"}, {AddressOf CopyLargeErrorDescription}, Color.DarkSeaGreen)
        End If
    End Sub
    Private Shared Sub CopyLargeErrorDescription()
        If Not String.IsNullOrWhiteSpace(largeErrorDescription) Then My.Computer.Clipboard.SetText(largeErrorDescription) Else If Not String.IsNullOrWhiteSpace(largeErrorDescriptionHeader) Then My.Computer.Clipboard.SetText(largeErrorDescriptionHeader)
    End Sub

#End Region

#End Region

#Region "Klasse"

    Public Sub New(YourSettingsDialog As System.Windows.Forms.Form)

        WindowsMessageHelpers.TryCreateShortcut()

        Me._mySettingsDialog = YourSettingsDialog

        InitializeComponents()

        Me.InitializePlugIns()
        'Dim mes As String = Me.CheckDoubleHKs()
        'If Not String.IsNullOrWhiteSpace(mes) Then
        '    ShowMessage("Folgende HotKeys wurden doppelt belegt. Bitte legen Sie neue HotKeys fest.", mes)
        '    MySettingsDialog.Show()
        'Else
        '    RegUnregPlugInHKs(True, True) : BuildDictionary() 'wird gemacht, wenn AktiveTSMI gechecked wird, aber nicht PlugIns, da die noch nicht geladen sind, drum Fehler unterdrücken
        'End If

        Me.NotifyIcon.ShowBalloonTip(7000, "MyHotKeys", "Willkommen", ToolTipIcon.Info)
    End Sub

    Private Sub InitializeComponents()
        Me.ContextMenuStrip1 = New ContextMenuStrip() : Me.ToolStripSeparator1 = New ToolStripSeparator()
        Me.BeendenToolStripMenuItem = New ToolStripMenuItem() : Me.EinstellungenToolStripMenuItem = New ToolStripMenuItem()
        Me.NotifyIcon = New NotifyIcon()
        Me.ActiveToolStripMenuItem = New ToolStripMenuItem()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EinstellungenToolStripMenuItem, Me.ActiveToolStripMenuItem, Me.ToolStripSeparator1, Me.BeendenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(167, 160)
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.Image = Global.MyHotKeys.My.Resources.Resources.Options
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.EinstellungenToolStripMenuItem.Font = New Font(Me.EinstellungenToolStripMenuItem.Font, Drawing.FontStyle.Bold)
        Me.EinstellungenToolStripMenuItem.Text = "Einstellungen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(163, 6)
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Image = Global.MyHotKeys.My.Resources.Resources._Exit
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.BeendenToolStripMenuItem.Text = "Beenden"
        '
        'AktiveToolStripMenuItem
        '
        Me.ActiveToolStripMenuItem.Name = "AktiveToolStripMenuItem"
        Me.ActiveToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.ActiveToolStripMenuItem.Text = "Aktiv"
        Me.ActiveToolStripMenuItem.CheckOnClick = True
        'Me.ActiveToolStripMenuItem.Checked = True
        '
        'NotifyIcon
        '
        NotifyIcon = New NotifyIcon()
        NotifyIcon.ContextMenuStrip = ContextMenuStrip1
        NotifyIcon.Icon = MySettingsDialog.Icon
        NotifyIcon.Text = "MyHotKeys"
        NotifyIcon.Visible = True

        'Me.UpdateCMS()
    End Sub

    Private Sub UpdateCMS(Optional ByVal ShowShortCuts As Boolean = Nothing) Implements [Interface].MHKEnvironment.UpdateCMS
        With My.Settings
            '---Plugins---
            For Each pluginpack As [Interface].MHKPlugInPack In _allpluginpacks
                Try
                    Dim pluginpackToolStripItem As ToolStripMenuItem = CType(Me.ContextMenuStrip1.Items.Find(pluginpack.Name & "ToolStripMenuItem", True)(0), ToolStripMenuItem)
                    For Each plugin As [Interface].MHKPlugIn In pluginpack.PlugIns
                        Dim plugInTSMI As ToolStripMenuItem = CType(pluginpackToolStripItem.DropDownItems.Find(plugin.Name & "ToolStripMenuItem", True)(0), ToolStripMenuItem)
                        If IsNothing(ShowShortCuts) Then ShowShortCuts = Me.Active
                        If ShowShortCuts Then
                            plugInTSMI.ShortcutKeyDisplayString = plugin.HotKey.ToString()
                        Else
                            plugInTSMI.ShortcutKeyDisplayString = ""
                        End If
                    Next
                Catch ex As Exception
                    ShowError("Fehler beim Anzeigen der HotKeys des PluginPacks '" & pluginpack.Name, ex.Message)
                    'ShowError("Fehler beim Anzeigen der HotKeys des PluginPacks '" & pluginpack.Name & "':" & vbCrLf & ex.Message)
                End Try
            Next
            '-------------
        End With

    End Sub

    Private Sub CleanCMS() Implements [Interface].MHKEnvironment.ClearCMS
        ' HACK todo
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Me.DisposePlugIns()
        Me.NotifyIcon.Visible = False : Me.NotifyIcon.Dispose()
    End Sub

#End Region

#Region "Deklarationen d. Steuerelemente"
    Friend WithEvents _notifyIcon As NotifyIcon

    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend Property NotifyIcon() As NotifyIcon Implements [Interface].MHKEnvironment.NotifyIcon
        Get
            Return _notifyIcon
        End Get
        Set(ByVal value As NotifyIcon)
            _notifyIcon = value
        End Set
    End Property

    Private WithEvents EinstellungenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
#End Region

#Region "Events"

    Private Sub NotifyIcon_Click(sender As Object, e As MouseEventArgs) Handles _notifyIcon.MouseClick
        If e.Button = MouseButtons.Left Then
            MySettingsDialog.Show()
        End If
    End Sub

#Region "ContextMenuStrip"
    Private Sub OnShowSettings(sender As System.Object, ByVal e As System.EventArgs) Handles EinstellungenToolStripMenuItem.Click
        Me.Active = False
        Me.ActiveToolStripMenuItem.Enabled = False
        MySettingsDialog.Show()
    End Sub

    Private Sub OnAktivCheckedChange(sender As System.Object, ByVal e As System.EventArgs) Handles ActiveToolStripMenuItem.CheckedChanged
        Active = ActiveToolStripMenuItem.Checked
    End Sub

    Private Sub OnExitApp(sender As System.Object, ByVal e As System.EventArgs) Handles BeendenToolStripMenuItem.Click
        MySettingsDialog.Close()
    End Sub
#End Region
#End Region

#Region "Globale Tastaturabfrage"

    Private WithEvents HK As HotKeys = New HotKeys()

    Private _plugInDictionary As New Dictionary(Of Keys, [Interface].MHKPlugIn)
    Friend ReadOnly Property PlugInDictionary As Dictionary(Of Keys, [Interface].MHKPlugIn) Implements [Interface].MHKEnvironment.PlugInDictionary
        Get
            Return Me._plugInDictionary
        End Get
    End Property

    Private Sub _Hotkeys_Pressed(ByVal sender As Object, ByVal e As HotKeys.PressedEventArgs) Handles HK.Pressed
        'If Not MySettingsDialog.Visible Then
        If Not ExceptedApp() And ActiveToolStripMenuItem.Checked Then
            If (My.Settings.Sounds) Then Console.Beep()
            With PlugInDictionary(e.Key)
                Try
                    If .needsKeyReleaseTime Then
                        System.Threading.Thread.Sleep(My.Settings.HKDelay)
                    End If
                    .Run(Me)
                Catch ex As Exception
                    ShowError("Fehler beim Ausführen des PlugIns '", "blabla") '& .Name, ex.Message)
                    'ShowError("Fehler beim Ausführen des PlugIns '" & .Name & "' : " & vbCrLf & ex.Message)
                End Try
            End With
            If (My.Settings.Sounds) Then Console.Beep()
        End If
        'Else
        'Console.Beep() : Console.Beep() : Console.Beep()
        'End If
    End Sub

    Friend Sub BuildDictionary() Implements [Interface].MHKEnvironment.BuildDictionary
        PlugInDictionary.Clear()
        '---Plugins---
        For Each pluginpack As [Interface].MHKPlugInPack In _allpluginpacks
            Try
                For Each plugin As [Interface].MHKPlugIn In pluginpack.PlugIns
                    Try
                        PlugInDictionary.Add(plugin.HotKey, plugin)
                    Catch ex As Exception
                        ShowError("Fehler beim Registrieren (ins Dictionary) des Plugins '" & pluginpack.Name, ex.Message)
                        'ShowError("Fehler beim Registrieren (ins Dictionary) des Plugins '" & pluginpack.Name & "': " & vbCrLf & ex.Message)
                    End Try
                Next
            Catch ex As Exception
                ShowError("Fehler beim Registrieren (ins Dictionary) des PluginPacks '" & pluginpack.Name, ex.Message)
                'ShowError("Fehler beim Registrieren (ins Dictionary) des PluginPacks '" & pluginpack.Name & "': " & vbCrLf & ex.Message)
            End Try
        Next
        '-------------
    End Sub

    Public Sub RegisterHotkeys(Optional ByVal SupressErrors As Boolean = False) Implements [Interface].MHKEnvironment.RegisterHotkeys
        Me.RegUnregPlugInHKs(True, SupressErrors)
        BuildDictionary()
        UpdateCMS(True)
    End Sub

    Public Function CheckDoubleHKs() As String Implements [Interface].MHKEnvironment.CheckDoubleHKs
        Dim messagelist As New List(Of String)()
        Dim pllist As List(Of [Interface].MHKPlugIn) = Me.AllPlugIns

        For i As Integer = 0 To pllist.Count - 2
            For j As Integer = i + 1 To pllist.Count - 1
                If (pllist(i).HotKey = pllist(j).HotKey) Then
                    messagelist.Add(pllist(i).Name + " und " + pllist(j).Name + ": " + pllist(i).HotKey.ToString())
                End If
            Next
        Next

        Dim message As String = ""
        For Each mes As String In messagelist
            message += mes + Environment.NewLine
        Next
        Return message
    End Function

    Public Sub UnRegisterHotkeys(Optional ByVal SupressErrors As Boolean = False) Implements [Interface].MHKEnvironment.UnRegisterHotkeys
        '    ''---Plugins---
        '    'If .UsePlugIns Then
        '    '    For Each plugin As [Interface].MHKPlugInInterface In myplugins
        '    '        Try
        '    '            Dim phk As Keys = plugin.HotKey()
        '    '            If Not phk = Keys.None Then
        '    '                If Not HK.TryUnRegister(phk) Then
        '    '                    If Not SupressErrors Then ShowError( "Der HotKey '" & plugin.HotKey & "' für das Plugin: '" & plugin.Name & "' konnte nicht degistriert werden.")
        '    '                End If
        '    '            End If
        '    '        Catch ex As Exception
        '    '            If Not SupressErrors Then ShowError( "Fehler beim Deregistrieren des Plugins '" & plugin.Name & "':" & vbCrLf & ex.Message)
        '    '            'MsgBox("Fehler beim Deregistrieren des Plugins '" & plugin.Name & "':" & vbCrLf & ex.Message)
        '    '        End Try
        '    '    Next
        '    'End If
        '    ''-------------
        Me.RegUnregPlugInHKs(False, SupressErrors)
        UpdateCMS(False)
    End Sub

    Public Sub RegUnregHotKey(HotKey As Keys, Register As Boolean, Optional ByVal SupressErrors As Boolean = False) Implements [Interface].MHKEnvironment.RegUnregHotKey
        If Register Then
            If Not HK.TryRegister(HotKey) Then ShowError("DerHotkey '" & HotKey & "' konnte nicht registriert werden. Bitte wählen Sie einen anderen.", "") ' ShowError("DerHotkey '" & HotKey & "' konnte nicht registriert werden. Bitte wählen Sie einen anderen.")
        Else
            If Not HK.TryUnRegister(HotKey) Then ShowError("DerHotkey '" & HotKey & "' konnte nicht deregistriert werden!", "") 'ShowError()
        End If
        UpdateCMS()
    End Sub

    Public Sub RegUnregPlugInHKs(ByVal Register As Boolean, Optional ByVal SupressErrors As Boolean = False) Implements [Interface].MHKEnvironment.RegUnregPlugInHKs
        'Dim errorless As Boolean = True
        With My.Settings
            For Each pluginpack As [Interface].MHKPlugInPack In _allpluginpacks
                Try
                    For Each plugin As [Interface].MHKPlugIn In pluginpack.PlugIns
                        Try
                            Dim phk As Keys = plugin.HotKey()
                            If Not phk = Keys.None Then
                                If Register Then
                                    If Not HK.TryRegister(phk) Then
                                        plugin.HotKey = Keys.None
                                        If Not SupressErrors Then ShowError("Der HotKey '" & plugin.HotKey & "' für das Plugin: '" & plugin.Name & "' konnte nicht registriert werden.") 'ShowError("Der HotKey '" & plugin.HotKey & "' für das Plugin: '" & plugin.Name & "' konnte nicht registriert werden.")
                                        'errorless = False
                                    End If
                                Else
                                    If Not HK.TryUnRegister(phk) Then
                                        If Not SupressErrors Then ShowError("Der HotKey '" & plugin.HotKey & "' für das Plugin: '" & plugin.Name & "' konnte nicht deregistriert werden.") ' ShowError("Der HotKey '" & plugin.HotKey & "' für das Plugin: '" & plugin.Name & "' konnte nicht degistriert werden.")
                                        'errorless = False
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            If Not SupressErrors Then ShowError("Fehler beim (De)registrieren des Plugins '" & plugin.Name, ex.Message) 'ShowError("Fehler beim (De)registrieren des Plugins '" & plugin.Name & "':" & vbCrLf & ex.Message)
                            'errorless = False
                        End Try
                    Next
                Catch ex As Exception
                    If Not SupressErrors Then ShowError("Fehler beim (De)registrieren des PluginPacks '" & pluginpack.Name, ex.Message) ' ShowError("Fehler beim (De)registrieren des PluginPacks '" & pluginpack.Name & "':" & vbCrLf & ex.Message)
                    'errorless = False
                End Try
            Next
        End With
        'If errorless And SettingsDialog.Loaded Then
        '    ShowError("Alle HotKeys wurden erfolgreich übernommen", ToolTipIcon.Info, 2000)
        'End If
    End Sub

#End Region

#Region "PlugIns"

    Private _allpluginpacks As New List(Of [Interface].MHKPlugInPack)
    Friend ReadOnly Property AllPlugInPacks() As List(Of [Interface].MHKPlugInPack) Implements [Interface].MHKEnvironment.AllPlugInPacks
        Get
            Return _allpluginpacks
        End Get
    End Property

    Friend Sub InitializePlugIns() Implements [Interface].MHKEnvironment.InitializePlugins
        Try
            'My.Settings.PlugInPath = GetRelativePath(My.Settings.PlugInPath)
            If My.Settings.PlugInPath.StartsWith("\") Then My.Settings.PlugInPath = My.Application.Info.DirectoryPath & My.Settings.PlugInPath
            Dim diOrdner As New System.IO.DirectoryInfo(My.Settings.PlugInPath) 'GetAbsolutePath(My.Settings.PlugInPath))
            If Not diOrdner.Exists Then diOrdner.Create()

            Try
                'alle plugins laden
                For Each pluginDLL As String In Directory.GetFiles(My.Settings.PlugInPath, "*.dll") 'GetAbsolutePath(My.Settings.PlugInPath), "*.dll")
                    Dim npluginpacks As List(Of [Interface].MHKPlugInPack) = New List(Of [Interface].MHKPlugInPack)()
                    Try
                        npluginpacks = PlugInConnector.LoadPlugIn(pluginDLL)
                    Catch ex As Exception
                        Dim name As String, namearr As String() = pluginDLL.Split("\"c)
                        If namearr.Length > 1 Then name = namearr(namearr.Length - 1) Else name = pluginDLL
                        ShowError(name, "Unbekannter Fehler beim Einbinden des PlugInPacks '" & name & "'. Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                            vbCrLf & ex.Message)
                    End Try


                    'Plugins initialisieren
                    For Each pluginpack As [Interface].MHKPlugInPack In npluginpacks
                        Try
                            pluginpack.Initialize(Me)
                        Catch ex As Exception
                            ShowError(pluginpack.Name, "Unbekannter Fehler beim Initialisieren des PluginPacks. Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                                vbCrLf & ex.Message)
                        End Try
                    Next

                    AddPlugInToContextMenu(npluginpacks)

                    _allpluginpacks.AddRange(npluginpacks)
                Next
                If _allpluginpacks.Count = 0 Then
                    ShowToast("MyHotKeys", "Kein gültiges PlugIn gefunden.", , , SettingsDialog.Icon.ToBitmap(), , Color.DarkSeaGreen, AddressOf Me.MySettingsDialog.Show, "None")
                End If

                'AddPlugInsToContextMenu()
            Catch ex As Exception
                ShowError("Unbekannter Fehler beim Laden der Plugins.", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                       vbCrLf & ex.Message)
            End Try
        Catch ex As System.UnauthorizedAccessException
            ShowError("Das Programm ist anscheinend nicht berechtigt, auf den PlugIn-Ordner zuzugreifen.", "Starten sie das Programm als Administrator, oder ändern oder erstellen Sie den Ordner")
        End Try
    End Sub

    Friend Sub DisposePlugIns() Implements [Interface].MHKEnvironment.DisposePlugIns
        If ActiveToolStripMenuItem.Checked Then UnRegisterHotkeys()
        For Each pluginPack As [Interface].MHKPlugInPack In _allpluginpacks
            Try
                pluginPack.SaveSettings()
                pluginPack.Dispose()
            Catch ex As Exception
                ShowError("Fehler beim Beenden der PlugIns", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & vbCrLf & ex.Message)
            End Try
        Next
        Me.AllPlugInPacks.Clear()
    End Sub

    'Private PlugInsTSMIs As New List(Of ToolStripItem)
    'Private Sub AddPlugInsToContextMenu()
    '    Dim TSS As New ToolStripSeparator() With {.Name = "PlugInsToolStripSeparator", .Size = New System.Drawing.Size(163, 6)}
    '    PlugInsTSMIs.Add(TSS)
    '    For Each plugin As [Interface].MHKPlugInInterface In myplugins
    '        Try
    '            Dim PTSMI As New ToolStripMenuItem()
    '            PTSMI.Image = plugin.Icon
    '            PTSMI.Name = plugin.Name & "ToolStripMenuItem"
    '            PTSMI.Size = New System.Drawing.Size(166, 24)
    '            PTSMI.Text = plugin.Name
    '            AddHandler PTSMI.Click, AddressOf RunTSMI
    '            PlugInsTSMIs.Add(PTSMI)
    '        Catch ex As Exception
    '            ShowError("Fehler beim Erweitern des Kontextmenüs um das Plugin: '" & plugin.Name & "':" & vbCrLf & ex.Message)
    '            'MsgBox("Fehler beim Erweitern des Kontextmenüs um das Plugin: '" & plugin.Name & "':" & vbCrLf & ex.Message)
    '        End Try
    '    Next
    '    Dim i As Integer = 8
    '    For Each TSI As ToolStripItem In PlugInsTSMIs
    '        Me.ContextMenuStrip1.Items.Insert(i, TSI)
    '        i += 1
    '    Next
    'End Sub
    Private Sub AddPlugInToContextMenu(npluginpacks As List(Of [Interface].MHKPlugInPack))
        If Not npluginpacks.Count = 0 Then
            Dim PlugInPacksTSMIs As New List(Of ToolStripItem)
            For Each pluginpack As [Interface].MHKPlugInPack In npluginpacks
                Try
                    Dim PackTSMI As New ToolStripMenuItem()
                    PackTSMI.Image = pluginpack.Icon
                    PackTSMI.Name = pluginpack.Name & "ToolStripMenuItem"
                    PackTSMI.Size = New System.Drawing.Size(166, 24)
                    PackTSMI.Text = pluginpack.Name
                    PlugInPacksTSMIs.Add(PackTSMI)

                    For Each plugin As [Interface].MHKPlugIn In pluginpack.PlugIns
                        Try
                            Dim PTSMI As New ToolStripMenuItem()
                            PTSMI.Image = plugin.Icon
                            PTSMI.Name = plugin.Name & "ToolStripMenuItem"
                            PTSMI.Size = New System.Drawing.Size(166, 24)
                            PTSMI.Text = plugin.Name
                            PTSMI.ShortcutKeyDisplayString = plugin.HotKey.ToString()
                            AddHandler PTSMI.Click, AddressOf RunTSMI
                            PackTSMI.DropDownItems.Add(PTSMI)
                        Catch ex As Exception
                            ShowError("Fehler beim Erweitern des Kontextmenüs um das Plugin: '" & plugin.Name, ex.Message)
                        End Try
                    Next
                Catch ex As Exception
                    ShowError("Fehler beim Erweitern des Kontextmenüs um das PluginPack: '" & pluginpack.Name, ex.Message)
                End Try
            Next
            'Dim TSS As New ToolStripSeparator() With {.Name = "PlugInsToolStripSeparator", .Size = New System.Drawing.Size(163, 6)}
            'PlugInPacksTSMIs.Add(TSS)
            Dim i As Integer = 0
            For Each TSI As ToolStripItem In PlugInPacksTSMIs
                Me.ContextMenuStrip1.Items.Insert(i, TSI)
                i += 1
            Next
        End If
    End Sub

    Friend ReadOnly Property AllPlugIns As List(Of [Interface].MHKPlugIn) Implements [Interface].MHKEnvironment.AllPlugIns
        Get
            Dim list As New List(Of [Interface].MHKPlugIn)
            For Each pack As [Interface].MHKPlugInPack In _allpluginpacks
                Try
                    list.AddRange(pack.PlugIns)
                Catch ex As Exception
                    ShowError("Ein unbekannter Fehler Erstellen einer Liste aller Plugins.", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                           vbCrLf & ex.Message)
                End Try
            Next
            Return list
        End Get
    End Property

    Friend Sub RunTSMI(ByVal sender As Object, ByVal e As EventArgs)
        Try
            For Each pack As [Interface].MHKPlugInPack In _allpluginpacks
                For Each plugin As [Interface].MHKPlugIn In pack.PlugIns
                    If CType(sender, ToolStripMenuItem).Name = plugin.Name & "ToolStripMenuItem" Then
                        plugin.Run(Me) : Exit Sub
                    End If
                Next
            Next
        Catch ex As Exception
            ShowError("Unbekannter Fehler beim Ausführen eines Plugins.", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                   vbCrLf & ex.Message)
        End Try
    End Sub

    Friend Sub ReloadPlugIns() Implements [Interface].MHKEnvironment.ReloadPlugIns
        Me.DisposePlugIns()
        Me.InitializePlugIns()
    End Sub

#End Region

#Region "Ausnahmen"
    ''' <summary>
    ''' Überprüft, ob ausgenommene Anwendung läuft
    ''' </summary>
    ''' <returns>True, wenn eine ausgenommene Anwendung läuft</returns>
    Private Function ExceptedApp() As Boolean
        'My.Settings.ExceptedApps.Add("explorer")
        For Each App As String In My.Settings.ExceptedApps
            If FindWindow(App) Then Return True : Exit Function
        Next
        Return False
    End Function

    Private Function FindWindow(Name As String) As Boolean
        For Each prStr As String In GetAllProcesses()
            If (prStr.ToLower = Name) Then Return True : Exit Function
        Next
        Return False
    End Function

    Friend Shared Function GetAllProcesses() As List(Of String)
        Dim processes As New List(Of String)
        For Each p As Process In Process.GetProcesses
            processes.Add(p.ProcessName.ToLower())
        Next
        Return processes
    End Function
#End Region

End Class