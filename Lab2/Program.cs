using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Schema;

//Необхідно сворити додаток за допомогою якого можна буде імітувати роботу обмінника валют.

namespace Lab2
{
    class Program
    {
        #region Methods
        static void Main(string[] args) // Point of enter
        {
            #region Password
            var rnd = new Random(5);
            var x = rnd.Next(3, 20);
            var truePassw = new string[] { x.ToString() };//вірний пароль
            Lab1.Program.Main(truePassw);
            Console.Write($"Key = + {x} + Enter the password = ");//ключ = x. Введіть пароль
            var customerPassw = Convert.ToSingle(Console.ReadLine());//пароль, отриманий від клієнта
            #endregion

            if (Convert.ToSingle(truePassw[0]) != customerPassw)
            {
                var computer = new Computer();
                var employee = new Employee(computer);//працівник
                var customer = new Customer();//клієнт
                customer.StartExchange(employee);
            }
            else
            {
                Console.WriteLine("We're simply sitting here");//Ми просто сидимо тут
            }
        }
        #endregion
    }
    class Customer //клієнт
    {
        #region Properties
        string _name;
        public Customer()
        {
            _name = "Customer customer customer";
        }
        #endregion

        #region Methods
        public void StartExchange(Employee employee)//початок обміну
        {
            int punct;
            float customerStartMoney;//початкові гроші клієнта
            float? customerResultMoney;//результуючі гроші клієнта

            employee.Question1();//питання 1
            punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    break;
                case 1:
                    ExchangeCurrency(CurrencyExhanges.GrnToDollar, employee, 
                        out customerStartMoney, out customerResultMoney);
                    break;
                case 2:
                    ExchangeCurrency(CurrencyExhanges.GrnToEuro, employee,
                        out customerStartMoney, out customerResultMoney);
                    break;
                case 3:
                    ExchangeCurrency(CurrencyExhanges.DollarToGrn, employee,
                         out customerStartMoney, out customerResultMoney);
                    break;
                case 4:
                    ExchangeCurrency(CurrencyExhanges.EuroToGrn, employee,
                        out customerStartMoney, out customerResultMoney);
                    break;
                case 5:
                    ExchangeCurrency(CurrencyExhanges.YuanToGrn, employee,
                        out customerStartMoney, out customerResultMoney);
                    break;
                case 6:
                    ExchangeCurrency(CurrencyExhanges.GrnToYuan, employee,
                        out customerStartMoney, out customerResultMoney);
                    break;
                default:
                    Console.WriteLine("It's imposible!");//це неможливо
                    return;
            }
        }

