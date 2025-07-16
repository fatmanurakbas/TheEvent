using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEvent.DAL.Entities
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }


        [NotMapped]
        public string CurrentPasword { get; set; }

        [NotMapped]
        public string NewPasword { get; set; }

        [NotMapped]
        public string ConfirmPasword { get; set; }
    }
}
