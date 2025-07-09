namespace PetCare.PL
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnProprietaire = new Button();
            btnAnimal = new Button();
            btnTypeAnimal = new Button();
            btnVeterinaire = new Button();
            btnConsultation = new Button();
            SuspendLayout();
            // 
            // btnProprietaire
            // 
            btnProprietaire.Location = new Point(12, 137);
            btnProprietaire.Name = "btnProprietaire";
            btnProprietaire.Size = new Size(174, 29);
            btnProprietaire.TabIndex = 0;
            btnProprietaire.Text = "Gérer Propriétaires";
            btnProprietaire.UseVisualStyleBackColor = true;
            btnProprietaire.Click += btnProprietaire_Click;
            // 
            // btnAnimal
            // 
            btnAnimal.Location = new Point(12, 88);
            btnAnimal.Name = "btnAnimal";
            btnAnimal.Size = new Size(172, 29);
            btnAnimal.TabIndex = 1;
            btnAnimal.Text = "Gérer Animaux";
            btnAnimal.UseVisualStyleBackColor = true;
            btnAnimal.Click += btnAnimal_Click;
            // 
            // btnTypeAnimal
            // 
            btnTypeAnimal.Location = new Point(10, 226);
            btnTypeAnimal.Name = "btnTypeAnimal";
            btnTypeAnimal.Size = new Size(174, 29);
            btnTypeAnimal.TabIndex = 2;
            btnTypeAnimal.Text = "Gérer Types Animaux";
            btnTypeAnimal.UseVisualStyleBackColor = true;
            btnTypeAnimal.Click += btnTypeAnimal_Click;
            // 
            // btnVeterinaire
            // 
            btnVeterinaire.Location = new Point(12, 266);
            btnVeterinaire.Name = "btnVeterinaire";
            btnVeterinaire.Size = new Size(174, 29);
            btnVeterinaire.TabIndex = 3;
            btnVeterinaire.Text = "Gérer Vétérinaires";
            btnVeterinaire.UseVisualStyleBackColor = true;
            btnVeterinaire.Click += btnVeterinaire_Click;
            // 
            // btnConsultation
            // 
            btnConsultation.Location = new Point(12, 182);
            btnConsultation.Name = "btnConsultation";
            btnConsultation.Size = new Size(174, 29);
            btnConsultation.TabIndex = 4;
            btnConsultation.Text = "Gérer Consultations";
            btnConsultation.UseVisualStyleBackColor = true;
            btnConsultation.Click += btnConsultation_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConsultation);
            Controls.Add(btnVeterinaire);
            Controls.Add(btnTypeAnimal);
            Controls.Add(btnAnimal);
            Controls.Add(btnProprietaire);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnProprietaire;
        private Button btnAnimal;
        private Button btnTypeAnimal;
        private Button btnVeterinaire;
        private Button btnConsultation;
    }
}
