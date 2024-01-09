Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Net
Imports System.Net.Mail
Imports ShowMessage
Public Class Form9
    Public connection As New MySqlConnection("host=localhost; user=root; password=;database=db_brgypotrero;")
    Public adptr As New MySqlDataAdapter
    Public ds As New DataSet

    Dim command As MySqlCommand
    Dim dataReader As MySqlDataReader
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp_filter.Value = DateTime.Now
        fetch_logs()
    End Sub
    Public Sub fetch_logs()
        Dim tablenew1 As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select                                             
                                                _dateTime as 'Date & Time', 
                                                col_desc as Description
                                                from tbl_logs where col_uname = '" & Form1.Uname & "' 
                                                
                                                ORDER BY `_dateTime` DESC", connection)
        adptr.SelectCommand = command
        tablenew1.Clear()

        adptr.Fill(tablenew1)
        dgv_logs.DataSource = tablenew1

        connection.Close()
    End Sub

    Private Sub dtp_filter_ValueChanged(sender As Object, e As EventArgs) Handles dtp_filter.ValueChanged
        Dim tablenew As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select                                             
                                                _dateTime as 'Date & Time', 
                                                col_desc as Description
                                                from tbl_logs where col_uname = '" & Form1.Uname & "'
                                                and _dateTime = '" & dtp_filter.Value.ToString("yyyy/MM/dd") & "' 
                                                and col_desc LIKE '%" & txtsearch.Text & "%'
                                                
                                                ORDER BY `col_desc` DESC", connection)
        adptr.SelectCommand = command
        tablenew.Clear()

        adptr.Fill(tablenew)
        dgv_logs.DataSource = tablenew


        connection.Close()
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim tablenew As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("SELECT
                                           _dateTime as 'Date & Time', 
                                           col_desc as Description
                                    FROM
                                            tbl_logs
                                    WHERE 
                                            col_uname = '" & Form1.Uname & "' and 
                                            col_desc LIKE '%" & txtsearch.Text & "%' and
                                            _dateTime = '" & dtp_filter.Value.ToString("yyyy/MM/dd") & "'
                                  
                                    ORDER BY
                                            `col_desc`
                                    DESC
                                                                    ", connection)
        adptr.SelectCommand = command
        tablenew.Clear()

        adptr.Fill(tablenew)
        dgv_logs.DataSource = tablenew

        connection.Close()
    End Sub
End Class