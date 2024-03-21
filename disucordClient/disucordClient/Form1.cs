using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//Berke Ceylan & Fırat Yurdakul

namespace disucordClient
{
    public partial class Form1 : Form
    {
        Socket clientSocket;
        bool terminating = false;
        bool connected = false;

        string username;

        bool isSubscribedToIF100 = false;
        bool isSubscribedToSPS101 = false;

        private ManualResetEvent sps101UnsubscribeComplete = new ManualResetEvent(false);


        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        // Event handler for the form closing
        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //unsub from both channels if client is subscribed
            if (isSubscribedToIF100 == true)
            {
                string message = $"UNSUB:IF100";
                sendMessage(message);
            }
            if (isSubscribedToSPS101 == true)
            {
                string message = $"UNSUB:SPS101";
                sendMessage(message);
            }
            //close port
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }
        // button_connect_Click
        // handle the connection procedure to server 
        private void button_connect_Click(object sender, EventArgs e)
        {
            //to clear channel boxes after before we connect    
            if100_logs.Clear();
            sps101_logs.Clear();

            terminating = false; //to connect after disconnect

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string IP = textbox_ip.Text;
            username = textbox_username.Text;
            int portNum;

            if (username != "")
            {//check username

                if (Int32.TryParse(textbox_port.Text, out portNum))
                { //parse port number

                    if (portNum < 0 && portNum > 65535)
                    {//check the validty of port number
                        logs.AppendText("Invalid Port Number\n");
                    }

                    if (textbox_ip.Text != "")
                    { //check ip

                        try
                        {
                            clientSocket.Connect(IP, portNum);//connect
                            connected = true;

                            //set UI elements
                            pictureBox_status.BackColor = Color.Green;
                            button_connect.Enabled = false;
                            button_disconnect.Enabled = true;
                            combobox_channel.Enabled = true;
                            button_subscribe.Enabled = true;

                            sendMessage($"USERNAME: {username}");//send username to server

                            Thread receiveThread = new Thread(Receive);//start the thread to receive message from server
                            receiveThread.Start();

                        }
                        catch (SocketException ex)//catch connection error
                        {

                            if (ex.SocketErrorCode == SocketError.ConnectionRefused)//socket error carch
                            {
                                logs.AppendText("Cannot connect to server!\n");
                                logs.AppendText("Please check port number and try again...\n");
                            }
                            else//IP error catch
                            {
                                logs.AppendText("Cannot connect to server!\n");
                                logs.AppendText("Please check IP address and try again...\n");
                            }
                            logs.ScrollToCaret();

                        }

                    }
                    else//ip cannot be mepth
                    {
                        logs.AppendText("IP cannot be empty!\n");
                        logs.AppendText("Please try again...\n");
                        logs.ScrollToCaret();
                    }

                }
                else//invalid port number
                {
                    logs.AppendText("Invalid port number!\n");
                    logs.AppendText("Please try again...\n");
                    logs.ScrollToCaret();
                }
            }
            else//username cannot be empty
            {
                textbox_username.Text = "";
                logs.AppendText("Username cannot be empty!\n");
                logs.AppendText("Please try again...\n");
                logs.ScrollToCaret();
            }

        }

        // senMessage
        // used to mainly send message to server side for various puropse
        private void sendMessage(string message)
        {
            Byte[] buffer = new Byte[10000000];//buffer is big to prevent unexpected requirments
            buffer = Encoding.Default.GetBytes(message);
            clientSocket.Send(buffer);
        }
        // Receive
        // receive messages from server side
        // perfom operations according to predifened token system
        // PIF100 -> print message to if100_logs
        // PSPS101 -> print message to sps01_logs
        // SERVERCLOSED -> to handle is server closed before client
        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[10000];
                    int receivedBytes = clientSocket.Receive(buffer);

