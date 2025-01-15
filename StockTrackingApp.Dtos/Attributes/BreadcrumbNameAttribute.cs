
namespace StockTrackingApp.Dtos.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BreadcrumbNameAttribute : Attribute
    {
        public string Name { get; }

        public BreadcrumbNameAttribute(string name)
        {
            Name = name;
        }
    }
}
