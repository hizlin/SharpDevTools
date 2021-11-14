using Osei.Core.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osei.Core.SmBios
{
    public enum StructureType : byte
    {
        BiosInformation = 0,
        SystemInformation = 1,
        BaseboardOrModuleInformation = 2,
        SystemEnclosureOrChassis = 3,
        ProcessorInformation = 4,

        [Specification(Obsolete = "2.1")]
        MemoryControllerInformation = 5,

        [Specification(Obsolete = "2.1")]
        MemoryModuleInformation = 6,

        /// <summary>
        /// Processor.Cache
        /// </summary>
        CacheInformation = 7,

        PortConnectorInformation = 8,
        SystemSlots = 9,

        /// <summary>
        /// 板载设备
        /// </summary>
        [Specification(Obsolete = "2.6")]
        OnboardDevicesInformation = 10,

        OemStrings = 11,
        SystemConfigurationOptions = 12,
        BiosLanguageInformation = 13,
        GroupAssociations = 14,
        SystemEventLog = 15,
        PhysicalMemoryArray = 16,
        MemoryDevice = 17,

        /// <summary>
        /// 32-Bit Memory Error Information
        /// </summary>
        MemoryErrorInformation32 = 18,

        MemoryArrayMappedAddress = 19,
        MemoryDeviceMappedAddress = 20,
        BuiltinPointingDevice = 21,
        PortableBattery = 22,
        SystemReset = 23,
        HardwareSecurity = 24,
        SystemPowerControls = 25,
        VoltageProbe = 26,
        CoolingDevice = 27,
        TemperatureProbe = 28,
        ElectricalCurrentProbe = 29,
        OutOfBandRemoteAccess = 30,
        BootIntegrityServicesEntryPoint = 31,
        SystemBootInformation = 32,

        /// <summary>
        /// 64-Bit Memory Error Information
        /// </summary>
        MemoryErrorInformation64 = 33,

        ManagementDevice = 34,
        ManagementDeviceComponent = 35,
        ManagementDeviceThresholdData = 36,
        MemoryChannel = 37,

        /// <summary>
        /// Intelligent Platform Management Interface
        /// </summary>
        IpmiDeviceInformation = 38,

        SystemPowerSupply = 39,
        AdditionalInformation = 40,

        /// <summary>
        /// 板载设备 扩展信息
        /// </summary>
        OnboardDevicesExtendedInformation = 41,

        ManagementControllerHostInterface = 42,

        /// <summary>
        /// Trusted Platform Module
        /// </summary>
        TpmDevice = 43,

        ProcessorAdditionalInformation = 44,

        [Specification(Since = "3.5")]
        FirmwareInventoryInformation = 45,

        [Specification(Since = "3.5")]
        StringProperty = 46,

        Inactive = 126,
        EndOfTable = 127,
    }
}
