Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports ShowMessage
Public Class Form3
    Public connection As New MySqlConnection("host=localhost; user=root; password=;database=db_brgypotrero;")
    Public adptr As New MySqlDataAdapter
    Public ds As New DataSet
    Public table As New DataTable

    Dim command As MySqlCommand
    Dim dataReader As MySqlDataReader

    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs) Handles btndashboard.Click
        chrtDocs()

        count_pndng()
        count_prcss()
        count_pck()
        count_settled()
        count_Declined()
        count_cancel()
        Form5.Close()
        Form6.Close()
        Form7.Close()
        Form8.Close()
        Form9.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        timenoww.Text = TimeString
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start() 'for digital clock
        Dim DateNOW As Date = Date.Now
        Dim dtnow As String = DateNOW.ToString("dd")
        Dim dtrmonth As String = DateNOW.ToString("MMM")
        Dim dtyear As String = DateNOW.ToString("yyy")

        thisdate.Text = dtnow + " / " + dtrmonth + " / " + dtyear

        chrtDocs()
        fetch_accname()

    End Sub
    Public Sub fetch_accname()
        connection.Close()
        connection.Open()
        command = New MySqlCommand("select * from tbl_admin where col_admin_Uname='" & Form1.Uname & "'", connection)
        dataReader = command.ExecuteReader

        While dataReader.Read
            Dim LName = dataReader.GetString("col_admin_name")

            lbl_accname.Text = LName
            lbl_accnameDashB.Text = LName
        End While

        connection.Close()
    End Sub

    Public Sub chrtDocs()
        With pieChartDocu
            .Series.Clear()
            .Series.Add("Series1")
        End With
        pieChartDocu.BackColor = System.Drawing.Color.Transparent
        Dim da As New MySqlDataAdapter("Select col_rqstDOC_action, count(ID) as total from tbl_docsreq Group by col_rqstDOC_action", connection)
        Dim ds As New DataSet

        da.Fill(ds, "col_rqstDOC_action")
        pieChartDocu.DataSource = ds.Tables("col_rqstDOC_action")

        Dim s1 As Series = pieChartDocu.Series("Series1")
        s1.ChartType = SeriesChartType.Doughnut
        s1.Name = "col_rqstDOC_action"

        With pieChartDocu
            .Series(0)("PieLabelStyle") = "Outside"
            .Series(0).BorderWidth = 1
            .ChartAreas(0).Area3DStyle.Enable3D = True
            .Series(s1.Name).XValueMember = "col_rqstDOC_action"
            .Series(s1.Name).YValueMembers = "total"
            .Series(0).LabelFormat = "{#,##0}"
            '.Series(0).IsValueShownAsLabel = True

            .Series(0).LegendText = "#VALX (#PERCENT)"
        End With


        count_pndng()
        count_prcss()
        count_pck()
        count_settled()
        count_Declined()
        count_cancel()
    End Sub

    Public Sub count_pndng()

        connection.Open()
        command = New MySqlCommand("Select Count(ID)as total   FROM tbl_docsreq where col_rqstDOC_action = 'Pending'", connection)
        dataReader = command.ExecuteReader

        While dataReader.Read
            lblpndng.Text = dataReader(0)
        End While
        connection.Close()

    End Sub
    Public Sub count_prcss()

        connection.Open()
        command = New MySqlCommand("Select Count(ID)as total   FROM tbl_docsreq where col_rqstDOC_action = 'Processing'", connection)
        dataReader = command.ExecuteReader

        While dataReader.Read
            lblprcss.Text = dataReader(0)
        End While
        connection.Close()

    End Sub


    Public Sub count_pck()

        connection.Open()
        command = New MySqlCommand("Select Count(ID)as total   FROM tbl_docsreq where col_rqstDOC_action = 'To Pick-up'", connection)
        dataReader = command.ExecuteReader

        While dataReader.Read
            lblpck.Text = dataReader(0)
        End While
        connection.Close()

    End Sub

    Public Sub count_settled()

        connection.Open()
        command = New MySqlCommand("Select Count(ID)as total   FROM tbl_docsreq where col_rqstDOC_action = 'Settled'", connection)
        dataReader = command.ExecuteReader

        While dataReader.Read
            lblsettled.Text = dataReader(0)
        End While
        connection.Close()

    End Sub


    Public Sub count_Declined()

        connection.Open()
        command = New MySqlCommand("Select Count(ID)as total   FROM tbl_docsreq where col_rqstDOC_action = 'Declined'", connection)
        dataReader = command.ExecuteReader

        While dataReader.Read
            lbldcline.Text = dataReader(0)
        End While
        connection.Close()

    End Sub

    Public Sub count_cancel() 'cancel sa ctzn

        connection.Open()
        command = New MySqlCommand("Select Count(ID)as total   FROM tbl_docsreq where col_rqstDOC_action = 'Canceled'", connection)
        dataReader = command.ExecuteReader

        While dataReader.Read
            lblrcanceled.Text = dataReader(0)
        End While
        connection.Close()

    End Sub



    Private Sub Guna2ImageButton4_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton4.Click

        Dim Quest As Integer = MsgShow("Are Sure You want to logout?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
        If Quest = DialogResult.Yes Then

            'FOR ACTIVITY LOG
            Dim regtime As Date = Date.Now()
            Dim str_hr As String = regtime.ToString("HH")
            Dim str_min As String = regtime.ToString("mm")
            Dim str_sec As String = regtime.ToString("ss")

            Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "

            connection.Close()
            connection.Open()
            command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
            command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
            command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "Account was successfully logged out'"
            command.ExecuteNonQuery()
            connection.Close()


            btndashboard.Checked = True
            Me.Close()
            Form9.Close()
            Form8.Close()
            Form5.Close()
            Form6.Close()
            Form1.Show()
        Else

        End If
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles btn_info_docu.Click
        With Form7
            .TopLevel = False
            displayPnl.Controls.Add(Form7)
            .BringToFront()
            .Show()
            Form7.Size = displayPnl.Size
            lbltag.Text = "Document Information"
        End With
    End Sub

    Private Sub Guna2GradientButton4_Click(sender As Object, e As EventArgs) Handles btn_ctzn.Click
        With Form5
            .TopLevel = False
            displayPnl.Controls.Add(Form5)
            .BringToFront()
            .Show()
            Form5.Size = displayPnl.Size
            lbltag.Text = "Citizen's Information"
        End With
    End Sub


    Private Sub Guna2ImageButton1_Click_1(sender As Object, e As EventArgs) Handles Guna2ImageButton1.Click
        With Form6
            .TopLevel = False
            displayPnl.Controls.Add(Form6)
            .BringToFront()
            .Show()
            Form6.Size = displayPnl.Size
            lbltag.Text = "Documents"
            Form6.verify_ctzn()
        End With
    End Sub

    Private Sub btn_report_Click(sender As Object, e As EventArgs) Handles btn_report.Click
        With Form8
            .TopLevel = False
            displayPnl.Controls.Add(Form8)
            .BringToFront()
            .Show()
            Form8.Size = displayPnl.Size
            lbltag.Text = "Reports"

        End With
    End Sub

    Private Sub Guna2GradientButton1_Click_1(sender As Object, e As EventArgs) Handles btn_logs.Click
        With Form9
            .TopLevel = False
            displayPnl.Controls.Add(Form9)
            .BringToFront()
            .Show()
            Form9.Size = displayPnl.Size
            Form9.fetch_logs()
            lbltag.Text = "LOGS"
        End With
    End Sub
End Class