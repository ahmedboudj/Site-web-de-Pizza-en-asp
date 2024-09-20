<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ingredients.aspx.cs" Inherits="prjWebCsNapolitanaBoudj.ingredients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestion des Ingrédients</title>
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
            background-color: white;
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
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <h1>GESTION DES INGRÉDIENTS</h1>
            <hr />
            <table>
                <tr>
                    <td>
                        Choisir un ingrédient<br />
                        <asp:ListBox ID="lstIngredients" runat="server" AutoPostBack="True" Font-Bold="True" ForeColor="Blue" Height="100" Width="200" OnSelectedIndexChanged="lstIngredients_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td>
                        <table class="inner-table">
                            <tr>
                                <th colspan="2">Gestion de l'ingrédient sélectionné</th>
                            </tr>
                            <tr>
                                <td>Nom :</td>
                                <td>
                                    <asp:TextBox ID="txtNomIngredient" runat="server" CssClass="textbox-style"></asp:TextBox>
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
                                    <asp:Button ID="btnAjouterIngredient" runat="server" Text="Ajouter" OnClick="btnAjouterIngredient_Click" CssClass="button" />
                                    <asp:Button ID="btnModifierIngredient" runat="server" Text="Modifier" OnClick="btnModifierIngredient_Click"  CssClass="button"/>
                                    <asp:Button ID="btnSupprimerIngredient" runat="server" Text="Supprimer" OnClick="btnSupprimerIngredient_Click" CssClass="button" />
                                    <asp:Button ID="btnSauvgarderIngredient" runat="server" Text="Sauvegarder" OnClick="btnSauvgarderIngredient_Click" CssClass="button" />
                                    <asp:Button ID="btnAnnulerIngredient" runat="server" Text="Annuler" OnClick="btnAnnulerIngredient_Click"  CssClass="button"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gridIngredients" runat="server" BackColor="#66FFFF" BorderStyle="Solid" BorderWidth="2" Font-Bold="True" ForeColor="#663300" Width="100%"></asp:GridView>
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
