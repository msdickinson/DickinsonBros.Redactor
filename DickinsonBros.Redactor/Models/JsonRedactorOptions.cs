using System;
using System.Collections.Generic;
using System.Text;

namespace DickinsonBros.Redactor.Models
{
    public class JsonRedactorOptions
    {
        public string[] PropertiesToRedact { get; set; }
        public string[] ValuesToRedact { get; set; }
    }
}
