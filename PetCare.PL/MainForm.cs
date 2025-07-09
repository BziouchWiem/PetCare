using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetCare.PL
{
    public partial class MainForm : Form
    {
        private Panel sidebarPanel;
        private Panel headerPanel;
        private Panel contentPanel;
        private StatusStrip statusStrip;
        private Label lblTitle;
        private PictureBox logoPictureBox;

        public MainForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Propriétés de la fenêtre principale
            this.Text = "PetCare - Gestion des Animaux";
            this.Size = new Size(900, 600);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Panneau latéral (sidebar) avec une largeur augmentée
            sidebarPanel = new Panel
            {
                Width = 250, // Augmenté de 200 à 250 pour plus d'espace
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(174, 217, 224), // #AED9E0
            };
            this.Controls.Add(sidebarPanel);

            // Panneau d'en-tête (header)
            headerPanel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(74, 144, 226), // #4A90E2
            };
            this.Controls.Add(headerPanel);

            // Titre dans l'en-tête
            lblTitle = new Label
            {
                Text = "🐾 PetCare",
                Font = new Font("Pacifico", 20, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(15, 15),
                AutoSize = true,
            };
            headerPanel.Controls.Add(lblTitle);

            // Barre de statut
            statusStrip = new StatusStrip
            {
                Dock = DockStyle.Bottom,
                BackColor = Color.FromArgb(174, 217, 224), // #AED9E0
            };
            ToolStripStatusLabel statusLabel = new ToolStripStatusLabel
            {
                Text = $"Date: {DateTime.Now.ToShortDateString()}",
                ForeColor = Color.FromArgb(73, 80, 87), // #495057
            };
            statusStrip.Items.Add(statusLabel);
            this.Controls.Add(statusStrip);

            // Panneau de contenu avec marges
            contentPanel = new Panel
            {
                Location = new Point(240, 60), // Ajusté pour la nouvelle largeur de sidebarPanel
                Size = new Size(this.ClientSize.Width - 240, this.ClientSize.Height - 60 - statusStrip.Height), // Ajuste la taille
                BackColor = Color.White,
            };
            this.Controls.Add(contentPanel);

            // Ajuste les boutons existants
            SetupExistingButtons();

            // Message de bienvenue initial
            ShowWelcomeMessage();
        }

        private void SetupExistingButtons()
        {
            // Applique le style aux boutons existants
            StyleButton(btnProprietaire, new Point(10, 20), "👤");
            StyleButton(btnAnimal, new Point(10, 70), "🐾");
            StyleButton(btnTypeAnimal, new Point(10, 120), "🐱");
            StyleButton(btnVeterinaire, new Point(10, 170), "🩺");
            StyleButton(btnConsultation, new Point(10, 220), "📅");

            // Ajoute tous les boutons au panneau latéral
            sidebarPanel.Controls.AddRange(new Control[] { btnProprietaire, btnAnimal, btnTypeAnimal, btnVeterinaire, btnConsultation });
        }

        private void StyleButton(Button btn, Point location, string emoji)
        {
            btn.Text = $"{emoji} {btn.Text}";
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(174, 217, 224); // #AED9E0
            btn.ForeColor = Color.FromArgb(73, 80, 87); // #495057
            btn.Font = new Font("Poppins", 10, FontStyle.Regular);
            btn.Size = new Size(230, 40); // Augmenté de 180 à 230 pour plus d'espace
            btn.Location = location;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(150, 200, 210);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(174, 217, 224);
            btn.Tag = btn.BackColor; // Stocke la couleur originale
        }

        private void HighlightButton(Button selectedButton)
        {
            foreach (Control ctrl in sidebarPanel.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = (Color)btn.Tag;
                }
            }
            selectedButton.BackColor = Color.FromArgb(74, 144, 226); // #4A90E2
        }

        private void ShowWelcomeMessage()
        {
            contentPanel.Controls.Clear();
            Label welcomeLabel = new Label
            {
                Text = "Bienvenue sur PetCare !\nGérez facilement vos animaux, propriétaires, \net consultations.",
                Font = new Font("Poppins", 14, FontStyle.Regular),
                AutoSize = true,
                ForeColor = Color.FromArgb(73, 80, 87), // #495057
            };
            welcomeLabel.Location = new Point(
                (contentPanel.Width - welcomeLabel.Width) / 2,
                (contentPanel.Height - welcomeLabel.Height) / 2
            );
            contentPanel.Controls.Add(welcomeLabel);
            welcomeLabel.Location = new Point(
                (contentPanel.Width - welcomeLabel.Width) / 2,
                (contentPanel.Height - welcomeLabel.Height) / 2
            );
        }

        private void btnProprietaire_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            ProprietaireForm proprietaireForm = new ProprietaireForm();
            proprietaireForm.ShowDialog();
            ShowWelcomeMessage();
        }

        private void btnAnimal_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            AnimalForm animalForm = new AnimalForm();
            animalForm.ShowDialog();
            ShowWelcomeMessage();
        }

        private void btnTypeAnimal_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            TypeAnimalForm typeAnimalForm = new TypeAnimalForm();
            typeAnimalForm.ShowDialog();
            ShowWelcomeMessage();
        }

        private void btnVeterinaire_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            VeterinaireForm veterinaireForm = new VeterinaireForm();
            veterinaireForm.ShowDialog();
            ShowWelcomeMessage();
        }

        private void btnConsultation_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            ConsultationForm consultationForm = new ConsultationForm();
            consultationForm.ShowDialog();
            ShowWelcomeMessage();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Méthode vide pour le chargement
        }
    }
}