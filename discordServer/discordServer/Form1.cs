using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//Berke Ceylan & Fırat Yurdakul

namespace discordServer
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Client> clients = new List<Client>();

        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        // button_listen_Click_1
        // handle the listen procedure
        private void button_listen_Click_1(object sender, EventArgs e)
        {
            int serverPort;
            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(300);

                // Update server state
                listening = true;
                button_listen.Enabled = false;
                logs_server.AppendText("Started listening on port: " + serverPort + "\n");

                // Start a new thread to handle client connections
                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

            }
            else {
                logs_server.AppendText("Unable to listen given port!\nTry to listen with different port number...\n");
            }
        }

        // Accept
        // Method to accept incoming client connections
        private void Accept()
        {
            while (listening)
            {
                try
                {
                    // Accept a new client connection
                    Socket newClientSocket = serverSocket.Accept();
                    // Receive the initial message from the client
                    Byte[] buffer = new Byte[1024]; // Adjust buffer size as needed
                    int rec = newClientSocket.Receive(buffer);

                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }

                    // Extract username from the initial message
                    string incomingMessage = Encoding.Default.GetString(buffer).Substring(0, rec);
                    string[] messageParts = incomingMessage.Split(':');

                    // Check if the message is a valid username
                    if (messageParts.Length >= 2 && messageParts[0] == "USERNAME")
                    {
                        string username = messageParts[1];

                        // Check if the username already exists
                        if (clients.Any(c => c.Name == username))
                        {
                            // Notify the client about the duplicate username
                            string message = "This username already exists.\nTry a different username...\n";
                            newClientSocket.Send(Encoding.Default.GetBytes(message));
                            newClientSocket.Close();

                            // Update server logs
                            this.Invoke((MethodInvoker)delegate
                            {
                                logs_server.AppendText($"This username \"{username}\" already exists.\n");
                            });
                        }
                        else
                        {
                            // Create a new client object and add it to the list
                            Client newClient = new Client(username, newClientSocket);
                            clients.Add(newClient);

                            // Update server logs and connected users list
                            this.Invoke((MethodInvoker)delegate
                            {
                                logs_server.AppendText($"A new user \"{username}\" connected.\n");
                                serverUsers.AppendText($"{username}\n");
                            });

                            string message = $"Connected to the server!\nHello, {username}\nPlease select a channel that you want to subscribe.\n";
                            newClientSocket.Send(Encoding.Default.GetBytes(message));

                            // Start a new thread to handle messages from the client
                            Thread receiveThread = new Thread(() => Receive(newClientSocket));
                            receiveThread.Start();
                        }
                    }
                    else
                    {
                        string errorMessage = "Invalid message format.";
                        newClientSocket.Send(Encoding.Default.GetBytes(errorMessage));
                        newClientSocket.Close();
                    }
                }
                catch//genereal exception catch to prevent any crash
                {
                    logs_server.AppendText("Error Occured!");

                }
            }
        }

        // RemoveFromLogs
        // Method to remove specific text from a RichTextBox
        private void RemoveFromLogs(RichTextBox richTextBox, string textToRemove)
        {
            int index = richTextBox.Text.IndexOf(textToRemove);
            if (index >= 0) // Text found
            {
                richTextBox.Select(index, textToRemove.Length); // Select the text
                richTextBox.SelectedText = ""; // Remove the selected text
            }
        }

        // Receive
        // Method to handle receiving messages from a client
        // Perfom operations according to predifened token system
        // SUB -> add client to defined channel and send subscription message to channel
        // UNSUB -> remove client from defined channel and send unsubscription message to channel
        // IF100M -> broadcast message to IF100 channel
        // SPS101M -> broadcast message to SPS101 channel
        // send PIF100 and PSPS101 tokens to client according to operrations
        private void Receive(Socket thisClient)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    // Receive a message from the client
                    Byte[] buffer = new Byte[10000];
                    int rec = thisClient.Receive(buffer);
                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }

                    // Extract the message and find the corresponding client object
                    string incomingMessage = Encoding.Default.GetString(buffer).Substring(0, rec);
                    Client client = clients.FirstOrDefault(c => c.ClientSocket == thisClient);

                    if (client != null)
                    {
                        // Splitting message header part for cheking afterwards
                        string[] messageParts = incomingMessage.Split(':');
                        //message splited 2 parts
                        //messageParts[0] = token
                        //messageParts[1] = actual message

                        if (messageParts.Length >= 2)
                        {
                            // Process different message types
                            if (messageParts[0] == "SUB")
                            {
                                string channel = messageParts[1];
                                if (channel == "IF100")
                                {
                                    // If subscribed to IF100 channel
                                    client.IsSubscribedToIF100 = true;
                                    if100Users.AppendText($"{client.Name}\n");//add client to list
                                    logs_if100.AppendText($"{client.Name} subscribed to IF100.\n");

                                    // Broadcast subscription message to other clients who subscribed to IF100 channel
                                    string breadcastMessage = $"PIF100:{client.Name} subscribed to IF100.\n";
                                    BroadcastMessage(client, breadcastMessage, true);
                                }
                                else if (channel == "SPS101")
                                {
                                    // If subscribed to SPS101 channel
                                    client.IsSubscribedToSPS101 = true;
                                    sps101Users.AppendText($"{client.Name}\n");//add client to list
                                    logs_sps101.AppendText($"{client.Name} subscribed to SPS101.\n");

                                    // Broadcast subscription message to other clients who subscribed to SPS101 channel
                                    string breadcastMessage = $"PSPS101:{client.Name} subscribed to SPS101.\n";
                                    BroadcastMessage(client, breadcastMessage, false);
                                }
                            }
                            else if (messageParts[0] == "UNSUB")
                            {
                                string channel = messageParts[1];
                                if (channel == "IF100")
                                {

                                    RemoveFromLogs(if100Users, $"{client.Name}\n");//remove client from list
                                    logs_if100.AppendText($"{client.Name} unsubscribed from IF100.\n");

                                    // Broadcast unsubscription message to other clients who subscribed to IF100 channel
                                    string breadcastMessage = $"PIF100:{client.Name} unsubscribed from IF100.\n";
                                    BroadcastMessage(client, breadcastMessage, true);
                                    client.IsSubscribedToIF100 = false;

                                }
                                else if (channel == "SPS101")
                                {

                                    RemoveFromLogs(sps101Users, $"{client.Name}\n");//remove client from list
                                    logs_sps101.AppendText($"{client.Name} unsubscribed from SPS101.\n");

                                    // Broadcast unsubscription message to other clients who subscribed to SPS101 channel
                                    string breadcastMessage = $"PSPS101:{client.Name} unsubscribed from SPS101.\n";
                                    BroadcastMessage(client, breadcastMessage, false);
                                    client.IsSubscribedToSPS101 = false;

                                }

                            }
                            else if (messageParts[0] == "IF100M")
                            {
                                logs_if100.AppendText($"{client.Name}:{messageParts[1]}\n");

                                // Broadcast message to other clients in the IF100 channel
                                string breadcastMessage = $"PIF100:{client.Name} => {messageParts[1]}\n";
                                BroadcastMessage(client, breadcastMessage, true);

                            }
                            else if (messageParts[0] == "SPS101M")
                            {
                                logs_sps101.AppendText($"{client.Name}:{messageParts[1]}\n");

                                // Broadcast message to other clients in the SPS101 channel
                                string breadcastMessage = $"PSPS101:{client.Name} => {messageParts[1]}\n";
                                BroadcastMessage(client, breadcastMessage, false);


                            }
                        }

                        logs_server.AppendText($"{client.Name}>{incomingMessage}\n");
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        Client client = clients.FirstOrDefault(c => c.ClientSocket == thisClient);
                        if (client != null)
                        {
                            // Update server logs and remove disconnected client
                            logs_server.AppendText($"{client.Name} user is disconnected\n");//additional \n add to begining for line accuracy

                            RemoveFromLogs(serverUsers, $"{client.Name}\n");

                            if (client.IsSubscribedToIF100 == true)
                            {
                                RemoveFromLogs(if100Users, $"{client.Name}\n");
                            }
                            if (client.IsSubscribedToSPS101 == true)
                            {
                                RemoveFromLogs(sps101Users, $"{client.Name}\n");
                            }

                            clients.Remove(client);
                        }
                        else
                        {
                            // Update server logs for a general client disconnection
                            logs_server.AppendText("A client has disconnected.\n");
                        }
                        thisClient.Close();
                        connected = false;
                    }
                }
            }
        }

        // sendMessage
        // Method to send a message to the server
        private void sendMessage(string message)
        {
            Byte[] buffer = new Byte[10000000];
            buffer = Encoding.Default.GetBytes(message);
            serverSocket.Send(buffer);
        }

        // BroadcastMessage
        // Method to broadcast a message to clients in a specific channel
        private void BroadcastMessage(Client sender, string message, bool isIF100)
        {
            foreach (Client client in clients)
            {
                // Check if the client is subscribed to the specified channel
                if ((isIF100 == true && client.IsSubscribedToIF100) || (isIF100 == false && client.IsSubscribedToSPS101))
                {
                    try
                    {
                        // Send the message to the subscribed client
                        client.ClientSocket.Send(Encoding.Default.GetBytes(message));
                    }
                    catch
                    {
                        logs_server.AppendText("Error accured while broadcasting message!");
                    }
                }
            }
        }

        // BroadcastToAllClients
        // Method to broadcast a message to all connected clients
        private void BroadcastToAllClients(string message)
        {
            byte[] buffer = Encoding.Default.GetBytes(message);

            foreach (Client client in clients)
            {
                try
                {
                    client.ClientSocket.Send(buffer);
                }
                catch
                {
                    logs_server.AppendText("Error accured while broadcasting message!");
                }
            }
        }

        // Event handler for the form closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Broadcast a closing message to all clients
            BroadcastToAllClients("SERVERCLOSED:Server is shutting down.");

            // Update server state
            listening = false;
            terminating = true;

            // Close all client sockets
            foreach (var client in clients)
            {
                client.ClientSocket.Close(); // Optionally close each client socket
            }

            serverSocket.Close(); // Close the server socket
            Environment.Exit(0); // Ensure the server application closes completely
        }

    }

    // Class to represent a connected client
    public class Client
    {
        public string Name { get; set; }
        public bool IsSubscribedToIF100 { get; set; }
        public bool IsSubscribedToSPS101 { get; set; }
        public Socket ClientSocket { get; set; } // Optional

        public Client(string name, Socket clientSocket)
        {
            Name = name;
            IsSubscribedToIF100 = false;
            IsSubscribedToSPS101 = false;
            ClientSocket = clientSocket;
        }
    }
}
