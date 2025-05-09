using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5_object
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //생성자
            Car car1 = new Car();
            car1.speed = 20;
            car1.color = "은색";
            car1.print();


            Console.WriteLine("\r\n-----------------------\r\n");

            Car car2 = new Car("그랜저", 50, "검정", 2024);
            car2.print();
            car2.accel(30);
            car2.print();



        }
    }

    
}
