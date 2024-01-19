using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;

public class Program
{
    public static void Main()
    {
        MonitorPrice newprice = new MonitorPrice();
        newprice.PriceChangeHandler = ShowPrice;
        newprice.Start();
    }
   
   public static void ShowPrice(int price)
    {
        Console.WriteLine($"Цена на текущий момент {price}");
    }

    //NoParameters noPrm = new NoParameters(ShowMessage);

    //noPrm();

    //WithParameters withPrm = new WithParameters(ShowMessage);
    //string value = withPrm("Петя", "Вася");
    //Console.WriteLine(value);
    //public static void ShowMessage()
    //{
    //    Console.WriteLine("Я делегат без параметров");
    //}
    
    //public static string ShowMessage(string name1, string name2)
    //{
    //    return $"with {name1}  {name2}";
    //}



    //var numbers = new int[] { 3, 1, 2, 4, 3, 1, 1, 6 };
    //var result = numbers.Sum();
    //result += numbers.Skip(4).Take(2).Sum();
    //var y = numbers.GroupBy(x => x).Select(x =>
    //{
    //    result += x.Key;
    //    return x.Key;
    //});

    //Console.WriteLine(result);
}

public class MonitorPrice
{
    public delegate void PriceChange(int price);

    public PriceChange PriceChangeHandler { get; set; }

    public void Start()
    {
        while (true)
        {
            int bankOfAmerica = (new Random().Next(100));

            PriceChangeHandler(bankOfAmerica);

            Thread.Sleep(2000);
        }
    }
}