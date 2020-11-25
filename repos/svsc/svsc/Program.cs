using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;



namespace Sockets
{
    class Servidor
    {

        //public void conectar()
        static void Main(string[] args)
        {
            Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            miPrimerSocket.Bind(direccion);

            miPrimerSocket.Listen(5);

            Console.WriteLine("Escuchando...");

            Socket Escuchar = miPrimerSocket.Accept();

            Console.WriteLine("Conectado con exito");


            byte[] ByRec = new byte[255];

            int a = Escuchar.Receive(ByRec, 0, ByRec.Length, 0);

            Array.Resize(ref ByRec, a);

            Console.WriteLine("Cliente dice: " + Encoding.Default.GetString(ByRec)); //mostramos lo recibido

            miPrimerSocket.Close();

            Console.WriteLine("Presione cualquier tecla para terminar");

            Console.ReadKey();

        }


    }




    class Cliente
    {
        public void Conectar()
        {

            Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            miPrimerSocket.Connect(miDireccion); // Conectamos               

            Console.WriteLine("Conectado con exito\n");
            Console.WriteLine("Ingrese La Informacion a Enviar\n\n");



            string info = Console.ReadLine();

            byte[] infoEnviar = Encoding.Default.GetBytes(info);

            miPrimerSocket.Send(infoEnviar, 0, infoEnviar.Length, 0);

            miPrimerSocket.Close();


            Console.WriteLine("Presione cualquier tecla para terminar");

            Console.ReadKey();

        }




    }
}
