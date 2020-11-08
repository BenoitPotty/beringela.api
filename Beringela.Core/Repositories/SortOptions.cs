namespace Beringela.Core.Repositories
{
    public class SortOptions
    {
        public string PropertyName { get; set; }
        public bool Descending { get; set; }
        
        public SortOptions(string propertyName = null, bool descending = false)
        {
            PropertyName = propertyName;
            Descending = descending;
        }
    }
}
