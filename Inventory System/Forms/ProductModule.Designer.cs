namespace Inventory_System.Forms
{
    partial class ProductModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductModule));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.txtProdCode = new System.Windows.Forms.TextBox();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.cmbCat = new System.Windows.Forms.ComboBox();
            this.cmbDep = new System.Windows.Forms.ComboBox();
            this.txtWorker = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.NotWorking = new System.Windows.Forms.CheckBox();
            this.NotFound = new System.Windows.Forms.CheckBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblPrint = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.bunifuElipse_Save = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.bunifuElipse_Clear = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.bunifuElipse_Update = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Module = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.prod_id = new System.Windows.Forms.Label();
            this.lblFullname = new System.Windows.Forms.Label();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.lblUserMod = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
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
            // txtProdCode
            // 
            resources.ApplyResources(this.txtProdCode, "txtProdCode");
            this.txtProdCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProdCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtProdCode.Name = "txtProdCode";
            this.txtProdCode.Enter += new System.EventHandler(this.txtProdCode_Enter);
            this.txtProdCode.Leave += new System.EventHandler(this.txtProdCode_Leave);
            // 
            // txtVendor
            // 
            resources.ApplyResources(this.txtVendor, "txtVendor");
            this.txtVendor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVendor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Enter += new System.EventHandler(this.txtVendor_Enter);
            this.txtVendor.Leave += new System.EventHandler(this.txtVendor_Leave);
            // 
            // txtModel
            // 
            resources.ApplyResources(this.txtModel, "txtModel");
            this.txtModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtModel.Name = "txtModel";
            this.txtModel.Enter += new System.EventHandler(this.txtModel_Enter);
            this.txtModel.Leave += new System.EventHandler(this.txtModel_Leave);
            // 
            // cmbCat
            // 
            resources.ApplyResources(this.cmbCat, "cmbCat");
            this.cmbCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbCat.DropDownHeight = 120;
            this.cmbCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cmbCat.FormattingEnabled = true;
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.Sorted = true;
            this.cmbCat.Enter += new System.EventHandler(this.cmbCat_Enter);
            this.cmbCat.Leave += new System.EventHandler(this.cmbCat_Leave);
            // 
            // cmbDep
            // 
            resources.ApplyResources(this.cmbDep, "cmbDep");
            this.cmbDep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbDep.DropDownHeight = 120;
            this.cmbDep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cmbDep.FormattingEnabled = true;
            this.cmbDep.Name = "cmbDep";
            this.cmbDep.Sorted = true;
            this.cmbDep.Enter += new System.EventHandler(this.cmbDep_Enter);
            this.cmbDep.Leave += new System.EventHandler(this.cmbDep_Leave);
            // 
            // txtWorker
            // 
            resources.ApplyResources(this.txtWorker, "txtWorker");
            this.txtWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtWorker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtWorker.Name = "txtWorker";
            this.txtWorker.Enter += new System.EventHandler(this.txtWorker_Enter);
            this.txtWorker.Leave += new System.EventHandler(this.txtWorker_Leave);
            // 
            // txtDesc
            // 
            resources.ApplyResources(this.txtDesc, "txtDesc");
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Enter += new System.EventHandler(this.txtDesc_Enter);
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
            // 
            // NotWorking
            // 
            resources.ApplyResources(this.NotWorking, "NotWorking");
            this.NotWorking.Name = "NotWorking";
            this.NotWorking.UseVisualStyleBackColor = true;
            this.NotWorking.CheckedChanged += new System.EventHandler(this.NotWorking_CheckedChanged);
            // 
            // NotFound
            // 
            resources.ApplyResources(this.NotFound, "NotFound");
            this.NotFound.Name = "NotFound";
            this.NotFound.UseVisualStyleBackColor = true;
            this.NotFound.CheckedChanged += new System.EventHandler(this.NotFound_CheckedChanged);
            // 
            // lblBarcode
            // 
            resources.ApplyResources(this.lblBarcode, "lblBarcode");
            this.lblBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(108)))), ((int)(((byte)(248)))));
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Click += new System.EventHandler(this.lblBarcode_Click);
            // 
            // lblPrint
            // 
            resources.ApplyResources(this.lblPrint, "lblPrint");
            this.lblPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(108)))), ((int)(((byte)(248)))));
            this.lblPrint.Name = "lblPrint";
            this.lblPrint.Click += new System.EventHandler(this.lblPrint_Click);
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
            // bunifuElipse_Save
            // 
            this.bunifuElipse_Save.ElipseRadius = 15;
            this.bunifuElipse_Save.TargetControl = this.btnSave;
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
            // bunifuElipse_Clear
            // 
            this.bunifuElipse_Clear.ElipseRadius = 15;
            this.bunifuElipse_Clear.TargetControl = this.btnClear;
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
            // bunifuElipse_Update
            // 
            this.bunifuElipse_Update.ElipseRadius = 15;
            this.bunifuElipse_Update.TargetControl = this.btnUpdate;
            // 
            // bunifuElipse_Module
            // 
            this.bunifuElipse_Module.ElipseRadius = 20;
            this.bunifuElipse_Module.TargetControl = this;
            // 
            // prod_id
            // 
            resources.ApplyResources(this.prod_id, "prod_id");
            this.prod_id.ForeColor = System.Drawing.Color.Black;
            this.prod_id.Name = "prod_id";
            // 
            // lblFullname
            // 
            resources.ApplyResources(this.lblFullname, "lblFullname");
            this.lblFullname.ForeColor = System.Drawing.Color.Black;
            this.lblFullname.Name = "lblFullname";
            // 
            // picBarcode
            // 
            this.picBarcode.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.picBarcode, "picBarcode");
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.TabStop = false;
            // 
            // lblUserMod
            // 
            resources.ApplyResources(this.lblUserMod, "lblUserMod");
            this.lblUserMod.ForeColor = System.Drawing.Color.Black;
            this.lblUserMod.Name = "lblUserMod";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.ForeColor = System.Drawing.Color.Black;
            this.lblLanguage.Name = "lblLanguage";
            // 
            // ProductModule
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.picBarcode);
            this.Controls.Add(this.prod_id);
            this.Controls.Add(this.lblFullname);
            this.Controls.Add(this.lblUserMod);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPrint);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.NotFound);
            this.Controls.Add(this.NotWorking);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtWorker);
            this.Controls.Add(this.cmbDep);
            this.Controls.Add(this.cmbCat);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtVendor);
            this.Controls.Add(this.txtProdCode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductModule";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductModule_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProductModule_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private System.Windows.Forms.Label lblBarcode;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Save;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Clear;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Update;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Module;
        public System.Windows.Forms.TextBox txtProdCode;
        public System.Windows.Forms.TextBox txtVendor;
        public System.Windows.Forms.TextBox txtModel;
        public System.Windows.Forms.ComboBox cmbCat;
        public System.Windows.Forms.ComboBox cmbDep;
        public System.Windows.Forms.TextBox txtWorker;
        public System.Windows.Forms.TextBox txtDesc;
        public System.Windows.Forms.CheckBox NotWorking;
        public System.Windows.Forms.CheckBox NotFound;
        public System.Windows.Forms.Label lblPrint;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Label prod_id;
        public System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.PictureBox picBarcode;
        public System.Windows.Forms.Label lblUserMod;
        public System.Windows.Forms.Label lblLanguage;
    }
}