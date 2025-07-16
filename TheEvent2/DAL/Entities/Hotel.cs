using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEvent.DAL.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? raiting { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; } // görsel yükleme
    }
}
