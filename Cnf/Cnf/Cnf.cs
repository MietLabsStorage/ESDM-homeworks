namespace Cnf
{
    internal static class Cnf
    {
        public static string AsString(this bool e)
        {
            return e ? "1" : "0";
        }

        public static bool[] X1 => new bool[] { false, false, false, false, true, true, true, true };
        public static bool[] X2 => new bool[] { false, false, true, true, false, false, true, true };
        public static bool[] X3 => new bool[] { false, true, false, true, false, true, false, true };
        public static bool[] X4
        {
            get
            {
                var x = new bool[8];
                for (var i = 0; i < 8; i++)
                {
                    x[i] = !X3[i];
                }
                return x;
            }
        }
        public static bool[] X5
        {
            get
            {
                var x = new bool[8];
                for (var i = 0; i < 8; i++)
                {
                    x[i] = X1[i] || X2[i];
                }
                return x;
            }
        }
        public static bool[] X6
        {
            get
            {
                var x = new bool[8];
                for (var i = 0; i < 8; i++)
                {
                    x[i] = !X4[i];
                }
                return x;
            }
        }
        public static bool[] X7
        {
            get
            {
                var x = new bool[8];
                for (var i = 0; i < 8; i++)
                {
                    x[i] = X1[i] && X2[i] && X4[i];
                }
                return x;
            }
        }
        public static bool[] X8
        {
            get
            {
                var x = new bool[8];
                for (var i = 0; i < 8; i++)
                {
                    x[i] = X5[i] || X6[i];
                }
                return x;
            }
        }
        public static bool[] X9
        {
            get
            {
                var x = new bool[8];
                for (var i = 0; i < 8; i++)
                {
                    x[i] = X6[i] || X7[i];
                }
                return x;
            }
        }
        public static bool[] X10
        {
            get
            {
                var x = new bool[8];
                for (var i = 0; i < 8; i++)
                {
                    x[i] = X8[i] && X9[i] && X7[i];
                }
                return x;
            }
        }
        public static bool[] F
        {
            get
            {
                var x = new bool[8];
                for (var i = 0; i < 8; i++)
                {
                    x[i] = X10[i] && (X4[i] == !X3[i])
                        && (X5[i] == (X1[i] || X2[i]))
                        && (X6[i] == !X4[i])
                        && (X7[i] == (X1[i] && X2[i] && X4[i]))
                        && (X8[i] == (X5[i] || X6[i]))
                        && (X9[i] == (X6[i] || X7[i]))
                        && (X10[i] == (X7[i] && X8[i] && X9[i]));
                }
                return x;
            }
        }
    }
}
