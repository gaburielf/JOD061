using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JOD061
{
    class Program
    {
        const int porta_ = 7000;
        const string ip = "192.168.1.7";
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint endP = new IPEndPoint(IPAddress.Any, 0);
                UdpClient porta = new UdpClient(porta_);

                Console.WriteLine("Para sair, aperte - CTRL + C");
                while (true)
                {
                    byte[] bytesRecebidos = porta.Receive(ref endP);
                    Console.WriteLine("Mensagem recebida: {0}", Encoding.ASCII.GetString(bytesRecebidos));
                    Console.WriteLine("Mensagem enviada por {0}:{1}",endP.Address.ToString(), endP.Port.ToString());
                    
                }
            }
            catch (Exception)
            {
                UdpClient par = new UdpClient();
                par.EnableBroadcast = true;

                Console.WriteLine("Envie sua mensagem. Precione ENTER para sair.");
                Console.WriteLine("> ");
                string mensagem = Console.ReadLine();

                while (mensagem.Length > 0)
                {
                    byte[] bytesEnviados = Encoding.ASCII.GetBytes(mensagem);
                    par.Send(bytesEnviados, bytesEnviados.Length, ip, porta_);

                    Console.Write("> ");
                    mensagem = Console.ReadLine();

                }
                par.Close();

            }
        }
    }
}