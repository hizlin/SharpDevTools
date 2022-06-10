namespace VsTidy.Core.Models
{
    public class InstallSizes : JsonBase
    {
        public long sharedDrive { get; set; }
        public long systemDrive { get; set; }
        public long targetDrive { get; set; }
        public long win10KitsInstallDir { get; set; }
    }

}
