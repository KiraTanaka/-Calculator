using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.UserInterfaces
{
    public interface UserInterface
    {
        string ReceivingData();
        void ResultOutput(string result);
        void DisplaysErrorMessage(string errorMessage);
    }
}
