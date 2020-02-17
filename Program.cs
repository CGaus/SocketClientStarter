using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClientStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = null;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddr = null;

            try
            {
                Console.WriteLine("*** Wekcome to Socket Client Starter Example by Chris Gaus ***");
                Console.WriteLine("Please Type a valid service IP address and press enter: ");

                string strIPAddress = Console.ReadLine();

                Console.WriteLine("Please supply a valid port number 0-65535 and press enter:");
                string strPortInput = Console.ReadLine();
                int nPortInput = 0;

                if (!IPAddress.TryParse(strIPAddress, out ipaddr))
                {
                    Console.WriteLine("Invalid server IP supplied.");
                }

                if (!int.TryParse(strPortInput.Trim(), out nPortInput))
                {
                    Console.WriteLine("Invalid port number supplied, return.");
                }

                if (nPortInput <=0 || nPortInput > 65535)
                {
                    Console.WriteLine("Port number must be between 0 and 65535.");
                }

                System.Console.WriteLine(string.Format("IPAddress: {0} - Port: {1}", ipaddr.ToString(), nPortInput));

                client.Connect(ipaddr, nPortInput);

                Console.ReadKey();

            }
            catch(Exception excp)
            {
                Console.WriteLine(excp.ToString());
            }
        }
    }
}
