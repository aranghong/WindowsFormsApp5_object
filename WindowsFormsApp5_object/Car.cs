using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5_object
{
    internal class Car
    {
        private int _speed;
        private string _modelName;
        private int year;
        private readonly string manufacturer = "현대";

        public static int totalCar = 0;

        public int speed
        {
            get { return _speed; }
            set
            {
                if (value < 0) _speed = 0;   //음수 방지
                else _speed = value;
            }
        }

        public string color { get; set; }

        public string modelName
        {
            get { return _modelName; }
            private set { _modelName = value; }
        }


        public bool IsNewCar
        {
            get { return year >= 2023; }
        }


        public string summary
        {
            get { return $"{year}년식 {manufacturer} {modelName} - {color} - {speed} \r\n"; }
        }

        //생성자
        public Car()
        {
            modelName = "이름 없는 차";
            speed = 0;
            color = "회색";
            year = 2000;
            totalCar++;

            Console.WriteLine("기본 생성자 car 생성");

        }

        public Car(string model, int speed, string color, int year)
        {
            modelName = model;
            _speed = speed;
            this.color = color;
            this.year = year;
            totalCar++;

            Console.WriteLine($"{model} 객체 생성");
        }

        //소멸자
        ~Car()
        {
            Console.WriteLine($"{modelName} 객체가 메모리에서 삭제");
        }

        //메서드
        public void accel(int amount)
        {
            speed += amount;
            Console.WriteLine("속도 증가");
        }
        public void brake(int amount)
        {
            speed -= amount;
            if (speed < 0) speed = 0;
            Console.WriteLine("속도 감소");
        }

        public void print()
        {
            Console.WriteLine("-----차량 정보-------");
            Console.WriteLine($"제조사: {manufacturer}");
            Console.WriteLine($"모델명: {modelName}");
            Console.WriteLine($"색상: {color}");
            Console.WriteLine($"속도: {speed}");
            Console.WriteLine($"생산년도: {year}");
            Console.WriteLine($"신차여부: {(IsNewCar ? "신차!!" : "구형 차량")}");
            Console.WriteLine($"요약: {summary}");
            Console.WriteLine($"총 생산 차량 수: {totalCar}");
        }
    }
}
