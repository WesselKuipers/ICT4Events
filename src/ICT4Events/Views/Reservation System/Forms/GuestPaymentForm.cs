using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Events.Views.Reservation_System.Forms
{
    public partial class GuestPaymentForm : Form
    {
        public GuestPaymentForm(decimal amount)
        {
            InitializeComponent();
            lblPaymentAmount.Text = amount.ToString("C", new CultureInfo("nl-NL"));
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
