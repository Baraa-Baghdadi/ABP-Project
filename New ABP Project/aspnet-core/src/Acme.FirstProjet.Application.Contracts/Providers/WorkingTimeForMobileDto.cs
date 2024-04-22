using Dawaa24Neo.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.FirstProjet.Providers
{
    public class WorkingTimeForMobileDto
    {
        public ProviderWorkDay WorkDay { get; set; }
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
    }
}
