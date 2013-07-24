using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Andarki.Wol.Code
{
    public static class WolClient
    {
        // Galactica: BC:5F:F4:2B:F8:7C
        public static void SendMagicPacket(string mac, int port = 9)
        {
            // Remove : and - used as separators
            mac = mac.Replace(":", string.Empty).Replace("-", string.Empty).ToUpper();

            // Validate input
            if (!Regex.IsMatch(mac, @"^[A-F0-9]{12}$"))
                throw new ArgumentException("MAC-Address should contain 12 hex chars", mac);

            UdpClient client = new UdpClient();

            //255.255.255.255 - broadcast
            client.Connect(new IPAddress(0xffffffff), port);
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 0);

            // Array position
            int position = 0;

            // message to be send
            byte[] bytes = new byte[102];

            // first 6 bytes should be 0xFF
            for (int y = 0; y < 6; y++)
                bytes[position++] = 0xFF;

            //now repeate MAC 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    bytes[position++] = byte.Parse(mac.Substring(i, 2), NumberStyles.HexNumber);
                    i += 2;
                }
            }

            // Send wake up packet  
            client.Send(bytes, 102);
        }
    }
}
