using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationRequest.Manage;

namespace VacationRequest.pages
{
    public partial class Hrcontrol : System.Web.UI.Page
    {
        private  String idEmp,idSemp;
        private String requete,secondrequete;
        protected void Page_Load(object sender, EventArgs e)
        {
            idEmp = Application.Get("hrstatus").ToString();
            idSemp = Application.Get("adminstatus").ToString();
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


            
            if (idEmp.Equals("hr") || idSemp.Equals("ad"))
            {
                info.Visible = false;
                requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
                requete += " FROM [Vacation_information],User_Information,Department where situation='a' and";
                requete += " vuserid=dmmUserID and UserDeptId=DMMDeptID ORDER BY fromdate DESC";
                secondrequete = "SELECT userFName,userSName  FROM [Vacation_information],User_Information where";
                secondrequete += " dmmUserID=vsupervisor and situation='a' ORDER BY fromdate DESC";

                Gestion gestion = new Gestion();
                gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);

            }
            else 
            {

                Response.Redirect("~/pages/EmployeeInfos.aspx");
           
            }     
  
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

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            info.Visible = false;
            requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
            requete += " FROM [Vacation_information],User_Information,Department where situation='a' and";
            requete += " vuserid=dmmUserID and UserDeptId=DMMDeptID ORDER BY fromdate DESC";
            secondrequete = "SELECT userFName,userSName  FROM [Vacation_information],User_Information where";
            secondrequete += " dmmUserID=vsupervisor and situation='a' ORDER BY fromdate DESC";

            Gestion gestion = new Gestion();
            gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);
        }
    }
}