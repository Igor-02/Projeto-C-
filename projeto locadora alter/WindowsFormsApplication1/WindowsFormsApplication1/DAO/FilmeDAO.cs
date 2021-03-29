using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.model;

namespace WindowsFormsApplication1.DAO
{
   public class FilmeDAO
    {
        MySqlConnection conexao;
        //construtor 
        public FilmeDAO()
        {
            this.conexao = ConnectionFactory.getConnection();
        }
         public void cadastrarFilme(Filme obj)
         {

            try
            {
                // 1 passo-comando sql
                string sql = @"insert into Filmes(nome_filme,categoria_id,diretor,valor_locacao)
                             values(@nome,
                                    @categoria,
                                   @diretor,
                                   @valor)";
                                   



                //2 passo - organizar e executar o sql
                MySqlCommand comando = new MySqlCommand(sql,conexao);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@categoria", obj.categoria);
                comando.Parameters.AddWithValue("@diretor", obj.diretor);
                comando.Parameters.AddWithValue("@reservado", obj.reservado);
                comando.Parameters.AddWithValue("@valor", obj.Valor);
                

                // 3 passo - executar o comando
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();

             
            }
            catch (Exception erro)
            {
                MessageBox.Show("aconteceu um erro:" + erro);

            }
        }
        //metodo altera
        public void alterarFilme(Filme obj)
        {
            try
            {
                // 1 passo-comando sql
                string sql = @"update filmes set
                                   nome_filme =@nome,
                                   categoria_id=@categoria,
                                   diretor=@diretor,
                                   valor_locacao=@valor
                                   where idfilme =@cod";




                //2 passo - organizar e executar o sql
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@categoria", obj.categoria);
                comando.Parameters.AddWithValue("@diretor", obj.diretor);
              
                comando.Parameters.AddWithValue("@valor", obj.Valor);
                comando.Parameters.AddWithValue("@cod", obj.Codigo);
              
                // 3 passo - executar o comando
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();

           
            }
            catch (Exception erro)
            {
                MessageBox.Show("aconteceu um erro:" + erro);

            }
        }
        //metodo excluir
        public void excluirFilme(Filme obj)
        {
            try
            {
                // 1 passo-comando sql
                string sql = @"delete from Filmes where idfilme =@cod";




                //2 passo - organizar e executar o sql
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@cod", obj.Codigo);

                // 3 passo - executar o comando
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();

               
            }
            catch (Exception erro)
            {
                MessageBox.Show("aconteceu um erro:" + erro);

            }
        }
        #region metodo listar
        public DataTable listarFilme()
        {
            // 1 passo-comando sql
            string sql = @"select f.idfilme, f.nome_filme, c.nome_categoria, f.diretor, f.valor_locacao
                               from filmes as f join categorias as c on (f.categoria_id = c.idcategoria) ";

            // 2 passo- organizar comando sql
            MySqlCommand executarcmdsql = new MySqlCommand(sql, conexao);

            // 3 passo abrir e executar o comando sql
            conexao.Open();
            executarcmdsql.ExecuteNonQuery();

            //4passo criar o datatable
            DataTable tabelaFilme = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(executarcmdsql);

            da.Fill(tabelaFilme);

            //fechar conexão
            conexao.Close();
            //retornar o DataTable com os dados
            return tabelaFilme;
        }
        #endregion

        
    }
    }


    