Imports System.Xml

Public Class config
    Private Sub config_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ListBox3.Items.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ListBox3.Items.Add(sp)
        Next

        Using reader As XmlReader = XmlReader.Create(Application.UserAppDataPath + "\configuracion.xml")
            While reader.Read()
                If reader.IsStartElement() Then
                    If Not reader.IsEmptyElement Then
                        If reader.Name <> "Configuracion" Then
                            If Not reader.IsEmptyElement Then
                                ListBox1.Items.Add(reader.Name)
                                ListBox2.Items.Add(reader.ReadString())

                            End If
                        End If
                    End If
                End If
            End While
            reader.Close()

        End Using
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As System.EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedIndex <> -1 Then
            ListBox2.Items.Item(ListBox1.SelectedIndex) = InputBox(ListBox1.Items.Item(ListBox1.SelectedIndex), "Cambiar configuración", ListBox2.Items.Item(ListBox1.SelectedIndex))
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Visible = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        Using reader As XmlReader = XmlReader.Create(Application.UserAppDataPath + "\configuracion.xml")
            While reader.Read()
                If reader.IsStartElement() Then
                    If Not reader.IsEmptyElement Then
                        If reader.Name <> "Configuracion" Then
                            If Not reader.IsEmptyElement Then
                                ListBox1.Items.Add(reader.Name)
                                ListBox2.Items.Add(reader.ReadString())

                            End If
                        End If
                    End If
                End If
            End While
        End Using
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim settings As New XmlWriterSettings()
        settings.Indent = True

        ' Initialize the XmlWriter.
        Dim XmlWrt As XmlWriter = XmlWriter.Create(Application.UserAppDataPath + "\configuracion.xml", settings)
        With XmlWrt
            .WriteStartDocument()
            .WriteStartElement("Configuracion")
            For c = 0 To ListBox1.Items.Count - 1
                .WriteStartElement(ListBox1.Items.Item(c))
                .WriteString(ListBox2.Items.Item(c))
                .WriteEndElement()

            Next
            .WriteEndDocument()
            .Close()
        End With
        Me.Visible = False
        ' Form1.tiempo()

    End Sub
End Class