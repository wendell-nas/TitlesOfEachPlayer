using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitlesOfEachPlayer
{
    public partial class login : Form
    {
        string strConexao = @"Data Source =.\SQLEXPRESS; Initial Catalog = bd_titulos; Persist Security Info = True; User ID = sa; Password = sql2022";
        SqlConnection conexao;

        public login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            conexao = new SqlConnection(strConexao);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao;
            cmd.CommandText = "SELECT usuario FROM Usuario WHERE usuario = @user";
            cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
            conexao.Open();
            if (cmd.ExecuteScalar() == null)
            {
                cmd.CommandText = "INSERT INTO Usuario(usuario, senha) VALUES(@ser, @senha)";
                cmd.Parameters.AddWithValue("@ser", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                cmd.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Usuario cadastrado no Sistema");
                DialogResult resposta = MessageBox.Show("Entrar agora?", "Acesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta.ToString() == "Yes")
                {
                    this.Hide();
                    TelaPrincipal fPrincipal = new TelaPrincipal();
                    fPrincipal.ShowDialog();
                    conexao.Close();
                }
            }
            else
            {
                cmd.CommandText = "SELECT senha FROM Usuario WHERE usuario = @u";
                cmd.Parameters.AddWithValue("@u", txtUsuario.Text);
                if (txtSenha.Text == cmd.ExecuteScalar().ToString())
                {
                    this.Hide();
                    TelaPrincipal fPrincipal = new TelaPrincipal();
                    fPrincipal.ShowDialog();
                    conexao.Close();
                }
                else
                {
                    MessageBox.Show("Senha incorreta!");
                    conexao.Close();
                }
            }

        }
    }
}
