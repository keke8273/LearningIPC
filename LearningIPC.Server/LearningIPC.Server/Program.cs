using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LearningIPC.Server
{
    class Program
    {
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static List<Socket> _clientSockets = new List<Socket>();

        static void Main(string[] args)
        {
        }

        private static void SetupServer()
        {
            Console.WriteLine("Setting up server....");
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AsyncAcceptCallback), null);

        }

        private void AsyncAcceptCallback(IAsyncResult AR)
        {
            var state = AR.AsyncState; // This is whatever is passed in as the state object when invoking Begin* method
            var socket = _serverSocket.EndAccept(AR);


        }
    }
}
