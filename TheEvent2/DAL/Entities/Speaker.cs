using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEvent.DAL.Entities
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
        public string?Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; } // görsel yükleme
    }
}