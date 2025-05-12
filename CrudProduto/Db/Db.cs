using MySql.Data.MySqlClient;

namespace CrudProduto.Db {
    public class Db {
        static string usuario = "root";
        static string banco = "produto";
        static string senha = "vertrigo";
        static string servidor = "localhost";
        static MySqlConnection conexao;

        public static MySqlConnection Conexao {
            get {   
                if (conexao == null || conexao.State == System.Data.ConnectionState.Broken || conexao.State == System.Data.ConnectionState.Closed) {
                    string strConnString = string.Format(
                        "Data source={0};user id={1};password={2};database={3};sslmode=none;", servidor, usuario, senha, banco
                    );

                    conexao = new MySqlConnection();
                    conexao.ConnectionString = strConnString;
                    conexao.Open();
                }

                return conexao;
            }

            set {
                conexao = value;
            }
        }

        public static void Fechar() {
            conexao?.Close();
        }
    }
}