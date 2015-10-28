using System;
using System.Windows.Forms;

namespace ICT4Events.Views.SocialSystem.Forms
{
    public partial class ReportPostForm : Form
    {
        public string ReasonReturnValue { get; private set; }

        public ReportPostForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // this button sets the DialogResult to DialogResult.OK 
            // that way we can be sure that a reason has been given in the calling form
            if (!string.IsNullOrWhiteSpace(txtReason.Text))
            {
                ReasonReturnValue = txtReason.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Vul eerst een reden voor dit rapport in a.u.b.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
