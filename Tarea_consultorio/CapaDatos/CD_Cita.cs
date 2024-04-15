using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_consultorio.CapaDatos
{
    public class CD_Cita
    {
        public int CitaId { get; set; }
        public int Fk_Medico { get; set; }
        public int Fk_Pacienteld { get; set; }
        public DateTime FechaCita { get; set; }
        public bool Estado { get; set; }
    }

    public class CitaDataLayer
    {
        private string connectionString;

        public CitaDataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertCita(Cita cita)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Cita (Citald, Fk_Medico, Fk_Pacienteld, FechaCita, Estado) 
                             VALUES (@Citald, @Fk_Medico, @Fk_Pacienteld, @FechaCita, @Estado)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Citald", cita.CitaId);
                command.Parameters.AddWithValue("@Fk_Medico", cita.Fk_Medico);
                command.Parameters.AddWithValue("@Fk_Pacienteld", cita.Fk_Pacienteld);
                command.Parameters.AddWithValue("@FechaCita", cita.FechaCita);
                command.Parameters.AddWithValue("@Estado", cita.Estado);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCita(Cita cita)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Cita 
                             SET Fk_Medico = @Fk_Medico, Fk_Pacienteld = @Fk_Pacienteld, 
                                 FechaCita = @FechaCita, Estado = @Estado
                             WHERE Citald = @Citald";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Fk_Medico", cita.Fk_Medico);
                command.Parameters.AddWithValue("@Fk_Pacienteld", cita.Fk_Pacienteld);
                command.Parameters.AddWithValue("@FechaCita", cita.FechaCita);
                command.Parameters.AddWithValue("@Estado", cita.Estado);
                command.Parameters.AddWithValue("@Citald", cita.CitaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCita(int citaId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM Cita WHERE Citald = @Citald";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Citald", citaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Cita GetCita(int citaId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Cita WHERE Citald = @Citald";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Citald", citaId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Cita
                    {
                        CitaId = Convert.ToInt32(reader["Citald"]),
                        Fk_Medico = Convert.ToInt32(reader["Fk_Medico"]),
                        Fk_Pacienteld = Convert.ToInt32(reader["Fk_Pacienteld"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    };
                }

                return null;
            }
        }

        public List<Cita> GetAllCitas()
        {
            List<Cita> citas = new List<Cita>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Cita";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    citas.Add(new Cita
                    {
                        CitaId = Convert.ToInt32(reader["Citald"]),
                        Fk_Medico = Convert.ToInt32(reader["Fk_Medico"]),
                        Fk_Pacienteld = Convert.ToInt32(reader["Fk_Pacienteld"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    });
                }
            }

            return citas;
        }
    }
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        T GetById(object id);
        IEnumerable<T> GetAll();
    }

    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        IRepository<T> GetRepository<T>() where T : class;
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SqlConnection connection;

        public Repository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Insert(T entity)
        {
            string query = "INSERT INTO Cita (Citald, Fk_Medico, Fk_Pacienteld, FechaCita, Estado) " +
                           "VALUES (@Citald, @Fk_Medico, @Fk_Pacienteld, @FechaCita, @Estado)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Convertir la entidad a tipo Cita
                Cita cita = entity as Cita;

                // Configurar los parámetros
                command.Parameters.AddWithValue("@Citald", cita.Citald);
                command.Parameters.AddWithValue("@Fk_Medico", cita.Fk_Medico);
                command.Parameters.AddWithValue("@Fk_Pacienteld", cita.Fk_Pacienteld);
                command.Parameters.AddWithValue("@FechaCita", cita.FechaCita);
                command.Parameters.AddWithValue("@Estado", cita.Estado);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(T entity)
        {
            string query = "UPDATE Cita " +
                           "SET Fk_Medico = @Fk_Medico, Fk_Pacienteld = @Fk_Pacienteld, " +
                           "FechaCita = @FechaCita, Estado = @Estado " +
                           "WHERE Citald = @Citald";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Convertir la entidad a tipo Cita
                Cita cita = entity as Cita;

                // Configurar los parámetros
                command.Parameters.AddWithValue("@Fk_Medico", cita.Fk_Medico);
                command.Parameters.AddWithValue("@Fk_Pacienteld", cita.Fk_Pacienteld);
                command.Parameters.AddWithValue("@FechaCita", cita.FechaCita);
                command.Parameters.AddWithValue("@Estado", cita.Estado);
                command.Parameters.AddWithValue("@Citald", cita.Citald);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(object id)
        {
            string query = "DELETE FROM Cita WHERE Citald = @Citald";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Configurar el parámetro
                command.Parameters.AddWithValue("@Citald", id);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public T GetById(object id)
        {
            string query = "SELECT * FROM Cita WHERE Citald = @Citald";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Configurar el parámetro
                command.Parameters.AddWithValue("@Citald", id);

                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Verificar si hay resultados y mapearlos a una instancia de Cita
                if (reader.Read())
                {
                    return new Cita
                    {
                        Citald = Convert.ToInt32(reader["Citald"]),
                        Fk_Medico = Convert.ToInt32(reader["Fk_Medico"]),
                        Fk_Pacienteld = Convert.ToInt32(reader["Fk_Pacienteld"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    } as T;
                }
            }

            return null;
        }

        public IEnumerable<T> GetAll()
        {
            List<T> citas = new List<T>();

            string query = "SELECT * FROM Cita";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Abrir la conexión y ejecutar la consulta
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Iterar sobre los resultados y mapearlos a instancias de Cita
                while (reader.Read())
                {
                    citas.Add(new Cita
                    {
                        Citald = Convert.ToInt32(reader["Citald"]),
                        Fk_Medico = Convert.ToInt32(reader["Fk_Medico"]),
                        Fk_Pacienteld = Convert.ToInt32(reader["Fk_Pacienteld"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    } as T);
                }
            }

            return citas;
        }

    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection connection;
        private readonly Dictionary<Type, object> repositories;
        private bool disposed = false;

        public UnitOfWork(SqlConnection connection)
        {
            this.connection = connection;
            this.repositories = new Dictionary<Type, object>();
        }

        public void SaveChanges()
        {
            // Implementación de la lógica para guardar los cambios en la base de datos
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                repositories[typeof(T)] = new Repository<T>(connection);
            }

            return (IRepository<T>)repositories[typeof(T)];
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Liberar recursos manejados
                    foreach (var repository in repositories.Values)
                    {
                        if (repository is IDisposable disposableRepository)
                        {
                            disposableRepository.Dispose();
                        }
                    }
                }

                // Liberar recursos no manejados

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
