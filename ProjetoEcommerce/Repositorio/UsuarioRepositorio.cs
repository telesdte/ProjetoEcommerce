using MySql.Data.MySqlClient;
using ProjetoEcommerce.Models;
using System.Data;

namespace ProjetoEcommerce.Repositorio
{
    public class UsuarioRepositorio(IConfiguration configuration)
    {
        //campo privado para leitura e armazenamento da string de con
        private readonly string _conexaoMySQL = configuration.GetConnectionString("conexaoMySQL");

        public Usuario ObterUsuario(string email)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new("SELECT * FROM Usuario WHERE Email = @email", conexao);
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

                using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    Usuario usuario = null;

                    if (dr.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nome = dr["Nome"].ToString(),
                            Email = dr["Email"].ToString(),
                            Senha = dr["Senha"].ToString()
                        };
                    }
                    return usuario;
                }
            }
        }

        // MÉTODO DE CADASTRO DE USUÁRIO
        public void Cadastrar(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new("INSERT INTO Usuario (Nome, Email, Senha) VALUES (@nome, @email, @senha)", conexao);

                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.Nome;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = usuario.Email;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.Senha; // depois vamos colocar hash aqui

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}
