namespace Beringela.Core.Configuration
{
    public class BeringelaOptions
    {
        public const string Beringela = "Beringela";

        public SwaggerOptions Swagger { get; set; }

        public string HealthChecksUrl { get; set; } = "/health";
    }
}
