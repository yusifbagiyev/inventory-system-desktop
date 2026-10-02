namespace Inventory_System.Forms
{
    partial class UserModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserModule));
            this.bunifuElipse_Module = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblFullname = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbUsertype = new System.Windows.Forms.ComboBox();
            this.bunifuElipse_Savee = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse__Update = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse__Clear = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.txtPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtConfirmPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtUserId = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse_Module
            // 
            this.bunifuElipse_Module.ElipseRadius = 20;
            this.bunifuElipse_Module.TargetControl = this;
            // 
            // lblFullname
            // 
            resources.ApplyResources(this.lblFullname, "lblFullname");
            this.lblFullname.ForeColor = System.Drawing.Color.Black;
            this.lblFullname.Name = "lblFullname";
            // 
            // txtFullname
            // 
            resources.ApplyResources(this.txtFullname, "txtFullname");
            this.txtFullname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Enter += new System.EventHandler(this.txtFullname_Enter);
            this.txtFullname.Leave += new System.EventHandler(this.txtFullname_Leave);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(120)))), ((int)(((byte)(32)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(50)))), ((int)(((byte)(61)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.ImageActive = null;
            this.btnExit.Name = "btnExit";
            this.btnExit.TabStop = false;
            this.btnExit.Zoom = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // cmbUsertype
            // 
            resources.ApplyResources(this.cmbUsertype, "cmbUsertype");
            this.cmbUsertype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUsertype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsertype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbUsertype.DropDownHeight = 120;
            this.cmbUsertype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cmbUsertype.FormattingEnabled = true;
            this.cmbUsertype.Items.AddRange(new object[] {
            resources.GetString("cmbUsertype.Items"),
            resources.GetString("cmbUsertype.Items1")});
            this.cmbUsertype.Name = "cmbUsertype";
            this.cmbUsertype.Sorted = true;
            this.cmbUsertype.Enter += new System.EventHandler(this.cmbUsertype_Enter);
            this.cmbUsertype.Leave += new System.EventHandler(this.cmbUsertype_Leave);
            // 
            // bunifuElipse_Savee
            // 
            this.bunifuElipse_Savee.ElipseRadius = 15;
            this.bunifuElipse_Savee.TargetControl = this.btnSave;
            // 
            // bunifuElipse__Update
            // 
            this.bunifuElipse__Update.ElipseRadius = 15;
            this.bunifuElipse__Update.TargetControl = this.btnUpdate;
            // 
            // bunifuElipse__Clear
            // 
            this.bunifuElipse__Clear.ElipseRadius = 15;
            this.bunifuElipse__Clear.TargetControl = this.btnClear;
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtPassword.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtPassword.HintText = "";
            this.txtPassword.isPassword = false;
            this.txtPassword.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txtPassword.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txtPassword.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txtPassword.LineThickness = 4;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtConfirmPass
            // 
            resources.ApplyResources(this.txtConfirmPass, "txtConfirmPass");
            this.txtConfirmPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txtConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtConfirmPass.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtConfirmPass.HintText = "";
            this.txtConfirmPass.isPassword = false;
            this.txtConfirmPass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txtConfirmPass.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txtConfirmPass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.txtConfirmPass.LineThickness = 4;
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtConfirmPass.Enter += new System.EventHandler(this.txtConfirmPass_Enter);
            this.txtConfirmPass.Leave += new System.EventHandler(this.txtConfirmPass_Leave);
            // 
            // txtUserId
            // 
            resources.ApplyResources(this.txtUserId, "txtUserId");
            this.txtUserId.ForeColor = System.Drawing.Color.Black;
            this.txtUserId.Name = "txtUserId";
            // 
            // lblLanguage
            // 
            this.lblLanguage.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // UserModule
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cmbUsertype);
            this.Controls.Add(this.lblFullname);
            this.Controls.Add(this.txtFullname);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserModule";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserModule_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserModule_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Module;
        public System.Windows.Forms.Label lblFullname;
        public System.Windows.Forms.TextBox txtFullname;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnClear;
        private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.ComboBox cmbUsertype;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Savee;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse__Update;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse__Clear;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtPassword;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtConfirmPass;
        public System.Windows.Forms.Label txtUserId;
        public System.Windows.Forms.Label lblLanguage;
    }
}