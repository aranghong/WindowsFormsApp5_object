using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 클래스 만들기 순서
 * 1. class 이름 정의
 * 2. 필드 작성
 * 3. 속성 작성
 * 4. 생성자 작성
 * 5. 메서드 작성
 * 6. Main에서 객체 만들어 사용.
 */

/*
 * class 이름 작성법
 * - 파스칼 표기법 사용
 * - 언더스코어(_) X
 * - 클래스 1개 = 파일 1개 '관례적' 원칙 (강요 X, 권장 O)
 * Why?
 * - 여러 클래스 넣으면 어떤 파일에 어떤 클래스가 들어 있는지 헷갈림.
 * - 충돌 위험
 * - 재사용성 떨어짐
 * - 버전관리(Git) 힘듦.
 */

namespace WindowsFormsApp_07_Class
{
    // 1. 클래스 선언
    // - 객체를 만들기 위한 설계도(틀)
    internal class Car
    {
        #region 2. 필드
        /*
         * 필드 = 데이터를 저장하는 변수
         * 클래스 내부에서 데이터를 보관하는 공간
         * 외부에서 직접 접근하면 문제가 생길 수 있으므로 보통 private 사용.
         * 필드 이름은 camelCase 로 작성 할 것!
         */

        // --- #2-1. 일반 필드 선언
        private int speed;          // 자동차 속도
        private string modelName;   // 자동차 모델명
        private int year;           // 자동차 생산년도

        // --- #2-2. readonly 필드
        // - readonly 키워드 사용!
        // - 초기화한 이후 값을 바꿀 수 없는 필드! (= 불변 데이터용)
        // - ㄴ 생성자에서는 값을 한 번 정할 수 있음.
        // Why?
        // - 한번 설정되면 절대 바뀌지 않아야 하는 값(데이터)을 보호하고 싶을 때!
        private readonly string manufacturer = "Hyundai";

        // --- #2-3. static 필드
        // - static 키워드 사용!
        // - 모든 객체가 공유하는 데이터 (= 모든 Car 객체가 공유)
        private static int totalCars = 0;
        #endregion

        #region 3. 속성
        /*
         * 속성 = 필드에 안전하게 접근할 수 있도록 해주는 통로.
         * ㄴ 필드에 직접 접근하는 것을 막고, 값을 읽거나 쓸 때 조건 검사 기능.
         */

        // --- #3-1. 기본 속성 형태 (유효성 검사 포함 가능)
        /*
         * get & set 키워드란?
         * get: 값을 읽을 때 실행 (= 데이터를 가져가는 역할) / 읽기
         * set: 값을 쓸 때 실행 (= 데이터를 저장하는 역할) / 쓰기
         * value: 외부에서 전달된 값 (자동 제공되는 변수) - set 안에서만 사용 가능!
         */

        public int Speed
        {
            get { return speed; }
            set
            {
                if (value < 0) speed = 0; // 음수 방지
                else speed = value;
            }
        }

        // --- #3-2. 자동 구현 속성
        // - 특별한 조건 검사 없이 단순히 값을 저장하고 꺼낼 때 사용.
        public string Color { get; set; }
        /*
         * 자동으로 아래와 같이 처리됨.
         * - 자동으로 숨겨진 필드를 만들어서 처리함.
         * 
         * public string Color
         * {
         *      get { return (자동 생성된 필드);}
         *      set { (자동 생성된 필드) = value;
         * }
         */

        // --- #3-3. 읽기 전용 속성
        // - 외부에서는 읽기만 가능. 내부에서만 값 설정
        public string ModelName
        {
            get { return modelName; }
            private set { modelName = value; }
        }

        // --- #3-4. 계산 결과 제공 속성
        // - 데이터 보관용 (x)
        // - 계산 결과 제공 (o)
        // - 외부에서 값을 직접 비교할 필요 없이 속성을 읽기만 하면
        //   여부를 쉽게 알 수 있음

        public bool IsNewCar    // 신차 판단
        {
            get { return year >= 2023; }
        }

        // --- #3-5. 표현 속성 (출력용)
        // - 필드 값을 조합해서 보기 좋은 문자열 형태로 가공해서 제공하는 속성.
        public string Summary
        {
            get
            {
                return $"{year}년식 {manufacturer} {ModelName} - {Color} - {Speed}km/h";
            }
        }
        #endregion

