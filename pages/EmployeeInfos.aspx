<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeInfos.aspx.cs" Inherits="VacationRequest.pages.EmployeeInfos"  UICulture="en-US" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 40px;
            width: 202px;
        }
        .style3
        {
            height: 40px;
            width: 421px;
        }
        .style4
        {
            width: 421px;
            height: 46px;
        }
        .style5
        {
            height: 46px;
            width: 202px;
        }
        .style6
        {
            height: 36px;
        }
        .style7
        {
            height: 47px;
            width: 248px;
        }
        .style10
        {
            height: 47px;
            width: 266px;
        }
        .style11
        {
            width: 266px;
        }
        .style12
        {
            width: 248px;
        }
        .style14
        {
            height: 62px;
        }
                
    </style>
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#3399FF" 
                 
            
            style="top: 28px; left: 218px; position: absolute; height: 714px; width: 991px">
        <ul>
  <li><a class="active"  href="EmployeeInfos.aspx"><strong>REQUEST FORM</strong></a></li>                  
  <li><a href="employeeform.aspx"><strong>SUBMITED FORM</strong></a></li>
   <li><a href="supervisorcontrol.aspx"><strong>  <asp:Label ID="titresup" runat="server" Text="SUPERVISOR"></asp:Label></strong></a></li>
  <li><a href="Hrcontrol.aspx"><strong><asp:Label ID="titreHr" runat="server"
      Text="H/R ACCOUNTS"></asp:Label></strong></a></li>
  <li><a href="AdminControl.aspx"><strong><asp:Label ID="titreAdmin" runat="server"
      Text="ADMIN SETUP"></asp:Label></strong></a></li>
 
 </ul>


        <table style="position: relative; top: 12px; left: 37px; width: 821px; height: 132px" 
                bgcolor="White" border="2px">
 
     
            
             
  
    <tr>
    <td class="style3">
       <asp:Label ID="empname" runat="server" 
            style="top: 54px; left: 259px; height: 28px; width: 393px; right: 625px;" 
            Text="EMPLOYEE NAME:" Font-Bold="True" ForeColor="Blue"></asp:Label>
   
        <asp:Label ID="name" runat="server" Font-Bold="True" Font-Size="Large" 
            Text="Label"></asp:Label>
   
        </td>
     
    <td class="style1">
         <asp:Label ID="todaydate" runat="server" 
            style="top: 53px; left: 698px;  height: 32px; width: 351px" 
            Text="DATE:" Font-Bold="True" ForeColor="Blue"></asp:Label>
         <asp:Label ID="date" runat="server" Font-Bold="True" Font-Size="Large" 
             Text="Label"></asp:Label>
        </td>
       
    </tr>
   <tr>
   <td class="style4">
       <asp:Label ID="dept" runat="server" 
            style="top: 105px; left: 263px;  height: 32px; width: 282px" 
            Text="DEPT/SECTION:" Font-Bold="True" ForeColor="Blue"></asp:Label>
    
       <asp:Label ID="section" runat="server" Font-Bold="True" Font-Size="Large" 
           Text="Label"></asp:Label>
    
    </td>
   <td class="style5">
       <asp:Label ID="puchId" runat="server" Font-Bold="True" 
           style="top: 46px; left: 434px;  height: 31px; width: 356px; margin-top: 14px;" 
           Text="PUNCH CARD No:" ForeColor="Blue"></asp:Label>
       <asp:Label ID="card" runat="server" Font-Bold="True" Font-Size="Large" 
           Text="Label"></asp:Label>
       </td>
   </tr>
    </table>
            <table bgcolor="White" border="2px" 
                
                style="position: relative; top: 56px; left: 42px; height: 305px; width: 819px;">
                <tr>
                    <td class="style6" colspan="2" valign="middle" align="center">
                        <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="Blue" 
                            Text="LEAVE REQUESTED AS FOLLOWS"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="Blue" 
                            Text="FROM(DATE)"></asp:Label>
                    </td>
                    <td class="style10">
                  
                        <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="Blue" 
                            Text="TO (Date)"></asp:Label>
                            </td>
                  
                </tr>
                <tr>
                    <td class="style12">
                        <asp:Calendar ID="Calendar1" runat="server" Height="250px" Width="330px" 
                            BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" 
                            Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" 
                            NextPrevFormat="ShortMonth">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                                Height="8pt" />
                            <DayStyle BackColor="#CCCCCC" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
                                Font-Size="12pt" ForeColor="White" Height="12pt" />
                            <TodayDayStyle BackColor="#999999" ForeColor="White" />
                        </asp:Calendar>
                    </td>
                    <td class="style11">
                        <asp:Calendar ID="Calendar2" runat="server" Width="330px" BackColor="White" 
                            BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" 
                            Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                                Height="8pt" />
                            <DayStyle BackColor="#CCCCCC" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
                                Font-Size="12pt" ForeColor="White" Height="12pt" />
                            <TodayDayStyle BackColor="#999999" ForeColor="White" />
                        </asp:Calendar>
                    </td>

                    
                </tr>
               <tr><td>
                   <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                       Font-Bold="True" Font-Size="Medium" oncheckedchanged="CheckBox1_CheckedChanged" 
                       Text="Hours" />
                   <asp:TextBox ID="daysh" runat="server" TextMode="Number" Visible="False"></asp:TextBox>
                   </td></tr>
              <tr>
              <td   valign="bottom" align="right" class="style14">
                  <asp:Button ID="Button1" runat="server" Text="SUMBIT" Height="31px" 
                      Width="140px" onclick="Button1_Click" /></td>
                      <td valign="bottom" align="left">

                          <asp:Button ID="disconet" runat="server" onclick="disconet_Click" 
                              Text="DISCONNECT" Height="31px" 
                      Width="140px" />

                      </td>
              </tr>
              <tr>
              <td colspan="2" valign="middle" align="center">
                  <asp:Label ID="info" runat="server" Text="Label" Font-Bold="True" 
                      Font-Size="X-Large" ForeColor="Red" Visible="False"></asp:Label></td> 
              </tr>
            </table>
           
         </asp:Panel>
    
           
        
       
    
    </form>
</body>
</html>
