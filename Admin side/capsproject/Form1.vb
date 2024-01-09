Imports Guna.UI2.AnimatorNS
Imports Guna.UI2.WinForms
Imports ShowMessage
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Net.Mail

Public Class Form1
    Public connection As New MySqlConnection("host=localhost; user=root; password=;database=db_brgypotrero;")
    'Public connection As New MySqlConnection("host=185.27.134.160; user=epiz_32974157; password=iFEhzT7KOtc;database=db_brgypotrero;")
    Dim command As MySqlCommand
    Dim dataReader As MySqlDataReader

    Public Shared Uname As String ' para sa mga name malagay ang acc name sa dashboard

    Public Shared randomCode As String
    Public Shared toUser As String

    Dim attempts As Integer = 0
    Dim cd2 As New TimeSpan() 'automatic cooldown if lagpas na sa attempt log in
    Dim cd_resend As New TimeSpan 'para sa automatic mag cooldown sa resend code button
    Public Sub clear()
        txtregisterUS.Clear()
        txtregistPass.Clear()
        txtregisterPass2.Clear()
        txtfname.Clear()
        txtemail.Clear()

        txtcode1.Clear()
        txtcode2.Clear()
        txtcode3.Clear()
        txtcode4.Clear()
        txtcode5.Clear()
        txtcode6.Clear()

    End Sub


    Public Sub Log() 'Code sa pag Log in


        If txtuname.Text = Nothing And txtpass111.Text = Nothing Then
            'MsgShow("Please input your Username and Password", MsgType.Exclamation, "Notice", MsgLocation.Top_Full_Width)
            'MessageBox.Show("Please input your Username and Password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MsgShow("Please input your Username and Password", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)
        Else
            connection.Open()
            command = New MySqlCommand("select * from tbl_admin where col_admin_Uname='" & txtuname.Text & "' and col_admin_pass='" & txtpass111.Text & "'", connection)
            dataReader = command.ExecuteReader
            Dim Login As Integer
            Login = 0
            While dataReader.Read
                Login = Login + 1
            End While

            If Login = 1 Then
                Me.Hide()
                Uname = txtuname.Text


                'FOR ACTIVITY LOG

                Dim regDate As Date = Date.Now()
                Dim str_hr As String = regDate.ToString("HH")
                Dim str_min As String = regDate.ToString("mm")
                Dim str_sec As String = regDate.ToString("ss")

                Dim time_now = "[" + str_hr + " : " + str_min + " : " + str_sec + "] "

                connection.Close()
                connection.Open()
                command = New MySqlCommand("Insert into tbl_logs (col_uname, col_desc) values (@uname, @desc)", connection)
                command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & txtuname.Text & ""
                command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "Account was logged in succesfully!"
                command.ExecuteNonQuery()
                connection.Close()

                Form3.ShowDialog()
                txtpass111.Clear()
                txtuname.Clear()

            Else
                attempts += 1
                MsgShow("Username and Password don't Match!" & vbNewLine & attempts & " of 3 attempts left.", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
                txtuname.Clear()
                txtpass111.Clear()
                txtuname.Focus()

                If attempts = 3 Then

                    MsgShow("Log in session freezed due to invalid log in", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)
                    attempts = 0
                    btnlogin.Enabled = False
                    lblRC.Visible = True
                    Timer1.Start()




                End If

            End If
            connection.Close()
        End If


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cd2 = New TimeSpan(0, CInt("3"), 0)
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        cd2 = cd2.Subtract(New TimeSpan(0, 0, 1))
        lblRC.Text = String.Format("{0} mins : {1} Secs", cd2.Minutes, cd2.Seconds)
        If cd2.Minutes = 0 AndAlso cd2.Seconds = 0 Then
            cd2 = New TimeSpan(0, CInt("3"), 0)
            Timer1.Stop()
            lblRC.Visible = False
            btnlogin.Enabled = True
        End If
    End Sub

    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs) Handles btncreate.Click
        gunaPBdesign.Dock = DockStyle.Right
        gunaPnlregister.Visible = True
        gunapnlLogin.Visible = False
        Guna2Transition1.ShowSync(gunaPnlregister)


    End Sub

    Private Sub Guna2GradientButton3_Click_1(sender As Object, e As EventArgs) Handles Guna2GradientButton3.Click
        gunaPBdesign.Dock = DockStyle.Left
        gunapnlLogin.Visible = True
        gunaPnlregister.Visible = False
        Guna2Transition1.ShowSync(gunapnlLogin)
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Log()
    End Sub

    Private Sub btnreg_Click(sender As Object, e As EventArgs) Handles btnreg.Click
        'Conditions

        If txtregisterUS.Text = Nothing Or txtregistPass.Text = Nothing Or txtfname.Text = Nothing Or txtemail.Text = Nothing Or txtregistPass.Text = Nothing Then

            'MessageBox.Show("Please fill the needed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MsgShow("Please fill the needed!", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

        ElseIf VPass(txtregistPass.Text) = False Then
            MsgShow("Password must be: " & vbNewLine & "8 characters long" & vbNewLine & "Atleast contain one LOWER case character" & vbNewLine & "Atleast contain one UPPER case character" & vbNewLine & "Atleast contain one number", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txtregistPass.Text <> txtregisterPass2.Text Then

            'MessageBox.Show("Please confirm your password!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MsgShow("Please confirm your password!", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

        ElseIf lblvalidemail.Visible = True Then

            'MessageBox.Show("Please input another email", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MsgShow("Please input another email", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

        ElseIf lblunamevalid.Visible = True Then
            'MessageBox.Show("Please input another username", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MsgShow("Please input another username", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)
        Else
            Try
                Dim from, pass, messagebody As String
                Dim rand As Random = New Random()
                randomCode = (rand.Next(999999)).ToString()
                Dim message As MailMessage = New MailMessage()
                toUser = txtemail.Text
                from = "bargypotrero@gmail.com"
                pass = "dwkptjkiayczsawe"
                messagebody = " Your verification code is " & randomCode
                message.To.Add(toUser)
                message.From = New MailAddress(from)
                message.Body = messagebody
                message.Subject = "Verification code!"
                Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com")
                smtp.EnableSsl = True
                smtp.Port = 587
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New NetworkCredential(from, pass)
                Try
                    smtp.Send(message)
                    'MessageBox.Show("Please check your email and copy the code received.", "VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MsgShow("Please check your email and copy the code received.", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                    pnlVerifycode.Visible = True
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Catch
                MsgShow("Please check your email properly.", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
            End Try
        End If
    End Sub

    Private Sub txtregisterUS_TextChanged(sender As Object, e As EventArgs) Handles txtregisterUS.TextChanged
        connection.Close()
        connection.Open()
        command = New MySqlCommand("select * from tbl_admin where col_admin_Uname='" & txtregisterUS.Text & "'", connection)
        dataReader = command.ExecuteReader
        Dim us As Integer
        us = 0
        While dataReader.Read
            us = us + 1
        End While

        If us = 1 Then
            lblunamevalid.Visible = True
        Else
            lblunamevalid.Visible = False
        End If
        connection.Close()
    End Sub

    Private Sub txtemail_TextChanged(sender As Object, e As EventArgs)
        connection.Close()
        connection.Open()
        command = New MySqlCommand("select * from tbl_admin where col_admin_email='" & txtemail.Text & "'", connection)
        dataReader = command.ExecuteReader
        Dim email As Integer
        email = 0
        While dataReader.Read
            email = email + 1
        End While

        If email = 1 Then
            lblvalidemail.Visible = True
        Else
            lblvalidemail.Visible = False
        End If
        connection.Close()
    End Sub

    Private Sub linkFpass_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkFpass.LinkClicked
        Me.Hide()
        Form2.ShowDialog()
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles btnconfirm.Click
        Dim txtcodes As String

        txtcodes = txtcode1.Text + txtcode2.Text + txtcode3.Text + txtcode4.Text + txtcode5.Text + txtcode6.Text
        'txtcodes = Nothing
        If txtcode1.Text = Nothing And txtcode2.Text = Nothing And txtcode3.Text = Nothing And txtcode4.Text = Nothing And txtcode5.Text = Nothing And txtcode6.Text = Nothing Then
            MsgShow("Please input a verification code here", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)
            'MessageBox.Show("Please input a verification code here", "VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            If (txtcodes.Equals(randomCode)) Then

                'REGISTRATION
                connection.Close()
                connection.Open()
                command = New MySqlCommand("Insert into tbl_admin (col_admin_Uname, col_admin_pass, col_admin_name, col_admin_email, col_admin_bday) values (@us, @pass, @name, @email, @bday)", connection)
                command.Parameters.Add(New MySqlParameter("@us", MySqlDbType.VarChar, 50)).Value = txtregisterUS.Text.ToUpper
                command.Parameters.Add(New MySqlParameter("@pass", MySqlDbType.VarChar, 50)).Value = txtregistPass.Text
                command.Parameters.Add(New MySqlParameter("@name", MySqlDbType.VarChar, 50)).Value = txtfname.Text
                command.Parameters.Add(New MySqlParameter("@email", MySqlDbType.VarChar, 50)).Value = txtemail.Text
                command.Parameters.Add(New MySqlParameter("@bday", dtpbday.Value.Date))
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
                command.Parameters.Add(New MySqlParameter("@uname", MySqlDbType.VarChar, 200)).Value = "" & txtregisterUS.Text & ""
                command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "Account was created successfully"
                command.ExecuteNonQuery()
                connection.Close()


                ' MessageBox.Show("You Successfully Register as Admin!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MsgShow("You Successfully Register as admin!", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                clear()
                'para mag show sa log in panel
                gunaPBdesign.Dock = DockStyle.Left
                gunapnlLogin.Visible = True
                gunaPnlregister.Visible = False
                pnlVerifycode.Visible = False
                Guna2Transition1.ShowSync(gunapnlLogin)

            Else
                MsgShow("Please check verification code properly!", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
                'MessageBox.Show("Please check verification code properly!", "VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
    End Sub

    Private Function VPass(ByVal password) As Boolean
        'para sa password policy
        Dim reg_ex
        reg_ex = CreateObject("vbscript.regexp")

        reg_ex.Pattern = "^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$"
        VPass = reg_ex.Test(password)

        reg_ex = Nothing
    End Function
    Private Sub txtcode1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcode1.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allownum As String = "0123456789"

            If Not allownum.Contains(e.KeyChar.ToString) Then
                MsgShow("Please input a number", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcode2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcode2.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allownum As String = "0123456789"

            If Not allownum.Contains(e.KeyChar.ToString) Then
                MsgShow("Please input a number", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcode3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcode3.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allownum As String = "0123456789"

            If Not allownum.Contains(e.KeyChar.ToString) Then
                MsgShow("Please input a number", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcode4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcode4.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allownum As String = "0123456789"

            If Not allownum.Contains(e.KeyChar.ToString) Then
                MsgShow("Please input a number", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcode5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcode5.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allownum As String = "0123456789"

            If Not allownum.Contains(e.KeyChar.ToString) Then
                MsgShow("Please input a number", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcode6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcode6.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allownum As String = "0123456789"

            If Not allownum.Contains(e.KeyChar.ToString) Then
                MsgShow("Please input a number", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)

                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnresend_Click(sender As Object, e As EventArgs) Handles btnresend.Click
        Dim from, pass, messagebody As String
        Dim rand As Random = New Random()
        randomCode = (rand.Next(999999)).ToString()
        Dim message As MailMessage = New MailMessage()
        toUser = txtemail.Text
        from = "bargypotrero@gmail.com"
        pass = "dwkptjkiayczsawe"
        messagebody = " Your verification code is " & randomCode
        message.To.Add(toUser)
        message.From = New MailAddress(from)
        message.Body = messagebody
        message.Subject = "Verification code!"
        Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com")
        smtp.EnableSsl = True
        smtp.Port = 587
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        smtp.UseDefaultCredentials = False
        smtp.Credentials = New NetworkCredential(from, pass)
        Try
            smtp.Send(message)
            btnresend.Enabled = False
            lblsec__.Visible = True
            'MessageBox.Show("Please check your email and copy the code received.", "VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MsgShow("Please check your email and copy the code received.", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        If time_resend.Enabled = False Then 'para sa resend code activation
            time_resend.Start()
            cd_resend = New TimeSpan(0, CInt("1"), 0)
        End If
    End Sub

    Private Sub time_resend_Tick(sender As Object, e As EventArgs) Handles time_resend.Tick
        cd_resend = cd_resend.Subtract(New TimeSpan(0, 0, 1))
        lblsec__.Text = String.Format("{0} Secs", cd_resend.Seconds)
        If cd_resend.Seconds = 0 Then
            cd_resend = New TimeSpan(0, CInt("1"), 0)
            time_resend.Stop()
            lblsec__.Visible = False
            btnresend.Enabled = True
        End If
    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        pnlVerifycode.Visible = False
    End Sub
End Class
