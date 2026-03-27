using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_HMI_Controls
{
    public partial class IndustrialDevice : UserControl
    {
        public IndustrialDevice()
        {
            InitializeComponent();
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void buttonGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = buttonGroup1.Items.FirstOrDefault(i => i.Selected);
            if (selectedItem != null && selectedItem.Text != null)
            {
                string action = selectedItem.Text.ToString();
                switch (action)
                {
                    case "停止":
                        industrialDevice12.Status = LYHControls.IndustrialDevice.DeviceStatus.Stopped;
                        break;
                    case "运行":
                        industrialDevice12.Status = LYHControls.IndustrialDevice.DeviceStatus.Running;
                        break;
                    case "故障":
                        industrialDevice12.Status = LYHControls.IndustrialDevice.DeviceStatus.Fault;
                        break;
                }
            }
        }
    }
}
