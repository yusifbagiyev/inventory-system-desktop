namespace Inventory_System.Forms
{
    partial class İnformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(İnformation));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lblFullname = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCountOfAllProducts = new System.Windows.Forms.Label();
            this.btn_CntOfAllProd = new System.Windows.Forms.Button();
            this.lblCountOfDepartments = new System.Windows.Forms.Label();
            this.lblCountOfLostProducts = new System.Windows.Forms.Label();
            this.lblCountOfUselessProducts = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCountOfAllProducts = new System.Windows.Forms.TextBox();
            this.txtCountOfDepartments = new System.Windows.Forms.TextBox();
            this.txtCntOfUseless = new System.Windows.Forms.TextBox();
            this.txtCountOfLostProducts = new System.Windows.Forms.TextBox();
            this.cmbResult = new System.Windows.Forms.ComboBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFullname
            // 
            resources.ApplyResources(this.lblFullname, "lblFullname");
            this.lblFullname.ForeColor = System.Drawing.Color.Black;
            this.lblFullname.Name = "lblFullname";
            // 
            // chart1
            // 
            resources.ApplyResources(this.chart1, "chart1");
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            this.chart1.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.chart1.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            this.chart1.BorderSkin.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            chartArea1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            legend1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            legend1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            legend1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackSecondaryColor = System.Drawing.Color.Black;
            series1.BorderColor = System.Drawing.Color.White;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.CustomProperties = "PieDrawingStyle=Concave";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            this.chart1.Series.Add(series1);
            title1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            title1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            title1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            title1.BackSecondaryColor = System.Drawing.Color.White;
            title1.BorderColor = System.Drawing.Color.BlanchedAlmond;
            title1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            title1.BorderWidth = 4;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            title1.Name = "Title1";
            title1.Text = "Count of Products";
            this.chart1.Titles.Add(title1);
            // 
            // lblCountOfAllProducts
            // 
            resources.ApplyResources(this.lblCountOfAllProducts, "lblCountOfAllProducts");
            this.lblCountOfAllProducts.ForeColor = System.Drawing.Color.Black;
            this.lblCountOfAllProducts.Name = "lblCountOfAllProducts";
            // 
            // btn_CntOfAllProd
            // 
            this.btn_CntOfAllProd.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btn_CntOfAllProd.AutoEllipsis = true;
            this.btn_CntOfAllProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            resources.ApplyResources(this.btn_CntOfAllProd, "btn_CntOfAllProd");
            this.btn_CntOfAllProd.FlatAppearance.BorderSize = 0;
            this.btn_CntOfAllProd.Name = "btn_CntOfAllProd";
            this.btn_CntOfAllProd.UseVisualStyleBackColor = false;
            // 
            // lblCountOfDepartments
            // 
            resources.ApplyResources(this.lblCountOfDepartments, "lblCountOfDepartments");
            this.lblCountOfDepartments.ForeColor = System.Drawing.Color.Black;
            this.lblCountOfDepartments.Name = "lblCountOfDepartments";
            // 
            // lblCountOfLostProducts
            // 
            resources.ApplyResources(this.lblCountOfLostProducts, "lblCountOfLostProducts");
            this.lblCountOfLostProducts.ForeColor = System.Drawing.Color.Black;
            this.lblCountOfLostProducts.Name = "lblCountOfLostProducts";
            // 
            // lblCountOfUselessProducts
            // 
            resources.ApplyResources(this.lblCountOfUselessProducts, "lblCountOfUselessProducts");
            this.lblCountOfUselessProducts.ForeColor = System.Drawing.Color.Black;
            this.lblCountOfUselessProducts.Name = "lblCountOfUselessProducts";
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.button1.AutoEllipsis = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.button2.AutoEllipsis = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            resources.ApplyResources(this.button2, "button2");
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.button3.AutoEllipsis = true;
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            resources.ApplyResources(this.button3, "button3");
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // txtCountOfAllProducts
            // 
            this.txtCountOfAllProducts.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.txtCountOfAllProducts, "txtCountOfAllProducts");
            this.txtCountOfAllProducts.BackColor = System.Drawing.Color.White;
            this.txtCountOfAllProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCountOfAllProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCountOfAllProducts.Name = "txtCountOfAllProducts";
            this.txtCountOfAllProducts.ReadOnly = true;
            // 
            // txtCountOfDepartments
            // 
            this.txtCountOfDepartments.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.txtCountOfDepartments, "txtCountOfDepartments");
            this.txtCountOfDepartments.BackColor = System.Drawing.Color.White;
            this.txtCountOfDepartments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCountOfDepartments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCountOfDepartments.Name = "txtCountOfDepartments";
            this.txtCountOfDepartments.ReadOnly = true;
            // 
            // txtCntOfUseless
            // 
            this.txtCntOfUseless.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.txtCntOfUseless, "txtCntOfUseless");
            this.txtCntOfUseless.BackColor = System.Drawing.Color.White;
            this.txtCntOfUseless.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCntOfUseless.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCntOfUseless.Name = "txtCntOfUseless";
            this.txtCntOfUseless.ReadOnly = true;
            // 
            // txtCountOfLostProducts
            // 
            this.txtCountOfLostProducts.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.txtCountOfLostProducts, "txtCountOfLostProducts");
            this.txtCountOfLostProducts.BackColor = System.Drawing.Color.White;
            this.txtCountOfLostProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCountOfLostProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCountOfLostProducts.Name = "txtCountOfLostProducts";
            this.txtCountOfLostProducts.ReadOnly = true;
            // 
            // cmbResult
            // 
            resources.ApplyResources(this.cmbResult, "cmbResult");
            this.cmbResult.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbResult.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.SelectedIndexChanged += new System.EventHandler(this.CmbResult_SelectedIndexChanged);
            this.cmbResult.Enter += new System.EventHandler(this.CmbResult_Enter);
            this.cmbResult.Leave += new System.EventHandler(this.CmbResult_Leave);
            // 
            // chart2
            // 
            resources.ApplyResources(this.chart2, "chart2");
            this.chart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            this.chart2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            this.chart2.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.chart2.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            this.chart2.BorderSkin.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            legend2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            legend2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            legend2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.chart2.Legends.Add(legend2);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.BackSecondaryColor = System.Drawing.Color.White;
            series2.BorderColor = System.Drawing.Color.White;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.CustomProperties = "PieStartAngle=0, PieDrawingStyle=Concave";
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            series2.IsValueShownAsLabel = true;
            series2.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "s1";
            series2.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series2.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.SlateBlue;
            series2.SmartLabelStyle.CalloutLineWidth = 2;
            series2.SmartLabelStyle.CalloutStyle = System.Windows.Forms.DataVisualization.Charting.LabelCalloutStyle.Box;
            series2.SmartLabelStyle.IsOverlappedHidden = false;
            series2.SmartLabelStyle.MaxMovingDistance = 6D;
            series3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            series3.BackSecondaryColor = System.Drawing.Color.Black;
            series3.BorderColor = System.Drawing.Color.White;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.CustomProperties = "PieStartAngle=0, PieDrawingStyle=Concave";
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "s2";
            this.chart2.Series.Add(series2);
            this.chart2.Series.Add(series3);
            title2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            title2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            title2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.ZigZag;
            title2.BackSecondaryColor = System.Drawing.Color.White;
            title2.BorderColor = System.Drawing.Color.BlanchedAlmond;
            title2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            title2.BorderWidth = 4;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            title2.Name = "Title1";
            title2.Text = "Analyze products in Department";
            this.chart2.Titles.Add(title2);
            // 
            // cmbSearch
            // 
            resources.ApplyResources(this.cmbSearch, "cmbSearch");
            this.cmbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cmbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.CmbSearch_SelectedIndexChanged);
            this.cmbSearch.Enter += new System.EventHandler(this.CmbSearch_Enter);
            this.cmbSearch.Leave += new System.EventHandler(this.CmbSearch_Leave);
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.ForeColor = System.Drawing.Color.Black;
            this.lblLanguage.Name = "lblLanguage";
            // 
            // İnformation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cmbSearch);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.cmbResult);
            this.Controls.Add(this.txtCountOfLostProducts);
            this.Controls.Add(this.txtCntOfUseless);
            this.Controls.Add(this.txtCountOfDepartments);
            this.Controls.Add(this.txtCountOfAllProducts);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCountOfLostProducts);
            this.Controls.Add(this.lblCountOfUselessProducts);
            this.Controls.Add(this.lblCountOfDepartments);
            this.Controls.Add(this.btn_CntOfAllProd);
            this.Controls.Add(this.lblCountOfAllProducts);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblFullname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "İnformation";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblCountOfAllProducts;
        private System.Windows.Forms.Button btn_CntOfAllProd;
        private System.Windows.Forms.Label lblCountOfDepartments;
        private System.Windows.Forms.Label lblCountOfLostProducts;
        private System.Windows.Forms.Label lblCountOfUselessProducts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtCountOfAllProducts;
        private System.Windows.Forms.TextBox txtCountOfDepartments;
        private System.Windows.Forms.TextBox txtCntOfUseless;
        private System.Windows.Forms.TextBox txtCountOfLostProducts;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.ComboBox cmbSearch;
        public System.Windows.Forms.Label lblLanguage;
    }
}