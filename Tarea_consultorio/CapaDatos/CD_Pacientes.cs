using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_consultorio.CapaDatos
{
    public class CD_Pacientes
    {
        public int PacienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
    }

    public class PacienteDataLayer
    {
        private string connectionString;

        public PacienteDataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertPaciente(Paciente paciente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Pacientes (Pacienteld, Nombres, Apellidos, Fechaingreso, Estado) 
                             VALUES (@Pacienteld, @Nombres, @Apellidos, @FechaIngreso, @Estado)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pacienteld", paciente.PacienteId);
                command.Parameters.AddWithValue("@Nombres", paciente.Nombres);
                command.Parameters.AddWithValue("@Apellidos", paciente.Apellidos);
                command.Parameters.AddWithValue("@FechaIngreso", paciente.FechaIngreso);
                command.Parameters.AddWithValue("@Estado", paciente.Estado);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdatePaciente(Paciente paciente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Pacientes 
                             SET Nombres = @Nombres, Apellidos = @Apellidos, 
                                 Fechaingreso = @FechaIngreso, Estado = @Estado
                             WHERE Pacienteld = @Pacienteld";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombres", paciente.Nombres);
                command.Parameters.AddWithValue("@Apellidos", paciente.Apellidos);
                command.Parameters.AddWithValue("@FechaIngreso", paciente.FechaIngreso);
                command.Parameters.AddWithValue("@Estado", paciente.Estado);
                command.Parameters.AddWithValue("@Pacienteld", paciente.PacienteId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeletePaciente(int pacienteId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM Pacientes WHERE Pacienteld = @Pacienteld";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pacienteld", pacienteId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Paciente GetPaciente(int pacienteId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Pacientes WHERE Pacienteld = @Pacienteld";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pacienteld", pacienteId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Paciente
                    {
                        PacienteId = Convert.ToInt32(reader["Pacienteld"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        FechaIngreso = Convert.ToDateTime(reader["Fechaingreso"]),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    };
                }

                return null;
            }
        }

        public List<Paciente> GetAllPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Pacientes";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    pacientes.Add(new Paciente
                    {
                        PacienteId = Convert.ToInt32(reader["Pacienteld"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        FechaIngreso = Convert.ToDateTime(reader["Fechaingreso"]),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    });
                }
            }

            return pacientes;
        }
        public interface IPacientesRepository : IRepository<CD_Pacientes>
        {
            // Agregar métodos específicos para la entidad CD_Pacientes si es necesario
        }

        public class PacientesRepository : Repository<CD_Pacientes>, IPacientesRepository
        {
            public PacientesRepository(SqlConnection connection) : base(connection)
            {
            }

            public void Insert(CD_Pacientes entity)
            {
                string query = "INSERT INTO Pacientes (PacienteId, Nombres, Apellidos, FechaIngreso, Estado) " +
                               "VALUES (@PacienteId, @Nombres, @Apellidos, @FechaIngreso, @Estado)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PacienteId", entity.PacienteId);
                    command.Parameters.AddWithValue("@Nombres", entity.Nombres);
                    command.Parameters.AddWithValue("@Apellidos", entity.Apellidos);
                    command.Parameters.AddWithValue("@FechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@Estado", entity.Estado);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void Update(CD_Pacientes entity)
            {
                string query = "UPDATE Pacientes SET Nombres = @Nombres, Apellidos = @Apellidos, " +
                               "FechaIngreso = @FechaIngreso, Estado = @Estado " +
                               "WHERE PacienteId = @PacienteId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombres", entity.Nombres);
                    command.Parameters.AddWithValue("@Apellidos", entity.Apellidos);
                    command.Parameters.AddWithValue("@FechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@Estado", entity.Estado);
                    command.Parameters.AddWithValue("@PacienteId", entity.PacienteId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void Delete(object id)
            {
                string query = "DELETE FROM Pacientes WHERE PacienteId = @PacienteId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PacienteId", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public CD_Pacientes GetById(object id)
            {
                string query = "SELECT * FROM Pacientes WHERE PacienteId = @PacienteId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PacienteId", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new CD_Pacientes
                        {
                            PacienteId = Convert.ToInt32(reader["PacienteId"]),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        };
                    }
                }

                return null;
            }

            public IEnumerable<CD_Pacientes> GetAll()
            {
                List<CD_Pacientes> pacientes = new List<CD_Pacientes>();

                string query = "SELECT * FROM Pacientes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        pacientes.Add(new CD_Pacientes
                        {
                            PacienteId = Convert.ToInt32(reader["PacienteId"]),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        });
                    }
                }

                return pacientes;
            }
        }

        public interface IPacientesUnitOfWork : IUnitOfWork
        {
            IPacientesRepository PacientesRepository { get; }
        }

        public class PacientesUnitOfWork : UnitOfWork, IPacientesUnitOfWork
        {
            public IPacientesRepository PacientesRepository { get; }

            public PacientesUnitOfWork(SqlConnection connection) : base(connection)
            {
                PacientesRepository = new PacientesRepository(connection);
            }
        }
    }
}

