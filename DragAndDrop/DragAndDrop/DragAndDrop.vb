Public Class DragAndDrop
    Private isDragging1 As Boolean = False, isDragging2 As Boolean = False
    Private startPoint1 As Point, startPoint2 As Point

    Private Sub DragAndDrop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialize()
    End Sub

    Public Sub initialize()
        If isDragging1 Then
            isDragging2 = False
        End If

        If isDragging2 Then
            isDragging1 = False
        End If
    End Sub

    'PictureBox 1 starts
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown, PictureBox2.MouseDown
        startPoint1 = PictureBox1.PointToScreen(New Point(e.X, e.Y))
        isDragging1 = True
        isDragging2 = False
        PictureBox1.BringToFront()
        Me.Cursor = New Cursor(New System.IO.MemoryStream(My.Resources.H_MOVE))
        StatusBar1.Text = "PictureBox1: " + startPoint1.X.ToString + "," + startPoint1.Y.ToString
        If PictureBox1.Bounds.IntersectsWith(PictureBox2.Bounds) Then
            StatusBar1.Text += " || " + "PictureBox1 currenctly over PictureBox2"
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If isDragging1 Then
            Dim endPoint1 As Point = PictureBox1.PointToScreen(New Point(e.X, e.Y))
            PictureBox1.Left += (endPoint1.X - startPoint1.X)
            PictureBox1.Top += (endPoint1.Y - startPoint1.Y)
            startPoint1 = endPoint1
            isDragging2 = False
            PictureBox1.BringToFront()
            Me.Cursor = New Cursor(New System.IO.MemoryStream(My.Resources.H_MOVE))
            StatusBar1.Text = "PictureBox1: " + startPoint1.X.ToString + "," + startPoint1.Y.ToString
            If PictureBox1.Bounds.IntersectsWith(PictureBox2.Bounds) Then
                StatusBar1.Text += " || " + "PictureBox1 currenctly over PictureBox2"
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        isDragging1 = False
        isDragging2 = False
        PictureBox1.BringToFront()
        StatusBar1.Text = "PictureBox1: " + startPoint1.X.ToString + "," + startPoint1.Y.ToString
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If PictureBox1.Bounds.IntersectsWith(PictureBox2.Bounds) Then
            StatusBar1.Text += " || " + "PictureBox1 currenctly over PictureBox2"
        End If
    End Sub
    'PictureBox 1 ends

    'PictureBox 2 starts
    Private Sub PictureBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        startPoint2 = PictureBox2.PointToScreen(New Point(e.X, e.Y))
        isDragging2 = True
        isDragging1 = False
        PictureBox2.BringToFront()
        Me.Cursor = New Cursor(New System.IO.MemoryStream(My.Resources.H_MOVE))
        StatusBar1.Text = "PictureBox2: " + startPoint2.X.ToString + "," + startPoint2.Y.ToString
        If PictureBox2.Bounds.IntersectsWith(PictureBox1.Bounds) Then
            StatusBar1.Text += " || " + "PictureBox2 currenctly over PictureBox1"
        End If
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        If isDragging2 Then
            Dim endPoint2 As Point = PictureBox2.PointToScreen(New Point(e.X, e.Y))
            PictureBox2.Left += (endPoint2.X - startPoint2.X)
            PictureBox2.Top += (endPoint2.Y - startPoint2.Y)
            startPoint2 = endPoint2
            isDragging1 = False
            PictureBox2.BringToFront()
            Me.Cursor = New Cursor(New System.IO.MemoryStream(My.Resources.H_MOVE))
            StatusBar1.Text = "PictureBox2: " + startPoint2.X.ToString + "," + startPoint2.Y.ToString
            If PictureBox2.Bounds.IntersectsWith(PictureBox1.Bounds) Then
                StatusBar1.Text += " || " + "PictureBox2 currenctly over PictureBox1"
            End If
        End If
    End Sub

    Private Sub PictureBox2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        isDragging2 = False
        isDragging1 = False
        PictureBox2.BringToFront()
        Me.Cursor = System.Windows.Forms.Cursors.Default
        StatusBar1.Text = "PictureBox2: " + startPoint2.X.ToString + "," + startPoint2.Y.ToString
        If PictureBox2.Bounds.IntersectsWith(PictureBox1.Bounds) Then
            StatusBar1.Text += " || " + "PictureBox2 currenctly over PictureBox1"
        End If
    End Sub
    'PictureBox 2 ends
End Class
