using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationRequest.Manage;

namespace VacationRequest.pages
{
    public partial class employeeform : System.Web.UI.Page
    {
        private String requete,secondrequete;
        private String punch;
        private static String iddept, supervisor, userId, idvac, datesubmit, date_from, date_to,nbdays;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Gestion gestion = new Gestion();
                userId = Application.Get("userId").ToString();

                punch = Application.Get("punch").ToString();

                if (Application.Get("adminstatus").ToString().Equals("ad"))
                {
                    titreAdmin.Visible = true;
                }
                else
                {
                    titreAdmin.Visible = false;
                }
                if (Application.Get("hrstatus").ToString().Equals("hr"))
                {
                    titreHr.Visible = true;
                }
                else
                {
                    titreHr.Visible =false;
                }
                if (Application.Get("supstatus").ToString().Equals("sup"))
                {
                    titresup.Visible = true;
                }
                else
                {
                    titresup.Visible = false;
                }

                requete = "SELECT  [UserDeptId]";
                requete += " from User_Information where UserPayrollNo='" + punch + "'";

                iddept = gestion.recupererValeurString(requete);
                requete = "SELECT  distinct vsupervisor FROM Vacation_information,User_Information,Department";
                requete += " where vuserid=dmmUserID and vuserid='" + userId + "' and UserDeptId=DMMDeptID";




                try
                {
                    supervisor = gestion.recupererValeurString(requete);
                    requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
                    requete += " FROM [Vacation_information],User_Information,Department where dmmUserID='" + userId + "'";
                    requete += " and vuserid=dmmUserID and UserDeptId=DMMDeptID ORDER BY fromdate DESC";

                    secondrequete = "SELECT userFName,userSName FROM [Vacation_information],User_Information where vuserid='"+userId+"'";
                    secondrequete += " and vsupervisor=dmmUserID  ORDER BY fromdate DESC";



                    gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);
                    error.Visible = false;

                }
                catch (SystemException ex)
                {
                    error.Visible = true;

                }






            }
 
            

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              Label situation  =(Label)e.Row.FindControl("Label8");

              if (situation.Text.Equals("IN PROCESS"))
              {
                  situation.ForeColor = System.Drawing.Color.Orange;
              }
              else if (situation.Text.Equals("REJECTED"))
              {
                  situation.ForeColor = System.Drawing.Color.Red;
              }
              else if (situation.Text.Equals("ACCEPTED"))
              {
                  situation.ForeColor = System.Drawing.Color.Green;
              }
              else
              {
                  situation.ForeColor = System.Drawing.Color.Black;
              }

            }


        }

      

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            Gestion gestion = new Gestion();
            GridView1.PageIndex = e.NewPageIndex;

            requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
            requete += " FROM [Vacation_information],User_Information,Department where dmmUserID='" + userId + "'";
            requete += " and vuserid=dmmUserID and UserDeptId=DMMDeptID ORDER BY fromdate DESC";

            secondrequete = "SELECT userFName,userSName FROM [Vacation_information],User_Information where vuserid='" + userId + "'";
            secondrequete += " and vsupervisor=dmmUserID  ORDER BY fromdate DESC";



            gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);
            error.Visible = false;
           
        }

    
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Gestion gestion = new Gestion();
            
            requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
            requete += " FROM [Vacation_information],User_Information,Department where dmmUserID='" + userId + "'";
            requete += " and vuserid=dmmUserID and UserDeptId=DMMDeptID ORDER BY fromdate DESC";

            secondrequete = "SELECT userFName,userSName FROM [Vacation_information],User_Information where vuserid='" + userId + "'";
            secondrequete += " and vsupervisor=dmmUserID  ORDER BY fromdate DESC";



            gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);
           
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            idvac = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label9")).Text;
            datesubmit = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            date_from = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
            date_to = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3")).Text;
            nbdays = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4")).Text;
          
            ModalPopupExtender1.TargetControlID = "close";
            ModalPopupExtender1.Show();
       
        }
        protected void close_Click(object sender, EventArgs e)
        {

        }
        protected void tempb_Click(object sender, EventArgs e)
        {
            if (accept.Checked)
            {
                Gestion gestion = new Gestion();


                if (date_from.Length != 0)
                {

                    gestion.updateTableVacation("fromdate", date_from, idvac);
                }


                if (datesubmit.Length != 0)
                {
                    gestion.updateTableVacation("dateSubmit", datesubmit, idvac);
                }
                if (date_to.Length != 0)
                {
                    gestion.updateTableVacation("todate", date_to, idvac);
                }
                if (nbdays.Length != 0 && Convert.ToInt32(nbdays)<24)
                {
                    gestion.updateTableVacation("nbdaysh", nbdays, idvac);
                }
               
            }
                Response.Redirect("~/pages/employeeform.aspx");
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Response.Redirect("~/pages/employeeform.aspx");
        }
    }
}