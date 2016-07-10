using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inserir2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string cnnString = ConfigurationManager.ConnectionStrings["BaseDadosSQL"].ConnectionString;

            //string sqlString = "Insert into Registos (Nome, Apelido) Values('PW', 'PW')";
            //string sqlString = "Insert into Registos (Nome, Apelido) Values('"+ TextBox1.Text+"', '"+ TextBox2.Text+"')";
            string sqlString = "Insert into Registos (Nome, Apelido) Values(@nome, @apelido)";
            SqlConnection cnn = new SqlConnection(cnnString);

            //OUTRAS INTRUÇÕES

            SqlCommand cmd = new SqlCommand(sqlString, cnn);

            cmd.Parameters.AddWithValue("@nome", TextBox1.Text);
            cmd.Parameters.AddWithValue("@apelido", TextBox2.Text);
            cnn.Open();

            cmd.ExecuteNonQuery();


            //texto.Text = "O resultado é: " + result;
            cnn.Close();
        }
        catch (SqlException)
        {

            erro.Text="Ocorreu um erro ao inserir os dados. Tente mais tarde.";
        }

    }
}