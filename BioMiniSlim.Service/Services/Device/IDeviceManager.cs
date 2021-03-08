using System;
using Suprema;

namespace BioMiniSlim.Service.Services.Device
{
    public interface IDeviceManager
    {
        int ScannerCount { get; }
        bool ScannerDetectCore { get; set; }
        int ScannerTemplateSize { get; set; }
        int ScannerTimeout { get; set; }
        UFS_STATUS Status { get; set; }

        Tuple<byte[], string> GetImage();
        bool Match(byte[] template1, byte[] template2);
    }
}