using System.Drawing;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        //04
        Console.WriteLine("04 amount");
        var amount04Commands = int.Parse(Console.ReadLine());
        Console.WriteLine("modbus adress (dec)");
        var modbus04Adress = short.Parse(Console.ReadLine());
        Console.WriteLine("dwin start adress (hex)");
        var dwinStartAdress = short.Parse(Console.ReadLine(), System.Globalization.NumberStyles.HexNumber);

        //03
        Console.WriteLine("03 amount");
        var amount03Commands = int.Parse(Console.ReadLine());
        Console.WriteLine("modbus adress (dec)");
        var modbus03Adress = short.Parse(Console.ReadLine());
        
        Console.WriteLine();

        //command
        var start = "5A 01 ";

        var command03 = "03 ";
        var command04 = "04 ";
        var command06 = "06 ";

        var middle = "01 30 00 00 00 ";
        var middle06 = "01 30 04 00 00 ";

        //dwin adress

        //modbus adress

        var end = "00 00 00 00 ";

        var result = new List<string>();
        //

        //04
        var adressDwin = dwinStartAdress;
        var adressModBus = modbus04Adress;

        for (int i = 0; i < amount04Commands; i++)
        {

            var converted04ModBusAdress = string.Join(" ", BitConverter.GetBytes(adressModBus).Reverse().Select(x => x.ToString("X2")));
            var converted04DwinAdress = string.Join(" ", BitConverter.GetBytes(adressDwin).Reverse().Select(x => x.ToString("X2")));

            var command = start + command04 + middle + converted04DwinAdress + " " + converted04ModBusAdress + " " + end;
            result.Add(command);

            adressDwin += 2;
            adressModBus += 1;

            Console.WriteLine(command);
        }

        //03
        adressDwin = (short)(dwinStartAdress + 2 * amount04Commands);
        adressModBus = modbus03Adress;

        for (int i = 0; i < amount03Commands; i++)
        {

            var converted03ModBusAdress = string.Join(" ", BitConverter.GetBytes(adressModBus).Reverse().Select(x => x.ToString("X2")));
            var converted03DwinAdress = string.Join(" ", BitConverter.GetBytes(adressDwin).Reverse().Select(x => x.ToString("X2")));

            var command = start + command03 + middle + converted03DwinAdress + " " + converted03ModBusAdress + " " + end;
            result.Add(command);

            adressDwin += 2;
            adressModBus += 1;

            Console.WriteLine(command);
        }

        //06
        adressDwin = (short)(dwinStartAdress + 2 * amount04Commands); ;
        adressModBus = modbus03Adress;

        for (int i = 0; i < amount03Commands; i++)
        {
            var converted06ModBusAdress = string.Join(" ", BitConverter.GetBytes(adressModBus).Reverse().Select(x => x.ToString("X2")));
            var converted06DwinAdress = string.Join(" ", BitConverter.GetBytes(adressDwin).Reverse().Select(x => x.ToString("X2")));

            var command = start + command06 + middle06 + converted06DwinAdress + " " + converted06ModBusAdress + " " + end;
            result.Add(command);

            adressDwin += 2;
            adressModBus += 1;

            Console.WriteLine(command);
        }
    }
}