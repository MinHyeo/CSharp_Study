using System;
using System.Collections;
using System.Collections.Generic;

namespace OZ_Coding_CS
{
    public enum AirConditionerMode
    {
        Cooling = 0,
        Heating = 1,
    }

    public enum ManufacturerType 
    {
        Unknown = 0,
        SamSung,
        LG,
        ASUS,
    }

    public enum CPUType
    {
        None = 0,
        Intel,
        Ryzen,
    }

    public enum OSType
    {
        Window,
        Mac,
        Linux,
    }

    public class ElectronicEquipment
    {
        protected bool _isPowerOn;          // 전원 상태
        protected string _name;             // 이름
        protected ManufacturerType _brand;            // 브랜드
        protected int _powerConsumption;    // 소모전력

        public ElectronicEquipment(string name, ManufacturerType brand, int powerConsumption)
        {
            _isPowerOn = false;
            _name = name;
            _brand = brand;
            _powerConsumption = powerConsumption;
        }

        // 전원 On
        public void TurnOn()
        {
            if (_isPowerOn)
            {
                Console.WriteLine("이미 전원이 켜져 있습니다.");
                return;
            }
            _isPowerOn = true;
            Console.WriteLine($"{_name} 전원을 켰습니다.");
        }

        public void TurnOff()
        {
            if (!_isPowerOn)
            {
                Console.WriteLine("이미 전원이 꺼져 있습니다.");
                return;
            }
            _isPowerOn = false;
            Console.WriteLine($"{_name} 전원을 껐습니다.");
        }

        // 상태 출력
        public virtual void ShowStatus()
        {
            //Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"제품명 : {_name}, 제조자 : {_brand.ToString()}, 소모 전력 : {_powerConsumption}");
        }
    }

    public class AirConditioner : ElectronicEquipment
    {
        private AirConditionerMode _mode;
        private int _targetTemperature;

        public AirConditioner(string name, ManufacturerType brand, int powerConsumption) : base(name, brand, powerConsumption)
        {
            _mode = AirConditionerMode.Cooling;
            _targetTemperature = 26;
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine("상세 정보");
            Console.WriteLine($"모드 : {_mode.ToString()}, 목표 온도 : {_targetTemperature}");
            Console.WriteLine("--------------------------------------");
        }

        // 모드 변경
        public void ChangeMode()
        {
            _mode = 1 - _mode;
            Console.WriteLine($"{_name}의 모드를 {_mode}로 변경하였습니다.");
        }

        // 온도 변경
        public void SetTemperature(int temperature)
        {
            _targetTemperature = temperature;
            Console.WriteLine($"목표 온도를 {_targetTemperature}로 변경하였습니다.");
        }
    }

    public class FridgeFreezer : ElectronicEquipment
    {
        private int _freezerTemperature;
        private int _fridgeTemperature;

        public FridgeFreezer(string name, ManufacturerType brand, int powerConsumption) : base(name, brand, powerConsumption)
        {
            _freezerTemperature = -10;
            _fridgeTemperature = 10;
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine("상세 정보");
            Console.WriteLine($"냉장 온도 : {_fridgeTemperature}°C, 냉동 온도 : {_freezerTemperature}°C");
            Console.WriteLine("--------------------------------------");
        }

        public void SetFreezerTemperature(int freezerTemperature)
        {
            _freezerTemperature = freezerTemperature;
            Console.WriteLine($"냉동 온도를 {_freezerTemperature}로 변경하였습니다.");
        }

        public void SetFridgeTemperature(int fridgeTemperature)
        {
            _fridgeTemperature = fridgeTemperature;
            Console.WriteLine($"냉동 온도를 {_fridgeTemperature}로 변경하였습니다.");
        }
    }

    public class Computer : ElectronicEquipment
    {
        private CPUType _cpuType;
        private int _ramCapacity;
        private OSType _osType;

        public Computer(string name, ManufacturerType brand, int powerConsumption, CPUType cpuType, int ramCapacity, OSType osType) : base(name, brand, powerConsumption)
        {
            _cpuType = cpuType;
            _ramCapacity = ramCapacity;
            _osType = osType;
        }

        public override void ShowStatus()
        {
            base.ShowStatus();
            Console.WriteLine("상세 정보");
            Console.WriteLine($"CPU : {_cpuType.ToString()}, Ram 용량 : {_ramCapacity}GB, OS : {_osType.ToString()}");
            Console.WriteLine("--------------------------------------");
        }

        public void RunProgram()
        {
            Console.WriteLine($"{_name}가 프로그램을 실행합니다");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ElectronicEquipment airConditioner = new AirConditioner("에어컨", ManufacturerType.SamSung, 100);
            ElectronicEquipment fridgeFreezer = new FridgeFreezer("냉장고", ManufacturerType.LG, 120);
            ElectronicEquipment computer = new Computer("컴퓨터", ManufacturerType.ASUS, 70, CPUType.Intel, 16, OSType.Window);

            Console.WriteLine("에어컨 기능 테스트");
            // 에어컨
            // 에어컨 가동 및 상태 확인
            airConditioner.TurnOn();
            airConditioner.ShowStatus();
            if(airConditioner is AirConditioner airCon)
            {
                airCon.ChangeMode();
                airCon.SetTemperature(30);
            }
            airConditioner.ShowStatus();

            // 전원 종료
            airConditioner.TurnOff();
            Console.WriteLine("===========================================");
            Console.WriteLine();

            // 냉장고
            // 냉장고 가동 및 상태 확인
            fridgeFreezer.TurnOn();
            fridgeFreezer.ShowStatus();
            if (fridgeFreezer is FridgeFreezer fri)
            {
                fri.SetFreezerTemperature(-20);
                fri.SetFridgeTemperature(20);
            }

            fridgeFreezer.ShowStatus();
            fridgeFreezer.TurnOff();
            Console.WriteLine("===========================================");
            Console.WriteLine();

            // 컴퓨터
            // 컴퓨터 가동 및 상태 확인
            computer.TurnOn();
            computer.ShowStatus();
            if(computer is Computer com)
            {
                com.RunProgram();
            }

            computer.TurnOff();
        }
    }
}
