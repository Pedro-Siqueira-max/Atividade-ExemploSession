using Microsoft.EntityFrameworkCore;

namespace ExemploSession.Models
{
    public class SeedData
    {


        public static void EnsurePopulated(IApplicationBuilder app)
        {
			Context context = app.ApplicationServices.GetRequiredService<Context>();
			context.Database.Migrate();
			if (!context.Usuarios.Any())
			{
				var usuario = new Usuario { Senha = "123456", Nome = "Pedro", Email = "pedro@gmail.com" };
				context.Usuarios.AddRange(usuario);
				context.SaveChanges();
			}
		}
    }
}
