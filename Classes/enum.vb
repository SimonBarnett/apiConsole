Public Module enums

    Public Enum eFormType
        log
        debug
        install
    End Enum

    Public Enum epType
        feed = 0
        handler = 1
    End Enum

End Module

Public Class HighlightColors

    Public Shared HC_NODE As Color = Color.Firebrick

    Public Shared HC_STRING As Color = Color.Blue

    Public Shared HC_ATTRIBUTE As Color = Color.Red

    Public Shared HC_COMMENT As Color = Color.GreenYellow

    Public Shared HC_INNERTEXT As Color = Color.Black

End Class