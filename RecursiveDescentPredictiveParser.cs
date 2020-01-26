using System;

namespace LinMat6
{


    public class RecursiveDescentPredictiveParser
    {

        private static readonly char[] predictW = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '(' }; //equals first(W)
        private static readonly char[] predictO = new char[] { '*', ':', '+', '-', '^' }; //equals first(O)
        private static readonly char[] predictR = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; //equals first(R)
        private static readonly char[] predictL = predictR; //equals first(L)

        private string expression;

        private int index = 0;

        public bool Parse(String expression)
        {
            this.expression = expression;
            return CheckS();
        }

        private bool CheckS()
        {
            return CheckW() && CheckSymbol(';') && CheckZ();
        }

        private bool CheckZ()
        {
            if (ArrayContains(CurrentSymbol(), predictW))
            {
                return CheckW() && CheckSymbol(';') && CheckZ();
            }
            else
            {
                return true;
            }
        }

        private bool CheckW()
        {
            return CheckP() && CheckWprim();
        }

        private bool CheckWprim()
        {
            if (ArrayContains(CurrentSymbol(), predictO))
            {
                return CheckO() && CheckW();
            }
            else
            {
                return true;
            }
        }

        private bool CheckP()
        {
            if (ArrayContains(CurrentSymbol(), predictR))
            {
                return CheckR();
            }
            else
            {
                return CheckSymbol('(') && CheckW() && CheckSymbol(')');
            }
        }

        private bool CheckR()
        {
            return CheckL() && CheckRprim();
        }

        private bool CheckRprim()
        {
            if (CheckSymbol('.'))
            {
                return CheckL();
            }
            else
            {
                return true;
            }
        }

        private bool CheckL()
        {
            return CheckC() && CheckLprim();
        }

        private bool CheckLprim()
        {
            if (ArrayContains(CurrentSymbol(), predictL))
            {
                return CheckL();
            }
            else
            {
                return true;
            }
        }

        private bool CheckC()
        {
            return CheckSymbol(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        }

        private bool CheckO()
        {
            return CheckSymbol(new char[] { '*', ':', '+', '-', '^' });
        }

        private bool CheckSymbol(char c)
        {
            if (LastSymbolReached())
            {
                return false;
            }
            if (c == CurrentSymbol())
            {
                index++;
                return true;
            }
            return false;
        }

        private bool CheckSymbol(char[] symbols)
        {
            if (LastSymbolReached())
            {
                return false;
            }
            if (ArrayContains(CurrentSymbol(), symbols))
            {
                index++;
                return true;
            }
            return false;
        }

        private char CurrentSymbol()
        {
            return (LastSymbolReached()) ? '0' : expression[index]; //charAt(index)
        }

        private bool LastSymbolReached()
        {
            return index >= expression.Length;
        }

        private bool ArrayContains(char c, char[] cArr)
        {
            foreach (char _c in cArr)
            {
                if (_c == c)
                {
                    return true;
                }
            }
            return false;
        }
    }

}