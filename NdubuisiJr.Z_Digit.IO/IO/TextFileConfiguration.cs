using System.Collections.Generic;
using System.Linq;
using NdubuisiJr.Z_Digit.Domain;
using System.IO;
using NdubuisiJr.Z_Digit.Data.IO.Reader;
using System;

namespace NdubuisiJr.Z_Digit.Data.IO
{
    public class TextFileConfiguration : IConfiguration
    {
        public TextFileConfiguration(string filePath)
        {
            _path = filePath;
            Charts = new List<ZFactorChart>();
        }

        public void Read() {
            var ReadFile = new TextFileReader();
            var fullLines = File.ReadAllLines(_path);
            var lines = fullLines.Skip(1);
            foreach (var line in lines) {
                ReadFile.ReadLine(line);
            }
            Charts = ReadFile.Charts;
            Charts.Add(ReadFile.chart);
        }

        public List<ZFactorChart> Charts { get; set; }

        string _path;
    }
}
