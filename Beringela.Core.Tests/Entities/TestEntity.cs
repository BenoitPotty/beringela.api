using System;
using Beringela.Core.Entities;

namespace Beringela.Core.Tests.Entities
{
    public class TestEntity: DataEntity
    {
        private string _summary;

        [TextualSearch]
        public string Summary
        {
            get => _summary;
            set => _summary = value;
        }
    }
}
