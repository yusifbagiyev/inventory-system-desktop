using Inventory_System.Classes;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace Inventory_System.Forms
{
    public partial class Routes : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlCommand cn = new SqlCommand();
        SqlCommand cl = new SqlCommand();
        SqlCommand ck = new SqlCommand();
        SqlDataReader dr;
        SqlDataReader dra; // Reader for the ck command
        private string MaxRouteId = "";
        public Routes(string usertype, string fullname,string language)
        {
            InitializeComponent();
            lblUser.Text = usertype;
            lblFullname.Text = fullname;
            lblLanguage.Text = language;
            _=LoadRoutes();
        }
        private async Task LoadRoutes()
        {
            try
            {
                dgvRoute.Rows.Clear();
                string searchText = txtSearch.Text == "Search in . . . " || txtSearch.Text == "Поиск в . . . " ? "" : txtSearch.Text;
                string query = "SELECT * FROM Route ORDER BY RouteID DESC";
                if (!string.IsNullOrEmpty(searchText))
                {
                    query = @"SELECT * FROM Route
                 WHERE RouteId LIKE @searchText 
                 OR prodCode LIKE @searchText 
                 OR FrmWorker LIKE @searchText 
                 OR ToWorker LIKE @searchText 
                 OR FrmDep LIKE @searchText 
                 OR ToDep LIKE @searchText 
                 OR Date LIKE @searchText 
                 OR Description LIKE @searchText 
                 ORDER BY RouteID DESC";
                }

                cm = new SqlCommand(query, connect.EstablishConnection(lblFullname.Text));

                if (!string.IsNullOrEmpty(searchText))
                {
                    cm.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                }
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dgvRoute.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                    if (cm == null)
                    {
                        MessageBox.Show("There is no option to search");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading routes in Route Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading routes in Route Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                txtTotal.Text = dgvRoute.Rows.Count.ToString();
                await Task.Delay(20);
            }

        }
        private async Task EditRoutes(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvRoute.Columns[e.ColumnIndex].Name;
                if (lblUser.Text == "Admin")
                {
                    if (colName == "Edit")
                    {
                        RouteModel routeModule = new RouteModel(lblUser.Text, lblFullname.Text, lblLanguage.Text);
                        routeModule.lblRouteId.Text = dgvRoute.Rows[e.RowIndex].Cells[0].Value.ToString();
                        routeModule.txtProdCode.Text = dgvRoute.Rows[e.RowIndex].Cells[1].Value.ToString();
                        routeModule.cmbFrmDep.Text = dgvRoute.Rows[e.RowIndex].Cells[2].Value.ToString();
                        routeModule.txtFrmWorker.Text = dgvRoute.Rows[e.RowIndex].Cells[3].Value.ToString();
                        routeModule.cmbToDep.Text = dgvRoute.Rows[e.RowIndex].Cells[4].Value.ToString();
                        routeModule.txtToWorker.Text = dgvRoute.Rows[e.RowIndex].Cells[5].Value.ToString();
                        routeModule.date.Text = dgvRoute.Rows[e.RowIndex].Cells[6].Value.ToString();
                        routeModule.txtDesc.Text = dgvRoute.Rows[e.RowIndex].Cells[7].Value.ToString();

                        routeModule.StartPosition = FormStartPosition.CenterScreen;
                        routeModule.btnSave.Visible = false;
                        routeModule.txtProdCode.Enabled = false;
                        routeModule.txtCategory.Enabled = false;
                        routeModule.txtFrmWorker.Enabled = false;
                        routeModule.txtModel.Enabled = false;
                        routeModule.txtVendor.Enabled = false;
                        routeModule.cmbFrmDep.Enabled = false;
                        routeModule.btnClear.Enabled = false;
                        routeModule.btnUpdate.Location = new System.Drawing.Point(46, 625);
                        routeModule.btnClear.Location = new System.Drawing.Point(199, 625);
                        routeModule.ShowDialog();
                        await LoadRoutes();
                    }
                    else if (colName == "Delete")
                    {
                        if (MessageBox.Show("Are you sure you want to delete this route?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            await SearchForMaxId(dgvRoute.Rows[e.RowIndex].Cells[0].Value.ToString());
                            cl = new SqlCommand("UPDATE Product SET Product.pdepartment=Route.ToDep,Product.pworker=Route.ToWorker,Product.pdescription=Route.Description FROM Route,Product WHERE Route.ProdCode=Product.prodCode AND Route.RouteId LIKE '" + MaxRouteId + "' ", connect.EstablishConnection(lblFullname.Text));
                            cn.ExecuteNonQuery();
                            cl.ExecuteNonQuery();
                            await Task.Delay(100);
                            if (cm != null & ck != null && cl != null && cn != null)
                            {
                                MessageBox.Show("Route has been successfully deleted!");
                                Logger.WriteUserLog(lblUser.Text, " : " + lblFullname.Text + " deleted a row with Product_Code [" + dgvRoute.Rows[e.RowIndex].Cells[1].Value.ToString() + "] from Route Table");
                                Logger.WriteAllLog(lblUser.Text, " : " + lblFullname.Text + " deleted a row with Product_Code [" + dgvRoute.Rows[e.RowIndex].Cells[1].Value.ToString() + "] from Route Table");
                            }
                            else
                            {
                                MessageBox.Show("Route has not been deleted!", "DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        await LoadRoutes();
                    }
                    if (lblUser.Text == "User")
                    {
                        if (colName == "Edit" || colName == "Delete")
                        {
                            MessageBox.Show("You don't have an access!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in Routes Panel when editing items. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in Routes Panel when editing items. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task SearchForMaxId(string ID)
        {
            try
            {
                cm = new SqlCommand("DELETE FROM Route WHERE RouteId LIKE '" + ID + "'", connect.EstablishConnection(lblFullname.Text));
                // Read the product code before the row goes, so its latest remaining route can be found.
                ck = new SqlCommand("SELECT ProdCode FROM Route WHERE RouteId LIKE '" + ID + "'", connect.EstablishConnection(lblFullname.Text));
                dra = ck.ExecuteReader();
                string SrchForPrdCode = "";
                while (dra.Read())
                {
                    SrchForPrdCode = dra[0].ToString();
                }
                dra.Close();
                cm.ExecuteNonQuery();
                ck.ExecuteNonQuery();
                cn = new SqlCommand("SELECT MAX(RouteId) FROM Route WHERE ProdCode LIKE'" + SrchForPrdCode + "' ", connect.EstablishConnection(lblFullname.Text));
                dr = cn.ExecuteReader();
                while (dr.Read())
                {
                    MaxRouteId = dr[0].ToString();
                }
            }
            finally
            {
                dra.Close();
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            RouteModel routemodule = new RouteModel(lblUser.Text, lblFullname.Text,lblLanguage.Text);
            routemodule.StartPosition = FormStartPosition.CenterScreen;
            routemodule.lblFullname.Text = lblFullname.Text;
            routemodule.lblUserMod.Text = lblUser.Text;
            routemodule.btnUpdate.Visible = false;
            routemodule.btnSave.Location = new System.Drawing.Point(46, 625);
            routemodule.btnClear.Location = new System.Drawing.Point(199, 625);
            routemodule.ShowDialog();
            _ = LoadRoutes();
        }
        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (dgvRoute.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Routes.pdf";
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
                            Logger.WriteUserLog(lblFullname.Text, " | Error occured in Routes Panel when printing documents. | Error is: " + ex.Message);
                            Logger.WriteAllLog(lblFullname.Text, " | Error occured in Routes Panel when printing documents. | Error is: " + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(8);
                            pTable.DefaultCell.Padding = 3;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_CENTER;
                            foreach (DataGridViewColumn col in dgvRoute.Columns)
                            {
                                if (col.HeaderText != "")
                                {
                                    PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                    pCell.BorderWidth = 2;
                                    pCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    pTable.AddCell(pCell);
                                }
                            }
                            foreach (DataGridViewRow viewRow in dgvRoute.Rows)
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
                            Logger.WriteUserLog(lblFullname.Text, " | exported a pdf file of Route Panel");
                            Logger.WriteAllLog(lblFullname.Text, " | exported a pdf file of Route Panel");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while exporting Data" + ex.Message);
                            Logger.WriteUserLog(lblFullname.Text, " | Error occured in Routes Panel when printing documents. | Error is: " + ex.Message);
                            Logger.WriteAllLog(lblFullname.Text, " | Error occured in Routes Panel when printing documents. | Error is: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }
        }
        private void txtSearch_OnValueChanged(object sender, EventArgs e)
        {
            _=LoadRoutes();
        }
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e) => _ = EditRoutes(sender, e);
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
