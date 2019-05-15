Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer3.Enabled = True
        Timer3.Start()
        Button2.Enabled = True
        Button1.Text = "0"
        Button1.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        RadioButton4.Enabled = False
        If RadioButton1.Checked Then
            Shell("shutdown -s -t 10")
            NotifyIcon1.Text = "Turning off..."
            NotifyIcon1.BalloonTipText = "Turning off..."
            NotifyIcon1.ShowBalloonTip(100)
        ElseIf RadioButton2.Checked Then
            Shell("shutdown -r -t 10")
            NotifyIcon1.Text = "Restarting..."
            NotifyIcon1.BalloonTipText = "Restarting..."
            NotifyIcon1.ShowBalloonTip(100)
        ElseIf RadioButton3.Checked Then
            MsgBox("Log off will be immediate.")
            Shell("shutdown -l")
            NotifyIcon1.Text = "Logging off..."
            NotifyIcon1.BalloonTipText = "Logging off..."
            NotifyIcon1.ShowBalloonTip(100)
        ElseIf RadioButton4.Checked Then
            Shell("shutdown -s -f -t 10")
            NotifyIcon1.Text = "Force Shutting Down"
            NotifyIcon1.BalloonTipText = "Process Cancelled."
            NotifyIcon1.ShowBalloonTip(100)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shell("shutdown -a")
        NotifyIcon1.Text = "Process Cancelled"
        NotifyIcon1.BalloonTipText = "Process Cancelled."
        NotifyIcon1.ShowBalloonTip(100)
        Timer3.Stop()
        Button1.Enabled = True
        Button1.Text = "Start Now"
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
        RadioButton4.Enabled = True

    End Sub

    Private Sub Label7_TextChanged(sender As Object, e As EventArgs) Handles Label7.TextChanged
        If Label7.Text = "60" Then
            Label5.Text += 1
            Label7.Text = "00"
        End If
    End Sub

    Private Sub Label5_TextChanged(sender As Object, e As EventArgs) Handles Label5.TextChanged
        If Label5.Text = "60" Then
            Label3.Text += 1
            Label5.Text = "00"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        NotifyIcon1.BalloonTipText = "Timer Started."
        NotifyIcon1.Text = Label3.Text & ":" & Label5.Text & ":" & Label7.Text & vbCrLf & "hour:min:sec"
        NotifyIcon1.ShowBalloonTip(1)
        Button4.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        RadioButton4.Enabled = False
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer1.Stop()
        Label3.Text = "00"
        Label5.Text = "00"
        Label7.Text = "00"
        NotifyIcon1.Text = Label3.Text & ":" & Label5.Text & ":" & Label7.Text & vbCrLf & "hour:min:sec"
        NotifyIcon1.BalloonTipText = Label3.Text & ":" & Label5.Text & ":" & Label7.Text & vbCrLf & "hour:min:sec"
        NotifyIcon1.ShowBalloonTip(300)
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
        RadioButton4.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label7.Text += 1
        NotifyIcon1.Text = Label3.Text & ":" & Label5.Text & ":" & Label7.Text & vbCrLf & "hour:min:sec"
        NotifyIcon1.BalloonTipText = Label3.Text & ":" & Label5.Text & ":" & Label7.Text & vbCrLf & "hour:min:sec"
        If Label3.Text = NumericUpDown1.Value And Label5.Text = NumericUpDown2.Value Then
            If RadioButton1.Checked Then
                Shell("shutdown -s")
            ElseIf RadioButton2.Checked Then
                Shell("shutdown -r")
            ElseIf RadioButton3.Checked Then
                Shell("shutdown -l")
            ElseIf RadioButton4.Checked Then
                Shell("shutdown -s -f")
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If RadioButton1.Checked = False And RadioButton2.Checked = False And RadioButton3.Checked = False And RadioButton4.Checked = False Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False

        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Button1.Text += 1
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        NotifyIcon1.BalloonTipText = "Still Running in the Background"
        NotifyIcon1.ShowBalloonTip(500)
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles NotifyIcon1.BalloonTipClicked
        Me.Show()
        Me.Visible = True
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If Timer1.Enabled = True Then
            Timer1.Enabled = False
            Shell("shutdown -a")
            Application.Exit()
        Else
            End
        End If
    End Sub

    Private Sub StopCancelAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopCancelAllToolStripMenuItem.Click
        Timer1.Enabled = False
        Shell("shutdown -a")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        End
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Dim i As Integer = 0
        System.Threading.Thread.Sleep(1000)
        For Each p As Process In Process.GetProcesses
            If p.ProcessName = "EpicGamesLauncher" Then
                i += 1
                p.Kill()
                System.Threading.Thread.Sleep(700)
            End If
        Next
    End Sub
End Class
