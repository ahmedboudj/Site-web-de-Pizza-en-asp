using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsNapolitanaBoudj
{
    public partial class gestionClients : System.Web.UI.Page
    {
        public static DataSet setClients { get; set; }
        static string mode = "";
        public static int indiceClientChoisi = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setClients = CreerDataSet();
                RemplirListClients();
                lstClients.SelectedIndex = 0;
                lstClients_SelectedIndexChanged(sender, e);
                CacherBoutons(true, false);
            }
        }

        public void RemplirListClients()
        {
            lstClients.Items.Clear();
            foreach (DataRow row in setClients.Tables["Clients"].Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["NomComplet"].ToString();
                item.Value = row["RefClients"].ToString(); // Utilisation de la colonne RefClients pour la valeur
                lstClients.Items.Add(item);
            }
        }

        private DataSet CreerDataSet()
        {
            DataSet mySet = new DataSet();

            DataTable tableClients = new DataTable("Clients");

            DataColumn myCol = new DataColumn("RefClients", typeof(int)); // Ajout de la colonne RefClients
            myCol.AutoIncrement = true;
            myCol.AutoIncrementSeed = 1;
            myCol.AutoIncrementStep = 1;
            tableClients.Columns.Add(myCol);

            myCol = new DataColumn("NomComplet", typeof(string));
            tableClients.Columns.Add(myCol);

            myCol = new DataColumn("NumeroTel", typeof(string));
            tableClients.Columns.Add(myCol);


            // Ajout de clients
            DataRow row = tableClients.NewRow();
            row["NomComplet"] = "Ahmed";
            row["NumeroTel"] = "123 456 4335";
            tableClients.Rows.Add(row);

            row = tableClients.NewRow();
            row["NomComplet"] = "Boudj";
            row["NumeroTel"] = "111 222 3333";
            tableClients.Rows.Add(row);

            // sauvegarder la table Clients dans le dataset
            mySet.Tables.Add(tableClients);
            return mySet;
        }

        protected void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            indiceClientChoisi = lstClients.SelectedIndex;
            string RefC = lstClients.SelectedItem.Value;

            foreach (DataRow myRow in setClients.Tables["Clients"].Rows)
            {
                if (RefC == myRow["RefClients"].ToString())
                {
                    txtNomComplet.Text = myRow["NomComplet"].ToString();
                    txtNumeroTel.Text = myRow["NumeroTel"].ToString();
                    break;
                }
            }

            DataTable tabClientSelectionne = setClients.Tables["Clients"].Clone();
            foreach (DataRow myrow in setClients.Tables["Clients"].Rows)
            {
                if (RefC == myrow["RefClients"].ToString())
                {
                    tabClientSelectionne.ImportRow(myrow);
                }
            }

            // Remplir le GridView avec les commandes du client sélectionné
            DataRow client = setClients.Tables["Clients"].Rows[lstClients.SelectedIndex];
            gridCommandes.DataSource = GetCommandesClient(client["NomComplet"].ToString());
            gridCommandes.DataBind();
        }

        // Méthode pour obtenir les commandes du client sélectionné
        private DataTable GetCommandesClient(string nomClient)
        {
            DataTable commandes = new DataTable();
            commandes.Columns.Add("Pizza");
            commandes.Columns.Add("Taille");
            commandes.Columns.Add("Croute");
            commandes.Columns.Add("Ingredients");

            // Simulation de données de commandes
            if (nomClient == "Ahmed")
            {
                commandes.Rows.Add("Napolitaine", "Grande", "Fine", "olives");

            }
            else if (nomClient == "Boudj")
            {
                commandes.Rows.Add("Margherita", "Moyenne", "Épaisse", "mozzarella");
            }

            return commandes;
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            mode = "ajout";
            CacherBoutons(false, true);
            txtNomComplet.Text = "";
            txtNumeroTel.Text = "";
            txtNomComplet.Focus();
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            mode = "modif";
            CacherBoutons(false, true);
            txtNomComplet.Focus();
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            DataRow clientToDelete = setClients.Tables["Clients"].Rows[indiceClientChoisi];
            clientToDelete.Delete();
            RemplirListClients();

            if (lstClients.Items.Count > 0)
            {
                lstClients.SelectedIndex = 0;
                lstClients_SelectedIndexChanged(sender, e);
            }
            else
            {
                txtNomComplet.Text = "";
                txtNumeroTel.Text = "";
                btnSupprimer.Visible = false;
            }
        }

        protected void btnSauvgarder_Click(object sender, EventArgs e)
        {
            if (mode == "ajout")
            {
                DataRow newClient = setClients.Tables["Clients"].NewRow();
                newClient["NomComplet"] = txtNomComplet.Text;
                newClient["NumeroTel"] = txtNumeroTel.Text;
                setClients.Tables["Clients"].Rows.Add(newClient);
            }
            else if (mode == "modif")
            {
                DataRow clientToUpdate = setClients.Tables["Clients"].Rows[indiceClientChoisi];
                clientToUpdate["NomComplet"] = txtNomComplet.Text;
                clientToUpdate["NumeroTel"] = txtNumeroTel.Text;
            }

            mode = "";
            RemplirListClients();
            CacherBoutons(true, false);
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            CacherBoutons(true, false);
            lstClients.SelectedIndex = indiceClientChoisi;
            lstClients_SelectedIndexChanged(sender, e);
        }
        public string NomClientSelectionne
        {
            get { return txtNomComplet.Text; }
        }

        public string NumeroTelClientSelectionne
        {
            get { return txtNumeroTel.Text; }
        }

        protected void btnRechercher_Click(object sender, EventArgs e)
        {
            string nomClient = txtRecherche.Text.Trim();
            bool clientTrouve = false;

            foreach (DataRow row in setClients.Tables["Clients"].Rows)
            {
                if (row["NomComplet"].ToString().Equals(nomClient, StringComparison.OrdinalIgnoreCase))
                {
                    txtNomRecherche.Text = row["NomComplet"].ToString();
                    txtNumeroTelRecherche.Text = row["NumeroTel"].ToString();
                    clientTrouve = true;
                    break;
                }
            }

            if (!clientTrouve)
            {
                txtRecherche.Text = "Client Introuvable";
                txtNomRecherche.Text = "Client Introuvable";
                txtNumeroTelRecherche.Text = "Client Introuvable";
            }
        }

        private void CacherBoutons(bool btnAjModSup, bool btnSauvAn)
        {
            btnAjouter.Visible = btnModifier.Visible = btnSupprimer.Visible = btnAjModSup;
            btnSauvgarder.Visible = btnAnnuler.Visible = btnSauvAn;
        }
    }
}
