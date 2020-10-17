using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente
{
    class Program
    {
        const int porta = 7000;
        const string ip = "192.168.1.7";

        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            Console.Write("Conectando ao servidor");
            try
            {
                client.Connect(ip, porta);
                Console.WriteLine("Ok");
            }
            catch (Exception)
            {
                Console.WriteLine("Falhou");
                return;
            }

            byte[] bytes = new byte[1024];
            NetworkStream stream = client.GetStream();

            Console.WriteLine("Envie uma mensagem. Pressione ENTER para sair.");
            Console.Write("> ");
            string mensagem = Console.ReadLine();

            while (msg.Length > 0)
            {
                bytes = Encoding.ASCII.GetBytes(mensagem);
                stream.Write(bytes, 0, bytes.Length);

                Console.Write("> ");
                mensagem = Console.ReadLine();
            }

            stream.Close();
            Console.WriteLine("Desconectado");
            client.Close();
        }
    }
}
