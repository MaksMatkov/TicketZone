using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Models.ValueModels
{
    public class DateValidator
    {
        public DateValidator(DateTime date)
        {
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
                throw new ArgumentException("Date is not valid");

            Value = date;
        }

        public DateTime Value { get; private set; } 
    }
}
