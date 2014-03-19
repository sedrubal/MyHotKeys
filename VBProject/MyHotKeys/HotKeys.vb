Public NotInheritable Class HotKeys : Inherits NativeWindow : Implements IDisposable

   Private Declare Function RegisterHotKey Lib "user32" ( _
         ByVal Hwnd As IntPtr, ByVal ID As Integer, _
         ByVal Modifiers As Integer, ByVal Key As Integer) As Integer

   Private Declare Function UnregisterHotKey Lib "user32" ( _
         ByVal Hwnd As IntPtr, ByVal ID As Integer) As Integer

   Public Class PressedEventArgs : Inherits EventArgs
      Public ReadOnly Key As Keys
      Public Sub New(ByVal Key As Keys)
         Me.Key = Key
      End Sub
   End Class
   Public Event Pressed As EventHandler(Of PressedEventArgs)

   Public Const WinKey As Keys = DirectCast(Keys.Alt << 1, Keys)
   Private _Registered As New HashSet(Of Keys)

   Public Sub New()
      Me.CreateHandle(New CreateParams)
   End Sub

   Public Function TryRegister(ByVal Key As Keys) As Boolean
      Dim ApiModifier = 0
      If CBool(Key And WinKey) Then ApiModifier += 8
      If CBool(Key And Keys.Shift) Then ApiModifier += 4
      If CBool(Key And Keys.Control) Then ApiModifier += 2
      If CBool(Key And Keys.Alt) Then ApiModifier += 1
      'Für die API-Registrierung die Modifier-Komponente (oberhalb &HFFFF) der Keys-Enumeration wegmaskieren
      If RegisterHotKey(Me.Handle, Key, ApiModifier, Key And &HFFFF) = 0 Then Return False
      _Registered.Add(Key)
      Return True
   End Function

   Public Function TryUnRegister(ByVal Key As Keys) As Boolean
      If Not _Registered.Remove(Key) Then Return False
      If UnregisterHotKey(Me.Handle, Key) = 0 Then Return False
      Return True
   End Function

   Protected Overrides Sub WndProc(ByRef m As Message)
      Const WM_HOTKEY As Integer = &H312
      If m.Msg = WM_HOTKEY Then RaiseEvent Pressed(Me, New PressedEventArgs(DirectCast(m.WParam.ToInt32, Keys)))
      MyBase.WndProc(m)
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      If Me.Handle = IntPtr.Zero Then Return
      For Each key In _Registered
         If UnregisterHotKey(Me.Handle, key) = 0 Then Stop
      Next
      Me.ReleaseHandle()
   End Sub

End Class
