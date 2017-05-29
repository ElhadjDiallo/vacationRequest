<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="employeeform.aspx.cs" Inherits="VacationRequest.pages.employeeform"  UICulture="en-US" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
  <li><a  href="EmployeeInfos.aspx"><strong>REQUEST FORM</strong></a></li>                  
  <li><a class="active" href="employeeform.aspx"><strong>SUBMITED FORM</strong></a></li>
   <li><a href="supervisorcontrol.aspx"><strong>  <asp:Label ID="titresup" runat="server" Text="SUPERVISOR"></asp:Label></strong></a></li>
  <li><a href="Hrcontrol.aspx"><strong><asp:Label ID="titreHr" runat="server"
      Text="H/R ACCOUNTS"></asp:Label></strong></a></li>
  <li><a href="AdminControl.aspx"><strong><asp:Label ID="titreAdmin" runat="server"
      Text="ADMIN SETUP"></asp:Label></strong></a></li>
  <li><a href="../Home/Authentification.aspx"><strong>DISCONNECT</strong></a></li>
 </ul>
    
    </td>
     </tr>
        <tr>
        <td>
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" 
            onrowdatabound="GridView1_RowDataBound" AllowPaging="True" 
                onpageindexchanging="GridView1_PageIndexChanging1" PageSize="13" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" 
                AutoGenerateEditButton="True" onrowediting="GridView1_RowEditing" 
                onrowupdating="GridView1_RowUpdating" 
                onrowcancelingedit="GridView1_RowCancelingEdit" style="margin-right: 0px" 
             >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# bind("idvacation") %>' Font-Bold="True" Font-Size="Medium"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EMPLOYEE NAME">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# bind("employe_name") %>' 
                        Font-Bold="True" Font-Size="Medium"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DEPT/SECTION">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# bind("departement") %>'  Font-Bold="True" Font-Size="Medium"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DATE OF SUBMISSION">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# bind("date") %>'  Font-Bold="True" Font-Size="Medium"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Font-Bold="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FROM (DATE)">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# bind("from_date") %>'  Font-Bold="True" Font-Size="Medium" ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
                </EditItemTemplate>
                <FooterStyle Font-Bold="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TO (DATE)">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# bind("to_date") %>'  Font-Bold="True" Font-Size="Medium"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Date"></asp:TextBox>
                </EditItemTemplate>
                <HeaderStyle Font-Bold="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No OF HOURS/DAYS">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="Number" MaxLength="23"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# bind("days") %>'  Font-Bold="True" Font-Size="Medium" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Approved by">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# bind("approved") %>'  Font-Bold="True" Font-Size="Medium"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Bold="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RESPONSE">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# bind("choix") %>'  Font-Bold="True" Font-Size="Medium"></asp:Label>
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
    <asp:Label ID="error" runat="server" Text="NO RECORDS SUBMITED FOR YOU" 
            Font-Bold="True" Font-Size="XX-Large" ForeColor="#CC0000" Visible="False"></asp:Label>
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
 
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"  PopupControlID="Panel2" Drag="True" DropShadow="True"
        TargetControlID="tempb"
        CancelControlID="close">
    </asp:ModalPopupExtender>
  
    </form>
</body>
</html>
