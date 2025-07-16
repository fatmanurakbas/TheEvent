using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheEvent.DAL.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
}