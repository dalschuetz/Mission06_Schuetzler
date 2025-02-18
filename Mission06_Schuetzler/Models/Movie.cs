using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Schuetzler.Models
{
    //allows us to get and retrieve the data from the form
    //sets MovieID, Category, Title, Year, Director, and Rating to Required and the rest to allow nulls
    public class Movie
    {
        [Key]
        [Required]
        public required int MovieID { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category CategoryName { get; set; }

        [Required]
        public required string Title { get; set; }
       
        [Required]
        public required int Year { get; set; }
        
        public string? Director { get; set; }
        
        public string? Rating { get; set; }

        [Required]
        public required int Edited { get; set; }
       
        public string? LentTo { get; set; }

        [Required]
        public required int CopiedToPlex { get; set; }

        //specify that notes cannot be more than 25 characters long (as a backup)
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
