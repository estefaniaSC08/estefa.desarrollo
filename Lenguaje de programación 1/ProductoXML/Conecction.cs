using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

// Microsoft.Data.SqlClient


namespace ProductoXML.Data
{
    public class Conecction
    {
        private readonly string connectionString = "Server=localhost;Database=PersonaDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection CrearConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}
