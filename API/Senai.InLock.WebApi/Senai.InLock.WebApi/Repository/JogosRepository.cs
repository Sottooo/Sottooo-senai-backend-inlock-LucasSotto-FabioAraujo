using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repository
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DEV1101\\SQLEXPRESS; initial catalog=Inlock_Games_Tarde; user Id=sa; pwd=sa@132";

        public void CadastrarJogo(JogosDomain jogoRecebido)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastro = "INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", jogoRecebido.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogoRecebido.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogoRecebido.DataLancamento.ToString());
                    cmd.Parameters.AddWithValue("@Valor", jogoRecebido.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", jogoRecebido.IdEstudio);

                    rdr = cmd.ExecuteReader();
                }
            }
        }

        public List<JogosDomain> ListarJogos()
        {
            List<JogosDomain> lista = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryLista = "SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Jogos.IdEstudio, Estudios.IdEstudio, Estudios.NomeEstudio FROM Jogos LEFT JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLista, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        JogosDomain jogos = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = DateTime.Parse(rdr["DataLancamento"].ToString()),
                            Valor = Convert.ToSingle(rdr["Valor"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };

                        lista.Add(jogos);
                    }
                    return lista;
                }

            }
        }
    }
}
