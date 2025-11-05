using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System.Text.Json;
using WebapiProyect.Interfaces;
using WebapiProyect.Models;

namespace WebapiProyect.Services
{
    public class DataAccessService: IDataAccessService
    {
        private readonly ApplicationDbContext _context;

        public DataAccessService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> ExecuteSqlGetJsonAsync(string sqlQuery)
        {
            var resultList = new List<Dictionary<string, object>>();

            // Usar la conexión de DbContext para ejecutar la consulta
            await using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                await using (var command = connection.CreateCommand())
                {
                    // ⚠️ ADVERTENCIA DE SEGURIDAD: Aquí se ejecuta la query generada por IA. 
                    // Asegúrate de que tu IA solo genere SELECTs o valida el SQL antes de ejecutarlo.
                    command.CommandText = sqlQuery;

                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                // Lee el nombre de la columna y su valor
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            }
                            resultList.Add(row);
                        }
                    }
                }
            }

            // Convierte la lista de resultados a una cadena JSON
            return JsonSerializer.Serialize(resultList);
        }
    }
}
