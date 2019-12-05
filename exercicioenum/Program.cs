using System;
using System.Collections.Generic;
using System.Globalization;

namespace exercicioenum
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string nome = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel nivel = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.WriteLine("Base salary: ");
            double salario = double.Parse(Console.ReadLine());
            Department dept = new Department(deptName);
            Worker worker = new Worker(nome, nivel, salario,dept);
            Console.WriteLine();
            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #{0} contract data: ", i);
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value per hour: ");
                double valorhora = double.Parse(Console.ReadLine());
                Console.WriteLine("Duration (hours): ");
                int horas = int.Parse(Console.ReadLine());
                HourContract h = new HourContract(data, valorhora, horas);
                worker.AddContract(h);
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthandyear = Console.ReadLine();
            int mes = int.Parse(monthandyear.Substring(0, 2)); //substring corta a string de cima de acordo com asp osições 
            int ano = int.Parse(monthandyear.Substring(3)); // corta do 3 até o final 
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for: " + monthandyear + ":" + worker.Income(mes, ano).ToString("N2"));
        }
    }
}
