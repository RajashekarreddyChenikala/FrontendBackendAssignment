using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Text;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Assignment
{
    public partial class Employee : System.Web.UI.Page
    {
        private void FillData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId");
            dt.Columns.Add("EmpName");
            dt.Columns.Add("EmpDob");
            dt.Columns.Add("EmpSkills");
            dt.Columns.Add("EmpAddress");
            dt.Columns.Add("EmpRole");
            dt.Columns.Add("EmpSalary");
            ViewState["dt"] = dt;
            GridView1.DataSource = ViewState["dt"] as DataTable;
            GridView1.DataBind();
            GetData();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
            {
                FillData();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows.Add(txtid.Text,txtname.Text, txtdob.Text, txtskills.Text, txtaddress.Text,txtrole.Text,txtsalary.Text);
            ViewState["dt"] = dt;
            GridView1.DataSource = ViewState["dt"] as DataTable;
            GridView1.DataBind();
            txtid.Text = "";
            txtname.Text ="";
            txtdob.Text ="";
            txtskills.Text = "";
            txtaddress.Text = "";
            txtrole.Text = "";
            txtsalary.Text = "";
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows.RemoveAt(row.RowIndex);
            ViewState["dt"] = dt;
            GridView1.DataSource = ViewState["dt"] as DataTable;
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="send")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                var id = Convert.ToInt32(GridView1.Rows[RowIndex].Cells[2].Text);
                var name = GridView1.Rows[RowIndex].Cells[3].Text;
                var dob = Convert.ToDateTime(GridView1.Rows[RowIndex].Cells[4].Text);
                var skills = GridView1.Rows[RowIndex].Cells[5].Text;
                var address = GridView1.Rows[RowIndex].Cells[6].Text;
                var role = GridView1.Rows[RowIndex].Cells[7].Text;
                var salary = Convert.ToDecimal(GridView1.Rows[RowIndex].Cells[8].Text);
                string apiUrl = "http://localhost:60177/api/Employee";
                var input = new
                {
                    id = id,
                    name = name,
                    dob = dob,
                    skills = skills,
                    address = address,
                    role = role,
                    salary = salary 
                };
                string inputJson = new JavaScriptSerializer().Serialize(input);
                HttpClient client = new HttpClient();
                HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(apiUrl + "/Post", inputContent).Result;
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        DataTable dt = ViewState["dt"] as DataTable;
                        dt.Rows.RemoveAt(RowIndex);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }     
        protected void GetData()
        {
            string apiUrl = "http://localhost:26404/api/CustomerAPI";
            var input = new
            {
                Name = txtname.Text.Trim(),
            };
            string inputJson = (new JavaScriptSerializer()).Serialize(input);
            HttpClient client = new HttpClient();
            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(apiUrl + "/Get", inputContent).Result;
        }
    }
}