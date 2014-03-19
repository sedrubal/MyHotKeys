'Imports System.IO

'Module PathTools
'    Public Function GetRelativePath(ByVal AbsolutePath As String, Optional ByVal BasePath As String = Nothing) As String
'        If Not File.Exists(AbsolutePath) And Not Directory.Exists(AbsolutePath) Then AbsolutePath = GetAbsolutePath(AbsolutePath, BasePath)
'        If String.IsNullOrWhiteSpace(BasePath) Then BasePath = My.Application.Info.DirectoryPath
'        BasePath = BasePath.TrimEnd(CChar("\"))
'        If Not File.Exists(AbsolutePath) Or Not Directory.Exists(AbsolutePath) Or Not Directory.Exists(BasePath) Then
'            Throw New DirectoryNotFoundException("The File or Directory 'AbsolutePath'='" & AbsolutePath & "' or the Directory 'BasePath'='" & BasePath & "' does not exist.")
'        Else
'            Dim relativePath As String = ""
'            If AbsolutePath.Contains(BasePath) Then
'                relativePath = AbsolutePath.Replace(BasePath, "")
'            Else
'                Dim base As New DirectoryInfo(BasePath)
'                Do Until AbsolutePath.Contains(base.Parent.FullName) Or String.IsNullOrWhiteSpace(base.FullName)
'                    relativePath &= "\.."
'                    Dim nbase As String = base.Parent.FullName
'                    base = New DirectoryInfo(nbase)
'                Loop
'                relativePath &= AbsolutePath.Replace(base.FullName, "")
'            End If
'            Return relativePath
'        End If
'    End Function
'    Public Function GetAbsolutePath(ByVal RelativePath As String, Optional ByVal BasePath As String = Nothing) As String
'        If String.IsNullOrWhiteSpace(BasePath) Then BasePath = My.Application.Info.DirectoryPath
'        If Not RelativePath.StartsWith("\") Then RelativePath = "\" & RelativePath
'        If BasePath.EndsWith("\") Then BasePath = BasePath.TrimEnd(CChar("\"))
'        If Not Directory.Exists(BasePath) Then
'            Throw New DirectoryNotFoundException("The Directory 'BasePath'='" & BasePath & "' does not exist.")
'        Else
'            Dim absolutepath As String = BasePath & RelativePath
'            Return absolutepath
'        End If
'    End Function
'End Module
