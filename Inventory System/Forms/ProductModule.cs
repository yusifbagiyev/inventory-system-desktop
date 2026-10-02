using Inventory_System.Classes;
using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;


namespace Inventory_System.Forms
{
    /// <summary>Dialog that adds or edits a product and makes and prints its barcode label.</summary>
    public partial class ProductModule : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;
        public ProductModule(string _fullname, string _usertype, string _language)
        {
            InitializeComponent();
            _ = LoadCategory();
            _ = LoadDepartment();
            lblFullname.Text = _fullname;
            lblUserMod.Text = _usertype;
            lblLanguage.Text = _language;
            _ = ChangingLanguage();
            this.KeyPreview = true;
        }
        private async Task ChangingLanguage()
        {
            if (lblLanguage.Text == "Russian")
            {
                txtProdCode.Text = "Код";
                txtVendor.Text = "Продавец";
                txtWorker.Text = "Рабочий";
                txtDesc.Text = "Описание";
                cmbCat.Text = "Категории";
                cmbDep.Text = "Отделы";
                txtModel.Text = "Модель";
            }
            else
            {
                txtProdCode.Text = "Code";
                txtVendor.Text = "Vendor";
                txtWorker.Text = "Worker";
                txtDesc.Text = "Description";
                cmbCat.Text = "Categories";
                cmbDep.Text = "Departments";
                txtModel.Text = "Model";
            }
            await Task.Delay(10);
        }
        private async Task LoadCategory()
        {
            try
            {
                cmbCat.Items.Clear();
                cm = new SqlCommand("SELECT catname FROM Category ORDER BY catname ASC", connect.EstablishConnection(lblFullname.Text));
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cmbCat.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading categories in ProductModule Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading categories in ProductModule Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task LoadDepartment()
        {
            try
            {
                cmbDep.Items.Clear();
                cm = new SqlCommand("SELECT dname FROM Department ORDER BY dname ASC", connect.EstablishConnection(lblFullname.Text));
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cmbDep.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading departments in ProductModule Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading departments in ProductModule Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        public async Task LoadID()
        {
            try
            {
                var product_id = "";
                cm = new SqlCommand("SELECT ID FROM Product WHERE prodCode LIKE @prodCode", connect.EstablishConnection(lblFullname.Text));
                cm.Parameters.AddWithValue("@prodCode", txtProdCode.Text);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    product_id = dr[0].ToString();
                }
                prod_id.Text = product_id;
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading ID in ProductModule Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading ID in ProductModule Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        /// <summary>Loads the product for a typed code, also one marked useless or lost, and then blocks saving it twice.</summary>
        private async Task ProdCodeCondition()
        {
            btnSave.Enabled = true;
            await ClearTextsExceptCode();
            if (string.IsNullOrEmpty(txtProdCode.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtProdCode.Text = "Код";
                }
                else
                    txtProdCode.Text = "Code";
            }
            try
            {
                cm = new SqlCommand("SELECT prodCode,pcategory,pvendor,pmodel,pdepartment,pworker,pdescription FROM Product WHERE prodCode= @prodCode OR prodCode='*' + @prodCode OR prodCode='#' + @prodCode", connect.EstablishConnection(lblFullname.Text));
                cm.Parameters.AddWithValue("@prodCode", txtProdCode.Text);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    txtProdCode.Text = dr[0].ToString();
                    cmbCat.Text = dr[1].ToString();
                    txtVendor.Text = dr[2].ToString();
                    txtModel.Text = dr[3].ToString();
                    cmbDep.Text = dr[4].ToString();
                    txtWorker.Text = dr[5].ToString();
                    txtDesc.Text = dr[6].ToString();
                }
                if (dr.HasRows)
                {
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in ProductModule Panel when finding product code. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in ProductModule Panel when finding product code. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
            if (txtProdCode.Text.Contains("*"))
            {
                NotWorking.Checked = true;
            }
            if (txtProdCode.Text.Contains("#"))
            {
                NotFound.Checked = true;
            }
        }
        private async Task SaveProducts()
        {
            try
            {
                if (string.IsNullOrEmpty(txtProdCode.Text) || string.IsNullOrEmpty(cmbCat.Text) || string.IsNullOrEmpty(cmbDep.Text) || txtProdCode.Text == "Code")
                {
                    MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!cmbCat.Items.Contains(cmbCat.Text) || !cmbCat.Items.Contains(cmbCat.Text))
                {
                    MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await ClearItems();
                    cm = new SqlCommand("INSERT INTO Product(prodCode,pcategory,pvendor,pmodel,pdepartment,pworker,pdescription)VALUES(@prodCode, @pcategory, @pvendor, @pmodel, @pdepartment, @pworker, @pdescription )", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@prodCode", txtProdCode.Text);
                    cm.Parameters.AddWithValue("@pcategory", cmbCat.Text);
                    cm.Parameters.AddWithValue("@pvendor", txtVendor.Text);
                    cm.Parameters.AddWithValue("@pmodel", txtModel.Text);
                    cm.Parameters.AddWithValue("@pdepartment", cmbDep.Text);
                    cm.Parameters.AddWithValue("@pworker", txtWorker.Text);
                    cm.Parameters.AddWithValue("@pdescription", txtDesc.Text);
                    cm.ExecuteNonQuery();

                    // A new product's history starts with a route from New Inventory to its department
                    cn = new SqlCommand("INSERT INTO Route(prodCode,FrmDep,ToDep,ToWorker,Date,Description)VALUES(@prodCode, @FrmDep, @ToDep, @ToWorker, @Date, @Description)", connect.EstablishConnection(lblFullname.Text));
                    cn.Parameters.AddWithValue("@prodCode", txtProdCode.Text);
                    cn.Parameters.AddWithValue("@FrmDep", "New Inventory");
                    cn.Parameters.AddWithValue("@ToDep", cmbDep.Text);
                    cn.Parameters.AddWithValue("@ToWorker", txtWorker.Text);
                    cn.Parameters.AddWithValue("@Date", DateTime.Now.ToString("dd.MM.yyyy"));
                    cn.Parameters.AddWithValue("@Description", txtDesc.Text);
                    cn.ExecuteNonQuery();

                    if (cm != null && cn != null)
                    {
                        MessageBox.Show("Product has been successfully updated.");
                        Logger.WriteUserLog(lblFullname.Text, " added a new product with Product_Code  [" + txtProdCode.Text + "], Product_Category [" + cmbCat.Text + "], Product_Vendor [" + txtVendor.Text + "], Product_Model [" + txtModel.Text + "], Product_Department [" + cmbDep.Text + "], Product_Worker [" + txtWorker.Text + "], Product_Description [" + txtDesc.Text + "] to the Product Table");
                        Logger.WriteAllLog(lblFullname.Text, " added a new route with Product_Code  [" + txtProdCode.Text + "], From_Department [new Inventory], To_Department [" + cmbDep.Text + "], To_Worker [" + txtWorker.Text + "], Date [" + DateTime.Now.ToString("dd.MM.yyyy") + "], Description [" + txtDesc.Text + "] to the Route Table");
                    }
                    else
                    {
                        MessageBox.Show("Product has not been saved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in Product Table when saving a product with Product Code [" + NotWorking + "]. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in Product Table when saving a product with Product Code [" + NotWorking + "]. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task UpdateProducts()
        {
            try
            {
                cn = new SqlCommand("SELECT prodCode,pcategory,pvendor,pmodel,pdepartment,pworker,pdescription FROM Product WHERE ID LIKE @ID", connect.EstablishConnection(lblFullname.Text));
                cn.Parameters.AddWithValue("@ID", prod_id.Text);
                dr = cn.ExecuteReader();
                if (dr.HasRows != false)
                {
                    if (string.IsNullOrEmpty(txtProdCode.Text) || string.IsNullOrEmpty(cmbCat.Text) || string.IsNullOrEmpty(cmbDep.Text) || txtProdCode.Text == "Code")
                    {
                        MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        await ClearItems();
                        cm = new SqlCommand("UPDATE Product SET prodCode = @prodCode,pcategory=@pcategory, pvendor=@pvendor ,pmodel=@pmodel, pdepartment=@pdepartment , pworker=@pworker, pdescription=@pdescription WHERE ID LIKE @ID", connect.EstablishConnection(lblFullname.Text));
                        cm.Parameters.AddWithValue("@ID", prod_id.Text);
                        cm.Parameters.AddWithValue("@prodCode", txtProdCode.Text);
                        cm.Parameters.AddWithValue("@pcategory", cmbCat.Text);
                        cm.Parameters.AddWithValue("@pvendor", txtVendor.Text);
                        cm.Parameters.AddWithValue("@pmodel", txtModel.Text);
                        cm.Parameters.AddWithValue("@pdepartment", cmbDep.Text);
                        cm.Parameters.AddWithValue("@pworker", txtWorker.Text);
                        cm.Parameters.AddWithValue("@pdescription", txtDesc.Text);
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Product has been successfully updated!");

                        Logger.WriteUserLog(lblFullname.Text, " updated a new product with Product_Code  [" + txtProdCode.Text + "], Product_Category [" + cmbCat.Text + "], Product_Vendor [" + txtVendor.Text + "], Product_Model [" + txtModel.Text + "], Product_Department [" + cmbDep.Text + "], Product_Worker [" + txtWorker.Text + "], Product_Description [" + txtDesc.Text + "] to the Product Table");
                        Logger.WriteUserLog(lblFullname.Text, " updated a new product with Product_Code  [" + txtProdCode.Text + "], Product_Category [" + cmbCat.Text + "], Product_Vendor [" + txtVendor.Text + "], Product_Model [" + txtModel.Text + "], Product_Department [" + cmbDep.Text + "], Product_Worker [" + txtWorker.Text + "], Product_Description [" + txtDesc.Text + "] to the Product Table");
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in Product Table when updating a product with Product Code [" + txtProdCode.Text + "]. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in Product Table when updating a product with Product Code [" + txtProdCode.Text + "]. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)=>_ = SaveProducts();
        private void btnUpdate_Click(object sender, EventArgs e)=> _ = UpdateProducts();
        private void btnClear_Click(object sender, EventArgs e) => _ = ClearTexts();
        private async Task ClearTextsExceptCode()
        {
            txtVendor.Text = "Vendor";
            txtWorker.Text = "Worker";
            txtDesc.Text = "Description";
            cmbCat.Text = "Categories";
            cmbDep.Text = "Departments";
            txtModel.Text = "Model";
            picBarcode.Image = null;
            picBarcode.Visible = false;
            await Task.Delay(10);
        }
        private async Task ClearTexts()
        {
            txtProdCode.Text = "Code";
            txtVendor.Text = "Vendor";
            txtWorker.Text = "Worker";
            txtDesc.Text = "Description";
            cmbCat.Text = "Categories";
            cmbDep.Text = "Departments";
            txtModel.Text = "Model";
            picBarcode.Image = null;
            picBarcode.Visible = false;
            await Task.Delay(10);
        }
        // Fields left at their placeholder are saved as No Name for vendor and model and empty otherwise
        private async Task ClearItems()
        {
            if (txtVendor.Text == "Vendor" || txtVendor.Text == "" || txtVendor.Text == "Продавец")
            {
                txtVendor.Text = "No Name";
            }
            if (txtDesc.Text == "Description" || txtDesc.Text == "" || txtDesc.Text == "Описание")
            {
                txtDesc.Text = "";
            }
            if (txtModel.Text == "Model" || txtModel.Text == "" || txtModel.Text == "Модель")
            {
                txtModel.Text = "No Name";
            }
            if (txtWorker.Text == "Worker" || txtWorker.Text == "" || txtWorker.Text == "Рабочий")
            {
                txtWorker.Text = "";
            }
            await Task.Delay(10);
        }
        private void btnExit_Click(object sender, EventArgs e)=>this.Dispose();
        // A * in front of the code marks the product useless and a # marks it lost
        public void NotWorking_CheckedChanged(object sender, EventArgs e)
        {
            if (NotWorking.Checked == false)
            {
                if (txtProdCode.Text.Contains("*"))
                {
                    txtProdCode.Text = txtProdCode.Text.Replace("*", "");
                }
            }
            else
            {
                if (!txtProdCode.Text.Contains("*"))
                {
                    txtProdCode.Text = "*" + txtProdCode.Text;
                }
            }
        }
        public void NotFound_CheckedChanged(object sender, EventArgs e)
        {
            if (NotFound.Checked == false)
            {
                if (txtProdCode.Text.Contains("#"))
                {
                    txtProdCode.Text = txtProdCode.Text.Replace("#", "");
                }
            }
            else
            {
                if (!txtProdCode.Text.Contains("#"))
                {
                    txtProdCode.Text = "#" + txtProdCode.Text;
                }
            }
        }
        private void txtProdCode_Leave(object sender, EventArgs e)=>_ = ProdCodeCondition();
        private void lblBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProdCode.Text == "Code" || txtProdCode.Text == "Код")
                {
                    MessageBox.Show("Please write the code of product", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    BarcodeWriter barcodeWriter = new BarcodeWriter()
                    {
                        Format = BarcodeFormat.CODE_128,
                        Options = new ZXing.Common.EncodingOptions
                        {
                            Width = 60,
                            Height = 60,
                            Margin = 10
                        }
                    };
                    picBarcode.Image = barcodeWriter.Write(txtProdCode.Text.Replace("*", ""));
                }
                picBarcode.Visible = true;
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in ProductModule Panel when generating barcode. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in ProductModule Panel when generating barcode. | Error is: " + ex.Message);
            }
        }
        private void lblPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (picBarcode.Image != null)
                {
                    PrintDialog pd = new PrintDialog();
                    PrintDocument pDoc = new PrintDocument();
                    pDoc.PrintPage += PrintPicture;
                    pd.Document = pDoc;
                    if (pd.ShowDialog() == DialogResult.OK)
                    {
                        pDoc.Print();
                    }
                }
                else
                {
                    MessageBox.Show("No barcode image", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in ProductModule Panel when printing barcode. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in ProductModule Panel when printing barcode. | Error is: " + ex.Message);
            }
        }
        private void PrintPicture(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(picBarcode.Width, picBarcode.Height);
            picBarcode.DrawToBitmap(bmp, new Rectangle(0, 0, picBarcode.Width, picBarcode.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
            PointF point = new PointF(260, 300);
            SolidBrush brush = new SolidBrush(Color.White);
            e.Graphics.DrawString(txtProdCode.Text, txtProdCode.Font, brush, point);
        }
        #region Design
        // Lets the borderless dialog be dragged by its body
        private void ProductModule_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void ProductModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnSave.Visible != false)
                {
                    btnSave_Click(this, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                else
                {
                    btnUpdate_Click(this, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
            }
        }
        private void txtProdCode_Enter(object sender, EventArgs e)
        {
            if (txtProdCode.Text == "Code" || txtProdCode.Text == "Код")
            {
                txtProdCode.Text = "";
            }
        }
        private void txtVendor_Enter(object sender, EventArgs e)
        {
            if (txtVendor.Text == "Vendor" || txtVendor.Text == "Продавец")
            {
                txtVendor.Text = "";
            }
        }
        private void txtVendor_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVendor.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtVendor.Text = "Продавец";
                }
                else
                    txtVendor.Text = "Vendor";
            }
        }
        private void txtModel_Enter(object sender, EventArgs e)
        {
            if (txtModel.Text == "Model" || txtModel.Text == "Модель")
            {
                txtModel.Text = "";
            }
        }
        private void txtModel_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModel.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtModel.Text = "Модель";
                }
                else
                    txtModel.Text = "Model";
            }
        }
        private void cmbCat_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCat.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbCat.Text = "Категория";
                }
                else
                    cmbCat.Text = "Category";
            }
        }
        private void cmbCat_Enter(object sender, EventArgs e)
        {
            if (cmbCat.Text == "Category" || cmbCat.Text == "Категория")
            {
                cmbCat.Text = "";
            }
        }
        private void cmbDep_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDep.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbDep.Text = "Отделение";
                }
                else
                    cmbDep.Text = "Department";
            }
        }
        private void cmbDep_Enter(object sender, EventArgs e)
        {
            if (cmbDep.Text == "Department" || cmbDep.Text == "Отделение")
            {
                cmbDep.Text = "";
            }
        }
        private void txtWorker_Enter(object sender, EventArgs e)
        {
            if (txtWorker.Text == "Worker" || txtWorker.Text == "Рабочий")
            {
                txtWorker.Text = "";
            }
        }
        private void txtWorker_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWorker.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtWorker.Text = "Рабочий";
                }
                else
                    txtWorker.Text = "Worker";
            }
        }
        private void txtDesc_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtDesc.Text = "Описание";
                }
                else
                    txtDesc.Text = "Description";
            }
        }
        private void txtDesc_Enter(object sender, EventArgs e)
        {
            if (txtDesc.Text == "Description" || txtDesc.Text == "Описание")
            {
                txtDesc.Text = "";
            }
        }
        #endregion
    }
}