
namespace UserForms.Forms
{
    partial class FavouritePlayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouritePlayersForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpMainPlayers = new System.Windows.Forms.TableLayoutPanel();
            this.tlpOtherPlayers = new System.Windows.Forms.TableLayoutPanel();
            this.lblLoadingText = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlpMainPlayers
            // 
            this.tlpMainPlayers.AllowDrop = true;
            resources.ApplyResources(this.tlpMainPlayers, "tlpMainPlayers");
            this.tlpMainPlayers.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlpMainPlayers.Name = "tlpMainPlayers";
            this.tlpMainPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDrop);
            this.tlpMainPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragEnter);
            // 
            // tlpOtherPlayers
            // 
            this.tlpOtherPlayers.AllowDrop = true;
            resources.ApplyResources(this.tlpOtherPlayers, "tlpOtherPlayers");
            this.tlpOtherPlayers.Name = "tlpOtherPlayers";
            this.tlpOtherPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDrop);
            this.tlpOtherPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragEnter);
            // 
            // lblLoadingText
            // 
            resources.ApplyResources(this.lblLoadingText, "lblLoadingText");
            this.lblLoadingText.Name = "lblLoadingText";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // FavouritePlayersForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLoadingText);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tlpOtherPlayers);
            this.Controls.Add(this.tlpMainPlayers);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FavouritePlayersForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FavouritePlayersForm_FormClosing);
            this.Load += new System.EventHandler(this.FavouritePlayersForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpMainPlayers;
        private System.Windows.Forms.TableLayoutPanel tlpOtherPlayers;
        private System.Windows.Forms.Label lblLoadingText;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}