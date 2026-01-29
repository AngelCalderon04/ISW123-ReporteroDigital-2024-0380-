using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Reportero Digital iniciado....");
    }

    // Excepcion personalizada para errores de red
    public class ErrorDeRedException : Exception
    {
        public ErrorDeRedException(string mensaje) : base(mensaje) { }
    }

}
   