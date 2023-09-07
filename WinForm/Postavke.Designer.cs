namespace WinForm
{
    partial class Postavke
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
            cbChampionship = new ComboBox();
            cbLang = new ComboBox();
            lblChampionship = new Label();
            lblLang = new Label();
            btnAccept = new Button();
            btnDecline = new Button();
            SuspendLayout();
            // 
            // cbChampionship
            // 
            cbChampionship.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChampionship.FormattingEnabled = true;
            cbChampionship.Location = new Point(488, 376);
            cbChampionship.Name = "cbChampionship";
            cbChampionship.Size = new Size(363, 56);
            cbChampionship.TabIndex = 7;
            // 
            // cbLang
            // 
            cbLang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLang.FormattingEnabled = true;
            cbLang.Location = new Point(488, 135);
            cbLang.Name = "cbLang";
            cbLang.Size = new Size(363, 56);
            cbLang.TabIndex = 6;
            // 
            // lblChampionship
            // 
            lblChampionship.AutoSize = true;
            lblChampionship.Location = new Point(137, 376);
            lblChampionship.Name = "lblChampionship";
            lblChampionship.Size = new Size(174, 48);
            lblChampionship.TabIndex = 5;
            lblChampionship.Text = "Prvenstvo";
            // 
            // lblLang
            // 
            lblLang.AutoSize = true;
            lblLang.Location = new Point(137, 135);
            lblLang.Name = "lblLang";
            lblLang.Size = new Size(105, 48);
            lblLang.TabIndex = 4;
            lblLang.Text = "Jezik ";
            // 
            // btnAccept
            // 
            btnAccept.DialogResult = DialogResult.OK;
            btnAccept.Location = new Point(109, 508);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(262, 110);
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Potvrdi";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnDecline
            // 
            btnDecline.Location = new Point(663, 508);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(262, 110);
            btnDecline.TabIndex = 9;
            btnDecline.Text = "Odustani ";
            btnDecline.UseVisualStyleBackColor = true;
            btnDecline.Click += BtnDecline_Click;
            // 
            // Postavke
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnDecline;
            ClientSize = new Size(1089, 724);
            Controls.Add(btnDecline);
            Controls.Add(btnAccept);
            Controls.Add(cbChampionship);
            Controls.Add(cbLang);
            Controls.Add(lblChampionship);
            Controls.Add(lblLang);
            Name = "Postavke";
            Text = "Postavke";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbChampionship;
        private ComboBox cbLang;
        private Label lblChampionship;
        private Label lblLang;
        private Button btnAccept;
        private Button btnDecline;
    }
}