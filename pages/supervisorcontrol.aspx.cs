using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationRequest.Manage;

namespace VacationRequest.pages
{
    public partial class supervisorcontrol : System.Web.UI.Page
    {
        private String idEmp,IdSemp;
        private String punch;
        private String iddept;
        private String requete;
        private String secondrequete;
        private static String idvac;
        private static CheckBox box;
        protected void Page_Load(object sender, EventArgs e)
        {
               idEmp = Application.Get("supstatus").ToString();
                IdSemp = Application.Get("adminstatus").ToString();

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
                    titreHr.Visible = false;
                }
                if (Application.Get("supstatus").ToString().Equals("sup"))
                {
                    titresup.Visible = true;
                }
                else
                {
                    titresup.Visible = false;
                }
               
                if (idEmp.Equals("sup") || IdSemp.Equals("ad"))
                {
                    if (!IsPostBack)
                    {
                        info.Visible = false;
                        Gestion gestion = new Gestion();
                        String userId = Application.Get("userId").ToString();
                        punch = Application.Get("punch").ToString();
                        requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
                        requete += " FROM [Vacation_information],User_Information,Department where vuserid ";
                        requete += "IN (select   idEmploye from SupervisorControl where idManager='" + userId + "' and idEmploye!='0')";
                        requete += "   and vuserid=dmmUserID and UserDeptId=DMMDeptID  ORDER BY fromdate DESC";

                        secondrequete = "SELECT userFName,userSName FROM [Vacation_information],User_Information where vuserid ";
                        secondrequete += "IN (select   idEmploye from SupervisorControl where idManager='" + userId + "')";
                        secondrequete += " and vsupervisor=dmmUserID  ORDER BY fromdate DESC";

                        gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);
                        GridView1.Columns[9].Visible = false;
                    }
                }
                else
                {
                   // info.Visible = true;
                    Response.Redirect("~/pages/EmployeeInfos.aspx");
                }
            
           
        }

      

      

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
             box= ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("updatechoice"));
            idvac = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label9")).Text;

         
            
                ModalPopupExtender1.TargetControlID = "close";
                ModalPopupExtender1.Show();
                
         

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label situation = (Label)e.Row.FindControl("Label8");

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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.Columns[8].Visible = false;

            GridView1.Columns[9].Visible = true;
            GridView1.EditIndex = e.NewEditIndex;
            Gestion gestion = new Gestion();
            String userId = Application.Get("userId").ToString();
            requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
            requete += " FROM [Vacation_information],User_Information,Department where vuserid ";
            requete += "IN (select   idEmploye from SupervisorControl where idManager='" + userId + "' and  idEmploye!='0')";
            requete += "   and vuserid=dmmUserID and UserDeptId=DMMDeptID  ORDER BY fromdate DESC";

            secondrequete = "SELECT userFName,userSName FROM [Vacation_information],User_Information where vuserid ";
            secondrequete += "IN (select   idEmploye from SupervisorControl where idManager='" + userId + "')";
            secondrequete += " and vsupervisor=dmmUserID  ORDER BY fromdate DESC";

            gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);
          
        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            info.Visible = false;
            Gestion gestion = new Gestion();
            String userId = Application.Get("userId").ToString();
            punch = Application.Get("punch").ToString();
            requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
            requete += " FROM [Vacation_information],User_Information,Department where vuserid ";
            requete += "IN (select   idEmploye from SupervisorControl where idManager='" + userId + "' and idEmploye!='0')";
            requete += "   and vuserid=dmmUserID and UserDeptId=DMMDeptID  ORDER BY fromdate DESC";

            secondrequete = "SELECT userFName,userSName FROM [Vacation_information],User_Information where vuserid ";
            secondrequete += "IN (select   idEmploye from SupervisorControl where idManager='" + userId + "')";
            secondrequete += " and vsupervisor=dmmUserID  ORDER BY fromdate DESC";

            gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);
            GridView1.Columns[9].Visible = false;
        }



        protected void close_Click(object sender, EventArgs e)
        {

        }
        protected void tempb_Click(object sender, EventArgs e)
        {
              String userId = Application.Get("userId").ToString();
            if (accept.Checked)
            {
                if (box.Checked)
                {
                    Gestion gestion = new Gestion();
                    requete = "Update Vacation_information set situation='a' where idvacation='" + idvac + "'";
                    gestion.insertToDataBase(requete);
                    requete = "Update Vacation_information set vsupervisor='" + userId + "' where idvacation='" + idvac + "'";
                    gestion.insertToDataBase(requete);  
                }
                else
                {
                    Gestion gestion = new Gestion();
                    requete = "Update Vacation_information set situation='r' where idvacation='" + idvac + "'";
                    gestion.insertToDataBase(requete);
                    requete = "Update Vacation_information set vsupervisor='" + userId + "' where idvacation='" + idvac + "'";
                    gestion.insertToDataBase(requete);
                }
            }
            Response.Redirect("~/pages/supervisorcontrol.aspx");
          
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Response.Redirect("~/pages/supervisorcontrol.aspx");
        }
      
    }
}