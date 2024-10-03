using Microsoft.EntityFrameworkCore;

using dotNET_Api.Models;

namespace dotNET_Api.Context
{
    public class OrganizerContext : DbContext
    {
        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
        {

        }

        public DbSet<TaskSchedule> Tasks { get; set; }
    }
}