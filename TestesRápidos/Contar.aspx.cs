using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

//        string path = this.Server.MapPath("~/app_data/Clientes3.mdf");

//        string cnnString = string.Format(@"Data Source=.\SQLExpress;AttachDbFilename={0}; 
//        Integrated Security=True; User Instance=True", path);

        string cnnString = ConfigurationManager.ConnectionStrings["BaseDadosSQL"].ConnectionString;

        string sqlString = "select count(*) from Registos";

        SqlConnection cnn = new SqlConnection(cnnString);

        //OUTRAS INTRUÇÕES

        SqlCommand cmd = new SqlCommand(sqlString, cnn);
        cnn.Open();

       int result = Convert.ToInt32(cmd.ExecuteScalar());


        texto.Text = "O resultado é: " + result;
        cnn.Close();

    }
}