        #region 4. 생성자
        /*
         * 생성자 = 객체가 만들어질 때 (new 키워드 사용시) 자동으로 실행되는 특별한 메서드.
         * 필드나 속성을 초기화(값 설정)하는 용도로 사용.
         * 반환형이 없으며 클래스 이름과 동일
         * 여러 개 만들 수 있는데 -> 생성자 오버로딩
         * ㄴ 오버로딩 : 같은 이름이지만 매개변수가 다른 메서드를 여러 개 만드는 것.
         */

        // --- #4-1. 기본 생성자 (없으면 자동 제공)
        public Car()
        {
            ModelName = "이름 없는 차";
            Speed = 0;
            Color = "회색";
            year = 2000;

            totalCars++; // 자동차 총 생산량 증가

            Console.WriteLine("기본 생성자로 Car 객체가 만들어졌습니다.");
        }

        // --- #4-2. 매개변수 있는 생성자
        public Car(string model, int speed, string color, int year)
        {
            ModelName = model;
            Speed = speed;
            Color = color;
            this.year = year;

            totalCars++;

            Console.WriteLine($"{model} 객체 생성 완료!");
        }
        #endregion

        #region 5. 소멸자
        /*
         * 소멸자 = 객체가 메모리에서 삭제 될 때 자동으로 호출되는 특별한 메서드
         * ㄴ 객체가 더 이상 사용되지 않으면 -> CLR이 가비지 컬렉션으로 메모리 정리를 할 때 소멸자가 자동 호출
         * Why?
         * - 주로 파일 닫기, DB 연결 종료 등 리소스 정리 용도.
         * 
         * C#은 가비지 컬렉터가 메모리 관리하므로 자주 사용되지 않음. (= 메모리 관리가 자동!)
         * ㄴ 개발자가 객체를 직접 삭제할 필요가 없음.
         * ㄴ 소멸 시점 예측 불가 -> 언제 소멸자가 실행될지 알 수 없음.
         * ㄴ 외부 리소스 다룰 때 사용 (= 가비지 컬렉션으로 자동 처리되지 않는 것들)
         * 
         * 구조
         * ~클래스명()
         * {
         *      종료 시 실행할 코드
         * }
         */
        ~Car()
        {
            Console.WriteLine($"{ModelName} 객체가 메모리에서 삭제됩니다.");
        }
        #endregion

        #region 6. 메서드
        /*
         * 메서드 = 객체가 할 수 있는 행동 (기능)
         * 구조: 접근 제한자 + 반환형 + 이름 + 매개변수 + 본문
         * 같은 이름의 메서드를 매개변수만 다르게 여러 개 만들 수 있음 (오버로딩)
         */

        // --- #6-1. 속도 증가
        public void Accelerate(int amount)
        {
            Speed += amount;
            Console.WriteLine($"{ModelName}의 속도가 {Speed}km/h로 증가했습니다.");
        }

        // --- #6-2. 속도 감소
        public void Brake(int amount)
        {
            Speed -= amount;
            //if (Speed < 0) speed = 0;
            Console.WriteLine($"{ModelName}의 속도가 {Speed}km/h로 감소했습니다.");
        }

        // --- #6-3. 자동차 정보 출력
        public void PrintInfo()
        {
            Console.WriteLine($"=== 차량 정보 ===");
            Console.WriteLine($"제조사: {manufacturer}");
            Console.WriteLine($"모델명: {ModelName}");
            Console.WriteLine($"색상: {Color}");
            Console.WriteLine($"속도: {Speed} km/h");
            Console.WriteLine($"생산년도: {year}");
            Console.WriteLine($"신차 여부: {(IsNewCar ? "신차!!" : "구형 차량")}");
            Console.WriteLine($"요약: {Summary} ");
            Console.WriteLine($"총 생산 차량 수: {totalCars}대");
        }
        #endregion

        #region 7. static 메서드 (클래스 메서드)
        /*
         * static 메서드 = 객체를 생성하지 않고 클래스 이름으로 호출 가능 (new x)
         * - 주로 공통 기능 제공 (객체와 무관한 작업)
         */
        public static void ShowTotalCars()
        {
            Console.WriteLine($"총 생상된 자동차 수: {totalCars}대");
        }

        #endregion
    }
}