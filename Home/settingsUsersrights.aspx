<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="settingsUsersrights.aspx.cs" Inherits="VacationRequest.Home.UserRight" UICulture="en-US" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 53px;
            width: 210px;
        }
        .style2
        {
            width: 266px;
        }
        .style3
        {
            width: 210px;
        }
    </style>
    <link href="../css/menu.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" 
            
            style="top: 91px; left: 158px; position: absolute; height: 633px; width: 1252px" 
            BackColor="SkyBlue">
        
    <table style="margin-right: 0px">
      <tr>
    <td colspan="2" >  <ul>
  <li><a href="../pages/EmployeeInfos.aspx"><strong>REQUEST FORM</strong></a></li>                  
  <li><a  href="../pages/employeeform.aspx"><strong>SUBMITED  FORM</strong></a></li>
   <li><a  href="../pages/supervisorcontrol.aspx"><strong>SUPERVISOR </strong></a></li>
  <li><a href="../pages/Hrcontrol.aspx"><strong>H/R ACCOUNTS</strong></a></li>
  <li><a class="active" href="../pages/AdminControl.aspx"><strong>ADMIN SETUP</strong></a></li>
  <li><a href="Authentification.aspx"><strong>DISCONNECT</strong></a></li>
   </ul>
     </td>
    </tr>
    <tr>
  
        <td class="style1" rowspan="2">
            
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="4" 
                Font-Bold="True" Font-Size="Medium" ForeColor="#333333" 
                onpageindexchanging="GridView1_PageIndexChanging" 
                onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                Width="825px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="id">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# bind("position") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FIRST NAME">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# bind("employe_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LAST NAME">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# bind("employe_lastname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FUNCTION">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" ForeColor="Green" 
                                Text='<%# bind("status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ADMIN">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Font-Bold="True" 
                                ForeColor="Green" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Font-Bold="True" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HR">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="True" 
                                ForeColor="Green" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" />
                        </EditItemTemplate>
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supervisor">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox4" runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox4" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Responsable">
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox5" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox5" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEPARTEMEMENT">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text='<%# bind("approved") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" Wrap="True" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </td>
        <td class="style2"><asp:Label ID="labeldept" runat="server" Text="DEPARTEMENT" BackColor="#507CD1" 
                Font-Bold="True" ForeColor="White" Visible="False"></asp:Label></td>
           </tr>
           <tr>
           <td class="style2">
               <asp:ListBox ID="listdepartement" runat="server" Height="272px" Width="187px" 
                   Visible="False" Font-Bold="True" Font-Size="Medium">
               </asp:ListBox>
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
    
     
    </div>
    </form>
</body>
</html>
