using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson19
{
            /*Модель компьютера  характеризуется кодом  и названием  марки компьютера, типом  процессора,  
             частотой работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, 
             стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии. Создать список,
             содержащий 6 - 10 записей с различным набором значений характеристик.
             
            Определить:
            -все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            -все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
            -вывести весь список, отсортированный по увеличению стоимости;
            -вывести весь список, сгруппированный по типу процессора;
            -найти самый дорогой и самый бюджетный компьютер;
            -есть ли хотя бы один компьютер в количестве не менее 30 штук ?*/
    class Computer
    {
        public int Code { get; set; }
        public string Brand { get; set; }
        public string TypeCPU { get; set; }
        public int FrequencyCPU { get; set; }
        public int AmountRAM { get; set; }
        public int CapacityHardDisk { get; set; }
        public int AmountVRAM { get; set; }
        public decimal PricePC { get; set; }
        public uint Quantity { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputers = new List<Computer>()
            {
                new Computer(){Code=1,Brand="Lenovo",TypeCPU="Intel",FrequencyCPU=3000,AmountRAM=6,CapacityHardDisk=256,AmountVRAM=128,PricePC=35000M,Quantity=15},
                new Computer(){Code=2,Brand="HP",TypeCPU="Intel",FrequencyCPU=3300,AmountRAM=6,CapacityHardDisk=512,AmountVRAM=256,PricePC=39000M,Quantity=12},
                new Computer(){Code=3,Brand="HP",TypeCPU="AMD",FrequencyCPU=3800,AmountRAM=8,CapacityHardDisk=512,AmountVRAM=512,PricePC=44000M,Quantity=10},
                new Computer(){Code=4,Brand="Aser",TypeCPU="Intel",FrequencyCPU=2700,AmountRAM=4,CapacityHardDisk=256,AmountVRAM=64,PricePC=23000M,Quantity=27},
                new Computer(){Code=5,Brand="Lenovo",TypeCPU="AMD",FrequencyCPU=3300,AmountRAM=8,CapacityHardDisk=1024,AmountVRAM=128,PricePC=38000M,Quantity=7},
                new Computer(){Code=6,Brand="Toshiba",TypeCPU="AMD",FrequencyCPU=3600,AmountRAM=6,CapacityHardDisk=256,AmountVRAM=512,PricePC=42000M,Quantity=35},
                new Computer(){Code=7,Brand="Aser",TypeCPU="Intel",FrequencyCPU=3000,AmountRAM=4,CapacityHardDisk=512,AmountVRAM=256,PricePC=41000M,Quantity=10},
                new Computer(){Code=8,Brand="Aser",TypeCPU="Intel",FrequencyCPU=3900,AmountRAM=16,CapacityHardDisk=2048,AmountVRAM=1024,PricePC=56000M,Quantity=3},
            };
            Console.Write("Выберите тип процессора: ");
            string n = Console.ReadLine();
            List<Computer> cpu = listComputers
                .Where(d => d.TypeCPU == n)
                .DefaultIfEmpty()
                .ToList();
            foreach (Computer d in cpu)
                if (d != null)
                {
                    Console.WriteLine($"{d.Code}, {d.Brand}, {d.PricePC} руб., {d.Quantity} шт.");
                }
                else
                {
                    Console.WriteLine("Таких компьютеров нет");
                }
            Console.WriteLine();

            Console.Write("Укажите минимальный объем оперативной памяти, ГБ: ");
            int m = Convert.ToInt32(Console.ReadLine());
            List<Computer> ram = listComputers
                .Where(d => d.AmountRAM >= m)
                .DefaultIfEmpty()
                .ToList();
            foreach (Computer d in ram)
                if (d != null)
                {
                    Console.WriteLine($"{d.Code}, {d.Brand}, {d.AmountRAM} ГБ, {d.PricePC} руб., {d.Quantity} шт.");
                }
                else
                {
                    Console.WriteLine("Таких компьютеров нет");
                }
            Console.WriteLine();

            Console.WriteLine("Сортировка по цене.");
            List<Computer> sortPrice = listComputers
                .OrderBy(d => d.PricePC)
                .ToList();
            foreach (Computer d in sortPrice)
                    Console.WriteLine($"{d.Code}, {d.Brand}, {d.PricePC} руб., {d.Quantity} шт.");
            Console.WriteLine();

            Console.WriteLine("Группировка по типу процессора.");
            List<Computer> sortCPU = listComputers
                .OrderBy(d => d.TypeCPU)
                .ToList();
            foreach (Computer d in sortCPU)
                Console.WriteLine($"{d.Code}, {d.Brand}, {d.TypeCPU}, {d.PricePC} руб., {d.Quantity} шт.");
            Console.WriteLine();

            Console.WriteLine("Самый дорогой компьютер.");
            Computer maxPrice = listComputers
                .OrderByDescending(d => d.PricePC)
                .First();
            Console.WriteLine($"{maxPrice.Code}, {maxPrice.Brand}, {maxPrice.PricePC} руб.");
            Console.WriteLine();

            Console.WriteLine("Самый бюджетный компьютер.");
            Computer minPrice = listComputers
                .OrderBy(d => d.PricePC)
                .First();
            Console.WriteLine($"{minPrice.Code}, {minPrice.Brand}, {minPrice.PricePC} руб.");
            Console.WriteLine();

            Console.WriteLine("Модели компьютеров более 30 шт.");
            List<Computer> many = listComputers
                .Where(d => d.Quantity >= 30)
                .DefaultIfEmpty()
                .ToList();
            foreach (Computer d in many)
                if (d != null)
                {
                    Console.WriteLine($"{d.Code}, {d.Brand}, {d.PricePC} руб., {d.Quantity} шт.");
                }
                else
                {
                    Console.WriteLine("Таких компьютеров нет");
                }
            Console.ReadKey();
        }
    }
}
