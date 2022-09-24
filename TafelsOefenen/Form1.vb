Imports System.ComponentModel

Public Class Form1
    Private Factor1 As Integer = 1
    Private Factor2 As Integer = 1
    Private Pogingen As Integer = 0
    Private Score As Integer = 0
    Private Dt As DataTable
    Private GemiddeldeDt As DataTable
    Private AantalPerSessie As Integer = 10
    Private OefeningNummer As Integer
    Private OefeningBezig As Boolean = False
    Private LaagsteScoreDt As DataTable
    Private MinstGeoefendDt As DataTable
    Private FormLoadFinisched As Boolean = False
    Private AantalNogNietGeoefend As Integer = 81


    Private Enum TafelModi
        Willekeurig = 1
        LaagsteScore = 2
        MinstGeoefend = 3
    End Enum
    Private TafelModus As TafelModi

    Private Sub MaakLaagsteScoreDt()
        Dim i As Integer
        Dim TopDr() As DataRow = GemiddeldeDt.Select("Aantalkeer > 0", "Score ASC")
        If TopDr.Length < AantalPerSessie Then
            TopDr = GemiddeldeDt.Select("", "Score ASC")
        End If
        LaagsteScoreDt = GemiddeldeDt.Clone
        LaagsteScoreDt.Clear()
        For i = 0 To AantalPerSessie - 1
            LaagsteScoreDt.ImportRow(TopDr(i))
        Next
        dgv.DataSource = LaagsteScoreDt
    End Sub
    Private Sub MaakMinstGeoeffendDt()
        GemiddeldeDt.DefaultView.Sort = "AantalKeer ASC"
        MinstGeoefendDt = GemiddeldeDt.DefaultView.ToTable.AsEnumerable().Take(AantalPerSessie).CopyToDataTable
        dgv.DataSource = MinstGeoefendDt
    End Sub

    Private Sub NieuweOpgave()
        OefeningNummer += 1
        If OefeningNummer > AantalPerSessie Then
            StopBtn_Click(Nothing, Nothing)
            Exit Sub
        End If

        Select Case TafelModus
            Case TafelModi.Willekeurig
                Dim Generator As System.Random = New System.Random
                Factor1 = Generator.Next(1, 9)
                Factor2 = Generator.Next(1, 9)
            Case TafelModi.LaagsteScore
                Dim Dr As DataRow
                Dr = LaagsteScoreDt.Rows.Item(OefeningNummer - 1)
                Factor1 = Dr.Item("Factor1")
                Factor2 = Dr.Item("Factor2")
            Case TafelModi.MinstGeoefend
                Dim Dr As DataRow
                Dr = MinstGeoefendDt.Rows.Item(OefeningNummer - 1)
                Factor1 = Dr.Item("Factor1")
                Factor2 = Dr.Item("Factor2")
        End Select

        Pogingen = 0
        ToonOpgave()
    End Sub

    Private Sub ToonOpgave()
        OpdrachtLbl.Text = Factor1.ToString + " x " + Factor2.ToString + " ="
        Tijdprg.Value = 0
        Timer.Enabled = True
        AntwoordTxt.Text = ""
        AntwoordTxt.Focus()
        ScoreLbl.Text = "Score: " + Score.ToString
        StatusOefeningLbl.Text = "Oefening " + OefeningNummer.ToString + "/" + AantalPerSessie.ToString

    End Sub
    Private Sub AntwoordTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles AntwoordTxt.KeyDown
        If e.KeyValue = Keys.Enter Then

            If Val(AntwoordTxt.Text) = Factor1 * Factor2 Then
                RegistreerJuistAntwoord()
            Else
                FoutAntwoord()
            End If
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub RegistreerJuistAntwoord()
        My.Computer.Audio.Play(My.Resources.ok, AudioPlayMode.Background)
        Dim BehaaldeScore As Integer = Int((60 - Tijdprg.Value) / (Pogingen + 1))
        Timer.Enabled = False
        Score += BehaaldeScore
        ScoreLbl.Text = "Score: " + Score.ToString
        'gegevens opslaan
        Dt.Rows.Add({Factor1, Factor2, Pogingen, BehaaldeScore, Now})
        NieuweOpgave()



    End Sub
    Private Sub FoutAntwoord()
        Beep()
        Pogingen = Pogingen + 1
        AntwoordTxt.SelectAll()


    End Sub
    Public Sub GeenAntwoord()
        Beep()
        Tijdprg.Value = 0
        Dt.Rows.Add({Factor1, Factor2, Pogingen, 0, Now})
        NieuweOpgave()
    End Sub
    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If Tijdprg.Value = 60 Then GeenAntwoord()
        Tijdprg.Value = Tijdprg.Value + 1
    End Sub
    Private Sub MaakOefeningDatatable()
        BerekenGemiddeldes()
        Select Case TafelModus
            Case TafelModi.LaagsteScore
                MaakLaagsteScoreDt()
            Case TafelModi.MinstGeoefend
                MaakMinstGeoeffendDt()
        End Select
    End Sub
    Private Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        AntwoordTxt.Enabled = True
        StartBtn.Enabled = False
        StopBtn.Enabled = True
        Score = 0
        OefeningNummer = 0
        InstellingenPanel.Enabled = False
        OefeningBezig = True
        NieuweOpgave()
        Timer.Enabled = True
    End Sub

    Private Sub StopBtn_Click(sender As Object, e As EventArgs) Handles StopBtn.Click
        InstellingenPanel.Enabled = True
        StartBtn.Enabled = True
        StopBtn.Enabled = False
        OefeningBezig = False
        If Score > (My.Settings.HighScore) Then
            MsgBox("Proficiat, je verbeterde je record! Vorig record:" + My.Settings.HighScore.ToString + " Nieuw record: " + Score.ToString)
            My.Settings.HighScore = Score
            RecordLbl.Text = "Record: " + My.Settings.HighScore.ToString
        End If
        OefeningNummer = 0
        Score = 0
        Timer.Enabled = False
        StatusOefeningLbl.Text = "Klik op Start"
        MaakOefeningDatatable()

        OpdrachtLbl.Text = ""
        AntwoordTxt.Text = ""
        AntwoordTxt.Enabled = False

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RecordLbl.Text = "Record: " + My.Settings.HighScore.ToString
        AantalPerSessieTxt.Text = AantalPerSessie.ToString
        If System.IO.File.Exists("Tafels.xml") Then
            Dt = New DataTable
            Dt.ReadXml("Tafels.xml")
        Else
            MaakDt()
        End If
        If System.IO.File.Exists("GemiddeldeTafels.xml") Then
            GemiddeldeDt = New DataTable
            GemiddeldeDt.ReadXml("GemiddeldeTafels.xml")
        Else

            MaakGemiddeldeDt()
        End If
        BerekenGemiddeldes()
        MaakOefeningDatatable()
        FormLoadFinisched = True

    End Sub
    Private Sub MaakDt()
        Dt = New DataTable
        With Dt
            .TableName = "Tafels"
            .Columns.Add(New DataColumn("Factor1", GetType(System.String)))
            .Columns.Add(New DataColumn("Factor2", GetType(System.String)))
            .Columns.Add(New DataColumn("Pogingen", GetType(System.Int16)))
            .Columns.Add(New DataColumn("Score", GetType(System.Int16)))
            .Columns.Add(New DataColumn("Datum", GetType(System.DateTime)))
            '.Rows.Add({1, 1, 0, 0, Now})
            .WriteXml("Tafels.xml", XmlWriteMode.WriteSchema)
        End With
    End Sub
    Private Sub MaakGemiddeldeDt()
        GemiddeldeDt = New DataTable
        With GemiddeldeDt
            .TableName = "Tafels"
            .Columns.Add(New DataColumn("Factor1", GetType(System.String)))
            .Columns.Add(New DataColumn("Factor2", GetType(System.String)))
            .Columns.Add(New DataColumn("Pogingen", GetType(System.Int16)))
            .Columns.Add(New DataColumn("Score", GetType(System.Single)))
            .Columns.Add(New DataColumn("AantalKeer", GetType(System.Int16)))
            .WriteXml("GemiddeldeTafels.xml", XmlWriteMode.WriteSchema)
        End With
    End Sub
    Private Sub BerekenGemiddeldes()
        Dim i As Integer
        Dim j As Integer
        Dim RowsFound() As DataRow
        Dim GemPogingen As Single
        Dim GemScore As Integer
        '  If IsNothing(Dt) Then MaakDt()
        ' If IsNothing(GemiddeldeDt) Then MaakGemiddeldeDt()
        AantalNogNietGeoefend = 0
        GemiddeldeDt.Rows.Clear()

        For i = 1 To 9
            For j = 1 To 9
                RowsFound = Dt.Select("Factor1 = " + i.ToString + " AND Factor2 = " + j.ToString)
                GemPogingen = 0
                GemScore = 0
                For Each Dr As DataRow In RowsFound
                    GemPogingen += Dr.Item("Pogingen")
                    GemScore += Dr.Item("Score")
                Next
                If RowsFound.Count <> 0 Then
                    GemPogingen = GemPogingen / RowsFound.Count
                    GemScore = GemScore / RowsFound.Count
                    GemiddeldeDt.Rows.Add({i, j, GemPogingen, GemScore, RowsFound.Count})
                Else
                    AantalNogNietGeoefend += 1
                    GemiddeldeDt.Rows.Add({i, j, 0, 0, 0})
                End If

            Next
            Next
        GemiddeldeDt.WriteXml("GemiddeldeTafels.xml", XmlWriteMode.WriteSchema)
        If AantalNogNietGeoefend <> 0 Then NogNietGeoefendLbl.Text = AantalNogNietGeoefend.ToString + " nog niet geoefende tafels"
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dt.WriteXml("Tafels.xml", XmlWriteMode.WriteSchema)
        BerekenGemiddeldes 
        GemiddeldeDt.WriteXml("GemiddeldeTafels.xml", XmlWriteMode.WriteSchema)
    End Sub


    Private Sub ModusChanged(sender As Object, e As EventArgs) Handles LaagsteScoreOptbtn.CheckedChanged, MinstGeoefendOptBtn.CheckedChanged, WillekeurigOptBtn.CheckedChanged
        If WillekeurigOptBtn.Checked Then TafelModus = TafelModi.Willekeurig
        If LaagsteScoreOptbtn.Checked Then TafelModus = TafelModi.LaagsteScore
        If MinstGeoefendOptBtn.Checked Then TafelModus = TafelModi.MinstGeoefend
        If FormLoadFinisched Then MaakOefeningDatatable()
    End Sub



    Private Sub AantalPerSessieTxt_LostFocus(sender As Object, e As EventArgs) Handles AantalPerSessieTxt.LostFocus
        AantalPerSessie = Val(AantalPerSessieTxt.Text)
        AantalPerSessieTxt.Text = AantalPerSessie.ToString
    End Sub

    Private Sub AntwoordTxt_TextChanged(sender As Object, e As EventArgs) Handles AntwoordTxt.TextChanged

    End Sub

    Private Sub AllesWissenBtn_Click(sender As Object, e As EventArgs) Handles AllesWissenBtn.Click
        Dim Antwoord As MsgBoxResult = MsgBox("Bent u zeker dat alles gewist mag worden", vbYesNoCancel)
        Select Case Antwoord
            Case MsgBoxResult.No Or MsgBoxResult.Cancel
                ' niets doen
            Case MsgBoxResult.Yes

                Try
                    My.Computer.FileSystem.DeleteFile("Tafels.xml")
                    My.Computer.FileSystem.DeleteFile("GemiddeldeTafels.xml")
                    My.Settings.HighScore = 0
                    ScoreLbl.Text = "Score: 0"
                    Form1_Load(Nothing, Nothing)

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select
    End Sub
End Class
