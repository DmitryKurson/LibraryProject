using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Models
{
    
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
        
}
