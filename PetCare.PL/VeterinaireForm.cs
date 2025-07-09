using PetCare.DAL;
using PetCare.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PetCare.PL
{
    public partial class VeterinaireForm : Form
    {
        public VeterinaireForm()
        {
            InitializeComponent();
        }

        private void VeterinaireForm_Load(object sender, EventArgs e)
        {
            LoadVeterinaires();
        }

        private void LoadVeterinaires()
        {
            using (var context = new ApplicationDbContext())
            {
                var vets = context.Veterinaires
                    .Select(v => new { v.Id, v.Nom, v.Specialite })
                    .ToList();
                dgvVeterinaires.DataSource = vets;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var vet = new Veterinaire
                {
                    Nom = txtNom.Text,
                    Specialite = txtSpecialite.Text
                };
                context.Veterinaires.Add(vet);
                context.SaveChanges();
            }
            LoadVeterinaires();
            ClearFields();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvVeterinaires.CurrentRow != null)
            {
                int id = (int)dgvVeterinaires.CurrentRow.Cells["Id"].Value;
                using (var context = new ApplicationDbContext())
                {
                    var vet = context.Veterinaires.Find(id);
                    if (vet != null)
                    {
                        vet.Nom = txtNom.Text;
                        vet.Specialite = txtSpecialite.Text;
                        context.SaveChanges();
                    }
                }
                LoadVeterinaires();
                ClearFields();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvVeterinaires.CurrentRow != null)
            {
                int id = (int)dgvVeterinaires.CurrentRow.Cells["Id"].Value;
                using (var context = new ApplicationDbContext())
                {
                    var vet = context.Veterinaires.Find(id);
                    if (vet != null)
                    {
                        context.Veterinaires.Remove(vet);
                        context.SaveChanges();
                    }
                }
                LoadVeterinaires();
                ClearFields();
            }
        }

        private void dgvVeterinaires_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvVeterinaires.Rows[e.RowIndex];
                txtNom.Text = row.Cells["Nom"].Value.ToString();
                txtSpecialite.Text = row.Cells["Specialite"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtNom.Clear();
            txtSpecialite.Clear();
        }
    }
}