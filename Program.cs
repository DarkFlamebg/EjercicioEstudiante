using M12.NotasEf;
using Microsoft.EntityFrameworkCore;

using NotasDbContext db = new NotasDbContext();

Console.WriteLine("conectando a la base de datos...");

// Aplica las migraciones pendientes (crea notas.db si no existe)
db.Database.Migrate();

if (!db.Estudiantes.Any())
{
    db.Estudiantes.Add(new Estudiante { Nombre = "Juan", Nota = 12, Ciudad = "guayaquil" });
    db.Estudiantes.Add(new Estudiante { Nombre = "Maria", Nota = 15, Ciudad = "guayaquil" });
    db.Estudiantes.Add(new Estudiante { Nombre = "Pedro", Nota = 14, Ciudad = "guayaquil" });
    db.Estudiantes.Add(new Estudiante { Nombre = "Jose", Nota = 14, Ciudad = "quito" });
    db.SaveChanges();
}

List<Estudiante> todos = db.Estudiantes.ToList();
Console.WriteLine(value: $"Estudiantes en la base de datos: {todos.Count}");

foreach (Estudiante estudiante in todos)
{
    Console.WriteLine(value: $"{estudiante.Id}, {estudiante.Nombre}, {estudiante.Nota}, {estudiante.Ciudad}");
}

List<string> aprobados = db.Estudiantes
    .Where(e => e.Nota >= 14)
    .Select(e => e.Nombre)
    .ToList();

Console.WriteLine(value: $"Aprobados: {string.Join(", ", aprobados)}");

int deQuito =db.Estudiantes.Count(e => e.Ciudad == "quito");
Console.WriteLine(value: $"Estudiantes de Quito: {deQuito}");