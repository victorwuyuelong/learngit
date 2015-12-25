using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using LitJson;


namespace ServerFast
{
    public partial class Form1 : Form
    {
        //  ServerFast c1 = new ServerFast();

        public Form1()
        {
            InitializeComponent();
            textBox1_zhujiip.Text = GetIP();
            ListBox.CheckForIllegalCrossThreadCalls = false;
        }
        public bool btnstatu = true;//开始停止侦听
        public bool online = true;//在线判断
        public Thread mythread1, mythread2, mythread4;
        private enum DataMode { Text, Hex }
        private char[] HexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f' };
        private Socket _socket;
        private bool CharInArray(char aChar, char[] charArray)
        {
            return (Array.Exists<char>(charArray, delegate(char a) { return a == aChar; }));
        }

        private static Dictionary<string, Socket> dicOnline;
        String GetIP()
        {
            String strHostName = Dns.GetHostName();

            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);


            // Grab the first IP addresses
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
                return IPStr;
            }
            return IPStr;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {

            if (btnstatu)
            {
                SocketAdmin(textBox1_zhujiip.Text.Trim(), out _socket, Convert.ToInt32(textBox2_zhujiduankou.Text.Trim()), out dicOnline);
                mythread2 = new Thread(LoopInfoMsg);//循环发送消息的方法
                mythread2.IsBackground = true;
                mythread2.Start();
                btnstatu = false;
                btnStart.Text = "关闭监听";
            }
            else
            {
                try
                {

                    mythread2.Abort();
                    lstOnline.Items.Clear();
                    dicOnlineSocket.Clear();
                    btnstatu = true;
                    CloseSockets();

                    btnStart.Text = "打开监听";
                }
                catch (Exception)
                {

                }
            }


        }
        /// <summary>
        /// 关闭所有socket通信
        /// </summary>
        void CloseSockets()
        {
            if (socket != null)
            {
                socket.Close();
            }
            Socket workerSocket = null;
            for (int i = 0; i < m_workerSocketList.Count; i++)
            {
                workerSocket = (Socket)m_workerSocketList[i];
                if (workerSocket != null)
                {
                    workerSocket.Close();
                    workerSocket = null;
                }
            }
        }

