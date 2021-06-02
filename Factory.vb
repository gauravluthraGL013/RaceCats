
Namespace RaceCatsTask
    Friend Module Factory
        Private myRandom As Integer
        Public Property GuyNumber As Integer

        Sub New()
        End Sub

        Private Function GetAPunter(ByVal Type As String) As RaceCatsTask.Punter
            If Equals(Type, "Joe") Then
                Dim xP As RaceCatsTask.Punter = New RaceCatsTask.Joe()
                Return xP
            ElseIf Equals(Type, "Al") Then
                Dim xP As RaceCatsTask.Punter = New RaceCatsTask.Al()
                Return xP
            Else
                Dim xP As RaceCatsTask.Punter = New RaceCatsTask.Bob()
                Return xP
            End If
        End Function

        Private Sub SetTheGuyNumber(ByVal a As Integer)
        End Sub
    End Module
End Namespace
