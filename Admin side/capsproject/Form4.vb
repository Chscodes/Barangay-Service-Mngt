Imports MySql.Data.MySqlClient
Imports ShowMessage
Imports System.Net
Imports System.Net.Mail
Public Class Form4
    Public connection As New MySqlConnection("host=localhost; user=root; password=;database=db_brgypotrero;")
    Public adptr As New MySqlDataAdapter
    Public ds As New DataSet
    Public table As New DataTable

    Dim command As MySqlCommand
    Dim dataReader As MySqlDataReader

    Public Shared randomCode As String
    Public Shared toUser As String

    Dim cd_resend As New TimeSpan 'para sa automatic mag cooldown sa resend code button
    Private Sub btnverify_Click(sender As Object, e As EventArgs) Handles btnverify.Click
        If txt_current_uname.Text = Nothing And txt_current_pass.Text = Nothing And txtuname.Text = Nothing Or txtnewPass.Text = Nothing Or txtnewPass2.Text = Nothing Then
            'MessageBox.Show("Please fill the needed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'MsgShow("Please fill the needed", MsgType.Exclamation, "Notice", MsgLocation.Top_Center)
            MsgShow("Please fill the needed", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf txtnewPass.Text <> txtnewPass2.Text Then
            'MessageBox.Show("Please confirm your password properly!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MsgShow("Please confirm your password properly!", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)

        ElseIf VPass(txtnewPass.text) = False Then
            MsgShow("Password must be: " & vbNewLine & "8 characters long" & vbNewLine & "Atleast contain one LOWER case character" & vbNewLine & "Atleast contain one UPPER case character" & vbNewLine & "Atleast contain one number", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        ElseIf lblvalUname.Visible = True Then
            'MessageBox.Show("Please input another username", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MsgShow("Please input another username", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
        Else
            connection.Open()
            command = New MySqlCommand("select * from tbl_admin where col_admin_Uname='" & txt_current_uname.Text & "' and col_admin_pass='" & txt_current_pass.Text & "'", connection)
            dataReader = command.ExecuteReader
            Dim ACC As Integer
            ACC = 0
            While dataReader.Read
                ACC = ACC + 1
            End While

            If ACC = 1 Then
                Dim from, pass, messagebody As String
                Dim rand As Random = New Random()
                randomCode = (rand.Next(999999)).ToString()
                Dim message As MailMessage = New MailMessage()
                toUser = Form2.txtemail.Text 'email ng nasa form2
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

            Else
                'MessageBox.Show("Username and Password don't Match!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MsgShow("Current Username or Current Password is not Exist", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
            End If
            connection.Close()

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
    Private Sub Guna2GradientButton3_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton3.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub txtuname_TextChanged(sender As Object, e As EventArgs) Handles txtuname.TextChanged
        connection.Close()
        connection.Open()
        command = New MySqlCommand("select * from tbl_admin where col_admin_Uname='" & txtuname.Text & "'", connection)
        dataReader = command.ExecuteReader
        Dim us As Integer
        us = 0
        While dataReader.Read
            us = us + 1
        End While

        If us = 1 Then
            lblvalUname.Visible = True
        Else
            lblvalUname.Visible = False
        End If
        connection.Close()
    End Sub

    Private Sub Guna2GradientButton1_Click_1(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        Dim txtcodes As String

        txtcodes = txtcode1.Text + txtcode2.Text + txtcode3.Text + txtcode4.Text + txtcode5.Text + txtcode6.Text
        'txtcodes = Nothing
        If txtcode1.Text = Nothing And txtcode2.Text = Nothing And txtcode3.Text = Nothing And txtcode4.Text = Nothing And txtcode5.Text = Nothing And txtcode6.Text = Nothing Then
            MsgShow("Please input a verification code here", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)
            'MessageBox.Show("Please input a verification code here", "VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

            If (txtcodes.Equals(randomCode)) Then


                connection.Close()
                connection.Open()
                command = New MySqlCommand("UPDATE tbl_admin SET col_admin_Uname ='" & txtuname.Text & "', col_admin_pass ='" & txtnewPass.Text & "'  where col_ID='" & Form2.frm2ID & "'", connection)
                dataReader = command.ExecuteReader
                connection.Close()
                'MessageBox.Show("You successfully updated your account!", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                MsgShow("You successfully updated your account!", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)

                pnlVerifycode.Visible = False


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
                command.Parameters.Add(New MySqlParameter("@desc", MySqlDbType.VarChar, 200)).Value = time_now + "Account was successfully updated into new Username: '" & txtuname.Text.ToString.ToUpper & "' and Password: '" & txtnewPass.Text.ToString.ToUpper & "'"
                command.ExecuteNonQuery()
                connection.Close()

                clear()
                Form2.cleartext()
                Form2.Close()
                Me.Close()
                Form1.Show()



            Else
                MsgShow("Please check verification code properly!", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
                'MessageBox.Show("Please check verification code properly!", "VERIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If
    End Sub
    Public Sub clear()
        txtcode1.Clear()
        txtcode2.Clear()
        txtcode3.Clear()
        txtcode4.Clear()
        txtcode5.Clear()
        txtcode6.Clear()
        txtnewPass.Clear()
        txtnewPass2.Clear()
        txtuname.Clear()
    End Sub

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

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        pnlVerifycode.Visible = False
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

    Private Sub btnresend_Click(sender As Object, e As EventArgs) Handles btnresend.Click
        Dim from, pass, messagebody As String
        Dim rand As Random = New Random()
        randomCode = (rand.Next(999999)).ToString()
        Dim message As MailMessage = New MailMessage()
        toUser = Form2.txtemail.Text
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
End Class