Imports System.IO.Ports
Imports MySql.Data.MySqlClient ' Ensure you have the MySQL library imported

Public Class Form1

    Private WithEvents serialPort As New SerialPort("COM6", 9600)
    Private conn As New MySqlConnection
    Private CMD As MySqlCommand
    Private constring As String = "data source = localhost; userid = root; password = ; database = experiment4"
    Private startReceived As Boolean = False
    Private isStopped As Boolean = False ' Flag to track if the encoder is stopped
    Private resetActive As Boolean = False ' Flag to track if reset is active

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        serialPort.BaudRate = 9600
        serialPort.DataBits = 8
        serialPort.Parity = Parity.None
        serialPort.StopBits = StopBits.One
        serialPort.Handshake = Handshake.None

        Try
            serialPort.Open()
        Catch ex As Exception
            MessageBox.Show("Error opening serial port: " & ex.Message)
        End Try
    End Sub

    Private Sub Guna2ToggleSwitch1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ToggleSwitch1.CheckedChanged
        Try
            If Guna2ToggleSwitch1.Checked Then
                conn = New MySqlConnection(constring)
                conn.Open()
                MsgBox("Successfully Connected to Database experiment4", vbInformation, "Confirmation Window")

            Else
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                    MsgBox("Disconnected from Database experiment4", vbInformation, "Confirmation Window")

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub serialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serialPort.DataReceived
        Dim incomingData As String = serialPort.ReadLine()
        Debug.WriteLine("Received: " & incomingData)

        Me.Invoke(Sub()
                      Dim dataParts As String() = incomingData.Split(New String() {": "}, StringSplitOptions.None)

                      If dataParts.Length >= 2 Then
                          Select Case dataParts(0)
                              Case "Counter"
                                  ' Keep updating the counter as long as stop hasn't been pressed
                                  If Not isStopped Then
                                      Dim counterValue As Integer
                                      If Integer.TryParse(dataParts(1), counterValue) AndAlso counterValue >= 0 Then
                                          LabelEncoderValue.Text = counterValue.ToString()

                                          ' If reset is active and the encoder moves, change the state to "start"
                                          If resetActive AndAlso counterValue > 0 Then
                                              LabelStartButton.Text = "start"
                                              resetActive = False ' Reset the flag since state has changed to start
                                              Debug.WriteLine("Status changed to 'start' after rotation")
                                          End If
                                      End If
                                  End If
                              Case "Status"
                                  Select Case dataParts(1).Trim().ToLower()
                                      Case "start"
                                          startReceived = True
                                          isStopped = False ' Allow updates
                                          resetActive = False ' Reset should not be active during start
                                          Debug.WriteLine("Start received: True")

                                      Case "reset"
                                          ' Reset the counter to 0, set status to reset, and allow encoder movement
                                          LabelEncoderValue.Text = "0"
                                          LabelStartButton.Text = "reset"
                                          resetActive = True ' Set reset flag to true
                                          startReceived = False
                                          isStopped = False
                                          Debug.WriteLine("Reset received: Counter reset to 0")

                                      Case "stop"
                                          isStopped = True ' Stop updates
                                          Debug.WriteLine("Stop received: Stopped updates")

                                  End Select
                                  LabelStartButton.Text = dataParts(1).Trim()
                          End Select
                      Else
                          Debug.WriteLine("Invalid data format received.")
                      End If
                  End Sub)
    End Sub

    Private Sub SaveData()
        If String.IsNullOrEmpty(LabelEncoderValue.Text) Then
            MessageBox.Show("No valid data to save. Please rotate the encoder to display a value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim counterValue As Integer = Integer.Parse(LabelEncoderValue.Text)
        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                CMD = New MySqlCommand("INSERT INTO rotary (VALUE, STATUS) VALUES (@Value, @Status)", conn)
                CMD.Parameters.AddWithValue("@Value", counterValue)
                CMD.Parameters.AddWithValue("@Status", LabelStartButton.Text)
                CMD.ExecuteNonQuery()

                MessageBox.Show("Data saved successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message)
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If serialPort.IsOpen Then
            serialPort.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        SaveData()
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        SaveData()
    End Sub
End Class
