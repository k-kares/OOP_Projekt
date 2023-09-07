namespace WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            contextMenuStripRemove = new ContextMenuStrip(components);
            removeToolStripMenuItem = new ToolStripMenuItem();
            addImageToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStripAdd = new ContextMenuStrip(components);
            addToolStripMenuItem = new ToolStripMenuItem();
            addImageToolStripMenuItem1 = new ToolStripMenuItem();
            tabPage3 = new TabPage();
            lblRankGoals = new Label();
            lblRankCards = new Label();
            lbRankCards = new ListBox();
            lbRankGoals = new ListBox();
            lbRankGames = new ListBox();
            btnSettings3 = new Button();
            btnPrint = new Button();
            lblRankGame = new Label();
            tabPage1 = new TabPage();
            btnSetRep = new Button();
            lblFavPlayers = new Label();
            lblAllPlayers = new Label();
            flpFavPlayers = new FlowLayoutPanel();
            playerControl1 = new PlayerControl();
            playerControl2 = new PlayerControl();
            playerControl3 = new PlayerControl();
            flpAllPlayers = new FlowLayoutPanel();
            btnSettings = new Button();
            cbFavRep = new ComboBox();
            lblRep = new Label();
            tabControl1 = new TabControl();
            printDocument = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog = new PrintPreviewDialog();
            contextMenuStripRemove.SuspendLayout();
            contextMenuStripAdd.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage1.SuspendLayout();
            flpFavPlayers.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStripRemove
            // 
            contextMenuStripRemove.ImageScalingSize = new Size(48, 48);
            contextMenuStripRemove.Items.AddRange(new ToolStripItem[] { removeToolStripMenuItem, addImageToolStripMenuItem });
            contextMenuStripRemove.Name = "contextMenuStripRemove";
            resources.ApplyResources(contextMenuStripRemove, "contextMenuStripRemove");
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(removeToolStripMenuItem, "removeToolStripMenuItem");
            removeToolStripMenuItem.Click += RemoveToolStripMenuItem_Click;
            // 
            // addImageToolStripMenuItem
            // 
            addImageToolStripMenuItem.Name = "addImageToolStripMenuItem";
            resources.ApplyResources(addImageToolStripMenuItem, "addImageToolStripMenuItem");
            addImageToolStripMenuItem.Click += AddImageToolStripMenuItem_Click;
            // 
            // contextMenuStripAdd
            // 
            contextMenuStripAdd.ImageScalingSize = new Size(48, 48);
            contextMenuStripAdd.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, addImageToolStripMenuItem1 });
            contextMenuStripAdd.Name = "contextMenuStripAdd";
            resources.ApplyResources(contextMenuStripAdd, "contextMenuStripAdd");
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            resources.ApplyResources(addToolStripMenuItem, "addToolStripMenuItem");
            addToolStripMenuItem.Click += AddToolStripMenuItem_Click;
            // 
            // addImageToolStripMenuItem1
            // 
            addImageToolStripMenuItem1.Name = "addImageToolStripMenuItem1";
            resources.ApplyResources(addImageToolStripMenuItem1, "addImageToolStripMenuItem1");
            addImageToolStripMenuItem1.Click += AddImageToolStripMenuItem1_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(lblRankGoals);
            tabPage3.Controls.Add(lblRankCards);
            tabPage3.Controls.Add(lbRankCards);
            tabPage3.Controls.Add(lbRankGoals);
            tabPage3.Controls.Add(lbRankGames);
            tabPage3.Controls.Add(btnSettings3);
            tabPage3.Controls.Add(btnPrint);
            tabPage3.Controls.Add(lblRankGame);
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Name = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblRankGoals
            // 
            resources.ApplyResources(lblRankGoals, "lblRankGoals");
            lblRankGoals.Name = "lblRankGoals";
            // 
            // lblRankCards
            // 
            resources.ApplyResources(lblRankCards, "lblRankCards");
            lblRankCards.Name = "lblRankCards";
            // 
            // lbRankCards
            // 
            lbRankCards.FormattingEnabled = true;
            resources.ApplyResources(lbRankCards, "lbRankCards");
            lbRankCards.Name = "lbRankCards";
            // 
            // lbRankGoals
            // 
            lbRankGoals.FormattingEnabled = true;
            resources.ApplyResources(lbRankGoals, "lbRankGoals");
            lbRankGoals.Name = "lbRankGoals";
            // 
            // lbRankGames
            // 
            lbRankGames.FormattingEnabled = true;
            resources.ApplyResources(lbRankGames, "lbRankGames");
            lbRankGames.Name = "lbRankGames";
            // 
            // btnSettings3
            // 
            resources.ApplyResources(btnSettings3, "btnSettings3");
            btnSettings3.Name = "btnSettings3";
            btnSettings3.UseVisualStyleBackColor = true;
            btnSettings3.Click += BtnSettings_Click;
            // 
            // btnPrint
            // 
            resources.ApplyResources(btnPrint, "btnPrint");
            btnPrint.Name = "btnPrint";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += BtnPrint_Click;
            // 
            // lblRankGame
            // 
            resources.ApplyResources(lblRankGame, "lblRankGame");
            lblRankGame.Name = "lblRankGame";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnSetRep);
            tabPage1.Controls.Add(lblFavPlayers);
            tabPage1.Controls.Add(lblAllPlayers);
            tabPage1.Controls.Add(flpFavPlayers);
            tabPage1.Controls.Add(flpAllPlayers);
            tabPage1.Controls.Add(btnSettings);
            tabPage1.Controls.Add(cbFavRep);
            tabPage1.Controls.Add(lblRep);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSetRep
            // 
            resources.ApplyResources(btnSetRep, "btnSetRep");
            btnSetRep.Name = "btnSetRep";
            btnSetRep.UseVisualStyleBackColor = true;
            btnSetRep.Click += BtnSetRep_Click;
            // 
            // lblFavPlayers
            // 
            resources.ApplyResources(lblFavPlayers, "lblFavPlayers");
            lblFavPlayers.Name = "lblFavPlayers";
            // 
            // lblAllPlayers
            // 
            resources.ApplyResources(lblAllPlayers, "lblAllPlayers");
            lblAllPlayers.Name = "lblAllPlayers";
            // 
            // flpFavPlayers
            // 
            resources.ApplyResources(flpFavPlayers, "flpFavPlayers");
            flpFavPlayers.Controls.Add(playerControl1);
            flpFavPlayers.Controls.Add(playerControl2);
            flpFavPlayers.Controls.Add(playerControl3);
            flpFavPlayers.Name = "flpFavPlayers";
            // 
            // playerControl1
            // 
            playerControl1.AllowDrop = true;
            playerControl1.BorderStyle = BorderStyle.FixedSingle;
            playerControl1.ContextMenuStrip = contextMenuStripRemove;
            resources.ApplyResources(playerControl1, "playerControl1");
            playerControl1.Name = "playerControl1";
            playerControl1.DragDrop += PlayerControl1_DragDrop;
            playerControl1.DragEnter += PlayerControl1_DragEnter;
            playerControl1.MouseDown += PlayerControl1_MouseDown;
            // 
            // playerControl2
            // 
            playerControl2.AllowDrop = true;
            playerControl2.BorderStyle = BorderStyle.FixedSingle;
            playerControl2.ContextMenuStrip = contextMenuStripRemove;
            resources.ApplyResources(playerControl2, "playerControl2");
            playerControl2.Name = "playerControl2";
            playerControl2.DragDrop += PlayerControl1_DragDrop;
            playerControl2.DragEnter += PlayerControl1_DragEnter;
            playerControl2.MouseDown += PlayerControl1_MouseDown;
            // 
            // playerControl3
            // 
            playerControl3.AllowDrop = true;
            playerControl3.BorderStyle = BorderStyle.FixedSingle;
            playerControl3.ContextMenuStrip = contextMenuStripRemove;
            resources.ApplyResources(playerControl3, "playerControl3");
            playerControl3.Name = "playerControl3";
            playerControl3.DragDrop += PlayerControl1_DragDrop;
            playerControl3.DragEnter += PlayerControl1_DragEnter;
            playerControl3.MouseDown += PlayerControl1_MouseDown;
            // 
            // flpAllPlayers
            // 
            flpAllPlayers.AllowDrop = true;
            resources.ApplyResources(flpAllPlayers, "flpAllPlayers");
            flpAllPlayers.Name = "flpAllPlayers";
            // 
            // btnSettings
            // 
            resources.ApplyResources(btnSettings, "btnSettings");
            btnSettings.Name = "btnSettings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += BtnSettings_Click;
            // 
            // cbFavRep
            // 
            cbFavRep.FormattingEnabled = true;
            resources.ApplyResources(cbFavRep, "cbFavRep");
            cbFavRep.Name = "cbFavRep";
            // 
            // lblRep
            // 
            resources.ApplyResources(lblRep, "lblRep");
            lblRep.Name = "lblRep";
            // 
            // tabControl1
            // 
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            // 
            // printDocument
            // 
            printDocument.PrintPage += PrintDocument_PrintPage;
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(printPreviewDialog, "printPreviewDialog");
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Name = "printPreviewDialog";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStripRemove.ResumeLayout(false);
            contextMenuStripAdd.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            flpFavPlayers.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStripAdd;
        private ToolStripMenuItem addToolStripMenuItem;
        private ContextMenuStrip contextMenuStripRemove;
        private ToolStripMenuItem removeToolStripMenuItem;
        private TabPage tabPage3;
        private ListBox lbRankGames;
        private Button btnSettings3;
        private Button btnPrint;
        private Label lblRankGame;
        private TabPage tabPage1;
        private Button btnSetRep;
        private Label lblFavPlayers;
        private Label lblAllPlayers;
        private FlowLayoutPanel flpFavPlayers;
        private PlayerControl playerControl1;
        private PlayerControl playerControl2;
        private PlayerControl playerControl3;
        private FlowLayoutPanel flpAllPlayers;
        private Button btnSettings;
        private ComboBox cbFavRep;
        private Label lblRep;
        private TabControl tabControl1;
        private ToolStripMenuItem addImageToolStripMenuItem;
        private ToolStripMenuItem addImageToolStripMenuItem1;
        private Label lblRankGoals;
        private Label lblRankCards;
        private ListBox lbRankCards;
        private ListBox lbRankGoals;
        private System.Drawing.Printing.PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
    }
}