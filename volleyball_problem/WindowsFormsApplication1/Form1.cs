using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnHitung_Click(object sender, EventArgs e)
        {
            //variabel
            string operand1 = Txt1.Text;
            string operand2 = Txt2.Text;
            double opr1, opr2;
            
            double.TryParse(operand1, out opr1);
            double.TryParse(operand2, out opr2);
            
            //hasil
            TxtHasil.Text = kombinasi(opr1,opr2).ToString();
            
        }
        public static double kombinasi(double a, double b)
        {
            double result1=1,result2=1,resultfinal=0,angka1, angka2;

            if ((a < 25 && b < 25) || (a == b) || (a == 25 && b == 24))
                //something goes wrong
                return 0;
            else if (a == 25 && b<25 || b == 25 && a <25)
            {
                if (a < b)
                {
                    angka1 = b - 1;
                    angka2 = a;
                }
                else
                {
                    angka1 = a - 1;
                    angka2 = b;
                }
                for (double i = (angka1 + angka2); i > angka1; i--)
                {
                    result1 *= i;
                }
                for (double i = 1; i <= angka2; i++)
                {
                    result2 *= i;
                }
                resultfinal = Math.Round(result1 / result2);
            }
            else if (Math.Max(a, b) > 25 && (Math.Abs(a - b) == 2))
            {
                //seri
                for (double i = 48; i > 24; i--)
                {
                    result1 *= i;
                }
                for (double i = 1; i <= 24; i++)
                {
                    result2 *= i;
                }
                resultfinal = ((Math.Round(result1/result2))%1000000007) * (pow(2, (Math.Min((long)a, (long)b) - 24)) % 1000000007);
            }
            else
                return 0;
            while (resultfinal > (Math.Pow(10, 9) + 7))
                resultfinal %= (Math.Pow(10, 9) + 7);
            return resultfinal;
        }
        public static long pow(long b, long n)
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return b;
            long halfn = pow(b, n / 2);
            if (n % 2 == 0)
                return (halfn * halfn) % 1000000007;
            else
                return ((halfn * halfn) % 1000000007) * b;
        }
    }
}
