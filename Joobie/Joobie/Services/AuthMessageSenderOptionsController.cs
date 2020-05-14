using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Joobie.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; } = "Joobie sp. z o.o.";
        public string SendGridKey { get; set; } = "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";
    }
}
