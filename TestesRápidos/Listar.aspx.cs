using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Listar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string path = this.Server.MapPath("~/app_data/Clientes3.mdf");

        string cnnString = string.Format(@"Data Source=.\SQLExpress;AttachDbFilename={0}; 
        Integrated Security=True; User Instance=True", path);

        string sqlString = "select IDCliente, Nome, Apelido from Registos";

        SqlConnection cnn = new SqlConnection(cnnString);

        //OUTRAS INTRUÇÕES

        SqlCommand cmd = new SqlCommand(sqlString,cnn);
        cnn.Open();

        SqlDataReader reader = cmd.ExecuteReader();


        texto.Text = "";

        while (reader.Read())
        {
            texto.Text += string.Format("Nome: {0} Apelido:{1} <br/>", reader.GetString(1), reader.GetString(2));
        }
        //OUTRAS INTRUÇÕES
        reader.Close();
        cnn.Close();

    }
}