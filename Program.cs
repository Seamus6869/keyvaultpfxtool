using CommandLine;
using keyvaultpfxtool;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parsedOptions = Parser.Default.ParseArguments<CliOptions>(args);

            parsedOptions.WithParsed(opts =>
            {
                Console.WriteLine($"Reading {opts.Filename}.");

                var jsonText = File.ReadAllText(opts.Filename);
                var jsonInput = JsonConvert.DeserializeObject<JObject>(jsonText);

                try
                {
                    if (jsonInput["dataType"].ToString().ToLower() != "pfx")
                    {
                        Console.WriteLine("Json file does not contain a pfx certificate.");
                    }
                    else
                    {
                        var pfxData = jsonInput["data"].ToString();
                        var fileName = $"{opts.Filename}.pfx";
                        File.WriteAllText(fileName, pfxData);
                        Console.WriteLine($"Generated {fileName}");
                    }
                }
                catch
                {
                    Console.WriteLine($"Could not read {opts.Filename}");
                }

            });

        }
    }
}
