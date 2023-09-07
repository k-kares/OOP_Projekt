namespace WinForm
{
    partial class ChoosingForm
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
            lblLang = new Label();
            lblChampionship = new Label();
            cbLang = new ComboBox();
            cbChampionship = new ComboBox();
            btnOk = new Button();
            SuspendLayout();
            // 
            // lblLang
            // 
            lblLang.AutoSize = true;
            lblLang.Location = new Point(91, 111);
            lblLang.Name = "lblLang";
            lblLang.Size = new Size(105, 48);
            lblLang.TabIndex = 0;
            lblLang.Text = "Jezik ";
            // 
            // lblChampionship
            // 
            lblChampionship.AutoSize = true;
            lblChampionship.Location = new Point(91, 352);
            lblChampionship.Name = "lblChampionship";
            lblChampionship.Size = new Size(174, 48);
            lblChampionship.TabIndex = 1;
            lblChampionship.Text = "Prvenstvo";
            // 
            // cbLang
            // 
            cbLang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLang.FormattingEnabled = true;
            cbLang.Location = new Point(442, 111);
            cbLang.Name = "cbLang";
            cbLang.Size = new Size(363, 56);
            cbLang.TabIndex = 2;
            // 
            // cbChampionship
            // 
            cbChampionship.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChampionship.FormattingEnabled = true;
            cbChampionship.Location = new Point(442, 352);
            cbChampionship.Name = "cbChampionship";
            cbChampionship.Size = new Size(363, 56);
            cbChampionship.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(400, 530);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(225, 69);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // ChoosingForm
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 715);
            Controls.Add(btnOk);
            Controls.Add(cbChampionship);
            Controls.Add(cbLang);
            Controls.Add(lblChampionship);
            Controls.Add(lblLang);
            Name = "ChoosingForm";
            Text = "ChoosingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLang;
        private Label lblChampionship;
        private ComboBox cbLang;
        private ComboBox cbChampionship;
        private Button btnOk;
    }
}