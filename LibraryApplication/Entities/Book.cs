using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Domain
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
