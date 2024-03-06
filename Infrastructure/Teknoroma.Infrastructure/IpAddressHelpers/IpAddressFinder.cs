using System.Net;

namespace Teknoroma.Infrastructure.IpAddressHelpers
{
    public static class IpAddressFinder
    {
        public static string GetHostName()
        {
            string ip = "";

            var hostName = Dns.GetHostName();
            var address = Dns.GetHostAddresses(hostName);

            foreach ( var host in address )
            {
                if (host.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ip = host.ToString();
            }

            return ip;
        }
    }
}
