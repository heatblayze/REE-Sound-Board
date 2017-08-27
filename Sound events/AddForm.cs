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

namespace Sound_events
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        public bool AllowFileEdit = true;
        public ModifierKeys mods;
        public List<Keys> keys = new List<Keys>();
        public string sound, icon;
        public float Volume = 0.3f;
        public bool UseEcho;
        public float EchoAmount = 50;

        bool modready;
        bool keyready;

        private void AddForm_Load(object sender, EventArgs e)
        {
            if (!AllowFileEdit)
            {
                txtSound.Enabled = false;
                txtIcon.Enabled = false;
                btnSound.Enabled = false;
                btnImage.Enabled = false;
            }

            txtSound.Text = sound;
            txtIcon.Text = icon;

            string text = "";
            for (int i = 0; i < keys.Count; i++)
            {
                text += keys[i].ToString();

                if (i < keys.Count - 1)
                    text += " + ";
            }

            txtKey.Text = text;
            txtMod.Text = mods.ToString();
            trackVolume.Value = (int)(Volume * 100);
            chkEcho.Checked = UseEcho;
            trackEcho.Value = (int)EchoAmount;
            trackEcho.Enabled = UseEcho;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            try
            {
                dlg.InitialDirectory = Path.GetDirectoryName(sound);
            }
            catch
            {

            }
            dlg.Title = "Open sound file";
            var result = dlg.ShowDialog();

            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                txtSound.Text = dlg.FileName;
                sound = txtSound.Text;
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            try
            {
                dlg.InitialDirectory = Path.GetDirectoryName(icon);
            }
            catch
            {

            }
            dlg.Title = "Open icon file";
            var result = dlg.ShowDialog();

            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                txtIcon.Text = dlg.FileName;
                icon = txtIcon.Text;
            }
        }

        private void txtMod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None)
                return;

            if (modready)
            {
                modready = false;
                mods = Sound_events.ModifierKeys.None;
            }

            ModifierKeys modifier = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), e.Modifiers.ToString());
            mods = modifier;
            txtMod.Text = mods.ToString();
        }

        private void txtMod_KeyUp(object sender, KeyEventArgs e)
        {
            modready = true;
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.None)
                return;

            if (keyready)
            {
                keyready = false;
                keys.Clear();
            }

            if (!keys.Contains(e.KeyCode))
            {
                keys.Add(e.KeyCode);
            }
            string text = "";
            for (int i = 0; i < keys.Count; i++)
            {
                text += keys[i].ToString();

                if (i < keys.Count - 1)
                    text += " + ";
            }

            txtKey.Text = text;
        }

        private void txtKey_KeyUp(object sender, KeyEventArgs e)
        {
            keyready = true;
        }

        private void txtMod_Enter(object sender, EventArgs e)
        {
            modready = true;
        }

        private void txtMod_Leave(object sender, EventArgs e)
        {
            modready = false;
        }

        private void txtKey_Leave(object sender, EventArgs e)
        {
            keyready = false;
        }

        private void txtSound_TextChanged(object sender, EventArgs e)
        {
            sound = txtSound.Text;
        }

        private void txtIcon_TextChanged(object sender, EventArgs e)
        {
            icon = txtIcon.Text;
        }       

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Volume = trackVolume.Value / 100.0f;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
        }

        private void chkEcho_CheckedChanged(object sender, EventArgs e)
        {
            trackEcho.Enabled = chkEcho.Checked;
            UseEcho = chkEcho.Checked;
        }

        private void trackEcho_Scroll(object sender, EventArgs e)
        {
            EchoAmount = trackEcho.Value;
        }

        private void txtKey_Enter(object sender, EventArgs e)
        {
            keyready = true;
        }
    }
}
