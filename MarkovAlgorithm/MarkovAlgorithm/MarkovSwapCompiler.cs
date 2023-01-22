namespace MarkovAlgorithm
{
    internal class MarkovSwapCompiler : MarkovCompiler
    {
        public static string[] Replacements => new string[]
        {
            " * ", "*",
            "*", "m",
            "hmz", "h&z",
            "|/", "h/",
            "|h", "hh",
            "/|", "/z",
            "z|", "zz",
            "zm", "mz",
            "zh", "hz",
            "hz", "h*z",
            "/m", "m",
            "hmh", "h^h",
            "z/z", "z^z",
            "h", "|",
            "z", "|"
        };

        public MarkovSwapCompiler() : base(Replacements)
        {
        }
    }
}
