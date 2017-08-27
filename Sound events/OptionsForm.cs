using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.DirectSound;
using CSCore.SoundOut;
using System.Collections.ObjectModel;

namespace Sound_events
{
    public partial class OptionsForm : Form
    {
        public Guid MicIndex, OutIndex;
        public List<Guid> deviceList;

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            var devices = DirectSoundDeviceEnumerator.EnumerateDevices();
            deviceList = new List<Guid>();
            foreach (var device in devices)
            {
                deviceList.Add(device.Guid);
                cmbMic.Items.Add(device.Description);
                cmbOut.Items.Add(device.Description);
            }

            //for (int deviceId = 0; deviceId < WaveOut.DeviceCount; deviceId++)
            //{
            //    var capabilities = WaveOut.GetCapabilities(deviceId);
            //    cmbMic.Items.Add(capabilities.ProductName);
            //    cmbOut.Items.Add(capabilities.ProductName);
            //}

            if (deviceList.Contains(MicIndex))
                cmbMic.SelectedIndex = deviceList.IndexOf(MicIndex);
            if (deviceList.Contains(OutIndex))
                cmbOut.SelectedIndex = deviceList.IndexOf(OutIndex);
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

        private void cmbOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            OutIndex = deviceList[cmbOut.SelectedIndex];
        }

        private void cmbMic_SelectedIndexChanged(object sender, EventArgs e)
        {
            MicIndex = deviceList[cmbMic.SelectedIndex];
        }
    }
}
