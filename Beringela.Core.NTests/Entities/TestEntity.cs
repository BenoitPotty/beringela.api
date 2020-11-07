using Beringela.Core.Entities;

namespace Beringela.Core.NTests.Entities
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
