using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Tarea_consultorio.CapaDatos.MedicoldDataLayer;

namespace Tarea_consultorio.CapaDatos
{
    public class CD_Medico
    {

        public int Medico { get; set; }
        public string Tipo { get; set; }
        public int Nulidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
    }

    public class MedicoldDataLayer
    {
        private string connectionString;

        public MedicoldDataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertMedicold(Medicold medicold)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Medicold (Medico, Tipo, Nulidad, Nombres, Apellidos, Fechaingreso, Estado) 
                             VALUES (@Medico, @Tipo, @Nulidad, @Nombres, @Apellidos, @FechaIngreso, @Estado)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Medico", medicold.Medico);
                command.Parameters.AddWithValue("@Tipo", medicold.Tipo);
                command.Parameters.AddWithValue("@Nulidad", medicold.Nulidad);
                command.Parameters.AddWithValue("@Nombres", medicold.Nombres);
                command.Parameters.AddWithValue("@Apellidos", medicold.Apellidos);
                command.Parameters.AddWithValue("@FechaIngreso", medicold.FechaIngreso);
                command.Parameters.AddWithValue("@Estado", medicold.Estado);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateMedicold(Medicold medicold)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Medicold 
                             SET Tipo = @Tipo, Nulidad = @Nulidad, Nombres = @Nombres, Apellidos = @Apellidos, 
                                 Fechaingreso = @FechaIngreso, Estado = @Estado
                             WHERE Medico = @Medico";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Tipo", medicold.Tipo);
                command.Parameters.AddWithValue("@Nulidad", medicold.Nulidad);
                command.Parameters.AddWithValue("@Nombres", medicold.Nombres);
                command.Parameters.AddWithValue("@Apellidos", medicold.Apellidos);
                command.Parameters.AddWithValue("@FechaIngreso", medicold.FechaIngreso);
                command.Parameters.AddWithValue("@Estado", medicold.Estado);
                command.Parameters.AddWithValue("@Medico", medicold.Medico);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteMedicold(int medicoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM Medicold WHERE Medico = @Medico";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Medico", medicoId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Medicold GetMedicold(int medicoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Medicold WHERE Medico = @Medico";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Medico", medicoId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Medicold
                    {
                        Medico = Convert.ToInt32(reader["Medico"]),
                        Tipo = reader["Tipo"].ToString(),
                        Nulidad = Convert.ToInt32(reader["Nulidad"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        FechaIngreso = Convert.ToDateTime(reader["Fechaingreso"]),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    };
                }

                return null;
            }
        }

        public List<Medicold> GetAllMedicolds()
        {
            List<Medicold> medicolds = new List<Medicold>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Medicold";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    medicolds.Add(new Medicold
                    {
                        Medico = Convert.ToInt32(reader["Medico"]),
                        Tipo = reader["Tipo"].ToString(),
                        Nulidad = Convert.ToInt32(reader["Nulidad"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        FechaIngreso = Convert.ToDateTime(reader["Fechaingreso"]),
                        Estado = Convert.ToBoolean(reader["Estado"])
                    });
                }
            }

            return medicolds;
        }
        public class MedicoRepository : Repository<CD_Medico>, IMedicoRepository
        {
            public MedicoRepository(SqlConnection connection) : base(connection)
            {
            }

            public void Insert(CD_Medico entity)
            {
                string query = "INSERT INTO Medicold (Medico, Tipo, Nulidad, Nombres, Apellidos, FechaIngreso, Estado) " +
                               "VALUES (@Medico, @Tipo, @Nulidad, @Nombres, @Apellidos, @FechaIngreso, @Estado)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Medico", entity.Medico);
                    command.Parameters.AddWithValue("@Tipo", entity.Tipo);
                    command.Parameters.AddWithValue("@Nulidad", entity.Nulidad);
                    command.Parameters.AddWithValue("@Nombres", entity.Nombres);
                    command.Parameters.AddWithValue("@Apellidos", entity.Apellidos);
                    command.Parameters.AddWithValue("@FechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@Estado", entity.Estado);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void Update(CD_Medico entity)
            {
                string query = "UPDATE Medicold SET Tipo = @Tipo, Nulidad = @Nulidad, " +
                               "Nombres = @Nombres, Apellidos = @Apellidos, FechaIngreso = @FechaIngreso, " +
                               "Estado = @Estado WHERE Medico = @Medico";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tipo", entity.Tipo);
                    command.Parameters.AddWithValue("@Nulidad", entity.Nulidad);
                    command.Parameters.AddWithValue("@Nombres", entity.Nombres);
                    command.Parameters.AddWithValue("@Apellidos", entity.Apellidos);
                    command.Parameters.AddWithValue("@FechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@Estado", entity.Estado);
                    command.Parameters.AddWithValue("@Medico", entity.Medico);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void Delete(object id)
            {
                string query = "DELETE FROM Medicold WHERE Medico = @Medico";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Medico", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public CD_Medico GetById(object id)
            {
                string query = "SELECT * FROM Medicold WHERE Medico = @Medico";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Medico", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return new CD_Medico
                        {
                            Medico = Convert.ToInt32(reader["Medico"]),
                            Tipo = reader["Tipo"].ToString(),
                            Nulidad = Convert.ToInt32(reader["Nulidad"]),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        };
                    }
                }

                return null;
            }

            public IEnumerable<CD_Medico> GetAll()
            {
                List<CD_Medico> medicos = new List<CD_Medico>();

                string query = "SELECT * FROM Medicold";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        medicos.Add(new CD_Medico
                        {
                            Medico = Convert.ToInt32(reader["Medico"]),
                            Tipo = reader["Tipo"].ToString(),
                            Nulidad = Convert.ToInt32(reader["Nulidad"]),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        });
                    }
                }

                return medicos;
            }
        }

    }

    public interface IMedicoUnitOfWork : IUnitOfWork
        {
            IMedicoRepository MedicoRepository { get; }
        }

        public class MedicoUnitOfWork : UnitOfWork, IMedicoUnitOfWork
        {
            public IMedicoRepository MedicoRepository { get; }

            public MedicoUnitOfWork(SqlConnection connection) : base(connection)
            {
                MedicoRepository = new MedicoRepository(connection);
            }
        }
    }
    


