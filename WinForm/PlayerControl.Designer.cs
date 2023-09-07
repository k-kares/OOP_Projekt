namespace WinForm
{
    partial class PlayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            pictureBox1 = new PictureBox();
            lblPlayerName = new Label();
            lblPosition = new Label();
            lblNumber = new Label();
            lblCaptain = new Label();
            lblFavourite = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(366, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            
            // 
            // lblPlayerName
            // 
            lblPlayerName.AutoSize = true;
            lblPlayerName.Location = new Point(406, 49);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new Size(98, 48);
            lblPlayerName.TabIndex = 1;
            lblPlayerName.Text = "Ime: ";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(406, 299);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(146, 48);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "Pozicija:";
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Location = new Point(697, 299);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(102, 48);
            lblNumber.TabIndex = 3;
            lblNumber.Text = "Broj: ";
            // 
            // lblCaptain
            // 
            lblCaptain.AutoSize = true;
            lblCaptain.Location = new Point(406, 177);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(157, 48);
            lblCaptain.TabIndex = 4;
            lblCaptain.Text = "Kapetan:";
            // 
            // lblFavourite
            // 
            lblFavourite.AutoSize = true;
            lblFavourite.Location = new Point(3, 0);
            lblFavourite.Name = "lblFavourite";
            lblFavourite.Size = new Size(0, 48);
            lblFavourite.TabIndex = 5;
            // 
            // PlayerControl
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblFavourite);
            Controls.Add(lblCaptain);
            Controls.Add(lblNumber);
            Controls.Add(lblPosition);
            Controls.Add(lblPlayerName);
            Controls.Add(pictureBox1);
            Name = "PlayerControl";
            Size = new Size(948, 398);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public PictureBox pictureBox1;
        public Label lblPlayerName;
        public Label lblPosition;
        public Label lblNumber;
        public Label lblCaptain;
        public Label lblFavourite;
    }
}
