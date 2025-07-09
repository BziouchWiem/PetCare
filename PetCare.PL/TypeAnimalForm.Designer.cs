namespace PetCare.PL
{
    partial class TypeAnimalForm
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

        private void InitializeComponent()
        {
            txtLibelle = new TextBox();
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            dgvTypesAnimaux = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTypesAnimaux).BeginInit();
            SuspendLayout();
            // 
            // txtLibelle
            // 
            txtLibelle.Location = new Point(15, 36);
            txtLibelle.Name = "txtLibelle";
            txtLibelle.Size = new Size(200, 27);
            txtLibelle.TabIndex = 0;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(11, 294);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(94, 29);
            btnAjouter.TabIndex = 1;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(121, 294);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(94, 29);
            btnModifier.TabIndex = 2;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(231, 294);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(94, 29);
            btnSupprimer.TabIndex = 3;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // dgvTypesAnimaux
            // 
            dgvTypesAnimaux.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTypesAnimaux.Location = new Point(12, 79);
            dgvTypesAnimaux.Name = "dgvTypesAnimaux";
            dgvTypesAnimaux.RowHeadersWidth = 51;
            dgvTypesAnimaux.Size = new Size(400, 200);
            dgvTypesAnimaux.TabIndex = 4;
            dgvTypesAnimaux.CellClick += dgvTypesAnimaux_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 13);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 5;
            label1.Text = "Type d'animal";
            // 
            // TypeAnimalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 353);
            Controls.Add(label1);
            Controls.Add(dgvTypesAnimaux);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnAjouter);
            Controls.Add(txtLibelle);
            Name = "TypeAnimalForm";
            Text = "TypeAnimalForm";
            Load += TypeAnimalForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTypesAnimaux).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.DataGridView dgvTypesAnimaux;
        private Label label1;
    }
}