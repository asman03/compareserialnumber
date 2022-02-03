Imports System.Diagnostics.Process
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class Form1
    Sub viewlist()
        Call connect()
        Dim sqlquery As String = "select barcode, camera, result from tb_result order by id desc limit 5"
        Dim sqladapter As New MySqlDataAdapter
        Dim sqlcommand As New MySqlCommand
        Dim table As New DataTable
        Dim i As Integer

        With sqlcommand
            .CommandText = sqlquery
            .Connection = conn
        End With

        With sqladapter
            .SelectCommand = sqlcommand
            .Fill(table)
        End With

        lv.Items.Clear()

        For i = 0 To table.Rows.Count - 1
            With lv
                .Items.Add(table.Rows(i)("barcode"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(table.Rows(i)("camera"))
                    .Add(table.Rows(i)("result"))

                End With
                If i Mod 2 = 0 Then
                    .Items(i).BackColor = Color.Khaki
                Else
                    .Items(i).BackColor = Color.DarkKhaki
                End If
            End With

        Next

        txtbarcode.Text = ""
        txtcamera.Text = ""
    End Sub

    Sub time()

        'HR'

        Dim hr As String = TimeOfDay.Hour

        If hr = 1 Then

            hr = "0" + hr

        End If

        If hr = 2 Then

            hr = "0" + hr

        End If

        If hr = 3 Then

            hr = "0" + hr

        End If

        If hr = 4 Then

            hr = "0" + hr

        End If

        If hr = 5 Then

            hr = "0" + hr

        End If

        If hr = 6 Then

            hr = "0" + hr

        End If

        If hr = 7 Then

            hr = "0" + hr

        End If

        If hr = 8 Then

            hr = "0" + hr

        End If

        If hr = 9 Then

            hr = "0" + hr

        End If

        If hr = 0 Then

            hr = "0" + hr

        End If

        'MN'

        Dim mn As String = TimeOfDay.Minute

        If mn = 1 Then

            mn = "0" + mn

        End If

        If mn = 2 Then

            mn = "0" + mn

        End If

        If mn = 3 Then

            mn = "0" + mn

        End If

        If mn = 4 Then

            mn = "0" + mn

        End If

        If mn = 5 Then

            mn = "0" + mn

        End If

        If mn = 6 Then

            mn = "0" + mn

        End If

        If mn = 7 Then

            mn = "0" + mn

        End If

        If mn = 8 Then

            mn = "0" + mn

        End If

        If mn = 9 Then

            mn = "0" + mn

        End If

        If mn = 0 Then

            mn = "0" + mn

        End If

        'SC'

        Dim sc As String = TimeOfDay.Second

        If sc = 1 Then

            sc = "0" + sc

        End If

        If sc = 2 Then

            sc = "0" + sc

        End If

        If sc = 3 Then

            sc = "0" + sc

        End If

        If sc = 4 Then

            sc = "0" + sc

        End If

        If sc = 5 Then

            sc = "0" + sc

        End If

        If sc = 6 Then

            sc = "0" + sc

        End If

        If sc = 7 Then

            sc = "0" + sc

        End If

        If sc = 8 Then

            sc = "0" + sc

        End If

        If sc = 9 Then

            sc = "0" + sc

        End If

        If sc = 0 Then

            sc = "0" + sc

        End If

        lbjam.Text = hr + ":" + mn + ":" + sc

    End Sub

    Sub compare()
        If txtbarcode.Text = txtcamera.Text Then
            Button2.BackColor = Color.LightGreen
            Button2.Text = "OK"
        Else
            Button2.BackColor = Color.Red
            Button2.Text = "NG"
        End If
    End Sub

    Sub readtxt()
        Dim rf As New IO.StreamReader("D:\PROJECT\latihan.txt")
        Dim r As String
        Do Until rf.EndOfStream
            r = rf.ReadLine

            txtbarcode.Text = txtbarcode.Text & r & vbCrLf
        Loop

        rf.Close()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewlist()
        Call time()
        lbtgl.Text = Today
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        txtbarcode.Focus()
        Call readtxt()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        time()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.Diagnostics.Process.Start("shutdown", "-s -t 10")
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Call connect()
        Dim input As String = "insert into tb_result values (NUll,'" & txtbarcode.Text & "','" & txtcamera.Text & "','" & Button2.Text & "')"
        cmd = New MySqlCommand(input, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Data berhasil di input")
        viewlist()
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtbarcode.Text = ""
        txtcamera.Text = ""
        txtbarcode.Focus()
    End Sub

    Private Sub txtbarcode_TextChanged(sender As Object, e As EventArgs) Handles txtbarcode.TextChanged
        Call compare()

    End Sub

    Private Sub txtcamera_TextChanged(sender As Object, e As EventArgs) Handles txtcamera.TextChanged
        Call compare()
    End Sub

    Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
        On Error Resume Next
        txtbarcode.Text = lv.SelectedItems.Item(0).SubItems(0).Text
        txtcamera.Text = lv.SelectedItems.Item(0).SubItems(1).Text
        Button2.Text = lv.SelectedItems.Item(0).SubItems(2).Text
    End Sub
End Class
