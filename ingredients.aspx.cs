using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsNapolitanaBoudj
{
    public partial class ingredients : System.Web.UI.Page
    {
        public static DataSet setIngredients { get; set; }
        static string modeIngredient = "";
        public static int indiceIngredientChoisi = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setIngredients = CreerDataset();
                RemplirListeIngredients();
                lstIngredients.SelectedIndex = 0;
                lstIngredients_SelectedIndexChanged(sender, e);
                CacherBoutonsIngredient(true, false);
            }
        }

        public void RemplirListeIngredients()
        {
            lstIngredients.Items.Clear();
            foreach (DataRow row in setIngredients.Tables["Ingredients"].Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["NomIngredient"].ToString();
                item.Value = row["RefIngredient"].ToString();
                lstIngredients.Items.Add(item);
            }
        }

        public static DataSet CreerDataset()
        {
            DataSet mySet = new DataSet();
            DataTable myTable = new DataTable("Ingredients");

            DataColumn myCol = new DataColumn("RefIngredient", typeof(int));
            myCol.AutoIncrement = true;
            myCol.AutoIncrementSeed = 1;
            myCol.AutoIncrementStep = 1;
            myTable.Columns.Add(myCol);

            myCol = new DataColumn("NomIngredient", typeof(string));
            myCol.MaxLength = 50;
            myTable.Columns.Add(myCol);

            myTable.Columns.Add(new DataColumn("Prix", typeof(decimal)));

            DataColumn[] cles = new DataColumn[1];
            cles[0] = myTable.Columns["RefIngredient"];
            myTable.PrimaryKey = cles;

            DataRow myRow = myTable.NewRow();
            myRow["NomIngredient"] = "Champignons";
            myRow["Prix"] = 1.5;
            myTable.Rows.Add(myRow);

            myRow = myTable.NewRow();
            myRow["NomIngredient"] = "Bacon Halal";
            myRow["Prix"] = 2;
            myTable.Rows.Add(myRow);

            myRow = myTable.NewRow();
            myRow["NomIngredient"] = "Extra Fromage";
            myRow["Prix"] = 1.75;
            myTable.Rows.Add(myRow);

            myRow = myTable.NewRow();
            myRow["NomIngredient"] = "Viande hachée";
            myRow["Prix"] = 2.5;
            myTable.Rows.Add(myRow);

            myRow = myTable.NewRow();
            myRow["NomIngredient"] = "Pepperoni";
            myRow["Prix"] = 2;
            myTable.Rows.Add(myRow);

            mySet.Tables.Add(myTable);
            return mySet;
        }
        public Decimal getPrixIngredient(string refIngredient)
        {
            Decimal prix = 0;
            foreach (DataRow myRow in setIngredients.Tables["Ingredients"].Rows)
            {
                if (refIngredient == myRow["RefIngredient"].ToString())
                {
                    prix = Convert.ToDecimal(myRow["Prix"]);
                    break;
                }
            }
            return prix;
        }
        protected void lstIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            indiceIngredientChoisi = lstIngredients.SelectedIndex;
            string RefI = lstIngredients.SelectedItem.Value;

            foreach (DataRow myRow in setIngredients.Tables["Ingredients"].Rows)
            {
                if (RefI == myRow["RefIngredient"].ToString())
                {
                    txtNomIngredient.Text = myRow["NomIngredient"].ToString();
                    txtPrix.Text = myRow["Prix"].ToString();
                    break;
                }
            }
            // Afficher le dePrix de pizza selectionner
            // Cree une table temporaire en clonant la table pizza de notre dataset 
            DataTable tabIngredientSelectionne = setIngredients.Tables["Ingredients"].Clone();
            //verifier chaque pizza dont le refPizza egal celui de la pizza selectionnee
            foreach (DataRow myrow in setIngredients.Tables["Ingredients"].Rows)
            {
                if (RefI == myrow["RefIngredient"].ToString())
                {
                    tabIngredientSelectionne.ImportRow(myrow);
                }
            }
            //GridView
            //gridIngredients.DataSource = tabIngredientSelectionne;
            //gridIngredients.DataBind();
        }

        protected void btnAjouterIngredient_Click(object sender, EventArgs e)
        {
            modeIngredient = "ajout";
            CacherBoutonsIngredient(false, true);
            txtNomIngredient.Text = "";
            txtPrix.Text = "";
            txtNomIngredient.Focus();
        }

        protected void btnModifierIngredient_Click(object sender, EventArgs e)
        {
            modeIngredient = "modif";
            CacherBoutonsIngredient(false, true);
            txtNomIngredient.Focus();
        }

        protected void btnSupprimerIngredient_Click(object sender, EventArgs e)
        {
            DataRow ingredientARemove = setIngredients.Tables["Ingredients"].Rows[indiceIngredientChoisi];
            ingredientARemove.Delete();
            RemplirListeIngredients();
            if (lstIngredients.Items.Count > 0)
            {
                lstIngredients.SelectedIndex = 0;
                lstIngredients_SelectedIndexChanged(sender, e);
            }
            else
            {
                txtNomIngredient.Text = "Vide";
                txtPrix.Text = "0";
                btnSupprimerIngredient.Visible = false;
            }
        }

        protected void btnSauvgarderIngredient_Click(object sender, EventArgs e)
        {
            if (modeIngredient == "ajout")
            {
                DataRow newIngredient = setIngredients.Tables["Ingredients"].NewRow();
                newIngredient["NomIngredient"] = txtNomIngredient.Text;
                newIngredient["PrixIngredient"] = txtPrix.Text;
                setIngredients.Tables["Ingredients"].Rows.Add(newIngredient);
            }
            else if (modeIngredient == "modif")
            {
                DataRow selectedIngredient = setIngredients.Tables["Ingredients"].Rows[indiceIngredientChoisi];
                selectedIngredient["NomIngredient"] = txtNomIngredient.Text;
                selectedIngredient["PrixIngredient"] = txtPrix.Text;
            }
            modeIngredient = "";
            RemplirListeIngredients();
            CacherBoutonsIngredient(true, false);
        }

        protected void btnAnnulerIngredient_Click(object sender, EventArgs e)
        {
            CacherBoutonsIngredient(true, false);
            lstIngredients.SelectedIndex = indiceIngredientChoisi;
            lstIngredients_SelectedIndexChanged(sender, e);
        }

        private void CacherBoutonsIngredient(bool btnAjModSup, bool btnSauvAn)
        {
            btnAjouterIngredient.Visible = btnModifierIngredient.Visible = btnSupprimerIngredient.Visible = btnAjModSup;
            btnSauvgarderIngredient.Visible = btnAnnulerIngredient.Visible = btnSauvAn;
        }
    }
}