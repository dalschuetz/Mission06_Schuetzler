using System.ComponentModel.DataAnnotations; // Data Annotations
using System.ComponentModel.DataAnnotations.Schema; // Data Annotations, Entity Framework

namespace Mission06_Schuetzler.Models // Models, Namespace
{
    // Allows us to get and retrieve the data from the form
    // Sets MovieID, Category, Title, Year, Director, and Rating to Required and the rest to allow nulls
    public class Movie // Model
    {
        [Key] // Data Annotations (Primary Key)
        [Required] // Data Annotations (Required Field)
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")] // Data Annotations (Foreign Key)
        public int? CategoryId { get; set; } // Nullable Values
        public Category? Category { get; set; } // Nullable Values, Model Relationship

        [Required(ErrorMessage = "Please enter a title")] // Data Annotations (Validation)
        public string Title { get; set; } // Model Property

        [Required(ErrorMessage = "Please enter a year")] // Data Annotations (Validation)
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")] // Data Annotations (Validation)
        public int Year { get; set; } // Model Property

        public string? Director { get; set; } // Nullable Values

        public string? Rating { get; set; } // Nullable Values

        [Required(ErrorMessage = "Please select if edited")] // Data Annotations (Validation)
        public int Edited { get; set; } // Model Property

        public string? LentTo { get; set; } // Nullable Values

        [Required(ErrorMessage = "Please select if copied to Plex")] // Data Annotations (Validation)
        public int CopiedToPlex { get; set; } // Model Property

        // Specify that notes cannot be more than 25 characters long (as a backup)
        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")] // Data Annotations (Validation)
        public string? Notes { get; set; } // Nullable Values
    }
}
