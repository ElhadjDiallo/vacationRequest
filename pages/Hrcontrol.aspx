<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hrcontrol.aspx.cs" Inherits="VacationRequest.pages.Hrcontrol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:Panel ID="Panel1" runat="server" BackColor="SkyBlue" 
        
        
        style="top: 15px; left: 44px; position: absolute; height: 529px; width: 1346px">
    <table style="position: relative; top: 5px; left: 98px; height: 320px; width: 1152px">
    <tr>
    <td valign="middle" align="center">
        <ul>
  <li><a   href="EmployeeInfos.aspx"><strong>REQUEST FORM</strong></a></li>                  
  <li><a href="employeeform.aspx"><strong>SUBMITED FORM</strong></a></li>
   <li><a href="supervisorcontrol.aspx"><strong>  <asp:Label ID="titresup" runat="server" Text="SUPERVISOR"></asp:Label></strong></a></li>
  <li><a class="active" href="Hrcontrol.aspx"><strong><asp:Label ID="titreHr" runat="server"
      Text="H/R ACCOUNTS"></asp:Label></strong></a></li>
  <li><a href="AdminControl.aspx"><strong><asp:Label ID="titreAdmin" runat="server"
      Text="ADMIN SETUP"></asp:Label></strong></a></li>
        <li><a href="../Home/Authentification.aspx"><strong>DISCONNECT</strong></a></li>
 
 </ul>
    
    </td>
     </tr>
        <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                onpageindexchanging="GridView1_PageIndexChanging1" 
                onrowdatabound="GridView1_RowDataBound" 
                PageSize="13">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="EMPLOYEE NAME">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text='<%# bind("employe_name") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEPT/SECTION">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text='<%# bind("departement") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DATE OF SUBMISSION">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text='<%# bind("date") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FROM (DATE)">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text='<%# bind("from_date") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle Font-Bold="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TO (DATE)">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text='<%# bind("to_date") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="No OF HOURS/DAYS">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text='<%# bind("days") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Approved by">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text='<%# bind("approved") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RESPONSE">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text='<%# bind("choix") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" Wrap="False" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
    </td>
      </tr>
      <tr>
      <td> 
          <asp:Label ID="info" runat="server" Font-Bold="True" Font-Size="X-Large" 
              ForeColor="Red" Text="SORRY YOU NEED TO CONNECT AS HR OR ADMIN" 
              Visible="False"></asp:Label>
          </td>
      </tr>
      </table>
   
    </asp:Panel>
    </form>
</body>
</html>
