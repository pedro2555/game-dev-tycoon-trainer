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
            this.Icon = new System.Drawing.Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("SimpleTrainer.icon.ico"));

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
                foreach (Match m1 in reg1.Matches(m.Groups[1].ToString(), 0))
                    switch (index)
                    {
                        case 0:
                            txt0Design.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 1:
                            txt1Design.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 2:
                            txt2Design.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 3:
                            txt3Design.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 4:
                            txt4Design.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 5:
                            txt5Design.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 6:
                            txt6Design.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                    }
                // Technology
                reg1 = new Regex("\\\"tF\":(.*?)\\,");
                foreach (Match m1 in reg1.Matches(m.Groups[1].ToString(), 0))
                    switch (index)
                    {
                        case 0:
                            txt0Tech.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 1:
                            txt1Tech.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 2:
                            txt2Tech.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 3:
                            txt3Tech.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 4:
                            txt4Tech.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 5:
                            txt5Tech.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 6:
                            txt6Tech.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                    }
                // Speed
                reg1 = new Regex("\\\"speedF\":(.*?)\\,");
                foreach (Match m1 in reg1.Matches(m.Groups[1].ToString(), 0))
                    switch (index)
                    {
                        case 0:
                            txt0Speed.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 1:
                            txt1Speed.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 2:
                            txt2Speed.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 3:
                            txt3Speed.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 4:
                            txt4Speed.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 5:
                            txt5Speed.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 6:
                            txt6Speed.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                    }
                // Research
                reg1 = new Regex("\\\"researchF\":(.*?)\\,");
                foreach (Match m1 in reg1.Matches(m.Groups[1].ToString(), 0))
                    switch (index)
                    {
                        case 0:
                            txt0Research.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 1:
                            txt1Research.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 2:
                            txt2Research.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 3:
                            txt3Research.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 4:
                            txt4Research.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 5:
                            txt5Research.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                        case 6:
                            txt6Research.Text = gdtDBHelper.FactorToInt(Double.Parse(m1.Groups[1].ToString().Replace('.', ','))).ToString();
                            break;
                    }
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

            /*
             * blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                blob = blob.Insert(m.Groups[1].Index, txtCash.Text);
             */


            string blob = gdtDBHelper.getBlob();
            int startIndex = blob.IndexOf("\"company\":{");
            // Name
            Regex reg = new Regex("\\\"name\":\"(.*?)\\\","); // "\\ from this (.*?)\\ to this "
            foreach (Match m in reg.Matches(blob, startIndex))
            {
                blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                blob = blob.Insert(m.Groups[1].Index, txtName.Text);
                break;
            }
            // Cash
            reg = new Regex("\\\"cash\":(.*?)\\,");
            foreach (Match m in reg.Matches(blob, startIndex))
            {
                blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                blob = blob.Insert(m.Groups[1].Index, txtCash.Text);

                break;
            }
            // Fans
            reg = new Regex("\\\"fans\":(.*?)\\,");
            foreach (Match m in reg.Matches(blob, startIndex))
            {
                blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                blob = blob.Insert(m.Groups[1].Index, txtFans.Text);
                break;
            }
            // Fans
            reg = new Regex("\\\"researchPoints\":(.*?)\\,");
            foreach (Match m in reg.Matches(blob, startIndex))
            {
                blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                blob = blob.Insert(m.Groups[1].Index, txtResearchPoints.Text);
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
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, txt0Name.Text);
                            break;
                        case 1:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, txt1Name.Text);
                            break;
                        case 2:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, txt2Name.Text);
                            break;
                        case 3:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, txt3Name.Text);
                            break;
                        case 4:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, txt4Name.Text);
                            break;
                        case 5:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, txt5Name.Text);
                            break;
                        case 6:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, txt6Name.Text);
                            break;
                    }
                // Design
                reg1 = new Regex("\\\"dF\":(.*?)\\,");
                foreach (Match m1 in reg1.Matches(m.Groups[1].ToString(), 0))
                    switch (index)
                    {
                        case 0:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt0Design.Text.Replace(',', '.'))).ToString());
                            break;
                        case 1:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt1Design.Text.Replace(',', '.'))).ToString());
                            break;
                        case 2:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt2Design.Text.Replace(',', '.'))).ToString());
                            break;
                        case 3:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt3Design.Text.Replace(',', '.'))).ToString());
                            break;
                        case 4:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt4Design.Text.Replace(',', '.'))).ToString());
                            break;
                        case 5:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt5Design.Text.Replace(',', '.'))).ToString());
                            break;
                        case 6:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt6Design.Text.Replace(',', '.'))).ToString());
                            break;
                    }
                // Technology
                reg1 = new Regex("\\\"tF\":(.*?)\\,");
                foreach (Match m1 in reg1.Matches(m.Groups[1].ToString(), 0))
                    switch (index)
                    {
                        case 0:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt0Tech.Text.Replace(',', '.'))).ToString());
                            break;
                        case 1:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt1Tech.Text.Replace(',', '.'))).ToString());
                            break;
                        case 2:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt2Tech.Text.Replace(',', '.'))).ToString());
                            break;
                        case 3:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt3Tech.Text.Replace(',', '.'))).ToString());
                            break;
                        case 4:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt4Tech.Text.Replace(',', '.'))).ToString());
                            break;
                        case 5:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt5Tech.Text.Replace(',', '.'))).ToString());
                            break;
                        case 6:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt6Tech.Text.Replace(',', '.'))).ToString());
                            break;
                    }
                // Speed
                reg1 = new Regex("\\\"speedF\":(.*?)\\,");
                foreach (Match m1 in reg1.Matches(m.Groups[1].ToString(), 0))
                    switch (index)
                    {
                        case 0:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt0Speed.Text.Replace(',', '.'))).ToString());
                            break;
                        case 1:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt1Speed.Text.Replace(',', '.'))).ToString());
                            break;
                        case 2:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt2Speed.Text.Replace(',', '.'))).ToString());
                            break;
                        case 3:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt3Speed.Text.Replace(',', '.'))).ToString());
                            break;
                        case 4:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt4Speed.Text.Replace(',', '.'))).ToString());
                            break;
                        case 5:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt5Speed.Text.Replace(',', '.'))).ToString());
                            break;
                        case 6:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt6Speed.Text.Replace(',', '.'))).ToString());
                            break;
                    }
                // Research
                reg1 = new Regex("\\\"researchF\":(.*?)\\,");
                foreach (Match m1 in reg1.Matches(m.Groups[1].ToString(), 0))
                    switch (index)
                    {
                        case 0:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt0Research.Text.Replace(',', '.'))).ToString());
                            break;
                        case 1:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt1Research.Text.Replace(',', '.'))).ToString());
                            break;
                        case 2:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt2Research.Text.Replace(',', '.'))).ToString());
                            break;
                        case 3:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt3Research.Text.Replace(',', '.'))).ToString());
                            break;
                        case 4:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt4Research.Text.Replace(',', '.'))).ToString());
                            break;
                        case 5:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt5Research.Text.Replace(',', '.'))).ToString());
                            break;
                        case 6:
                            blob = blob.Remove(m.Groups[1].Index, m.Groups[1].Length);
                            blob = blob.Insert(m.Groups[1].Index, gdtDBHelper.FactorToDouble(Double.Parse(txt6Research.Text.Replace(',', '.'))).ToString());
                            break;
                    }
                index++;
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
                if (gdtDBHelper.BackupDB())
                {
                    if (SaveBlob())
                    {
                        Update();
                        MessageBox.Show("Stats updated successfully!", "Game stats updated!");

                    }
                }
                else
                    MessageBox.Show("Stats could not be updated!", "Failed to update!");
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
