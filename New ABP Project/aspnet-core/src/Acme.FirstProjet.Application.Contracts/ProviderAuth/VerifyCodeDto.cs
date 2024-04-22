using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.FirstProjet.ProviderAuth
{
    public class VerifyCodeDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
