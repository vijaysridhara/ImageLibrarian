Public Class ContainerPanel
    Inherits Panel
    Protected Overrides Function ScrollToControl(activeControl As Control) As Point
        Return Me.DisplayRectangle.Location

    End Function

End Class
