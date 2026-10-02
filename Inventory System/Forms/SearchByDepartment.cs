using Inventory_System.Classes;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace Inventory_System.Forms
{
    /// <summary>Lists a department's products and narrows them down by category, vendor and model in turn.</summary>
    public partial class SearchByDepartment : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public SearchByDepartment(string fullname,string language)
        {
            InitializeComponent();
            _=LoadDepartments();
            lblFullname.Text = fullname;
            lblLanguage.Text = language;
        }
        private async Task ShowTotal()
        {
            txtTotal.Visible = true;
            lblTotal.Visible = true;
            txtTotal.Text = dgvProduct.RowCount.ToString();
            await Task.Delay(10);
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
                if (!dr.HasRows)
                {
                    MessageBox.Show("There are no any product in this Department", "IN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading departments in SearchByDepartment Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading departments in SearchByDepartment Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        /// <summary>Fills the category list from the department of the products in the grid.</summary>
        private async Task CountofProducts()
        {
            try
            {
                if (!String.IsNullOrEmpty(dgvProduct.Rows[0].Cells[4].Value.ToString()))
                {
                    cmbResult.Items.Clear();
                    cm = new SqlCommand("SELECT DISTINCT pcategory FROM Product WHERE pdepartment LIKE @pdepartment", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@pdepartment", dgvProduct.Rows[0].Cells[4].Value.ToString());
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        cmbResult.Items.Add(dr["pcategory"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading CountOfProducts in SearchByDepartment Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading CountOfProducts in SearchByDepartment Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        /// <summary>Fills the vendor list for the chosen category in that department.</summary>
        private async Task CountofProductsforVendor()
        {
            try
            {
                if (!String.IsNullOrEmpty(cmbResult.Text))
                {
                    cmbVendor.Items.Clear();
                    cm = new SqlCommand("SELECT DISTINCT pvendor FROM Product WHERE pdepartment LIKE @pdepartment AND pcategory LIKE @pcategory", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@pdepartment", dgvProduct.Rows[0].Cells[4].Value.ToString());
                    cm.Parameters.AddWithValue("@pcategory", cmbResult.Text);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        cmbVendor.Items.Add(dr["pvendor"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading CountofProductsforVendor in SearchByDepartment Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading CountofProductsforVendor in SearchByDepartment Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        /// <summary>Fills the model list for the chosen category and vendor in that department.</summary>
        private async Task CountofProductsforModel()
        {
            try
            {
                if (!String.IsNullOrEmpty(cmbVendor.Text))
                {
                    cmbModel.Items.Clear();
                    cm = new SqlCommand("SELECT DISTINCT pmodel FROM Product WHERE pdepartment LIKE @pdepartment AND pcategory LIKE @pcategory AND pvendor LIKE @pvendor", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@pdepartment", dgvProduct.Rows[0].Cells[4].Value.ToString());
                    cm.Parameters.AddWithValue("@pcategory", cmbResult.Text);
                    cm.Parameters.AddWithValue("@pvendor", cmbVendor.Text);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        cmbModel.Items.Add(dr["pmodel"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading CountofProductsforModel in SearchByDepartment Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading CountofProductsforModel in SearchByDepartment Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task SearchOptionByDeparment()
        {
            try
            {
                if (String.IsNullOrEmpty(cmbSearch.Text))
                {
                    MessageBox.Show("Please select a department !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cm = new SqlCommand("SELECT * FROM Product WHERE pdepartment=@pdepartment", connect.EstablishConnection(lblFullname.Text));
                cm.Parameters.AddWithValue("pdepartment", cmbSearch.Text);
                dgvProduct.Rows.Clear();
                dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dgvProduct.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                    }
                    dgvProduct.Visible = true;
                    cmbResult.Visible = true;
                    cmbResult.Items.Clear();
                    txtTotal.Text = "";
                    cmbModel.Visible = false;
                    cmbVendor.Visible = false;
                    txtTotal.Visible = false;
                    lblTotal.Visible = false;
                    cmbVendor.Items.Clear();
                    cmbModel.Items.Clear();
                    await CountofProducts();
                }
                else
                {
                    lblTotal.Visible = false;
                    cmbResult.Visible = false;
                    txtTotal.Visible = false;
                    dgvProduct.Visible = false;
                    txtTotal.Text = "";
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when Searching Departments in SearchByDepartment Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when Searching Departments in SearchByDepartment Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await ShowTotal();
            }
        }
        private async Task SearchOptionByResult()
        {
            try
            {
                await CountofProductsforVendor();
                await CountofProductsforModel();
                cm = new SqlCommand("SELECT * FROM Product WHERE pdepartment=@pdepartment AND pcategory=@pcategory", connect.EstablishConnection(lblFullname.Text));
                cm.Parameters.AddWithValue("pdepartment", dgvProduct.Rows[0].Cells[4].Value.ToString());
                cm.Parameters.AddWithValue("pcategory", cmbResult.Text);
                dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    dgvProduct.Rows.Clear();
                    while (dr.Read())
                    {
                        dgvProduct.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                    }
                }
                cmbVendor.Visible = true;
                cmbVendor.Text = "";
                cmbModel.Text = "";
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when selecting a category in SearchByDepartment Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when selecting a category in SearchByDepartment Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await ShowTotal();
            }
        }
        private async Task SearchOptionByVendor()
        {
            try
            {
                await CountofProductsforModel();
                cm = new SqlCommand("SELECT * FROM Product WHERE pdepartment=@pdepartment AND pcategory=@pcategory AND pvendor=@pvendor", connect.EstablishConnection(lblFullname.Text));
                cm.Parameters.AddWithValue("pdepartment", dgvProduct.Rows[0].Cells[4].Value.ToString());
                cm.Parameters.AddWithValue("pcategory", cmbResult.Text);
                cm.Parameters.AddWithValue("pvendor", cmbVendor.Text);
                dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    dgvProduct.Rows.Clear();
                    while (dr.Read())
                    {
                        dgvProduct.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                    }
                }
                cmbModel.Visible = true;
                cmbModel.Text = "";
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when selecting a vendor in SearchByDepartment Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when selecting a vendor in SearchByDepartment Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await ShowTotal();
            }
        }
        private async Task SearchOptionByModel()
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM Product WHERE pdepartment=@pdepartment AND pcategory=@pcategory AND pvendor=@pvendor AND pmodel=@pmodel", connect.EstablishConnection(lblFullname.Text));
                cm.Parameters.AddWithValue("pdepartment", dgvProduct.Rows[0].Cells[4].Value.ToString());
                cm.Parameters.AddWithValue("pcategory", cmbResult.Text);
                cm.Parameters.AddWithValue("pvendor", cmbVendor.Text);
                cm.Parameters.AddWithValue("pmodel", cmbModel.Text);
                dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    dgvProduct.Rows.Clear();
                    while (dr.Read())
                    {
                        dgvProduct.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when selecting a model in SearchByDepartment Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when selecting a model in SearchByDepartment Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await ShowTotal();
            }
        }
        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e) => _ = SearchOptionByDeparment();
        private void cmbResult_SelectedIndexChanged(object sender, EventArgs e) => _ = SearchOptionByResult();
        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e) => _ = SearchOptionByVendor();
        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e) => _ = SearchOptionByModel();
        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (dgvProduct.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Products.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Unable to write data in disk" + ex.Message);
                            Logger.WriteUserLog(lblFullname.Text, " | Error occured in Product Panel when printing documents. | Error is: " + ex.Message);
                            Logger.WriteAllLog(lblFullname.Text, " | Error occured in Product Panel when printing documents. | Error is: " + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(7);
                            pTable.DefaultCell.Padding = 3;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dgvProduct.Columns)
                            {
                                if (col.HeaderText != "")
                                {
                                    PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                    pCell.BorderWidth = 2;
                                    pCell.PaddingLeft = 20;
                                    pTable.AddCell(pCell);
                                }
                            }
                            foreach (DataGridViewRow viewRow in dgvProduct.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    // Icon cells hold a Bitmap and their columns have no header, so both stay out of the PDF
                                    if (dcell.Value.ToString() != "System.Drawing.Bitmap")
                                    {
                                        pTable.AddCell(dcell.Value.ToString());
                                    }
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4.Rotate(), 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Data Export Successfully", "info");
                            Logger.WriteUserLog(lblFullname.Text, " | exported a pdf file of Product Panel");
                            Logger.WriteAllLog(lblFullname.Text, " | exported a pdf file of Product Panel");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while exporting Data" + ex.Message);
                            Logger.WriteUserLog(lblFullname.Text, " | Error occured in Product Panel when printing documents. | Error is: " + ex.Message);
                            Logger.WriteAllLog(lblFullname.Text, " | Error occured in Product Panel when printing documents. | Error is: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }
        }
        #region Design
        private void cmbSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSearch.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbSearch.Text = "Поиск продукты по отделу . . .";
                }
                else
                cmbSearch.Text = "Search products in Deparment . . .";
            }
        }
        private void cmbSearch_Enter(object sender, EventArgs e)
        {
            if (cmbSearch.Text == "Search products in Deparment . . ." || cmbSearch.Text == "Поиск продукты по отделу . . .")
            {
                cmbSearch.Text = "";
            }
        }
        private void cmbResult_Enter(object sender, EventArgs e)
        {
            if (cmbResult.Text == "Select a product"||cmbResult.Text== "Выберите продукт")
            {
                cmbResult.Text = "";
            }
        }
        private void cmbResult_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbResult.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbResult.Text = "Выберите продукт";
                }
                else
                cmbResult.Text = "Select a product";
            }
        }
        private void cmbVendor_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbVendor.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbVendor.Text = "Выберите продавец";
                }
                else
                cmbVendor.Text = "Select a vendor";
            }
        }
        private void cmbVendor_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbVendor.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbVendor.Text = "Выберите продавец";
                }
                else
                cmbVendor.Text = "Select a vendor";
            }
        }
        private void cmbModel_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbModel.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbModel.Text = "Выберите модель";
                }
                else
                cmbModel.Text = "Select a model";
            }
        }
        private void cmbModel_Enter(object sender, EventArgs e)
        {
            if (cmbModel.Text == "Select a model"||cmbModel.Text== "Выберите модель")
            {
                cmbModel.Text = "";
            }
        }
        #endregion
    }
}
