using System;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Reportero Digital iniciado...");

        ReporteroDigital reportero = new ReporteroDigital();
        reportero.FuenteCompletada += mensaje =>
        {
            Console.WriteLine("EVENTO: " + mensaje);
        };

        Task<string> textoTask = reportero.ObtenerTextoAsync();
        Task<string> imagenTask = reportero.ObtenerImagenAsync();

        await Task.WhenAll(textoTask, imagenTask);

        Console.WriteLine(textoTask.Result);
        Console.WriteLine(imagenTask.Result);
    }

    // Excepcion personalizada para errores de red
    public class ErrorDeRedException : Exception
    {
        public ErrorDeRedException(string mensaje) : base(mensaje) { }
    }

    
    public class ReporteroDigital
    {
        public event Action<string> FuenteCompletada;

        public async Task<string> ObtenerTextoAsync()
        {
            await Task.Delay(2000);
            FuenteCompletada?.Invoke("Texto cargado");
            return "Texto principal de la noticia.";
        }

        public async Task<string> ObtenerImagenAsync()
        {
            await Task.Delay(1500);
            FuenteCompletada?.Invoke("Imagen cargada");
            return "ImagenNoticia.jpg";
        }

    }





}
