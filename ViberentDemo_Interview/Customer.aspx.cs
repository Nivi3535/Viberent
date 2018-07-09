using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ViberentDemo_Interview
{
    public partial class Customer : System.Web.UI.Page

    {
        string btninput;
        //Connection String
        SqlConnection connection = new SqlConnection(@"Data Source = DESKTOP-ODLE4NA; Initial Catalog = ViberentCustomerCRUD ; Integrated Security = true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Enabled = false;
                FillingGrid();
            }

        }
        //Delete Operation "Deleted using stored Procedure DeleteByID 
        //In this case record is deleted based on CustomerId(Autogenrated and hidden field)" 
       
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand command = new SqlCommand("DeleteByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(HiddenFieldId.Value));
            command.ExecuteNonQuery();
            Delete();

            lSuccessMsg.Text = "Deleted Successfully !! ";
            FillingGrid();

        }

        // Add or Update Based on string value btninput 
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (connection.State == ConnectionState.Closed)

                connection.Open();
            //Checking if btninput is Update if then it perform Update operation else Add(Insert) operation
            if (btninput == "Update")
            {
               
                SqlCommand command = new SqlCommand("CustomerUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                // command.Parameters.Add("@CustomerId", (HiddenFieldId.Value == "" ? 0 : Convert.ToInt32(HiddenFieldId.Value)));
                command.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = txtCustomerName.Text;
                command.Parameters.Add("@CustomerFirstName", SqlDbType.NVarChar).Value = txtCustomerFN.Text;
                command.Parameters.AddWithValue("@CustomerLastName", SqlDbType.NVarChar).Value = txtCustomerLN.Text;
                command.Parameters.AddWithValue("@CustomerPhoneNumber", SqlDbType.NVarChar).Value = txtCustomerPhone.Text;
                command.Parameters.AddWithValue("@CustomerAddress", SqlDbType.NVarChar).Value = txtCustomerAddress.Text;
                command.Parameters.AddWithValue("@CustomerEmailId", SqlDbType.NVarChar).Value = txtCustomerEmailId.Text;
                command.Parameters.AddWithValue("@CustomerPassword", SqlDbType.NVarChar).Value = txtCustomerPassword.Text;
                command.ExecuteNonQuery();
                // string CustomerID_Check = HiddenFieldId.Value;
                // Delete();
                connection.Close();
                lSuccessMsg.Text = "Upated Successfully !!";
                FillingGrid();
            }
           else
            { 
            string query = "select count(*)  from ViberentCustomer where CustomerEmailId= '" + txtCustomerEmailId.Text + "'";
            SqlCommand cmd = new SqlCommand(query, connection);
            string isemail = cmd.ExecuteScalar().ToString();
                 if(isemail == "0")
                 {
                        SqlCommand command = new SqlCommand("CustomerAddorUpdate", connection);
                        command.CommandType = CommandType.StoredProcedure;
                         command.Parameters.AddWithValue("@CustomerId", (HiddenFieldId.Value =="" ? 0 : Convert.ToInt32(HiddenFieldId.Value)));
                         command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        command.Parameters.AddWithValue("@CustomerFirstName", txtCustomerFN.Text);
                        command.Parameters.AddWithValue("@CustomerLastName", txtCustomerLN.Text);
                        command.Parameters.AddWithValue("@CustomerPhoneNumber", txtCustomerPhone.Text);
                        command.Parameters.AddWithValue("@CustomerAddress", txtCustomerAddress.Text);
                        command.Parameters.AddWithValue("@CustomerEmailId", txtCustomerEmailId.Text);
                        command.Parameters.AddWithValue("@CustomerPassword", txtCustomerPassword.Text);
                        command.ExecuteNonQuery();
                        connection.Close();
                        lSuccessMsg.Text = "Saved Successfully !!";
                        FillingGrid();
                }
                else
                {
                        lValidationSummary.Text = "Cannot perform ADD Email already exist";
                }
            }
        }
        void FillingGrid()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("CustomerView", connection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                connection.Close();
                GridCustomerDetails.DataSource = dataTable;
                GridCustomerDetails.DataBind();
                connection.Close();

            }
        }

        protected void Link_OnClick(object sender, EventArgs e)
        {
          //  lSuccessMsg.Text = "";
            int CustomerId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (connection.State == ConnectionState.Closed)

                connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("ViewByID", connection);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerId", CustomerId);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            connection.Close();
            GridCustomerDetails.DataSource = dataTable;
            GridCustomerDetails.DataBind();
            HiddenFieldId.Value = CustomerId.ToString();
            txtCustomerName.Text = dataTable.Rows[0]["CustomerName"].ToString();
            txtCustomerFN.Text = dataTable.Rows[0]["CustomerFirstName"].ToString();
            txtCustomerLN.Text = dataTable.Rows[0]["CustomerLastName"].ToString();

            txtCustomerPhone.Text = dataTable.Rows[0]["CustomerPhoneNumber"].ToString();
            txtCustomerAddress.Text = dataTable.Rows[0]["CustomerAddress"].ToString();
            txtCustomerEmailId.Text = dataTable.Rows[0]["CustomerEmailId"].ToString();
            btnAdd.Text = "Update";
            btninput = btnAdd.Text;
            btnDelete.Enabled = true;
        }
       
            protected void btnClear_Click(object sender, EventArgs e)
        {
            Delete();
        }
        public void Delete()
        {
            HiddenFieldId.Value = "";
            txtCustomerName.Text = "";
            txtCustomerFN.Text = "";
            txtCustomerLN.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerEmailId.Text = "";
            txtCustomerPassword.Text = "";
            btnAdd.Text = "Add";
            btnDelete.Enabled = false;
        }


    }
      
}