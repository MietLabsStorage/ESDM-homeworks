namespace MarkovAlgorithm
{
    internal class MarkovMultiplyCompiler : MarkovCompiler
    {
        public static string[] Replacements => new string[]
        {
            "|^", "X",
            "_|", "|_Z",
            "Z|", "|Z",
            "|X", "X_",
            "X", "",
            "_", "",
            "Z", "|"
        };

        public MarkovMultiplyCompiler() : base(Replacements)
        {
        }
    }
}
