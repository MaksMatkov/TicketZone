using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Models.ValueModels
{
    public class StringValidator
    {
        public StringValidator(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("String Value is not valid");

            Value = value;
        }

        public string Value { get; private set; }
    }
}
