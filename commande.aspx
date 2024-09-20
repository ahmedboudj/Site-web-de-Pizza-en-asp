<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="commande.aspx.cs" Inherits="prjWebCsNapolitanaBoudj.commande" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Commande</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-image: url('images/pizza2.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            justify-content: flex-start;
            align-items: center;
            height: 100vh;
            text-align:center;
        }

        h1 {
            text-align: center;
            color: #ffa500;
            margin-bottom: 20px;
        }
        h2
        {
            text-align:center;
            color:#ffa500;
        }

        .inner-table {
            width: 100%;
            border-collapse: collapse;
        }

        .inner-table th, .inner-table td {
            padding: 8px;
            text-align: left;
            color: white;
        }

        .inner-table th {
            background-color: saddlebrown;
        }

        .button-group, .liens {
            text-align: center;
            margin-bottom: 20px;
            margin-top: 20px;
        }

        .button-group .button {
            display: inline-block;
            padding: 10px 20px;
            background-color: green; 
            color: white;
            font-size: 18px;
            font-weight: bold;
            text-decoration: none;
            border-radius: 5px;
            transition: background-color 0.3s ease;
            margin-right: 10px;
            border: none;
            cursor: pointer;
        }

        .button-group .button:hover {
            background-color: #0a602e; 
        }
        .infoCP
        {
            text-align:center;
            color:white;
            font-weight: bold;
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
            margin-right: 10px;
        }

        .liens a:hover {
            background-color: #c0392b; 
        }

        .input-text {
            width: 200px;
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Informations sur la Commande</h1>
             <div class="button-group">
                <asp:Button ID="btnFacture" runat="server" Text="Voir la Facture" OnClick="btnFacture_Click" CssClass="button" />
             </div>
        </div>

        <div>
             <h3 style="color:#ffa500;">Details Facture </h3><br />
             <asp:Label ID="lblPrixP" runat="server" style="color:white;" Text=""></asp:Label><br /><br />
            <asp:Label ID="lblPrixI" runat="server" style="color:white;" Text=""></asp:Label><br /><br />
            <asp:Label ID="lblPrixT" runat="server" style="color:white;" Text=""></asp:Label><br /><br />
            <asp:Label ID="lblPrixC" runat="server" style="color:white;" Text=""></asp:Label><br /><br />
            <asp:Label ID="lblTotal" runat="server" style="color:gold; font-weight:bold;" Text=""></asp:Label><br /><br />
            <asp:Label ID="lblTotalAvecTaxe" runat="server" style="color:gold; font-weight:bold;" Text=""></asp:Label><br />
         </div>
        <br />
       
        <div class="button-group">
            <asp:Button ID="btnConfirmerCommande" runat="server" Text="Confirmer votre commande" OnClick="btnConfirmerCommande_Click" CssClass="button" />
        </div>

        <div>
                <h2 >Information sur le Client et la Pizza commander</h2>
                
            <br />
              
                <h3 style="color:#ffa500;">Info Client </h3>
            <asp:Label ID="lblInfoClient" runat="server" CssClass="infoCP" Text=""></asp:Label>
                </div>
               <br />
                 <div>
                   <h3 style="color:#ffa500;">Info Pizza </h3><br />
                   <asp:Label ID="lblInfoPizza" runat="server" CssClass="infoCP" Text=""></asp:Label>
                  </div>
                  <br />
        
                    <asp:Label ID="lblConfirmationClient" runat="server" style="color:gold; font-weight:bold;" Text="" ></asp:Label>
                  <br />
        

        <div class="liens">
            <a href="acceuil.aspx">Retour à l'accueil</a>
        </div>
    </form>
</body>
</html>
