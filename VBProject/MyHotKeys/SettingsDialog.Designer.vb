<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsDialog
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsDialog))
        Dim DropDownButtonRenderer1 As DropDownButtonLib.DropDownButtonRenderer = New DropDownButtonLib.DropDownButtonRenderer()
        Me.ProgSettingsGB = New System.Windows.Forms.GroupBox()
        Me.VersionLBL = New System.Windows.Forms.Label()
        Me.DelayNUD = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SoundCB = New System.Windows.Forms.CheckBox()
        Me.AutostartCB = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.MainToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PlugInsGB = New System.Windows.Forms.GroupBox()
        Me.PlugInLV = New System.Windows.Forms.ListView()
        Me.NameCH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HKCH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PlugInIL = New System.Windows.Forms.ImageList(Me.components)
        Me.PlugInHKTB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ApplyPlugInBTN = New System.Windows.Forms.Button()
        Me.ConfigPlugInBTN = New System.Windows.Forms.Button()
        Me.resetPlugInHKBTN = New System.Windows.Forms.Button()
        Me.DisposePlugInBTN = New System.Windows.Forms.Button()
        Me.ReloadPlugInsBTN = New System.Windows.Forms.Button()
        Me.OpenPlugInFolderBTN = New System.Windows.Forms.Button()
        Me.SetPlugInFolderBTN = New System.Windows.Forms.Button()
        Me.PlugInPathTB = New System.Windows.Forms.TextBox()
        Me.ContactLLBL = New System.Windows.Forms.LinkLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ResetBTN = New System.Windows.Forms.Button()
        Me.ExitBTN = New DropDownButtonLib.DropDownButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SchließenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgrammBeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.AddExceptionTB = New System.Windows.Forms.TextBox()
        Me.AddExceptionBTN = New System.Windows.Forms.Button()
        Me.RemoveExceptionBTN = New System.Windows.Forms.Button()
        Me.ExceptionLB = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgSettingsGB.SuspendLayout()
        CType(Me.DelayNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PlugInsGB.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgSettingsGB
        '
        Me.ProgSettingsGB.Controls.Add(Me.VersionLBL)
        Me.ProgSettingsGB.Controls.Add(Me.DelayNUD)
        Me.ProgSettingsGB.Controls.Add(Me.Label1)
        Me.ProgSettingsGB.Controls.Add(Me.SoundCB)
        Me.ProgSettingsGB.Controls.Add(Me.AutostartCB)
        Me.ProgSettingsGB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgSettingsGB.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgSettingsGB.Location = New System.Drawing.Point(422, 307)
        Me.ProgSettingsGB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProgSettingsGB.Name = "ProgSettingsGB"
        Me.ProgSettingsGB.Padding = New System.Windows.Forms.Padding(2)
        Me.ProgSettingsGB.Size = New System.Drawing.Size(410, 153)
        Me.ProgSettingsGB.TabIndex = 2
        Me.ProgSettingsGB.TabStop = False
        Me.ProgSettingsGB.Text = "Programm"
        '
        'VersionLBL
        '
        Me.VersionLBL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VersionLBL.AutoEllipsis = True
        Me.VersionLBL.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLBL.Location = New System.Drawing.Point(290, 26)
        Me.VersionLBL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.VersionLBL.Name = "VersionLBL"
        Me.VersionLBL.Size = New System.Drawing.Size(116, 20)
        Me.VersionLBL.TabIndex = 17
        Me.VersionLBL.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'DelayNUD
        '
        Me.DelayNUD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DelayNUD.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.MyHotKeys.My.MySettings.Default, "HKDelay", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DelayNUD.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.DelayNUD.Location = New System.Drawing.Point(195, 80)
        Me.DelayNUD.Margin = New System.Windows.Forms.Padding(2)
        Me.DelayNUD.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.DelayNUD.Name = "DelayNUD"
        Me.DelayNUD.Size = New System.Drawing.Size(52, 27)
        Me.DelayNUD.TabIndex = 16
        Me.DelayNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.DelayNUD.ThousandsSeparator = True
        Me.DelayNUD.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 82)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "&Verzögerungsdauer [ms]:"
        '
        'SoundCB
        '
        Me.SoundCB.AutoSize = True
        Me.SoundCB.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MyHotKeys.My.MySettings.Default, "Sounds", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SoundCB.Location = New System.Drawing.Point(8, 52)
        Me.SoundCB.Margin = New System.Windows.Forms.Padding(2)
        Me.SoundCB.Name = "SoundCB"
        Me.SoundCB.Size = New System.Drawing.Size(228, 24)
        Me.SoundCB.TabIndex = 15
        Me.SoundCB.Text = "&Töne bei Hotkey wiedergeben"
        Me.MainToolTip.SetToolTip(Me.SoundCB, "Aktivieren Sie dieses Kästchen, um Signaltöne zu erhalten," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wenn eine Aktion von " & _
        "MyHotKeys ausgeführt wird.")
        Me.SoundCB.UseVisualStyleBackColor = True
        '
        'AutostartCB
        '
        Me.AutostartCB.AutoSize = True
        Me.AutostartCB.Location = New System.Drawing.Point(8, 24)
        Me.AutostartCB.Margin = New System.Windows.Forms.Padding(2)
        Me.AutostartCB.Name = "AutostartCB"
        Me.AutostartCB.Size = New System.Drawing.Size(180, 24)
        Me.AutostartCB.TabIndex = 14
        Me.AutostartCB.Text = "&Autostart mit Windows"
        Me.AutostartCB.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoEllipsis = True
        Me.Label9.BackColor = System.Drawing.Color.LightCoral
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(426, 473)
        Me.Label9.Margin = New System.Windows.Forms.Padding(8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(402, 49)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "während dieses Fenster geöffnet ist, werden keine Hotkeys ausgeführt." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "HotKeys we" & _
    "rdenerst beim Schließen des Fensters registriert" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(bitte das Programm nicht been" & _
    "den)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MainToolTip.SetToolTip(Me.Label9, "Wenn Sie einen schon registrierten Hotkey eingeben, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wird Ihnen beim Schließen d" & _
        "es Fensters eine Warnmeldung egeben")
        '
        'MainToolTip
        '
        Me.MainToolTip.AutoPopDelay = 5000
        Me.MainToolTip.InitialDelay = 1000
        Me.MainToolTip.IsBalloon = True
        Me.MainToolTip.ReshowDelay = 100
        Me.MainToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.MainToolTip.ToolTipTitle = "MyHotKeys"
        '
        'PlugInsGB
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.PlugInsGB, 2)
        Me.PlugInsGB.Controls.Add(Me.PlugInLV)
        Me.PlugInsGB.Controls.Add(Me.PlugInHKTB)
        Me.PlugInsGB.Controls.Add(Me.Label2)
        Me.PlugInsGB.Controls.Add(Me.ApplyPlugInBTN)
        Me.PlugInsGB.Controls.Add(Me.ConfigPlugInBTN)
        Me.PlugInsGB.Controls.Add(Me.resetPlugInHKBTN)
        Me.PlugInsGB.Controls.Add(Me.DisposePlugInBTN)
        Me.PlugInsGB.Controls.Add(Me.ReloadPlugInsBTN)
        Me.PlugInsGB.Controls.Add(Me.OpenPlugInFolderBTN)
        Me.PlugInsGB.Controls.Add(Me.SetPlugInFolderBTN)
        Me.PlugInsGB.Controls.Add(Me.PlugInPathTB)
        Me.PlugInsGB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlugInsGB.Font = New System.Drawing.Font("Segoe UI", 10.8!)
        Me.PlugInsGB.Location = New System.Drawing.Point(4, 5)
        Me.PlugInsGB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PlugInsGB.Name = "PlugInsGB"
        Me.PlugInsGB.Padding = New System.Windows.Forms.Padding(2)
        Me.PlugInsGB.Size = New System.Drawing.Size(828, 292)
        Me.PlugInsGB.TabIndex = 43
        Me.PlugInsGB.TabStop = False
        Me.PlugInsGB.Text = "PlugIns"
        Me.MainToolTip.SetToolTip(Me.PlugInsGB, "PlugIn EInstellungen werden beim nächsten Programm-Start wirksam.")
        '
        'PlugInLV
        '
        Me.PlugInLV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlugInLV.CheckBoxes = True
        Me.PlugInLV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NameCH, Me.HKCH})
        Me.PlugInLV.FullRowSelect = True
        Me.PlugInLV.HideSelection = False
        Me.PlugInLV.LargeImageList = Me.PlugInIL
        Me.PlugInLV.Location = New System.Drawing.Point(8, 63)
        Me.PlugInLV.MultiSelect = False
        Me.PlugInLV.Name = "PlugInLV"
        Me.PlugInLV.ShowItemToolTips = True
        Me.PlugInLV.Size = New System.Drawing.Size(812, 194)
        Me.PlugInLV.SmallImageList = Me.PlugInIL
        Me.PlugInLV.TabIndex = 6
        Me.MainToolTip.SetToolTip(Me.PlugInLV, "Alle geladenen Plugins werden hier aufgeführt.")
        Me.PlugInLV.UseCompatibleStateImageBehavior = False
        Me.PlugInLV.View = System.Windows.Forms.View.Details
        '
        'NameCH
        '
        Me.NameCH.Text = "Name"
        Me.NameCH.Width = 400
        '
        'HKCH
        '
        Me.HKCH.Text = "HotKey"
        Me.HKCH.Width = 200
        '
        'PlugInIL
        '
        Me.PlugInIL.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.PlugInIL.ImageSize = New System.Drawing.Size(16, 16)
        Me.PlugInIL.TransparentColor = System.Drawing.Color.Transparent
        '
        'PlugInHKTB
        '
        Me.PlugInHKTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlugInHKTB.Enabled = False
        Me.PlugInHKTB.Location = New System.Drawing.Point(248, 262)
        Me.PlugInHKTB.Margin = New System.Windows.Forms.Padding(2)
        Me.PlugInHKTB.Name = "PlugInHKTB"
        Me.PlugInHKTB.ReadOnly = True
        Me.PlugInHKTB.Size = New System.Drawing.Size(193, 27)
        Me.PlugInHKTB.TabIndex = 5
        Me.MainToolTip.SetToolTip(Me.PlugInHKTB, resources.GetString("PlugInHKTB.ToolTip"))
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Pfad:"
        Me.MainToolTip.SetToolTip(Me.Label2, "Legen Sie den Ordner fest, in dem nach Plugins gesucht werden soll." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dort sollten" & _
        " sich möglichst keine weiteren Dateien befinden." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PlugIn EInstellungen werden be" & _
        "im nächsten Programm-Start wirksam.")
        '
        'ApplyPlugInBTN
        '
        Me.ApplyPlugInBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyPlugInBTN.Enabled = False
        Me.ApplyPlugInBTN.Location = New System.Drawing.Point(445, 261)
        Me.ApplyPlugInBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.ApplyPlugInBTN.Name = "ApplyPlugInBTN"
        Me.ApplyPlugInBTN.Size = New System.Drawing.Size(108, 27)
        Me.ApplyPlugInBTN.TabIndex = 2
        Me.ApplyPlugInBTN.Text = "&übernehmen"
        Me.MainToolTip.SetToolTip(Me.ApplyPlugInBTN, "HotKey für das PlugIn übernehmen und registrieren.")
        Me.ApplyPlugInBTN.UseVisualStyleBackColor = True
        '
        'ConfigPlugInBTN
        '
        Me.ConfigPlugInBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ConfigPlugInBTN.Enabled = False
        Me.ConfigPlugInBTN.Location = New System.Drawing.Point(126, 262)
        Me.ConfigPlugInBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.ConfigPlugInBTN.Name = "ConfigPlugInBTN"
        Me.ConfigPlugInBTN.Size = New System.Drawing.Size(118, 27)
        Me.ConfigPlugInBTN.TabIndex = 2
        Me.ConfigPlugInBTN.Text = "Konfig. Pack"
        Me.MainToolTip.SetToolTip(Me.ConfigPlugInBTN, "Konfiguriert das PlugInPack, das zum ausgewählten PlugIn gehrört." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Auch Doppelkl" & _
        "ick auf PlugIn)")
        Me.ConfigPlugInBTN.UseVisualStyleBackColor = True
        '
        'resetPlugInHKBTN
        '
        Me.resetPlugInHKBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.resetPlugInHKBTN.Enabled = False
        Me.resetPlugInHKBTN.Location = New System.Drawing.Point(4, 262)
        Me.resetPlugInHKBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.resetPlugInHKBTN.Name = "resetPlugInHKBTN"
        Me.resetPlugInHKBTN.Size = New System.Drawing.Size(118, 27)
        Me.resetPlugInHKBTN.TabIndex = 2
        Me.resetPlugInHKBTN.Text = "Reset HotKey"
        Me.MainToolTip.SetToolTip(Me.resetPlugInHKBTN, "HotKey für das PlugIn zurücksetzen.")
        Me.resetPlugInHKBTN.UseVisualStyleBackColor = True
        '
        'DisposePlugInBTN
        '
        Me.DisposePlugInBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DisposePlugInBTN.Location = New System.Drawing.Point(556, 261)
        Me.DisposePlugInBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.DisposePlugInBTN.Name = "DisposePlugInBTN"
        Me.DisposePlugInBTN.Size = New System.Drawing.Size(130, 27)
        Me.DisposePlugInBTN.TabIndex = 2
        Me.DisposePlugInBTN.Text = "PlugIns entladen"
        Me.MainToolTip.SetToolTip(Me.DisposePlugInBTN, "Entläd alle ÜlugIns, sodass sie bestimmte PlugIns aus dem Ordner entfernen können" & _
        ".")
        Me.DisposePlugInBTN.UseVisualStyleBackColor = True
        '
        'ReloadPlugInsBTN
        '
        Me.ReloadPlugInsBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReloadPlugInsBTN.Location = New System.Drawing.Point(690, 261)
        Me.ReloadPlugInsBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.ReloadPlugInsBTN.Name = "ReloadPlugInsBTN"
        Me.ReloadPlugInsBTN.Size = New System.Drawing.Size(134, 27)
        Me.ReloadPlugInsBTN.TabIndex = 2
        Me.ReloadPlugInsBTN.Text = "PlugIns neu laden"
        Me.MainToolTip.SetToolTip(Me.ReloadPlugInsBTN, "Laden Sie die PlugIns neu, wenn sie neue PlugIns in den PlugIn-Ordner hinzugefügt" & _
        " haben." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Um PlugIns zu entfernen, müssen Sie das Programm schließen.")
        Me.ReloadPlugInsBTN.UseVisualStyleBackColor = True
        '
        'OpenPlugInFolderBTN
        '
        Me.OpenPlugInFolderBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenPlugInFolderBTN.Location = New System.Drawing.Point(690, 20)
        Me.OpenPlugInFolderBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.OpenPlugInFolderBTN.Name = "OpenPlugInFolderBTN"
        Me.OpenPlugInFolderBTN.Size = New System.Drawing.Size(130, 27)
        Me.OpenPlugInFolderBTN.TabIndex = 2
        Me.OpenPlugInFolderBTN.Text = "Ordner öffnen"
        Me.MainToolTip.SetToolTip(Me.OpenPlugInFolderBTN, "Öffnent den Ordner im Explorer, in dem die Plugins für das Programm abgelegt sind" & _
        ".")
        Me.OpenPlugInFolderBTN.UseVisualStyleBackColor = True
        '
        'SetPlugInFolderBTN
        '
        Me.SetPlugInFolderBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SetPlugInFolderBTN.Location = New System.Drawing.Point(556, 20)
        Me.SetPlugInFolderBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.SetPlugInFolderBTN.Name = "SetPlugInFolderBTN"
        Me.SetPlugInFolderBTN.Size = New System.Drawing.Size(130, 27)
        Me.SetPlugInFolderBTN.TabIndex = 2
        Me.SetPlugInFolderBTN.Text = "Ordner festlegen"
        Me.MainToolTip.SetToolTip(Me.SetPlugInFolderBTN, "Legen Sie den Ordner fest, in dem nach Plugins gesucht werden soll." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dort sollten" & _
        " sich möglichst keine weiteren Dateien befinden." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PlugIn EInstellungen werden be" & _
        "im nächsten Programm-Start wirksam.")
        Me.SetPlugInFolderBTN.UseVisualStyleBackColor = True
        '
        'PlugInPathTB
        '
        Me.PlugInPathTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlugInPathTB.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MyHotKeys.My.MySettings.Default, "PlugInPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PlugInPathTB.Location = New System.Drawing.Point(53, 20)
        Me.PlugInPathTB.Margin = New System.Windows.Forms.Padding(2)
        Me.PlugInPathTB.Name = "PlugInPathTB"
        Me.PlugInPathTB.ReadOnly = True
        Me.PlugInPathTB.Size = New System.Drawing.Size(500, 27)
        Me.PlugInPathTB.TabIndex = 1
        Me.PlugInPathTB.Text = Global.MyHotKeys.My.MySettings.Default.PlugInPath
        Me.MainToolTip.SetToolTip(Me.PlugInPathTB, "Legen Sie den Ordner fest, in dem nach Plugins gesucht werden soll." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dort sollten" & _
        " sich möglichst keine weiteren Dateien befinden." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PlugIn EInstellungen werden be" & _
        "im nächsten Programm-Start wirksam.")
        '
        'ContactLLBL
        '
        Me.ContactLLBL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContactLLBL.AutoSize = True
        Me.ContactLLBL.Location = New System.Drawing.Point(227, 22)
        Me.ContactLLBL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ContactLLBL.Name = "ContactLLBL"
        Me.ContactLLBL.Size = New System.Drawing.Size(187, 20)
        Me.ContactLLBL.TabIndex = 21
        Me.ContactLLBL.TabStop = True
        Me.ContactLLBL.Text = "sederic.enders@gmail.com"
        Me.MainToolTip.SetToolTip(Me.ContactLLBL, "Klicken Sie hier, um eine Email an mich zu verfassen.")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 22)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 20)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "E-Mail:"
        Me.MainToolTip.SetToolTip(Me.Label8, "Bei Fragen, Anregungen, Kritik schreiben Sie mir eine Mail. Ich freu mich auf Fee" & _
        "dback.")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.ContactLLBL)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(4, 470)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(410, 55)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Kontakt"
        Me.MainToolTip.SetToolTip(Me.GroupBox3, "Bei Fragen, Anregungen, Kritik schreiben Sie mir eine Mail. Ich freu mich auf Fee" & _
        "dback.")
        '
        'ResetBTN
        '
        Me.ResetBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ResetBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ResetBTN.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetBTN.Location = New System.Drawing.Point(2, 3)
        Me.ResetBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.ResetBTN.Name = "ResetBTN"
        Me.ResetBTN.Size = New System.Drawing.Size(124, 41)
        Me.ResetBTN.TabIndex = 17
        Me.ResetBTN.Text = "&Reset"
        Me.MainToolTip.SetToolTip(Me.ResetBTN, "Alle Einstellungen und PlugIn-Einstellungen zurücksetzen")
        Me.ResetBTN.UseVisualStyleBackColor = True
        '
        'ExitBTN
        '
        Me.ExitBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitBTN.BackColor = System.Drawing.Color.Transparent
        Me.ExitBTN.DropDownMenu = Me.ContextMenuStrip1
        Me.ExitBTN.Font = New System.Drawing.Font("Segoe UI", 10.8!)
        Me.ExitBTN.Location = New System.Drawing.Point(716, 3)
        Me.ExitBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.ExitBTN.Name = "ExitBTN"
        Me.ExitBTN.Renderer = DropDownButtonRenderer1
        Me.ExitBTN.Size = New System.Drawing.Size(117, 41)
        Me.ExitBTN.TabIndex = 20
        Me.ExitBTN.Text = "&Schließen"
        Me.MainToolTip.SetToolTip(Me.ExitBTN, "Das Programm verlassen")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SchließenToolStripMenuItem, Me.ProgrammBeendenToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 48)
        '
        'SchließenToolStripMenuItem
        '
        Me.SchließenToolStripMenuItem.Name = "SchließenToolStripMenuItem"
        Me.SchließenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SchließenToolStripMenuItem.Text = "Fenster &Schließen"
        Me.SchließenToolStripMenuItem.ToolTipText = "minimiert das Fenster in den Statussymbolbereich"
        '
        'ProgrammBeendenToolStripMenuItem
        '
        Me.ProgrammBeendenToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgrammBeendenToolStripMenuItem.Image = Global.MyHotKeys.My.Resources.Resources._Exit
        Me.ProgrammBeendenToolStripMenuItem.Name = "ProgrammBeendenToolStripMenuItem"
        Me.ProgrammBeendenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ProgrammBeendenToolStripMenuItem.Text = "&Programm beenden"
        Me.ProgrammBeendenToolStripMenuItem.ToolTipText = "beendet das Programm"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.AddExceptionTB)
        Me.GroupBox4.Controls.Add(Me.AddExceptionBTN)
        Me.GroupBox4.Controls.Add(Me.RemoveExceptionBTN)
        Me.GroupBox4.Controls.Add(Me.ExceptionLB)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 10.8!)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 307)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(410, 153)
        Me.GroupBox4.TabIndex = 44
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Ausnahmen"
        Me.MainToolTip.SetToolTip(Me.GroupBox4, "Wenn Sie auf einen HotKey nicht reagieren möchten während ein bestimmtes Programm" & _
        "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "geöffnet ist, dann geben Sie hier dessen Namen ein." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Die Namen der Prozesse kö" & _
        "nnen Sie im Taskmanager nachsehen.")
        '
        'AddExceptionTB
        '
        Me.AddExceptionTB.AcceptsReturn = True
        Me.AddExceptionTB.AcceptsTab = True
        Me.AddExceptionTB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddExceptionTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.AddExceptionTB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.AddExceptionTB.Location = New System.Drawing.Point(297, 24)
        Me.AddExceptionTB.Margin = New System.Windows.Forms.Padding(2)
        Me.AddExceptionTB.Name = "AddExceptionTB"
        Me.AddExceptionTB.Size = New System.Drawing.Size(108, 27)
        Me.AddExceptionTB.TabIndex = 3
        Me.MainToolTip.SetToolTip(Me.AddExceptionTB, "Geben Sie den Namen eines Prozesses ein (siehe Taskmanager)," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dessen Ausführung d" & _
        "as Ausführen der HotKeys verhindern soll.")
        '
        'AddExceptionBTN
        '
        Me.AddExceptionBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddExceptionBTN.Enabled = False
        Me.AddExceptionBTN.Location = New System.Drawing.Point(297, 54)
        Me.AddExceptionBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.AddExceptionBTN.Name = "AddExceptionBTN"
        Me.AddExceptionBTN.Size = New System.Drawing.Size(107, 29)
        Me.AddExceptionBTN.TabIndex = 2
        Me.AddExceptionBTN.Text = "hinzufügen"
        Me.MainToolTip.SetToolTip(Me.AddExceptionBTN, "Geben Sie den Namen eines Prozesses ein (siehe Taskmanager)," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dessen Ausführung d" & _
        "as Ausführen der HotKeys verhindern soll.")
        Me.AddExceptionBTN.UseVisualStyleBackColor = True
        '
        'RemoveExceptionBTN
        '
        Me.RemoveExceptionBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RemoveExceptionBTN.Enabled = False
        Me.RemoveExceptionBTN.Location = New System.Drawing.Point(298, 115)
        Me.RemoveExceptionBTN.Margin = New System.Windows.Forms.Padding(2)
        Me.RemoveExceptionBTN.Name = "RemoveExceptionBTN"
        Me.RemoveExceptionBTN.Size = New System.Drawing.Size(107, 29)
        Me.RemoveExceptionBTN.TabIndex = 1
        Me.RemoveExceptionBTN.Text = "entfernen"
        Me.MainToolTip.SetToolTip(Me.RemoveExceptionBTN, "Entfernen Sie den ausgewählten Prozess aus der Ausnahme-Liste.")
        Me.RemoveExceptionBTN.UseVisualStyleBackColor = True
        '
        'ExceptionLB
        '
        Me.ExceptionLB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExceptionLB.FormattingEnabled = True
        Me.ExceptionLB.ItemHeight = 19
        Me.ExceptionLB.Location = New System.Drawing.Point(4, 24)
        Me.ExceptionLB.Margin = New System.Windows.Forms.Padding(2)
        Me.ExceptionLB.Name = "ExceptionLB"
        Me.ExceptionLB.Size = New System.Drawing.Size(290, 118)
        Me.ExceptionLB.Sorted = True
        Me.ExceptionLB.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ProgSettingsGB, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PlugInsGB, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(836, 577)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.ExitBTN)
        Me.Panel1.Controls.Add(Me.ResetBTN)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 530)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(836, 47)
        Me.Panel1.TabIndex = 42
        '
        'SettingsDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.ResetBTN
        Me.ClientSize = New System.Drawing.Size(836, 577)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(852, 535)
        Me.Name = "SettingsDialog"
        Me.Opacity = 0.0R
        Me.ShowInTaskbar = False
        Me.Text = "MyHotKeys - Einstellungen"
        Me.ProgSettingsGB.ResumeLayout(False)
        Me.ProgSettingsGB.PerformLayout()
        CType(Me.DelayNUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PlugInsGB.ResumeLayout(False)
        Me.PlugInsGB.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgSettingsGB As System.Windows.Forms.GroupBox
    Friend WithEvents AutostartCB As System.Windows.Forms.CheckBox
    Friend WithEvents SoundCB As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DelayNUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MainToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents VersionLBL As System.Windows.Forms.Label
    Friend WithEvents PlugInsGB As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SetPlugInFolderBTN As System.Windows.Forms.Button
    Friend WithEvents PlugInPathTB As System.Windows.Forms.TextBox
    Friend WithEvents PlugInHKTB As System.Windows.Forms.TextBox
    Friend WithEvents ApplyPlugInBTN As System.Windows.Forms.Button
    Friend WithEvents resetPlugInHKBTN As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ContactLLBL As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    'Friend WithEvents ExitBTN As System.Windows.Forms.Button
    Friend WithEvents ResetBTN As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents AddExceptionTB As System.Windows.Forms.TextBox
    Friend WithEvents AddExceptionBTN As System.Windows.Forms.Button
    Friend WithEvents RemoveExceptionBTN As System.Windows.Forms.Button
    Friend WithEvents ExceptionLB As System.Windows.Forms.ListBox
    Friend WithEvents ConfigPlugInBTN As System.Windows.Forms.Button
    Friend WithEvents PlugInLV As System.Windows.Forms.ListView
    Friend WithEvents NameCH As System.Windows.Forms.ColumnHeader
    Friend WithEvents HKCH As System.Windows.Forms.ColumnHeader
    Friend WithEvents PlugInIL As System.Windows.Forms.ImageList
    Friend WithEvents ExitBTN As DropDownButtonLib.DropDownButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SchließenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgrammBeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenPlugInFolderBTN As System.Windows.Forms.Button
    Friend WithEvents ReloadPlugInsBTN As System.Windows.Forms.Button
    Friend WithEvents DisposePlugInBTN As System.Windows.Forms.Button

End Class
