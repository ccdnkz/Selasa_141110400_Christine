using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dstart = new DateTime(2016, 1, 1);
            DateTime dend = new DateTime(2016, 12, 31);
            monthCalendar1.AddAnnuallyBoldedDate(new DateTime(1997,4,27));
            while (dstart.DayOfWeek != DayOfWeek.Saturday && dstart.DayOfWeek != DayOfWeek.Sunday)
                dstart = dstart.AddDays(1);
            List<DateTime> list = new List<DateTime>();
            while(dstart<dend)   
            {
              //Add Saturday
              list.Add(dstart);
              dstart = dstart.AddDays(1);
              //Add Sunday
              list.Add(dstart);
              //Move to next week.
              dstart = dstart.AddDays(6);
            }
            monthCalendar1.BoldedDates = list.ToArray();
            monthCalendar1.UpdateBoldedDates();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
