using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheEvent.DAL.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}