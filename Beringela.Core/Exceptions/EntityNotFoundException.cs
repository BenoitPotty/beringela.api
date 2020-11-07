using System;
using System.Collections.Generic;
using System.Text;

namespace Beringela.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Guid Id { get; set; }    
    }
}
