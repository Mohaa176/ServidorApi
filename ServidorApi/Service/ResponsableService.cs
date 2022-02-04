using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using ServidorApi.Model;
using ServidorApi.Persistence;
using System.Threading.Tasks;

namespace ServidorApi.Service
{
    public class ResponsableService
    {
        public List<Responsable> GetAll()
        {
            var result = new List<Responsable>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Responsable";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Responsable
                            {
                                ID = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["Name"].ToString(),

                            });
                        }
                    }
                }
            }
            return result;
        }
        public int Add(Responsable responsable)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO Responsable (name) VALUES (?)";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("name", responsable.Name));


                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }
        public int Delete(int ID)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "DELETE FROM Responsable WHERE Id = ?";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", ID));
                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }
        public Responsable GetById(int Id)
        {
            Responsable responsable = null;

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Tasca WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("Id", Id));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            responsable = new Responsable()
                            {
                                ID = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["Name"].ToString() 
                            };
                        }
                    }
                }
            }
            return responsable;
        }

        public int Update(Responsable responsable)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE Tasca SET name = @name WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("name", responsable.Name));
                    command.Parameters.Add(new SQLiteParameter("Id", responsable.ID));

                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }



    }



}


