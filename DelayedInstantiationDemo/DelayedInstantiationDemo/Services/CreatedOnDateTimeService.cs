using System;

namespace AutofacDemo.Services
{
    public class CreatedOnDateTimeService : ICreatedOnDateTimeService
    {
        private readonly DateTime createdOn;

        public CreatedOnDateTimeService()
        {
            createdOn = DateTime.Now;
        }
        
        public DateTime CreatedOn { get => createdOn; set => throw new NotImplementedException(); }
    }
}
