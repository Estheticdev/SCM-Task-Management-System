using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCM_Activities
{
    public partial class AddData : System.Web.UI.Page
    {

        SqlConnection sqlCon = new SqlConnection("Data Source = LAP-SCM009; Initial Catalog = SCM_TMS_27072021; Integrated Security = True");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Load Form for Update
                string str = Request.QueryString["RecordNumber"];
                //End load form for update
                btnDelete.Enabled = false;              //FillGridView();

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("select * from dbo.Project_List", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                txtProject.DataTextField = ds.Tables[0].Columns["Project_Name"].ToString();
                txtProject.DataValueField = ds.Tables[0].Columns["Project_Name"].ToString();
                txtProject.DataSource = ds.Tables[0];
                txtProject.DataBind();
                sqlCon.Close();

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmdd = new SqlCommand("select * from dbo.Client_Name_List", sqlCon);
                SqlDataAdapter daa = new SqlDataAdapter(sqlCmdd);
                DataSet dss = new DataSet();
                daa.Fill(dss);
                txtClient.DataTextField = dss.Tables[0].Columns["Client_Name"].ToString();
                txtClient.DataValueField = dss.Tables[0].Columns["Client_Name"].ToString();
                txtClient.DataSource = dss.Tables[0];
                txtClient.DataBind();
                sqlCon.Close();

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmmdd = new SqlCommand("select * from dbo.Primary_Secondary_List", sqlCon);
                SqlDataAdapter daaa = new SqlDataAdapter(sqlCmmdd);
                DataSet dsss = new DataSet();
                daaa.Fill(dsss);
                drpPrimary.DataTextField = dsss.Tables[0].Columns["Primary_Secondary"].ToString();
                drpPrimary.DataValueField = dsss.Tables[0].Columns["Primary_Secondary"].ToString();
                drpPrimary.DataSource = dsss.Tables[0];
                drpPrimary.DataBind();

                drpSecondary.DataTextField = dsss.Tables[0].Columns["Primary_Secondary"].ToString();
                drpSecondary.DataValueField = dsss.Tables[0].Columns["Primary_Secondary"].ToString();
                drpSecondary.DataSource = dsss.Tables[0];
                drpSecondary.DataBind();
                sqlCon.Close();

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmmd = new SqlCommand("select * from dbo.Release_Status", sqlCon);
                SqlDataAdapter dda = new SqlDataAdapter(sqlCmmd);
                DataSet dds = new DataSet();
                dda.Fill(dds);
                drpStatus.DataTextField = dds.Tables[0].Columns["Status"].ToString();
                drpStatus.DataValueField = dds.Tables[0].Columns["Status"].ToString();
                drpStatus.DataSource = dds.Tables[0];
                drpStatus.DataBind();

                sqlCon.Close();



            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            hfRecordNumber.Value = "";
            txtProject.DataValueField = txtClient.DataValueField = txtRelease.Text = drpPrimary.DataValueField = drpSecondary.DataValueField = drpStatus.DataValueField = txtBuilds.Text = txtCodeFreeze.Text = txtCodeFreezeTime.Text = txtActualCodeFreeze.Text = txtActualCodeFreezeTime.Text = txtPlannedShipment.Text = txtPlannedShipmentTime.Text = txtActualShipment.Text = txtActualShipmentTime.Text = txtFault.Text = txtModification.Text = txtDataCorrection.Text = txtEnhancement.Text = txtOptimization.Text = txtOthers.Text = txtTotal.Text = txtCritical.Text = txtModerate.Text = txtMinor.Text = txtTotalP.Text = txtInternalCR.Text = txtGAP.Text = txtJiraIssues.Text = txtUATIssues.Text = txtComments.Text = txtEffor.Text = "";
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("CurrentCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@RecordNumber", (hfRecordNumber.Value == "" ? 0 : Convert.ToInt32(hfRecordNumber.Value)));
            sqlCmd.Parameters.AddWithValue("@ProjectName", txtProject.SelectedValue.Trim());
            sqlCmd.Parameters.AddWithValue("@client", txtClient.SelectedValue.Trim());
            sqlCmd.Parameters.AddWithValue("@Pro_Rel_Pat_number", txtRelease.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@primary_name", drpPrimary.SelectedValue.Trim());
            sqlCmd.Parameters.AddWithValue("@secondary_name", drpSecondary.SelectedValue.Trim());
            sqlCmd.Parameters.AddWithValue("@shipped", drpStatus.SelectedValue.Trim());
            sqlCmd.Parameters.AddWithValue("@actual_build", txtBuilds.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Plan_Codefreeze", txtCodeFreeze.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@time_planned_code_freeze", txtCodeFreezeTime.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@actual_codefreeze", txtActualCodeFreeze.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@time_actual_code_freeze", txtActualCodeFreezeTime.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@plan_shipment", txtPlannedShipment.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@time_planned_shipment", txtPlannedShipmentTime.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@actual_shipment", txtActualShipment.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@time_actual_shipment", txtActualShipmentTime.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@fault", txtFault.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@modification", txtModification.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@datacorrection", txtDataCorrection.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@enhacement", txtEnhancement.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@optimization", txtOptimization.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@others", txtOthers.Text.Trim());
          //  sqlCmd.Parameters.AddWithValue("@total_category_hd", txtTotal.Text.Trim());

            sqlCmd.Parameters.AddWithValue("@crittical", txtCritical.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@moderate", txtModerate.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@minor", txtMinor.Text.Trim());
          //  sqlCmd.Parameters.AddWithValue("@total_priory_hd", txtTotalP.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@internal_cr", txtInternalCR.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@gaps", txtGAP.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@jira_issue", txtJiraIssues.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@uat_issue", txtUATIssues.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@comments", txtComments.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@effor_hours", txtEffor.Text.Trim());

            int fault, modification, datacorrection, enhacement, others, total_category_hd;
            int optimization;


          //  fault = int.Parse(txtFault.Text);
            if(txtFault.Text == "")
            {
                txtFault.Text = "0";
                fault = int.Parse(txtFault.Text);
            }
            else {
                fault = int.Parse(txtFault.Text);
            }
            if (txtModification.Text == "")
            {
                txtModification.Text = "0";
                modification = int.Parse(txtModification.Text);
            }
            else
            {
                modification = int.Parse(txtModification.Text);
            }
            if (txtDataCorrection.Text == "")
            {
                txtDataCorrection.Text = "0";
                datacorrection = int.Parse(txtDataCorrection.Text);
            }
            else
            {
                datacorrection = int.Parse(txtDataCorrection.Text);
            }
            if (txtEnhancement.Text == "")
            {
                txtEnhancement.Text = "0";
                enhacement = int.Parse(txtEnhancement.Text);
            }
            else
            {
                enhacement = int.Parse(txtEnhancement.Text);
            }
            if (txtOptimization.Text == "")
            {
                txtOptimization.Text = "0";
                optimization = int.Parse(txtOptimization.Text);
            }
            else
            {
                optimization = int.Parse(txtOptimization.Text);
            }
            if (txtOthers.Text == "")
            {
                txtOthers.Text = "0";
                others = int.Parse(txtOthers.Text);
            }
            else
            {
                others = int.Parse(txtOthers.Text);
            }





            
           total_category_hd = fault + modification + datacorrection + optimization + enhacement + others;
            txtTotal.Text = total_category_hd.ToString();
            sqlCmd.Parameters.AddWithValue("@total_category_hd", txtTotal.Text.Trim());


            int crittical, moderate, minor, total_priory_hd;

            if (txtCritical.Text == "")
            {
                txtCritical.Text = "0";
                crittical = int.Parse(txtCritical.Text);
            }
            else
            {
                crittical = int.Parse(txtCritical.Text);
            }
            if (txtModerate.Text == "")
            {
                txtModerate.Text = "0";
                moderate = int.Parse(txtModerate.Text);
            }
            else
            {
                moderate = int.Parse(txtModerate.Text);
            }

            if (txtMinor.Text == "")
            {
                txtMinor.Text = "0";
                minor = int.Parse(txtMinor.Text);
            }
            else
            {
                minor = int.Parse(txtMinor.Text);
            }

            total_priory_hd = crittical + moderate + minor;
            txtTotalP.Text = total_priory_hd.ToString();
            sqlCmd.Parameters.AddWithValue("@total_priory_hd", txtTotalP.Text.Trim());



            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();

 

            string RecordNumber = hfRecordNumber.Value;
            if (RecordNumber == "")
            {
  
                    lblSuccessMessage.Text = "Saved  Successfully";
                
            }
            else
            {
                lblSuccessMessage.Text = "Updated Successfully";
                //FillGridView();
            }
            


        }

        //void FillGridView()
        //{


        //    if (sqlCon.State == ConnectionState.Closed)
        //        sqlCon.Open();
        //    SqlDataAdapter sqlDa = new SqlDataAdapter("CurrentViewAll", sqlCon);
        //    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    DataTable dtbl = new DataTable();
        //    sqlDa.Fill(dtbl);
        //    sqlCon.Close();
        //    gvContact.DataSource = dtbl;
        //    gvContact.DataBind();


        //}


        protected void lnk_OnClick(object sender, EventArgs e)
        {
            int RecordNumber = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("CurrentViewbyID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@RecordNumber", RecordNumber);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hfRecordNumber.Value = RecordNumber.ToString();
            txtProject.DataValueField = dtbl.Rows[0]["ProjectName"].ToString();
            txtClient.DataValueField = dtbl.Rows[0]["client"].ToString();
            txtRelease.Text = dtbl.Rows[0]["Pro_Rel_Pat_number"].ToString();
            drpPrimary.DataValueField = dtbl.Rows[0]["primary_name"].ToString();
            drpSecondary.DataValueField = dtbl.Rows[0]["secondary_name"].ToString();
            drpStatus.DataValueField = dtbl.Rows[0]["shipped"].ToString();
            txtBuilds.Text = dtbl.Rows[0]["actual_build"].ToString();
            txtCodeFreeze.Text = dtbl.Rows[0]["Plan_Codefreeze"].ToString();
            txtCodeFreezeTime.Text = dtbl.Rows[0]["time_planned_code_freeze"].ToString();
            txtActualCodeFreeze.Text = dtbl.Rows[0]["actual_codefreeze"].ToString();
            txtActualCodeFreezeTime.Text = dtbl.Rows[0]["time_actual_code_freeze"].ToString();
            txtPlannedShipment.Text = dtbl.Rows[0]["plan_shipment"].ToString();
            txtPlannedShipmentTime.Text = dtbl.Rows[0]["time_planned_shipment"].ToString();
            txtActualShipment.Text = dtbl.Rows[0]["actual_shipment"].ToString();
            txtActualShipmentTime.Text = dtbl.Rows[0]["time_actual_shipment"].ToString();
            txtFault.Text = dtbl.Rows[0]["fault"].ToString();
            txtModification.Text = dtbl.Rows[0]["modification"].ToString();
            txtDataCorrection.Text = dtbl.Rows[0]["datacorrection"].ToString();
            txtEnhancement.Text = dtbl.Rows[0]["enhacement"].ToString();
            txtOptimization.Text = dtbl.Rows[0]["optimization"].ToString();
            txtOthers.Text = dtbl.Rows[0]["others"].ToString();
            txtTotal.Text = dtbl.Rows[0]["total_category_hd"].ToString();
            txtCritical.Text = dtbl.Rows[0]["crittical"].ToString();
            txtModerate.Text = dtbl.Rows[0]["moderate"].ToString();
            txtMinor.Text = dtbl.Rows[0]["minor"].ToString();
            txtTotalP.Text = dtbl.Rows[0]["total_priory_hd"].ToString();
            txtInternalCR.Text = dtbl.Rows[0]["internal_cr"].ToString();
            txtGAP.Text = dtbl.Rows[0]["gaps"].ToString();
            txtJiraIssues.Text = dtbl.Rows[0]["jira_issue"].ToString();
            txtUATIssues.Text = dtbl.Rows[0]["uat_issue"].ToString();
            txtComments.Text = dtbl.Rows[0]["comments"].ToString();
            txtEffor.Text = dtbl.Rows[0]["effor_hours"].ToString();

            btnSave.Text = "Update";
            btnDelete.Enabled = true;


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("CurrentDeletebyID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@RecordNumber", Convert.ToInt32(hfRecordNumber.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            //FillGridView();
            lblSuccessMessage.Text = "Deleted Successfully";

        }

        protected void gvContact_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            //gvContact.PageIndex = e.NewPageIndex;
            //this.FillGridView();
            //lblCount.Text = "Displaying Page" + (gvContact.PageIndex + 1).ToString() + " of " + gvContact.PageCount.ToString();
        }

        public void Text()
        {
            int t1, t2, t3, t4, t5, t6;
            bool b1 = int.TryParse(txtFault.Text, out t1);
            bool b2 = int.TryParse(txtModification.Text, out t2);
            bool b3 = int.TryParse(txtDataCorrection.Text, out t3);
            bool b4 = int.TryParse(txtEnhancement.Text, out t4);
            bool b5 = int.TryParse(txtOptimization.Text, out t5);
            bool b6 = int.TryParse(txtOthers.Text, out t6);

            if(b1 || b2 || b3 || b4 || b5 || b6)
            {
                txtTotal.Text = (t1 + t2 + t3 + t4 + t5 + t6).ToString();
            }
            else
            {
                txtTotal.Text = "Wrong Text Inpus";
            }
        }

        protected void txtFault_TextChanged(object sender, EventArgs e)
        {
            Text();
        }

        protected void txtModification_TextChanged(object sender, EventArgs e)
        {
            Text();
        }

        protected void txtDataCorrection_TextChanged(object sender, EventArgs e)
        {
            Text();
        }

        protected void txtEnhancement_TextChanged(object sender, EventArgs e)
        {
            Text();
        }

        protected void txtOptimization_TextChanged(object sender, EventArgs e)
        {
            Text();
        }

        protected void txtOthers_TextChanged(object sender, EventArgs e)
        {
            Text();
        }

        public void Text2()
        {
            int t1, t2, t3;
            bool b1 = int.TryParse(txtCritical.Text, out t1);
            bool b2 = int.TryParse(txtModerate.Text, out t2);
            bool b3 = int.TryParse(txtMinor.Text, out t3);

            if (b1 || b2 || b3 )
            {
                txtTotalP.Text = (t1 + t2 + t3 ).ToString();
            }
            else
            {
                txtTotalP.Text = "Wrong Text Inpus";
            }
        }

        protected void txtCritical_TextChanged(object sender, EventArgs e)
        {
            Text2();
        }

        protected void txtModerate_TextChanged(object sender, EventArgs e)
        {
            Text2();
        }

        protected void txtMinor_TextChanged(object sender, EventArgs e)
        {
            Text2();
        }

        
    }
    }
