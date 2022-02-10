
namespace UserForms.Forms
{
    partial class RangListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangListForm));
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attendance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.PictureOfPlayer = new System.Windows.Forms.DataGridViewImageColumn();
            this.Players = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Goals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YellowCards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.lblData = new System.Windows.Forms.Label();
            this.lblPercentage2 = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPreview
            // 
            resources.ApplyResources(this.btnPreview, "btnPreview");
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvMatches
            // 
            this.dgvMatches.AllowUserToAddRows = false;
            this.dgvMatches.AllowUserToDeleteRows = false;
            this.dgvMatches.AllowUserToResizeColumns = false;
            this.dgvMatches.AllowUserToResizeRows = false;
            this.dgvMatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMatches.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMatches.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMatches.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.location,
            this.Attendance,
            this.HomeTeam,
            this.awayTeam});
            this.dgvMatches.GridColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.dgvMatches, "dgvMatches");
            this.dgvMatches.MultiSelect = false;
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.ReadOnly = true;
            this.dgvMatches.RowHeadersVisible = false;
            this.dgvMatches.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvMatches.RowTemplate.Height = 24;
            this.dgvMatches.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // location
            // 
            resources.ApplyResources(this.location, "location");
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // Attendance
            // 
            resources.ApplyResources(this.Attendance, "Attendance");
            this.Attendance.Name = "Attendance";
            this.Attendance.ReadOnly = true;
            // 
            // HomeTeam
            // 
            resources.ApplyResources(this.HomeTeam, "HomeTeam");
            this.HomeTeam.Name = "HomeTeam";
            this.HomeTeam.ReadOnly = true;
            // 
            // awayTeam
            // 
            resources.ApplyResources(this.awayTeam, "awayTeam");
            this.awayTeam.Name = "awayTeam";
            this.awayTeam.ReadOnly = true;
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AllowUserToResizeColumns = false;
            this.dgvPlayers.AllowUserToResizeRows = false;
            this.dgvPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPlayers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPlayers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPlayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PictureOfPlayer,
            this.Players,
            this.Goals,
            this.YellowCards});
            this.dgvPlayers.GridColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.dgvPlayers, "dgvPlayers");
            this.dgvPlayers.MultiSelect = false;
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.RowHeadersVisible = false;
            this.dgvPlayers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvPlayers.RowTemplate.Height = 80;
            this.dgvPlayers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlayers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlayers_CellDoubleClick);
            this.dgvPlayers.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // PictureOfPlayer
            // 
            this.PictureOfPlayer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.PictureOfPlayer, "PictureOfPlayer");
            this.PictureOfPlayer.Name = "PictureOfPlayer";
            this.PictureOfPlayer.ReadOnly = true;
            this.PictureOfPlayer.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Players
            // 
            resources.ApplyResources(this.Players, "Players");
            this.Players.Name = "Players";
            this.Players.ReadOnly = true;
            this.Players.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Goals
            // 
            resources.ApplyResources(this.Goals, "Goals");
            this.Goals.Name = "Goals";
            this.Goals.ReadOnly = true;
            this.Goals.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // YellowCards
            // 
            resources.ApplyResources(this.YellowCards, "YellowCards");
            this.YellowCards.Name = "YellowCards";
            this.YellowCards.ReadOnly = true;
            this.YellowCards.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Name = "printPreviewDialog";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // lblData
            // 
            resources.ApplyResources(this.lblData, "lblData");
            this.lblData.Name = "lblData";
            // 
            // lblPercentage2
            // 
            resources.ApplyResources(this.lblPercentage2, "lblPercentage2");
            this.lblPercentage2.Name = "lblPercentage2";
            // 
            // lblPercentage
            // 
            resources.ApplyResources(this.lblPercentage, "lblPercentage");
            this.lblPercentage.Name = "lblPercentage";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // RangListForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblPercentage2);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvMatches);
            this.Controls.Add(this.dgvPlayers);
            this.Name = "RangListForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RangListForm_FormClosing);
            this.Load += new System.EventHandler(this.RangListForm_Load);
            this.Resize += new System.EventHandler(this.RangListForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvMatches;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.DataGridViewImageColumn PictureOfPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Players;
        private System.Windows.Forms.DataGridViewTextBoxColumn Goals;
        private System.Windows.Forms.DataGridViewTextBoxColumn YellowCards;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn awayTeam;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblPercentage2;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}