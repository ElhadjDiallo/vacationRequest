using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationRequest.Manage;

namespace VacationRequest.pages
{
    public partial class AdminControl : System.Web.UI.Page
    {
        private String idEmp;
        private String punch;
        private String iddept;
        private String requete;
        private String secondrequete;
        private static String idvac,datesubmit,date_from,date_to,lastname,name_approved,daysH;
        private static CheckBox box;
       
        protected void Page_Load(object sender, EventArgs e)
        {
          
                idEmp = Application.Get("adminstatus").ToString();

                if (idEmp.Equals("ad"))
          
                {
                    if (!IsPostBack)
                    {
                        Gestion gestion = new Gestion();
                        String userId = Application.Get("userId").ToString();
                        punch = Application.Get("punch").ToString();
                        requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
                        requete += " FROM [Vacation_information],User_Information,Department where  ";
                        requete += " vuserid=dmmUserID and UserDeptId=DMMDeptID ORDER BY fromdate DESC";

                        secondrequete = "SELECT userFName,userSName  FROM [Vacation_information],User_Information where";
                        secondrequete += " dmmUserID=vsupervisor  ORDER BY fromdate DESC";

                        gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);
                        GridView1.Columns[9].Visible = false;
                        bouton.Visible = true;
                    }
                }
                else
                {
                    bouton.Visible = false;
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
       
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            GridView1.Columns[8].Visible = false;
            GridView1.Columns[7].Visible = false;
            approved.Visible = true;
            Gestion gestion = new Gestion();
            requete = "select userFName,userSName  from Department,User_Information where deptmanger=dmmUserID";
            gestion.updateListbox(requete, listeApproved, 2);
            listeApproved.Visible = true;
           
            GridView1.Columns[9].Visible = true;
            GridView1.EditIndex =e.NewEditIndex;

            requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
            requete += " FROM [Vacation_information],User_Information,Department where  ";
            requete += " vuserid=dmmUserID and UserDeptId=DMMDeptID ORDER BY fromdate DESC";

            secondrequete = "SELECT userFName,userSName  FROM [Vacation_information],User_Information where";
            secondrequete += " dmmUserID=vsupervisor  ORDER BY fromdate DESC";
            gestion.bingGridVEmp(requete, secondrequete, GridView1, 8);
           
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView1.Columns[8].Visible = false;

            GridView1.Columns[9].Visible = true;
            box = ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("updatechoice"));
            idvac = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label9")).Text;
            datesubmit = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            date_from = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
            date_to = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3")).Text;
            daysH = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4")).Text;

            name_approved = null;
       
            if (listeApproved.SelectedIndex != -1)
            {
                name_approved = listeApproved.SelectedValue;
                String[] words;
                words=name_approved.Split(' ');
                int i = 0;
                foreach (String name in words)
                {
                    if (i == 0)
                    {
                        name_approved = name;
                    }
                    else
                        lastname = name;
                    i++;
                }
            }



          

            ModalPopupExtender1.TargetControlID = "close";
            ModalPopupExtender1.Show();
                
        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            Gestion gestion = new Gestion();
            String userId = Application.Get("userId").ToString();
            punch = Application.Get("punch").ToString();
            requete = "SELECT userFName,userSName, [fromdate],[todate],[dateSubmit],[situation],DeptName,idvacation,nbdaysh";
            requete += " FROM [Vacation_information],User_Information,Department where  ";
            requete += " vuserid=dmmUserID and UserDeptId=DMMDeptID ORDER BY fromdate DESC";

            secondrequete = "SELECT userFName,userSName  FROM [Vacation_information],User_Information where";
            secondrequete += " dmmUserID=vsupervisor  ORDER BY fromdate DESC";

            gestion.bingGridVEmp(requete, secondrequete, GridView1, 9);
            GridView1.Columns[9].Visible = false;
            bouton.Visible = true;
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

                  gestion.updateTableVacation("fromdate",date_from, idvac);   
                }
               
         
                if (datesubmit.Length != 0)
                {
                    gestion.updateTableVacation("dateSubmit",datesubmit, idvac);
                }
                if (date_to.Length != 0)
                {
                    gestion.updateTableVacation("todate", date_to, idvac);
                }
                if (daysH.Length != 0)
                {
                    gestion.updateTableVacation("nbdaysh",daysH, idvac);
                }
                if (listeApproved.SelectedIndex!=-1)
                {
                    requete = "select dmmUserID  from User_Information where userFName='" + name_approved + "'";
                    requete += " and userSName='" + lastname + "'";
                  
                    String idsupervisor = gestion.recupererValeurString(requete);
                    requete = "SELECT [vuserid] FROM [Vacation_information] where idvacation='" + idvac + "'";
                    String iduser = gestion.recupererValeurString(requete);
                    requete="Update Vacation_information set vsupervisor='"+idsupervisor+"' where vuserid='"+iduser+"'";
                    gestion.insertToDataBase(requete);
                    requete="Update SupervisorControl set idManager='"+idsupervisor+"' where idvacation in";
                    requete += "  ( select idvacation from Vacation_information where vuserid='" + iduser + "')";
                    gestion.insertToDataBase(requete);
                     
                }
               

                if (box.Checked)
                {
                   
                    requete = "Update Vacation_information set situation='a' where idvacation='" + idvac + "'";
                    gestion.insertToDataBase(requete);
                 
                }
                else
                {
                   
                    requete = "Update Vacation_information set situation='r' where idvacation='" + idvac + "'";
                    gestion.insertToDataBase(requete);

                }
            }
         Response.Redirect("~/pages/AdminControl.aspx");

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {


            Response.Redirect("~/pages/AdminControl.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/settingsUsersrights.aspx");
        }
    }
}