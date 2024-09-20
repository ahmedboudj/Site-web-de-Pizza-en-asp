using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsNapolitanaBoudj
{
    public partial class taille : System.Web.UI.Page
    {
        // declaration des variables ou objets globaux
        public static DataSet setTaille { get; set; }
        static string mode = "";
        public static Int32 indiceTailleChoisie = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //  Session["pizza"] = CreerDataset();
                setTaille = CreerDataset();
                RemplirListTaille();
                lstTailles.SelectedIndex = 0;
                lstTailles_SelectedIndexChanged(sender, e);
                CacherBoutons(true, false);
            }
        }

        public void RemplirListTaille()
        {
            lstTailles.Items.Clear(); // vider la liste au depart
            foreach (DataRow myRow in setTaille.Tables["Tailles"].Rows)
            {
                ListItem elm = new ListItem();
                elm.Text = myRow["tailleNom"].ToString();
                elm.Value = myRow["RefTaille"].ToString();
                lstTailles.Items.Add(elm);
            }

        }
        public static DataSet CreerDataset()
        {

            DataSet mySet = new DataSet();

            // Creation de la table taille
            DataTable myTbTaille = new DataTable("Tailles");

            // Creation du champ RefTaille
            DataColumn myCol = new DataColumn("RefTaille", typeof(Int64));
            // metre la colomn en numerique auto
            myCol.AutoIncrement = true;
            myCol.AutoIncrementSeed = 1;
            myCol.AutoIncrementStep = 1;

            // sauvegarder la colomn dans les colomn de la table
            myTbTaille.Columns.Add(myCol);

            // Creation du champ Taille
            myCol = new DataColumn("tailleNom", typeof(String));
            myCol.MaxLength = 50;

            // sauvegarder la colomn dans les colomn de la table
            myTbTaille.Columns.Add(myCol);

            // Creation du champ Taille
            myTbTaille.Columns.Add(new DataColumn("Taille", typeof(String)));

            // Creation du champ Prix
            myTbTaille.Columns.Add(new DataColumn("Prix", typeof(Decimal)));

            // Creation des champs indexes
            DataColumn[] cles = new DataColumn[1];
            cles[0] = myTbTaille.Columns["RefTaille"];
            myTbTaille.PrimaryKey = cles;

            //Remplir table avec enregistrements
            DataRow myrow = myTbTaille.NewRow();
            myrow["tailleNom"] = "Petite";
            myrow["Taille"] = "S";
            myrow["Prix"] = 5;
            myTbTaille.Rows.Add(myrow);

            myrow = myTbTaille.NewRow();
            myrow["tailleNom"] = "Moyenne";
            myrow["Taille"] = "M";
            myrow["Prix"] = 10;
            myTbTaille.Rows.Add(myrow);

            myrow = myTbTaille.NewRow();
            myrow["tailleNom"] = "Grande";
            myrow["Taille"] = "XL";
            myrow["Prix"] = 15;
            myTbTaille.Rows.Add(myrow);


            // sauvegarder la table tailel dans le dataset
            mySet.Tables.Add(myTbTaille);
            return mySet;
        }
        public Decimal getPrixTaille(string refTaille)
        {
            Decimal prix = 0;
            foreach (DataRow myRow in setTaille.Tables["Tailles"].Rows)
            {
                if (refTaille == myRow["RefTaille"].ToString())
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
            txtNom.Text = "";
            txtTaille.Text = "";
            txtPrix.Text = "";
            txtNom.Focus();
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            mode = "modif";
            CacherBoutons(false, true);
            txtNom.Focus();
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            // trouver l'equipe choisie en fonction de son indice
            DataRow myrow = setTaille.Tables["Tailles"].Rows[indiceTailleChoisie];
            // supprimer l'equipe
            //setSport.Tables["Equipes"].Rows.Remove(myrow);
            myrow.Delete();
            RemplirListTaille();
            if (lstTailles.Items.Count > 0)
            {
                // choisir la premiere equipe de la liste
                lstTailles.SelectedIndex = 0;
                lstTailles_SelectedIndexChanged(sender, e);
            }
            else
            {
                txtNom.Text = "Vide";
                txtTaille.Text = "vide";
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

                DataRow myrow = setTaille.Tables["Tailles"].NewRow();

                //affecter les valeurs des textbox dans le nouvel enregistrement
                myrow["tailleNom"] = txtNom.Text;
                myrow["Taille"] = txtTaille.Text;
                myrow["Prix"] = txtPrix.Text;
                //sauvegarder ou ajouter la ligne dans la collection .Rows
                setTaille.Tables["Tailles"].Rows.Add(myrow);

            }
            else if (mode == "modif")
            {
                // sauvegarder la modification de l'equipe choisie
                // trouver l'equipe choisie en fonction de son indice
                DataRow myrow = setTaille.Tables["Tailles"].Rows[indiceTailleChoisie];

                //affecter les valeurs des textbox dans l'enregistrement choisi
                myrow["tailleNom"] = txtNom.Text;
                myrow["Taille"] = txtTaille.Text;
                myrow["Prix"] = txtPrix.Text;

            }
            mode = "";
            //mettre a jour la liste des noms des equipes
            RemplirListTaille();
            CacherBoutons(true, false);
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {

            CacherBoutons(true, false);
            // choisir l'equipe precedente equipe de la liste
            lstTailles.SelectedIndex = indiceTailleChoisie;
            lstTailles_SelectedIndexChanged(sender, e);
        }

        protected void lstTailles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //recuperer indice de l'element choisi
            indiceTailleChoisie = lstTailles.SelectedIndex;
            //
            string refT = lstTailles.SelectedItem.Value;

            //string equip = lstEquipes.SelectedItem.Text;
            foreach (DataRow myRow in setTaille.Tables["Tailles"].Rows)
            {
                if (refT == myRow["RefTaille"].ToString())
                {
                    txtNom.Text = myRow["tailleNom"].ToString();
                    txtTaille.Text = myRow["Taille"].ToString();
                    txtPrix.Text = myRow["Prix"].ToString();
                    break;
                }
            }

            // Afficher le detaille de pizza selectionner
            // Cree une table temporaire en clonant la table pizza de notre dataset 
            DataTable tabTailles = setTaille.Tables["Tailles"].Clone();
            //verifier chaque pizza dont le refPizza egal celui de la pizza selectionnee
            foreach (DataRow myrow in setTaille.Tables["Tailles"].Rows)
            {
                if (refT == myrow["RefTaille"].ToString())
                {
                    tabTailles.ImportRow(myrow);
                }
            }
            // Lier les données filtrées au GridView
            //gridTailles.DataSource = tabTailles;
            //gridTailles.DataBind();
        }
        private void CacherBoutons(bool btnAjModSup, bool btnSauvAn)
        {
            btnAjouter.Visible = btnModifier.Visible = btnSupprimer.Visible = btnAjModSup;
            btnSauvgarder.Visible = btnAnnuler.Visible = btnSauvAn;
        }
    }
}