<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="croute.aspx.cs" Inherits="prjWebCsNapolitanaBoudj.croute" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GESTION DES TAILLES</title>
    <style type="text/css">
         body {
     font-family: Arial, sans-serif;
      background-image:  url('images/pizza1.jpg'); 
 background-repeat:no-repeat;
 background-size: cover;
     margin: 0;
     padding: 0;
 }

 h1 {
     text-align: center;
     color: #ffa500;
     margin-top: 20px;
 }

 hr {
     width: 80%;
     margin: 20px auto;
     border-color: saddlebrown;
 }

 table {
     margin: auto;
     width: 80%;
     border-radius: 10px;
     padding: 10px;
     border-spacing: 8px;
     background-color: bisque;
     color: saddlebrown;
     font-weight: bold;
     border: 1px solid #ccc;
 }

 .inner-table {
     width: 100%;
     border-collapse: collapse;
 }

 .inner-table th, .inner-table td {
     padding: 8px;
     text-align: left;

 }

 .inner-table th {
     background-color: saddlebrown;
     color: white;
     text-align:center;
 }

 .button-group {
     text-align: right;
 }

 .button-group button, .button {
        padding: 8px 20px;
        font-weight: bold;
        color: white;
        background-color: brown;
        border: none;
        cursor: pointer;
        margin-right: 10px;
        border-radius: 5px;
    }

    .button-group button:hover, .button:hover {
        background-color: #8b4513;
    }

 .button-group button:hover {
     background-color: #8b4513;
 }

         .liens {
    margin-bottom: 15px;
    text-align: center;
}

.liens a {
    display: inline-block;
    padding: 10px 20px;
    background-color: #e74c3c;
    color: white;
    font-size: 18px;
    font-weight: bold;
    text-decoration: none;
    border-radius: 5px;
    transition: background-color 0.3s ease;
}

.liens a:hover {
    background-color: #c0392b;
}

/* Style spécial pour le lien "Gestion des Commandes" */
.liens a.btn-orange {
    background-color: #f39c12;
}

.liens a.btn-orange:hover {
    background-color: #d68910;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>GESTION DES CROUTES</h1>
            <hr />
            <table class="outer-table">
                <tr>
                    <td>
                        Choisir une croute<br />
                        <asp:ListBox ID="lstCroutes" runat="server" AutoPostBack="True" Font-Bold="True" ForeColor="Blue" Height="100" Width="200" OnSelectedIndexChanged="lstCroutes_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td>
                        <table class="inner-table">
                            <tr>
                                <th colspan="2">Gestion des croutes sélectionnées</th>
                            </tr>
                            <tr>
                                <td>Croute :</td>
                                <td>
                                    <asp:TextBox ID="txtCroute" runat="server" CssClass="textbox-style"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Prix :</td>
                                <td>
                                    <asp:TextBox ID="txtPrix" runat="server" CssClass="textbox-style"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="button-group" colspan="2">
                                    <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" CssClass="button" />
<asp:Button ID="btnModifier" runat="server" Text="Modifier" OnClick="btnModifier_Click" CssClass="button" />
<asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" OnClick="btnSupprimer_Click" CssClass="button" />
<asp:Button ID="btnSauvgarder" runat="server" Text="Sauvegarder" OnClick="btnSauvgarder_Click" CssClass="button" />
<asp:Button ID="btnAnnuler" runat="server" Text="Annuler" OnClick="btnAnnuler_Click" CssClass="button" />

                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gridCroutes" runat="server" BackColor="#66FFFF" CssClass="gridview-style"  ForeColor="#663300" Width="100%"></asp:GridView>
                    </td>
                </tr>
            </table>
        </div>

        <div class="liens">
    <a href="acceuil.aspx"> Retour à l'accueil</a>
</div>
    </form>
</body>
</html>