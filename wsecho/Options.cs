using System.Runtime.CompilerServices;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace wsecho
{
    public class Options
    {
        [Option('h', "hostname", Required=true, HelpText = "Hostname in the form: ws://127.0.0.1:4096")]
        public string Hostname { get; set; }
        [Option('m', "message", Required = true, HelpText = "Message that will be sent. You have to escape quotest or use single quotes and supply the -q option.")]
        public string Message { get; set; }
        [Option('q', "quotes", Required = false, HelpText = "Replaces all single quotes in the message with double quotes.")]
        public bool ReplaceSingleQuotes { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}