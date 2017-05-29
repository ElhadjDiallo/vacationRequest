using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationRequest.Manage;

namespace VacationRequest.pages
{
    public partial class EmployeeInfos : System.Web.UI.Page
    {
        private String requete;
        private List<String> empInfo;
        private static  Employee employe;
        private static string  iddept;
        private static String punch;
        protected void Page_Load(object sender, EventArgs e)
        {
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

            requete = "SELECT [userFName],[userSName],[UserDeptId]";
            requete += " from User_Information where UserPayrollNo='" + punch + "'";
            Gestion gestion = new Gestion();
            employe = new Employee();
            employe.employe_name = "";
            empInfo = gestion.getvalues(requete, 3);
            int i = 0;
          
            foreach (String value in empInfo)
            {

                if (i == 2)
                    iddept = value;
                else
                    employe.employe_name += value + " ";
               
                i++;
            }
            requete = "SELECT [DeptName] FROM [holidaycontrol].[dbo].[Department] where DMMDeptID='" + iddept + "'";
            employe.departement =gestion.recupererValeurString(requete);
             name.Text= employe.employe_name;
            section.Text=employe.departement;
            employe.date=DateTime.Today.ToString("yyyy-MM-dd");
           card.Text = punch;
           date.Text = employe.date;

            
       }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((Calendar1.SelectedDate == DateTime.MinValue || Calendar2.SelectedDate == DateTime.MinValue) && CheckBox1.Checked)
            {
                employe.days = daysh.Text;
               
                employe.from_date = DateTime.Today.ToString("yyyy-MM-dd");
                employe.to_date = DateTime.Today.ToString("yyyy-MM-dd");

                requete = "select dmmUserID from User_Information where UserPayrollNo='" + punch + "'";
                Gestion gestion = new Gestion();
                String userId = gestion.recupererValeurString(requete);
                requete = "select dmmUserID from User_Information where UserDeptId='" + iddept + "'";
                String supervisor = gestion.recupererValeurString(requete);



                requete = "INSERT INTO [dbo].[Vacation_information]([fromdate],";
                requete += "[todate],[dateSubmit],[situation],[nbdaysh] ,[vuserid],[vsupervisor])VALUES('";
                requete += employe.from_date + "','" + employe.to_date + "','";
                requete += employe.date + "','s','"+employe.days+"','" + userId + "','" + supervisor + "')";
                gestion.insertToDataBase(requete);
           
                requete = "INSERT INTO [dbo].[SupervisorControl]  VALUES ('" + userId + "','" + supervisor +"','"+employe.from_date+ "','"+iddept+"')";
              //  gestion.insertToDataBase(requete);





                requete = "select count(*) from SupervisorControl where  idDept='" + iddept + "'";
                String existe = gestion.recupererValeurString(requete);
                requete = "select IDENT_CURRENT('Vacation_information') as id";
                String idvac = gestion.recupererValeurString(requete);

                if (Convert.ToInt32(existe) > 0)
                {


                    requete = "select distinct idManager  from SupervisorControl where idDept='" + iddept + "'";
                    List<String> listeManager = gestion.getvalues(requete, 1);
                    foreach (String idmanage in listeManager)
                    {
                        requete = "INSERT INTO [dbo].[SupervisorControl]  VALUES ";
                        requete += "('" + userId + "','" + idmanage + "','" + employe.from_date + "','" + iddept + "','" + idvac + "')";
                        gestion.insertToDataBase(requete);


                    }

                    info.Text = "REQUEST SUBMITED";
                    info.ForeColor = System.Drawing.Color.Green;
                    info.Visible = true;
                }
                else
                {
                    requete = "INSERT INTO [dbo].[SupervisorControl]  VALUES ";
                    requete += "('" + userId + "','" + supervisor + "','" + employe.from_date + "','" + iddept + "','" + idvac + "')";
                    gestion.insertToDataBase(requete);
                    info.Text = "REQUEST SUBMITED";
                    info.ForeColor = System.Drawing.Color.Green;
                    info.Visible = true;

                }
                  
            }
            else
            {
                if ((Calendar2.SelectedDate - Calendar1.SelectedDate).TotalDays < 0 && CheckBox1.Checked==false)
                {
                    info.Text = "Wrong Range Date please Try Again with valid Dates";
                    info.ForeColor = System.Drawing.Color.Red;
                    info.Visible = true;

                }
                else if ((Calendar2.SelectedDate - Calendar1.SelectedDate).TotalDays > 0 && CheckBox1.Checked == false)
                {
                   
                    employe.from_date = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
                    employe.to_date = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
                    employe.days = (Calendar2.SelectedDate - Calendar1.SelectedDate).TotalDays.ToString();
                    requete = "select dmmUserID from User_Information where UserPayrollNo='" + punch + "'";
                    Gestion gestion = new Gestion();
                    String userId = gestion.recupererValeurString(requete);
                    requete = "select dmmUserID from User_Information where UserDeptId='" + iddept + "'";
                    String supervisor = gestion.recupererValeurString(requete);

                    requete = "INSERT INTO [dbo].[Vacation_information]([fromdate],";
                    requete += "[todate],[dateSubmit],[situation],[nbdaysh] ,[vuserid],[vsupervisor])VALUES('";
                    requete += employe.from_date + "','" + employe.to_date + "','";
                    requete += employe.date + "','s','" + employe.days + "','" + userId + "','" + supervisor + "')";




                    gestion.insertToDataBase(requete);
                    requete = "select count(*) from SupervisorControl where  idDept='" + iddept + "'";
                    String existe = gestion.recupererValeurString(requete);
                    requete = "select IDENT_CURRENT('Vacation_information') as id";
                    String idvac = gestion.recupererValeurString(requete);
                    
                    if (Convert.ToInt32(existe) > 0)
                    {

                    
                       requete = "select distinct idManager  from SupervisorControl where idDept='" + iddept + "'";
                       List<String> listeManager = gestion.getvalues(requete, 1);
                        foreach(String idmanage in listeManager)
                        {
                        requete = "INSERT INTO [dbo].[SupervisorControl]  VALUES ";
                        requete+="('" + userId + "','" +idmanage + "','" + employe.from_date + "','" + iddept + "','"+idvac+"')";
                        gestion.insertToDataBase(requete);


                        }
                      
                        info.Text = "REQUEST SUBMITED";
                        info.ForeColor = System.Drawing.Color.Green;
                        info.Visible = true;
                    }
                    else
                    {
                        requete = "INSERT INTO [dbo].[SupervisorControl]  VALUES ";
                        requete += "('" + userId + "','" + supervisor + "','" + employe.from_date + "','" + iddept + "','" + idvac + "')";
                        gestion.insertToDataBase(requete);
                        info.Text = "REQUEST SUBMITED";
                        info.ForeColor = System.Drawing.Color.Green;
                        info.Visible = true;

                    }
                  
                 //   Response.Redirect("/pages/employeeform.aspx");
                }
                else
                {
                    info.Text = "You have to specify a day or a Date";
                    info.ForeColor = System.Drawing.Color.Red;
                    info.Visible = true;
                }
            }

        }

        protected void disconet_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Authentification.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
               daysh.Visible = true;
              daysh.Text  = "3";
              Calendar1.SelectedDate = Convert.ToDateTime("01/01/0001");
              Calendar2.SelectedDate = Convert.ToDateTime("01/01/0001");
               
            }
            else
            {
                daysh.Visible = false;
               
          
            }
            
        }

      

      
    }
}