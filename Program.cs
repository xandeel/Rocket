using System;
using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the IP address or domain name of the target: ");
        string target = Console.ReadLine();
        Console.Write("Enter the port range to scan (example: 1-9999): "); // Corregí el mensaje en esta línea
        string portRange = Console.ReadLine();

        string[] ports = portRange.Split("-");
        int startPort = Int32.Parse(ports[0]);
        int endPort = Int32.Parse(ports[1]); // Corregí el nombre de la variable "endPort"

        Console.WriteLine($"Scanning for open ports on {target}...");

        for (int port = startPort; port <= endPort; port++)
        {
            if (IsPortOpen(target, port)) // Corregí el nombre de la función "IsPortOpen"
            {
                Console.WriteLine($"Port {port} is open");
            }
        }
    }

    static bool IsPortOpen(string host, int port)
    {
        try
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect(host, port);
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}