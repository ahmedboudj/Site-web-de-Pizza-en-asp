using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsNapolitanaBoudj
{
    public partial class commande : System.Web.UI.Page
    {
        pizza pizzaPage = new pizza();
        taille taillePage = new taille();
        ingredients ingredientPage = new ingredients();
        croute croutePage = new croute();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pizza.setPizza = pizza.CreerDataset();
                taille.setTaille = taille.CreerDataset();
                ingredients.setIngredients = ingredients.CreerDataset();
                croute.setCroute = croute.CreerDataset();


                //calculerPrix();
            }
        }

        protected void btnConfirmerCommande_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier si un élément est sélectionné pour chaque gestion
                if (pizza.indicePizzaChoisie == -1 || ingredients.indiceIngredientChoisi == -1 || taille.indiceTailleChoisie == -1 || croute.indiceCrouteChoisie == -1)
                {
                    throw new Exception("Veuillez sélectionner un élément pour chaque gestion (Client, Pizza, Croute, Taille, Gestion).");
                }
                // Récupérer le nom et le numéro de téléphone du client sélectionné
                string nomClient = gestionClients.setClients.Tables["Clients"].Rows[gestionClients.indiceClientChoisi]["NomComplet"].ToString();
                string numeroTelClient = gestionClients.setClients.Tables["Clients"].Rows[gestionClients.indiceClientChoisi]["NumeroTel"].ToString();
                // Récupérer le nomPizza et ingredient et taille et croute du selectionne
                string nomPizza = pizza.setPizza.Tables["Pizzas"].Rows[pizza.indicePizzaChoisie]["Nom"].ToString();
                string ingredient = ingredients.setIngredients.Tables["Ingredients"].Rows[ingredients.indiceIngredientChoisi]["NomIngredient"].ToString();
                string tailleP = taille.setTaille.Tables["Tailles"].Rows[taille.indiceTailleChoisie]["tailleNom"].ToString();
                string crouteP = croute.setCroute.Tables["Croutes"].Rows[croute.indiceCrouteChoisie]["crouteNom"].ToString();

                // Afficher le message
                lblInfoClient.Text = $"Nom: {nomClient},<br/> <br/>  Numéro de téléphone: {numeroTelClient},";
                lblInfoPizza.Text = $"Pizza : {nomPizza}, De taille :{tailleP}, Avec l'ingredient :{ingredient},  Et une croute :{crouteP}";
            
                // Effacer les labels de confirmation précédents
                lblConfirmationClient.Text = "";

                // Afficher le message de confirmation
                lblConfirmationClient.Text = "Commande confirmée, A Bientot !";
            }
            catch (Exception ex)
            {
                lblConfirmationClient.Text = ex.Message;
            }
        }
    


        protected void btnFacture_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérifier si un élément est sélectionné pour chaque gestion
                if (pizza.indicePizzaChoisie == -1 || ingredients.indiceIngredientChoisi == -1 || taille.indiceTailleChoisie == -1 || croute.indiceCrouteChoisie == -1)
                {
                    throw new Exception("Veuillez sélectionner un élément pour chaque gestion (Client, Pizza, Croute, Taille, Gestion).");
                }

                // Récupérer le prix de la pizza sélectionnée
                string PrixP = pizza.setPizza.Tables["Pizzas"].Rows[pizza.indicePizzaChoisie]["Prix"].ToString();
                string PrixI = ingredients.setIngredients.Tables["Ingredients"].Rows[ingredients.indiceIngredientChoisi]["Prix"].ToString();
                string PrixT = taille.setTaille.Tables["Tailles"].Rows[taille.indiceTailleChoisie]["Prix"].ToString();
                string PrixC = croute.setCroute.Tables["Croutes"].Rows[croute.indiceCrouteChoisie]["Prix"].ToString();

                // Convertir les prix en décimaux
                decimal prixPizza = decimal.Parse(PrixP);
                decimal prixIngredient = decimal.Parse(PrixI);
                decimal prixTaille = decimal.Parse(PrixT);
                decimal prixCroute = decimal.Parse(PrixC);

                // Calculer le prix total
                decimal prixTotal = prixPizza + prixIngredient + prixTaille + prixCroute;

                // Calculer la taxe (15%)
                decimal taxe = prixTotal * 0.15m;

                // Calculer le prix total avec taxe
                decimal prixTotalAvecTaxe = prixTotal + taxe;

                // Afficher les messages
                lblPrixP.Text = $"Prix Pizza: {PrixP} $";
                lblPrixI.Text = $"Prix Ingredient: {PrixI} $";
                lblPrixT.Text = $"Prix Taille: {PrixT} $";
                lblPrixC.Text = $"Prix Croute: {PrixC} $";
                lblTotal.Text = $"Prix Total: {prixTotal} $";
                lblTotalAvecTaxe.Text = $"Total avec Taxe: {prixTotalAvecTaxe} $";
            }
            catch (Exception ex)
            {
                lblTotal.Text = "";
                lblTotalAvecTaxe.Text = "";
                lblPrixP.Text = "";
                lblPrixI.Text = "";
                lblPrixT.Text = "";
                lblPrixC.Text = "";
                lblConfirmationClient.Text = ex.Message;
            }
        }


    }
}
