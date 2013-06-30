using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GameDevTycoon
{
    public partial class mainForm : Form
{
        public mainForm()
        {
            InitializeComponent();
        }

        public new void Update()
        {
            base.Update();
            if (gdtDBHelper.isGameRunning())
                return;
            string blob = gdtDBHelper.getBlob();

            int startIndex = blob.IndexOf("\"company\":{");
            // Name
            Regex reg = new Regex("\\\"name\":\"(.*?)\\\","); // "\\ from this (.*?)\\ to this "
            foreach (Match m in reg.Matches(blob, startIndex))
            {
                txtName.Text = m.Groups[1].ToString();
                startIndex = m.Groups[1].Index;
                break;
            }
            // Cash
            reg = new Regex("\\\"cash\":(.*?)\\,");
            foreach (Match m in reg.Matches(blob, startIndex))
            {
                txtCash.Text = m.Groups[1].ToString();
                startIndex = m.Groups[1].Index;
                break;
            }
            // Fans
            reg = new Regex("\\\"fans\":(.*?)\\,");
            foreach (Match m in reg.Matches(blob, startIndex))
            {
                txtFans.Text = m.Groups[1].ToString();
                startIndex = m.Groups[1].Index;
                break;
            }
            // Fans
            reg = new Regex("\\\"researchPoints\":(.*?)\\,");
            foreach (Match m in reg.Matches(blob, startIndex))
            {
                txtResearchPoints.Text = m.Groups[1].ToString();
                startIndex = m.Groups[1].Index;
                break;
            }
            // Staff
            // every staff member is in betwen '{"id":' <==> '}'
            int index = 0;
            startIndex = blob.IndexOf("\"staff\":[");
            reg = new Regex("\\{\"id\":(.*?)\\}");
            foreach (Match m in reg.Matches(blob, startIndex))
            {
                // Name
                Regex reg1 = new Regex("\\,\"name\":\"(.*?)\\\",");
                foreach (Match m1 in reg1.Matches(m.Groups[1].ToString(), 0))
                    switch (index)
                    {
                        case 0:
                            txt0Name.Text = m1.Groups[1].ToString();
                            break;
                        case 1:
                            txt1Name.Text = m1.Groups[1].ToString();
                            break;
                        case 2:
                            txt2Name.Text = m1.Groups[1].ToString();
                            break;
                        case 3:
                            txt3Name.Text = m1.Groups[1].ToString();
                            break;
                        case 4:
                            txt4Name.Text = m1.Groups[1].ToString();
                            break;
                        case 5:
                            txt5Name.Text = m1.Groups[1].ToString();
                            break;
                        case 6:
                            txt6Name.Text = m1.Groups[1].ToString();
                            break;
                    }
                // Design
                reg1 = new Regex("\\\"dF\":(.*?)\\,");

                index++;

            }
        }

        private bool SaveBlob()
        {
            if (gdtDBHelper.isGameRunning())
                return false;
            /// TODO: Test numeric values
            // Cash
            try { Decimal.Parse(txtCash.Text); }
            catch (Exception) { txtCash.BackColor = Color.Red; return false; }
            txtCash.BackColor = Color.White;
            // Fans
            try { Decimal.Parse(txtFans.Text); }
            catch (Exception) { txtFans.BackColor = Color.Red; return false; }
            txtFans.BackColor = Color.White;
            // Research Points
            try { Decimal.Parse(txtResearchPoints.Text); }
            catch (Exception) { txtResearchPoints.BackColor = Color.Red; return false; }
            txtResearchPoints.BackColor = Color.White;



            string blob = gdtDBHelper.getBlob();
            string pattern;
            // Cash
            pattern = "\\\"cash\":(.*?)\\,"; //    "\\ from this (.*?)\\ to this "
            foreach (Match m in Regex.Matches(blob, pattern))
            {
                blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                blob = blob.Insert(m.Groups[1].Index, txtCash.Text);
                break;
            }
            // Fans
            pattern = "\\\"fans\":(.*?)\\,"; //    "\\ from this (.*?)\\ to this "
            foreach (Match m in Regex.Matches(blob, pattern))
            {
                blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                blob = blob.Insert(m.Groups[1].Index, txtFans.Text);
                break;
            }
            // Reserach Points
            pattern = "\\\"researchPoints\":(.*?)\\,"; //    "\\ from this (.*?)\\ to this "
            foreach (Match m in Regex.Matches(blob, pattern))
            {
                blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                blob = blob.Insert(m.Groups[1].Index, txtResearchPoints.Text);
                break;
            }

            gdtDBHelper.setBlob(blob);
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gdtDBHelper.isGameRunning())
                if (MessageBox.Show("Game Dev Tycoon should NOT be running! Stop any instance of Game Dev Tycoon and click OK to continue, click Cancel to abort.", "Game Dev Tycoon is running!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    btnSave_Click(sender, e);
                else
                    return;
            else
                if (SaveBlob())
                {
                    gdtDBHelper.BackupDB();
                    Update();
                    MessageBox.Show("Stats updated successfully!", "Game stats updated!");
                }
        }

        private void mainForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            AboutBox frm = new AboutBox();
            frm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Update();
        }

        

        private void mainForm_Load(object sender, EventArgs e)
        {
            if (gdtDBHelper.isGameRunning())
            {
                MessageBox.Show("Game Dev Tycoon should NOT be running! Stop any instance of Game Dev Tycoon and try again.", "Game Dev Tycoon is running!");
                Application.Exit();
            }
            else
            {
                cmbSlot.SelectedIndex = 0;
            }
        }

        private void cmbSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            gdtDBHelper.CurrentSlot = cmbSlot.SelectedItem.ToString();
            Update();
        }

        private void btnRestoreDB_Click(object sender, EventArgs e)
        {
            gdtDBHelper.RestoreDB();
        }

    }
}
