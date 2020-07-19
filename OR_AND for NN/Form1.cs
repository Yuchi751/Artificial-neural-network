using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int[] x1 = new int[100];//輸入1
        int[] x2 = new int[100];//輸入2
        double[] w1 = new double[100];//權重1
        double[] w2 = new double[100];//權重2
        double[] ex = new double[100];//期望值
        double[] tt = new double[100];//實際輸出
        double[] z = new double[100];
        double[] zz = new double[100];
        double Threshold = 0.1;//邊界值
        double learn_person = 0.2;//學習值
        double[] y = new double[100];
        string ans = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            w1[0] = 0.3;//權重1
            w2[0] = -0.2;//權重2
            int i = 0;
            double decide1 = 0.0;
            double decide2 = 0.0;
            Random rnd = new Random();
            for (i = 0; i <= x1.Length - 2; i++)
            {
                decide1 = rnd.NextDouble();//亂數值1
                decide2 = rnd.NextDouble();//亂數值2
                if (decide1 <= 0.5)
                { x1[i] = 1;}
                else
                { x1[i] = 0;}
                if (decide2 <= 0.5)
                { x2[i] = 1;}
                else
                { x2[i] = 0;}
                z[i] = x1[i] | x2[i]; //OR
                z[i] = x1[i] & x2[i]; //AND
                z[i] = x1[i] ^ x2[i]; //XOR
                int a = Math.Sign((x1[i] * w1[i] + x2[i] * w2[i]) - Threshold);
                if (a >= 0)
                { y[i] = 1;}
                else
                { y[i] = 0;}
                w1[i + 1] = w1[i] + (x1[i] * learn_person * (z[i] - y[i]));
                w2[i + 1] = w2[i] + (x2[i] * learn_person * (z[i] - y[i]));
                ans += x1[i] + "," + x2[i] + "," + w1[i] + "," + w2[i] + "," + z[i] + "," + y[i] + "," + ((z[i] - y[i])) + "..";
            }
            ra(ans);
            Close();
        }

        void ra(string ans)
        {
            FileStream fs = new FileStream(@"C:\Users\Windows 10\Desktop\test1.txt", FileMode.OpenOrCreate);
            StreamWriter st = new StreamWriter(fs);

            st.WriteLine(ans);
            st.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
