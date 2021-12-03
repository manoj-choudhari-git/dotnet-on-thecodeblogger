using System;
using System.Collections.Generic;

namespace DeleteExamples.Data.EF.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CountryLanguage> CountryLanguages { get; set; }

        public override string ToString()
        {
            return $"{{ Id: {Id}, Name: {Name} }}";
        }
    }

}
