namespace Inventory_System.Forms
{
    partial class RouteModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteModel));
            this.txtFrmWorker = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.cmbToDep = new System.Windows.Forms.ComboBox();
            this.cmbFrmDep = new System.Windows.Forms.ComboBox();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtProdCode = new System.Windows.Forms.TextBox();
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtToWorker = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.bunifuElipse_Save = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Clear = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Update = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse_Route = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblRouteId = new System.Windows.Forms.Label();
            this.lblFullname = new System.Windows.Forms.Label();
            this.lblUserMod = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.lblLanguage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFrmWorker
            // 
            resources.ApplyResources(this.txtFrmWorker, "txtFrmWorker");
            this.txtFrmWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFrmWorker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFrmWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtFrmWorker.Name = "txtFrmWorker";
            this.txtFrmWorker.Enter += new System.EventHandler(this.txtFrmWorker_Enter);
            this.txtFrmWorker.Leave += new System.EventHandler(this.txtFrmWorker_Leave);
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
            // cmbToDep
            // 
            resources.ApplyResources(this.cmbToDep, "cmbToDep");
            this.cmbToDep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbToDep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbToDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbToDep.DropDownHeight = 120;
            this.cmbToDep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cmbToDep.FormattingEnabled = true;
            this.cmbToDep.Name = "cmbToDep";
            this.cmbToDep.Sorted = true;
            this.cmbToDep.Enter += new System.EventHandler(this.cmbToDep_Enter);
            this.cmbToDep.Leave += new System.EventHandler(this.cmbToDep_Leave);
            // 
            // cmbFrmDep
            // 
            resources.ApplyResources(this.cmbFrmDep, "cmbFrmDep");
            this.cmbFrmDep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFrmDep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFrmDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbFrmDep.DropDownHeight = 120;
            this.cmbFrmDep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.cmbFrmDep.FormattingEnabled = true;
            this.cmbFrmDep.Name = "cmbFrmDep";
            this.cmbFrmDep.Sorted = true;
            this.cmbFrmDep.Enter += new System.EventHandler(this.cmbFrmDep_Enter);
            this.cmbFrmDep.Leave += new System.EventHandler(this.cmbFrmDep_Leave);
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
            // txtCategory
            // 
            resources.ApplyResources(this.txtCategory, "txtCategory");
            this.txtCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Enter += new System.EventHandler(this.txtCategory_Enter);
            this.txtCategory.Leave += new System.EventHandler(this.txtCategory_Leave);
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
            // txtToWorker
            // 
            resources.ApplyResources(this.txtToWorker, "txtToWorker");
            this.txtToWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtToWorker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txtToWorker.Name = "txtToWorker";
            this.txtToWorker.Enter += new System.EventHandler(this.txtToWorker_Enter);
            this.txtToWorker.Leave += new System.EventHandler(this.txtToWorker_Leave);
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
            // bunifuElipse_Clear
            // 
            this.bunifuElipse_Clear.ElipseRadius = 15;
            this.bunifuElipse_Clear.TargetControl = this.btnClear;
            // 
            // bunifuElipse_Update
            // 
            this.bunifuElipse_Update.ElipseRadius = 15;
            this.bunifuElipse_Update.TargetControl = this.btnUpdate;
            // 
            // bunifuElipse_Route
            // 
            this.bunifuElipse_Route.ElipseRadius = 20;
            this.bunifuElipse_Route.TargetControl = this;
            // 
            // lblRouteId
            // 
            resources.ApplyResources(this.lblRouteId, "lblRouteId");
            this.lblRouteId.ForeColor = System.Drawing.Color.Black;
            this.lblRouteId.Name = "lblRouteId";
            // 
            // lblFullname
            // 
            resources.ApplyResources(this.lblFullname, "lblFullname");
            this.lblFullname.ForeColor = System.Drawing.Color.Black;
            this.lblFullname.Name = "lblFullname";
            // 
            // lblUserMod
            // 
            resources.ApplyResources(this.lblUserMod, "lblUserMod");
            this.lblUserMod.ForeColor = System.Drawing.Color.Black;
            this.lblUserMod.Name = "lblUserMod";
            // 
            // date
            // 
            resources.ApplyResources(this.date, "date");
            this.date.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.date.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.date.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.date.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.date.Cursor = System.Windows.Forms.Cursors.Default;
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Name = "date";
            this.date.Value = new System.DateTime(2024, 9, 30, 0, 0, 0, 0);
            // 
            // lblLanguage
            // 
            this.lblLanguage.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // RouteModel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.date);
            this.Controls.Add(this.lblRouteId);
            this.Controls.Add(this.lblFullname);
            this.Controls.Add(this.lblUserMod);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtToWorker);
            this.Controls.Add(this.txtFrmWorker);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.cmbToDep);
            this.Controls.Add(this.cmbFrmDep);
            this.Controls.Add(this.txtVendor);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtProdCode);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RouteModel";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RouteModel_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RouteModel_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Save;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Clear;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Update;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Route;
        public System.Windows.Forms.Label lblRouteId;
        public System.Windows.Forms.Label lblFullname;
        public System.Windows.Forms.Label lblUserMod;
        public System.Windows.Forms.TextBox txtFrmWorker;
        public System.Windows.Forms.TextBox txtModel;
        public System.Windows.Forms.ComboBox cmbToDep;
        public System.Windows.Forms.ComboBox cmbFrmDep;
        public System.Windows.Forms.TextBox txtVendor;
        public System.Windows.Forms.TextBox txtCategory;
        public System.Windows.Forms.TextBox txtProdCode;
        public System.Windows.Forms.TextBox txtToWorker;
        public System.Windows.Forms.TextBox txtDesc;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.DateTimePicker date;
        public System.Windows.Forms.Label lblLanguage;
    }
}