<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acceuil.aspx.cs" Inherits="prjWebCsNapolitanaBoudj.acceuil" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>pizzeria napoletana</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-image:  url('images/pizza2.jpg'); 
            background-repeat: no-repeat; 
            background-size: cover; 
            margin: 0;
            padding: 0;
        }

        .pizza {
            text-align: center;
            padding-top: 20px;
            width: 600px;
            margin: 0 auto; 
        }

        h1 {
            color: #e74c3c;
            font-size: 36px;
            margin-bottom: 20px;
        }

        hr {
            border: 2px solid #e74c3c;
            margin-bottom: 30px;
        }

        .titre {
            font-family:'Goudy Old Style';
            animation: blink-animation 2s steps(5, start) infinite;
            text-align: center;
            color:forestgreen;
            font-size:50px;
        }

        @keyframes blink-animation {
            to {
                visibility: hidden;
            }
        }

        .liens {
            margin-bottom: 45px;
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

        
        .liens a.btn-orange {
            background-color: #f39c12;
        }

        .liens a.btn-orange:hover {
            background-color: #d68910;
        }

        /* Animation d'écriture pour le span */
        @keyframes typing {
            from {
                width: 0;
            }
            to {
                width: 100%;
            }
        }

        span.typewriter {
            margin-left: 100px;
            margin-top: 30px;
            display: inline-block;
            overflow: hidden;
            white-space: nowrap; 
            font-size: 45px; 
            color:white; 
            background-color:darkblue;
            font-family:'Goudy Old Style';
           
            animation: typing 5s steps(50, end); 
        }
    </style>
</head>

<body>
    
    <div>
        <span class="typewriter">Bienvenue chez Pizza Napolitana, l'adresse incontournable pour déguster les meilleures pizzas à Montréal !</span>
    </div>

    <form id="form1" runat="server">
        <div class="pizza">
            <div>
                <h1 class="titre">PIZZERIA NAPOLITANA</h1>
                <hr style="width:600px" />
            </div>
            
            <div class="liens" style="margin-right:50px" >
                <a href="pizza.aspx">Gestion des Pizzas </a>
                
            </div>
            <div class="liens" style="margin-left:70px">
                <a href="ingredients.aspx">  Gestion des Ingrédients</a>          
            </div>
            <div class="liens" style="margin-left:100px">
                <a href="croute.aspx"> Gestion des Croute</a>
            </div>
            <div class="liens" style="margin-left:90px">
                <a href="taille.aspx"> Gestion des Taille</a>
            </div>
            <div class="liens" style="margin-left:40px">
                <a href="gestionClients.aspx">Gestion des Clients </a>
            </div>
            <div class="liens" style="margin-right:90px">
                <a href="commande.aspx">Voir Commande</a>
            </div>
        </div>
    </form>



</body>
</html>
