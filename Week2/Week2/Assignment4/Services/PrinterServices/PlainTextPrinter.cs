using System;

namespace Week2.Assignment4.Services.PrinterServices
{
    public class PlainTextPrinter : IPrinterService
    {
        public void PrintPage(string page)
        {
            Console.WriteLine(page);
        }
    }
}
