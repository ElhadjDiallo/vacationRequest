<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminControl.aspx.cs" Inherits="VacationRequest.pages.AdminControl" UICulture="en-US" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
       <asp:Panel ID="Panel1" runat="server" BackColor="SkyBlue" 
        
        
           
           style="top: 15px; left: 10px; position: absolute; height: 681px; width: 1411px; margin-right: 41px;">
  
         <table style="position: relative; top: 0px; left: 61px; width: 1154px; height: 321px">
    <tr>
    <td>  <ul>
  <li><a href="EmployeeInfos.aspx"><strong>REQUEST FORM</strong></a></li>                  
  <li><a  href="employeeform.aspx"><strong>SUBMITED  FORM</strong></a></li>
   <li><a  href="supervisorcontrol.aspx"><strong>SUPERVISOR </strong></a></li>
  <li><a href="Hrcontrol.aspx"><strong>H/R ACCOUNTS</strong></a></li>
  <li><a class="active" href="AdminControl.aspx"><strong>ADMIN SETUP</strong></a></li>
  <li><a href="../Home/Authentification.aspx"><strong>DISCONNECT</strong></a></li>
   </ul>
     </td>
    </tr>
    <tr>
    <td rowspan="2">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="4" 
            ForeColor="#333333" onpageindexchanging="GridView1_PageIndexChanging1" 
            onrowdatabound="GridView1_RowDataBound" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" 
            onrowcancelingedit="GridView1_RowCancelingEdit">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# bind("idvacation") %>' Font-Bold="True" Font-Size="Medium" ></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Font-Bold="True" Font-Size="Medium" />
                </asp:TemplateField>
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
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text='<%# bind("date") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Font-Bold="True" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FROM (DATE)">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text='<%# bind("from_date") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle Font-Bold="True" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TO (DATE)">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="Date"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" 
                            Text='<%# bind("to_date") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Font-Bold="True" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No OF HOURS/DAYS">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" TextMode="Number"></asp:TextBox>
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
                <asp:TemplateField HeaderText="UPDATE">
                    <EditItemTemplate>
                        <asp:CheckBox ID="updatechoice" runat="server" Font-Bold="True" 
                            Font-Size="Medium" />
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="Lime" 
                            Text="ACCEPT/"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="Red" 
                            Text="REJECT"></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# bind("decision") %>' 
                            Enabled="False" Font-Bold="True" Font-Size="Medium" />
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="Lime" 
                            Text="ACCEPT/"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="Red" 
                            Text="REJECT"></asp:Label>
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
        <td valign="middle" align="center" bgcolor="Blue">
            <asp:Label ID="approved" runat="server" BackColor="Blue" Font-Bold="True" 
                Font-Size="Medium" ForeColor="White" 
                style="top: 65px; left: 1201px; height: 47px; width: 144px" 
                Text="Approved BY" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
        <asp:ListBox ID="listeApproved" runat="server" Height="314px" Visible="False" 
            Width="148px" Font-Bold="True" Font-Size="Medium"></asp:ListBox>
        </td>
    </tr>
    <tr>
    <td>
        <asp:Button ID="bouton" runat="server" Height="32px" 
            Text="SETUP USERS RIGHTS" Width="224px" onclick="Button1_Click" />
        </td>
    </tr>
   
    </table>
      </asp:Panel>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

         <asp:panel ID="Panel2" runat="server"  BackColor="#FFFF99" Width="322px" 
            Height="148px" >
      <table style="height: 149px; width: 327px">
      <tr>
                <td align="center" valign="middle" class="style10" colspan="2"> 
                   <asp:Label ID="Label4" runat="server" 
                        Text="Are you sure?" Font-Bold="True" Font-Names="Arial Black" 
                        Font-Size="Medium"></asp:Label> 
 
                </td>
                    
       </tr>
                <tr>
                <td  valign="middle" align="right">                   
                   <span>   <asp:RadioButton ID="accept" runat="server" Text="Yes" GroupName="boutongroup" TextAlign="Left"/></span>
                     </td>
                 <td>
                
                <asp:RadioButton ID="refuse" runat="server" 
                        Text="No" GroupName="boutongroup"
                   TextAlign="Right" style="top: 300px" />
                   </td>
                 
               
                </tr>
             
                    <tr>
                    
                <td align="center" valign="middle">
                        <asp:Button ID="tempb" runat="server" 
                        Text="Update" onclick="tempb_Click" style="height: 29px"  /> 
                              </td>
                        <td align="center" valign="middle">
                         <asp:Button ID="close" runat="server" onclick="close_Click" Text="Close" 
                                Height="29px" Width="80px" 
                            />
                 
                        </td>
                </tr>
           
      </table>
      </asp:panel>
   
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    PopupControlID="Panel2" Drag="True" DropShadow="True"
        TargetControlID="tempb"
        CancelControlID="close">
    </asp:ModalPopupExtender>
    </form>
</body>
</html>
