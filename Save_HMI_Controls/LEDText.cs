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
    public partial class LEDText : UserControl
    {
        public LEDText()
        {
            InitializeComponent();
            DateTime today = DateTime.Today;
            string dateString = today.ToString("yyyy-MM-dd");
            label4.Text = dateString;
        }
    }
}
