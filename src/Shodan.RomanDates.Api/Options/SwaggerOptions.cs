using System;

namespace Shodan.RomanDates.Api.Options
{
    public class SwaggerOptions
    {
        public string Version { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public Uri ContactUrl { get; set; }

        public string IdentitySchemeDefinition { get; set; }
    }
}
