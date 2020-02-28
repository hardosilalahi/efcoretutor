using Microsoft.EntityFrameworkCore;
using tutorefcore.Models;

namespace tutorefcore
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options): base(options){}

        public DbSet<Posts> Post {get; set;}

    }
}