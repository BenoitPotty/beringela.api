using System;

namespace Beringela.Core.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TextualSearchAttribute : Attribute
    {
        public bool IgnoreCase { get; set; } = true;
    }
}
