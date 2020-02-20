using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DickinsonBros.Redactor.Models
{
    [ExcludeFromCodeCoverage]
    public class JsonRedactorOptions
    {
        public string[] PropertiesToRedact { get; set; }
        public string[] ValuesToRedact { get; set; }
    }
}
