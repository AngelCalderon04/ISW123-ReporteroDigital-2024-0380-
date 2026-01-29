using System;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Reportero Digital iniciado...");

        ReporteroDigital reportero = new ReporteroDigital();
        string texto = await reportero.ObtenerTextoAsync();

        Console.WriteLine(texto);
    }

    // Excepcion personalizada para errores de red
    public class ErrorDeRedException : Exception
    {
        public ErrorDeRedException(string mensaje) : base(mensaje) { }
    }

    public class ReporteroDigital
    {
        public async Task<string> ObtenerTextoAsync()
        {
            await Task.Delay(2000);
            return "Texto principal de la noticia.";
        }
    }



}
