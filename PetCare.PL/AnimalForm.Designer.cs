
namespace PetCare.PL
{
    partial class AnimalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtNom = new TextBox();
            label1 = new Label();
            label2 = new Label();
            numAge = new NumericUpDown();
            cbProprietaire = new ComboBox();
            cbTypeAnimal = new ComboBox();
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            dgvAnimaux = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimaux).BeginInit();
            SuspendLayout();
            // 
            // txtNom
            // 
            txtNom.Location = new Point(0, 32);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(125, 27);
            txtNom.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 1;
            label1.Text = "Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 9);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 2;
            label2.Text = "Âge";
            // 
            // numAge
            // 
            numAge.Location = new Point(161, 32);
            numAge.Name = "numAge";
            numAge.Size = new Size(150, 27);
            numAge.TabIndex = 3;
            // 
            // cbProprietaire
            // 
            cbProprietaire.FormattingEnabled = true;
            cbProprietaire.Location = new Point(332, 32);
            cbProprietaire.Name = "cbProprietaire";
            cbProprietaire.Size = new Size(151, 28);
            cbProprietaire.TabIndex = 4;
            cbProprietaire.Text = "Proprietaire";
            cbProprietaire.SelectedIndexChanged += cbProprietaire_SelectedIndexChanged;
            // 
            // cbTypeAnimal
            // 
            cbTypeAnimal.FormattingEnabled = true;
            cbTypeAnimal.Location = new Point(505, 32);
            cbTypeAnimal.Name = "cbTypeAnimal";
            cbTypeAnimal.Size = new Size(151, 28);
            cbTypeAnimal.TabIndex = 5;
            cbTypeAnimal.Text = "TypeAnimal";
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(31, 118);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(94, 29);
            btnAjouter.TabIndex = 6;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(161, 118);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(94, 29);
            btnModifier.TabIndex = 7;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(286, 118);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(94, 29);
            btnSupprimer.TabIndex = 8;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // dgvAnimaux
            // 
            dgvAnimaux.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimaux.Location = new Point(11, 215);
            dgvAnimaux.Name = "dgvAnimaux";
            dgvAnimaux.RowHeadersWidth = 51;
            dgvAnimaux.Size = new Size(777, 176);
            dgvAnimaux.TabIndex = 9;
            dgvAnimaux.CellClick += dgvAnimaux_CellClick;
            // 
            // AnimalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvAnimaux);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnAjouter);
            Controls.Add(cbTypeAnimal);
            Controls.Add(cbProprietaire);
            Controls.Add(numAge);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNom);
            Name = "AnimalForm";
            Text = "AnimalForm";
            Load += AnimalForm_Load;
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimaux).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.ComboBox cbProprietaire;
        private System.Windows.Forms.ComboBox cbTypeAnimal;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.DataGridView dgvAnimaux;
    }
}
