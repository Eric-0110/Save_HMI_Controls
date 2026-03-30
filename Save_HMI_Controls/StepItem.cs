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
    public partial class StepItem : UserControl
    {
        public StepItem()
        {
            InitializeComponent();
            antSteps1.Current = 1;
            antSteps2.Current = 2;
            antSteps3.Current = 3;
            antSteps4.Current = 2;
            antSteps5.Current = 1;
            antSteps6.Current = 2;
            antSteps7.Current = 3;
            antSteps8.Current = 4;
            antSteps9.Current = 1;
            antSteps13.Current = 2;
            antSteps11.Current = 3;
            antSteps14.Current = 1;
            antSteps15.Current = 3;
            antSteps16.Current = 2;
            antSteps17.Current = 3;
            antSteps18.Current = 3;
        }

        private void antSteps8_CurrentChanged(object sender, int e)
        {

        }
    }
}
