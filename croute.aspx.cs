using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsNapolitanaBoudj
{
    public partial class croute : System.Web.UI.Page
    {
        // declaration des variables ou objets globaux
        public static DataSet setCroute { get; set; }
        static string mode = "";
        public static int indiceCrouteChoisie = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                
                setCroute = CreerDataset();
                RemplirListCroute();
                lstCroutes.SelectedIndex = 0;
                lstCroutes_SelectedIndexChanged(sender, e);
                CacherBoutons(true, false);
            }
        }

        public void RemplirListCroute()
        {
            lstCroutes.Items.Clear(); // vider la liste au depart
                                      // Vérifier si la table "Croutes" existe dans le DataSet
            if (setCroute != null && setCroute.Tables.Contains("Croutes"))
            {
                foreach (DataRow myRow in setCroute.Tables["Croutes"].Rows)
                {
                    ListItem elm = new ListItem();
                    elm.Text = myRow["crouteNom"].ToString();
                    elm.Value = myRow["RefCroute"].ToString();
                    lstCroutes.Items.Add(elm);
                }
            }
            else
            {
                // Gérer le cas où la table "Croutes" n'existe pas
                // ou que le DataSet est null
                // Afficher un message d'erreur ou effectuer une autre action
            }
        }
        public static DataSet CreerDataset()
        {

            DataSet mySet = new DataSet();

            // Creation de la table Croute
            DataTable myTbCroute = new DataTable("Croutes");

            // Creation du champ RefCroute
            DataColumn myCol = new DataColumn("RefCroute", typeof(Int64));
            // metre la colomn en numerique auto
            myCol.AutoIncrement = true;
            myCol.AutoIncrementSeed = 1;
            myCol.AutoIncrementStep = 1;

            // sauvegarder la colomn dans les colomn de la table
            myTbCroute.Columns.Add(myCol);

            // Creation du champ Taille
            myCol = new DataColumn("crouteNom", typeof(String));
            myCol.MaxLength = 50;
            // sauvegarder la colomn dans les colomn de la table
            myTbCroute.Columns.Add(myCol);

            // Creation du champ Prix
            myTbCroute.Columns.Add(new DataColumn("Prix", typeof(Decimal)));
            // Creation des champs indexes
            DataColumn[] cles = new DataColumn[1];
            cles[0] = myTbCroute.Columns["RefCroute"];
            myTbCroute.PrimaryKey = cles;
            //Remplir table avec enregistrements
            DataRow myrow = myTbCroute.NewRow();
            myrow["crouteNom"] = "Mince";
            myrow["Prix"] = 1;
            myTbCroute.Rows.Add(myrow);

            myrow = myTbCroute.NewRow();
            myrow["crouteNom"] = "Normal";
            myrow["Prix"] = 1.5;
            myTbCroute.Rows.Add(myrow);

            myrow = myTbCroute.NewRow();
            myrow["crouteNom"] = "Epaisse";
            myrow["Prix"] = 2;
            myTbCroute.Rows.Add(myrow);

            myrow = myTbCroute.NewRow();
            myrow["crouteNom"] = "Fourrée Fromage";
            myrow["Prix"] = 2.5;
            myTbCroute.Rows.Add(myrow);


            // sauvegarder la table tailLe dans le dataset
            mySet.Tables.Add(myTbCroute);
            return mySet;
        }
        public Decimal getPrixCroute(string refCroute)
        {
            Decimal prix = 0;
            foreach (DataRow myRow in setCroute.Tables["Croutes"].Rows)
            {
                if (refCroute == myRow["RefCroute"].ToString())
                {
                    prix = Convert.ToDecimal(myRow["Prix"]);
                    break;
                }
            }
            return prix;
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            mode = "ajout";
            CacherBoutons(false, true);
            txtCroute.Text = "";
            txtPrix.Text = "";
            txtCroute.Focus();
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            mode = "modif";
            CacherBoutons(false, true);
            txtCroute.Focus();
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            // trouver l'equipe choisie en fonction de son indice
            DataRow myrow = setCroute.Tables["Croutes"].Rows[indiceCrouteChoisie];
            // supprimer l'equipe
            //setSport.Tables["Equipes"].Rows.Remove(myrow);
            myrow.Delete();
            RemplirListCroute();
            if (lstCroutes.Items.Count > 0)
            {
                // choisir la premiere equipe de la liste
                lstCroutes.SelectedIndex = 0;
                lstCroutes_SelectedIndexChanged(sender, e);
            }
            else
            {
                txtCroute.Text = "Vide";
                txtPrix.Text = "0";
                btnSupprimer.Visible = false;
            }
        }

        protected void btnSauvgarder_Click(object sender, EventArgs e)
        {
            if (mode == "ajout")
            {
                // sauvegarder l'ajout d'une nouvelle pizza
                //creation d'une nouvelle Ligne (ou enregistrement) avec la structure de la table Pizza

                DataRow myrow = setCroute.Tables["Croutes"].NewRow();

                //affecter les valeurs des textbox dans le nouvel enregistrement
                myrow["crouteNom"] = txtCroute.Text;
                myrow["Prix"] = txtPrix.Text;
                //sauvegarder ou ajouter la ligne dans la collection .Rows
                setCroute.Tables["Croutes"].Rows.Add(myrow);

            }
            else if (mode == "modif")
            {
                // sauvegarder la modification de l'equipe choisie
                // trouver l'equipe choisie en fonction de son indice
                DataRow myrow = setCroute.Tables["Croutes"].Rows[indiceCrouteChoisie];

                //affecter les valeurs des textbox dans l'enregistrement choisi
                myrow["crouteNom"] = txtCroute.Text;
                myrow["Prix"] = txtPrix.Text;

            }
            mode = "";
            //mettre a jour la liste des noms des equipes
            RemplirListCroute();
            CacherBoutons(true, false);
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {

            CacherBoutons(true, false);
            // choisir l'equipe precedente equipe de la liste
            lstCroutes.SelectedIndex = indiceCrouteChoisie;
            lstCroutes_SelectedIndexChanged(sender, e);
        }

        protected void lstCroutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //recuperer indice de l'element choisi
            indiceCrouteChoisie = lstCroutes.SelectedIndex;
            //
            string refC = lstCroutes.SelectedItem.Value;

            //string equip = lstEquipes.SelectedItem.Text;
            foreach (DataRow myRow in setCroute.Tables["Croutes"].Rows)
            {
                if (refC == myRow["RefCroute"].ToString())
                {
                    txtCroute.Text = myRow["crouteNom"].ToString();
                    txtPrix.Text = myRow["Prix"].ToString();
                    break;
                }
            }

            // Afficher le dePrix de pizza selectionner
            // Cree une table temporaire en clonant la table pizza de notre dataset 
            DataTable tabCroutes = setCroute.Tables["Croutes"].Clone();
            //verifier chaque pizza dont le refPizza egal celui de la pizza selectionnee
            foreach (DataRow myrow in setCroute.Tables["Croutes"].Rows)
            {
                if (refC == myrow["RefCroute"].ToString())
                {
                    tabCroutes.ImportRow(myrow);
                }
            }
            // GridView
            //gridCroutes.DataSource = tabCroutes;
            //gridCroutes.DataBind();
        }
        private void CacherBoutons(bool btnAjModSup, bool btnSauvAn)
        {
            btnAjouter.Visible = btnModifier.Visible = btnSupprimer.Visible = btnAjModSup;
            btnSauvgarder.Visible = btnAnnuler.Visible = btnSauvAn;
        }
    }
}