Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Net
Imports System.Net.Mail
Imports ShowMessage
Public Class Form5
    Public connection As New MySqlConnection("host=localhost; user=root; password=;database=db_brgypotrero;")
    Public adptr As New MySqlDataAdapter
    Public ds As New DataSet


    Dim command As MySqlCommand
    Dim dataReader As MySqlDataReader

    Dim RESIDENT_ID As Integer 'para sa id ng resident information

    Public Shared toUser As String
    Public Shadows txtemail As String

    Public Shared rbresident As String 'for radiobutton selection in residency
    Public Shared rbstatus As String 'for radiobutton selection in maariage status

    'Dim y_m As New TextBox 'para sa mag hold ng value sa number of years or months na naninirahan

    Dim txt_rprt As New TextBox

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fetch_resident()


    End Sub
    Public Sub Fetch_resident() ' FOR admin datas
        Dim tablenew As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                col_ID as 'ID',
                                                col_rsdnt_lname as 'Lastname' ,
                                                col_rsdnt_fname as 'Firstname',
                                                col_rsdnt_mname as 'Middlename',
                                                col_rsdnt_address as 'Address',
                                                col_rsdnt_residency as 'Residency',
                                                col_rsdnt_year as 'Residency Year',
                                                col_rsdnt_gender as 'Gender',

                                                col_rsdnt_cnum as 'Contact Number',
                                                col_rsdnt_ctznshp as 'Citizenship',
                                                col_rsdnt_bday as 'Birthday',
                                                col_rsdnt_pday as 'Place of birth',
                                                col_rsdnt_status as 'Marital status',
                                                col_rsdnt_health as 'Health',
                                                col_rsdnt_Rname as 'Relative Name',
                                                col_rsdnt_Rcnum as 'Relative Cell Number',
                                                col_rsdnt_Radd as 'Relative Address',

                                                _dateTime as 'Created Date and Time'
                                                from tbl_resident 
                                                ORDER BY `_datetime` DESC", connection)
        adptr.SelectCommand = command
        tablenew.Clear()

        adptr.Fill(tablenew)
        dgv_resident.DataSource = tablenew

        connection.Close()

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        saveInfo()
    End Sub
    Public Sub clear()
        txtlname.Clear()
        txtfname.Clear()
        txtmname.Clear()
        txtaddress.Clear()
        rbowned.Checked = True
        txtnumyear.Clear()
        cmbgender.Text = Nothing
        txtcp_num.Clear()
        txtctznshp.Clear()
        txtplace_bday.Clear()
        rbsingle.Checked = True
        cmbhealth.Text = Nothing
        txt_rlName.Clear()
        txt_rl_address.Clear()
        txt_rl_cnum.Clear()

    End Sub
    Public Sub saveInfo() 'for save information of brgy official
        If txtlname.Text = Nothing Then
            MsgShow("Please input resident's lastname", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)

        ElseIf txtfname.Text = Nothing Then
            MsgShow("Please input resident's firstname", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txtmname.Text = Nothing Then
            MsgShow("Please input resident's middlename", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txtaddress.Text = Nothing Then
            MsgShow("Please input resident's address", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf cmbgender.Text = Nothing Then
            MsgShow("Please select resident's gender", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf cmbhealth.Text = Nothing Then
            MsgShow("Please select resident's health status", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txtnumyear.Text = Nothing Then
            MsgShow("Please input resident's number of year/months as resident", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txtcp_num.Text = Nothing Then
            MsgShow("Please input resident's cellphone number", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txtplace_bday.Text = Nothing Then
            MsgShow("Please input resident's place of birth", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)

        ElseIf txt_rlName.Text = Nothing Or txt_rl_cnum.Text = Nothing Or txt_rl_address.Text = Nothing Then
            MsgShow("Please fill blank textboxes for Others Information!", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txt_rlName.Text = Nothing Then
            MsgShow("Please input resident's relative fullname at 'Others'", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txt_rl_cnum.Text = Nothing Then
            MsgShow("Please input resident's relative cellphone number at 'Others'", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txt_rl_address.Text = Nothing Then
            MsgShow("Please input resident's relative address at 'Others'", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        Else
            connection.Close()
            connection.Open()
            command = New MySqlCommand("Insert into tbl_resident 
                                   (col_rsdnt_lname, col_rsdnt_fname,col_rsdnt_mname, col_rsdnt_address, col_rsdnt_residency,
                                    col_rsdnt_year, col_rsdnt_gender, col_rsdnt_cnum, col_rsdnt_ctznshp, col_rsdnt_bday, col_rsdnt_pday,
                                    col_rsdnt_status, col_rsdnt_health, col_rsdnt_Rname, col_rsdnt_Rcnum, col_rsdnt_Radd)
                             values 
                                    (@lname, @fname, @mname, @add, @res, @yr, @gender, @cnum, @ctznshp, @bday, @pday, @status, @health,  
                                    @rname, @Rcnum, @Radd)", connection)

            command.Parameters.Add(New MySqlParameter("@lname", MySqlDbType.VarChar, 50)).Value = txtlname.Text
            command.Parameters.Add(New MySqlParameter("@fname", MySqlDbType.VarChar, 50)).Value = txtfname.Text
            command.Parameters.Add(New MySqlParameter("@mname", MySqlDbType.VarChar, 50)).Value = txtmname.Text
            command.Parameters.Add(New MySqlParameter("@add", MySqlDbType.VarChar, 50)).Value = txtaddress.Text
            command.Parameters.Add(New MySqlParameter("@res", MySqlDbType.VarChar, 50)).Value = rbresident
            command.Parameters.Add(New MySqlParameter("@yr", MySqlDbType.VarChar, 50)).Value = txtnumyear.Text
            command.Parameters.Add(New MySqlParameter("@gender", MySqlDbType.VarChar, 50)).Value = cmbgender.Text
            command.Parameters.Add(New MySqlParameter("@cnum", MySqlDbType.VarChar, 50)).Value = txtcp_num.Text
            command.Parameters.Add(New MySqlParameter("@ctznshp", MySqlDbType.VarChar, 50)).Value = txtctznshp.Text
            command.Parameters.Add(New MySqlParameter("@bday", dtpbday.Value.Date))
            command.Parameters.Add(New MySqlParameter("@pday", MySqlDbType.VarChar, 50)).Value = txtplace_bday.Text
            command.Parameters.Add(New MySqlParameter("@status", MySqlDbType.VarChar, 50)).Value = rbstatus
            command.Parameters.Add(New MySqlParameter("@health", MySqlDbType.VarChar, 50)).Value = cmbhealth.Text
            command.Parameters.Add(New MySqlParameter("@rname", MySqlDbType.VarChar, 50)).Value = txt_rlName.Text
            command.Parameters.Add(New MySqlParameter("@Rcnum", MySqlDbType.VarChar, 50)).Value = txt_rl_cnum.Text
            command.Parameters.Add(New MySqlParameter("@Radd", MySqlDbType.VarChar, 50)).Value = txt_rl_address.Text


            command.ExecuteNonQuery()
            connection.Close()

            'FOR ACTIVITY LOG

            Dim regDate As Date = Date.Now()
            Dim str_hr As String = regDate.ToString("HH")
            Dim str_min As String = regDate.ToString("mm")
            Dim str_sec As String = regDate.ToString("ss")

            Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "

            connection.Close()
            connection.Open()
            command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
            command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
            command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully added " & txtfname.Text.ToString.ToUpper & " " & txtlname.Text.ToString.ToUpper & " as resident"
            command.ExecuteNonQuery()
            connection.Close()





            MsgShow("Person's information added as barangay resident successfully!", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
            'MessageBox.Show("Citizen Information Registered Successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Fetch_resident()
            clear()
        End If
    End Sub

    Private Sub rbwoned_CheckedChanged(sender As Object, e As EventArgs) Handles rbowned.CheckedChanged

        rbresident = rbowned.Text
    End Sub

    Private Sub rbrent_CheckedChanged(sender As Object, e As EventArgs) Handles rbrent.CheckedChanged

        rbresident = rbrent.Text
    End Sub

    Private Sub rbrelative_CheckedChanged(sender As Object, e As EventArgs) Handles rbrelative.CheckedChanged

        rbresident = rbrelative.Text
    End Sub

    Private Sub rbsingle_CheckedChanged(sender As Object, e As EventArgs) Handles rbsingle.CheckedChanged
        rbstatus = rbsingle.Text
    End Sub

    Private Sub rbmarried_CheckedChanged(sender As Object, e As EventArgs) Handles rbmarried.CheckedChanged
        rbstatus = rbmarried.Text
    End Sub

    Private Sub rbwidow_CheckedChanged(sender As Object, e As EventArgs) Handles rbwidow.CheckedChanged
        rbstatus = rbwidow.Text
    End Sub

    Private Sub rbseparate_CheckedChanged(sender As Object, e As EventArgs) Handles rbseparate.CheckedChanged
        rbstatus = rbseparate.Text
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_resident.CellContentClick
        'PARA SA PAG FETCH NG DATA FROM DATAGRID TO TEXTBOXES

        dgv_resident.ClearSelection()
        If e.RowIndex < 0 Then Exit Sub


        RESIDENT_ID = dgv_resident.Item(0, e.RowIndex).Value.ToString
        txtlname.Text = dgv_resident.Item(1, e.RowIndex).Value.ToString
        txtfname.Text = dgv_resident.Item(2, e.RowIndex).Value.ToString
        txtmname.Text = dgv_resident.Item(3, e.RowIndex).Value.ToString
        txtaddress.Text = dgv_resident.Item(4, e.RowIndex).Value.ToString

        'FOR FETCHING DATA FOR RADIOBUTTON ( RESIDENCY TYPE )
        If dgv_resident.Rows(e.RowIndex).Cells(5).Value.ToString.Equals("Owned") Then
            rbowned.Checked = True
        ElseIf dgv_resident.Rows(e.RowIndex).Cells(5).Value.ToString.Equals("Rented") Then
            rbrent.Checked = True
        ElseIf dgv_resident.Rows(e.RowIndex).Cells(5).Value.ToString.Equals("Living with Relatives") Then
            rbrelative.Checked = True
        End If

        txtnumyear.Text = dgv_resident.Item(6, e.RowIndex).Value.ToString
        cmbgender.Text = dgv_resident.Item(7, e.RowIndex).Value.ToString
        txtcp_num.Text = dgv_resident.Item(8, e.RowIndex).Value.ToString
        txtctznshp.Text = dgv_resident.Item(9, e.RowIndex).Value.ToString
        dtpbday.Value = CDate(dgv_resident.Item(10, e.RowIndex).Value)
        txtplace_bday.Text = dgv_resident.Item(11, e.RowIndex).Value.ToString

        'FOR FETCHING DATA FOR RADIOBUTTON ( Marital Status )
        If dgv_resident.Rows(e.RowIndex).Cells(12).Value.ToString.Equals("Single") Then
            rbsingle.Checked = True
        ElseIf dgv_resident.Rows(e.RowIndex).Cells(12).Value.ToString.Equals("Married") Then
            rbmarried.Checked = True
        ElseIf dgv_resident.Rows(e.RowIndex).Cells(12).Value.ToString.Equals("Widow/er") Then
            rbwidow.Checked = True
        ElseIf dgv_resident.Rows(e.RowIndex).Cells(12).Value.ToString.Equals("Separated") Then
            rbseparate.Checked = True
        End If


        cmbhealth.Text = dgv_resident.Item(13, e.RowIndex).Value.ToString
        txt_rlName.Text = dgv_resident.Item(14, e.RowIndex).Value.ToString

        txt_rl_cnum.Text = dgv_resident.Item(15, e.RowIndex).Value.ToString
        txt_rl_address.Text = dgv_resident.Item(16, e.RowIndex).Value.ToString

        'PARA SA PAG READ ONLY NG TEXTBOXES
        txtlname.ReadOnly = True
        txtfname.ReadOnly = True
        txtmname.ReadOnly = True
        txtaddress.ReadOnly = True

        rbowned.Enabled = False
        rbrent.Enabled = False
        rbrelative.Enabled = False

        txtnumyear.ReadOnly = True
        cmbgender.Enabled = False
        txtcp_num.ReadOnly = True
        txtctznshp.ReadOnly = True
        dtpbday.Enabled = False
        txtplace_bday.ReadOnly = True
        Guna2Panel1.Enabled = False 'marital status panel of radio buttons
        cmbhealth.Enabled = False
        txt_rlName.ReadOnly = True
        txt_rl_address.ReadOnly = True
        txt_rl_cnum.ReadOnly = True

        btnsave.Visible = False
        btn_edit.Visible = True 'pag visible ng btn na edit
        btnClear.Visible = True

    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        'MessageBox.Show("Are you sure want to UPDATE this?", "Update Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Dim update As Integer = MsgShow("Are you sure want to UPDATE this?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
        If update = DialogResult.Yes Then
            connection.Close()
        connection.Open()

            'col_rsdnt_lname, col_rsdnt_fname, col_rsdnt_mname, col_rsdnt_address, col_rsdnt_residency,
            '                        col_rsdnt_year, col_rsdnt_gender, col_rsdnt_cnum, col_rsdnt_ctznshp, col_rsdnt_bday, col_rsdnt_pday,
            '                        col_rsdnt_status, col_rsdnt_health, col_rsdnt_Rname, col_rsdnt_Rcnum, col_rsdnt_Radd

            command = New MySqlCommand("UPDATE tbl_resident SET col_rsdnt_lname='" & txtlname.Text & "',
                                        col_rsdnt_fname ='" & txtfname.Text & "',
                                        col_rsdnt_mname= '" & txtmname.Text & "',
                                        col_rsdnt_address= '" & txtaddress.Text & "',
                                        col_rsdnt_residency= '" & rbresident & "',
                                        col_rsdnt_year= '" & txtnumyear.Text & "',
                                        col_rsdnt_gender= '" & cmbgender.Text & "',
                                        col_rsdnt_cnum= '" & txtcp_num.Text & "',
                                        col_rsdnt_ctznshp= '" & txtctznshp.Text & "',
                                        col_rsdnt_bday= @bday,
                                        col_rsdnt_pday= '" & txtplace_bday.Text & "',
                                        col_rsdnt_status= '" & rbstatus & "',
                                        col_rsdnt_health= '" & cmbhealth.Text & "',
                                        col_rsdnt_Rname= '" & txt_rlName.Text & "',
                                        col_rsdnt_Rcnum= '" & txt_rl_cnum.Text & "',
                                        col_rsdnt_Radd= '" & txt_rl_address.Text & "'

                                        WHERE col_ID='" & RESIDENT_ID & "'", connection)
            command.Parameters.Add(New MySqlParameter("@bday", dtpbday.Value.Date))
        dataReader = command.ExecuteReader
            connection.Close()


            'FOR ACTIVITY LOG

            Dim regDate As Date = Date.Now()
            Dim str_hr As String = regDate.ToString("HH")
            Dim str_min As String = regDate.ToString("mm")
            Dim str_sec As String = regDate.ToString("ss")

            Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "

            connection.Close()
            connection.Open()
            command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
            command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
            command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully updated " & txtfname.Text.ToString.ToUpper & " " & txtlname.Text.ToString.ToUpper & "'s personal information"
            command.ExecuteNonQuery()
            connection.Close()



            'MessageBox.Show("Resident Information Updated", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MsgShow("Barangay resident's information has been successfully UPDATED", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
            Fetch_resident() ' para auto refresh ang grid sa form2 
        clear()
        btnsave.Visible = True
        btnupdate.Visible = False
        btnClear.Visible = False
        End If

    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        'para sa pag accessible ang mga textboxes/radio buttons
        txtlname.ReadOnly = False
        txtfname.ReadOnly = False
        txtmname.ReadOnly = False
        txtaddress.ReadOnly = False

        rbowned.Enabled = True
        rbrent.Enabled = True
        rbrelative.Enabled = True

        txtnumyear.ReadOnly = False

        cmbgender.Enabled = True

        txtcp_num.ReadOnly = False
        txtctznshp.ReadOnly = False
        dtpbday.Enabled = True
        txtplace_bday.ReadOnly = False

        Guna2Panel1.Enabled = True 'marital status panel of radio buttons
        cmbhealth.Enabled = True

        txt_rlName.ReadOnly = False
        txt_rl_address.ReadOnly = False
        txt_rl_cnum.ReadOnly = False

        btnupdate.Visible = True
        btn_edit.Visible = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
        'para sa pag accessible ang mga textboxes/radio buttons
        txtlname.ReadOnly = False
        txtfname.ReadOnly = False
        txtmname.ReadOnly = False
        txtaddress.ReadOnly = False

        rbowned.Enabled = True
        rbrent.Enabled = True
        rbrelative.Enabled = True

        txtnumyear.ReadOnly = False

        cmbgender.Enabled = True

        txtcp_num.ReadOnly = False
        txtctznshp.ReadOnly = False
        dtpbday.Enabled = True
        txtplace_bday.ReadOnly = False

        Guna2Panel1.Enabled = True 'marital status panel of radio buttons
        cmbhealth.Enabled = True

        txt_rlName.ReadOnly = False
        txt_rl_address.ReadOnly = False
        txt_rl_cnum.ReadOnly = False

        btnsave.Visible = True
        btn_edit.Visible = False
        btnClear.Visible = False
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim tablenew As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("SELECT
                                            col_ID AS 'ID',
                                            col_rsdnt_lname AS 'Lastname',
                                            col_rsdnt_fname AS 'Firstname',
                                            col_rsdnt_mname AS 'Middlename',
                                            col_rsdnt_address AS 'Address',
                                            col_rsdnt_residency AS 'Residency',
                                            col_rsdnt_year AS 'Residency Year',
                                            col_rsdnt_gender AS 'Gender',
                                            col_rsdnt_cnum AS 'Contact Number',
                                            col_rsdnt_ctznshp AS 'Citizenship',
                                            col_rsdnt_bday AS 'Birthday',
                                            col_rsdnt_pday AS 'Place of birth',
                                            col_rsdnt_status AS 'Marital status',
                                            col_rsdnt_health AS 'Health',
                                            col_rsdnt_Rname AS 'Relative Name',
                                            col_rsdnt_Rcnum AS 'Relative Cell Number',
                                            col_rsdnt_Radd AS 'Relative Address',
                                            _dateTime AS 'Created Date and Time'
                                    FROM
                                            tbl_resident
                                    WHERE
                                            col_rsdnt_lname LIKE '%" & txtsearch.Text & "%'
                                    OR
                                             col_rsdnt_fname LIKE '%" & txtsearch.Text & "%'
                                    OR
                                             col_rsdnt_mname LIKE '%" & txtsearch.Text & "%'
                                    OR
                                             col_rsdnt_address LIKE '%" & txtsearch.Text & "%'
                                    OR
                                             col_rsdnt_Rname LIKE '%" & txtsearch.Text & "%'
                                    ORDER BY
                                            `_datetime`
                                    DESC
                                                                    ", connection)
        adptr.SelectCommand = command
        tablenew.Clear()

        adptr.Fill(tablenew)
        dgv_resident.DataSource = tablenew

        connection.Close()

    End Sub


    Private Sub txtcp_num_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcp_num.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allownum As String = "0123456789"

            If Not allownum.Contains(e.KeyChar.ToString) Then
                MsgShow("Please input valid cellphone number", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)

                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txt_rl_cnum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_rl_cnum.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allownum As String = "0123456789"

            If Not allownum.Contains(e.KeyChar.ToString) Then
                MsgShow("Please input valid cellphone number", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)

                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click
        If txtlname.Text = Nothing Then
            MsgShow("Please select a resident", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        Else

            pnl_dates.Visible = True

            'para sa combobox ng document
            cmb_doc.Items.Clear()
            connection.Open()
            command = New MySqlCommand("select col_doc_name from tbl_docu where col_availability = 'AVAILABLE'", connection)
            dataReader = command.ExecuteReader

            While dataReader.Read
                Dim col_doc_Name = dataReader.GetString("col_doc_name")
                cmb_doc.Items.Add(col_doc_Name)
            End While
            connection.Close()
        End If
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        pnl_dates.Visible = False
    End Sub


    Private Sub print_Doc_report_PrintPage(sender As Object, e As PrintPageEventArgs) Handles print_Doc_report.PrintPage
        e.Graphics.DrawImage(bg_report.Image, 0, 0, bg_report.Width + 831, bg_report.Height + 1070) ' for image bg for indigent
        Dim font As New Font("Arial", 12, FontStyle.Bold)
        e.Graphics.DrawString(txt_rprt.Text, font, Brushes.Black, 70, 140)

        Dim imagebmap As New Bitmap(Me.dgv_res_req.Width, Me.dgv_res_req.Height)
        dgv_res_req.DrawToBitmap(imagebmap, New Rectangle(0, 0, Me.dgv_res_req.Width, Me.dgv_res_req.Height))
        e.Graphics.DrawImage(imagebmap, 10, 570)
    End Sub
    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        If cmb_doc.Text = Nothing Then
            MsgShow("Please select document type", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        Else
            Dim sug As Integer = MsgShow("Are you sure you want to generate reports between" + vbNewLine + dtp_report_from.Value + " and " + dtp_report_to.Value + " ?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
            If sug = DialogResult.Yes Then
                res_req()

                Dim regDate As Date = Date.Now()
                Dim strDate As String = regDate.ToString("dd")
                Dim strmonth As String = regDate.ToString("MMMM")
                Dim stryear As String = regDate.ToString("yyyy")

                Dim date_now = strmonth + "-" + strDate + "-" + stryear

                txt_rprt.Clear()
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText("DATE: " + date_now)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText("Reports from: " + dtp_report_from.Value.ToString("MMMM-dd-yyyy") + " to " + dtp_report_to.Value.ToString("MMMM-dd-yyyy"))
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText("**********************************************************************************************************" + vbNewLine)
                txt_rprt.AppendText("FULLNAME:" + vbTab + vbTab + txtlname.Text + " " + txtfname.Text + " " + txtmname.Text + vbNewLine)
                txt_rprt.AppendText("ADDRESS:" + vbTab + vbTab + txtaddress.Text + vbNewLine)
                txt_rprt.AppendText("BIRTHDATE:" + vbTab + vbTab + dtpbday.Value.ToString("MMM-dd-yyyy") + vbNewLine)
                txt_rprt.AppendText("BIRTHPLACE:" + vbTab + vbTab + txtplace_bday.Text + vbNewLine)
                txt_rprt.AppendText("SEX:" + vbTab + vbTab + vbTab + cmbgender.Text + vbNewLine)
                txt_rprt.AppendText("CITIZENSHIP:" + vbTab + vbTab + txtctznshp.Text)
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText("**********************************************************************************************************")
                txt_rprt.AppendText(vbNewLine)
                txt_rprt.AppendText("Document Type: " + cmb_doc.Text + vbNewLine)
                txt_rprt.AppendText("")
                print_preview_report.ShowDialog()

            End If
        End If
    End Sub

    Public Sub res_req() ' KAIALANGN KO MAKA PA TEST PAANO MALAGAY ANG MGA REFNUM NA NAKA ;LOOP NA MALAGAY SA TEXT APPEND
        Dim tbl As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("SELECT
                                            col_req_refNum AS 'Reference Number',
                                            col_rqstDOC_purpose AS 'Purpose',
                                            _dateTime AS 'Requested Date & Time'
                                        FROM
                                            tbl_docsreq
                                        WHERE
                                            `_datetime` BETWEEN '" & dtp_report_from.Value.ToString("yyyy/MM/dd") & "' 
                                        AND '" & dtp_report_to.Value.ToString("yyyy/MM/dd") & "'
                                        AND col_rqstDOC_docsType = '" & cmb_doc.Text & "' 
                                               
                                        ORDER BY
                                            `_datetime`
                                        DESC
    
                                            ", connection)
        adptr.SelectCommand = command
        tbl.Clear()

        adptr.Fill(tbl)
        dgv_res_req.DataSource = tbl

        'dgv_docu.Columns(8).DefaultCellStyle.Format = "yyyy-MM-dd" 'para mag format sa timestamp
        connection.Close()
    End Sub

End Class