using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedModels.Models;

namespace ICT4Events.Views.Reservation_System
{
    public partial class ReservationSystemForm : Form
    {
        private User _user;

        public ReservationSystemForm(User user)
        {
            InitializeComponent();
            _user = user;
        }
    }
}
