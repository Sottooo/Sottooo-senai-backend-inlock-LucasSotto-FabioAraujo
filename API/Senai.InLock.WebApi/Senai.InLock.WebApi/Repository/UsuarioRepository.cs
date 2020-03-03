using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV1101\\SQLEXPRESS; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=sa@132";


        public UsuariosDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string query = "SELECT IdUsuarios, Email, Senha, IdTipoUsuario FROM Usuarios WHERE Email = @Email AND Senha = @Senha";


                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        UsuariosDomain usuario = new UsuariosDomain();

                        while (rdr.Read())
                        {
                            usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuarios"]);

                            usuario.Email = rdr["Email"].ToString();

                            usuario.Senha = rdr["Senha"].ToString();

                            usuario.IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]);
                        }

                        return usuario;
                    }
                }

                return null;
            }
        }


    }
}
