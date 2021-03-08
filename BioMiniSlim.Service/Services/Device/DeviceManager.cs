using Suprema;
using System;
using System.ComponentModel;

namespace BioMiniSlim.Service.Services.Device
{
    public class DeviceManager : IDeviceManager
    {
        #region Private Fields

        private UFScanner _scanner;
        private UFScannerManager _scannerManager;
        private UFMatcher _matcher;

        #endregion Private Fields

        #region Public Constructors

        public DeviceManager()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public int ScannerCount => _scannerManager.Scanners.Count;

        public bool ScannerDetectCore
        {
            get { return _scanner.DetectCore; }
            set { _scanner.DetectCore = value; }
        }

        public int ScannerTemplateSize
        {
            get { return _scanner.TemplateSize; }
            set
            {
                if (value > DeviceConst.MaxTemplateSize)
                    _scanner.TemplateSize = DeviceConst.MaxTemplateSize;
                _scanner.TemplateSize = value;
            }
        }

        public int ScannerTimeout
        {
            get { return _scanner.Timeout; }
            set { _scanner.Timeout = value; }
        }

        public UFS_STATUS Status { get; set; }

        #endregion Public Properties

        #region Public Methods

        public Tuple<byte[], string> GetImage()
        {
            Initialize();

            UFS_STATUS ufs_res;
            byte[] Template = new byte[DeviceConst.MaxTemplateSize];
            int TemplateSize;

            int EnrollQuality;
            // Clear capture buffer
            ufs_res = _scanner.ClearCaptureImageBuffer();
            // Capture single image
            ufs_res = _scanner.CaptureSingleImage();

            ufs_res = _scanner.ExtractEx(DeviceConst.MaxTemplateSize, Template, out TemplateSize, out EnrollQuality);

            var image = Guid.NewGuid() + ".jpg";
            _scanner.SaveCaptureImageBufferToJPG($"{Environment.CurrentDirectory}\\CapturedImages\\{image}");

            UnInitialize();

            return Tuple.Create(Template, image);
        }

        public bool Match(byte[] template1, byte[] template2)
        {
            Initialize();

            bool result;
            _matcher.Verify(template1, 1024, template2, 1024, out result);

            UnInitialize();

            return result;
        }

        #endregion Public Methods

        #region Private Methods

        private void GetDeviceManager(ISynchronizeInvoke synchronizeInvoke)
        {
            var scannerManager = new UFScannerManager(synchronizeInvoke);
            var status = scannerManager.Init();
            if (status != UFS_STATUS.OK)
            {
                Status = status;
                throw new Exception();
            }
            _scannerManager = scannerManager;
        }

        private void GetScanner()
        {
            var scanner = _scannerManager.Scanners[0];
            if (scanner == null)
            {
                Status = UFS_STATUS.ERROR;
                throw new Exception();
            }
            _scanner = scanner;
        }

        private void GetMatcher()
        {
            _matcher = new UFMatcher();
        }

        private void Initialize()
        {
            GetDeviceManager(this as ISynchronizeInvoke);
            GetScanner();
            GetMatcher();
        }

        private void UnInitialize()
        {
            UFS_STATUS ufs_res;
            // Uninitialize scanner module
            ufs_res = _scannerManager.Uninit();
        }

        #endregion Private Methods
    }
}