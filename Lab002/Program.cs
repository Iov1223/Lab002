using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab002 { // Задание 007
    class FindeFile {
        private string text;
        private string Tmp;
        private string _path;
        private string _pathTMP;
        public FindeFile(string path1, string path2) {
            _path = path1;
            _pathTMP = path2;
        }

        public string readFileText() {
            text = File.ReadAllText(_path);
            return text;
        }
        public string readFilceTmp()
        {
            Tmp = File.ReadAllText(_pathTMP);
            return Tmp;
        }       
    }
    class ResultOfProgramArg {
        public void ShowResult(string arg1, string arg2) {
            FindeFile myAuthorization = new FindeFile(arg1, arg2);
            FindeFile autoriz = new FindeFile(arg1, arg2);
            string poem = autoriz.readFileText();
            string reg = autoriz.readFilceTmp();
            Console.WriteLine("Считываемый файл:\n" + poem + "\n");
            Console.WriteLine("Шаблон для поиска - {0}", reg);
            reg.Remove(autoriz.readFilceTmp().Length - 2);
            reg = @"\w*" + reg + @"\w*";
            Regex regex = new Regex(reg, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(poem);
            if (matches.Count > 0) {
                foreach (Match m in matches) {
                    Console.WriteLine(m.Value);
                }
                Console.WriteLine("Количество совпадений = {0}.", matches.Count);
            }
            else {
                Console.WriteLine("Совпадений не найдено.");
            }          
        }
    }
    class ResultOfProgramStr : ResultOfProgramArg {
        public void ShowResult() {
            Console.Write("В командную строку вводится два аргумента, оба заключаются в двойные кавчки: 1 - Полный путь к файлу с содержимым." +
                   " 2 - Полный путь к файлу с шаблоном.\nВведите аргументы (здесь без кавычек), после ввода первого нажминет \"ENTER\": ");
            string firstArg = Console.ReadLine();
            string secondArg = Console.ReadLine();
            base.ShowResult(firstArg, secondArg);
        }
       
    }
    class Program {
        static void Main(string[] args) {
            
            if (args.Length == 2) {
                try
                {
                    ResultOfProgramArg res = new ResultOfProgramArg();
                    res.ShowResult(args[0],args[1]);
                }
                catch
                {
                    Console.WriteLine("Неверно введены аргументы. Перезапустите программу и будте внимательны!");
                }
            }
            else {
                try
                {
                    ResultOfProgramStr res = new ResultOfProgramStr();
                    res.ShowResult();
                }
                catch
                {
                    Console.WriteLine("Неверно введены аргументы. Перезапустите программу и будте внимательны!");
                }
            }
        }
    }
}
