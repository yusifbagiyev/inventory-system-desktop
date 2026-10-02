namespace Inventory_System.Forms
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.txtFulName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.bunifuElipse_Save = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.lblFullname = new System.Windows.Forms.Label();
            this.lblLang = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFulName
            // 
            this.txtFulName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFulName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtFulName, "txtFulName");
            this.txtFulName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtFulName.Name = "txtFulName";
            this.txtFulName.Enter += new System.EventHandler(this.txtFulName_Enter);
            this.txtFulName.Leave += new System.EventHandler(this.txtFulName_Leave);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bunifuElipse_Save
            // 
            this.bunifuElipse_Save.ElipseRadius = 15;
            this.bunifuElipse_Save.TargetControl = this.btnSave;
            // 
            // cmbLang
            // 
            this.cmbLang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbLang.DropDownHeight = 120;
            resources.ApplyResources(this.cmbLang, "cmbLang");
            this.cmbLang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Items.AddRange(new object[] {
            resources.GetString("cmbLang.Items"),
            resources.GetString("cmbLang.Items1")});
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Sorted = true;
            this.cmbLang.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            this.cmbLang.Enter += new System.EventHandler(this.cmbLang_Enter);
            this.cmbLang.Leave += new System.EventHandler(this.cmbLang_Leave);
            // 
            // lblFullname
            // 
            resources.ApplyResources(this.lblFullname, "lblFullname");
            this.lblFullname.ForeColor = System.Drawing.Color.Black;
            this.lblFullname.Name = "lblFullname";
            // 
            // lblLang
            // 
            resources.ApplyResources(this.lblLang, "lblLang");
            this.lblLang.ForeColor = System.Drawing.Color.Black;
            this.lblLang.Name = "lblLang";
            // 
            // txtOldPass
            // 
            this.txtOldPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtOldPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtOldPass, "txtOldPass");
            this.txtOldPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Enter += new System.EventHandler(this.txtOldPass_Enter);
            this.txtOldPass.Leave += new System.EventHandler(this.txtOldPass_Leave);
            // 
            // txtNewPass
            // 
            this.txtNewPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtNewPass, "txtNewPass");
            this.txtNewPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Enter += new System.EventHandler(this.txtNewPass_Enter);
            this.txtNewPass.Leave += new System.EventHandler(this.txtNewPass_Leave);
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtConfirmPass, "txtConfirmPass");
            this.txtConfirmPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Enter += new System.EventHandler(this.txtConfirmPass_Enter);
            this.txtConfirmPass.Leave += new System.EventHandler(this.txtConfirmPass_Leave);
            // 
            // lblUserId
            // 
            resources.ApplyResources(this.lblUserId, "lblUserId");
            this.lblUserId.ForeColor = System.Drawing.Color.Black;
            this.lblUserId.Name = "lblUserId";
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.lblLang);
            this.Controls.Add(this.lblFullname);
            this.Controls.Add(this.cmbLang);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFulName);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFulName;
        private System.Windows.Forms.Button btnSave;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Save;
        private System.Windows.Forms.ComboBox cmbLang;
        public System.Windows.Forms.Label lblFullname;
        public System.Windows.Forms.Label lblLang;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        public System.Windows.Forms.Label lblUserId;
    }
}