using DeleteExamples.Data.EF;
using DeleteExamples.Data.EF.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeleteExamples
{
    public static class ManyToManyHelper
    {
        public static void SeedData(UniversityContext context)
        {
            List<Language> languages = new List<Language>()
            {
                new Language() { Name = "Hindi" },
                new Language() { Name = "Marathi" },
                new Language() { Name = "English" },
            };

            context.Languages.AddRange(languages);
            context.SaveChanges();

            List<Country> countries = new List<Country>()
            {
                new Country { Name = "India" },
                new Country { Name = "USA" },
                new Country { Name = "UK" },
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();

            var countryIds = context.Countries.Select(x => x.Id).ToList();
            var languageIds = context.Languages.Select(x => x.Id).ToList();
            List<CountryLanguage> countryLanguages = new List<CountryLanguage>()
            {
                new CountryLanguage() { CountryId = countryIds[0], LanguageId = languageIds[0] },
                new CountryLanguage() { CountryId = countryIds[0], LanguageId = languageIds[1] },
                new CountryLanguage() { CountryId = countryIds[1], LanguageId = languageIds[0] },
                new CountryLanguage() { CountryId = countryIds[1], LanguageId = languageIds[1] },
                new CountryLanguage() { CountryId = countryIds[2], LanguageId = languageIds[1] },
                new CountryLanguage() { CountryId = countryIds[2], LanguageId = languageIds[2] },
            };

            context.CountryLanguages.AddRange(countryLanguages);
            context.SaveChanges();
        }

        public static async Task Delete(UniversityContext context)
        {
            var languages = await context.Languages.ToListAsync();
            context.Languages.Remove(languages[0]);
            await context.SaveChangesAsync();
        }
    }
}
