using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsTidy.Works
{
    // Microsoft.VisualStudio.Setup
    internal static class Utilities
    {
        public static string FormatIdentityString(string id, object version, string chip, string language, string branch)
        {
            // Validate.IsNotNullOrEmpty(id, "id");
            var builder = new StringBuilder(id);
            if (version != null)
            {
                builder.Append(",version=");
                builder.Append(version);
            }
            if (!string.IsNullOrEmpty(chip))
            {
                builder.Append(",chip=");
                builder.Append(chip);
            }
            if (!string.IsNullOrEmpty(language))
            {
                builder.Append(",language=");
                builder.Append(language);
            }
            if (!string.IsNullOrEmpty(branch))
            {
                builder.Append(",branch=");
                builder.Append(branch);
            }
            return builder.ToString();
        }
    }
}
