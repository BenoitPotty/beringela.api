using System;

namespace Beringela.Core.Entities
{
    public abstract class DataEntity : IDataEntity
    {
        public Guid Id { get; set; } = new Guid();

        public abstract Func<IDataEntity, bool> SearchPredicate(string term);
        
    }
}
