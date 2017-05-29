using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace VacationRequest.Manage
{
    public class Gestion
    {
        /**
         *  This class is used to control the database and initialise componements we are using in this application 
         * */
        private String connection;
        /*
         * Connection to database
         * 
         * */
        public Gestion()
        {
            connection = "data source=localhost\\sqlexpress;database=holidaycontrol; ";
            connection += "" + "integrated security=SSPI";
        }
        /*
         *  check if the request are returning a result 
         * */
        public String exist(String requete)
        {
              using (SqlConnection con = new SqlConnection(connection))
            {

                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
               
                SqlDataReader res = cmd.ExecuteReader();
                
                if (res.IsDBNull(0))
                    return "nofound";
                else
                    return "ok";
                }
        }
        /*
         * *
         *   Initialise the class Supervision with the data form the database
         * */
        public List<Supervision> updateSupervision(String requete)
        {

            using (SqlConnection con = new SqlConnection(connection))
            {

             
                
                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
                SqlDataReader res = cmd.ExecuteReader();

                List<Supervision> maliste = new List<Supervision>();

                while (res.Read())
                {
                    Supervision supervision = new Supervision();
                    for (int i = 0; i < 3; i++)
                    {
                        if (i == 0)
                            supervision.idEmploye = res.GetValue(i).ToString();
                        else if (i == 1)
                            supervision.idvacation = res.GetValue(i).ToString();
                        else
                            supervision.datefrom = Convert.ToDateTime(res.GetValue(i).ToString()).ToString("yyyy-MM-dd");

                    }
                    maliste.Add(supervision);
                }
                return maliste;
            }

        }
        /**
         *  Update a table from the database by taking a name of a column and the value of the column
         * */
        public void updateTableVacation(String column,String value,String idvac)
        {
            String requete = "Update Vacation_information set ";
           
            
                requete +=column+"= '" +value + "' where idvacation='" + idvac + "'";
                insertToDataBase(requete);
            
         
        }
        /**
         * 
         *   Add to a listbox from the database
         * */
        public void updateOneColonneListBox(String requete, ListBox list)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {


                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
                List<String> maliste = new List<String>();
                SqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    maliste.Add(res.GetValue(0).ToString());
                }
                list.DataSource = maliste;
                list.DataBind();
            }
        }
        /**
         *  samething juste here we concatenate many string 
         * */
        public void updateListbox(String requete, ListBox list,int nb)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {

                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
                List<String> maliste = new List<String>();
                SqlDataReader res = cmd.ExecuteReader();

                String resultat="";

                while (res.Read())
                {
                    for (int i = 0; i < nb; i++)
                    {
                        if (i == 0)
                            resultat = res.GetValue(i).ToString();
                        else
                            resultat +="  "+ res.GetValue(i).ToString();
                           
                    }
                    maliste.Add(resultat);
                }
                list.DataSource = maliste;
                list.DataBind();
           }
        }
        /*
         * 
         * Use to bind the gridview who is used in the page settingsUseright.aspx
         * */
        public void bindGridView(String requete,List<Employee> maliste, int nb)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {

              
                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
                
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    Employee employee = new Employee();
                    if (nb == 3)
                    {
                        employee.status = "EMPLOYEE";
                    }
                    for (int i = 0; i < nb; i++)
                    {

                        if (i == 0)
                        {
                            employee.position = Convert.ToInt32(res.GetValue(i).ToString());
                            String requetSupervisor = "select distinct  DeptName FROM SupervisorControl,Department where ";
                            requetSupervisor += "idDept=DMMDeptID and  idManager='";
             
                            requetSupervisor += employee.position + "'";
                            employee.approved =null;
                            int j = 0;
                            foreach (String dept in getvalues(requetSupervisor, 1))
                            {
                                if (j == 0)
                                    employee.approved = dept;
                                else 
                                employee.approved += ", " + dept+" ";
                                j++;
                            }
                        }
                        else if (i == 1)
                            employee.employe_name = res.GetValue(i).ToString();
                        else if (i == 2)
                            employee.employe_lastname = res.GetValue(i).ToString();
                        else if (i == 3)
                        {
                            if (res.GetValue(i).ToString().Equals("sup"))
                                employee.status = "SUPERVISOR";
                            else if (res.GetValue(i).ToString().Equals("ad"))
                                employee.status = "ADMIN";
                            else if (res.GetValue(i).ToString().Equals("hr"))
                                employee.status = "H R";
                            else
                                employee.status = "EMPLOYEE";

                        }
                       
                    }
                    maliste.Add(employee);
                }
               
            }

        }
        /***
         * 
         * bind all other gridview in this application except the gridview in settinguser
         * */
        public void  bingGridVEmp(String requete,String secondrequet, GridView grid,int nb)
        {
          
            using (SqlConnection con = new SqlConnection(connection))
            {

                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
                List<Employee> maliste = new List<Employee>();
                SqlDataReader res = cmd.ExecuteReader();

                int position = 0;

                while (res.Read())
                {
                    Employee employee = new Employee();
                  
                    for (int i = 0; i < nb; i++)
                    {
                      
                      
                   
                       
                        if (i == 0)
                            employee.employe_name = res.GetValue(i).ToString();
                        else if (i == 1)
                            employee.employe_name +="  "+res.GetValue(i).ToString();
                        else if (i == 2)
                            employee.from_date = Convert.ToDateTime(res.GetValue(i).ToString()).ToString("yyyy-MM-dd");
                        else if (i == 3)
                            employee.to_date =Convert.ToDateTime(res.GetValue(i).ToString()).ToString("yyyy-MM-dd");
                        else if (i == 4)
                        {
                            employee.date =Convert.ToDateTime( res.GetValue(i).ToString()).ToString("yyyy-MM-dd");
                            
                        }
                        else if (i == 5)
                        {
                            
                            if (res.GetValue(i).ToString().Equals("s"))
                            {
                                employee.choix = "IN PROCESS";
                                employee.decision = false;
                            }
                            else if (res.GetValue(i).ToString().Equals("a"))
                            {
                                employee.choix = "ACCEPTED";
                                employee.decision = true;
                            }
                            else if (res.GetValue(i).ToString().Equals("r"))
                            {
                                employee.choix = "REJECTED";
                                employee.decision = false;
                            }
                           
                        }
                        else if (i == 6)
                        {
                            employee.departement = res.GetValue(i).ToString();
                          
                        }
                        else if (i == 7)
                        {
                            employee.idvacation = res.GetValue(i).ToString();
                        }
                        else if (i == 8)
                        {
                            employee.days = res.GetValue(i).ToString();
                        }

                       
                      
                      
                    }
                    employee.position = position;
                 maliste.Add(employee);
                 
                 position++;
                }
               
                con.Close();
                res.Close();
                SqlCommand secondCmd = new SqlCommand(secondrequet, con);
                con.Open();
                res = secondCmd.ExecuteReader();
                position = 0;
                while (res.Read())
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            foreach (Employee emp in maliste)
                            {
                                if(emp.position==position)
                                emp.approved = res.GetValue(i).ToString();
                            }
                        }
                        else
                        {
                            foreach (Employee emp in maliste)
                            {
                                if(emp.position==position)
                                emp.approved += " " + res.GetValue(i).ToString();
                            }
                        }
                       


                         
                    }
                    position++;
                }
                
                grid.DataSource = maliste;
               grid.DataBind();
            }

            
        }
        /* connection control using the database*/
        public String verifconnection(String punchCardId, String password,String requete)
        {
            String resultat = "";

            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {

                    if (res["PunchCardID"].ToString().Equals(punchCardId))

                        resultat = "okl";
                  

                    if (res["Password"].ToString().Equals(password))
                        resultat += "okp";
                   
                     
                    if (resultat.Equals("oklokp") || resultat.Equals("okl") || resultat.Equals("okp"))
                        return resultat;
                  
                }

                return resultat;
            }
        }
       /* a request that return one row from the database*/
        public String recupererValeurString(String requete)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
               
                return cmd.ExecuteScalar().ToString();
            }

        }
       /* get many row from the data base with the parameter nb that specify how many row we want*/
        public List<string> getvalues(String requete, int nb)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
                List<String> maliste = new List<String>();
                SqlDataReader res = cmd.ExecuteReader();
           
                while (res.Read())
                {


                    for (int i = 0; i < nb; i++)
                    {
                        maliste.Add(res.GetValue(i).ToString());
                    }



                }
                return maliste;
            }
        }
        /*Insert into the database */
        public void insertToDataBase(String requete)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand(requete, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}