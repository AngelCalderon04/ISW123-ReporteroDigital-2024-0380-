using System;
using System.Threading.Tasks;

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

        try
        {
            Task<string> textoTask = reportero.ObtenerTextoAsync();
            Task<string> imagenTask = reportero.ObtenerImagenAsync();
            Task<string> analisisTask = reportero.ObtenerAnalisisAsync();

            await Task.WhenAll(textoTask, imagenTask, analisisTask);

            Console.WriteLine(textoTask.Result);
            Console.WriteLine(imagenTask.Result);
            Console.WriteLine(analisisTask.Result);
        }
        catch (ErrorDeRedException ex)
        {
            Console.WriteLine("Error de red: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error inesperado: " + ex.Message);
        }
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

            bool fallo = false; 
            if (fallo)
            {
                throw new ErrorDeRedException("Error al cargar la imagen");
            }

            FuenteCompletada?.Invoke("Imagen cargada");
            return "ImagenNoticia.jpg";
        }

        public async Task<string> ObtenerAnalisisAsync()
        {
            await Task.Delay(1000);
            FuenteCompletada?.Invoke("Análisis cargado");
            return "Analisis del periodista.";
        }

    }
}
