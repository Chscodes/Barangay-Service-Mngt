Imports MySql.Data.MySqlClient
Imports ShowMessage
Public Class Form7
    Public connection As New MySqlConnection("host=localhost; user=root; password=;database=db_brgypotrero;")
    Public adptr As New MySqlDataAdapter
    Public ds As New DataSet


    Dim command As MySqlCommand
    Dim dataReader As MySqlDataReader

    Dim DOC_ID As Integer 'para sa id ng docu information
    Private Sub Guna2ToggleSwitch1_CheckedChanged(sender As Object, e As EventArgs) Handles tg_avail.CheckedChanged
        If tg_avail.Checked Then
            lbl_avail.Text = "AVAILABLE"
        Else
            lbl_avail.Text = "NOT AVAILABLE"
        End If
    End Sub

    Private Sub txtdocPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdocPrice.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allownum As String = "0123456789"
            Dim allowsym As String = "."

            If Not allownum.Contains(e.KeyChar.ToString) And Not allowsym.Contains(e.KeyChar.ToString) Then
                MsgShow("Please input valid price for document", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)

                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        If txtdocname.Text = Nothing Or txtdocDesc.Text = Nothing Or txtdocPrice.Text = Nothing Then
            MsgShow("All fields are required", MsgType.Information, MsgButton.OkOnly, MsgLanguage.English)
        Else
            connection.Close()
            connection.Open()
            command = New MySqlCommand("select * from tbl_docu where col_doc_name='" & txtdocname.Text & "'
                    ", connection)
            dataReader = command.ExecuteReader
            Dim docu As Integer
            docu = 0
            While dataReader.Read
                docu = docu + 1
            End While

            If docu >= 1 Then
                MsgShow("You already added this document type!", MsgType.Information, MsgButton.OkOnly, MsgLanguage.English)
            Else
                '' FOR DATE ISSUED (FOR ID)
                'Dim DateNOW As Date = Date.Now
                'Dim dtnow As String = DateNOW.ToString("dd")
                'Dim dtyear As String = DateNOW.ToString("yyy")

                Dim quest As Integer = MsgShow("Are you sure you want to add this information?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
                If quest = DialogResult.Yes Then
                    connection.Close()
                    connection.Open()
                    command = New MySqlCommand("Insert into tbl_docu
                                   (col_Doc_name, col_Price, col_availability, col_Description)
                             values 
                                    ( @name, @price, @avail, @desc)", connection)

                    command.Parameters.Add(New MySqlParameter("@name", MySqlDbType.VarChar, 50)).Value = txtdocname.Text
                    command.Parameters.Add(New MySqlParameter("@price", MySqlDbType.VarChar, 50)).Value = txtdocPrice.Text
                    command.Parameters.Add(New MySqlParameter("@avail", MySqlDbType.VarChar, 50)).Value = lbl_avail.Text
                    command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 50)).Value = txtdocDesc.Text



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
                    command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully added a new available document (" & txtdocname.Text & ")"
                    command.ExecuteNonQuery()
                    connection.Close()


                    MsgShow("Document Information has been added successfully!", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                    Fetch_docu()
                    clear()
                End If
            End If
            connection.Close()

        End If


    End Sub



    Public Sub clear()
        txtdocDesc.Clear()
        txtdocname.Clear()
        txtdocPrice.Clear()
        tg_avail.Checked = True
    End Sub
    Public Sub Fetch_docu() ' FOR admin datas
        Dim tablenew As New DataTable

        connection.Close()
        connection.Open()
        command = New MySqlCommand("select 
                                                ID as 'Document ID',
                                                col_doc_name as 'Document Name',
                                                col_Price as 'Document Price',
                                                col_availability as 'Document Availability',
                                                col_description as 'Document Description',

                                                _dateTime as 'Created Date and Time'
                                                from tbl_docu
                                                ORDER BY `_datetime` DESC", connection)
        adptr.SelectCommand = command
        tablenew.Clear()

        adptr.Fill(tablenew)
        dgv_docs.DataSource = tablenew

        connection.Close()

    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fetch_docu()
    End Sub

    Private Sub dgv_docs_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_docs.CellContentClick
        dgv_docs.ClearSelection()
        If e.RowIndex < 0 Then Exit Sub
        DOC_ID = dgv_docs.Item(0, e.RowIndex).Value.ToString
        txtdocname.Text = dgv_docs.Item(1, e.RowIndex).Value.ToString
        txtdocPrice.Text = dgv_docs.Item(2, e.RowIndex).Value.ToString
        lbl_avail.Text = dgv_docs.Item(3, e.RowIndex).Value.ToString
        txtdocDesc.Text = dgv_docs.Item(4, e.RowIndex).Value.ToString


        txtdocname.ReadOnly = True
        txtdocPrice.ReadOnly = True
        txtdocDesc.ReadOnly = True
        tg_avail.Enabled = False

        btn_edit.Visible = True
        btnsave.Visible = False
        btnClear.Visible = True
        btnupdate.Visible = False


        tg_avail.Visible = False
        lbl_avail.Visible = False

        If lbl_avail.Text = "AVAILABLE" Then
            tg_avail.Checked = True
        Else
            tg_avail.Checked = False
        End If

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
        txtdocname.ReadOnly = False
        txtdocPrice.ReadOnly = False
        txtdocDesc.ReadOnly = False
        tg_avail.Enabled = True

        btnsave.Visible = True
        btn_edit.Visible = False
        btnupdate.Visible = False
        btnClear.Visible = False


        tg_avail.Visible = True
        lbl_avail.Visible = True
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        txtdocname.ReadOnly = False
        txtdocPrice.ReadOnly = False
        txtdocDesc.ReadOnly = False
        tg_avail.Enabled = True

        btn_edit.Visible = False
        btnupdate.Visible = True


        tg_avail.Visible = True
        lbl_avail.Visible = True

    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim update As Integer = MsgShow("Are you sure want to UPDATE this information?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
        If update = DialogResult.Yes Then
            connection.Close()
            connection.Open()

            'col_rsdnt_lname, col_rsdnt_fname, col_rsdnt_mname, col_rsdnt_address, col_rsdnt_residency,
            '                        col_rsdnt_year, col_rsdnt_gender, col_rsdnt_cnum, col_rsdnt_ctznshp, col_rsdnt_bday, col_rsdnt_pday,
            '                        col_rsdnt_status, col_rsdnt_health, col_rsdnt_Rname, col_rsdnt_Rcnum, col_rsdnt_Radd

            command = New MySqlCommand("UPDATE tbl_docu SET col_doc_name='" & txtdocname.Text & "',
                                        col_Price ='" & txtdocPrice.Text & "',
                                        col_availability= '" & txtdocPrice.Text & "',
                                        col_description= '" & txtdocDesc.Text & "',
                                        col_availability =  '" & lbl_avail.Text & "'
                                        
                                        WHERE ID='" & DOC_ID & "'", connection)

            dataReader = command.ExecuteReader
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
            command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "You successfully updated document's information"
            command.ExecuteNonQuery()
            connection.Close()


            'MessageBox.Show("Resident Information Updated", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MsgShow("Information has been successfully UPDATED", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
            Fetch_docu() ' para auto refresh ang grid sa form2 
            clear()
            btnsave.Visible = True
            btnupdate.Visible = False
            btnClear.Visible = False
        End If

    End Sub



    'Private Sub tg_UP_avail_Click(sender As Object, e As EventArgs) Handles tg_UP_avail.Click
    '    If tg_UP_avail.Checked Then
    '        lblUP_avail.Text = "AVAILABLE"


    '        Dim update As Integer = MsgShow("Are you sure want to UPDATE its availability?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
    '        If update = DialogResult.Yes Then
    '            connection.Close()
    '            connection.Open()

    '            command = New MySqlCommand("UPDATE tbl_docu SET 
    '                                            col_availability =  '" & lblUP_avail.Text & "'

    '                                    WHERE ID='" & DOC_ID & "'", connection)

    '            dataReader = command.ExecuteReader
    '            connection.Close()
    '            MsgShow("Information has been successfully UPDATED", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
    '            Fetch_docu()
    '            clear()
    '            btnsave.Visible = True
    '            btnupdate.Visible = False
    '            btn_edit.Visible = False
    '            btnClear.Visible = False

    '            tg_UP_avail.Visible = False
    '            lblUP_avail.Visible = False
    '            tg_avail.Visible = True
    '            lbl_avail.Visible = True
    '        Else

    '        End If

    '    Else
    '        lblUP_avail.Text = "NOT AVAILABLE"


    '        Dim update As Integer = MsgShow("Are you sure want to UPDATE its availability?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
    '        If update = DialogResult.Yes Then
    '            connection.Close()
    '            connection.Open()

    '            command = New MySqlCommand("UPDATE tbl_docu SET 
    '                                            col_availability =  '" & lblUP_avail.Text & "'

    '                                    WHERE ID='" & DOC_ID & "'", connection)

    '            dataReader = command.ExecuteReader
    '            connection.Close()
    '            MsgShow("Information has been successfully UPDATED", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
    '            Fetch_docu()
    '            clear()
    '            btnsave.Visible = True
    '            btnupdate.Visible = False
    '            btn_edit.Visible = False
    '            btnClear.Visible = False

    '            tg_UP_avail.Visible = False
    '            lblUP_avail.Visible = False
    '            tg_avail.Visible = True
    '            lbl_avail.Visible = True
    '        End If
    '    End If
    'End Sub
End Class