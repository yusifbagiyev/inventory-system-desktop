using Inventory_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inventory_System.Forms
{
    public partial class İnformation : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm;
        SqlDataReader dr;
        private int AllProducts = 0;
        private int LostProducts = 0;
        private int UselessProducts = 0;
        private int sum = 0;
        public İnformation(string fullname, string language)
        {
            InitializeComponent();
            lblFullname.Text = fullname;
            lblLanguage.Text = language;
            _ = CountofUselessProducts();
            _ = CountofLostProducts();
            _ = CountofAllDepartments();
            _ = CreateChart1();
            _ = LoadDepartments();
        }
        private async Task LoadDepartments()
        {
            try
            {
                cmbSearch.Items.Clear();
                cm = new SqlCommand("SELECT dname FROM Department ORDER BY dname ASC", connect.EstablishConnection(lblFullname.Text));
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["dname"].ToString() == "")
                        continue;
                    cmbSearch.Items.Add(dr["dname"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading departments in Information Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading departments in Information Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task LoadCategory()
        {
            try
            {
                cmbResult.Items.Clear();
                cm = new SqlCommand("SELECT DISTINCT(pcategory) FROM Product WHERE pdepartment=@pdepartment", connect.EstablishConnection(lblFullname.Text));
                cm.Parameters.AddWithValue("@pdepartment", cmbSearch.Text);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["pcategory"].ToString() == "")
                        continue;
                    cmbResult.Items.Add(dr["pcategory"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading category in Information Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading category in Information Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task CountofLostProducts()
        {
            cm = new SqlCommand("SELECT Count(prodCode) FROM Product WHERE prodCode LIKE '#%'", connect.EstablishConnection(lblFullname.Text));
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txtCountOfLostProducts.Text = dr[0].ToString();
            }
            dr.Close();
            connect.CloseConnection();
            LostProducts = Convert.ToInt32(txtCountOfLostProducts.Text);
            await Task.Delay(10);
        }
        private async Task CountofUselessProducts()
        {
            cm = new SqlCommand("SELECT Count(prodCode) FROM Product WHERE prodCode LIKE '*%'", connect.EstablishConnection(lblFullname.Text));
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txtCntOfUseless.Text = dr[0].ToString();
            }
            dr.Close();
            connect.CloseConnection();
            UselessProducts = Convert.ToInt32(txtCntOfUseless.Text);
            await Task.Delay(10);
        }
        private async Task CountofAllDepartments()
        {
            cm = new SqlCommand("SELECT Count(DISTINCT pdepartment) FROM Product", connect.EstablishConnection(lblFullname.Text));
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                txtCountOfDepartments.Text = dr[0].ToString();
            }
            dr.Close();
            connect.CloseConnection();
            await Task.Delay(10);
        }
        private async Task CreateChart1()
        {
            if (chart1.Visible == false)
            {
                cm = new SqlCommand("SELECT Count(prodCode) FROM Product", connect.EstablishConnection(lblFullname.Text));
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    txtCountOfAllProducts.Text = dr[0].ToString();
                }
                dr.Close();
                connect.CloseConnection();
                AllProducts = Convert.ToInt32(txtCountOfAllProducts.Text);
                sum = AllProducts - LostProducts - UselessProducts;
                await ChartOption1();
            }
        }
        private async Task ChartOption1()
        {
            if (lblLanguage.Text == "Russian")
            {
                chart1.Titles.Clear();
                chart1.Titles.Add("Количество продуктов");
                chart1.Titles[0].Font = new Font("Inter", 16, FontStyle.Bold);
                chart1.Titles[0].ForeColor = Color.FromArgb(84, 84, 84);
                chart1.Titles[0].Alignment = ContentAlignment.MiddleCenter;
                chart1.Series["s1"].Points.AddXY("Продукты, которые работают", sum);
                chart1.Series["s1"].Points.AddXY("Бесполезные продукты", UselessProducts);
                chart1.Series["s1"].Points.AddXY("Потерянные продукты", LostProducts);
            }
            else if (lblLanguage.Text == "English")
            {
                chart1.Series["s1"].Points.AddXY("Products that work", sum);
                chart1.Series["s1"].Points.AddXY("Useless Products", UselessProducts);
                chart1.Series["s1"].Points.AddXY("Lost Products", LostProducts);
            }
            await Task.Delay(10);
        }
        private void CmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbResult.Visible = true;
            if (lblLanguage.Text == "Russian")
            {
                cmbResult.Text = "Выберите продукт";
            }
            cmbResult.Text = "Select a product";
            _ = CreateChartCategory();
            chart2.Visible = true;
            _ = LoadCategory();
        }
        private async Task CreateChartCategory()
        {
            // Only categories that have products in this department.
            cm = new SqlCommand("SELECT pcategory FROM Product WHERE pdepartment=@pdepartment", connect.EstablishConnection(lblFullname.Text));
            cm.Parameters.AddWithValue("@pdepartment", cmbSearch.Text);
            dr = cm.ExecuteReader();

            Dictionary<string, int> categoryCount = new Dictionary<string, int>();
            while (dr.Read())
            {
                string categoryName = dr["pcategory"].ToString();

                if (categoryCount.ContainsKey(categoryName))
                {
                    categoryCount[categoryName]++;
                }
                else
                {
                    categoryCount[categoryName] = 1;
                }
            }
            dr.Close();
            connect.CloseConnection();
            await ChartOptionDepartment(categoryCount);
        }
        private async Task ChartOptionDepartment(Dictionary<string, int> categoryCount)
        {
            if (lblLanguage.Text == "Russian")
            {
                chart2.Titles.Clear();
                chart2.Titles.Add("Анализировать продукты в отделах");
                chart2.Titles[0].Font = new Font("Inter", 16, FontStyle.Bold);
                chart2.Titles[0].ForeColor = Color.FromArgb(84, 84, 84);
                chart2.Titles[0].Alignment = ContentAlignment.MiddleCenter;
            }
            chart2.Series["s1"].Enabled = true;
            chart2.Series["s2"].Enabled = false;
            chart2.Series["s1"].Points.Clear();
            chart2.Series["s1"].IsValueShownAsLabel = true;
            foreach (var entry in categoryCount)
            {
                chart2.Series["s1"].Points.AddXY(entry.Key, entry.Value);
            }
            await Task.Delay(10);
        }
        private void CmbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ = LoadCategory();
            _ = CreateChartVendor();
        }
        private async Task CreateChartVendor()
        {
            cm = new SqlCommand("SELECT pvendor FROM Product WHERE pdepartment=@pdepartment AND pcategory=@pcategory", connect.EstablishConnection(lblFullname.Text));
            cm.Parameters.AddWithValue("@pdepartment", cmbSearch.Text);
            cm.Parameters.AddWithValue("@pcategory", cmbResult.Text);
            dr = cm.ExecuteReader();

            Dictionary<string, int> vendorCount = new Dictionary<string, int>();
            while (dr.Read())
            {
                string vendorName = dr["pvendor"].ToString();

                if (vendorCount.ContainsKey(vendorName))
                {
                    vendorCount[vendorName]++;
                }
                else
                {
                    vendorCount[vendorName] = 1;
                }
            }
            dr.Close();
            connect.CloseConnection();
            await ChartOptionCategory(vendorCount);
        }
        private async Task ChartOptionCategory(Dictionary<string, int> vendorCount)
        {
            if (lblLanguage.Text == "Russian")
            {
                chart2.Titles.Clear();
                chart2.Titles.Add("Анализировать продукты в отделах");
                chart2.Titles[0].Font = new Font("Inter", 16, FontStyle.Bold);
                chart2.Titles[0].ForeColor = Color.FromArgb(84, 84, 84);
                chart2.Titles[0].Alignment = ContentAlignment.MiddleCenter;
            }
            chart2.Series["s1"].Enabled = false;
            chart2.Series["s2"].Enabled = true;
            chart2.Series["s2"].Points.Clear();
            chart2.Series["s2"].IsValueShownAsLabel = true;
            foreach (var entry in vendorCount)
            {
                chart2.Series["s2"].Points.AddXY(entry.Key, entry.Value);
            }
            await Task.Delay(10);
        }
        #region Design
        private void CmbSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSearch.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbSearch.Text = "Анализировать продукцию в отделе . . .";
                }
                else
                    cmbSearch.Text = "Analyze products in Deparment . . .";
            }
        }
        private void CmbSearch_Enter(object sender, EventArgs e)
        {
            if (cmbSearch.Text == "Analyze products in Deparment . . ." || cmbSearch.Text == "Анализировать продукцию в отделе . . .")
            {
                cmbSearch.Text = "";
            }
        }
        private void CmbResult_Enter(object sender, EventArgs e)
        {
            if (cmbResult.Text == "Select a product" || cmbResult.Text == "Выберите продукт")
            {
                cmbResult.Text = "";
            }
        }
        private void CmbResult_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbResult.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbResult.Text = "";
                }
                else
                    cmbResult.Text = "Select a product";
            }
        }
        #endregion
    }
}
