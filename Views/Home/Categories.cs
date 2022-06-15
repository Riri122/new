
namespace Newrtest.Views.Home
{
    public class Categories { 
     
        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public ICollection<Categories>? Evenement { get; set; }
    }
}
