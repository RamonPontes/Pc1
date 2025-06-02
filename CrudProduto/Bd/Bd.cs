using MySql.Data.MySqlClient;

namespace CrudProduto.Bd
{
    public class Bd
    {
        static string usuario = "root";
        static string banco = "crudproduto";
        static string senha = "vertrigo";
        static string servidor = "localhost";
        static MySqlConnection? conexao;

        public static MySqlConnection Conexao
        {
            get
            {
                if (conexao == null || conexao.State == System.Data.ConnectionState.Broken || conexao.State == System.Data.ConnectionState.Closed)
                {
                    string strConnString = $"Data Source={servidor};user id={usuario};password={senha};database={banco};sslmode=none;";
                    conexao = new MySqlConnection();
                    conexao.ConnectionString = strConnString;
                    conexao.Open();
                }
                return conexao;
            }
            set
            {
                conexao = value;
            }
        }

        public static void Fechar()
        {
            conexao?.Close();
        }
    }
}