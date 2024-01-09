Imports MySql.Data.MySqlClient
Imports ShowMessage

Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Net.Mail
Public Class Form8

    Public connection As New MySqlConnection("host=localhost; user=root; password=;database=db_brgypotrero;")
    Public adptr As New MySqlDataAdapter
    Public ds As New DataSet


    Dim command As MySqlCommand
    Dim dataReader As MySqlDataReader

    Dim txt_report As New TextBox
    Dim txt_allreq_data As New TextBox

    Public Sub Fetch_req() ' for fetching pending request
        Dim tbl As New DataTable

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
                                                from tbl_docsreq where col_rqstDOC_action = 'settled'
                                                ORDER BY `_datetime` DESC", connection)
        adptr.SelectCommand = command
        tbl.Clear()

        adptr.Fill(tbl)
        dgv_docu.DataSource = tbl

        'dgv_docu.Columns(8).DefaultCellStyle.Format = "yyyy-MM-dd" 'para mag format sa timestamp
        connection.Close()





    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fetch_req()
        fetch_doc()


    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim tablenew As New DataTable
        cmb_doc.Text = Nothing
        connection.Close()
        connection.Open()
        command = New MySqlCommand("SELECT
                                            ID as 'Request ID',
                                                col_rqstDOC_docsType as 'Document Type',
                                                col_rqstDOC_purpose as 'Purpose',
                                                col_rqstDOC_lname as 'Lastname' ,
                                                col_rqstDOC_fname as 'Firstname',
                                                col_rqstDOC_mname as 'Middlename',
                                                col_rqstDOC_bday as 'Birthdate ',
                                                col_req_refNum as 'Reference Number',
                                               
                                                _dateTime as 'Requested Date & Time'
                                    FROM
                                            tbl_docsreq
                                   where 
                                            col_rqstDOC_action = 'settled'
                                    and
                                            col_rqstDOC_lname LIKE '%" & txtsearch.Text & "%'
                                    OR
                                             col_rqstDOC_fname LIKE '%" & txtsearch.Text & "%'
                                    OR
                                             col_rqstDOC_mname LIKE '%" & txtsearch.Text & "%'
                                    OR
                                             col_req_refNum LIKE '%" & txtsearch.Text & "%'
                                    OR      
                                             col_rqstDOC_docsType  LIKE  '%" & txtsearch.Text & "%'
                                   
                                    ORDER BY
                                            `_datetime`
                                    DESC
                                                                    ", connection)
        adptr.SelectCommand = command
        tablenew.Clear()

        adptr.Fill(tablenew)
        dgv_docu.DataSource = tablenew

        connection.Close()
    End Sub

    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click
        Dim tablenew As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("SELECT
                                            ID AS 'Request ID',
                                            col_rqstDOC_docsType AS 'Document Type',
                                            col_rqstDOC_purpose AS 'Purpose',
                                            col_rqstDOC_lname AS 'Lastname',
                                            col_rqstDOC_fname AS 'Firstname',
                                            col_rqstDOC_mname AS 'Middlename',
                                            col_rqstDOC_bday AS 'Birthdate ',
                                            col_req_refNum AS 'Reference Number',
                                            _dateTime AS 'Requested Date & Time'
                                        FROM
                                            tbl_docsreq
                                        WHERE  
                                            col_rqstDOC_action = 'settled'
                                        and
                                            `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                            
                                         ORDER BY `_datetime` DESC

                                                                    ", connection)
        adptr.SelectCommand = command
        tablenew.Clear()

        adptr.Fill(tablenew)
        dgv_docu.DataSource = tablenew
        txtsearch.Clear()
        connection.Close()
    End Sub

    Private Sub sum_report_Click(sender As Object, e As EventArgs) Handles sum_report.Click
        Dim sug As Integer = MsgShow("Are you sure you want to generate reports between" + vbNewLine + dtp_from.Value + " and " + dtp_to.Value + " ?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
        If sug = DialogResult.Yes Then
            Dim regDate As Date = Date.Now()
            Dim strDate As String = regDate.ToString("dd")
            Dim strmonth As String = regDate.ToString("MMMM")
            Dim stryear As String = regDate.ToString("yyyy")

            Dim date_now = strmonth + "-" + strDate + "-" + stryear

            'PARA sa CLEARANCE TOTAL OF REQUEST
            Dim total_req As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay Clearance'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_req.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa CLEARANCE PENDING TOTAL OF REQUEST
            Dim total_clrnc_P As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay Clearance' AND `col_rqstDOC_action`= 'Pending'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_clrnc_P.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa CLEARANCE Declined TOTAL OF REQUEST
            Dim total_clrnc_D As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay Clearance' AND `col_rqstDOC_action`= 'Declined'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_clrnc_D.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa CLEARANCE Retrieve TOTAL OF REQUEST
            Dim total_clrnc_R As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay Clearance' AND `col_rqstDOC_action`= 'Retrieve'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_clrnc_R.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa CLEARANCE PROCessing TOTAL OF REQUEST
            Dim total_clrnc_Prcss As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay Clearance' AND `col_rqstDOC_action`= 'Processing'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_clrnc_Prcss.Text = dataReader(0).ToString
            End While

            connection.Close()


            'PARA sa CLEARANCE on-pickUP TOTAL OF REQUEST
            Dim total_clrnc_pck As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay Clearance' AND `col_rqstDOC_action`= 'To Pick-up'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_clrnc_pck.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa CLEARANCE on-pickUP TOTAL OF REQUEST
            Dim total_clrnc_sttld As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay Clearance' AND `col_rqstDOC_action`= 'Settled'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_clrnc_sttld.Text = dataReader(0).ToString
            End While

            connection.Close()

            '*****************************************************************CERTIFICATE INDIGENCY*******************************

            'PARA sa Certificate of Indigency TOTAL OF REQUEST
            Dim total_INDI_req As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Indigency'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_INDI_req.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of Indigency PENDING TOTAL OF REQUEST
            Dim total_indi_P As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Indigency' AND `col_rqstDOC_action`= 'Pending'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_indi_P.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of Indigency Declined TOTAL OF REQUEST
            Dim total_indi_D As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Indigency' AND `col_rqstDOC_action`= 'Declined'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_indi_D.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of Indigency Retrieve TOTAL OF REQUEST
            Dim total_indi_R As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Indigency' AND `col_rqstDOC_action`= 'Retrieve'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_indi_R.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of Indigency PROCessing TOTAL OF REQUEST
            Dim total_indi_Prcss As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Indigency' AND `col_rqstDOC_action`= 'Processing'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_indi_Prcss.Text = dataReader(0).ToString
            End While

            connection.Close()


            'PARA sa Certificate of Indigency on-pickUP TOTAL OF REQUEST
            Dim total_indi_pck As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Indigency' AND `col_rqstDOC_action`= 'To Pick-up'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_indi_pck.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of Indigency Succesful TOTAL OF REQUEST
            Dim total_indi_sttld As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Indigency' AND `col_rqstDOC_action`= 'Settled'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_indi_sttld.Text = dataReader(0).ToString
            End While

            connection.Close()

            '*****************************************************************CERTIFICATE Residency*******************************

            'PARA sa Certificate of Residency TOTAL OF REQUEST
            Dim total_RES_req As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Residency'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_RES_req.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of Residency PENDING TOTAL OF REQUEST
            Dim total_RES_P As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Residency' AND `col_rqstDOC_action`= 'Pending'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_RES_P.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of Residency Declined TOTAL OF REQUEST
            Dim total_RES_D As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Residency' AND `col_rqstDOC_action`= 'Declined'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_RES_D.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of Residency Retrieve TOTAL OF REQUEST
            Dim total_RES_R As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Residency' AND `col_rqstDOC_action`= 'Retrieve'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_RES_R.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of Residency PROCessing TOTAL OF REQUEST
            Dim total_RES_Prcss As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Residency' AND `col_rqstDOC_action`= 'Processing'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_RES_Prcss.Text = dataReader(0).ToString
            End While

            connection.Close()


            'PARA sa Certificate of Residency on-pickUP TOTAL OF REQUEST
            Dim total_RES_pck As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Residency' AND `col_rqstDOC_action`= 'To Pick-up'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_RES_pck.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Certificate of ResidencySuccesful TOTAL OF REQUEST
            Dim total_RES_sttld As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Certificate of Residency' AND `col_rqstDOC_action`= 'Settled'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_RES_sttld.Text = dataReader(0).ToString
            End While

            connection.Close()


            '*****************************************************************Barangay ID*******************************

            'PARA sa Barangay ID TOTAL OF REQUEST
            Dim total_prmt_req As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay ID'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_prmt_req.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Barangay ID PENDING TOTAL OF REQUEST
            Dim total_ID_P As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay ID' AND `col_rqstDOC_action`= 'Pending'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_ID_P.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Barangay ID Declined TOTAL OF REQUEST
            Dim total_ID_D As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay ID' AND `col_rqstDOC_action`= 'Declined'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_ID_D.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Barangay ID Retrieve TOTAL OF REQUEST
            Dim total_ID_R As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay ID' AND `col_rqstDOC_action`= 'Retrieve'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_ID_R.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Barangay ID PROCessing TOTAL OF REQUEST
            Dim total_ID_Prcss As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay ID' AND `col_rqstDOC_action`= 'Processing'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_ID_Prcss.Text = dataReader(0).ToString
            End While

            connection.Close()


            'PARA sa Barangay ID on-pickUP TOTAL OF REQUEST
            Dim total_ID_pck As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay ID' AND `col_rqstDOC_action`= 'To Pick-up'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_ID_pck.Text = dataReader(0).ToString
            End While

            connection.Close()

            'PARA sa Barangay ID Succesful TOTAL OF REQUEST
            Dim total_ID_sttld As New TextBox
            connection.Open()
            command = New MySqlCommand("SELECT
                                                COUNT(`col_rqstDOC_docsType`)
                                            FROM
                                                tbl_docsreq
                                            WHERE
                                                `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                                AND col_rqstDOC_docsType = 'Barangay ID' AND `col_rqstDOC_action`= 'Settled'
                                                
                                                ", connection)
            dataReader = command.ExecuteReader
            While dataReader.Read
                total_ID_sttld.Text = dataReader(0).ToString
            End While

            connection.Close()



            txt_report.Clear()
            txt_report.AppendText(vbNewLine)
            txt_report.AppendText(vbNewLine)
            txt_report.AppendText(vbNewLine)
            txt_report.AppendText(vbNewLine)
            txt_report.AppendText("DATE: " + date_now)
            txt_report.AppendText(vbNewLine)
            txt_report.AppendText("Reports from: " + dtp_from.Value.ToString("MMMM-dd-yyyy") + " to " + dtp_to.Value.ToString("MMMM-dd-yyyy"))
            txt_report.AppendText(vbNewLine)
            txt_report.AppendText(vbNewLine)
            txt_report.AppendText("Barangay Clearance: " + total_req.Text + " total of request" + vbNewLine)
            txt_report.AppendText("*************************************************************************************************" + vbNewLine)
            txt_report.AppendText("Total of Pending request: " + total_clrnc_P.Text + vbNewLine)
            txt_report.AppendText("Total of Declined request: " + total_clrnc_D.Text + vbNewLine)
            txt_report.AppendText("Total of Retrieve request: " + total_clrnc_R.Text + vbNewLine)
            txt_report.AppendText("Total of On-Process request: " + total_clrnc_Prcss.Text + vbNewLine)
            txt_report.AppendText("Total of On-PickUp request: " + total_clrnc_pck.Text + vbNewLine)
            txt_report.AppendText("Total of Succesfull request: " + total_clrnc_sttld.Text + vbNewLine)
            txt_report.AppendText(vbNewLine)

            'INDIGENCY
            txt_report.AppendText("Certificate of Indigency: " + total_INDI_req.Text + " total of request" + vbNewLine)
            txt_report.AppendText("*************************************************************************************************" + vbNewLine)
            txt_report.AppendText("Total of Pending request: " + total_indi_P.Text + vbNewLine)
            txt_report.AppendText("Total of Declined request: " + total_indi_D.Text + vbNewLine)
            txt_report.AppendText("Total of Retrieve request: " + total_indi_R.Text + vbNewLine)
            txt_report.AppendText("Total of On-Process request: " + total_indi_Prcss.Text + vbNewLine)
            txt_report.AppendText("Total of On-PickUp request: " + total_indi_pck.Text + vbNewLine)
            txt_report.AppendText("Total of Succesfull request: " + total_indi_sttld.Text + vbNewLine)
            txt_report.AppendText(vbNewLine)

            'RESIDENCY
            txt_report.AppendText("Certificate of Residency: " + total_RES_req.Text + " total of request" + vbNewLine)
            txt_report.AppendText("*************************************************************************************************" + vbNewLine)
            txt_report.AppendText("Total of Pending request: " + total_RES_P.Text + vbNewLine)
            txt_report.AppendText("Total of Declined request: " + total_RES_D.Text + vbNewLine)
            txt_report.AppendText("Total of Retrieve request: " + total_RES_R.Text + vbNewLine)
            txt_report.AppendText("Total of On-Process request: " + total_RES_Prcss.Text + vbNewLine)
            txt_report.AppendText("Total of On-PickUp request: " + total_RES_pck.Text + vbNewLine)
            txt_report.AppendText("Total of Succesfull request: " + total_RES_sttld.Text + vbNewLine)
            txt_report.AppendText(vbNewLine)

            'PERMIT
            txt_report.AppendText("Barangay ID: " + total_prmt_req.Text + " total of request" + vbNewLine)
            txt_report.AppendText("*************************************************************************************************" + vbNewLine)
            txt_report.AppendText("Total of Pending request: " + total_ID_P.Text + vbNewLine)
            txt_report.AppendText("Total of Declined request: " + total_ID_D.Text + vbNewLine)
            txt_report.AppendText("Total of Retrieve request: " + total_ID_R.Text + vbNewLine)
            txt_report.AppendText("Total of On-Process request: " + total_ID_Prcss.Text + vbNewLine)
            txt_report.AppendText("Total of On-PickUp request: " + total_ID_pck.Text + vbNewLine)
            txt_report.AppendText("Total of Succesfull request: " + total_ID_sttld.Text + vbNewLine)


            print_preview_report.ShowDialog()

            'ACTIVITY LOG
            Dim regtime As Date = Date.Now()
            Dim str_hr As String = regtime.ToString("HH")
            Dim str_min As String = regtime.ToString("mm")
            Dim str_sec As String = regtime.ToString("ss")

            Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "

            connection.Close()
            connection.Open()
            command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
            command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & Form1.Uname & ""
            command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully generated a report between the dates of " & dtp_from.Value.ToString("yyyy/MM/dd") & " and " & dtp_to.Value.ToString("yyyy/MM/dd") & " "
            command.ExecuteNonQuery()
            connection.Close()

        End If
    End Sub


    Private Sub print_Doc_report_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles print_Doc_report.PrintPage
        e.Graphics.DrawImage(bg_reports.Image, 0, 0, bg_reports.Width + 831, bg_reports.Height + 1070) ' for image bg for indigent
        Dim font As New Font("Arial", 12, FontStyle.Bold)
        e.Graphics.DrawString(txt_report.Text, font, Brushes.Black, 70, 140)
    End Sub

    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_doc.SelectedIndexChanged
        Dim tablenew As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("SELECT
                                            ID AS 'Request ID',
                                            col_rqstDOC_docsType AS 'Document Type',
                                            col_rqstDOC_purpose AS 'Purpose',
                                            col_rqstDOC_lname AS 'Lastname',
                                            col_rqstDOC_fname AS 'Firstname',
                                            col_rqstDOC_mname AS 'Middlename',
                                            col_rqstDOC_bday AS 'Birthdate ',
                                            col_req_refNum AS 'Reference Number',
                                            _dateTime AS 'Requested Date & Time'
                                        FROM
                                            tbl_docsreq
                                        WHERE
                                            `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                            and col_rqstDOC_docsType = '" & cmb_doc.Text & "'
                                         ORDER BY `_datetime` DESC

                                                                    ", connection)
        adptr.SelectCommand = command
        tablenew.Clear()

        adptr.Fill(tablenew)
        dgv_docu.DataSource = tablenew
        txtsearch.Clear()
        connection.Close()



    End Sub
    Public Sub fetch_doc()
        cmb_doc.Items.Clear()
        connection.Open()
        command = New MySqlCommand("select col_doc_name from tbl_docu where col_availability = 'AVAILABLE'", connection)
        dataReader = command.ExecuteReader

        While dataReader.Read
            Dim col_doc_Name = dataReader.GetString("col_doc_name")
            cmb_doc.Items.Add(col_doc_Name)
        End While
        connection.Close()
    End Sub

    Private Sub print_doc_ALLREQ_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles print_doc_ALLREQ.PrintPage
        e.Graphics.DrawImage(bg_reports.Image, 0, 0, bg_reports.Width + 831, bg_reports.Height + 1070) ' for image bg for repor summary
        Dim font As New Font("Arial", 12, FontStyle.Bold)
        e.Graphics.DrawString(txt_allreq_data.Text, font, Brushes.Black, 70, 140)

        Dim imagebmap As New Bitmap(Me.dgv_res_req.Width, Me.dgv_res_req.Height)
        dgv_res_req.DrawToBitmap(imagebmap, New Rectangle(0, 0, Me.dgv_res_req.Width, Me.dgv_res_req.Height))
        e.Graphics.DrawImage(imagebmap, 0, 290)



        'Static page As Integer = 1
        'If page = 1 Then
        ' 

        '    page = 1
        '    e.HasMorePages = False
        '    page += 1
        '    e.HasMorePages = True
        '    Return
        'End If

        'If page = 2 Then

        'End If





        'Dim total_rows As Integer = 0
        'For i As Integer = 0 To dgv_res_req.Rows.Count() - 1 Step +1
        '    total_rows = total_rows + 1
        '    If total_rows >= 2 Then

        '        Static page As Integer = 1
        '        If page = 1 Then


        '            page = 1
        '            e.HasMorePages = False
        '            page += 1
        '            e.HasMorePages = True
        '            Return
        '        End If

        '        If page = 2 Then

        '        End If

        '    End If
        'Next
        'TextBox1.Text = total_rows.ToString()
    End Sub

    Private Sub res_report_Click(sender As Object, e As EventArgs) Handles res_report.Click
        If cmb_doc.Text = Nothing Then
            MsgShow("Please Select the request document type to generate.", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

        Else




            Dim sug As Integer = MsgShow("Are you sure you want to generate all requests of" + vbNewLine + cmb_doc.Text.ToUpper + " between" + vbNewLine + dtp_from.Value + " and " + dtp_to.Value + " ?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
            If sug = DialogResult.Yes Then
                report_req() 'fetch sa datagrid para malagay sa printing
                'TextBox1.Text = dgv_res_req.RowCount
                Dim regDate As Date = Date.Now()
                Dim strDate As String = regDate.ToString("dd")
                Dim strmonth As String = regDate.ToString("MMMM")
                Dim stryear As String = regDate.ToString("yyyy")

                Dim date_now = strmonth + "-" + strDate + "-" + stryear
                txt_allreq_data.Clear()
                txt_allreq_data.AppendText(vbNewLine)
                txt_allreq_data.AppendText(vbNewLine)
                txt_allreq_data.AppendText(vbNewLine)
                txt_allreq_data.AppendText(vbNewLine)
                txt_allreq_data.AppendText("DATE: " + date_now)
                txt_allreq_data.AppendText(vbNewLine)
                txt_allreq_data.AppendText("Requests from: " + dtp_from.Value.ToString("MMMM-dd-yyyy") + " to " + dtp_to.Value.ToString("MMMM-dd-yyyy"))
                txt_allreq_data.AppendText(vbNewLine)
                txt_allreq_data.AppendText("Document Type: " +cmb_doc.Text.ToUpper)

                print_prev_ALLREQ.ShowDialog()
            End If
        End If

    End Sub
    Public Sub report_req()
        dgv_res_req.BackgroundColor = Color.White
        Dim tablenew As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("SELECT  col_req_refNum AS 'Reference Number',
                                            col_rqstDOC_purpose AS 'Purpose',
                                            col_rqstDOC_lname AS 'Lastname',
                                            col_rqstDOC_fname AS 'Firstname',
                                            col_rqstDOC_mname AS 'Middlename',                                          
                                            _dateTime AS 'Requested Date & Time'
                                        FROM
                                            tbl_docsreq
                                        WHERE
                                            `_datetime` BETWEEN '" & dtp_from.Value.ToString("yyyy/MM/dd") & "' AND '" & dtp_to.Value.AddDays(1).ToString("yyyy/MM/dd") & "'
                                            and col_rqstDOC_docsType = '" & cmb_doc.Text & "' and col_rqstDOC_action = 'Settled'
                                         ORDER BY `_datetime` DESC

                                                                    ", connection)
        adptr.SelectCommand = command
        tablenew.Clear()

        adptr.Fill(tablenew)
        dgv_res_req.DataSource = tablenew
        connection.Close()
    End Sub
End Class