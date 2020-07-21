using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WIA;

namespace RestWCFServiceLibrary
{
    public class RestWCFServiceLibrary : IRestWCFServiceLibrary
    {
      

        public IEnumerable<Source> GetSources()
        {
            Collection<Source> _result = new Collection<Source>();
            var deviceManager = new DeviceManager();
            Console.WriteLine("Getting available scanners...");
            foreach (DeviceInfo info in deviceManager.DeviceInfos)
            {
                var source = new Source();
                source.Platform = SourcePlatform.X86_32;
                source.Version = DsmVersion.V1;
                source.Id = info.DeviceID.ToString();
                foreach (WIA.Property p in info.Properties)
                {
                    if (p.Name == "Name")
                    {
                        source.Name = ((WIA.IProperty)p).get_Value().ToString();
                        Console.WriteLine(source.Name);
                    }
                }

                _result.Add(source);
            }

            if (_result.Count == 0)
                Console.WriteLine("No device found ...\n Please add scanner devices to your machine.");
            else Console.WriteLine(_result.Count + " devices found.");
            return _result;
        }

        public string GetImages(string id)
        {
            string img = null;
            ImageFile image1 = null;
            Byte[] imageBytes = null;
            Scanner device = null;
            try
            {
                var deviceManager = new DeviceManager();
                List<Scanner> data = new List<Scanner>();
                foreach (DeviceInfo info in deviceManager.DeviceInfos)
                {
                    string id2 = info.DeviceID;
                    if (string.Compare(id2, id) == 0)
                    {
                        device = new Scanner(info);

                        break;
                    }
                }


                Console.WriteLine("Scanning .....");
                image1 = (device as Scanner).Scan();

                //Item item = device.ExecuteCommand(CommandID.wiaCommandTakePicture);
                //image1 = item.Transfer(FormatID.wiaFormatJPEG) as WIA.ImageFile;

                imageBytes = (byte[])image1.FileData.get_BinaryData(); // <– Converts the ImageFile to a byte array
            }
            catch (Exception exc)
            {
                Console.WriteLine("error occured :" + exc.Message);
            }

            img = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            return img;
        }

        public bool IsInstalledFlag()
        {
            return true;
        }
    }
}