using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql; // Pour la connexion à PostgreSQL

namespace football.objets
{
    internal class Connexion
    {
        public NpgsqlConnection DbConnect()
        {
            string connectionString = "Server=localhost;Port=5432;Database=football;User Id=postgres;Password=root;";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            
            return connection;
        }
    }
}
