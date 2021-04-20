using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsExample.Configurations
{
    public class MailFeature
    {
        public bool IsEnabled { get; set; }
        public string SmtpServer{ get; set; }
        public string Subject { get; set; }
        public string FromEmailAddress { get; set; }
    }
}
