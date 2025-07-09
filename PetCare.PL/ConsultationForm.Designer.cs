namespace PetCare.PL
{
    partial class ConsultationForm
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
            cbAnimal = new ComboBox();
            cbVeterinaire = new ComboBox();
            dtDate = new DateTimePicker();
            txtDiagnostic = new TextBox();
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            dgvConsultations = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvConsultations).BeginInit();
            SuspendLayout();
            // 
            // cbAnimal
            // 
            cbAnimal.FormattingEnabled = true;
            cbAnimal.Location = new Point(30, 30);
            cbAnimal.Name = "cbAnimal";
            cbAnimal.Size = new Size(150, 28);
            cbAnimal.TabIndex = 0;
            // 
            // cbVeterinaire
            // 
            cbVeterinaire.FormattingEnabled = true;
            cbVeterinaire.Location = new Point(200, 30);
            cbVeterinaire.Name = "cbVeterinaire";
            cbVeterinaire.Size = new Size(150, 28);
            cbVeterinaire.TabIndex = 1;
            // 
            // dtDate
            // 
            dtDate.Location = new Point(370, 30);
            dtDate.Name = "dtDate";
            dtDate.Size = new Size(250, 27);
            dtDate.TabIndex = 2;
            // 
            // txtDiagnostic
            // 
            txtDiagnostic.Location = new Point(30, 94);
            txtDiagnostic.Name = "txtDiagnostic";
            txtDiagnostic.Size = new Size(590, 27);
            txtDiagnostic.TabIndex = 3;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(30, 139);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(94, 29);
            btnAjouter.TabIndex = 4;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(150, 139);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(94, 29);
            btnModifier.TabIndex = 5;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(270, 139);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(94, 29);
            btnSupprimer.TabIndex = 6;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // dgvConsultations
            // 
            dgvConsultations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultations.Location = new Point(30, 189);
            dgvConsultations.Name = "dgvConsultations";
            dgvConsultations.RowHeadersWidth = 51;
            dgvConsultations.Size = new Size(590, 200);
            dgvConsultations.TabIndex = 7;
            dgvConsultations.CellClick += dgvConsultations_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 7);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 8;
            label1.Text = "Animal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 9);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 9;
            label2.Text = "Veterinaire";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(370, 9);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 10;
            label3.Text = "Date consultaion ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 71);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 11;
            label4.Text = "Diagnostique ";
            // 
            // ConsultationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 400);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvConsultations);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnAjouter);
            Controls.Add(txtDiagnostic);
            Controls.Add(dtDate);
            Controls.Add(cbVeterinaire);
            Controls.Add(cbAnimal);
            Name = "ConsultationForm";
            Text = "ConsultationForm";
            Load += ConsultationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ComboBox cbAnimal;
        private System.Windows.Forms.ComboBox cbVeterinaire;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.TextBox txtDiagnostic;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.DataGridView dgvConsultations;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}