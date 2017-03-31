Public Class Form1
    Public path As String
    Public newDirectory As Boolean = False
    Public copyDirectory As Boolean = False
    Public copyFile As Boolean = False

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub NewDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewDirectoryToolStripMenuItem.Click, ToolStripButton1.Click
        Label1.Text = "Create in destination directory"
        newDirectory = True
        copyDirectory = False
        copyFile = False
        CancelButton.Enabled = True
        BrowserButton.Enabled = True
        BrowserButton.Visible = True
        BrowserLabel.Text = ""
        Label2.Text = ""
        FileTextBox.Enabled = False
        FileTextBox.Visible = False
        FileTextBox.Text = ""
        newPathLabel.Text = ""
        ProgressBar1.Value = 0
    End Sub

    Private Sub CopyDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyDirectoryToolStripMenuItem.Click, ToolStripButton2.Click
        Label1.Text = "Copy this directory"
        copyDirectory = True
        newDirectory = False
        copyFile = False
        CancelButton.Enabled = True
        BrowserButton.Enabled = True
        BrowserButton.Visible = True
        BrowserLabel.Text = ""
        Label2.Text = ""
        FileTextBox.Enabled = False
        FileTextBox.Visible = False
        FileTextBox.Text = ""
        newPathLabel.Text = ""
        ProgressBar1.Value = 0
    End Sub

    Private Sub CopyFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyFileToolStripMenuItem.Click, ToolStripButton3.Click
        Label1.Text = "Copy this file"
        copyFile = True
        newDirectory = False
        copyDirectory = False
        CancelButton.Enabled = True
        BrowserButton.Enabled = True
        BrowserButton.Visible = True
        BrowserLabel.Text = ""
        Label2.Text = ""
        FileTextBox.Enabled = False
        FileTextBox.Visible = False
        FileTextBox.Text = ""
        newPathLabel.Text = ""
        ProgressBar1.Value = 0
    End Sub

    Private Sub BrowserButton_Click(sender As Object, e As EventArgs) Handles BrowserButton.Click
        With FolderBrowserDialog1
            .SelectedPath = ""
            If newDirectory = True Then
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    BrowserLabel.Text = .SelectedPath + "\"
                    Label2.Text = "this new subdirectory:"
                    FileTextBox.Enabled = True
                    FileTextBox.Visible = True
                    path = .SelectedPath + "\"
                End If
            End If
        End With
        With FolderBrowserDialog1
            If copyDirectory = True Then
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    BrowserLabel.Text = .SelectedPath + "\"
                    Label2.Text = "to:"
                    FileTextBox.Enabled = True
                    FileTextBox.Visible = True
                    path = .SelectedPath + "\"
                    newPathLabel.Text = System.IO.Path.GetDirectoryName(.SelectedPath) + "\"
                End If
            End If
        End With

        If copyFile = True Then
            With OpenFileDialog1
                .InitialDirectory = ""
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    BrowserLabel.Text = .FileName
                    Label2.Text = "to:"
                    FileTextBox.Enabled = True
                    FileTextBox.Visible = True
                    path = .FileName
                    newPathLabel.Text = System.IO.Path.GetDirectoryName(.FileName) + "\"
                End If
            End With
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Timer1.Start()
        If newDirectory = True Then
            My.Computer.FileSystem.CreateDirectory(path + FileTextBox.Text)
            newDirectory = False
        ElseIf copyDirectory = True Then
            My.Computer.FileSystem.CopyDirectory(path, newPathLabel.Text + FileTextBox.Text)
            copyDirectory = False
        ElseIf copyFile = True Then
            My.Computer.FileSystem.CopyFile(path, newPathLabel.Text + FileTextBox.Text)
            copyFile = False
        End If
    End Sub

    Private Sub FileTextBox_TextChanged(sender As Object, e As EventArgs) Handles FileTextBox.TextChanged
        If FileTextBox.Text = "" Then
            OkButton.Enabled = False
        Else
            OkButton.Enabled = True
        End If
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Label1.Text = ""
        CancelButton.Enabled = False
        OkButton.Enabled = False
        BrowserButton.Enabled = False
        BrowserButton.Visible = False
        BrowserLabel.Text = ""
        newPathLabel.Text = ""
        Label2.Text = ""
        FileTextBox.Enabled = False
        FileTextBox.Visible = False
        ProgressBar1.Value = 0
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(10)
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
        End If
    End Sub

End Class
