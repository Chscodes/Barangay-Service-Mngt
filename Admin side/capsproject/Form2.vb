Imports MySql.Data.MySqlClient 'mysql datbase
Imports ShowMessage
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing

Imports System.Net
Imports System.Net.Mail

Imports Guna.UI2.AnimatorNS
Imports Guna.UI2.WinForms
Public Class Form2
    Public connection As New MySqlConnection("host=localhost; user=root; password=;database=db_brgypotrero;")
    Public adptr As New MySqlDataAdapter
    Public ds As New DataSet
    Public table As New DataTable

    Dim command As MySqlCommand
    Dim dataReader As MySqlDataReader

    Public Shared frm2ID As String 'para sa pag update ng new pass at uname 
    Public Shared toUser As String
    Private Sub Guna2GradientButton3_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton3.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub btnverify_Click(sender As Object, e As EventArgs) Handles btnverify.Click
        If txtname.Text = Nothing Or txtEmail.Text = Nothing Then
            'MessageBox.Show("Please fill the needed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            MsgShow("Please fill the needed", MsgType.Exclamation, MsgButton.OkOnly, MsgLanguage.English)
        Else
            connection.Close()
            connection.Open()
            command = New MySqlCommand("select * from tbl_admin where col_admin_name='" & txtname.Text & "' and col_admin_bday='" & dtpbday.Text & "'
            and col_admin_email='" & txtemail.Text & "'", connection)
            dataReader = command.ExecuteReader
            Dim ACC As Integer
            ACC = 0
            While dataReader.Read
                ACC = ACC + 1
            End While

            If ACC = 1 Then
                frm2ID = dataReader.GetString("col_ID")
                Dim DB_us = dataReader.GetString("col_admin_Uname")
                Dim DB_pass = dataReader.GetString("col_admin_pass")

                'PARA MAG SEND SA EMAIL NG KANYANG PASSWORD AT USERNAME
                Dim from, pass As String
                Dim message As MailMessage = New MailMessage()
                toUser = txtemail.Text
                from = "bargypotrero@gmail.com"
                pass = "dwkptjkiayczsawe"
                message.To.Add(toUser)
                message.From = New MailAddress(from)
                message.Body = "Good Day, upon checking your request regarding to forgot username and password, we successfully verify your concern indicated below:" + vbNewLine + vbNewLine +
                    "Username: " + DB_us + vbNewLine +
                    "Password: " + DB_pass + vbNewLine + vbNewLine + "Hope this solve your concern, Have a nice day!"


                message.Subject = "FORGOT PASSWORD RESULT"
                Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com")
                smtp.EnableSsl = True
                smtp.Port = 587
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New NetworkCredential(from, pass)
                Try
                    smtp.Send(message)
                    ' MessageBox.Show("Please check your email.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MsgShow("Please check your email.", MsgType.Success, MsgButton.OkOnly, MsgLanguage.English)
                    'MessageBox.Show("Do you Want to change your username and password?", "Update Username and Password?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    Dim Quest As Integer = MsgShow("Do you Want to change your username and password?", MsgType.Question, MsgButton.YesNo, MsgLanguage.English)
                    If Quest = DialogResult.Yes Then
                        Me.Hide()

                        Form4.ShowDialog()
                    Else
                        cleartext()
                        Me.Close()
                        Form1.Show()
                    End If
                Catch ex As Exception
                    MsgShow(ex.Message)
                End Try
                'PARA MAG SEND SA EMAIL NG KANYANG PASSWORD AT USERNAME (end)

            Else
                'MessageBox.Show("Account Not Exist in Database!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                MsgShow("Account Not Exist in Database!.", MsgType.Critical, MsgButton.OkOnly, MsgLanguage.English)
            End If


        End If
    End Sub
    Public Sub cleartext()
        txtname.Text = Nothing
        txtemail.Text = Nothing
    End Sub
End Class