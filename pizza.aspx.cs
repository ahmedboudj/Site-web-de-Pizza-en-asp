using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsNapolitanaBoudj
{
    public partial class pizza : System.Web.UI.Page
    {
        // Déclaration des variables ou objets globaux
        public static DataSet setPizza { get; set; }
        static string mode = "";
        public static Int32 indicePizzaChoisie = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                setPizza = CreerDataset();
                RemplirListPizza();
                lstPizzas.SelectedIndex = 0;
                lstPizzas_SelectedIndexChanged(sender, e);
                CacherBoutons(true, false);
            }
        }

        public void RemplirListPizza()
        {
            lstPizzas.Items.Clear(); // vider la liste au départ
            foreach (DataRow myRow in setPizza.Tables["Pizzas"].Rows)
            {
                ListItem elm = new ListItem();
                elm.Text = myRow["Nom"].ToString();
                elm.Value = myRow["RefPizza"].ToString();
                lstPizzas.Items.Add(elm);
            }
        }

        public static DataSet CreerDataset()
        {
            DataSet mySet = new DataSet();

            // Création de la table pizzas
            DataTable myTbPizza = new DataTable("Pizzas");

            // Création du champ RefPizza
            DataColumn myCol = new DataColumn("RefPizza", typeof(Int64));
            myCol.AutoIncrement = true;
            myCol.AutoIncrementSeed = 1;
            myCol.AutoIncrementStep = 1;
            myTbPizza.Columns.Add(myCol);

            // Création du champ Nom
            myCol = new DataColumn("Nom", typeof(String));
            myCol.MaxLength = 50;
            myTbPizza.Columns.Add(myCol);

            // Création du champ Prix
            myTbPizza.Columns.Add(new DataColumn("Prix", typeof(Decimal)));

            // Création des champs indexes
            DataColumn[] cles = new DataColumn[1];
            cles[0] = myTbPizza.Columns["RefPizza"];
            myTbPizza.PrimaryKey = cles;

            // Remplir table avec enregistrements
            DataRow myrow = myTbPizza.NewRow();
            myrow["Nom"] = "La Italienne";
            myrow["Prix"] = 10;
            myTbPizza.Rows.Add(myrow);

            myrow = myTbPizza.NewRow();
            myrow["Nom"] = "La Quebecoise";
            myrow["Prix"] = 9;
            myTbPizza.Rows.Add(myrow);

            myrow = myTbPizza.NewRow();
            myrow["Nom"] = "La Mexicaine";
            myrow["Prix"] = 11;
            myTbPizza.Rows.Add(myrow);

            myrow = myTbPizza.NewRow();
            myrow["Nom"] = "La Vegetarienne";
            myrow["Prix"] = 14;
            myTbPizza.Rows.Add(myrow);

            myrow = myTbPizza.NewRow();
            myrow["Nom"] = "Halal";
            myrow["Prix"] = 5;
            myTbPizza.Rows.Add(myrow);

            // Sauvegarder la table pizza dans le dataset
            mySet.Tables.Add(myTbPizza);
            return mySet;
        }

        public Decimal getPrixPizza(string refPizza)
        {
            Decimal prix = 0;
            foreach (DataRow myRow in setPizza.Tables["Pizzas"].Rows)
            {
                if (refPizza == myRow["RefPizza"].ToString())
                {
                    prix = Convert.ToDecimal(myRow["Prix"]);
                    break;
                }
            }
            return prix;
        }

        protected void lstPizzas_SelectedIndexChanged(object sender, EventArgs e)
        {
            indicePizzaChoisie = lstPizzas.SelectedIndex;
            string refP = lstPizzas.SelectedItem.Value;

            foreach (DataRow myRow in setPizza.Tables["Pizzas"].Rows)
            {
                if (refP == myRow["RefPizza"].ToString())
                {
                    txtNom.Text = myRow["Nom"].ToString();
                    txtPrix.Text = myRow["Prix"].ToString();
                    break;
                }
            }
        }

        public DataSet getPizzas()
        {
            return CreerDataset();
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            mode = "ajout";
            CacherBoutons(false, true);
            txtNom.Text = "";
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
            DataRow myrow = setPizza.Tables["Pizzas"].Rows[indicePizzaChoisie];
            myrow.Delete();
            RemplirListPizza();
            if (lstPizzas.Items.Count > 0)
            {
                lstPizzas.SelectedIndex = 0;
                lstPizzas_SelectedIndexChanged(sender, e);
            }
            else
            {
                txtNom.Text = "Vide";
                txtPrix.Text = "0";
                btnSupprimer.Visible = false;
            }
        }

        protected void btnSauvgarder_Click(object sender, EventArgs e)
        {
            if (mode == "ajout")
            {
                DataRow myrow = setPizza.Tables["Pizzas"].NewRow();
                myrow["Nom"] = txtNom.Text;
                myrow["Prix"] = txtPrix.Text;
                setPizza.Tables["Pizzas"].Rows.Add(myrow);
            }
            else if (mode == "modif")
            {
                DataRow myrow = setPizza.Tables["Pizzas"].Rows[indicePizzaChoisie];
                myrow["Nom"] = txtNom.Text;
                myrow["Prix"] = txtPrix.Text;
            }
            mode = "";
            RemplirListPizza();
            CacherBoutons(true, false);
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            CacherBoutons(true, false);
            lstPizzas.SelectedIndex = indicePizzaChoisie;
            lstPizzas_SelectedIndexChanged(sender, e);
        }

        private void CacherBoutons(bool btnAjModSup, bool btnSauvAn)
        {
            btnAjouter.Visible = btnModifier.Visible = btnSupprimer.Visible = btnAjModSup;
            btnSauvgarder.Visible = btnAnnuler.Visible = btnSauvAn;
        }
    }
}
