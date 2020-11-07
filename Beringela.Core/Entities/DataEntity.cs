using System;

namespace Beringela.Core.Entities
{
    public abstract class DataEntity : IDataEntity
    {
        public Guid Id { get; set; } = new Guid();
    }
}
