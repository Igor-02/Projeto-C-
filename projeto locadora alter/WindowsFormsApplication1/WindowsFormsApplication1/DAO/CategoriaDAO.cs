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
   public class CategoriaDAO
    {
        MySqlConnection conexao;
        //construtor 
        public CategoriaDAO()
        {
            this.conexao = ConnectionFactory.getConnection();
        }
         public void cadastrarCategoria(Categoria obj)
         {

            try
            {
                // 1 passo-comando sql
                string sql = @"insert into categorias(nome_categoria)
                             values(@nome)";
                                   



                //2 passo - organizar e executar o sql
                MySqlCommand comando = new MySqlCommand(sql,conexao);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                

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
        public void alterarCategoria(Categoria obj)
        {
            try
            {
                // 1 passo-comando sql
                string sql = @"update categorias set
                                    nome_categoria =@nome
                                   where idcategoria =@cod";




                //2 passo - organizar e executar o sql
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
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
        public void excluirCategoria(Categoria obj)
        {
            try
            {
                // 1 passo-comando sql
                string sql = @"delete from categorias
                                   where idcategoria =@cod";




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
        public DataTable listarCategoria()
        {
            // 1 passo-comando sql
            string sql = @"select*from categorias";

            // 2 passo- organizar comando sql
            MySqlCommand executarcmdsql = new MySqlCommand(sql, conexao);

            // 3 passo abrir e executar o comando sql
            conexao.Open();
            executarcmdsql.ExecuteNonQuery();

            //4passo criar o datatable
            DataTable tabelaCategorias = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(executarcmdsql);

            da.Fill(tabelaCategorias);

            //fechar conexão
            conexao.Close();
            //retornar o DataTable com os dados
            return tabelaCategorias;
        }
        #endregion

        
    }
    }

