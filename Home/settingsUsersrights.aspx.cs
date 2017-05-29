using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationRequest.Manage;

namespace VacationRequest.Home
{
    public partial class UserRight : System.Web.UI.Page
    {
        private String requete;
        private static CheckBox admin,admin1s, hr,hr1s, sup,sup1s, deptManage,deptManage1s;
        private static String userfname, userlname, userId, deptname,id,deptsup;
        protected void Page_Load(object sender, EventArgs e)
        {
           // idEmp = Application.Get("status").ToString();
         
            if (!IsPostBack)
            {
               userId = Application.Get("userId").ToString();
                requete = "select dmmUserID,userFName,userSName,Efunction from ";
              requete+="  User_Information,Employee_status where idEmploye=dmmUserID";
              Gestion gestion = new Gestion();
              List<Employee> maliste = new List<Employee>();
              gestion.bindGridView(requete, maliste, 4);
                requete="select dmmUserID,userFName,userSName from ";
                requete += "   User_Information where dmmUserID Not  in (select idEmploye from Employee_status)";
                gestion.bindGridView(requete, maliste, 3);
                GridView1.DataSource = maliste;
                GridView1.DataBind();
            
                for(int i=4;i<8;i++)
                GridView1.Columns[i].Visible = false;
                labeldept.Visible = false;
                listdepartement.Visible =false;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            requete = "select dmmUserID,userFName,userSName,Efunction from ";
            requete += "  User_Information,Employee_status where idEmploye=dmmUserID";
            Gestion gestion = new Gestion();
            List<Employee> maliste = new List<Employee>();
            gestion.bindGridView(requete, maliste, 4);
            requete = "select dmmUserID,userFName,userSName from ";
            requete += "   User_Information where dmmUserID Not  in (select idEmploye from Employee_status)";
            gestion.bindGridView(requete, maliste, 3);
            GridView1.DataSource = maliste;
            GridView1.DataBind();

            for (int i = 4; i < 8; i++)
                GridView1.Columns[i].Visible = false;
            labeldept.Visible = false;
            listdepartement.Visible = false;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            requete = "select dmmUserID,userFName,userSName,Efunction from ";
            requete += "  User_Information,Employee_status where idEmploye=dmmUserID";
            Gestion gestion = new Gestion();
            List<Employee> maliste = new List<Employee>();
            gestion.bindGridView(requete, maliste, 4);
            requete = "select dmmUserID,userFName,userSName from ";
            requete += "   User_Information where dmmUserID Not  in (select idEmploye from Employee_status)";
            gestion.bindGridView(requete, maliste, 3);
            GridView1.DataSource = maliste;
            GridView1.DataBind();
            for (int i = 4; i < 8; i++)
                GridView1.Columns[i].Visible = true;
            GridView1.Columns[3].Visible = false;

              requete = "select deptName from Department";

         
            gestion.updateOneColonneListBox(requete, listdepartement);
            labeldept.Visible = true;
            listdepartement.Visible = true;
            id = ((Label)(GridView1.Rows[e.NewEditIndex].FindControl("Label1"))).Text;

            requete = "select count(*) as nb from Employee_status where Efunction='ad' and idEmploye='" + id + "'";
            if (!gestion.recupererValeurString(requete).Equals("0"))
            {
                ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox1")).Checked = true;
              
            }
         
            requete = "select count(*) as nb from Employee_status where Efunction='hr' and idEmploye='" + id + "'";
            if (!gestion.recupererValeurString(requete).Equals("0"))
            {
                ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox2")).Checked = true;
                
                
            }
                requete = "select count(*) as nb from Employee_status where Efunction='sup' and idEmploye='" + id + "'";

                if (!gestion.recupererValeurString(requete).Equals("0"))
                {

                    ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox4")).Checked = true;
            

                }
               
            deptsup=((Label)(GridView1.Rows[e.NewEditIndex].FindControl("Label5"))).Text;
              if(deptsup.Length!=0)
                  ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox5")).Checked = true;

              admin1s = ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox1"));
              hr1s = ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox2"));
              sup1s = ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox4"));
              deptManage1s=((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox5"));
         
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Gestion gestion = new Gestion();
            admin = ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox1"));
            hr=((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox2"));
            sup = ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox4"));
            deptManage = ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox5"));
            userfname = ((Label)(GridView1.Rows[e.RowIndex].FindControl("Label2"))).Text;
            userlname = ((Label)(GridView1.Rows[e.RowIndex].FindControl("Label3"))).Text;
            if (listdepartement.SelectedIndex != -1)
                deptname = listdepartement.SelectedValue;
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
                requete="select count (*) as nb from Employee_status where idEmploye='" + userId + "'";
                String verif = gestion.recupererValeurString(requete);
               
                
                if (verif.Equals("0"))
                {
                    requete = "INSERT INTO [dbo].[Employee_status]([idEmploye]) VALUES ";
                    requete += "('" + userId + "')";
                    gestion.insertToDataBase(requete);
                }
                if (admin.Checked != admin1s.Checked)
                {
                    if (admin.Checked)
                    {

                        requete = "INSERT INTO [dbo].[Employee_status] ";
                        requete += " ([Efunction] ,[idEmploye]) VALUES ";
                        requete += "('ad','" + id + "')";

                        gestion.insertToDataBase(requete);
                    }
                    else
                    {
                        requete = " delete from Employee_status where Efunction='ad' and idEmploye='" + id + "'";
                        gestion.insertToDataBase(requete);
                    }
                }

                if (hr.Checked != hr1s.Checked)
                {
                    if (hr.Checked)
                    {
                        requete = "INSERT INTO [dbo].[Employee_status] ";
                        requete += " ([Efunction] ,[idEmploye]) VALUES ";
                        requete += "('hr','" + id + "')";

                        gestion.insertToDataBase(requete);
                    }
                    else
                    {
                        requete = " delete from Employee_status where Efunction='hr' and idEmploye='" + id + "'";
                        gestion.insertToDataBase(requete);
                    }
                }
                if (sup1s.Checked != sup.Checked)
                {
                    if (sup.Checked)
                    {
                        requete = "INSERT INTO [dbo].[Employee_status] ";
                        requete += " ([Efunction] ,[idEmploye]) VALUES ";
                        requete += "('sup','" + id + "')";

                        gestion.insertToDataBase(requete);
                    }
                    else
                    {
                        requete = " delete from Employee_status where Efunction='sup' and idEmploye='" + id + "'";
                        gestion.insertToDataBase(requete);
                    }
                }
                if (deptManage1s.Checked != deptManage.Checked || listdepartement.SelectedIndex!=-1)
                {
                    if (deptManage.Checked)
                    {
                        requete = "select dmmUserID from User_Information where userFName='" + userfname;
                        requete += " ' and userSName='" + userlname + "'";
                        String idmanager = gestion.recupererValeurString(requete);
                        requete = "select DMMDeptID from Department where DeptName='" + deptname + "'";


                        String idDepartement = gestion.recupererValeurString(requete);
                        requete = "select count(*) as nb from SupervisorControl where idManager='" + idmanager + "'";
                        requete += " and idEmploye='0' and idDept='" + idDepartement + "'";
                        if (gestion.recupererValeurString(requete).Equals("0"))
                        {
                            requete = "INSERT INTO [dbo].[SupervisorControl] ([idEmploye] ,[idManager],[fromdate],[idDept]) ";
                            requete += "VALUES ('0','" + idmanager + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + idDepartement + "')";
                            gestion.insertToDataBase(requete);
                            requete = "select distinct   idEmploye,idvacation,fromdate from SupervisorControl where ";
                            requete += " idEmploye!='0' and idDept='" + idDepartement + "'";
                            List<Supervision> listsupervision = gestion.updateSupervision(requete);
                            foreach (Supervision superv in listsupervision)
                            {
                                requete = "INSERT INTO [dbo].[SupervisorControl]([idEmploye] ";
                                requete += ",[idManager],[fromdate],[idDept] ,[idvacation]) VALUES ";
                                requete += "('" + superv.idEmploye + "','" + idmanager + "','" + superv.datefrom + "','";
                                requete += idDepartement + "','" + superv.idvacation + "')";

                                gestion.insertToDataBase(requete);


                            }
                        }
                        else
                        {
                            Response.Write("ALREADY A MANAGER");
                        }
                    }
                    else
                    {
                        requete = " delete from SupervisorControl where idManager='" + id + "' and idDept=(";
                        requete += "select DMMDeptID from Department where DeptName='" + deptname + "')";
                        gestion.insertToDataBase(requete);
                    }
                }
             
                /*
                if(!admin.Checked && !hr.Checked && !sup.Checked)
                {
                    requete = "Update Employee_status ";
                    requete += " set Efunction='' where idEmploye=(select dmmUserID from User_Information where userFName='" + userfname;
                    requete += " ' and userSName='" + userlname + "')";
                    gestion.insertToDataBase(requete);
                }*/

            }
   Response.Redirect("~/Home/settingsUsersrights.aspx");
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Response.Redirect("~/Home/settingsUsersrights.aspx");
        }
    }
}