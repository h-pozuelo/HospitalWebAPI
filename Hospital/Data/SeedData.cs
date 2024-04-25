using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));
                context.Database.EnsureCreated();

                if (!context.Doctores.Any())
                {
                    context.Doctores.AddRange(new List<Doctor>()
                    {
                        new Doctor() { Especialidad = "Cardiología", Nombre = "Damián Pérez Ruiz" },
                        new Doctor() { Especialidad = "Neurología", Nombre = "Paola Ramírez Montes" }
                    });
                    context.SaveChanges();
                }

                if (!context.Pacientes.Any())
                {
                    context.Pacientes.AddRange(new List<Paciente>()
                    {
                        new Paciente() { Nombre = "Manolo Gómez Sierra" },
                        new Paciente() { Nombre = "Irene Nieves Molina" },
                        new Paciente() { Nombre = "Carmen Naranjo García" },
                        new Paciente() { Nombre = "Gregorio Sánchez Fustián" }
                    });
                    context.SaveChanges();
                }

                if (!context.Consultas.Any())
                {
                    context.Consultas.AddRange(new List<Consulta>()
                    {
                        new Consulta () { Fecha = DateTime.Parse("01/01/2024"), IdDoctor = 1, IdPaciente = 1 },
                        new Consulta () { Fecha = DateTime.Parse("02/01/2024"), IdDoctor = 2, IdPaciente = 2 },
                        new Consulta () { Fecha = DateTime.Parse("03/01/2024"), IdDoctor = 1, IdPaciente = 3 },
                        new Consulta () { Fecha = DateTime.Parse("04/01/2024"), IdDoctor = 2, IdPaciente = 4 }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
