<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authentification.aspx.cs" Inherits="VacationRequest.Home.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style10
        {
            width: 234px;
        }
        .style12
        {
            height: 32px;
            width: 119px;
        }
        .style15
        {
            height: 32px;
            width: 308px;
        }
        .style16
        {
            height: 43px;
            width: 119px;
        }
        .style17
        {
            height: 43px;
            width: 308px;
        }
        .style18
        {
            height: 37px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" 
            BackColor="#0099CC" 
            
            
            
            style="top: 117px; left: 521px; position: absolute; height: 242px; width: 338px;">
            <table style="position: relative; top: 5px; left: 2px; width: 339px; height: 236px; margin-left: 0px;">
            <tr>
            <td class="style10" colspan="2" >
                <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/pictures/vacation.JPG" 
                    
                    
                    
                    
                    style="position: relative; top: 9px; left: 3px; height: 39px; width: 287px; margin-top: 0px;">
                </asp:ImageMap>
            
              </td>
            </tr>
            <tr>
            <td class="style16" valign="middle" align="center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                    Text="PUNCH_ID"></asp:Label>
                </td>
            <td class="style17">
                <asp:TextBox ID="punchid" runat="server" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                </td>
            </tr>
             <tr>
            <td class="style12" valign="middle" align="center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                    Font-Size="Large" Text="Password"></asp:Label>
                 </td>
            <td class="style15">
                <asp:TextBox ID="password" runat="server" AutoCompleteType="Disabled" 
                    TextMode="Password"></asp:TextBox>
                 </td>
            </tr>
           
          
             <tr>
             <td colspan="2" valign="middle" align="center" class="style18">
              <asp:Button ID="Button1" 
                     runat="server" Height="29px" Text="ENTER" 
                     Width="116px" onclick="Button1_Click" />
                 </td>
             </tr>
                <tr>
             <td colspan="2" valign="middle" align="center">
                 <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" 
                     Font-Size="Large" ForeColor="Red" Visible="False"></asp:Label>
                 </td>
             </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