        private void ExchangeCurrency(CurrencyExhanges exchange, Employee employee, 
            out float customerStartMoney, out float? customerResultMoney)
        {
            employee.Question2(exchange);//питання 2
            customerStartMoney = Convert.ToSingle(Console.ReadLine());
            customerResultMoney = employee.Exchange(exchange, customerStartMoney);
            //_name + " дав " + customerStartMoney + " грн і отримав " + customerResultMoney + " доларів"
            if (customerResultMoney != null)
            {
                Console.WriteLine($"{_name} get {customerStartMoney} grn and received {customerResultMoney} dollars");
            }
            else
            {
                Console.WriteLine("Not enought money, bitch");
            }
        }
        #endregion
    }
    class Employee //працівник обмінника
    {
        static string[] employeeNames = { "Some name", "Some nams2", "Some name3" };
        static void PrintWithFor()
        {
            for (int i = 0; i < employeeNames.Length; i++)
            {
                Console.WriteLine(employeeNames[i]);
            }
        }

        static void PrintWithForeach()
        {
            foreach (var item in employeeNames)
            {
                Console.WriteLine(item);
            }
        }
        #region Properties //властивості
        string name;//ім'я
        float? _grnAmount;//кількість гривень в касі
        float? _dollarAmount;//кількість доларів в касі
        float? _euroAmount ;//кількість євро в касі
        float? _yuanAmount;
        Computer _computer;
        #endregion

        #region Methods
        public Employee(Computer computer)
        {
            object
            name = "Student student student";
            _grnAmount = 2147483647;
            _dollarAmount = 65535;
            _euroAmount = 128;
            _yuanAmount = 1234234;
            _computer = computer;
        }
        public float? Exchange(CurrencyExhanges currencyOut, float customerStartMoney = 10)
        {
            float? resultAmount = _computer.Exchange(currencyOut, customerStartMoney);
            switch (currencyOut)
            {
                case CurrencyExhanges.GrnToDollar:
                    if(_dollarAmount < resultAmount)
                    {
                        return null;
                    }

                    _dollarAmount -= resultAmount;
                    _grnAmount += customerStartMoney;
                    break;
                case CurrencyExhanges.GrnToEuro:
                    if (_euroAmount < resultAmount)
                    {
                        return null;
                    }
                    _euroAmount -= resultAmount;
                    _grnAmount += customerStartMoney;
                    break;
                case CurrencyExhanges.DollarToGrn:
                    if (_grnAmount < resultAmount)
                    {
                        return null;
                    }
                    _grnAmount -= resultAmount;
                    _dollarAmount += customerStartMoney;
                    break;
                case CurrencyExhanges.EuroToGrn:
                    if (_grnAmount < resultAmount)
                    {
                        return null;
                    }
                    _grnAmount -= resultAmount;
                    _euroAmount += customerStartMoney;
                    break;
                case CurrencyExhanges.YuanToGrn:
                    if (_grnAmount < resultAmount)
                    {
                        return null;
                    }
                    _grnAmount -= resultAmount;
                    _yuanAmount += customerStartMoney;
                    break;
                case CurrencyExhanges.GrnToYuan:
                    if (_yuanAmount < resultAmount)
                    {
                        return null;
                    }
                    _yuanAmount -= resultAmount;
                    _grnAmount += customerStartMoney;
                    break;
                default:
                    return null;
            }

            return resultAmount;
        }
        public void Question1()
        {
            Console.WriteLine("Choose a punct:");//виберіть пункт
            Console.WriteLine("0. End of exchange");//завершення обміну
            Console.WriteLine("1. Exchange grn to dollar");//обміняти гривні на долари
            Console.WriteLine("2. Exchange grn to euro");//обміняти гривні на євро
            Console.WriteLine("3. Exchange dollar to grn");//обміняти долари на гривні
            Console.WriteLine("4. Exchange euro to grn");//обміняти євро на гривні
            Console.WriteLine("5. Exchange yuan to grn");
            Console.WriteLine("6. Exhange grn to yuan");
        }

        public void Question2(CurrencyExhanges currencyOut)
        {
            Console.Write("Today employee is " + name + ". ");//Сьогодні працівником є name.
            Console.WriteLine("How many " + currencyOut + " you want to exchange?");//Скільки currencyOut Ви хочете обміняти
        }
        #endregion
    }
    class Computer //комп'ютер
    {
        #region Properties
        float _dollarRateSell;
        float _dollarRateBuy;
        float _euroRateSell;
        float _euroRateBuy;
        float _yuanRateSell;
        float _yuanRateBuy;    

        public Computer()
        {
            _dollarRateSell = 41.6f;
            _dollarRateBuy = 41.5f;
            _euroRateSell = 40.9f;
            _euroRateBuy = 40.8f;
            _yuanRateSell = 5.1f;
            _yuanRateBuy = 5;
        }
        #endregion

        #region Methods
        public float? Exchange(CurrencyExhanges currencyOut, float customerStartMoney)
        {
            switch (currencyOut)
            {
                case CurrencyExhanges.GrnToDollar:
                    return customerStartMoney / _dollarRateSell;
                case CurrencyExhanges.GrnToEuro:
                    return customerStartMoney / _euroRateSell;
                case CurrencyExhanges.DollarToGrn:
                    return customerStartMoney * _dollarRateBuy;
                case CurrencyExhanges.EuroToGrn:
                    return customerStartMoney * _euroRateBuy;
                case CurrencyExhanges.YuanToGrn:
                    return customerStartMoney / _yuanRateSell;
                case CurrencyExhanges.GrnToYuan:
                    return customerStartMoney * _yuanRateBuy;
                default:
                    return null;
            }
        }
        #endregion
    }
}