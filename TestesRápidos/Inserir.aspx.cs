using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inserir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cnnString = ConfigurationManager.ConnectionStrings["BaseDadosSQL"].ConnectionString;

        string sqlString = "Insert into Registos (Nome, Apelido) Values('PW', 'PW')";

        SqlConnection cnn = new SqlConnection(cnnString);

        //OUTRAS INTRUÇÕES

        SqlCommand cmd = new SqlCommand(sqlString, cnn);
        cnn.Open();

        cmd.ExecuteNonQuery();


        //texto.Text = "O resultado é: " + result;
        cnn.Close();
    }
}