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

namespace Inventory_System.Forms
{
    /// <summary>All-products page with search and a PDF export, where any user may edit but only admins delete.</summary>
    public partial class TheProducts : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;
        public TheProducts(string _userType, string _fullName, string _language)
        {
            InitializeComponent();
            lblFullname.Text = _fullName;
            lblUser.Text = _userType;
            lblLanguage.Text = _language;
            _ = LoadProduct();
        }
        private async Task LoadProduct()
        {
            try
            {
                dgvProduct.Rows.Clear();
                string searchText = txtSearch.Text == "Search in . . . " || txtSearch.Text == "Поиск в . . . " ? "" : txtSearch.Text;
                string query = "SELECT * FROM Product ORDER BY pdepartment";
                if (!string.IsNullOrEmpty(searchText))
                {
                    query = @" SELECT * FROM Product 
                     WHERE prodCode LIKE @searchText 
                     OR pcategory LIKE @searchText 
                     OR pvendor LIKE @searchText 
                     OR pmodel LIKE @searchText 
                     OR pdepartment LIKE @searchText 
                     OR pworker LIKE @searchText 
                     OR pdescription LIKE @searchText
                     ORDER BY pdepartment";
                }
                cm = new SqlCommand(query, connect.EstablishConnection(lblFullname.Text));
                if (!string.IsNullOrEmpty(searchText))
                {
                    cm.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                }
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dgvProduct.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                await Task.Delay(300);
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in Product Panel when loading product. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in Product Panel when loading product. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                txtTotal.Text = dgvProduct.Rows.Count.ToString();
            }
        }
        private async Task EditProducts(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvProduct.Columns[e.ColumnIndex].Name;
                if (lblUser.Text == "Admin")
                {
                    if (colName == "Edit")
                    {
                        ProductModule productModule = new ProductModule(lblUser.Text, lblFullname.Text, lblLanguage.Text);
                        productModule.txtProdCode.Text = dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                        productModule.cmbCat.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                        productModule.txtVendor.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                        productModule.txtModel.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                        productModule.cmbDep.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                        productModule.txtWorker.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                        productModule.txtDesc.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                        productModule.lblFullname.Text = lblFullname.Text;
                        _ = productModule.LoadID();
                        if (productModule.txtProdCode.Text.Contains("*"))
                        {
                            productModule.NotWorking.Checked = true;
                        }
                        if (productModule.txtProdCode.Text.Contains("#"))
                        {
                            productModule.NotFound.Checked = true;
                        }
                        productModule.btnSave.Visible = false;
                        productModule.btnClear.Enabled = false;
                        productModule.StartPosition = FormStartPosition.CenterScreen;
                        productModule.btnUpdate.Location = new System.Drawing.Point(50, 579);
                        productModule.btnClear.Location = new System.Drawing.Point(206, 579);
                        productModule.ShowDialog();
                        await LoadProduct();
                    }
                    if (colName == "Delete")
                    {
                        if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cm = new SqlCommand("DELETE FROM Product WHERE prodCode LIKE @prodCode", connect.EstablishConnection(lblFullname.Text));
                            cm.Parameters.AddWithValue("@prodCode", dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString());
                            cm.ExecuteNonQuery();
                            connect.CloseConnection();
                            MessageBox.Show("Record has been successfully deleted!");

                            Logger.WriteUserLog(lblFullname.Text, " deleted a product with Product_Code [" + dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString() + "] from Product Table");
                            Logger.WriteAllLog(lblFullname.Text, " deleted a product with Product_Code [" + dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString() + "] from Product Table");
                        }
                        await LoadProduct();
                    }
                }
                if (lblUser.Text == "User")
                {
                    if (colName == "Edit")
                    {
                        ProductModule productModule = new ProductModule(lblUser.Text, lblFullname.Text, lblLanguage.Text);
                        productModule.txtProdCode.Text = dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                        productModule.cmbCat.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                        productModule.txtVendor.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                        productModule.txtModel.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                        productModule.cmbDep.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                        productModule.txtWorker.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                        productModule.txtDesc.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                        if (productModule.txtProdCode.Text.Contains("*"))
                        {
                            productModule.NotWorking.Checked = true;
                        }
                        if (productModule.txtProdCode.Text.Contains("#"))
                        {
                            productModule.NotFound.Checked = true;
                        }
                        productModule.lblFullname.Text = lblFullname.Text;
                        productModule.btnSave.Visible = false;
                        productModule.btnClear.Enabled = false;
                        productModule.StartPosition = FormStartPosition.CenterScreen;
                        productModule.btnUpdate.Location = new System.Drawing.Point(50, 579);
                        productModule.btnClear.Location = new System.Drawing.Point(206, 579);
                        productModule.ShowDialog();
                        await LoadProduct();
                    }
                    if (colName == "Delete")
                    {
                        MessageBox.Show("You don't have an access!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.WriteAllLog("User: +" + lblFullname.Text, " | tried to modify product in Route Panel");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in Product Panel when editing items. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in Product Panel when editing items. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e) => _ = EditProducts(sender,e);
        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            _ = LoadProduct();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule ProductForm = new ProductModule(lblUser.Text, lblFullname.Text, lblLanguage.Text);
            ProductForm.StartPosition = FormStartPosition.CenterScreen;
            ProductForm.btnUpdate.Visible = false;
            ProductForm.btnSave.Location = new System.Drawing.Point(50, 579);
            ProductForm.btnClear.Location = new System.Drawing.Point(206, 579);
            ProductForm.ShowDialog();
            _ = LoadProduct();
        }
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
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search in . . . " || txtSearch.Text == "Поиск в . . . ")
            {
                txtSearch.Text = "";
            }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtSearch.Text = "Поиск в . . . ";
                }
                else
                    txtSearch.Text = "Search in . . . ";
            }
        }
    }
}
