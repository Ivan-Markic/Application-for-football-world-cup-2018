
namespace UserForms.UserControls
{
    partial class ShowPlayerControl
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
            this.components = new System.ComponentModel.Container();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.pbMainPlayer = new System.Windows.Forms.PictureBox();
            this.lblData = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MIMovePlayer = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPlayer)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPlayer
            // 
            this.pbPlayer.Location = new System.Drawing.Point(3, 20);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(60, 60);
            this.pbPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer.TabIndex = 0;
            this.pbPlayer.TabStop = false;
            // 
            // pbMainPlayer
            // 
            this.pbMainPlayer.Location = new System.Drawing.Point(337, 20);
            this.pbMainPlayer.Name = "pbMainPlayer";
            this.pbMainPlayer.Size = new System.Drawing.Size(60, 60);
            this.pbMainPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMainPlayer.TabIndex = 1;
            this.pbMainPlayer.TabStop = false;
            this.pbMainPlayer.Visible = false;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblData.Location = new System.Drawing.Point(89, 38);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(181, 20);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Pero Peric 12 defender";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIMovePlayer});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 28);
            // 
            // MIMovePlayer
            // 
            this.MIMovePlayer.Name = "MIMovePlayer";
            this.MIMovePlayer.Size = new System.Drawing.Size(160, 24);
            this.MIMovePlayer.Text = "Move player";
            // 
            // ShowPlayerControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.pbMainPlayer);
            this.Controls.Add(this.pbPlayer);
            this.Name = "ShowPlayerControl";
            this.Size = new System.Drawing.Size(400, 100);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPlayer)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblData;
        public System.Windows.Forms.PictureBox pbPlayer;
        public System.Windows.Forms.PictureBox pbMainPlayer;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem MIMovePlayer;
    }
}
