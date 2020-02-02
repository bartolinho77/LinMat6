using System;
using System.Collections.Generic;


namespace LinMat6
{
    public class GrammarChecker
    {
        private static readonly List<char> _firstW = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '(' };
        private static readonly List<char> _firstR = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static readonly List<char> _firstL = _firstR;
        private static readonly List<char> _firstC = _firstR;
        private static readonly List<char> _firstO = new List<char>() { '*', ':', '+', '-', '^' };


        private string _currentSentence;

        private int index = 0;

        public bool CheckSentence(string input)
        {
            _currentSentence = input;
            return CheckS();
        }
        
     
        private bool CheckS()
        {
            return CheckW() && CheckCurrentSymbol(';') && CheckZ();
        }

        private bool CheckZ()
        {
            if (_firstW.Contains(GetCurrentSymbol()))
                return CheckW() && CheckCurrentSymbol(';') && CheckZ();
            else
                return true;
        }

        private bool CheckW()
        {
            return CheckP() && CheckWprim();
        }

        private bool CheckWprim()
        {
            if (_firstO.Contains(GetCurrentSymbol()))
                return CheckO() && CheckW();
            else
                return true;
        }

        private bool CheckP()
        {
            if (_firstR.Contains(GetCurrentSymbol()))
                return CheckR();
            
            else
                return CheckCurrentSymbol('(') && CheckW() && CheckCurrentSymbol(')');
        }

        private bool CheckR()
        {
            return CheckL() && CheckRprim();
        }

        private bool CheckRprim()
        {
            if (CheckCurrentSymbol('.'))
                return CheckL();
            else
                return true;
        }

        private bool CheckL()
        {
            return CheckC() && CheckLprim();
        }

        private bool CheckLprim()
        {
            if (_firstL.Contains(GetCurrentSymbol()))
                return CheckL();
            else
                return true;
        }

        private bool CheckC()
        {
            return CheckCurrentSymbol(_firstC);
        }

        private bool CheckO()
        {
            return CheckCurrentSymbol(_firstO);
        }
        private bool CheckCurrentSymbol(char c)
        {
            if (IsItLastSymbol())
                    return false;
            
            if (c == GetCurrentSymbol())
            {
                index++;
                return true;
            }
            return false;
        }

        private bool CheckCurrentSymbol(List<char> symbols)
        {
            if (IsItLastSymbol())
                return false;
            
            if (symbols.Contains(GetCurrentSymbol()))
            {
                index++;
                return true;
            }
            return false;
        }

        private char GetCurrentSymbol()
        {
            return (IsItLastSymbol()) ? 'x' : _currentSentence[index];
        }

        private bool IsItLastSymbol()
        {
            return index >= _currentSentence.Length;
        }


    }
    class Program
    {
        static void Main()
        {
            GrammarChecker checker = new GrammarChecker();
            Console.WriteLine("Wprowadź zdanie:");
            string _currentSentence = Console.ReadLine();
            bool result = checker.CheckSentence(_currentSentence);
            Console.WriteLine("Wynik: {0}", result);
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować: ");
            Console.ReadKey();
        }
    }
}
