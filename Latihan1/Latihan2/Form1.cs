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
        Dictionary<string, int> months = new Dictionary<string, int>();
        string name_month = "";
        DateTime tanggal;
        public Form1()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dstart = new DateTime(2016, 1, 1);
            DateTime dend = new DateTime(2016, 12, 31);
            //birthday_bolded_dates
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
            if (domainUpDown1.Text != "Month")
            {
                monthCalendar1.AddAnnuallyBoldedDate(
                    new DateTime(DateTime.Now.Year, months[domainUpDown1.Text], Convert.ToInt32(numericUpDown1.Value)));
                monthCalendar1.UpdateBoldedDates();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tanggal = new DateTime(DateTime.Now.Year, 1, DateTime.Now.Day);
            for (int i = 1; i <= 12; i++)
            {
                name_month = tanggal.ToString("MMMM");
                months.Add(name_month, i);
                tanggal = tanggal.AddMonths(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (domainUpDown1.Text != "Month")
            {
                monthCalendar1.RemoveAnnuallyBoldedDate(
                    new DateTime(DateTime.Now.Year, months[domainUpDown1.Text], Convert.ToInt32(numericUpDown1.Value)));
                monthCalendar1.UpdateBoldedDates();
            }
        }
    }
}
