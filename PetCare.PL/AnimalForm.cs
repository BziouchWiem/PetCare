
using Microsoft.EntityFrameworkCore;
using PetCare.DAL;
using PetCare.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace PetCare.PL
{
    public partial class AnimalForm : Form
    {
        public AnimalForm()
        {
            InitializeComponent();
        }

        private void AnimalForm_Load(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                cbProprietaire.DataSource = context.Proprietaires.ToList();
                cbProprietaire.DisplayMember = "Nom";
                cbProprietaire.ValueMember = "Id";
                cbProprietaire.SelectedIndex = 0;

                cbTypeAnimal.DataSource = context.TypesAnimaux.ToList();
                cbTypeAnimal.DisplayMember = "Libelle";
                cbTypeAnimal.ValueMember = "Id";
                cbTypeAnimal.SelectedIndex = 0;

                LoadAnimals();
            }
        }

        private void LoadAnimals()
        {
            using (var context = new ApplicationDbContext())
            {
                var animaux = context.Animaux
                    .Include(a => a.Proprietaire)
                    .Include(a => a.TypeAnimal)
                    .Select(a => new
                    {
                        a.Id,
                        a.Nom,
                        a.Age,
                        Proprietaire = a.Proprietaire.Nom,
                        TypeAnimal = a.TypeAnimal.Libelle
                    })
                    .ToList();

                dgvAnimaux.DataSource = animaux;
            }
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var animal = new Animal
                {
                    Nom = txtNom.Text,
                    Age = (int)numAge.Value,
                    ProprietaireId = (int)cbProprietaire.SelectedValue,
                    TypeAnimalId = (int)cbTypeAnimal.SelectedValue
                };

                context.Animaux.Add(animal);
                context.SaveChanges();
            }

            LoadAnimals();
            ClearFields();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvAnimaux.CurrentRow != null)
            {
                int id = (int)dgvAnimaux.CurrentRow.Cells["Id"].Value;

                using (var context = new ApplicationDbContext())
                {
                    var animal = context.Animaux.Find(id);

                    if (animal != null)
                    {
                        animal.Nom = txtNom.Text;
                        animal.Age = (int)numAge.Value;
                        animal.ProprietaireId = (int)cbProprietaire.SelectedValue;
                        animal.TypeAnimalId = (int)cbTypeAnimal.SelectedValue;

                        context.SaveChanges();
                    }
                }

                LoadAnimals();
                ClearFields();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvAnimaux.CurrentRow != null)
            {
                int id = (int)dgvAnimaux.CurrentRow.Cells["Id"].Value;

                using (var context = new ApplicationDbContext())
                {
                    var animal = context.Animaux.Find(id);
                    if (animal != null)
                    {
                        context.Animaux.Remove(animal);
                        context.SaveChanges();
                    }
                }

                LoadAnimals();
                ClearFields();
            }
        }

        private void dgvAnimaux_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvAnimaux.Rows[e.RowIndex];
                txtNom.Text = row.Cells["Nom"].Value.ToString();
                numAge.Value = Convert.ToInt32(row.Cells["Age"].Value);
                cbProprietaire.Text = row.Cells["Proprietaire"].Value.ToString();
                cbTypeAnimal.Text = row.Cells["TypeAnimal"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtNom.Clear();
            numAge.Value = 0;
            cbProprietaire.SelectedIndex = 0;
            cbTypeAnimal.SelectedIndex = 0;
        }

        private void cbProprietaire_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
