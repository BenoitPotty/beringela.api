using Beringela.Core.Entities;

namespace Beringela.Core.Tests.Entities
{
    public class TestEntity: DataEntity
    {
        [TextualSearch]
        public string Summary { get; set; }

        [TextualSearch]
        public string Description { get; set; }

        [TextualSearch(IgnoreCase = false)]
        public string CaseSensitive { get; set; }
    }
}
