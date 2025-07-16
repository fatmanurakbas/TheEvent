using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEvent.DAL.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }

        public string? SubTitle { get; set; }

        public string? Title { get; set; }

        public string? ImageUrl { get; set; }


        [NotMapped]
        public IFormFile? ImageFile { get; set; } // dosya yükleme
        [NotMapped]
        public IFormFile? ImageFileBanner { get; set; }

    }
}
