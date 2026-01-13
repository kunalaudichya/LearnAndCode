using System;

namespace Week2.Assignment4.Services.PrinterServices
{
    public class HtmlPrinter : IPrinterService
    {
        public void PrintPage(string page)
        {
            Console.WriteLine($"<div style='single-page'>{page}</div>");
        }
    }
}
