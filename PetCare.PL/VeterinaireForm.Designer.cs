namespace PetCare.PL
{
    partial class VeterinaireForm
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
            txtNom = new TextBox();
            txtSpecialite = new TextBox();
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            dgvVeterinaires = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvVeterinaires).BeginInit();
            SuspendLayout();
            // 
            // txtNom
            // 
            txtNom.Location = new Point(16, 30);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(200, 27);
            txtNom.TabIndex = 0;
            // 
            // txtSpecialite
            // 
            txtSpecialite.Location = new Point(236, 30);
            txtSpecialite.Name = "txtSpecialite";
            txtSpecialite.Size = new Size(200, 27);
            txtSpecialite.TabIndex = 1;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(16, 293);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(94, 29);
            btnAjouter.TabIndex = 2;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(136, 293);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(94, 29);
            btnModifier.TabIndex = 3;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(256, 293);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(94, 29);
            btnSupprimer.TabIndex = 4;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // dgvVeterinaires
            // 
            dgvVeterinaires.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVeterinaires.Location = new Point(16, 77);
            dgvVeterinaires.Name = "dgvVeterinaires";
            dgvVeterinaires.RowHeadersWidth = 51;
            dgvVeterinaires.Size = new Size(420, 200);
            dgvVeterinaires.TabIndex = 5;
            dgvVeterinaires.CellClick += dgvVeterinaires_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 7);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 6;
            label1.Text = "Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 9);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 7;
            label2.Text = "Spécialité";
            // 
            // VeterinaireForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 360);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvVeterinaires);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnAjouter);
            Controls.Add(txtSpecialite);
            Controls.Add(txtNom);
            Name = "VeterinaireForm";
            Text = "VeterinaireForm";
            Load += VeterinaireForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVeterinaires).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtSpecialite;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.DataGridView dgvVeterinaires;
        private Label label1;
        private Label label2;
    }
}