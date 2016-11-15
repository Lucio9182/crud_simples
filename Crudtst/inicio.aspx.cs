using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Crudtst
{
    public partial class empform : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0AAOA16\\MSSQLSERVER02;Initial Catalog=Lucio;Integrated Security=True");
        public int selecionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mostrar_Valores();
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            con.Open();
            String str = "Insert into Crud values ('"+ txtNome.Text +"','"+txttel.Text+"')";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();

      


            con.Close();
            Mostrar_Valores();
            txtNome.Text = "";
            txttel.Text = "";
            

        }
        protected void lnk_Selecionar(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["id"] = btn.CommandArgument;
            GridViewRow linhaSelec = (GridViewRow)btn.NamingContainer;
            int linhaIndex = linhaSelec.RowIndex; 
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Crud", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            
            adp.Fill(dt);

            con.Close();
            if (dt.Rows.Count >= 0)
            {

                selecionado = (int)dt.Rows[linhaIndex]["id"];

                txtNome.Text = dt.Rows[linhaIndex]["nome"].ToString(); 
                txttel.Text = dt.Rows[linhaIndex]["tel"].ToString();
                

            }

           

        }

        protected void lnk_Apagar(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["id"] = btn.CommandArgument;

            con.Open();
            SqlCommand cmd = new SqlCommand("Delete From Crud WHERE Id = " + Session["id"] + ";", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            Mostrar_Valores();



        }




        public void Mostrar_Valores()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Crud", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            con.Close();

        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Crud SET Nome = '"+txtNome.Text+"', Tel = '"+txttel.Text+ "' WHERE Id = "+Session["id"]+";" , con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            Mostrar_Valores();
            }

        protected void btnApagar_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete From Crud WHERE Id = " + Session["id"] + ";", con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            Mostrar_Valores();
        }
    }
}