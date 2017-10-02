Imports System.Data.SqlClient

Public Class Login
    Dim con As SqlConnection = New SqlConnection(cnString)
    'Dim con As New SqlConnection("server = ./; database = Amaano ; user = sa ; password = 1234 ")
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As DataSet
    Dim dr As SqlDataReader
    Dim s As Integer = 0
    Dim r As String
    Dim per As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox(" fadlan gali  user name ka ")
            TextBox1.Focus()

        ElseIf TextBox2.Text = "" Then
            MsgBox(" fadlan gali password ka ")
            TextBox2.Focus()

        Else


            con.Close()


            Dim str As String = " select name, username  , password ,role,username  from users where username = '" & UsernameTextBox.Text & "' and password = '" & PasswordTextBox.Text & "'"
            cmd = New SqlCommand(str, con)
            con.Open()
            dr = cmd.ExecuteReader()
            If dr.Read = True Then
                'MsgBox(" succefully login ")
                Me.Hide()
                MDIParent1.Show()

                MDIParent1.userlbl.Text = dr(0)
                MDIParent1.Rolelbl.Text = dr(3)
                MDIParent1.Label1.Text = dr(4)
                per = dr("role").ToString()

                If per = "Cashier" Then
                    'MDIParent1.Invntrytoolstrip.Enabled = False

                    'MDIParent1.ReportsToolStripMenuItem2.Enabled = False
                    MDIParent1.craateuser.Enabled = False
                    'MDIParent1.DeleteUserToolStripMenuItem.Enabled = False

                    'MDIParent1.backkupToolStripMenuItem.Enabled = False
                    'MDIParent1.btn1.Enabled = False
                    'MDIParent1.btn2.Enabled = False
                    'MDIParent1.btn3.Enabled = False
                    'MDIParent1.btn4.Enabled = False
                    'MDIParent1.btn5.Enabled = False
                    'MDIParent1.btn6.Enabled = False
                    'MDIParent1.btn7.Enabled = False
                ElseIf per = "Manager" Then
                    ''MDIParent1.EmployeeRegistratioToolStripMenuItem.Enabled = False

                    ''MDIParent1.ReportsToolStripMenuItem2.Enabled = False
                    'MDIParent1.craateuser.Enabled = False
                    'MDIParent1.DeleteUserToolStripMenuItem.Enabled = False

                    ''MDIParent1.backkupToolStripMenuItem.Enabled = False
                    'MDIParent1.craateuser.Enabled = False
                    'MDIParent1.DeleteUserToolStripMenuItem.Enabled = False
                    ''MDIParent1.btn1.Enabled = False
                    ''MDIParent1.btn2.Enabled = False
                    ''MDIParent1.btn3.Enabled = False
                    ''MDIParent1.btn4.Enabled = False
                    ''MDIParent1.btn5.Enabled = False
                    'MDIParent1.btn6.Enabled = False
                    'MDIParent1.btn7.Enabled = False
                ElseIf per = "Accountant" Then

                    'MDIParent1.Invntrytoolstrip.Enabled = False

                    'MDIParent1.ReportsToolStripMenuItem2.Enabled = False
                    MDIParent1.craateuser.Enabled = False
                    'MDIParent1.DeleteUserToolStripMenuItem.Enabled = False

                    MDIParent1.backkupToolStripMenuItem.Enabled = False
                    'MDIParent1.btn1.Enabled = False
                    'MDIParent1.btn2.Enabled = False
                    MDIParent1.btn3.Enabled = False
                    MDIParent1.btn4.Enabled = False
                    'MDIParent1.btn5.Enabled = False
                    'MDIParent1.btn6.Enabled = False
                    'MDIParent1.btn7.Enabled = False

                Else


                    MDIParent1.ReportsToolStripMenuItem2.Enabled = False
                    'MDIParent1.Invntrytoolstrip.Enabled = False
                    'MDIParent1.Salestoolstrip.Enabled = False

                    MDIParent1.backkupToolStripMenuItem.Enabled = False
                    MDIParent1.SecurityToolStripMenuItem.Enabled = False
                    'MDIParent1.DeleteUserToolStripMenuItem.Enabled = False
                    MDIParent1.btn1.Enabled = False
                    MDIParent1.btn2.Enabled = False
                    MDIParent1.btn3.Enabled = False
                    MDIParent1.btn4.Enabled = False
                    MDIParent1.btn5.Enabled = False
                    MDIParent1.btn6.Enabled = False
                    MDIParent1.btn7.Enabled = False
                End If
            Else
                If s >= 3 Then
                    MsgBox(" fadlan isku day  mar danbe ", MsgBoxStyle.Information, " macasalam ")

                    End


                End If
                MsgBox(" user ka ama passwordku waa khalad ")
                TextBox1.Clear()
                TextBox2.Clear()

                TextBox1.Focus()
                s += 1


            End If




        End If



        'dr.Close()
        If con.State = ConnectionState.Connecting Then con.Close()



        'Me.Close()
    End Sub
End Class