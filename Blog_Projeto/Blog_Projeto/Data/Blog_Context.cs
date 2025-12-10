using Blog_Projeto.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Projeto.Data
{
    public class Blog_Context : DbContext
    {
        public Blog_Context(DbContextOptions<Blog_Context>options) : base(options) {}
        public DbSet<DadosPost> DadosPost { get; set; }
        public DbSet<DadosUser> DadosUser { get; set; }
    }
}
