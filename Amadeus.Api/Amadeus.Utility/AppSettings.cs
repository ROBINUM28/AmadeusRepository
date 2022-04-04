using System;
using System.Collections.Generic;
using System.Text;

namespace Amadeus.Utility
{
    public class AppSettings
    {
        public string SecretLogin { get; set; }
        public int ExpireTimeSession { get; set; }
        public string Audience { get; set; }
        public string IssuerLogin { get; set; }
    }
}
