Public Class Form1
    Dim ClickCount As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            Play_Music("鼓.wav")
        End If
        Timer1().Start()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled() = 0
        Label2().Text() = "0"
        ClickCount = 0
        Me.Width = 700
        Me.Height = 700
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim m, id, T
        m = ListBox1().Items().Count()
        Randomize()
        id = Int(Rnd() * 10000 + Rnd() * 10000) Mod m
        Label1.Text() = ListBox1().Items().Item(id)
        T = Int(Label2().Text())
        T = T + 1
        If (T > 61) Then
            Timer1().Stop()
            If CheckBox2.Checked = True Then
                ListBox3().Items().Add(ListBox1().Items().Item(id))
                ListBox1().Items().RemoveAt(id)
            End If
            T = 0
        End If
        Label2().Text() = Str(T)
    End Sub
    Private Sub Play_Music(ByVal Mname As String)

        Dim res As IO.Stream = Reflection.Assembly.GetEntryAssembly.GetManifestResourceStream("DrawLots." & Mname)

        Dim bytes(res.Length - 1) As Byte

        res.Read(bytes, 0, bytes.Length)

        My.Computer.Audio.Play(bytes, AudioPlayMode.Background)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim m, id, T
        Do
            m = ListBox1().Items().Count()
            Randomize()
            id = Int(Rnd() * 10000 + Rnd() * 10000) Mod m
            Label1.Text() = ListBox1().Items().Item(id)
            T = Int(Label2().Text())
            T = T + 1
            Label2().Text() = Str(T)
            ListBox2.Items(id) = (1 + Int(ListBox2.Items(id))).ToString
        Loop While T <= 20
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListBox3.Items.Count = 0 Then
            MsgBox("不需要重置还搁这重置，，，再见qaq", MsgBoxStyle.Exclamation)
            Me.Dispose()
            Application.Exit()
        End If
        While ListBox3.Items.Count > 0
            ListBox1().Items().Add(ListBox3.Items().Item(0))
            ListBox3.Items().RemoveAt(0)
        End While
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox("作者很懒...懒得写这块代码.", MsgBoxStyle.Information)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ClickCount = ClickCount + 1
        If (ClickCount > 5) Then
            MsgBox("嘿，这个彩蛋都被你发现了。奖励一朵小红花"， MsgBoxStyle.Critical)
            ClickCount = 0
        End If
    End Sub


End Class
