using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Hansot_Kiosk.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Hansot_Kiosk.Network
{
    public class TCPNet
    {
        // The port number for the remote device.  
        private const int port = 80;

        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.  
        private static String response = String.Empty;
        Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);

        private string userId;


        public void StartClient()
        {
            try
            {
                client.BeginConnect("10.80.163.197", 80, new AsyncCallback(ConnectCallback), client);
                //connectDone.WaitOne();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void CloseClient()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        public void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint.ToString());
                MessageBox.Show("매장 서버와 성공적으로 연결되었습니다!");
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Receive()
        {
            try
            {
                StateObject state = new StateObject();
                state.workSocket = client;

                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
                try
                {
                    StateObject state = (StateObject)ar.AsyncState;
                    Socket client = state.workSocket;
                    int bytesRead = client.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        state.sb = new StringBuilder(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
                        if (state.sb.ToString() != "200") 
                        {
                        MessageBox.Show(state.sb.ToString());
                    }
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                        //receiveDone.Set();
                    }
                    else
                    {
                        if (state.sb.Length > 1)
                        {
                        MessageBox.Show(state.sb.ToString());
                        }
                    MessageBox.Show("현재 매장 서버가 점검 중이오니 직접 주문을 해주시면 감사하겠습니다."); 
                        //receiveDone.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
        }

        public void Send(String data)
        {
            if (client.Connected)
            {
                byte[] byteData = Encoding.UTF8.GetBytes(data);

                client.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), client);
            } else
            {
                MessageBox.Show("현재 매장 서버에 연결되어 있지 않습니다. 직접 주문을 해주시면 감사하겠습니다.");
            }
            
        }

        public void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;

                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void SetUser(string Id)
        {
            userId = Id;
            StartClient();
        }

        public void Login()
        {
            RequestMessage requestJson = new RequestMessage();
            requestJson.MSGType = (MessageType)0;
            requestJson.Id = userId;
            string json = JsonConvert.SerializeObject(requestJson);
            Send(json);
            var thReceive = new Thread(Receive);
            thReceive.Start();
        }

        public void SendMessage(string message)
        {
            RequestMessage requestJson = new RequestMessage();
            requestJson.MSGType = (MessageType)1;
            requestJson.Id = userId;
            requestJson.Content = message;
            requestJson.ShopName = "";
            requestJson.OrderNumber = "";
            requestJson.Menus = null;
            string json = JsonConvert.SerializeObject(requestJson);
            Send(json);
        }
    }
}