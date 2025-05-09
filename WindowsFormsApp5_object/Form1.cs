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
using WindowsFormsApp_07_Class;

namespace WindowsFormsApp5_object
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // --- #4-1. 기본 생성자
            Car car1 = new Car();
            car1.Speed = 20;
            car1.Color = "은색";
            car1.PrintInfo();

            Console.WriteLine("-------------------");

            // --- #4-2. 매개변수 있는 생성자
            Car car2 = new Car("그랜저", 50, "검정", 2024);
            car2.Accelerate(30);
            car2.PrintInfo();
            Console.WriteLine("-------------------");

            // --- #6. 메서드 사용
            car2.Brake(100);
            Console.WriteLine("-------------------");
            // --- #7. static 메서드 호출
            Car.ShowTotalCars();
        }
    }
}


