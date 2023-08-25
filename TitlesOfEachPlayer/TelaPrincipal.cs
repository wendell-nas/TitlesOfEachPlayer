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
    public partial class TelaPrincipal : Form
    {
        string strConexao = @"Data Source =.\SQLEXPRESS; Initial Catalog = bd_titulos; Persist Security Info = True; User ID = sa; Password = sql2022";
        public int codigo = 3;
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter daFun = new SqlDataAdapter("SELECT * FROM tblJogadores", strConexao);
            daFun.Fill(tabela);
            comboBox1.DataSource = tabela;
            comboBox1.DisplayMember = "nome";
            comboBox1.ValueMember = "id";
           
        }
    }
}
