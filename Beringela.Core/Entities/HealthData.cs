using System.Reflection;

namespace Beringela.Core.Entities
{
    public class HealthData
    {
        public HealthData()
        {
            ApiName = "TODO";
#if DEBUG
            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            BeringelaVersion = assemblyName.Version?.ToString();
#endif
        }
        public string ApiName { get; set; }
        public string ApiVersion { get; set; }
        public string BeringelaVersion { get; set; }
    }
}
