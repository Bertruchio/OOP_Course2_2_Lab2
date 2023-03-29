/*
    Уравнение состояния идеального газа (уравнение Менделеева-Клапейрона):
𝑝 ∗ 𝑉 = (𝑚/𝑀) ∗ 𝑅 ∗ 𝑇,
где p - Давление идеального газа (Па), V – объем (м3), m – масса (кг), M – молярная масса
(кг/ моль), R – универсальная газовая постоянная (8.31 Дж/(моль * К)), T – температура (К).

1. Создать абстрактный базовый класс MCE, в котором создать виртуальный метод для
расчета объёма – CalculateVolume, принимающий на вход давление и температуру.
2. Создать класс-наследник от MCE MendeleevClapeyronEquation, в котором необходимо
объявить все переменные уравнения в виде полей класса (по условиям Объектно Ориентированного Программирования).
3. Создать поле – константу со значением универсальной газовой постоянной.
4. Создать конструктор, принимающий параметры: масса, молярная масса.
5. Через конструктор должно происходить присваивание значений соответствующим полям класса.
6. В методе CalculateVolume должно происходить присваивание значений полям:
Давление, Температура; а также производиться соответствующий расчет значения полю Объем.
7. Метод должен вернуть значение объема. Создать класс MendeleevClapeyronEquationUsing,
который должен являться наследником класса MendeleevClapeyronEquation.
8. В классе MendeleevClapeyronEquationUsing создать свойство AmountOfSubstance,
которое будет возвращать значение физической величины «Количество вещества (моль)»
(внести соответствующие изменения в модификаторы доступа).
Количество вещества рассчитывается как отношение массы к молярной массе вещества.
9. Создать представителя класса MendeleevClapeyronEquationUsing в Main.
10. Рассчитать и вывести значение объема, используя метод CalculateVolume.
11. Вывести значение Количества вещества.
 */

using System;
using System.Runtime.InteropServices;

namespace Lab2
{
    abstract class MCE
    {
        public abstract double CalculateVolume(double pressure, double temperature);

    }

    class MendeleevClapeyronEquation : MCE
    {
        private double _pressure;
        private double _temperature;
        private double _volume;
        private double _mass;
        private double _molarMass;
        private const double _uniGasConst = 8.31;

        public MendeleevClapeyronEquation(double mass, double molarMass)
        {
            _mass = mass;
            _molarMass = molarMass;
        }

        //𝑉 = ((𝑚/𝑀) ∗ 𝑅 ∗ 𝑇) / 𝑝
        public override double CalculateVolume(double pressure, double temperature)
        {
            _pressure = pressure;
            _temperature = temperature;

            _volume = ((_mass / _molarMass) * _uniGasConst * _temperature) / _pressure;
            return _volume;
        }
    }

    class MendeleevClapeyronEquationUsing : MendeleevClapeyronEquation
    {
        private double _mass;
        private double _molarMass;
        public double amountOfSubstance { get { return _mass / _molarMass; } }
        public MendeleevClapeyronEquationUsing(double mass, double molarMass) : base(mass, molarMass) 
        {
            _mass = mass;
            _molarMass = molarMass;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double mass;
            double molarMass;
            double pressure;
            double temperature;

            #region Enter Data From Console
            Console.WriteLine("\t\t*** Программа для рассчёта объёма и количества вещества ***");
            Console.WriteLine("Введите массу (кг):");
            do {
                while (!double.TryParse(Console.ReadLine(), out mass))
                {
                    Console.WriteLine("Ошибка ввода! Введите число c плавующей точкой для массы");
                }
                if (mass < 0)
                {
                    Console.WriteLine("Значение массы не может быть меньше нуля");
                }
            } while (mass < 0);

            Console.WriteLine("Введите молярную массу (кг/ моль):");
            do
            {
                while (!double.TryParse(Console.ReadLine(), out molarMass))
                {
                    Console.WriteLine("Ошибка ввода! Введите число c плавующей точкой для молярной массы");
                }
                if (molarMass < 0)
                {
                    Console.WriteLine("Значение молярной массы не может быть меньше нуля");
                }
            } while (molarMass < 0);

            Console.WriteLine("Введите давление идеального газа (Па):");
            do
            {
                while (!double.TryParse(Console.ReadLine(), out pressure))
                {
                    Console.WriteLine("Ошибка ввода! Введите число c плавующей точкой для давления");
                }
                if (pressure < 0)
                {
                    Console.WriteLine("Значение давления не может быть меньше нуля");
                }
            } while (pressure < 0);

            Console.WriteLine("Введите температуру (К):");
            do
            {
                while (!double.TryParse(Console.ReadLine(), out temperature))
                {
                    Console.WriteLine("Ошибка ввода! Введите число c плавующей точкой для температуры");
                }
                if (temperature <= 0)
                {
                    Console.WriteLine("Значение температуры в Кельвинах не может быть меньше или равно нулю");
                }
            } while (temperature < 0);
            #endregion

            MendeleevClapeyronEquationUsing mendeleev = new MendeleevClapeyronEquationUsing(mass, molarMass);

            Console.WriteLine($"Объем (м3): {mendeleev.CalculateVolume(pressure, temperature)}");
            Console.WriteLine($"Кол-во вещества: {mendeleev.amountOfSubstance}");
        }
    }
}