        /// <summary>
        /// 加入在线人数
        /// </summary>
        // string chu;


        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (lstOnline.SelectedItem != null)//如果已经选中了就准备发消息
            {
                Put_SendInfoToPool("text", txtString.Text, dicOnline[lstOnline.SelectedItem.ToString()]);
                textBox1_tiaoshi.Text += "已发送:" + txtString.Text.Trim() + "\r\n";
            }
            else
            {
                MessageBox.Show("请选择接受对象");
            }

        }
        /// <summary>

        /// 十六进制字符串转换字节数组

        /// </summary>

        /// <param name="s"></param>

        /// <returns></returns>

        private byte[] HexStringToByteArray(string s)
        {
            // s = s.Replace(" ", "");

            StringBuilder sb = new StringBuilder(s.Length);
            foreach (char aChar in s)
            {
                if (CharInArray(aChar, HexDigits))
                    sb.Append(aChar);
            }
            s = sb.ToString();
            int bufferlength;
            if ((s.Length % 2) == 1)
                bufferlength = s.Length / 2 + 1;
            else bufferlength = s.Length / 2;
            byte[] buffer = new byte[bufferlength];
            for (int i = 0; i < bufferlength - 1; i++)
                buffer[i] = (byte)Convert.ToByte(s.Substring(2 * i, 2), 16);
            if (bufferlength > 0)
                buffer[bufferlength - 1] = (byte)Convert.ToByte(s.Substring(2 * (bufferlength - 1), (s.Length % 2 == 1 ? 1 : 2)), 16);
            return buffer;
        }

        /// <summary>

        /// 当前发送模式

        /// </summary>

        private DataMode CurrentSendDataMode
        {
            get
            {
                return (chkHexSend.Checked) ? DataMode.Hex : DataMode.Text;
            }
            set
            {
                chkHexSend.Checked = (value == DataMode.Text);
            }
        }


        /// <summary>
        /// 消息类 键是id，data是json字符串
        /// </summary>
        public class MSGStruct
        {
            public string key;
            public string json;
        }

        #region 发用户的信息，只发个用户本人的
        /// <summary>
        /// 发用户的信息，只发个用户本人的
        /// </summary>
        /// <param name="type1"></param>
        /// <param name="type2"></param>
        /// <param name="msg"></param>
        /// 
        string m;
        Int32 lh;
        public void Put_SendInfoToPool(string key, string data, Socket sendSocket)
        {
            if (PoolInfoMsg == null)
            {
                PoolInfoMsg = new ArrayList();
            }
            _tempSocket = sendSocket;
            MSGStruct msg = new MSGStruct();
            msg.key = key;
            msg.json = data;
            string json = JsonMapper.ToJson(msg);
            lh = json.Length;
            m = json.Substring(22, lh - 24);
            //if (CurrentSendDataMode == DataMode.Text)
            //{
            //    data = Encoding.ASCII.GetBytes(rtfSend.Text);
            //}
            //else
            //{
            //    // 转换用户十六进制数据到字节数组

            //    data = HexStringToByteArray(rtfSend.Text);
            //}
            byte[] byteArr;
            if (CurrentSendDataMode == DataMode.Text)
            {
                //stringdata = Encoding.ASCII.GetString(byteDateLine, 0, recv);
                //  stringdata = Encoding.UTF8.GetChars(socketData.dataBuffer);
                //  MessageBox.Show(Convert.ToString(stringdata +"text"));
                //  m = m;
                byteArr = System.Text.Encoding.UTF8.GetBytes(m);
                //  txtString.Text

            }
            else
            {
                // stringdata = ByteArrayToHexString(chars);
                //  stringdata = stringdata.Substring(0, stringdata.Length - 3);


                byteArr = HexStringToByteArray(m);

                // MessageBox.Show(Convert.ToString(stringdata +"hex"));
            }

            // byte[] byteArr = System.Text.Encoding.UTF8.GetBytes(m);
            PoolInfoMsg.Add(byteArr);
        }
        private Socket _tempSocket;
        private ArrayList PoolInfoMsg;
        public void LoopInfoMsg()
        {
            while (_socket != null)
            {
                try
                {
                    if (PoolInfoMsg != null && PoolInfoMsg.Count > 0)//表示有消息
                    {
                        _tempSocket.Send((byte[])PoolInfoMsg[0]);

                        PoolInfoMsg.RemoveAt(0);//移除已发的消息
                    }
                    Thread.Sleep(100);

                }
                catch (Exception)
                {
                    //  MessageBox.Show(ex.Message);
                }


            }
        }


        #endregion




        private void button3_Click(object sender, EventArgs e)
        {
            if (lstOnline.SelectedItem != null)//如果已经选中了就准备发消息
                Put_SendInfoToPool("text", "AT+PORT1", dicOnline[lstOnline.SelectedItem.ToString()]);
            else
                MessageBox.Show("请选择接受对象");
        }





        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // if (mythread1 != null || mythread2 != null || mythread4 != null)
                if (mythread2 != null)
                {
                    //  mythread1.Abort();
                    mythread2.Abort();
                    //  mythread4.Abort();

                }
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.Message);
            }
        }


        private int m_clientCount = 0;
        Byte[] byteDateLine;

        public void OnConnectRequest(IAsyncResult ar)
        {
            try
            {

                //初始化一个SOCKET，用于其它客户端的连接
                //将要发送给连接上来的客户端的提示字符串
                Socket workerSocket = socket.EndAccept(ar);
                Interlocked.Increment(ref m_clientCount);
                m_workerSocketList.Add(workerSocket);
                string strDateLine = "find you";
                byteDateLine = System.Text.Encoding.UTF8.GetBytes(strDateLine);
                //将提示信息发送给客户端
                workerSocket.Send(byteDateLine, byteDateLine.Length, 0);
                //等待新的客户端连接
                ip = workerSocket.RemoteEndPoint.ToString();
                if (!dicOnlineSocket.ContainsKey(ip))
                    dicOnlineSocket.Add(ip, workerSocket);
                UpdateClientListControl();
                WaitForData(workerSocket, m_clientCount);
                socket.BeginAccept(new AsyncCallback(OnConnectRequest), null);
            }
            catch (Exception)
            {

            }

        }
        public AsyncCallback pfnWorkerCallBack;
        // Start waiting for data from the client
        public void WaitForData(System.Net.Sockets.Socket soc, int clientNumber)
        {
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    // Specify the call back function which is to be 
                    // invoked when there is any write activity by the 
                    // connected client
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket(soc, clientNumber);

                soc.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, pfnWorkerCallBack, theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        public class SocketPacket
        {
            // Constructor which takes a Socket and a client number
            public SocketPacket(System.Net.Sockets.Socket socket, int clientNumber)
            {
                m_currentSocket = socket;
                m_clientNumber = clientNumber;
            }
            public System.Net.Sockets.Socket m_currentSocket;
            public int m_clientNumber;
            // Buffer to store the data sent by the client
            public byte[] dataBuffer = new byte[1024];
        }
        private System.Collections.ArrayList m_workerSocketList =
                ArrayList.Synchronized(new System.Collections.ArrayList());
        public void OnDataReceived(IAsyncResult asyn)
        {
            SocketPacket socketData = (SocketPacket)asyn.AsyncState;
            try
            {

                // Complete the BeginReceive() asynchronous call by EndReceive() method
                // which will return the number of characters written to the stream 
                // by the client
                Socket workerSocket = (Socket)socketData.m_currentSocket;
                int iRx = socketData.m_currentSocket.EndReceive(asyn);
                // int iRx = socketData.m_currentSocket.EndReceive(byteDateLine);
                // recv = workerSocket.Receive(byteDateLine);
                //  MessageBox.Show(Convert.ToString(iRx));
                ip = workerSocket.RemoteEndPoint.ToString();
                if (iRx == 0)
                {
                    //当客户端终止连接时
                    // showinfo.AppendText(ip + "已从服务器断开");
                    //    MessageBox.Show(ip + "已从服务器断开");
                    dicOnlineSocket.Remove(ip);
                    UpdateClientListControl();
                    return;

                }


                char[] chars = new char[iRx + 1];
                //   txtString.Text = ByteArrayToHexString(chars);
                // Extract the characters as a buffer
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(socketData.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                if (CurrentReceiveDataMode == DataMode.Text)
                {
                    //stringdata = Encoding.ASCII.GetString(byteDateLine, 0, recv);
                    //  stringdata = Encoding.UTF8.GetChars(socketData.dataBuffer);
                    //  MessageBox.Show(Convert.ToString(stringdata +"text"));
                    stringdata = szData;

                }
                else
                {
                    stringdata = ByteArrayToHexString(chars);
                    stringdata = stringdata.Substring(0, stringdata.Length - 3);

                    // MessageBox.Show(Convert.ToString(stringdata +"hex"));
                }
                ////////////////////////////////////////////////////////////////
            
               //接收信息区域
                if (stringdata=="123\0")
                {      
                 Put_SendInfoToPool("text", "find you", dicOnline[ip]);
                }
               









                /////////////////////////////////////////////////////////////////
                string msg = "\r\n" + "【" + ip + "】:";
                AppendToRichEditControl(msg + stringdata);

                WaitForData(socketData.m_currentSocket, socketData.m_clientNumber);

            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "0", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10054) // Error code for Connection reset by peer
                {
                    string msg = "Client " + socketData.m_clientNumber + " Disconnected" + "\r\n";
                    AppendToRichEditControl(msg);

                    // Remove the reference to the worker socket of the closed client
                    // so that this object will get garbage collected
                    m_workerSocketList[socketData.m_clientNumber - 1] = null;
                    UpdateClientListControl();
                }
                else
                {
                    MessageBox.Show(se.Message);
                }
            }
        }
        public delegate void UpdateClientListCallback();
        private void UpdateClientListControl()
        {
            if (InvokeRequired) // Is this called from a thread other than the one created
            // the control
            {
                // We cannot update the GUI on this thread.
                // All GUI controls are to be updated by the main (GUI) thread.
                // Hence we will use the invoke method on the control which will
                // be called when the Main thread is free
                // Do UI update on UI thread
                lstOnline.BeginInvoke(new UpdateClientListCallback(UpdateClientList), null);
            }
            else
            {
                // This is the main thread which created this control, hence update it
                // directly 
                UpdateClientList();
            }
        }
        void UpdateClientList()
        {
            try
            {
                //   MessageBox.Show((dicOnlineSocket.Keys.Count).ToString());

                if (lstOnline.Items.Count != dicOnlineSocket.Count)//说明有新的用户连上
                {
                    lstOnline.Items.Clear();
                    //   MessageBox.Show((dicOnlineSocket.Keys.Count).ToString());

                    foreach (var item in dicOnlineSocket.Keys)
                    {

                        lstOnline.Items.Add(item);
                        // MessageBox.Show("客户端更新");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // This method could be called by either the main thread or any of the
        // worker threads
        public delegate void UpdateRichEditCallback(string text);
        private void AppendToRichEditControl(string msg)
        {
            // Check to see if this method is called from a thread 
            // other than the one created the control
            if (InvokeRequired)
            {
                // We cannot update the GUI on this thread.
                // All GUI controls are to be updated by the main (GUI) thread.
                // Hence we will use the invoke method on the control which will
                // be called when the Main thread is free
                // Do UI update on UI thread
                object[] pList = { msg };
                textBox1_tiaoshi.BeginInvoke(new UpdateRichEditCallback(OnUpdateRichEdit), pList);
            }
            else
            {
                // This is the main thread which created this control, hence update it
                // directly 
                OnUpdateRichEdit(msg);
            }
        }
        string stringdata;
        private void OnUpdateRichEdit(string msg)
        {


            textBox1_receive.Text += msg + Environment.NewLine;


        }

        private delegate void xiaoyaolife_invoke(string invokefun);

        /// <summary>
        /// 字节数组转换十六进制字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string ByteArrayToHexString(char[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));

            return sb.ToString().ToUpper();
        }

        /// <summary>

        /// 当前接收模式

        /// </summary>

        private DataMode CurrentReceiveDataMode
        {
            get
            {
                return (chkHexReceive.Checked) ? DataMode.Hex : DataMode.Text;
            }
            set
            {
                chkHexReceive.Checked = (value == DataMode.Text);
            }
        }



        private void ServerRun()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint _ipport = new IPEndPoint(IPAddress.Parse(ip), port);
                socket.Bind(_ipport);
                socket.Listen(50);
                socket.BeginAccept(new AsyncCallback(OnConnectRequest), socket);//////////////////////////////////////////////////////////////////////

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private static string ip;
        private static int port;
        private static Socket socket;
        public Thread mythread3;
        //private void SocketAdmin()
        //{

        //}

        private String str = "";

        public String STR
        {
            get { return str; }
            set { str = value; }
        }

        private void SocketAdmin(string _ip, out Socket _socket, int _port, out Dictionary<string, Socket> _dicSocket)
        {
            ip = _ip;
            port = _port;
            ServerRun();
            _socket = socket;
            _dicSocket = dicOnlineSocket;

        }

        /// <summary>
        /// 所有活动的socket连接
        /// </summary>
        public static Dictionary<string, Socket> dicOnlineSocket = new Dictionary<string, Socket>();


        private void button3_clear_Click(object sender, EventArgs e)
        {

            textBox1_receive.Clear();

        }

        private void button3_readconfig_Click(object sender, EventArgs e)
        {
            if (lstOnline.SelectedItem != null)//如果已经选中了就准备发消息
            {
                Put_SendInfoToPool("text", "AT+SHOW", dicOnline[lstOnline.SelectedItem.ToString()]);
                textBox1_tiaoshi.Text += "已发送:" + "AT+SHOW" + "\r\n";
            }
            else
                MessageBox.Show("请选择接受对象");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
