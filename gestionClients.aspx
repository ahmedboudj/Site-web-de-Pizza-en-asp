<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionClients.aspx.cs" Inherits="prjWebCsNapolitanaBoudj.gestionClients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestion des Clients</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-image: url('images/pizza1.jpg');
            background-repeat: no-repeat;
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
            padding: 15px;
            text-align: left;
        }

        .inner-table th {
            background-color: saddlebrown;
            color: white;
            text-align: center;
        }

        .button-group {
            background-color: white;
        }

        .button-group button:hover, .button:hover {
            background-color: #8b4513;
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

        .input-text {
            width: 200px;
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
            display: block;
            margin-left: auto;
            margin-right: auto;
        }

        .button {
            text-align: center;
            padding: 8px 20px;
            font-weight: bold;
            color: white;
            background-color: brown;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>GESTION DES CLIENTS</h1>
            <hr />

            <table>

                <tr>
                    <td>
                        Liste des clients<br />
                        <asp:ListBox ID="lstClients" runat="server" AutoPostBack="True" Font-Bold="True" ForeColor="Blue" Height="100" Width="200" OnSelectedIndexChanged="lstClients_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td>
                        <table class="inner-table">
                            <tr>
                                <th colspan="3">Gestion du client sélectionné</th>
                            </tr>

                            <tr>
                                <td>Nom :</td>
                                <td>
                                    <asp:TextBox ID="txtNomComplet" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Numéro de Téléphone :</td>
                                <td>
                                    <asp:TextBox ID="txtNumeroTel" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="button-group" colspan="3">
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
                        <!-- GridView pour afficher les commandes -->
                        <asp:GridView ID="gridCommandes" runat="server" BackColor="#66FFFF" BorderStyle="Solid" BorderWidth="2" Font-Bold="True" ForeColor="#663300" Width="100%">
    <Columns>
        <asp:BoundField DataField="Pizza" HeaderText="Pizza"/>
        <asp:BoundField DataField="Taille" HeaderText="Taille"/>
        <asp:BoundField DataField="Croute" HeaderText="Croute"/>
        <asp:BoundField DataField="Ingredients" HeaderText="Ingredients"/>
    </Columns>
</asp:GridView>

                    </td>
                </tr>
            </table>

            <hr />
            <div style="text-align: center; color: white">
                <label for="txtRecherche">Rechercher un client :</label>
                <asp:TextBox ID="txtRecherche" runat="server" CssClass="input-text"></asp:TextBox>
                <asp:Button ID="btnRechercher" runat="server" Text="Rechercher" OnClick="btnRechercher_Click" CssClass="button" />
            </div>
            <hr />
            <div style="text-align: center; color: white">
                <label for="txtNomRecherche">Nom :</label>
                <asp:TextBox ID="txtNomRecherche" runat="server" Enabled="false" CssClass="input-text"></asp:TextBox>
                <br />
                <label for="txtNumeroTelRecherche">Numéro de téléphone :</label>
                <asp:TextBox ID="txtNumeroTelRecherche" runat="server" Enabled="false" CssClass="input-text"></asp:TextBox>
            </div>
            <hr />
        </div>

        <div class="liens">
            <a href="acceuil.aspx"> Retour à l'accueil</a>
        </div>
    </form>
</body>
</html>
