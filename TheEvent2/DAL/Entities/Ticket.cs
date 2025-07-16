using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEvent.DAL.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }

    }
}