using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.model;
using WindowsFormsApplication1.view;

namespace WindowsFormsApplication1.DAO
{
    public class ClienteDAO
    {
        MySqlConnection conexao;
        //construtor 
        public ClienteDAO()
        {
            this.conexao = ConnectionFactory.getConnection();
        }
        public void cadastrarCliente(Cliente obj)
        {

            try
            {
                // 1 passo-comando sql
                string sql = @"insert into clientes (nome,rg,telefone,endereco,bairro,cidade,uf,email,datanascimento,sexo)
                             values(@nome,
                                    @rg,
                                    @telefone, 
                                    @end,
                                    @bairro,
                                    @cidade,
                                    @uf,
                                    @email,
                                    @datanascimento,
                                    @sexo)";



                //2 passo - organizar e executar o sql
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@rg", obj.Rg);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@end", obj.Endereco);
                comando.Parameters.AddWithValue("@bairro", obj.Bairro);
                comando.Parameters.AddWithValue("@cidade", obj.cidade);
                comando.Parameters.AddWithValue("@email", obj.Email);
                comando.Parameters.AddWithValue("@uf", obj.estado);
                comando.Parameters.AddWithValue("@datanascimento", obj.data_nascimento);
                comando.Parameters.AddWithValue("@sexo", obj.sexo);

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
        public void alterarCliente(Cliente obj)
        {
            try
            {
                // 1 passo-comando sql
                string sql = @"update clientes set
                                    nome =@nome,
                                     rg=@rg,
                                    telefone=@telefone,
                                    endereco=@end,
                                    bairro=@bairro,
                                     cidade=@cidade,
                                    email=@email,
                                    datanascimento=@datanascimento,
                                    sexo=@sexo
                                   where idcliente =@cod";




                //2 passo - organizar e executar o sql
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@rg", obj.Rg);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@end", obj.Endereco);
                comando.Parameters.AddWithValue("@bairro", obj.Bairro);
                comando.Parameters.AddWithValue("@cidade", obj.cidade);
                comando.Parameters.AddWithValue("@email", obj.Email);
                comando.Parameters.AddWithValue("@cod", obj.Codigo);
                comando.Parameters.AddWithValue("@datanascimento", obj.data_nascimento);
                comando.Parameters.AddWithValue("@sexo", obj.sexo);
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
        public void excluirCliente(Cliente obj)
        {
            try
            {
                // 1 passo-comando sql
                string sql = @"delete from clientes
                                   where  idcliente  =@cod";




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
        public DataTable listarClientes()
        {
            // 1 passo-comando sql
            string sql = @"select*from clientes";

            // 2 passo- organizar comando sql
            MySqlCommand executarcmdsql = new MySqlCommand(sql, conexao);

            // 3 passo abrir e executar o comando sql
            conexao.Open();
            executarcmdsql.ExecuteNonQuery();

            //4passo criar o datatable
            DataTable tabelaCliente = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(executarcmdsql);

            da.Fill(tabelaCliente);

            //fechar conexão
            conexao.Close();
            //retornar o DataTable com os dados
            return tabelaCliente;
        }
        #endregion

        #region metodo EfetuarLogin
        public void efetuarLogin(string email, string senha)
        {
            string sql = @"select * from usuario where login = @email and senha = @senha";

            MySqlCommand executacmdsql = new MySqlCommand(sql, conexao);
            executacmdsql.Parameters.AddWithValue("@email", email);
            executacmdsql.Parameters.AddWithValue("@senha", senha);

            conexao.Open();

            MySqlDataReader dados = executacmdsql.ExecuteReader();

            if (dados.Read())
            {
                MessageBox.Show("O Login deu certo");

                
                String cargo = dados.GetString("cargo");

                if (cargo.Equals("Gerente"))
                {


                    FrmMenu telamenu = new FrmMenu();

                    telamenu.Show();


                }
                else if (cargo.Equals("vendedor"))
                {
                    FrmMenu telamenu = new FrmMenu();
                    telamenu.btnClienteMenu.Enabled = false;
                    telamenu.Show();


                }
                else
                {
                    MessageBox.Show("email ou senha incorreto");
                }


            }

        #endregion


        }
    }
}


