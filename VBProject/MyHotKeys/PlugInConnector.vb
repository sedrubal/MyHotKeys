Public Class PlugInConnector

    Public Shared Function LoadPlugIn(ByVal strFile As String) As List(Of [Interface].MHKPlugInPack)
        Dim vPlugIn As New List(Of [Interface].MHKPlugInPack)

        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(strFile)
        Dim types() As Type
        types = a.GetTypes()

        For Each pType As Type In types
            'hier wird versucht die dll zu laden.
            'dies funktioniert nur, wenn die dll auch das selbe interface implementiert
            'wie der host vorgiebt

            Try
                If pType.ContainsGenericParameters = False Then
                    If pType.GetConstructors().Count > 0 Then
                        Dim instance As System.Object = a.CreateInstance(pType.FullName)
                        If TypeOf (instance) Is [Interface].MHKPlugInPack Then
                            vPlugIn.Add(CType(instance, [Interface].MHKPlugInPack))
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        Next

        Return vPlugIn
    End Function

    Shared Function TypeFilter(ByVal t As Type, ByVal filterCriteria As Object) As Boolean
        ' Return true if interface is defined in the same 
        ' assembly identified by the filterCriteria object.
        Return t.Assembly.GetName().ToString() = CType(filterCriteria, String)
    End Function
End Class