using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEvent.DAL.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public TimeSpan Time { get; set; }


        [NotMapped]
        public IFormFile? ImageFile { get; set; } // görsel yükleme

        // 📌 Eklenmesi gereken özellik
        public int Day { get; set; } // 1, 2, 3 şeklinde
    }
}