                    if (receivedBytes > 0)
                    {
                        string incomingMessage = Encoding.Default.GetString(buffer, 0, receivedBytes);
                        bool containsColon = incomingMessage.Contains(":");//check wheather coming message has a predifened token

                        if (containsColon)
                        {
                            string[] messageParts = incomingMessage.Split(':');
                            //message splited 2 parts
                            //messageParts[0] = token
                            //messageParts[1] = actual message

                            if (messageParts[0] == "PIF100")
                            {
                                if100_logs.AppendText(messageParts[1]);//print message to if100 channel
                            }
                            else if (messageParts[0] == "PSPS101")
                            {
                                sps101_logs.AppendText(messageParts[1]);

                                //To prevent closing socket before printing all the values in buffer
                                //in disconnection case it was needed
                                if (messageParts[1].Contains("unsubscribed"))//print message to sps101 channel
                                {
                                    sps101UnsubscribeComplete.Set();
                                }
                            }
                            else if (messageParts[0] == "SERVERCLOSED")//print server closing message
                            {
                                logs.AppendText("Server has closed the connection.\n");

                                pictureBox_status.BackColor = Color.Red;
                                connected = false;//disconnect
                                //Reset UI
                                button_connect.Enabled = true;
                                button_disconnect.Enabled = false;
                                combobox_channel.Enabled = false;
                                button_subscribe.Enabled = false;
                                button_unsubscribe.Enabled = false;
                                comboBox_message.Enabled = false;
                                textbox_message.Enabled = false;
                                button_send.Enabled = false;
                                isSubscribedToIF100 = false;
                                isSubscribedToSPS101 = false;
                            }
                        }
                        else
                        {//incoming message dont have a token so it will be printed to actions
                            logs.AppendText(incomingMessage);
                        }

                    }
                    else
                    {
                        throw new SocketException();
                    }
                }
                catch//disconnect
                {
                    if (!terminating)
                    {

                        pictureBox_status.BackColor = Color.Red;
                        connected = false;
                        //Reset UI
                        button_connect.Enabled = true;
                        combobox_channel.Enabled = false;
                        button_subscribe.Enabled = false;
                        button_unsubscribe.Enabled = false;
                        comboBox_message.Enabled = false;
                        textbox_message.Enabled = false;
                        button_send.Enabled = false;
                        isSubscribedToIF100 = false;
                        isSubscribedToSPS101 = false;
                    }
                }
            }
        }

        // button_disconnect_Click
        // handle disconnect operation and send unsubscribe message for subscribed channels to server
        private void button_disconnect_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                //unsubscribe from both channel when client disconnect
                if (isSubscribedToIF100 == true)
                {
                    string message = $"UNSUB:IF100";
                    sendMessage(message);
                    logs.AppendText($"You have unsubscribed from IF100 channel.\n");
                }
                if (isSubscribedToSPS101 == true)
                {
                    string message = "UNSUB:SPS101";
                    sendMessage(message);
                    //This part used to prevent disconnecting before receiving response from server
                    sps101UnsubscribeComplete.Reset();  // Reset the event state
                    sps101UnsubscribeComplete.WaitOne(); // Wait for the event to be set
                    logs.AppendText("You have unsubscribed from SPS101 channel.\n");

                }

                logs.AppendText("Disconnected from the server.\n");

                // Reset UI
                button_connect.Enabled = true;
                combobox_channel.Enabled = false;
                button_subscribe.Enabled = false;
                button_unsubscribe.Enabled = false;
                comboBox_message.Enabled = false;
                textbox_message.Enabled = false;
                button_send.Enabled = false;
                isSubscribedToIF100 = false;
                isSubscribedToSPS101 = false;
                if100_logs.Enabled = false;
                sps101_logs.Enabled = false;

                connected = false;//disconnect
                pictureBox_status.BackColor = Color.Red;
                clientSocket.Close();//close socket


            }
        }

        // button_subscribe_Click
        // handle the subscribe operation
        // send message to server as 
        // SUB:"channel" -> Subscribe to spesified channel
        private void button_subscribe_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                string selectedChannel = combobox_channel.SelectedItem.ToString();

                bool shouldSendMessage = false;

                if (selectedChannel == "IF100" && !isSubscribedToIF100)
                {//Subscribe form sps101 channel
                    isSubscribedToIF100 = true;
                    shouldSendMessage = true;
                    button_subscribe.Enabled = true;
                    button_unsubscribe.Enabled = true;
                    if100_logs.Enabled = true;
                    comboBox_message.Enabled = true;
                    button_send.Enabled = true;
                    textbox_message.Enabled = true;

                }
                else if (selectedChannel == "SPS101" && !isSubscribedToSPS101)
                {//Subscribe form sps101 channel
                    isSubscribedToSPS101 = true;
                    shouldSendMessage = true;
                    button_subscribe.Enabled = true;
                    button_unsubscribe.Enabled = true;
                    sps101_logs.Enabled = true;
                    comboBox_message.Enabled = true;
                    button_send.Enabled = true;
                    textbox_message.Enabled = true;

                }
                if (if100_logs.Enabled == true && sps101_logs.Enabled == true)
                {//if client subscribed to both channels cannot click subscribe button
                    button_subscribe.Enabled = false;
                }
                if (shouldSendMessage)
                {
                    //only send SUB message to server in first click other clicks are not send anything
                    //to prevent conflicfts in server side
                    string subscriptionMessage = $"SUB:{selectedChannel}";
                    sendMessage(subscriptionMessage);
                    logs.AppendText($"You have subscribed to {selectedChannel} channel.\n");
                }
                else//message to client to show that he/she already subscribed
                {
                    logs.AppendText($"You are already subscribed to {selectedChannel} channel.\n");
                }
            }
        }

        // button_unsubscribe_Click
        // handle the unsubscribe operation
        // send message to server as 
        // UNSUB:"channel" -> Unsubscribe to spesified channel
        private void button_unsubscribe_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                string selectedChannel = combobox_channel.SelectedItem.ToString();

                bool shouldSendMessage = false;

                if (selectedChannel == "IF100" && isSubscribedToIF100)
                {//Unsubscribe form if 100 channel
                    isSubscribedToIF100 = false;
                    shouldSendMessage = true;

                    button_subscribe.Enabled = true;
                    if100_logs.Enabled = false;
                }
                else if (selectedChannel == "SPS101" && isSubscribedToSPS101)
                {//Unsubscribe form sps101 channel
                    isSubscribedToSPS101 = false;
                    shouldSendMessage = true;

                    button_subscribe.Enabled = true;
                    sps101_logs.Enabled = false;
                }
                if (if100_logs.Enabled == false && sps101_logs.Enabled == false)
                {//if both channels are unsubscribed disable unsubscribe button and message send parts
                    button_unsubscribe.Enabled = false;
                    comboBox_message.Enabled = false;
                    button_send.Enabled = false;
                    textbox_message.Enabled = false;
                }
                if (shouldSendMessage)
                {
                    //only send UNSUB message to server in first click other clicks are not send anything
                    //to prevent conflicfts in server side
                    string unsubscriptionMessage = $"UNSUB:{selectedChannel}";
                    sendMessage(unsubscriptionMessage);
                    logs.AppendText($"You have unsubscribed from {selectedChannel} channel.\n");
                }
                else//message to client to show that he/she already unsubscribed
                {
                    logs.AppendText($"You are not subscribed to {selectedChannel} channel.\n");
                }
            }
        }

        // button_send_Click
        // handle messsage send operation
        // send two tokens to server
        // IF100M -> send message to IF100 channel
        // SPS101M -> send message to sps101 channel
        private void button_send_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                string messageToSend = textbox_message.Text;
                string messageChannel = comboBox_message.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(messageToSend))
                {
                    if (messageChannel == "IF100" && isSubscribedToIF100)
                    {//send message token to indicate client send message to if100 channel
                        messageToSend = "IF100M:" + messageToSend;
                        sendMessage(messageToSend);
                        logs.AppendText($"You send a message to IF100 channel\n");
                    }
                    else if (messageChannel == "SPS101" && isSubscribedToSPS101)
                    {//send message token to indicate client send message to sps101 channel
                        messageToSend = "SPS101M:" + messageToSend;
                        sendMessage(messageToSend);
                        logs.AppendText($"You send a message to SPS101 channel\n");
                    }
                    else if (messageChannel == "SPS101" && !isSubscribedToSPS101)
                    {//prevent sending message to unsubscribed channels
                        logs.AppendText($"You cannot send a message to SPS101 channel\n");
                    }
                    else if (messageChannel == "IF100" && !isSubscribedToIF100)
                    {//prevent sending message to unsubscribed channels
                        logs.AppendText($"You cannot send a message to IF101 channel\n");
                    }

                    textbox_message.Clear();
                }
                else
                {//handle empty message
                    logs.AppendText("Cannot send an empty message.\n");
                    logs.AppendText("Please try again...\n");
                }
            }
        }
    }
}
