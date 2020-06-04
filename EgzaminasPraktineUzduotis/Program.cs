using ClassLibrary;
using EgzaminasPraktineUzduotis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EgzaminasPraktineUzduotis
{
    class Program
    {
        static void Main()
        {
            ConsoleAplicationController controller = new ConsoleAplicationController();
            controller.StartMessage();
            while (controller.State)
            {
                controller.StandardMessage();
                controller.Select();
                controller.EndMessage();
            }
        }
    }
}
