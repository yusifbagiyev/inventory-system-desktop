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
    public partial class LostProducts : Form
    {
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private readonly Connect connect = new Connect();
        public LostProducts(string fullname, string language)
        {
            InitializeComponent();
            _ = LoadLostProduct();
            lblFullname.Text = fullname;
            lblLanguage.Text = language;
        }
        private async Task LoadLostProduct()
        {
            try
            {
                dgvProduct.Rows.Clear();
                string searchText = txtSearch.Text == "Search in . . . " || txtSearch.Text == "Поиск в . . . " ? "" : txtSearch.Text;
                // A lost product's code starts with #.
                string query = "SELECT * FROM Product WHERE prodCode LIKE '#%'";
                if (!string.IsNullOrEmpty(searchText))
                {
                    query += @" AND (prodCode LIKE '#%'+@searchText 
                     OR pcategory LIKE @searchText 
                     OR pvendor LIKE @searchText 
                     OR pmodel LIKE @searchText 
                     OR pdepartment LIKE @searchText 
                     OR pworker LIKE @searchText 
                     OR pdescription LIKE @searchText)";
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
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured when loading product in Lost Products Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured when loading product in Lost Products Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                txtTotal.Text = dgvProduct.Rows.Count.ToString();
                await Task.Delay(10);
            }
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)=>_ = LoadLostProduct();
        private void BtnPdf_Click(object sender, EventArgs e)
        {
            if (dgvProduct.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "LostProducts.pdf";
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
                            Logger.WriteUserLog(lblFullname.Text, " | Error occured when printing documents in Lost Products Panel. | Error is: " + ex.Message);
                            Logger.WriteAllLog(lblFullname.Text, " | Error occured when printing documents in Lost Products Panel. | Error is: " + ex.Message);
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
                            Logger.WriteUserLog(lblFullname.Text, " exported a pdf file of LostProduct Panel");
                            Logger.WriteAllLog(lblFullname.Text, " exported a pdf file of LostProduct Panel");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while exporting Data" + ex.Message);
                            Logger.WriteUserLog(lblFullname.Text, " | Error occured when printing documents in Lost Products Panel. | Error is: " + ex.Message);
                            Logger.WriteAllLog(lblFullname.Text, " | Error occured when printing documents in Lost Products Panel. | Error is: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }
        }
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search in . . . " || txtSearch.Text == "Поиск в . . . ")
            {
                txtSearch.Text = "";
            }
        }
        private void TxtSearch_Leave(object sender, EventArgs e)
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
