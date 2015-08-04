namespace SuperAdventure
{
    partial class SuperAdventure
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuperAdventure));
            this.lblHitPointsStr = new System.Windows.Forms.Label();
            this.lblGoldStr = new System.Windows.Forms.Label();
            this.lblExperienceStr = new System.Windows.Forms.Label();
            this.lblLevelStr = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblSelectAction = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openSavedGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnBank = new System.Windows.Forms.Panel();
            this.txtAvailableGold = new System.Windows.Forms.TextBox();
            this.lblGoldInBank = new System.Windows.Forms.Label();
            this.lblGoldAmount = new System.Windows.Forms.Label();
            this.txtGoldBank = new System.Windows.Forms.TextBox();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.dgvColQuestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColQuestDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnBank.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHitPointsStr
            // 
            resources.ApplyResources(this.lblHitPointsStr, "lblHitPointsStr");
            this.lblHitPointsStr.Name = "lblHitPointsStr";
            // 
            // lblGoldStr
            // 
            resources.ApplyResources(this.lblGoldStr, "lblGoldStr");
            this.lblGoldStr.Name = "lblGoldStr";
            // 
            // lblExperienceStr
            // 
            resources.ApplyResources(this.lblExperienceStr, "lblExperienceStr");
            this.lblExperienceStr.Name = "lblExperienceStr";
            // 
            // lblLevelStr
            // 
            resources.ApplyResources(this.lblLevelStr, "lblLevelStr");
            this.lblLevelStr.Name = "lblLevelStr";
            // 
            // lblHitPoints
            // 
            resources.ApplyResources(this.lblHitPoints, "lblHitPoints");
            this.lblHitPoints.Name = "lblHitPoints";
            // 
            // lblGold
            // 
            resources.ApplyResources(this.lblGold, "lblGold");
            this.lblGold.Name = "lblGold";
            // 
            // lblExperience
            // 
            resources.ApplyResources(this.lblExperience, "lblExperience");
            this.lblExperience.Name = "lblExperience";
            // 
            // lblLevel
            // 
            resources.ApplyResources(this.lblLevel, "lblLevel");
            this.lblLevel.Name = "lblLevel";
            // 
            // lblSelectAction
            // 
            resources.ApplyResources(this.lblSelectAction, "lblSelectAction");
            this.lblSelectAction.Name = "lblSelectAction";
            // 
            // cboWeapons
            // 
            this.cboWeapons.FormattingEnabled = true;
            resources.ApplyResources(this.cboWeapons, "cboWeapons");
            this.cboWeapons.Name = "cboWeapons";
            // 
            // cboPotions
            // 
            this.cboPotions.FormattingEnabled = true;
            resources.ApplyResources(this.cboPotions, "cboPotions");
            this.cboPotions.Name = "cboPotions";
            // 
            // btnUseWeapon
            // 
            resources.ApplyResources(this.btnUseWeapon, "btnUseWeapon");
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // btnUsePotion
            // 
            resources.ApplyResources(this.btnUsePotion, "btnUsePotion");
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.UseVisualStyleBackColor = true;
            this.btnUsePotion.Click += new System.EventHandler(this.btnUsePotion_Click);
            // 
            // btnNorth
            // 
            resources.ApplyResources(this.btnNorth, "btnNorth");
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnEast
            // 
            resources.ApplyResources(this.btnEast, "btnEast");
            this.btnEast.Name = "btnEast";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnWest
            // 
            resources.ApplyResources(this.btnWest, "btnWest");
            this.btnWest.Name = "btnWest";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // btnSouth
            // 
            resources.ApplyResources(this.btnSouth, "btnSouth");
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // rtbLocation
            // 
            resources.ApplyResources(this.rtbLocation, "rtbLocation");
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            // 
            // rtbMessages
            // 
            resources.ApplyResources(this.rtbMessages, "rtbMessages");
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColName,
            this.dgvColQuantity});
            resources.ApplyResources(this.dgvInventory, "dgvInventory");
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            // 
            // dgvColName
            // 
            resources.ApplyResources(this.dgvColName, "dgvColName");
            this.dgvColName.Name = "dgvColName";
            this.dgvColName.ReadOnly = true;
            // 
            // dgvColQuantity
            // 
            resources.ApplyResources(this.dgvColQuantity, "dgvColQuantity");
            this.dgvColQuantity.Name = "dgvColQuantity";
            this.dgvColQuantity.ReadOnly = true;
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColQuestName,
            this.dgvColQuestDone});
            resources.ApplyResources(this.dgvQuests, "dgvQuests");
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openSavedGameToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            resources.ApplyResources(this.newGameToolStripMenuItem, "newGameToolStripMenuItem");
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // openSavedGameToolStripMenuItem
            // 
            this.openSavedGameToolStripMenuItem.Name = "openSavedGameToolStripMenuItem";
            resources.ApplyResources(this.openSavedGameToolStripMenuItem, "openSavedGameToolStripMenuItem");
            this.openSavedGameToolStripMenuItem.Click += new System.EventHandler(this.openSavedGameToolStripMenuItem_Click);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            resources.ApplyResources(this.saveGameToolStripMenuItem, "saveGameToolStripMenuItem");
            this.saveGameToolStripMenuItem.Click += new System.EventHandler(this.saveGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            resources.ApplyResources(this.quitToolStripMenuItem, "quitToolStripMenuItem");
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvInventory);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvQuests);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnBank
            // 
            this.pnBank.Controls.Add(this.txtAvailableGold);
            this.pnBank.Controls.Add(this.lblGoldInBank);
            this.pnBank.Controls.Add(this.lblGoldAmount);
            this.pnBank.Controls.Add(this.txtGoldBank);
            this.pnBank.Controls.Add(this.cboBank);
            this.pnBank.Controls.Add(this.btnTransfer);
            resources.ApplyResources(this.pnBank, "pnBank");
            this.pnBank.Name = "pnBank";
            // 
            // txtAvailableGold
            // 
            resources.ApplyResources(this.txtAvailableGold, "txtAvailableGold");
            this.txtAvailableGold.Name = "txtAvailableGold";
            this.txtAvailableGold.ReadOnly = true;
            // 
            // lblGoldInBank
            // 
            resources.ApplyResources(this.lblGoldInBank, "lblGoldInBank");
            this.lblGoldInBank.Name = "lblGoldInBank";
            // 
            // lblGoldAmount
            // 
            resources.ApplyResources(this.lblGoldAmount, "lblGoldAmount");
            this.lblGoldAmount.Name = "lblGoldAmount";
            // 
            // txtGoldBank
            // 
            resources.ApplyResources(this.txtGoldBank, "txtGoldBank");
            this.txtGoldBank.Name = "txtGoldBank";
            // 
            // cboBank
            // 
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Items.AddRange(new object[] {
            resources.GetString("cboBank.Items"),
            resources.GetString("cboBank.Items1")});
            resources.ApplyResources(this.cboBank, "cboBank");
            this.cboBank.Name = "cboBank";
            // 
            // btnTransfer
            // 
            resources.ApplyResources(this.btnTransfer, "btnTransfer");
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // dgvColQuestName
            // 
            resources.ApplyResources(this.dgvColQuestName, "dgvColQuestName");
            this.dgvColQuestName.Name = "dgvColQuestName";
            this.dgvColQuestName.ReadOnly = true;
            // 
            // dgvColQuestDone
            // 
            resources.ApplyResources(this.dgvColQuestDone, "dgvColQuestDone");
            this.dgvColQuestDone.Name = "dgvColQuestDone";
            this.dgvColQuestDone.ReadOnly = true;
            // 
            // SuperAdventure
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnBank);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.lblSelectAction);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.lblLevelStr);
            this.Controls.Add(this.lblExperienceStr);
            this.Controls.Add(this.lblGoldStr);
            this.Controls.Add(this.lblHitPointsStr);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SuperAdventure";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pnBank.ResumeLayout(false);
            this.pnBank.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHitPointsStr;
        private System.Windows.Forms.Label lblGoldStr;
        private System.Windows.Forms.Label lblExperienceStr;
        private System.Windows.Forms.Label lblLevelStr;
        private System.Windows.Forms.Label lblHitPoints;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblSelectAction;
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.Button btnUsePotion;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.DataGridView dgvQuests;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openSavedGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnBank;
        private System.Windows.Forms.Label lblGoldAmount;
        private System.Windows.Forms.TextBox txtGoldBank;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtAvailableGold;
        private System.Windows.Forms.Label lblGoldInBank;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColQuestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColQuestDone;
    }
}

