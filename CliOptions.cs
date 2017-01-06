using CommandLine;

namespace keyvaultpfxtool
{
    public class CliOptions
    {
        [Option('r', "read", Required = true, HelpText = "Input file to be processed.")]
        public string Filename { get; set; }

        [Option(HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }
    }
}
