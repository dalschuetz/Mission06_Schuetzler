using System.ComponentModel.DataAnnotations;

namespace Mission06_Schuetzler.Models
{
    //allows us to get and retrieve the data from the form
    //sets MovieID, Category, Title, Year, Director, and Rating to Required and the rest to allow nulls
    public class Movie
    {
        [Key]
        [Required]
        public required int MovieID { get; set; }
        
        [Required]
        public required string Category { get; set; }
       
        [Required]
        public required string Title { get; set; }
       
        [Required]
        public required string Year { get; set; }
        
        [Required]
        public required string Director { get; set; }
        
        [Required]
        public required string Rating { get; set; }
        
        public bool? Edited { get; set; }
       
        public string? LentTo { get; set; }

        //specify that notes cannot be more than 25 characters long (as a backup)
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
