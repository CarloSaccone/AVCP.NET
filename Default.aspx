<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>AVCP Records Generator C#.NET</h1>
            <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
                <p>
                    Dataset Generated!
                </p>
                <p><a target="_blank" href="XML/dataset.xml">XML/dataset.xml</a></p>
                <p><a target="_blank" href="XML/index.xml">XML/index.xml</a></p>
            </asp:Panel>
            <asp:Panel ID="pnlError" runat="server" Visible="false">
                <asp:Label ID="lblException" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
