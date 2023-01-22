using System.Text;

namespace MarkovAlgorithm
{
    internal class MarkovCompiler
    {
        private readonly string[] _replacements;
        private static string[] DefaultReplacement => new string[]
        {
            // изменение выражения вида a/b*c/d на a*c/b*d
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
            "z", "|",

            // умножения
            "|^", "X",
            "_|", "|_Z",
            "Z|", "|Z",
            "|X", "X_",
            "X", "",
            "_", "",
            "Z", "|",

            // деление
            "%#", "#%",
            "%|", "%#",
            "#|", "##",
            "|#", "t",
            "t#", "#t",
            "t%", "%t",
            "%t", "%v|",
            "t", "|",
            "%v", "?d",
            "?d", "d?",
            "|d", "d|",
            "?", "%",
            "#d", "H",
            "H#", "oH",
            "H%", "H",
            "H", "",
            "#", "",
            "d", "|n",
            "&|", "-k",
            "k|", "kk",
            "k", "|+",
            "+|", "|+",
            "-", "ey",
            "|e", "e|",
            "y", "%",
            "eo", "0o",
            "e", "",
            "|n", ";a",
            "a;", ";a",
            ";;", ";",
            ";aaaaaaaaaa", "a,;",
            ",a", "a,",
            ";aaaaaaaaa", "9",
            ";aaaaaaaa", "8",
            ";aaaaaaa", "7",
            ";aaaaaa", "6",
            ";aaaaa", "5",
            ";aaaa", "4",
            ";aaa", "3",
            ";aa", "2",
            ";a", "1",
            ";DOT", ".",
            ";", "0",
            ",", "",
            "a", ";a",
            "o", "p||||||||||",
            "|p", "p|",
            "pp", "p",
            "%", "u",
            "u+", "u",
            "u", "n",
            "|+", "|)+",
            ")", "(>",
            ">+", "+>",
            "+", "{",
            "{", "|",
            ">>>>>", "=",
            "|=", "=",
            "(=", "=",
            "(", "&",
            "p=", "=<",
            "<0", "0<",
            "<1", "1<",
            "<2", "2<",
            "<3", "3<",
            "<4", "4<",
            "<5", "5<",
            "<6", "6<",
            "<7", "7<",
            "<8", "8<",
            "<9", "9<",
            "<<<<<", "$",
            "0$", "$0",
            "1$", "$1",
            "2$", "$2",
            "3$", "$3",
            "4$", "$4",
            "5$", "$5",
            "6$", "$6",
            "7$", "$7",
            "8$", "$8",
            "9$", "$9",
            "=$", ";DOT",
            "0=", "=0",
            "1=", "=1",
            "2=", "=2",
            "3=", "=3",
            "4=", "=4",
            "5=", "=5",
            "6=", "=6",
            "7=", "=7",
            "8=", "=8",
            "9=", "=9",
            "n>", "",
            "0>", ">0",
            "1>", ">1",
            "2>", ">2",
            "3>", ">3",
            "4>", ">4",
            "5>", ">5",
            "6>", ">6",
            "7>", ">7",
            "8>", ">8",
            "9>", ">9",
            "p>", "",
            "p", ";DOT",
            "n", ";DOT"
        };

        public MarkovCompiler(string[] replacements)
        {
            _replacements = replacements;
        }

        public MarkovCompiler()
        {
            _replacements = DefaultReplacement;
        }

        public string Compile(string phrase)
        {
            var length = _replacements.Length / 2;

            while (true)
            {
                var found = false;

                for (var i = 0; i < length; i++)
                {
                    var what = _replacements[i * 2];

                    if (phrase.Contains(what))
                    {
                        found = true;
                        var rep = _replacements[i * 2 + 1];
                        Console.WriteLine($"Замена: {phrase}, {what} => {rep}");
                        phrase = phrase.Replace(what, rep);
                        Console.WriteLine($"Текущее состояние: {phrase}");

                        break;
                    }
                }

                if (!found)
                {
                    break;
                }
            }

            Console.WriteLine($"Ответ: {phrase}");
            return phrase;
        }

        public static string ToUnar(string phrase)
        {
            var splited = phrase.Split(new string[] { "/", "*", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splited.Length; i++)
            {
                if (int.TryParse(splited[i], out var num))
                {
                    splited[i] = new string('|', num);
                }
            }
            return $"{splited[0]}/{splited[1]}*{splited[2]}/{splited[3]}";
        }

        public string ReplacementAsString()
        {
            var sb = new StringBuilder("---Replacements---\n");
            for (int i = 0; i < _replacements.Length / 2; i++)
            {
                sb.Append($"\'{_replacements[i]}\'->\'{_replacements[i*2]}\'\n");
            }
            sb.Append("---End Replacements---\n");
            return sb.ToString();
        }
    }
}
