using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Hpm.Previews.MavenSupport
{
    /**
     * NuGet.Versioning
     * https://github.com/NuGet/NuGet.Client/tree/dev/src/NuGet.Core/NuGet.Versioning
     * 
     * 
     * https://semver.org/spec/v2.0.0.html
     * 
     * {version}-{pre-release}+{build}
     * 
     * https://www.npmjs.com/package/semver
     */
    class MavenVersion : IEquatable<MavenVersion>, IComparable<MavenVersion>
    {
        private string _OriginalString;

        public int Major { get; set; }

        public int Minor { get; set; }

        public int Patch { get; set; }

        public string Version { get; set; }
        public string Prerelease { get; set; }
        public string Build { get; set; }

        public MavenVersion()
        {
        }


        #region IEquatable
        public bool Equals([AllowNull] MavenVersion other)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IComparable
        public int CompareTo([AllowNull] MavenVersion other)
        {
            throw new NotImplementedException();
        }
        #endregion

        public override string ToString()
        {
            // return base.ToString();
            return this._OriginalString;
        }

        public static MavenVersion Parse(string value)
        {
            TryParse(value, out var version);
            return version;
        }
        public static bool TryParse(string value, out MavenVersion version)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                string part1 = null;
                string part2 = null;
                string part3 = null;
                var index1 = value.IndexOf('-');
                var index2 = value.IndexOf('+');
                if (index1 > 0 && index2 > 0)
                {
                    part1 = value.Substring(0, index1);
                    part2 = value.Substring(++index1, index2);
                    part3 = value.Substring(++index2, value.Length - index2);
                }
                else if (index1 > 0)
                {
                    part1 = value.Substring(0, index1);
                    part2 = value.Substring(++index1, value.Length - index1);
                }
                else if (index2 > 0)
                {
                    part1 = value.Substring(0, index1);
                    part3 = value.Substring(++index1, value.Length - index1);
                }
                else
                {
                    part1 = value;
                }

                version = new MavenVersion();
                version._OriginalString = value;
                version.Version = part1;
                version.Prerelease = part2;
                version.Build = part3;
                return true;
            }

            version = null;
            return false;
        }
    }
}
