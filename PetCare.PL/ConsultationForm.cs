using PetCare.DAL;
using PetCare.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PetCare.PL
{
    public partial class ConsultationForm : Form
    {
        public ConsultationForm()
        {
            InitializeComponent();
        }

        private void ConsultationForm_Load(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                cbAnimal.DataSource = context.Animaux.ToList();
                cbAnimal.DisplayMember = "Nom";
                cbAnimal.ValueMember = "Id";

                cbVeterinaire.DataSource = context.Veterinaires.ToList();
                cbVeterinaire.DisplayMember = "Nom";
                cbVeterinaire.ValueMember = "Id";
            }

            LoadConsultations();
        }

        private void LoadConsultations()
        {
            using (var context = new ApplicationDbContext())
            {
                var consultations = context.Consultations
                    .Include(c => c.Animal)
                    .Include(c => c.Veterinaire)
                    .Select(c => new
                    {
                        c.Id,
                        Animal = c.Animal.Nom,
                        Veterinaire = c.Veterinaire.Nom,
                        c.DateConsultation,
                        c.Diagnostic
                    })
                    .ToList();
                dgvConsultations.DataSource = consultations;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var consultation = new Consultation
                {
                    AnimalId = (int)cbAnimal.SelectedValue,
                    VeterinaireId = (int)cbVeterinaire.SelectedValue,
                    DateConsultation = dtDate.Value,
                    Diagnostic = txtDiagnostic.Text
                };
                context.Consultations.Add(consultation);
                context.SaveChanges();
            }

            LoadConsultations();
            ClearFields();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvConsultations.CurrentRow != null)
            {
                int id = (int)dgvConsultations.CurrentRow.Cells["Id"].Value;
                using (var context = new ApplicationDbContext())
                {
                    var consultation = context.Consultations.Find(id);
                    if (consultation != null)
                    {
                        consultation.AnimalId = (int)cbAnimal.SelectedValue;
                        consultation.VeterinaireId = (int)cbVeterinaire.SelectedValue;
                        consultation.DateConsultation = dtDate.Value;
                        consultation.Diagnostic = txtDiagnostic.Text;
                        context.SaveChanges();
                    }
                }

                LoadConsultations();
                ClearFields();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvConsultations.CurrentRow != null)
            {
                int id = (int)dgvConsultations.CurrentRow.Cells["Id"].Value;
                using (var context = new ApplicationDbContext())
                {
                    var consultation = context.Consultations.Find(id);
                    if (consultation != null)
                    {
                        context.Consultations.Remove(consultation);
                        context.SaveChanges();
                    }
                }

                LoadConsultations();
                ClearFields();
            }
        }

        private void dgvConsultations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvConsultations.Rows[e.RowIndex];
                cbAnimal.Text = row.Cells["Animal"].Value.ToString();
                cbVeterinaire.Text = row.Cells["Veterinaire"].Value.ToString();
                dtDate.Value = Convert.ToDateTime(row.Cells["DateConsultation"].Value);
                txtDiagnostic.Text = row.Cells["Diagnostic"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            cbAnimal.SelectedIndex = 0;
            cbVeterinaire.SelectedIndex = 0;
            dtDate.Value = DateTime.Today;
            txtDiagnostic.Clear();
        }
    }
}