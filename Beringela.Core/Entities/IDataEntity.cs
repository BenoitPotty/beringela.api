using System;

namespace Beringela.Core.Entities
{
    public interface IDataEntity
    {
        public Func<IDataEntity, bool> SearchPredicate(string term);
        public Guid Id { get; set; }
    }
}
