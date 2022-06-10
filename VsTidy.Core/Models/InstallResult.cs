using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VsTidy.Core.Models
{
    [DataContract]
    public class InstallResult : JsonBase
    {
        public InstallResult()
        {
        }

        [DataMember]
        public int ReturnCode { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Details { get; set; }

        [DataMember]
        public string Watson { get; set; }

        [DataMember]
        public int MessageId { get; set; }

        [DataMember]
        public string Message { get; set; }

        public string executeAction { get; set; }
    }

    public enum InstallResultType
    {
        None,
        Success,
        SuccessRebootRequired,
        SuccessDelayedRebootRequired,
        Failure,
        FailureRebootRequired,
        FailureException,
        Cancel,
        FinalizerRebootRequired
    }
}
