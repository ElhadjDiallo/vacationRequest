using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VacationRequest.Manage;

namespace VacationRequest.Home
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private String requeteEmid,requeteInfoEmp;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (password.Text.Length != 0 && punchid.Text.Length != 0)
            {
                Gestion gestion = new Gestion();
              String  requete = "select  [PunchCardID] ,[Password] FROM [holidaycontrol].[dbo].[User]";

                String res = gestion.verifconnection(punchid.Text, password.Text, requete);
             
                
                if (res.Equals("no"))
                {

                    Label1.Text = "Error on login and password";
                    Label1.Visible = true;

                }
                else if (res.Equals("okl"))
                {
                    Label1.Text = "Error password";
                    Label1.Visible = true;

                }
                else if (res.Equals("okp"))
                {
                    Label1.Text = "Error on login";
                    Label1.Visible = true;
                }
                else if (res.Equals("oklokp"))
                {
                    requeteEmid = "select dmmUserID from User_Information where UserPayrollNo='" + punchid.Text + "'";
                    String retour=gestion.recupererValeurString(requeteEmid);

                  
                        requeteInfoEmp = "SELECT [Efunction] FROM Employee_status where idEmploye='" + retour + "'";
                        Response.Write(requeteInfoEmp);
                        List<String> listeDroits = new List<string>();
                       
                        listeDroits = gestion.getvalues(requeteInfoEmp, 1);
                        Application.Set("adminstatus","");
                        Application.Set("hrstatus","");
                        Application.Set("supstatus", "");
                         Application.Set("empstatus","");
                        foreach (String droit in listeDroits)
                        {
                           
                            if(droit.Equals("ad"))
                            {

                                Application.Set("adminstatus", droit);
                            }
                            else  if (droit.Equals("hr"))
                            {
                                Application.Set("hrstatus", droit);
                            }
                          
                            else  if(droit.Equals("sup"))
                            {
                                Application.Set("supstatus", droit);
                            }

                            Response.Write(droit);
                        }
                        Application.Set("punch", punchid.Text);
                        requete = "select dmmUserID from User_Information where UserPayrollNo='" + punchid.Text + "'";
                        Gestion manage = new Gestion();
                        String userId = manage.recupererValeurString(requete);
                        Application.Set("userId", userId);
                       Response.Redirect("~/pages/EmployeeInfos.aspx");
                       
                  
                    
                  
                }
                else
                {
                    Label1.Text = "Error on login and password";
                    Label1.Visible = true;
                }

            }
            else
            {
                Label1.Text = "You have to specify Login and password please ";
                Label1.Visible = true;
              
            }
        }

     
    }
}