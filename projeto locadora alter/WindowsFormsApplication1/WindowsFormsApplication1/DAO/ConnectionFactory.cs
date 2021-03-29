using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.DAO
{
   public class ConnectionFactory
    {
        public static MySqlConnection getConnection()
        {
            //acessando a string de conexão
            string conexao = ConfigurationManager.
                        ConnectionStrings["projeto_locadora"].ConnectionString;
            return new MySqlConnection(conexao);
        }   
    }
}
