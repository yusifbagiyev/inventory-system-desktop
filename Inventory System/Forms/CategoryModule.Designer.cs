namespace Inventory_System.Forms
{
    partial class CategoryModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryModule));
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.bunifuElipse_Save = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Update = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Clear = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Module = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblFullname = new System.Windows.Forms.Label();
            this.txtCatId = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.ImageActive = null;
            this.btnExit.Name = "btnExit";
            this.btnExit.TabStop = false;
            this.btnExit.Zoom = 10;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // txtCatName
            // 
            resources.ApplyResources(this.txtCatName, "txtCatName");
            this.txtCatName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCatName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Enter += new System.EventHandler(this.TxtCatName_Enter);
            this.txtCatName.Leave += new System.EventHandler(this.TxtCatName_Leave);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(120)))), ((int)(((byte)(32)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(50)))), ((int)(((byte)(61)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // bunifuElipse_Save
            // 
            this.bunifuElipse_Save.ElipseRadius = 15;
            this.bunifuElipse_Save.TargetControl = this.btnSave;
            // 
            // bunifuElipse_Update
            // 
            this.bunifuElipse_Update.ElipseRadius = 15;
            this.bunifuElipse_Update.TargetControl = this.btnUpdate;
            // 
            // bunifuElipse_Clear
            // 
            this.bunifuElipse_Clear.ElipseRadius = 15;
            this.bunifuElipse_Clear.TargetControl = this.btnClear;
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
            // txtCatId
            // 
            resources.ApplyResources(this.txtCatId, "txtCatId");
            this.txtCatId.ForeColor = System.Drawing.Color.Black;
            this.txtCatId.Name = "txtCatId";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.ForeColor = System.Drawing.Color.Black;
            this.lblLanguage.Name = "lblLanguage";
            // 
            // CategoryModule
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.txtCatId);
            this.Controls.Add(this.lblFullname);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CategoryModule";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CategoryModule_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CategoryModule_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Save;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Update;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Clear;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Module;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Label txtCatId;
        public System.Windows.Forms.Label lblFullname;
        public System.Windows.Forms.TextBox txtCatName;
        public System.Windows.Forms.Label lblLanguage;
    }
}