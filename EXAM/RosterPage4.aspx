<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RosterPage4.aspx.cs" Inherits="EXAM.RosterPage4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link type="text/css" rel="stylesheet" href="css/bootstrap.min.css?1" />
    <link type="text/css" rel="stylesheet" href="css/bootstrap-theme.min.css" />
    <style type="text/css">
        table th {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvRoster4" runat="server" Style="margin: 0 auto; text-align: center;" AutoGenerateColumns="False" Width="1031px" AllowSorting="True">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="编号" ReadOnly="true" />
                    <asp:BoundField DataField="name" HeaderText="姓名" ReadOnly="True" />
                    <asp:TemplateField HeaderText="性别">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# (bool)Eval("sex") ? "男":"女" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="seatNo" HeaderText="座位号" ReadOnly="True" />
                    <asp:BoundField DataField="examNo" HeaderText="准考证号" ReadOnly="True" />
                    <asp:BoundField DataField="room" HeaderText="教室号" ReadOnly="True" />
                    <asp:BoundField DataField="identityNo" HeaderText="身份证号" ReadOnly="True" />
                    <asp:BoundField DataField="examType" HeaderText="报考类别" ReadOnly="True" />
                    <asp:BoundField DataField="department" HeaderText="工作单位" ReadOnly="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
