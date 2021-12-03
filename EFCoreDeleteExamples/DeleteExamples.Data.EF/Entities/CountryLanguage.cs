using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteExamples.Data.EF.Entities
{
    public class CountryLanguage
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country AssociatedCountry { get; set; }
        public int LanguageId { get; set; }
        public Language AssociatedLanguage { get; set; }
    }
}
