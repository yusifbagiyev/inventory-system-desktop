using Inventory_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Forms
{
    public partial class RouteModel : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;
        SqlDataReader dra;
        
        public RouteModel(string _userType, string _fullName, string _language)
        {
            InitializeComponent();
            _ = LoadDepartment();
            lblUserMod.Text = _userType;
            lblFullname.Text = _fullName;
            lblLanguage.Text=_language;
            date.Value = DateTime.Now;
            this.KeyPreview = true;
        }
        private void DisableTexts()
        {
            txtCategory.Enabled = false;
            txtVendor.Enabled = false;
            txtModel.Enabled = false;
            txtFrmWorker.Enabled = false;
            cmbFrmDep.Enabled = false;
        }
        private async Task Clear()
        {
            if (lblLanguage.Text == "Russian")
            {
                txtProdCode.Text = "Код";
                txtDesc.Text = "Описание";
                txtToWorker.Text = "Работнику";
                txtFrmWorker.Text = "От Работника";
                txtCategory.Text = "Категория";
                txtVendor.Text = "Продавец";
                txtModel.Text = "Модель";
            }
            else
            {
                txtProdCode.Text = "Code";
                txtDesc.Text = "Description";
                txtToWorker.Text = "To Worker";
                txtFrmWorker.Text = "From Worker";
                txtCategory.Text = "Category";
                txtVendor.Text = "Vendor";
                txtModel.Text = "Model";
            }
            date.Text = DateTime.Now.ToString();
            cmbFrmDep.Text = null;
            cmbToDep.Text = null;
            await Task.Delay(10);
        }
        private async Task ClearItems()
        {
            if (txtDesc.Text == "Description" || txtDesc.Text == "Описание")
            {
                txtDesc.Text = "";
            }
            if (txtFrmWorker.Text == "From Worker" || txtFrmWorker.Text == "От Работника")
            {
                txtFrmWorker.Text = "";
            }
            if (txtToWorker.Text == "To Worker" || txtToWorker.Text == "Работнику")
            {
                txtToWorker.Text = "";
            }
            await Task.Delay(10);
        }
        private async Task LoadDepartment()
        {
            try
            {
                cmbFrmDep.Items.Clear();
                cmbToDep.Items.Clear();
                cm = new SqlCommand("SELECT dname FROM Department ORDER BY dname ASC", connect.EstablishConnection(lblFullname.Text));
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cmbFrmDep.Items.Add(dr[0].ToString());
                    cmbToDep.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading departments in Route Module Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading departments in Route Module Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task SaveRoutes()
        {
            try
            {
                if (string.IsNullOrEmpty(txtProdCode.Text) || string.IsNullOrEmpty(cmbFrmDep.Text) || string.IsNullOrEmpty(cmbToDep.Text))
                {
                    MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to save this route?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _ = ClearItems();
                    cm = new SqlCommand("INSERT INTO Route(ProdCode,FrmDep,FrmWorker,ToDep,ToWorker,Date,Description)VALUES(@prodCode, @FrmDep, @FrmWorker, @ToDep, @ToWorker, @Date, @Description)", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@prodCode", txtProdCode.Text);
                    cm.Parameters.AddWithValue("@FrmDep", cmbFrmDep.Text);
                    cm.Parameters.AddWithValue("@FrmWorker", txtFrmWorker.Text);
                    cm.Parameters.AddWithValue("@ToDep", cmbToDep.Text);
                    cm.Parameters.AddWithValue("@ToWorker", txtToWorker.Text);
                    cm.Parameters.AddWithValue("@Date", date.Text);
                    cm.Parameters.AddWithValue("@Description", txtDesc.Text);
                    cm.ExecuteNonQuery();
                    // Move the product to the receiving department and worker.
                    string query = @"
                    UPDATE Product
                    SET 
                          pdepartment = @ToDep,
                          pworker = @ToWorker,
                          pdescription = @Description
                    WHERE 
                          prodCode=@prodCode";
                    SqlCommand ck = new SqlCommand(query, connect.EstablishConnection(lblFullname.Text));
                    ck.Parameters.AddWithValue("@ProdCode", txtProdCode.Text);
                    ck.Parameters.AddWithValue("@ToDep", cmbToDep.Text);
                    ck.Parameters.AddWithValue("@ToWorker", txtToWorker.Text);
                    ck.Parameters.AddWithValue("@Description", txtDesc.Text);
                    ck.ExecuteNonQuery();
                    if (cm != null && ck != null)
                    {
                        MessageBox.Show("Route has been successfully saved.");
                        Logger.WriteUserLog(lblFullname.Text, "  added a new route with Product Code: [" + txtProdCode.Text + "], From Department: [" + cmbFrmDep.Text + "],From Worker: [" + txtFrmWorker.Text + "], To Department[" + cmbToDep.Text + "], To Worker: [" + txtToWorker.Text + "], Date: [" + date.Text + "] to the Route Table");
                        Logger.WriteAllLog(lblFullname.Text, "  added a new route with Product Code: [" + txtProdCode.Text + "], From Department: [" + cmbFrmDep.Text + "],From Worker: [" + txtFrmWorker.Text + "], To Department[" + cmbToDep.Text + "], To Worker: [" + txtToWorker.Text + "], Date: [" + date.Text + "] to the Route Table");
                    }
                    else
                    {
                        MessageBox.Show("Route has not been saved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.WriteUserLog(lblFullname.Text, " | Error occured when saving routing in Route Section. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured when saving routing in Route Section. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task MaxRouteId()
        {
            cn = new SqlCommand("SELECT MAX(RouteId) as MAX_ID FROM Route", connect.EstablishConnection(lblFullname.Text));
            dra = cn.ExecuteReader();
            while (dra.Read())
            {
                lblRouteId.Text = dra[0].ToString();
            }
            int RouteId = Convert.ToInt32(lblRouteId.Text);
            int sum = RouteId + 1;
            lblRouteId.Text = sum.ToString();
            await Task.Delay(10);
        }
        private async Task ProdCodeCondition()
        {
            try
            {
                cm = new SqlCommand("SELECT prodCode,pcategory,pvendor,pmodel,pdepartment,pworker FROM Product WHERE prodCode='" + txtProdCode.Text + "' OR prodCode='*" + txtProdCode.Text + "'", connect.EstablishConnection(lblFullname.Text));
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    txtProdCode.Text = dr[0].ToString();
                    txtCategory.Text = dr[1].ToString();
                    txtVendor.Text = dr[2].ToString();
                    txtModel.Text = dr[3].ToString();
                    cmbFrmDep.Text = dr[4].ToString();
                    txtFrmWorker.Text = dr[5].ToString();
                }
                if (dr.HasRows == false)
                {
                    MessageBox.Show("Please enter a valid product code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = Clear();
                    return;
                }
                await MaxRouteId();
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in RouteModule Panel when finding items. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in RouteModule Panel when finding items. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                dra.Close();
                connect.CloseConnection();
            }
        }
        private async Task UpdateRoutes()
        {
            try
            {
                if (string.IsNullOrEmpty(txtProdCode.Text) || string.IsNullOrEmpty(cmbFrmDep.Text) || string.IsNullOrEmpty(cmbToDep.Text) || string.IsNullOrEmpty(date.Text))
                {
                    MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this route?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await ClearItems();
                    string query = @"
                    UPDATE Route
                    SET 
                          prodCode = @prodCode,
                          ToDep = @ToDep,
                          ToWorker = @ToWorker,
                          Date = @Date,
                          Description = @Description
                    WHERE 
                          RouteId=@routeId";
                    cm = new SqlCommand(query, connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@routeId", lblRouteId.Text);
                    cm.Parameters.AddWithValue("@ProdCode", Convert.ToInt16(txtProdCode.Text));
                    cm.Parameters.AddWithValue("@ToDep", cmbToDep.Text);
                    cm.Parameters.AddWithValue("@ToWorker", txtToWorker.Text);
                    cm.Parameters.AddWithValue("@Date", date.Text);
                    cm.Parameters.AddWithValue("@Description", txtDesc.Text);
                    cm.ExecuteNonQuery();
                    if (cm != null)
                    {
                        MessageBox.Show("Route has been successfully updated.");
                        Logger.WriteUserLog(lblFullname.Text, " updated a route with Product Code: [" + txtProdCode.Text + "], From Department: [" + cmbFrmDep.Text + "],From Worker: [" + txtFrmWorker.Text + "], To Department[" + cmbToDep.Text + "], To Worker: [" + txtToWorker.Text + "], Date: [" + date.Text + "] in Route Table");
                        Logger.WriteAllLog(lblFullname.Text, " updated a route with Product Code: [" + txtProdCode.Text + "], From Department: [" + cmbFrmDep.Text + "],From Worker: [" + txtFrmWorker.Text + "], To Department[" + cmbToDep.Text + "], To Worker: [" + txtToWorker.Text + "], Date: [" + date.Text + "] in Route Table");
                        connect.CloseConnection();
                    }
                    else
                    {
                        MessageBox.Show("Route has not been updated!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.WriteUserLog(lblFullname.Text, " | Error occured when updating routing in Route Section. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured when updating routing in Route Section. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private void btnSave_Click(object sender, EventArgs e) => _ = SaveRoutes();
        private void btnExit_Click(object sender, EventArgs e)=>this.Dispose();
        private void btnUpdate_Click(object sender, EventArgs e) => _ = UpdateRoutes();
        private void btnClear_Click(object sender, EventArgs e)
        {
            _=Clear();
            txtProdCode.Enabled = true;
            txtFrmWorker.Enabled = true;
            cmbFrmDep.Enabled = true;
        }
        private void txtProdCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProdCode.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtProdCode.Text = "Код";
                }
                else
                    txtProdCode.Text = "Code";
            }
            else
            {
                _ = ProdCodeCondition();
                DisableTexts();
            }
        }
        #region Design
        private void txtProdCode_Enter(object sender, EventArgs e)
        {
            if (txtProdCode.Text == "Code")
            {
                txtProdCode.Text = "";
            }
        }
        private void txtCategory_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtCategory.Text = "Категория";
                }
                else
                txtCategory.Text = "Category";
            }
        }
        private void txtCategory_Enter(object sender, EventArgs e)
        {
            if(txtCategory.Text == "Category"||txtCategory.Text== "Категория")
            {
                txtCategory.Text = "";
            }
        }
        private void txtVendor_Enter(object sender, EventArgs e)
        {
            if (txtVendor.Text == "Vendor"||txtVendor.Text== "Продавец")
            {
                txtVendor.Text = "";
            }
        }
        private void txtVendor_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVendor.Text))
            {
                if(lblLanguage.Text== "Russian")
                {
                    txtVendor.Text = "Продавец";
                }
                else
                txtVendor.Text = "Vendor";
            }
        }
        private void txtModel_Enter(object sender, EventArgs e)
        {
            if (txtModel.Text == "Model"||txtModel.Text== "Модель")
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
        private void cmbFrmDep_Enter(object sender, EventArgs e)
        {
            if(cmbFrmDep.Text =="From Department"||cmbFrmDep.Text== "Из отдела")
            {
                cmbFrmDep.Text = "";
            }
        }
        private void cmbFrmDep_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFrmDep.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbFrmDep.Text = "Из отдела";
                }
                else
                cmbFrmDep.Text = "From Department";
            }
        }
        private void txtFrmWorker_Enter(object sender, EventArgs e)
        {
            if(txtFrmWorker.Text=="From Worker"||txtFrmWorker.Text== "От Работника")
            {
                txtFrmWorker.Text = "";
            }
        }
        private void txtFrmWorker_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrmWorker.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtFrmWorker.Text = "От Работника";
                }
                else
                txtFrmWorker.Text = "From Worker";
            }
        }
        private void cmbToDep_Enter(object sender, EventArgs e)
        {
            if(cmbToDep.Text=="To Department"||cmbToDep.Text== "В отдел")
            {
                cmbToDep.Text = "";
            }
        }
        private void cmbToDep_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbToDep.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbToDep.Text = "В отдел";
                }
                else
                cmbToDep.Text = "To Department";
            }
        }
        private void txtToWorker_Enter(object sender, EventArgs e)
        {
            if(txtToWorker.Text=="To Worker"||txtToWorker.Text== "Работнику")
            {
                txtToWorker.Text = "";
            }
        }
        private void txtToWorker_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtToWorker.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtToWorker.Text = "Работнику";
                }
                else
                txtToWorker.Text = "To Worker";
            }
        }
        private void txtDesc_Enter(object sender, EventArgs e)
        {
            if (txtDesc.Text == "Description"||txtDesc.Text== "Описание")
            {
                txtDesc.Text = "";
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
        private void RouteModel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void RouteModel_KeyDown(object sender, KeyEventArgs e)
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

        #endregion
    }
}
