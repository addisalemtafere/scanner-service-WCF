using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIA;

namespace RestWCFServiceLibrary
{
    public class Scanner
    {
        private readonly DeviceInfo _deviceInfo;

        public Scanner(DeviceInfo deviceInfo)
        {
            this._deviceInfo = deviceInfo;
        }

        public ImageFile Scan()
        {
          
            // scan image
        
            // save to temp file
          

            // Connect to the device
            var device = this._deviceInfo.Connect();

            // Start the scan
            var item = device.Items[1];
            //WIA.ICommonDialog wiaCommonDialog = new WIA.CommonDialog();
            //WIA.ImageFile image = (WIA.ImageFile)wiaCommonDialog.ShowTransfer(item, FormatID.wiaFormatTIFF, false);

            var imageFile = item.Transfer(FormatID.wiaFormatTIFF);

            //   var img = ImageToBase64(imageFile);

            // Return the imageFile
            return (ImageFile)imageFile;
        }

        public override string ToString()
        {
            return this._deviceInfo.Properties["Name"].get_Value().ToString();
        }
    }
}