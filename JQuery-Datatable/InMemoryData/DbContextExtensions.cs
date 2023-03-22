using JQuery_Datatable.Models;

namespace JQuery_Datatable.InMemoryData
{
    public static class DbContextExtensions
    {
        public static void Seed(this DatatableContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            for (int i = 1; i <= 200000; i++)
            {
                context.Aluno.Add(new Aluno
                {
                    Id = i,
                    Nome = $"Aluno {i}"
                });
            }

            context.SaveChanges();
        }
    }
}
