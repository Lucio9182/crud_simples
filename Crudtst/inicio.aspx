<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Crudtst.empform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div ng-app ="">
        <br />

        <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server" ></asp:TextBox>
        <br />
         <asp:Label ID="Label2" runat="server" Text="Telefone"></asp:Label>
        <br />
                <asp:TextBox ID="txttel" runat="server" Button="" server=""></asp:TextBox>
        <br/>
        <br/>
        
        <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
        <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" />
    
                <br />
        
        <br />      
        
        <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">

            <Columns>
                           <asp:BoundField DataField="id" HeaderText="Id" />
             
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="tel" HeaderText="Telefone" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnk_Selecionar">Selecionar</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnk_Apagar">Apagar</asp:LinkButton>
        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>



        </asp:GridView>
    </div>
    </form>
</body>
</html>
