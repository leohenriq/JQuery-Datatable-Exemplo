using JQuery_Datatable.Models;
using Microsoft.EntityFrameworkCore;

namespace JQuery_Datatable
{
    public class DatatableContext : DbContext
    {
        public DatatableContext(DbContextOptions<DatatableContext> options)
            : base(options)
        { }
        public DbSet<Aluno> Aluno { get; set; }
    }
}
