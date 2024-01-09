Imports MySql.Data.MySqlClient
Imports ShowMessage

Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Net.Mail
Imports System.Drawing.Printing

Public Class Form6
    Public connection As New MySqlConnection("host=localhost; user=root; password=;database=db_brgypotrero;")
    Public adptr As New MySqlDataAdapter
    Public ds As New DataSet


    Dim command As MySqlCommand
    Dim dataReader As MySqlDataReader

    Dim drop As Boolean = True 'para sa pag drop ng panel ng vouching

    Dim cd As New TimeSpan() 'cooldown para auto referesh ng verification ng citizen

    Public Shared txtdocPrice As String 'for fetching docs price 

    Public Shared txtemail As String 'for process grid para sa pag fetch email
    Public Shared txtemail2 As String 'for pick up grid para sa pag fetch email
    Dim txtemail3 As String 'for email of declining of request in pending grid 
    Public Shared toUser As String

    Dim txt_indigent As New TextBox
    Dim txt_residency As New TextBox
    Dim txtIDfront As New TextBox
    Dim txtIDfront_add As New TextBox
    Dim txtIDback As New TextBox

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Fetch_pending() ' for fetching pending request of citizen
        Fetch_processing() ' for fetching processing request of citizen

        Fetch_pickUp() ' for fetching information from pick up table
        fetch_settled()

        Fetch_Declined() ' for fetching Declined request of citizen




    End Sub

    Public Sub Fetch_pending() ' for fetching pending request
        Dim tblpending As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                ID as 'Request ID',
                                                col_rqstDOC_docsType as 'Document Type',
                                                col_rqstDOC_purpose as 'Purpose',
                                                col_rqstDOC_lname as 'Lastname' ,
                                                col_rqstDOC_fname as 'Firstname',
                                                col_rqstDOC_mname as 'Middlename',
                                                col_rqstDOC_bday as 'Birthdate ',
                                                col_req_refNum as 'Reference Number',
                                               
                                                _dateTime as 'Requested Date & Time'
                                                from tbl_docsreq  where col_rqstDOC_action = 'Pending'
                                                ORDER BY `_datetime` DESC", connection)
        adptr.SelectCommand = command
        tblpending.Clear()

        adptr.Fill(tblpending)
        dgv_pndng.DataSource = tblpending
        dgv_pndng.Columns(11).DefaultCellStyle.Format = "yyyy/MM/dd" 'para mag format sa birthdate
        connection.Close()



    End Sub
    Public Sub dgv_fetch_resID() 'para sa process na data
        Dim tbl_ctzn As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                
                                               col_id as 'ID',
                                               col_rsdnt_lname as 'Lastname',     
                                               col_rsdnt_fname as 'Firstname',
                                               col_rsdnt_mname as 'Middlename'
                                      FROM tbl_resident
                                     
                                      WHERE     
                                                 col_rsdnt_lname =  '" & dgv_prccss.SelectedRows(0).Cells(6).Value & "'
                                                 and  col_rsdnt_fname =  '" & dgv_prccss.SelectedRows(0).Cells(7).Value & "'
                                                  and  col_rsdnt_mname =  '" & dgv_prccss.SelectedRows(0).Cells(8).Value & "'
                                      ", connection)
        adptr.SelectCommand = command
        tbl_ctzn.Clear()

        adptr.Fill(tbl_ctzn)
        dgv_res_ID.DataSource = tbl_ctzn
        connection.Close()
    End Sub
    Public Sub Fetch_processing() ' for fetching pending request
        Dim tblprocess As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                tbl_docs_processing.col_ID as 'On-Process ID',
                                                tbl_docsreq.ID as 'Request ID',
                                                tbl_docsreq.col_rqstDOC_docsType as 'Document Type',
                                                tbl_docsreq.col_rqstDOC_purpose as 'Purpose',
                                                tbl_docsreq.col_rqstDOC_lname as 'Lastname' ,
                                                tbl_docsreq.col_rqstDOC_fname as 'Firstname',
                                                tbl_docsreq.col_rqstDOC_mname as 'Middlename',
                                                tbl_docsreq.col_rqstDOC_address as 'Address',


                                                tbl_docsreq.col_rqstDOC_bday as 'Birthdate ',
                                                tbl_docsreq.col_req_refNum as 'Reference Number',
                                                
                                                
                                                tbl_docs_processing._dateTime as 'Accepted Date & Time'
                                                
                                      FROM 
                                                tbl_docsreq  
                                      INNER JOIN
                                                tbl_docs_processing ON tbl_docsreq.ID = tbl_docs_processing.col_reqID
                                      WHERE     
                                                col_action = 'Processing' OR col_action = 'Retrieve'
                                      ORDER BY 
                                                tbl_docs_processing._dateTime DESC
        ", connection)
        adptr.SelectCommand = command
        tblprocess.Clear()

        adptr.Fill(tblprocess)
        dgv_prccss.DataSource = tblprocess

        connection.Close()

    End Sub

    Public Sub Fetch_pickUp() ' for fetching information from pick up table
        Dim tblpickup As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                tbl_docs_pickup.col_ID as 'On-Pick ID',
                                                tbl_docsreq.ID as 'Request ID',
                                                tbl_docsreq.col_rqstDOC_docsType as 'Document Type',
                                                tbl_docsreq.col_rqstDOC_purpose as 'Purpose',
                                                tbl_docsreq.col_rqstDOC_lname as 'Lastname' ,
                                                tbl_docsreq.col_rqstDOC_fname as 'Firstname',
                                                tbl_docsreq.col_rqstDOC_mname as 'Middlename',
                                                tbl_docsreq.col_rqstDOC_address as 'Address',


                                                tbl_docsreq.col_rqstDOC_bday as 'Birthdate ',
                                                tbl_docsreq.col_req_refNum as 'Reference Number',
                                                
                                                tbl_docs_pickup._dateTime as 'Set for pick up'
                                                
                                      FROM 
                                                tbl_docsreq  
                                      INNER JOIN
                                                tbl_docs_pickup ON tbl_docsreq.ID = tbl_docs_pickup.col_req_ID
                                      WHERE     
                                                tbl_docs_pickup.col_action = 'To Pick-up'
                                      
                                      ORDER BY 
                                                tbl_docs_pickup._dateTime DESC
        ", connection)
        adptr.SelectCommand = command
        tblpickup.Clear()

        adptr.Fill(tblpickup)
        dgv_pickUP.DataSource = tblpickup

        connection.Close()
    End Sub

    Public Sub fetch_settled()
        Dim tblsettled As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                tbl_docs_settled.col_ID as 'Settled ID',
                                                tbl_docsreq.ID as 'Request ID',
                                                tbl_docsreq.col_rqstDOC_docsType as 'Document Type',
                                                tbl_docsreq.col_req_refNum as 'Reference Number',
                                                tbl_docs_settled.col_validation as 'Valid Until',
                                                tbl_docsreq.col_rqstDOC_purpose as 'Purpose',
                                                tbl_docsreq.col_rqstDOC_lname as 'Lastname' ,
                                                tbl_docsreq.col_rqstDOC_fname as 'Firstname',
                                                tbl_docsreq.col_rqstDOC_mname as 'Middlename',
                                                
                                                
                                                
                                                tbl_docs_settled._dateTime as 'Settled pick up'
                                                
                                      FROM 
                                                tbl_docsreq  
                                      INNER JOIN
                                                tbl_docs_settled ON tbl_docsreq.ID = tbl_docs_settled.col_req_ID
                                      
                                      ORDER BY 
                                                tbl_docs_settled._dateTime DESC
        ", connection)
        adptr.SelectCommand = command
        tblsettled.Clear()

        adptr.Fill(tblsettled)
        dgv_settled.DataSource = tblsettled

        connection.Close()
    End Sub



    Public Sub Fetch_Declined() ' for fetching pending request
        Dim tbldeclined As New DataTable

        connection.Close()
        connection.Open()
        'command = New MySqlCommand("select 
        '                                        tbl_docs_declined.ID as 'Declined ID',
        '                                        tbl_docsreq.ID as 'Request ID',
        '                                        tbl_docsreq.col_rqstDOC_docsType as 'Document Type',
        '                                        tbl_docsreq.col_rqstDOC_purpose as 'Purpose',
        '                                        tbl_docsreq.col_rqstDOC_lname as 'Lastname' ,
        '                                        tbl_docsreq.col_rqstDOC_fname as 'Firstname',
        '                                        tbl_docsreq.col_rqstDOC_mname as 'Middlename',
        '                                        tbl_docsreq.col_rqstDOC_address as 'Address',

        '                                        tbl_docsreq.col_rqstDOC_cnum as 'Cellphone Number',


        '                                        tbl_docsreq.col_rqstDOC_bday as 'Birthdate ',

        '                                        tbl_docsreq.col_req_refNum as 'Reference Number',

        '                                        tbl_docs_declined._dateTime as 'Declined Date & Time'

        '                              FROM 
        '                                        tbl_docsreq  
        '                              INNER JOIN
        '                                        tbl_docs_declined ON tbl_docsreq.ID = tbl_docs_declined.col_reqID
        '                              WHERE     
        '                                        col_action = 'Declined'
        '                              ORDER BY 
        '                                        tbl_docs_declined._dateTime DESC

        '                               ", connection)


        command = New MySqlCommand("select 
                                                tbl_docs_declined.ID as 'Declined ID',
                                                tbl_docsreq.ID as 'Request ID',
                                                tbl_docs_declined.col_remarks as 'Reason for Declining',
                                                tbl_docsreq.col_rqstDOC_docsType as 'Document Type',
                                                tbl_docsreq.col_rqstDOC_purpose as 'Purpose',
                                                tbl_docsreq.col_rqstDOC_lname as 'Lastname' ,
                                                tbl_docsreq.col_rqstDOC_fname as 'Firstname',
                                                tbl_docsreq.col_rqstDOC_mname as 'Middlename',
                                                tbl_docsreq.col_rqstDOC_address as 'Address',

                                              
                                                tbl_docsreq.col_req_refNum as 'Reference Number',
                                                
                                                tbl_docs_declined._dateTime as 'Declined Date & Time'  
                                                
                                      FROM 
                                                tbl_docsreq  
                                      INNER JOIN
                                                tbl_docs_declined ON tbl_docsreq.ID = tbl_docs_declined.col_reqID
                                      WHERE     
                                                col_action = 'Declined'
                                      ORDER BY 
                                                tbl_docs_declined._dateTime DESC
                                      
                                       ", connection)

        adptr.SelectCommand = command
        tbldeclined.Clear()

        adptr.Fill(tbldeclined)
        dgvDecline.DataSource = tbldeclined

        connection.Close()

    End Sub



    Private Sub dgvDecline_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDecline.CellContentClick
        If dgvDecline.Columns(e.ColumnIndex).Name = "btn_dgv_retrieve" Then
            'MessageBox.Show("Are you sure want to RETRIEVE this?", "Retrieve Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Dim retrieve As Integer = MsgShow("Are you sure want to RETRIEVE this?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
            If retrieve = DialogResult.Yes Then


                'PARA SA PAF UPDATE NG ACTION SA DGV DECLINe (to retrieve)

                connection.Close()
                connection.Open()
                command = New MySqlCommand("UPDATE tbl_docs_declined SET col_action = 'Retrieve'
                                                WHERE ID='" & dgvDecline.SelectedRows(0).Cells(1).Value & "'", connection)
                dataReader = command.ExecuteReader
                connection.Close()
                'PARA SA PAF UPDATE NG ACTION SA DGV DECLINe(to retrieve)  (END)

                'PARA SA PAG UPDATE NG PENDING REQUEST TABLE TO RETRIEVE 
                connection.Close()
                connection.Open()
                command = New MySqlCommand("UPDATE tbl_docsreq SET col_rqstDOC_action = 'Pending'
                                                WHERE ID='" & dgvDecline.SelectedRows(0).Cells(2).Value & "'", connection)
                dataReader = command.ExecuteReader
                connection.Close()
                'PARA SA PAG UPDATE NG PENDING REQUEST TABLE TO RETRIEVE  (END)


                'ACTIVITY LOG
                Dim regDate As Date = Date.Now()
                Dim str_hr As String = regDate.ToString("HH")
                Dim str_min As String = regDate.ToString("mm")
                Dim str_sec As String = regDate.ToString("ss")

                Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "


                connection.Close()
                connection.Open()
                command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
                command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
                command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully retrieved " & dgvDecline.SelectedRows(0).Cells(7).Value.ToString.ToUpper & "'s request of '" & dgvDecline.SelectedRows(0).Cells(4).Value.ToString.ToUpper & "'"
                command.ExecuteNonQuery()
                connection.Close()



                MsgShow("Resident's request information has been " + vbNewLine + "retrieve successfully ", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                'MessageBox.Show("Citizen Request Retrieve Successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)


                'Fetch_processing()
                Fetch_Declined()
                Fetch_pending()
                Form3.chrtDocs()
                verify_ctzn()


            End If
        End If
    End Sub



    Public Sub verify_ctzn() 'para verify if registered ba ang citizen or hindi

        Dim font As New Font("Times New Roman", 10, FontStyle.Bold)
        For citizen = 0 To dgv_pndng.Rows.Count - 1
            connection.Close()
            connection.Open()
            command = New MySqlCommand("select * from tbl_resident where col_rsdnt_lname='" & dgv_pndng.Rows(citizen).Cells(7).Value & "'
                     and col_rsdnt_fname ='" & dgv_pndng.Rows(citizen).Cells(8).Value & "' and col_rsdnt_mname = '" & dgv_pndng.Rows(citizen).Cells(9).Value & "'", connection)
            dataReader = command.ExecuteReader
            Dim person As Integer
            person = 0
            While dataReader.Read
                person = person + 1
            End While

            If person >= 1 Then

                dgv_pndng.Rows(citizen).Cells(3).Style.ForeColor = Color.LightGreen
                dgv_pndng.Rows(citizen).Cells(3).Style.Font = font
                dgv_pndng.Rows(citizen).Cells(3).Value = "Verified"

            Else
                dgv_pndng.Rows(citizen).Cells(3).Style.ForeColor = Color.Tomato
                dgv_pndng.Rows(citizen).Cells(3).Style.Font = font
                dgv_pndng.Rows(citizen).Cells(3).Value = "Not - Verified"
            End If
            connection.Close()
        Next
    End Sub


    Private Sub dgv_pndng_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_pndng.CellContentClick
        If e.RowIndex < 0 Then Exit Sub

        dtpbday.Value = CDate(dgv_pndng.Item(10, e.RowIndex).Value)


        If dgv_pndng.Columns(e.ColumnIndex).Name = "btn_dgv_accept" Then

            'MessageBox.Show("Are you sure want to Accept this Request?", "Accept Request?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Dim Accept As Integer = MsgShow("Are you sure want to Accept this Request?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
            'PARA SA PAG UPDATE NG ACTION TABLE TO PROCCESSING
            '(PARA MA FILTER ANG DATAGRID FOR PENDING DATA )
            If Accept = DialogResult.Yes Then
                If dgv_pndng.SelectedRows(0).Cells(3).Value = "Verified" Then
                    connection.Close()
                    connection.Open()
                    command = New MySqlCommand("UPDATE tbl_docsreq SET col_rqstDOC_action = 'Processing'
                                                WHERE ID='" & dgv_pndng.SelectedRows(0).Cells(4).Value & "'", connection)
                    dataReader = command.ExecuteReader
                    connection.Close()
                    'PARA SA PAG UPDATE NG ACTION TABLE TO PROCCESSING (END)


                    'PARA SA PAG INSERT SA PROCESSING TBL
                    connection.Close()
                    connection.Open()
                    command = New MySqlCommand("Insert into tbl_docs_processing
                                   (col_reqID, col_action)
                             values 
                                    (@REQ_ID, @action)", connection)

                    command.Parameters.Add(New MySqlParameter("@REQ_ID", MySqlDbType.VarChar, 50)).Value = dgv_pndng.SelectedRows(0).Cells(4).Value
                    command.Parameters.Add(New MySqlParameter("@action", MySqlDbType.VarChar, 50)).Value = "Processing"


                    command.ExecuteNonQuery()
                    connection.Close()



                    'ACTIVITY LOG

                    Dim regDate As Date = Date.Now()
                    Dim str_hr As String = regDate.ToString("HH")
                    Dim str_min As String = regDate.ToString("mm")
                    Dim str_sec As String = regDate.ToString("ss")

                    Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "
                    connection.Close()
                    connection.Open()
                    command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
                    command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
                    command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully accepted " & dgv_pndng.SelectedRows(0).Cells(8).Value.ToString.ToUpper & "'s request of '" & dgv_pndng.SelectedRows(0).Cells(5).Value.ToString.ToUpper & "'"
                    command.ExecuteNonQuery()
                    connection.Close()


                    'PARA SA PAG INSERT SA PROCESSING TBL (END)
                    MsgShow("Request information was successfully ACCEPTED!", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                    'MessageBox.Show("You Successfully Accepted the citizen request", "Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Fetch_pending()
                    Fetch_processing()
                    verify_ctzn()
                    Form3.chrtDocs()



                Else 'PAG HINDI VERIFIED (wala sa db for info ctzn) ANG NAG REQUEST
                    MsgShow("This request information is " + vbNewLine + "not registered as barangay resident!", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
                    'MessageBox.Show("This Citizen is not registered as Citizen.", "Citizen Not Verified", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    Dim sug As Integer = MsgShow("Do you wish to ADD this information " + vbNewLine + " to barangay resident and proceed?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
                    If sug = DialogResult.Yes Then

                        'PARA SA PAG UPDATE NG ACTION TABLE TO PROCCESSING
                        connection.Close()
                        connection.Open()
                        command = New MySqlCommand("UPDATE tbl_docsreq SET col_rqstDOC_action = 'Processing'
                                                WHERE ID='" & dgv_pndng.SelectedRows(0).Cells(4).Value & "'", connection)
                        dataReader = command.ExecuteReader
                        connection.Close()
                        'PARA SA PAG UPDATE NG ACTION TABLE TO PROCCESSING (END)


                        'PARA SA PAG INSERT SA PROCESSING TBL
                        connection.Close()
                        connection.Open()
                        command = New MySqlCommand("Insert into tbl_docs_processing
                                   (col_reqID, col_action)
                             values 
                                    (@REQ_ID, @action)", connection)

                        command.Parameters.Add(New MySqlParameter("@REQ_ID", MySqlDbType.VarChar, 50)).Value = dgv_pndng.SelectedRows(0).Cells(4).Value
                        command.Parameters.Add(New MySqlParameter("@action", MySqlDbType.VarChar, 50)).Value = "Processing"


                        command.ExecuteNonQuery()
                        connection.Close()

                        'PARA SA PAG INSERT SA PROCESSING TBL (END)

                        'PARA SA PAG INSERT NG D REGISTERED NA NAG REQUEST NA CITIZEN

                        connection.Open()
                        command = New MySqlCommand("Select * from tbl_docsreq where ID = '" & dgv_pndng.SelectedRows(0).Cells(4).Value & "'", connection)
                        dataReader = command.ExecuteReader

                        If dataReader.Read Then
                            Dim address = dataReader.GetString("col_rqstDOC_address")
                            Dim year = dataReader.GetString("col_rqstDOC_year")
                            Dim cnum = dataReader.GetString("col_rqstDOC_cnum")
                            Dim ctznshp = dataReader.GetString("col_rqstDOC_ctznshp")
                            Dim pday = dataReader.GetString("col_rqstDOC_pday")
                            Dim spouse = dataReader.GetString("col_rqstDOC_spouse")
                            Dim child = dataReader.GetString("col_rqstDOC_childrens")
                            Dim res_type = dataReader.GetString("col_rqstDOC_residency")
                            Dim gender = dataReader.GetString("col_rqstDOC_gender")
                            Dim status = dataReader.GetString("col_rqstDOC_status")

                            connection.Close()
                            connection.Open()
                            command = New MySqlCommand("Insert into tbl_resident
                                   (col_rsdnt_lname, col_rsdnt_fname, col_rsdnt_mname, col_rsdnt_address, col_rsdnt_year, col_rsdnt_cnum, col_rsdnt_ctznshp
                                     ,col_rsdnt_bday, col_rsdnt_pday, col_rsdnt_spouse, col_rsdnt_childrens, col_rsdnt_residency, col_rsdnt_gender, col_rsdnt_status,
                                    col_rsdnt_health)
                             values 
                                    (@lname, @fname,@mname,@address, @yr, @cnum, @ctznshp, @bday, @pday, @spouse, @childs, @res_type, @gender, @status, @health)", connection)

                            command.Parameters.Add(New MySqlParameter("@lname", MySqlDbType.VarChar, 50)).Value = dgv_pndng.SelectedRows(0).Cells(7).Value
                            command.Parameters.Add(New MySqlParameter("@fname", MySqlDbType.VarChar, 50)).Value = dgv_pndng.SelectedRows(0).Cells(8).Value
                            command.Parameters.Add(New MySqlParameter("@mname", MySqlDbType.VarChar, 50)).Value = dgv_pndng.SelectedRows(0).Cells(9).Value
                            command.Parameters.Add(New MySqlParameter("@address", MySqlDbType.VarChar, 50)).Value = address
                            command.Parameters.Add(New MySqlParameter("@yr", MySqlDbType.VarChar, 50)).Value = year
                            command.Parameters.Add(New MySqlParameter("@cnum", MySqlDbType.VarChar, 50)).Value = cnum
                            command.Parameters.Add(New MySqlParameter("@ctznshp", MySqlDbType.VarChar, 50)).Value = ctznshp
                            command.Parameters.Add(New MySqlParameter("@bday", dtpbday.Value.Date))
                            command.Parameters.Add(New MySqlParameter("@pday", MySqlDbType.VarChar, 50)).Value = pday
                            command.Parameters.Add(New MySqlParameter("@spouse", MySqlDbType.VarChar, 50)).Value = spouse
                            command.Parameters.Add(New MySqlParameter("@childs", MySqlDbType.VarChar, 50)).Value = child
                            command.Parameters.Add(New MySqlParameter("@res_type", MySqlDbType.VarChar, 50)).Value = res_type
                            command.Parameters.Add(New MySqlParameter("@gender", MySqlDbType.VarChar, 50)).Value = gender
                            command.Parameters.Add(New MySqlParameter("@status", MySqlDbType.VarChar, 50)).Value = status
                            command.Parameters.Add(New MySqlParameter("@health", MySqlDbType.VarChar, 50)).Value = "Healthy"


                            command.ExecuteNonQuery()
                            connection.Close()





                            'ACTIVITY LOG

                            Dim regDate As Date = Date.Now()
                            Dim str_hr As String = regDate.ToString("HH")
                            Dim str_min As String = regDate.ToString("mm")
                            Dim str_sec As String = regDate.ToString("ss")

                            Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "
                            connection.Close()
                            connection.Open()
                            command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
                            command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
                            command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully accepted " & dgv_pndng.SelectedRows(0).Cells(8).Value.ToString.ToUpper & "'s request of '" & dgv_pndng.SelectedRows(0).Cells(5).Value.ToString.ToUpper & "' and added as resident"
                            command.ExecuteNonQuery()
                            connection.Close()


                            'MessageBox.Show("Citizen has now Officially Registered and Accepted", "Citizen Now Verified", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            MsgShow("Person's information is now officially " + vbNewLine + "REGISTERED and ACCEPTED!", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                            'PARA SA PAG INSERT NG D REGISTERED NA NAG REQUEST NA CITIZEN (END)
                            Fetch_pending()
                            Fetch_processing()
                            verify_ctzn()
                            Form3.chrtDocs()

                        Else
                            MsgShow("Unexpected error. Please contact the developer immediately!", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
                        End If

                    End If
                End If
            End If

        ElseIf dgv_pndng.Columns(e.ColumnIndex).Name = "btn_dgv_decline" Then
            'MessageBox.Show("Are you sure want to Decline this?", "Declined Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Dim decline As Integer = MsgShow("Are you sure want to DECLINE this request?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
            If decline = DialogResult.Yes Then

                pnl_pndng_reason.Visible = True




            End If
        ElseIf dgv_pndng.Columns(e.ColumnIndex).Name = "dgv_btn_vouch" Then

            Dim tbl_vouch As New DataTable
            'Dim dgv_vouch As New DataGridView ' new datagrid to hold the fetch image
            'Dim PB_fetchVouch As New PictureBox

            connection.Close()
            connection.Open()
            command = New MySqlCommand("select 
                                                ctzn_col_vouch
                                        FROM tbl_docsreq
                                       WHERE ID = '" & dgv_pndng.SelectedRows(0).Cells(4).Value & "'", connection)
            adptr.SelectCommand = command
            tbl_vouch.Clear()

            adptr.Fill(tbl_vouch)
            gvgv.DataSource = tbl_vouch
            connection.Close()

            Dim bytes As Byte() = gvgv.CurrentRow.Cells(0).Value
            Using ms As New MemoryStream(bytes)
                PB_pic_vouch.Image = Image.FromStream(ms)
            End Using





            pnl_vouch.Visible = True
            time_vouch.Start()
        End If
    End Sub


    Private Sub btn_ok_pndng_Click(sender As Object, e As EventArgs) Handles btn_ok_pndng.Click
        If txt_pndng_reasonDeclining.Text = Nothing Then
            MsgShow("Please indicate the reason for declining", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)

        Else
            subb_fetch_pndng() 'mag fetch sa information ng selected ctzn sa dgv

            'para mag fetch ng email sa usernmae ng nag log in sa mobile app
            connection.Close()

            connection.Open()
            command = New MySqlCommand("Select * from tbl_ctzn where ctzn_col_uname = '" & dgv_fetch_pndngALLINFO.SelectedRows(0).Cells(20).Value & "'", connection)
            dataReader = command.ExecuteReader

            While dataReader.Read
                Dim email = dataReader.GetString("ctzn_col_email")
                txtemail3 = email

            End While
            connection.Close()

            Dim from, pass, messagebody As String
            Dim message As MailMessage = New MailMessage()
            Dim user = txtemail3
            from = "bargypotrero@gmail.com"
            pass = "dwkptjkiayczsawe"
            messagebody = vbTab + "Your requested document '" & dgv_pndng.SelectedRows(0).Cells(5).Value.ToString.ToUpper & "' with reference number '" +
                dgv_fetch_pndngALLINFO.SelectedRows(0).Cells(21).Value.ToString + "' was declined for the reason of '" + txt_pndng_reasonDeclining.Text.ToUpper + "'." + vbNewLine + vbNewLine +
                vbTab + "If for you this was a mistake, please contact immediately to our barangay hotline: 395-1848 / 0919-999-8476." + vbNewLine + vbNewLine + vbNewLine +
                    "Have a great day ahead!"


            message.To.Add(user)
            message.From = New MailAddress(from)
            message.Body = messagebody
            message.Subject = "Request Declined"
            Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com")
            smtp.EnableSsl = True
            smtp.Port = 587
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.UseDefaultCredentials = False
            smtp.Credentials = New NetworkCredential(from, pass)
            Try
                smtp.Send(message)

                'PARA SA PAG UPDATE NG ACTION TABLE TO DECLINED
                connection.Close()
                connection.Open()
                command = New MySqlCommand("UPDATE tbl_docsreq SET col_rqstDOC_action = 'Declined'
                                                WHERE ID='" & dgv_pndng.SelectedRows(0).Cells(4).Value & "'", connection)
                dataReader = command.ExecuteReader
                connection.Close()
                'PARA SA PAG UPDATE NG ACTION TABLE TO DECLINED (END)



                'PARA SA PAG INSERT SA DECLINED TBL
                connection.Close()
                connection.Open()
                command = New MySqlCommand("Insert into tbl_docs_declined 
                                   (col_reqID, col_action, col_remarks)
                             values 
                                    (@REQ_ID, @action, @remarks)", connection)

                command.Parameters.Add(New MySqlParameter("@REQ_ID", MySqlDbType.VarChar, 50)).Value = dgv_pndng.SelectedRows(0).Cells(4).Value
                command.Parameters.Add(New MySqlParameter("@remarks", MySqlDbType.VarChar, 50)).Value = txt_pndng_reasonDeclining.Text
                command.Parameters.Add(New MySqlParameter("@action", MySqlDbType.VarChar, 50)).Value = "Declined"

                command.ExecuteNonQuery()
                connection.Close()
                'PARA SA PAG INSERT SA DECLINED TBL (END)

                'ACTIVITY LOG
                Dim regDate As Date = Date.Now()
                Dim str_hr As String = regDate.ToString("HH")
                Dim str_min As String = regDate.ToString("mm")
                Dim str_sec As String = regDate.ToString("ss")

                Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "

                connection.Close()
                connection.Open()
                command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
                command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
                command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully declined " & dgv_pndng.SelectedRows(0).Cells(8).Value.ToString.ToUpper & "'s request of '" & dgv_pndng.SelectedRows(0).Cells(5).Value.ToString.ToUpper & "' for the reason of '" & txt_pndng_reasonDeclining.Text.ToString.ToUpper & "'"
                command.ExecuteNonQuery()
                connection.Close()




                'MessageBox.Show("Citizen Request Declined Successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MsgShow("Request information has been declined successfully!", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                Fetch_pending()
                Fetch_Declined()
                verify_ctzn()
                txt_pndng_reasonDeclining.Clear()
                pnl_pndng_reason.Visible = False
                Form3.chrtDocs()


            Catch

                MsgShow("Please check your internet connection!", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)



            End Try

        End If



    End Sub




    Private Sub time_vouch_Tick(sender As Object, e As EventArgs) Handles time_vouch.Tick
        'for dropping panel for viewing vouch reference
        If drop Then
            pnl_vouch.Height += 10
            If pnl_vouch.Size = pnl_vouch.MaximumSize Then
                time_vouch.Stop()
                drop = False
                btn_VOUCH_X.Visible = True
            End If
        End If
    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles btn_VOUCH_X.Click
        pnl_vouch.Size = pnl_vouch.MinimumSize
        pnl_vouch.Hide()
        PB_pic_vouch.Image = Nothing
        btn_VOUCH_X.Visible = False
        drop = True
    End Sub
    Private Sub Print_Doc_Indigent_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Print_Doc_Indigent.PrintPage
        e.Graphics.DrawImage(PB_BG_Indigent.Image, 0, 0, PB_BG_Indigent.Width + 831, PB_BG_Indigent.Height + 1070) ' for image bg for indigent
        Dim font As New Font("Arial", 13.5, FontStyle.Bold)
        e.Graphics.DrawString(txt_indigent.Text, font, Brushes.Black, 70, 140)
    End Sub
    Public Sub docuIndigent()
        Dim regDate As Date = Date.Now()
        Dim strDate As String = regDate.ToString("dd")
        Dim strmonth As String = regDate.ToString("MMMM")

        txt_indigent.Clear()
        txt_indigent.AppendText(dgv_prcss_ctznpic.SelectedRows(0).Cells(21).Value.ToString + vbNewLine)
        txt_indigent.AppendText("Resident ID: " + dgv_res_ID.SelectedRows(0).Cells(0).Value.ToString.ToUpper)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        'para sa fullname
        txt_indigent.AppendText(vbTab + vbTab + vbTab + vbTab + dgv_prcss_ctznpic.SelectedRows(0).Cells(3).Value.ToString.ToUpper + ", " + dgv_prcss_ctznpic.SelectedRows(0).Cells(4).Value.ToString.ToUpper + " " + dgv_prcss_ctznpic.SelectedRows(0).Cells(5).Value.ToString.ToUpper)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        'para sa address
        txt_indigent.AppendText("      " + dgv_prcss_ctznpic.SelectedRows(0).Cells(6).Value.ToString.ToUpper)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)

        'para sa purpose
        txt_indigent.AppendText(vbTab + vbTab + "    " + dgv_prcss_ctznpic.SelectedRows(0).Cells(18).Value.ToString)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        'para sa date today
        txt_indigent.AppendText(vbTab + vbTab + "            " + strDate.ToString.ToUpper + vbTab + "   " + strmonth.ToString.ToUpper + " " + Now.Year.ToString)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbNewLine)
        txt_indigent.AppendText(vbTab + vbTab + vbTab + vbTab + vbTab + "          HON. SHERYL C. NOLASCO, MPA")


        PrintPreview_Indigent.ShowDialog()
    End Sub

    Public Sub docuClearnce()
        'FOR DATEBIRTH
        Dim regDate As Date = dgv_prcss_ctznpic.SelectedRows(0).Cells(10).Value.ToString
        Dim strDate As String = regDate.ToString("dd")
        Dim strmonth As String = regDate.ToString("MMM")
        Dim stryear As String = regDate.ToString("yyy")

        ' FOR DATE ISSUED
        Dim DateNOW As Date = Date.Now
        Dim dtnow As String = DateNOW.ToString("dd")
        Dim dtrmonth As String = DateNOW.ToString("MMM")
        Dim dtyear As String = DateNOW.ToString("yyy")


        txt_DOCU_Clearance.Clear()

        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + vbTab + vbTab + vbTab + vbTab + vbTab + "Resident ID: " + dgv_res_ID.SelectedRows(0).Cells(0).Value.ToString.ToUpper + vbNewLine)
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + vbTab + vbTab + vbTab + vbTab + vbTab + "Reference Number: " + dgv_prcss_ctznpic.SelectedRows(0).Cells(21).Value.ToString)

        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        'for fullname
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + dgv_prcss_ctznpic.SelectedRows(0).Cells(3).Value.ToString.ToUpper + vbTab + dgv_prcss_ctznpic.SelectedRows(0).Cells(4).Value.ToString.ToUpper + vbTab + dgv_prcss_ctznpic.SelectedRows(0).Cells(5).Value.ToString.ToUpper)
        ''for address
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + "  " + dgv_prcss_ctznpic.SelectedRows(0).Cells(6).Value.ToString.ToUpper)
        ' for bday and pday
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        ' for bday and pday
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + "          " + strmonth + "/" + strDate + "/" + stryear + vbTab + vbTab + "                   " + dgv_prcss_ctznpic.SelectedRows(0).Cells(11).Value.ToString)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        'for sex and civil stats 
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + "       " + dgv_prcss_ctznpic.SelectedRows(0).Cells(15).Value.ToString.ToUpper + vbTab + vbTab + vbTab + "     " + dgv_prcss_ctznpic.SelectedRows(0).Cells(16).Value.ToString)

        txt_DOCU_Clearance.AppendText(vbNewLine)
        'for nationality
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + "      " + dgv_prcss_ctznpic.SelectedRows(0).Cells(9).Value.ToString.ToUpper)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        'for purpose
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + "  " + dgv_prcss_ctznpic.SelectedRows(0).Cells(18).Value.ToString.ToUpper)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)

        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + "   Potrero Barangay Hall")
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + "   " + dtrmonth + " / " + dtnow + " / " + dtyear)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbNewLine)
        txt_DOCU_Clearance.AppendText(vbTab + vbTab + vbTab + vbTab + "   HON. SHERYL C. NOLASCO, MPA")

        print_preview_clearance.ShowDialog()
    End Sub

    Private Sub print_Doc_clearance_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles print_Doc_clearance.PrintPage



        Dim pb_ctzn As New PictureBox 'fetch image from information of request ctzn
        Dim bytes As Byte() = dgv_prcss_ctznpic.CurrentRow.Cells(2).Value
        Using ms As New MemoryStream(bytes)
            pb_ctzn.Image = Image.FromStream(ms)
        End Using



        e.Graphics.DrawImage(pb_bg_clearance.Image, 0, 0, pb_bg_clearance.Width + 990, pb_bg_clearance.Height + 790) ' for image bg clearance
        Dim font As New Font("Times New Roman", 14, FontStyle.Bold) ' for font style
        e.Graphics.DrawString(txt_DOCU_Clearance.Text, font, Brushes.Black, 90, 43)

        e.Graphics.DrawImage(pb_ctzn.Image, 870, 273, pb_ctzn.Width + 78, pb_ctzn.Height + 116) ' for image from datagrid
    End Sub
    Private Sub Print_doc_residency_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Print_doc_residency.PrintPage
        e.Graphics.DrawImage(pb_bg_residency.Image, 0, 0, PB_BG_Indigent.Width + 831, PB_BG_Indigent.Height + 1070) ' for image bg for indigent
        Dim font As New Font("Arial", 12, FontStyle.Bold)
        e.Graphics.DrawString(txt_residency.Text, font, Brushes.Black, 70, 140)
    End Sub

    Public Sub docuResidency()

        ' FOR DATE ISSUED
        Dim DateNOW As Date = Date.Now
        Dim dtnow As String = DateNOW.ToString("dd")
        Dim dtrmonth As String = DateNOW.ToString("MMM")
        Dim dtyear As String = DateNOW.ToString("yyy")

        txt_residency.Clear()

        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText("Resident ID: " + dgv_res_ID.SelectedRows(0).Cells(0).Value.ToString.ToUpper)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        'fullname (LASTNAME, FIRSTNAME, MIDDLENAME)
        txt_residency.AppendText(vbTab + vbTab + vbTab + "         " + dgv_prccss.SelectedRows(0).Cells(6).Value.ToString.ToUpper + "," + dgv_prccss.SelectedRows(0).Cells(7).Value.ToString.ToUpper + " " + dgv_prccss.SelectedRows(0).Cells(8).Value.ToString.ToUpper)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        'Full ADdress
        txt_residency.AppendText(vbTab + dgv_prccss.SelectedRows(0).Cells(9).Value.ToString.ToUpper)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        'PURPOSE
        txt_residency.AppendText(vbTab + vbTab + vbTab + "      " + dgv_prccss.SelectedRows(0).Cells(5).Value.ToString.ToUpper)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        txt_residency.AppendText(vbNewLine)
        'DATE ISSUED
        txt_residency.AppendText(vbTab + vbTab + dtnow + vbTab + vbTab + "    " + dtrmonth + ", " + dtyear)
        print_preview_residency.ShowDialog()
    End Sub


    Private Sub print_docu_ID_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles print_docu_ID.PrintPage

        Static page As Integer = 1
        If page = 1 Then


            e.Graphics.DrawImage(bf_ID_FRONT.Image, 0, 0, bf_ID_FRONT.Width + 831, bf_ID_FRONT.Height + 1070) ' for image bg for indigent
            Dim font As New Font("San-serif", 25, FontStyle.Bold)
            e.Graphics.DrawString(txtIDfront.Text, font, Brushes.Black, 70, 140)

            Dim font_add As New Font("San-serif", 22, FontStyle.Bold) ' for address
            e.Graphics.DrawString(txtIDfront_add.Text, font_add, Brushes.Black, 70, 140)

            Dim pb_ctzn As New PictureBox 'fetch image from information of request ctzn
            Dim bytes As Byte() = dgv_prcss_ctznpic.CurrentRow.Cells(2).Value
            Using ms As New MemoryStream(bytes)
                pb_ctzn.Image = Image.FromStream(ms)
            End Using
            e.Graphics.DrawImage(pb_ctzn.Image, 335, 260, pb_ctzn.Width + 183, pb_ctzn.Height + 220) ' for image from datagrid


            page = 1
            e.HasMorePages = False
            page += 1
            e.HasMorePages = True
            Return
        End If

        If page = 2 Then
            e.Graphics.DrawImage(BG_ID_BACK.Image, 0, 0, BG_ID_BACK.Width + 831, BG_ID_BACK.Height + 1070) ' for image bg for indigent
            Dim font As New Font("San-serif", 20, FontStyle.Bold)
            e.Graphics.DrawString(txtIDback.Text, font, Brushes.Black, 70, 134)


            page = 1
            e.HasMorePages = False
        End If
    End Sub
    Public Sub docuID()
        ' FOR DATE ISSUED
        Dim DateNOW As Date = Date.Now
        Dim dtnow As String = DateNOW.ToString("dd")
        Dim dtrmonth As String = DateNOW.ToString("MMM")
        Dim dtyear As String = DateNOW.ToString("yyy")

        txtIDfront.Clear()

        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)

        'LASTNAME
        txtIDfront.AppendText(vbTab + vbTab + dgv_prccss.SelectedRows(0).Cells(6).Value.ToString.ToUpper + ", ")
        txtIDfront.AppendText(vbNewLine)
        'FIRSTNAME MIDDLENAME
        txtIDfront.AppendText("                 " + dgv_prccss.SelectedRows(0).Cells(7).Value.ToString.ToUpper + "  " + dgv_prccss.SelectedRows(0).Cells(8).Value.ToString.ToUpper)



        'FOR ADDRESS TEXT (HINIWALAY KO PARA SA FRONT ID KASI MASYADO MALAKI ANG FONT)
        txtIDfront_add.Clear()
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbTab + vbTab + "Resident ID: " + dgv_res_ID.SelectedRows(0).Cells(0).Value.ToString.ToUpper + vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront_add.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        'addreess
        txtIDfront_add.AppendText("      " + dgv_prccss.SelectedRows(0).Cells(9).Value.ToString.ToUpper)


        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)
        txtIDfront.AppendText(vbNewLine)

        'FOR DATEBIRTH
        Dim regDate As Date = dgv_prccss.SelectedRows(0).Cells(10).Value.ToString
        Dim strDate As String = regDate.ToString("dd")
        Dim strmonth As String = regDate.ToString("MMM")
        Dim stryear As String = regDate.ToString("yyy")

        txtIDfront.AppendText(vbTab + vbTab + strmonth + "-" + strDate + "-" + stryear)

        'FOR DATEBIRTH
        Dim rDate As Date = Date.Now
        Dim sDate As String = regDate.ToString("dd")
        Dim smonth As String = regDate.ToString("MMM")
        Dim syear As String = regDate.ToString("yyy")

        Dim valid_Date As Date = Date.Now.AddMonths(6) 'para sa validation ng docu pag add ng 6 months

        'FOR BACK ID
        txtIDback.Clear()
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)

        txtIDback.AppendText("        HON. SHERYL C. NOLASCO, MPA")
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbNewLine)
        txtIDback.AppendText(vbTab + vbTab + valid_Date.ToString("MMMM-dd-yyyy"))
        Print_prev_ID.ShowDialog()
    End Sub
    Private Sub dgv_prccss_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_prccss.CellContentClick

        If dgv_prccss.Columns(e.ColumnIndex).Name = "btn_Set_up" Then
            dgv_fetch_resID() 'mag fetch ng resident id
            dgv_fetch_prccsss() 'mag fetch sa information ng selected ctzn sa dgv
            If dgv_prccss.SelectedRows(0).Cells(4).Value = "Barangay Clearance" Then
                docuClearnce()
            ElseIf dgv_prccss.SelectedRows(0).Cells(4).Value = "Certificate of Indigency" Then
                docuIndigent()
            ElseIf dgv_prccss.SelectedRows(0).Cells(4).Value = "Certificate of Residency" Then
                docuResidency()
            ElseIf dgv_prccss.SelectedRows(0).Cells(4).Value = "Barangay ID" Then
                docuID()
            End If
        ElseIf dgv_prccss.Columns(e.ColumnIndex).Name = "btn_dgv_done" Then
            dgv_fetch_prccsss() 'mag fetch sa information ng selected ctzn sa dgv
            Dim pickup As Integer = MsgShow("Notify citizen ready for pick up?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
            If pickup = DialogResult.Yes Then

                'pra mag fetch ng price sa na request na document
                connection.Close()
                connection.Open()
                command = New MySqlCommand("Select * from tbl_docu where col_doc_name = '" & dgv_prccss.SelectedRows(0).Cells(4).Value.ToString & "'", connection)
                dataReader = command.ExecuteReader

                While dataReader.Read
                    Dim doc_price = dataReader.GetString("col_Price")
                    txtdocPrice = doc_price

                End While
                connection.Close()



                'para mag fetch ng email sa usernmae ng nag log in sa mobile app
                connection.Close()
                connection.Open()
                command = New MySqlCommand("Select * from tbl_ctzn where ctzn_col_uname = '" & dgv_prcss_ctznpic.SelectedRows(0).Cells(20).Value & "'", connection)
                dataReader = command.ExecuteReader

                While dataReader.Read
                    Dim email = dataReader.GetString("ctzn_col_email")
                    txtemail = email

                End While
                connection.Close()

                Dim from, pass, messagebody As String
                Dim message As MailMessage = New MailMessage()
                toUser = txtemail
                from = "bargypotrero@gmail.com"
                pass = "dwkptjkiayczsawe"
                messagebody = vbTab + "Your requested document '" & dgv_prccss.SelectedRows(0).Cells(4).Value.ToString.ToUpper & "' is ready for pick-up. " +
                    "Please come to our barangay hall during office hours (MONDAY - SATURDAY 8AM TO 5PM). " + vbNewLine + vbNewLine + vbNewLine +
                    "To claim your acquired document, please prepare an exact amount of 'PHP " + txtdocPrice.ToUpper + ".00' and a xerox copy of your valid ID(back to back) with your signature indicated and present your reference number." + vbNewLine + vbNewLine +
                    "Reference Number: " + dgv_prcss_ctznpic.SelectedRows(0).Cells(21).Value.ToString

                message.To.Add(toUser)
                message.From = New MailAddress(from)
                message.Body = messagebody
                message.Subject = "Request '" + dgv_prcss_ctznpic.SelectedRows(0).Cells(21).Value.ToString + "' is Ready for Pick-UP"
                Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com")
                smtp.EnableSsl = True
                smtp.Port = 587
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New NetworkCredential(from, pass)
                Try

                    smtp.Send(message)
                    'PARA SA PAG UPDATE NG ACTION TABLE ng docs req
                    connection.Close()
                    connection.Open()
                    command = New MySqlCommand("UPDATE tbl_docsreq SET col_rqstDOC_action = 'To Pick-up'
                                                WHERE ID='" & dgv_prccss.SelectedRows(0).Cells(3).Value & "'", connection)
                    dataReader = command.ExecuteReader
                    connection.Close()
                    'PARA SA PAG UPDATE NG ACTION TABLE END


                    'PARA SA PAG UPDATE NG ACTION TABLE ng tbl_processing
                    connection.Close()
                    connection.Open()
                    command = New MySqlCommand("UPDATE tbl_docs_processing SET col_action = 'To Pick-up'
                                                WHERE col_ID='" & dgv_prccss.SelectedRows(0).Cells(2).Value & "'", connection)
                    dataReader = command.ExecuteReader
                    connection.Close()
                    'PARA SA PAG UPDATE NG ACTION sa tbl_processing END 


                    'para sa pag insert ng request id sa pick up table
                    connection.Close()
                    connection.Open()
                    command = New MySqlCommand("Insert into tbl_docs_pickUP
                                   (col_req_ID, col_action)
                             values 
                                    (@REQ_ID, @action)", connection)

                    command.Parameters.Add(New MySqlParameter("@REQ_ID", MySqlDbType.VarChar, 50)).Value = dgv_prccss.SelectedRows(0).Cells(3).Value
                    command.Parameters.Add(New MySqlParameter("@action", MySqlDbType.VarChar, 50)).Value = "To Pick-up"


                    command.ExecuteNonQuery()
                    connection.Close()
                    'para sa pag insert ng request id sa pick up table END


                    'FOR ACTIVITY LOG '
                    Dim regDate As Date = Date.Now()
                    Dim str_hr As String = regDate.ToString("HH")
                    Dim str_min As String = regDate.ToString("mm")
                    Dim str_sec As String = regDate.ToString("ss")

                    Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "

                    connection.Close()
                    connection.Open()
                    command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
                    command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
                    command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully set " & dgv_prccss.SelectedRows(0).Cells(7).Value.ToString.ToUpper & "'s request of " & dgv_prccss.SelectedRows(0).Cells(4).Value.ToString.ToUpper & " ready for pick up"
                    command.ExecuteNonQuery()
                    connection.Close()

                    MsgShow("You succesfully set this request for PICK UP.", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                    Fetch_processing() 'for refreshing processing grid
                    Fetch_pickUp() ' for fetching information from pick up table
                    Form3.chrtDocs()

                Catch ex As Exception
                    'MsgShow(ex.Message)
                    MsgShow("Please check your internet connection!", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
                End Try



            End If
        End If
    End Sub

    Private Sub print_Doc_clearance_QueryPageSettings(sender As Object, e As Printing.QueryPageSettingsEventArgs) Handles print_Doc_clearance.QueryPageSettings
        e.PageSettings.Landscape = True
    End Sub


    Public Sub subb_fetch_pndng() 'para sa process na data
        Dim tbl_ctzn As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                
                                               *
                                                
                                      FROM tbl_docsreq
                                     
                                      WHERE     
                                                 ID =  '" & dgv_pndng.SelectedRows(0).Cells(4).Value & "'
                                      ", connection)
        adptr.SelectCommand = command
        tbl_ctzn.Clear()

        adptr.Fill(tbl_ctzn)
        dgv_fetch_pndngALLINFO.DataSource = tbl_ctzn
        connection.Close()
    End Sub



    Public Sub dgv_fetch_prccsss() 'para sa process na data
        Dim tbl_ctzn As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                
                                               *
                                                
                                      FROM tbl_docsreq
                                     
                                      WHERE     
                                                 ID =  '" & dgv_prccss.SelectedRows(0).Cells(3).Value & "'
                                      ", connection)
        adptr.SelectCommand = command
        tbl_ctzn.Clear()

        adptr.Fill(tbl_ctzn)
        dgv_prcss_ctznpic.DataSource = tbl_ctzn
        connection.Close()
    End Sub

    Public Sub dgv_fetch_pickup() 'para sa pick up na data
        Dim tbl_ctzn As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                
                                               *
                                                
                                      FROM tbl_docsreq
                                     
                                      WHERE     
                                                 ID =  '" & dgv_pickUP.SelectedRows(0).Cells(2).Value & "'
                                      ", connection)
        adptr.SelectCommand = command
        tbl_ctzn.Clear()

        adptr.Fill(tbl_ctzn)
        dgv_ctzn_pickup.DataSource = tbl_ctzn
        connection.Close()
    End Sub

    Private Sub dgv_pickUP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_pickUP.CellContentClick
        If dgv_pickUP.Columns(e.ColumnIndex).Name = "btn_dgv_finish" Then
            Dim fpickup As Integer = MsgShow("Request already pick up by citizen?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
            If fpickup = DialogResult.Yes Then
                pnl_pick_name.Visible = True
                'proceed to btn_pick_ok
            End If
        End If
    End Sub
    Private Sub btn_pick_cancel_Click(sender As Object, e As EventArgs) Handles btn_pick_cancel.Click
        txtfullname_pick.Clear()
        pnl_pick_name.Visible = False
    End Sub


    Private Sub btn_pick_ok_Click(sender As Object, e As EventArgs) Handles btn_pick_ok.Click
        If txtfullname_pick.Text = Nothing Then
            MsgShow("Please input the name of person who picked up", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        Else
            dgv_fetch_pickup() 'mag fetch sa information ng selected ctzn sa dgv

            'para mag fetch ng email sa usernmae ng nag log in sa mobile app
            connection.Close()

            connection.Open()
            command = New MySqlCommand("Select * from tbl_ctzn where ctzn_col_uname = '" & dgv_ctzn_pickup.SelectedRows(0).Cells(20).Value & "'", connection)
            dataReader = command.ExecuteReader

            While dataReader.Read
                Dim email = dataReader.GetString("ctzn_col_email")
                txtemail2 = email

            End While
            connection.Close()


            Dim from, pass, messagebody As String
            Dim message As MailMessage = New MailMessage()
            Dim user = txtemail2
            from = "bargypotrero@gmail.com"
            pass = "dwkptjkiayczsawe"
            messagebody = vbTab + "Your requested document '" & dgv_pickUP.SelectedRows(0).Cells(3).Value.ToString.ToUpper & "' with reference number '" +
                dgv_ctzn_pickup.SelectedRows(0).Cells(21).Value.ToString + "' was succesfully picked up by '" + txtfullname_pick.Text.ToUpper + "'." + vbNewLine + vbNewLine +
                vbTab + "We are happy to serve you. Have a great day!" + vbNewLine + vbNewLine + vbNewLine


            message.To.Add(user)
            message.From = New MailAddress(from)
            message.Body = messagebody
            message.Subject = "Pick up Successful"
            Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com")
            smtp.EnableSsl = True
            smtp.Port = 587
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
            smtp.UseDefaultCredentials = False
            smtp.Credentials = New NetworkCredential(from, pass)
            Try

                smtp.Send(message)
                'PARA SA PAG UPDATE NG ACTION TABLE ng docs req
                connection.Close()
                connection.Open()
                command = New MySqlCommand("UPDATE tbl_docsreq SET col_rqstDOC_action = 'Settled'
                                                WHERE ID='" & dgv_pickUP.SelectedRows(0).Cells(2).Value & "'", connection)
                dataReader = command.ExecuteReader
                connection.Close()
                'PARA SA PAG UPDATE NG ACTION TABLE END


                'PARA SA PAG UPDATE NG ACTION TABLE ng tbl_pickup
                connection.Close()
                connection.Open()
                command = New MySqlCommand("UPDATE tbl_docs_pickup SET col_action = 'Settled'
                                                WHERE col_ID='" & dgv_pickUP.SelectedRows(0).Cells(1).Value & "'", connection)
                dataReader = command.ExecuteReader
                connection.Close()
                'PARA SA PAG UPDATE NG ACTION sa tbl_pick up END 


                'para sa pag insert ng request id sa settled table
                Dim valid_Date As DateTime = DateTime.Now.AddMonths(6) 'para sa validation ng docu pag add ng 6 months
                connection.Close()
                connection.Open()
                command = New MySqlCommand("Insert into tbl_docs_settled
                                   (col_req_ID, col_validation)
                             values 
                                    (@REQ_ID, @valid)", connection)

                command.Parameters.Add(New MySqlParameter("@REQ_ID", MySqlDbType.VarChar, 50)).Value = dgv_pickUP.SelectedRows(0).Cells(2).Value
                command.Parameters.Add(New MySqlParameter("@valid", valid_Date))

                command.ExecuteNonQuery()
                connection.Close()
                'para sa pag insert ng request id sa settled table END

                'ACTIVITY LOG

                Dim regDate As Date = Date.Now()
                Dim str_hr As String = regDate.ToString("HH")
                Dim str_min As String = regDate.ToString("mm")
                Dim str_sec As String = regDate.ToString("ss")

                Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "

                connection.Close()
                connection.Open()
                command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
                command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
                command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully set " & dgv_pickUP.SelectedRows(0).Cells(6).Value.ToString.ToUpper & "'s request of " & dgv_pickUP.SelectedRows(0).Cells(3).Value.ToString.ToUpper & " succesfully claimed by " & txtfullname_pick.Text.ToString.ToUpper & ""
                command.ExecuteNonQuery()
                connection.Close()



                MsgShow("You succesfully add this request to successfully claimed.", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                Fetch_pickUp() 'for refreshing pick up grid
                fetch_settled() ' for refreshing information from settled table
                txtfullname_pick.Clear()
                pnl_pick_name.Visible = False
                Form3.chrtDocs()

            Catch ex As Exception
                'MsgShow(ex.Message)
                MsgShow("Please check your internet connection!", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
            End Try

        End If
    End Sub

    Private Sub btn_pndng_cancel_Click(sender As Object, e As EventArgs) Handles btn_pndng_cancel.Click

        txt_pndng_reasonDeclining.Clear()
        pnl_pndng_reason.Visible = False
    End Sub
End Class