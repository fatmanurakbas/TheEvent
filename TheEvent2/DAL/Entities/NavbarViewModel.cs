using TheEvent.DAL.Entities;

namespace TheEvent.DAL.Entities
{
    public class NavbarViewModel
    {
        public int NavbarViewModelId { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Message> UnreadMessages { get; set; }
        public int UnreadMessageCount { get; set; }
        public int UnreadNotificationCount { get; set; }
    }
}

