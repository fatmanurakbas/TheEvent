

using TheEvent.DAL.Entities;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

using TheEvent.Context;


namespace TheEvent.Context
{
    public class TheEventContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=FATMANUR\\SQLEXPRESS; initial catalog=DbTheEvent; integrated Security=true; TrustServerCertificate=True");
        }
        public TheEventContext(DbContextOptions<TheEventContext> options)
            : base(options)
        {
        }
        public DbSet<Feature> Features { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<NavbarViewModel> NavbarViewModels { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Profile> Profiles { get; set; }
       


    }
}