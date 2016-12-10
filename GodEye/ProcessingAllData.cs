using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodEye
{
    class ProcessingAllData
    {
        private string id;
        private string protocol;
        private string length;
        private string sourceAddress;
        private string destinationAddress;
        private string hardwareType;
        private string time;
        private string data;
        private byte[] binaryData;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Protocol
        {
            get
            {
                return protocol;
            }

            set
            {
                protocol = value;
            }
        }

        public string Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public string SourceAddress
        {
            get
            {
                return sourceAddress;
            }

            set
            {
                sourceAddress = value;
            }
        }

        public string DestinationAddress
        {
            get
            {
                return destinationAddress;
            }

            set
            {
                destinationAddress = value;
            }
        }

        public string HardwareType
        {
            get
            {
                return hardwareType;
            }

            set
            {
                hardwareType = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public byte[] BinaryData
        {
            get
            {
                return binaryData;
            }

            set
            {
                binaryData = value;
            }
        }
    }
}
