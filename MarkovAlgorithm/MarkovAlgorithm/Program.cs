namespace MarkovAlgorithm
{
    internal class Program
    {
        static void Main()
        {
            var compiler = new MarkovCompiler();

            Console.WriteLine(compiler.ReplacementAsString());

            compiler.Compile(MarkovCompiler.ToUnar("(1/2)*(2/5)"));
        }
    }
}