using System;
using CommandLine;

namespace XmlCompare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandArguments>(args)
                .WithParsed(cmd => { })
                .WithNotParsed(err =>
                {
                    Console.WriteLine("Error parsing arguments:");
                    foreach (var error in err) Console.WriteLine($"\t{error.ToString()}");
                });
        }
    }

    public class CommandArguments
    {
        [Option('s', "source", HelpText = "Sets the source file for comparison", Required = true)]
        public string SourceFile { get; set; }

        [Option('t', "target", HelpText = "Sets the target file for comparison", Required = true)]
        public string TargetFile { get; set; }


        [Option('o', "out", HelpText = "If specified, the XML DiffGram will be saved to the target location.")]
        public string DiffgramOutput { get; set; }
    }
}