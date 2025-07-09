using PetCare.DAL;
using PetCare.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PetCare.PL
{
    public partial class TypeAnimalForm : Form
    {
        public TypeAnimalForm()
        {
            InitializeComponent();
        }

        private void TypeAnimalForm_Load(object sender, EventArgs e)
        {
            LoadTypes();
        }

        private void LoadTypes()
        {
            using (var context = new ApplicationDbContext())
            {
                var types = context.TypesAnimaux
                    .Select(t => new { t.Id, t.Libelle })
                    .ToList();
                dgvTypesAnimaux.DataSource = types;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var type = new TypeAnimal
                {
                    Libelle = txtLibelle.Text
                };
                context.TypesAnimaux.Add(type);
                context.SaveChanges();
            }
            LoadTypes();
            ClearFields();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvTypesAnimaux.CurrentRow != null)
            {
                int id = (int)dgvTypesAnimaux.CurrentRow.Cells["Id"].Value;
                using (var context = new ApplicationDbContext())
                {
                    var type = context.TypesAnimaux.Find(id);
                    if (type != null)
                    {
                        type.Libelle = txtLibelle.Text;
                        context.SaveChanges();
                    }
                }
                LoadTypes();
                ClearFields();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvTypesAnimaux.CurrentRow != null)
            {
                int id = (int)dgvTypesAnimaux.CurrentRow.Cells["Id"].Value;
                using (var context = new ApplicationDbContext())
                {
                    var type = context.TypesAnimaux.Find(id);
                    if (type != null)
                    {
                        context.TypesAnimaux.Remove(type);
                        context.SaveChanges();
                    }
                }
                LoadTypes();
                ClearFields();
            }
        }

        private void dgvTypesAnimaux_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTypesAnimaux.Rows[e.RowIndex];
                txtLibelle.Text = row.Cells["Libelle"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtLibelle.Clear();
        }
    }
}