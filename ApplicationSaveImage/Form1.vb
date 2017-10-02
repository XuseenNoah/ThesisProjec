Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO

Public Class Form1
    Dim conn As New SqlConnection(" server = .\; database = amaano ; user = sa ; password = 1234 ")

    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter("select * from users", conn)
    Dim ds As New DataSet
    Dim maxrow As Integer
    Dim i As Integer
    Dim dr As SqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim fopen As New OpenFileDialog
            fopen.FileName = ""
            fopen.Filter = "Image Files (*.jpg)|*.jpg|(*.jpeg)|*.JPEG|(*.gif)|*.gif|(*.png)|*.png|All Files (*.*)|*.*"
            fopen.ShowDialog()
            PictureBox1.Image = System.Drawing.Bitmap.FromFile(fopen.FileName)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\NoImage\" & "noimage.gif")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        conn.Close()
        conn.Open()
        'product picture
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, ImageFormat.Jpeg)
        'Read from Memorystream into byte Array.
        Dim bytBLOBData(ms.Length - 1) As Byte
        ms.Position = 0
        ms.Read(bytBLOBData, 0, Convert.ToInt32(ms.Length))

        Using cmd As New SqlClient.SqlCommand("insert into users(id,name,shop,role,username,password,mobile,pic,active,date,createduser) values ('" & idtxt.Text & "' , '" & nametxt.Text & "' , '" & titlecom.Text & "' , '" & Rolecomp.Text & "' , '" & usernametxt.Text & "' , '" & passwordtxt.Text & "' ,'" & mobiletxt.Text & "', @pic , 'A','" & datetxt.Text & "','" & MDIParent1.userlbl.Text & "')", conn)

            Dim prmstudent1 As New SqlParameter("@pic", SqlDbType.VarBinary, bytBLOBData.Length, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, bytBLOBData)

            cmd.Parameters.Add(prmstudent1)

            converimage()
            'cmd.Parameters.Add(New SqlClient.SqlParameter("@productpict", SqlDbType.Image)).Value = IO.File.ReadAllBytes(a.FileName)

            i = cmd.ExecuteNonQuery

        End Using
    End Sub

    Private Sub converimage()
        If PictureBox1.Image Is Nothing Then
            Dim MS = New MemoryStream
            PictureBox1.Image.Save(MS, ImageFormat.Jpeg)
            Dim photo_aray(MS.Length - 1) As Byte
            MS.Position = 0
            MS.Read(photo_aray, 0, photo_aray.Length)
            cmd.Parameters.AddWithValue("@som", photo_aray)
        End If
    End Sub
End Class
