Public Class SettingsDialog

    Private Main As MainClass
    ''' <summary>
    ''' Gibt an, ob das Prog fertig geladen ist
    ''' </summary>
    Friend Loaded As Boolean

#Region "Load"
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main = New MainClass(Me) : My.Application.SaveMySettingsOnExit = True
        Me.VersionLBL.Text = "Version: " & My.Application.Info.Version.ToString
        Me.Loaded = True
    End Sub
    Private Sub SettingsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim mes As String = Main.CheckDoubleHKs()
        If String.IsNullOrWhiteSpace(mes) Then
            Me.Hide()
        Else
            MainClass.ShowMessageStatic("Folgende HotKeys wurden doppelt belegt. Bitte legen Sie neue HotKeys fest.", mes)
        End If
        Me.Opacity = 1 : Me.ShowInTaskbar = True
    End Sub

    Private Sub SettingsDialog_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            Me.UpdateMe()
        Else
            Me.AddProgrammesToExceptionList()
        End If

        For Each pack As [Interface].MHKPlugInPack In Main.AllPlugInPacks
            pack.SaveSettings()
        Next
        Me.Main.Active = Not Me.Visible
        Me.Main.ActiveToolStripMenuItem.Enabled = Not Me.Visible
    End Sub

    Private Sub LoadSettings()
        'With My.Settings
        '    Me.PPKeysTB.Text = .PlayPause.ToString() : Me.StKeysTB.Text = ._Stop.ToString() : Me.LTKeysTB.Text = .Prev.ToString()
        '    Me.NTKeysTB.Text = ._Next.ToString() : Me.VUKeysTB.Text = .VolUp.ToString() : Me.VDKeysTB.Text = .VolDown.ToString()
        '    Me.MuKeysTB.Text = .Mute.ToString()

        '    Me.PPCB.Image = New Bitmap(InvertColors(My.Resources.PlayPause), 50, 20)
        '    Me.StCB.Image = New Bitmap(InvertColors(My.Resources._Stop), 20, 20)
        '    Me.LTCB.Image = New Bitmap(InvertColors(My.Resources.Previous), 20, 20)
        '    Me.NTCB.Image = New Bitmap(InvertColors(My.Resources._Next), 20, 20)
        '    Me.VDCB.Image = New Bitmap(InvertColors(My.Resources.VolUp), 20, 20)
        '    Me.VUCB.Image = New Bitmap(InvertColors(My.Resources.VolDown), 20, 20)
        '    Me.MuCB.Image = New Bitmap(InvertColors(My.Resources.Mute), 20, 20)
        'End With
        AutostartCB.Checked = IsAutostart()
    End Sub

    Private Sub UpdateMe()
        Me.LoadSettings() : Me.DisplayPlugIns() : Me.UpdateExceptedApps()
    End Sub
#End Region

    'Public Function InvertColors(ByVal Image As Image) As Image
    '    'Dim ImgAttr As New Imaging.ImageAttributes()

    '    ''Standard-ColorMatrix für Invertierung
    '    'Dim ColorMatrix As New Imaging.ColorMatrix(New Single()() {
    '    '        New Single() {-1, 0, 0, 0, 0},
    '    '        New Single() {0, -1, 0, 0, 0},
    '    '        New Single() {0, 0, -1, 0, 0},
    '    '        New Single() {0, 0, 0, 1, 0},
    '    '        New Single() {1, 1, 1, 0, 1}
    '    '    })

    '    ''ColorMatrix an ImageAttribute-Objekt übergeben
    '    'ImgAttr.SetColorMatrix(ColorMatrix)

    '    ''Neue 32bit Bitmap erstellen
    '    'Dim NewBitmap = New Bitmap(Image.Width, Image.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)

    '    ''Resolution (DPI) vom Quellbitmap auf Zielbitmap übertragen
    '    'NewBitmap.SetResolution(Image.HorizontalResolution, Image.VerticalResolution)

    '    ''Graphicsobjekt von NewBitmap erstellen
    '    'Dim NewGraphics As Graphics = Graphics.FromImage(NewBitmap)

    '    ''NewBitmap auf NewGraphics zeichnen
    '    'NewGraphics.DrawImage(Image, New Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, ImgAttr)

    '    ''Ressource freigeben
    '    'NewGraphics.Dispose()
    '    'ImgAttr.Dispose()
    '    'Return NewBitmap
    '    Return Image 'Unnötig ;)
    'End Function

#Region "Beenden"

    Friend Sub HideMe()
        Dim mes As String = Main.CheckDoubleHKs()
        If Not String.IsNullOrWhiteSpace(mes) Then
            MainClass.ShowMessageStatic("Folgende HotKeys wurden doppelt belegt:", mes)
            'MsgBox("Folgende HotKeys wurden doppelt belegt:" + Environment.NewLine + mes, MsgBoxStyle.Critical, "MyHotKeys - Doppelbelegung der HotKeys")
        Else
            Me.Hide()
        End If
    End Sub

    Private Sub ExitBTN_ButtonClicked(sender As Object, e As EventArgs) Handles ExitBTN.ButtonClicked, SchließenToolStripMenuItem.Click
        Me.HideMe()
    End Sub

    Private Sub ProgrammBeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgrammBeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    'Private Sub SettingsDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    If e.CloseReason = CloseReason.FormOwnerClosing Then
    '        Dim Res As MsgBoxResult = MsgBox("Wollen Sie das Programm wirklich beenden [ja] oder minimieren [nein]?", MsgBoxStyle.YesNoCancel, "MyHotKeys - Schließen")
    '        If Res = MsgBoxResult.Yes Then
    '            Exit Sub
    '        ElseIf Res = MsgBoxResult.No Then
    '            e.Cancel = True
    '            Me.HideMe()
    '        ElseIf Res = MsgBoxResult.Cancel Then
    '            e.Cancel = True
    '        End If
    '    End If
    'End Sub
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'Const WM_NCLBUTTONDOWN As Integer = &HA1
        'Const HTCLOSE As Integer = &H14
        'Const WM_QUERYENDSESSION As Integer = &H11  ' Session soll beendet werden
        'Const WM_ENDSESSION As Integer = &H16       ' Session wird beendet
        'Const WM_CLOSE As Integer = &H10            ' Code oder Taskmanager oder MDI-Parent
        Const WM_SYSCOMMAND As Integer = &H112      ' WM_SYSCOMMAND+SC_CLOSE ->
        Const SC_CLOSE As Integer = &HF060          '   -> vbFormControlMenu

        If m.Msg = WM_SYSCOMMAND Then
            If m.WParam.ToInt32 = SC_CLOSE Then
                'X -Button
                'If m.Msg = WM_NCLBUTTONDOWN And m.Msg = HTCLOSE Then
                MainClass.ShowMessageStatic("Wollen Sie das Programm wirklich beenden?", , {"Beenden", "Minimieren", "Abbrechen"}, {AddressOf Me.Close, AddressOf Me.HideMe})
                'Dim Res As MsgBoxResult = MsgBox("Wollen Sie das Programm wirklich beenden [ja] oder minimieren [nein]?", MsgBoxStyle.YesNoCancel, "MyHotKeys - Schließen")
                'If Res = MsgBoxResult.Yes Then
                '    MyBase.WndProc(m)
                'ElseIf Res = MsgBoxResult.No Then
                '    Me.HideMe()
                'ElseIf Res = MsgBoxResult.Cancel Then
                'End If
            Else
                MyBase.WndProc(m)
            End If
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Private Sub SettingsDialog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Main.Dispose() 'Main.Close()
    End Sub

#End Region

#Region "Buttons"
    Private Sub ResetBTN_Click(sender As Object, e As EventArgs) Handles ResetBTN.Click
        'Main.UnRegisterHotkeys()
        Dim oldPath As String = My.Settings.PlugInPath 'GetAbsolutePath(My.Settings.PlugInPath)
        My.Settings.Reset() : My.Settings.Reload()
        For Each pack As [Interface].MHKPlugInPack In Me.Main.AllPlugInPacks
            pack.ResetSettings()
        Next
        'With My.Settings
        '    TPP = .PlayPause : TSt = ._Stop : TPr = .Prev : TNe = ._Next : TVD = .VolDown : TVU = .VolUp : TMu = .Mute
        'End With
        If Not oldPath = My.Settings.PlugInPath Then 'GetAbsolutePath(My.Settings.PlugInPath) Then
            MainClass.ShowMessageStatic("Sie haben den Pfad geändert, in dem die PlugIns gespeichert sind.", "Wollen Sie die PlugIns aus dem neuen Ordner neu laden?", {"Yes", "No"}, {AddressOf Me.ReloadPlugIns})
        End If
        Me.UpdateMe()
    End Sub
#End Region

    '#Region "Texteingabe"
    '    Private TPP As Keys = My.Settings.PlayPause, TSt As Keys = My.Settings._Stop, TPr As Keys = My.Settings.Prev, TNe As Keys = My.Settings._Next
    '    Private TVU As Keys = My.Settings.VolUp, TVD As Keys = My.Settings.VolDown, TMu As Keys = My.Settings.Mute

    '    Private Sub PlayPauseTB_KeyDown(sender As Object, e As KeyEventArgs)
    '        TPP = e.KeyData : PPKeysTB.Text = e.KeyData.ToString
    '    End Sub

    '    Private Sub StopTB_KeyDown(sender As Object, e As KeyEventArgs)
    '        TSt = e.KeyData : StKeysTB.Text = e.KeyData.ToString
    '    End Sub

    '    Private Sub PrevTB_KeyDown(sender As Object, e As KeyEventArgs)
    '        TPr = e.KeyData : LTKeysTB.Text = e.KeyData.ToString
    '    End Sub

    '    Private Sub NextTB_KeyDown(sender As Object, e As KeyEventArgs)
    '        TNe = e.KeyData : NTKeysTB.Text = e.KeyData.ToString
    '    End Sub

    '    Private Sub VolUpTB_KeyDown(sender As Object, e As KeyEventArgs)
    '        TVU = e.KeyData : VUKeysTB.Text = e.KeyData.ToString
    '    End Sub

    '    Private Sub VolDownTB_KeyDown(sender As Object, e As KeyEventArgs)
    '        TVD = e.KeyData : VDKeysTB.Text = e.KeyData.ToString
    '    End Sub

    '    Private Sub MuteTB_KeyDown(sender As Object, e As KeyEventArgs)
    '        TMu = e.KeyData : MuKeysTB.Text = e.KeyData.ToString
    '    End Sub
    '#End Region

    '#Region "HK aktivieren / Deaktivieren"
    '    Private Sub VULBL_CheckedChanged(sender As Object, e As EventArgs)
    '        If Loaded Then Main.RegUnregHotKey(My.Settings.VolUp, VUCB.Checked)
    '    End Sub

    '    Private Sub NTLBL_CheckedChanged(sender As Object, e As EventArgs)
    '        If Loaded Then Main.RegUnregHotKey(My.Settings._Next, NTCB.Checked)
    '    End Sub

    '    Private Sub StLBL_CheckedChanged(sender As Object, e As EventArgs)
    '        If Loaded Then Main.RegUnregHotKey(My.Settings._Stop, StCB.Checked)
    '    End Sub

    '    Private Sub MuLBL_CheckedChanged(sender As Object, e As EventArgs)
    '        If Loaded Then Main.RegUnregHotKey(My.Settings.Mute, MuCB.Checked)
    '    End Sub

    '    Private Sub VDLBL_CheckedChanged(sender As Object, e As EventArgs)
    '        If Loaded Then Main.RegUnregHotKey(My.Settings.VolDown, VDCB.Checked)
    '    End Sub

    '    Private Sub LTLBL_CheckedChanged(sender As Object, e As EventArgs)
    '        If Loaded Then Main.RegUnregHotKey(My.Settings.Prev, LTCB.Checked)
    '    End Sub

    '    Private Sub PPLBL_CheckedChanged(sender As Object, e As EventArgs)
    '        If Loaded Then Main.RegUnregHotKey(My.Settings.PlayPause, PPCB.Checked)
    '    End Sub
    '#End Region

#Region "Autostart"
    Private Sub AutostartCB_CheckedChanged(sender As Object, e As EventArgs) Handles AutostartCB.CheckedChanged, SoundCB.CheckedChanged
        Autostart(AutostartCB.Checked)
    End Sub
    'Rest im Autostarthandler
#End Region

#Region "Email"
    Private Sub ContactLLBL_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles ContactLLBL.LinkClicked
        Try
            AddMailParam("", "subject=" & "MyHotKeys")
            'E-Mail-Programm mit "Neue Nachricht" öffnen
            Process.Start("mailto: " & ContactLLBL.Text)
        Catch ex As Exception
            My.Computer.Clipboard.SetText(ContactLLBL.Text)
            MainClass.ShowMessageStatic(ex.Message & ".", "Das e-Mail-Programm konnte nicht geöffnet werden. Der Link wurde in die Zwischenablage kopiert.")
            'MsgBox(ex.Message & ". Das e-Mail-Programm konnte nicht geöffnet werden. Der Link wurde in die Zwischenablage kopiert.")
        End Try
    End Sub
    'Hilfsfunktion: EMail-Parameter zusammenstellen
    Private Sub AddMailParam(ByRef sAllParam As String, ByVal sParam As String)
        If sAllParam = String.Empty Then
            sAllParam = "?" & sParam
        Else
            sAllParam &= "&" & sParam
        End If
    End Sub
#End Region

#Region "PlugIns"

    Private Sub SetPlugInFolderBTN_Click(sender As Object, e As EventArgs) Handles SetPlugInFolderBTN.Click
        Dim FBD As New FolderBrowserDialog()
        FBD.Description = "Legen Sie den Ordner fest, in dem nach Plugins gesucht werden soll."
        FBD.SelectedPath = My.Settings.PlugInPath 'GetAbsolutePath(My.Settings.PlugInPath)
        FBD.ShowNewFolderButton = True
        If FBD.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            If Not My.Settings.PlugInPath = FBD.SelectedPath Then 'GetAbsolutePath(My.Settings.PlugInPath) = FBD.SelectedPath Then 'GetAbsolutePath(FBD.SelectedPath) Then
                My.Settings.PlugInPath = FBD.SelectedPath 'GetRelativePath(FBD.SelectedPath)
                MainClass.ShowMessageStatic("Sie haben den Pfad geändert, in dem die PlugIns gespeichert sind.", "Wollen Sie die PlugIns aus dem neuen Ordner neu laden?", {"Yes", "No"}, {AddressOf Me.ReloadPlugIns})
                'If MsgBox("Sie müssen die Anwendung neu starten, um die Änderungen wirksam zu machen. Wollen Sie die Anwendung BEENDEN?", MsgBoxStyle.YesNo, "MyHotKeys - PlugIn Einstellungen") = MsgBoxResult.Yes Then
                '    Me.Close()
                'End If
            End If
        End If
    End Sub

    Private Sub OpenPlugInFolderBTN_Click(sender As Object, e As EventArgs) Handles OpenPlugInFolderBTN.Click
        Dim p As New ProcessStartInfo
        p.Arguments = "/e," & My.Settings.PlugInPath 'GetAbsolutePath(My.Settings.PlugInPath) & ""
        p.FileName = "explorer.exe"
        Process.Start(p)
    End Sub

    Private Sub DisplayPlugIns()
        Dim SelectedIndex As Integer = -1
        If Me.PlugInLV.SelectedItems.Count = 1 Then
            SelectedIndex = Me.PlugInLV.Items.IndexOf(Me.PlugInLV.SelectedItems(0))
        End If
        Me.PlugInLV.Items.Clear()
        Try
            For Each pack As [Interface].MHKPlugInPack In Main.AllPlugInPacks
                Try
                    Dim PackGroup As ListViewGroup = New ListViewGroup(pack.Name, pack.Name)
                    Me.PlugInLV.Groups.Add(PackGroup)
                    For Each plugin As [Interface].MHKPlugIn In pack.PlugIns

                        Dim LVItem As New ListViewItem(plugin.Name)
                        LVItem.SubItems.Add(plugin.HotKey.ToString())
                        LVItem.Group = PackGroup

                        Me.PlugInIL.Images.Add(plugin.Icon)
                        LVItem.ImageIndex = Me.PlugInLV.LargeImageList.Images.Count - 1
                        Me.PlugInLV.Items.Add(LVItem)
                    Next
                Catch ex As Exception
                    MainClass.ShowMessageStatic("Unbekannter Fehler beim Auflisten der Plugins", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                        vbCrLf & ex.Message)
                End Try
            Next
        Catch ex As Exception
            MainClass.ShowMessageStatic("Unbekannter Fehler beim Auflisten der PluginPacks.", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                vbCrLf & ex.Message)
        End Try
        If Me.PlugInLV.Items.Count > SelectedIndex And Not SelectedIndex < 0 Then
            Me.PlugInLV.Items(SelectedIndex).Selected = True
        End If
    End Sub

    Private Sub ConfigSelectedPlugIn(sender As Object, e As EventArgs) Handles ConfigPlugInBTN.Click, PlugInLV.MouseDoubleClick
        Try
            If (Me.PlugInLV.SelectedItems.Count = 1) Then
                Dim parentpack As [Interface].MHKPlugInPack = GetParentPack(Main.AllPlugIns((Me.PlugInLV.Items.IndexOf(Me.PlugInLV.SelectedItems(0)))))
                If Not IsNothing(parentpack) Then
                    If parentpack.IsConfigureable Then
                        parentpack.Config()
                        Me.DisplayPlugIns()
                        'CheckEnabledBTNS()
                    End If
                End If
            End If

            'If Not Me.PlugInLV.SelectedItems(0) Is Nothing Then
            '    For Each pack As [Interface].MHKPlugInPack In Main.GetPlugInPacks
            '        For Each plugin As [Interface].MHKPlugIn In pack.PlugIns
            '            If plugin.Name = Me.PlugInLV.SelectedItems(0).Text Then
            '                If pack.IsConfigureable Then
            '                    pack.Config()
            '                    Me.DisplayPlugIns()
            '                    LoadedPlugInsLB_SelectedIndexChanged()
            '                End If
            '                Exit Sub
            '            End If
            '        Next
            '    Next
            'End If
        Catch ex As Exception
            MainClass.ShowMessageStatic("Unbekannter Fehler beim Konfigurieren des Plugins.", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub resetPlugInHKBTN_Click(sender As Object, e As EventArgs) Handles resetPlugInHKBTN.Click
        Try
            If Me.PlugInLV.SelectedItems.Count = 1 Then
                With Main.AllPlugIns(Me.PlugInLV.Items.IndexOf(Me.PlugInLV.SelectedItems(0)))
                    'If Main.Active Then Main.RegUnregHotKey(.HotKey, False)
                    .ResetKotKey()
                    'If Main.Active Then Main.RegUnregHotKey(.HotKey, True)
                End With
            End If
            Me.DisplayPlugIns()
            Main.BuildDictionary()
        Catch ex As Exception
            MainClass.ShowMessageStatic("Unbekannter Fehler beim Zurücksetzen des Hotkeys für ein Plugin.", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                vbCrLf & ex.Message)
        End Try
        CheckEnabledBTNS()
    End Sub

    Private TPHK As Keys
    Private Sub CheckEnabledBTNS() Handles PlugInLV.SelectedIndexChanged
        resetPlugInHKBTN.Enabled = (Me.PlugInLV.SelectedItems.Count = 1) : PlugInHKTB.Enabled = resetPlugInHKBTN.Enabled
        Try
            If (Me.PlugInLV.SelectedItems.Count = 1) Then
                With Main.AllPlugIns((Me.PlugInLV.Items.IndexOf(Me.PlugInLV.SelectedItems(0))))
                    TPHK = .HotKey : PlugInHKTB.Text = .HotKey.ToString
                    ApplyPlugInBTN.Enabled = PlugInHKTB.Text <> .HotKey.ToString()
                    Dim parentpack As [Interface].MHKPlugInPack = GetParentPack(Main.AllPlugIns((Me.PlugInLV.Items.IndexOf(Me.PlugInLV.SelectedItems(0)))))
                    If Not IsNothing(parentpack) Then
                        Me.ConfigPlugInBTN.Enabled = parentpack.IsConfigureable
                    End If
                End With
            Else
                ApplyPlugInBTN.Enabled = False
            End If
        Catch ex As Exception
            MainClass.ShowMessageStatic("Unbekannter Fehler beim Laden des Hotkeys für ein Plugin.", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
       vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub PlugInHKTB_TextChanged(sender As Object, e As EventArgs) Handles PlugInHKTB.TextChanged
        Try
            If (Me.PlugInLV.SelectedItems.Count = 1) Then
                With Main.AllPlugIns((Me.PlugInLV.Items.IndexOf(Me.PlugInLV.SelectedItems(0))))
                    ApplyPlugInBTN.Enabled = PlugInHKTB.Text <> .HotKey.ToString()
                End With
            Else
                ApplyPlugInBTN.Enabled = False
            End If
        Catch ex As Exception
            MainClass.ShowMessageStatic("Unbekannter Fehler beim Laden des Hotkeys für ein Plugin.", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ApplyPlugInBTN_Click(sender As Object, e As EventArgs) Handles ApplyPlugInBTN.Click
        Try
            If (Me.PlugInLV.Items.IndexOf(Me.PlugInLV.SelectedItems(0))) >= 0 Then
                With Main.AllPlugIns((Me.PlugInLV.Items.IndexOf(Me.PlugInLV.SelectedItems(0))))
                    'If Main.Active Then Main.RegUnregHotKey(.HotKey, False)
                    .HotKey = TPHK
                    'If Main.Active Then Main.RegUnregHotKey(.HotKey, True)
                End With
            End If
            Me.DisplayPlugIns()
            'Main.BuildDictionary()
        Catch ex As Exception
            MainClass.ShowMessageStatic("Unbekannter Fehler beim Festlegen des Hotkeys für ein Plugin.", "Bitte kontaktieren sie den Entwickler und melden Sie das Problem. Weitere Informationen:" & _
                vbCrLf & ex.Message)
        End Try
        CheckEnabledBTNS()
    End Sub

    Private Sub PlugInHKTB_KeyDown(sender As Object, e As KeyEventArgs) Handles PlugInHKTB.KeyDown
        TPHK = e.KeyData : PlugInHKTB.Text = e.KeyData.ToString
    End Sub

    Private Function GetParentPack(ByVal FindPlugIn As [Interface].MHKPlugIn) As [Interface].MHKPlugInPack
        For Each pack As [Interface].MHKPlugInPack In Main.AllPlugInPacks
            For Each plugin As [Interface].MHKPlugIn In pack.PlugIns
                If plugin.Name = FindPlugIn.Name Then
                    Return pack
                End If
            Next
        Next
        Return Nothing
    End Function

    Private Sub ReloadPlugInsBTN_Click(sender As Object, e As EventArgs) Handles ReloadPlugInsBTN.Click
        Me.ReloadPlugIns()
    End Sub

    Private Sub DisposePlugInBTN_Click(sender As Object, e As EventArgs) Handles DisposePlugInBTN.Click
        Me.DisposePlugIns()
    End Sub

    Friend Sub ReloadPlugIns()
        Main.ReloadPlugIns()
        Me.DisplayPlugIns()
    End Sub

    Friend Sub DisposePlugIns()
        Main.DisposePlugIns()
        Me.DisplayPlugIns()
    End Sub

#End Region

#Region "Ausnahmen"
    Private Sub UpdateExceptedApps()
        Me.ExceptionLB.Items.Clear()
        For Each App As String In My.Settings.ExceptedApps
            Me.ExceptionLB.Items.Add(App)
        Next
    End Sub

    Private Sub AddExceptionFromTB() Handles AddExceptionBTN.Click
        If Not My.Settings.ExceptedApps.Contains(Me.AddExceptionTB.Text) And Not String.IsNullOrWhiteSpace(Me.AddExceptionTB.Text) Then
            Dim nApp As String = Me.AddExceptionTB.Text.ToLower()
            nApp = nApp.Replace(".exe", "")
            My.Settings.ExceptedApps.Add(nApp)
            Me.AddExceptionTB.Text = String.Empty
        End If
        UpdateExceptedApps()
    End Sub

    Private Sub RemoveExceptionBTN_Click(sender As Object, e As EventArgs) Handles RemoveExceptionBTN.Click
        If Not Me.ExceptionLB.SelectedItem Is Nothing Then My.Settings.ExceptedApps.Remove(Me.ExceptionLB.SelectedItem.ToString)
        UpdateExceptedApps()
        ExceptionLB_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub ExceptionLB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ExceptionLB.SelectedIndexChanged, ExceptionLB.Leave, ExceptionLB.Enter
        If Not Me.ExceptionLB.Focused And Not Me.RemoveExceptionBTN.Focused Then Me.ExceptionLB.SelectedItem = Nothing
        Me.RemoveExceptionBTN.Enabled = (Not ExceptionLB.SelectedItem Is Nothing) And (ExceptionLB.Focused Or Me.RemoveExceptionBTN.Focused) And Not Me.ExceptionLB.Items.Count = 0
    End Sub

    Private Sub AddExceptionTB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AddExceptionTB.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddExceptionFromTB()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub AddExceptionTB_TextChanged(sender As Object, e As EventArgs) Handles AddExceptionTB.TextChanged
        Me.AddExceptionBTN.Enabled = (Not String.IsNullOrWhiteSpace(AddExceptionTB.Text))
    End Sub

    Private Sub AddProgrammesToExceptionList()
        For Each app As String In MainClass.GetAllProcesses()
            If Not Me.AddExceptionTB.AutoCompleteCustomSource.Contains(app) Then
                Me.AddExceptionTB.AutoCompleteCustomSource.Add(app)
            End If
        Next
    End Sub
#End Region

    '#Region "Fenster bewegen"
    '    Dim mouseOffset As Point

    '    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Panel1.MouseDown
    '        mouseOffset = New Point(-e.X, -e.Y - Me.Height)
    '    End Sub

    '    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Panel1.MouseMove
    '        If e.Button = MouseButtons.Left Then
    '            Dim mousePos = Control.MousePosition
    '            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
    '            Location = mousePos
    '        End If
    '    End Sub
    '#End Region

    'Private Sub MessageTest(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDoubleClick
    '    MainClass.ShowMessageStatic("Message-Test at: " & Now.ToString, ToolTipIcon.Info)
    '    MsgBox(Now.ToString, , "Message-Test")
    'End Sub
End Class