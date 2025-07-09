using PetCare.DAL;
using PetCare.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PetCare.PL
{
    public partial class ProprietaireForm : Form
    {
        public ProprietaireForm()
        {
            InitializeComponent();
        }

        private void ProprietaireForm_Load(object sender, EventArgs e)
        {
            LoadProprietaires();
        }

        private void LoadProprietaires()
        {
            using (var context = new ApplicationDbContext())
            {
                var proprietaires = context.Proprietaires
                    .Select(p => new { p.Id, p.Nom, p.Adresse, p.Telephone })
                    .ToList();
                dgvProprietaires.DataSource = proprietaires;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var proprietaire = new Proprietaire
                {
                    Nom = txtNom.Text,
                    Adresse = txtAdresse.Text,
                    Telephone = txtTelephone.Text
                };
                context.Proprietaires.Add(proprietaire);
                context.SaveChanges();
            }
            LoadProprietaires();
            ClearFields();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvProprietaires.CurrentRow != null)
            {
                int id = (int)dgvProprietaires.CurrentRow.Cells["Id"].Value;
                using (var context = new ApplicationDbContext())
                {
                    var proprietaire = context.Proprietaires.Find(id);
                    if (proprietaire != null)
                    {
                        proprietaire.Nom = txtNom.Text;
                        proprietaire.Adresse = txtAdresse.Text;
                        proprietaire.Telephone = txtTelephone.Text;
                        context.SaveChanges();
                    }
                }
                LoadProprietaires();
                ClearFields();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvProprietaires.CurrentRow != null)
            {
                int id = (int)dgvProprietaires.CurrentRow.Cells["Id"].Value;
                using (var context = new ApplicationDbContext())
                {
                    var proprietaire = context.Proprietaires.Find(id);
                    if (proprietaire != null)
                    {
                        context.Proprietaires.Remove(proprietaire);
                        context.SaveChanges();
                    }
                }
                LoadProprietaires();
                ClearFields();
            }
        }

        private void dgvProprietaires_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProprietaires.Rows[e.RowIndex];
                txtNom.Text = row.Cells["Nom"].Value.ToString();
                txtAdresse.Text = row.Cells["Adresse"].Value.ToString();
                txtTelephone.Text = row.Cells["Telephone"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtNom.Clear();
            txtAdresse.Clear();
            txtTelephone.Clear();
        }
    }
}