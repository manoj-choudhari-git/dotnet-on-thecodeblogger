using System;

namespace AutofacDemo.Services
{
    public class CreatedOnDateTimeService : ISingletonService, IScopedService, ITransientService
    {
        private readonly DateTime createdOn;

        public CreatedOnDateTimeService()
        {
            createdOn = DateTime.Now.AddHours(-4);
        }
        
        public DateTime CreatedOn { get => createdOn; set => throw new NotImplementedException(); }
    }
}
