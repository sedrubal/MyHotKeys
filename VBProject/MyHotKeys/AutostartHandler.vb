Option Strict Off
Module AutostartHandler
    Public Sub Autostart(ByVal AutostartEnable As Boolean)
        Dim OldFile As String = My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe"
        Dim NewFile As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\" & My.Application.Info.AssemblyName & ".lnk"
        If AutostartEnable Then
            If Not My.Computer.FileSystem.FileExists(NewFile) Then
                If Not AutostartHandler.CreateLink(OldFile, NewFile, , , "Autostart", ) Then MainClass.ShowMessageStatic("Das Programm konnte nicht in die Autostart-Einträge hinzugefügt werden!")
            End If
        Else
            If My.Computer.FileSystem.FileExists(NewFile) Then
                My.Computer.FileSystem.DeleteFile(NewFile)
            End If
        End If
    End Sub

    Friend Function IsAutostart() As Boolean
        Return My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\" & My.Application.Info.AssemblyName & ".lnk")
    End Function

    ''' <summary>
    ''' Erstellt eine Verknüpfung
    ''' </summary>
    ''' <param name="sFile">kompletter Pfad der Ausgangsdatei</param>
    ''' <param name="sLinkName">kompletter Pfad für die Link-Datei, die erstellt werden soll</param>
    ''' <param name="sParameter">Parameter für die Linkdatei</param>
    ''' <param name="sComment">Kommentar für die Linkdatei</param>
    ''' <param name="sWorkingDir"></param>
    ''' <param name="sHotKey">Hotkey für Linkdatei</param>
    ''' <returns>Gibt zurück, ob der Vorgang erfolgreich war</returns>
    ''' <remarks></remarks>
    Public Function CreateLink(ByVal sFile As String, ByVal sLinkName As String, _
    Optional ByVal sParameter As String = "", Optional ByVal sComment As String = "", _
    Optional ByVal sWorkingDir As String = "", Optional ByVal sHotKey As String = "") As Boolean

        ' Fehlerbehandlung, falls WSH-Objekt nicht
        ' verfügbar
        On Error GoTo ErrHandler
        Dim WshShell As Object
        Dim WshLink As Object

        ' Verweis auf den Windows Scripting Host erstellen
        WshShell = CreateObject("WScript.Shell")

        ' Neuen Link Erstellen
        WshLink = WshShell.CreateShortcut(sLinkName)

        With WshLink
            ' Ziel der Verknüpfung
            .TargetPath = sFile

            ' Weitere Eigenschaften...
            .WorkingDirectory = sWorkingDir
            .Arguments = sParameter
            .Description = sComment
            .HotKey = sHotKey

            ' Verknüpfung speichern
            .Save()
        End With

        ' Objekte zerstören
        WshLink = Nothing
        WshShell = Nothing

        CreateLink = True
        On Error GoTo 0
        Exit Function

ErrHandler:
        CreateLink = False
    End Function

End Module
