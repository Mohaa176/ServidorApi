using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using ServidorApi.Model;
using ServidorApi.Persistence;

namespace ServidorApi.Service
{
    class TascaService
    {

        //Crear taula responsables
        public IEnumerable<Tasca> GetAll(string estat)
        {
            var result = new List<Tasca>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Tasca where estat='" + estat + "'";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Tasca
                            {
                                ID = Convert.ToInt32(reader["ID"].ToString()),
                                Name = reader["Name"].ToString(),
                                //   ResponsableTasca = reader["ResponsableTasca"].ToString(),
                                Descripcio = reader["Descripcio"].ToString(),
                                Data = Convert.ToDateTime(reader["Data"]),
                                Data1 = Convert.ToDateTime(reader["Data1"]),
                                Estat = reader["Estat"].ToString()
                            });
                        }
                    }
                }
            }
            return result;
        }
        public int Add(Tasca tasc)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "INSERT INTO Tasca (name, descripcio, data, data1, estat) VALUES (@name, @descripcio, @data, @data1, @estat)";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("name", tasc.Name));
                    //command.Parameters.Add(new SQLiteParameter("responsable_tasca", tasc.ResponsableTasca));
                    command.Parameters.Add(new SQLiteParameter("descripcio", tasc.Descripcio));
                    command.Parameters.Add(new SQLiteParameter("data", tasc.Data));
                    command.Parameters.Add(new SQLiteParameter("data1", tasc.Data1));
                    command.Parameters.Add(new SQLiteParameter("estat", tasc.Estat));
                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }


        public Tasca GetById(int Id)
        {
            Tasca user = null;

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
                            user = new Tasca()
                            {
                                ID = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Descripcio = reader["Descripcio"].ToString(),
                                Data = Convert.ToDateTime(reader["Data"]),
                                Data1 = Convert.ToDateTime(reader["Data1"]),
                                Estat = reader["Estat"].ToString()
                            };
                        }
                    }
                }
            }
            return user;
        }


        public int Update(Tasca tascaa, string estat)
        {
            int rows_afected = 0;
            using (var ctx = DbContext.GetInstance())
            {
                string query = "UPDATE Tasca SET name = @name, descripcio = @descripcio, data = @data, data1 = @data1, estat = @estat  WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("name", tascaa.Name));
                    // command.Parameters.Add(new SQLiteParameter("responsable_tasca", user.ResponsableTasca));
                    command.Parameters.Add(new SQLiteParameter("descripcio", tascaa.Descripcio));
                    command.Parameters.Add(new SQLiteParameter("data", tascaa.Data));
                    command.Parameters.Add(new SQLiteParameter("data1", tascaa.Data1));
                    command.Parameters.Add(new SQLiteParameter("estat", estat));
                    command.Parameters.Add(new SQLiteParameter("Id", tascaa.ID));

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
                string query = "DELETE FROM Tasca WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, ctx))
                {
                    command.Parameters.Add(new SQLiteParameter("ID", ID));
                    rows_afected = command.ExecuteNonQuery();
                }
            }

            return rows_afected;
        }

    }


}