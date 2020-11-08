namespace Beringela.Core.Repositories
{
    public class SortOptions
    {
        public string PropertyName { get; set; } = null;
        public bool Descending { get; set; } = false;
        
        public SortOptions(string propertyName = null, bool descending = false)
        {
            PropertyName = propertyName;
            Descending = descending;
        }
    }
}
