using System;
using System.Runtime.Serialization;

namespace PcapdotNET.Protocols
{
    [Serializable]
    public class ContentException : ApplicationException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //
        private readonly string fileName;

        public string FileName { get { return fileName; } }

        public override string Message
        {
            get
            {
                if (fileName == null) 
                    return base.Message;
                else
                    return "В файле " + FileName + " нет pcap файлов. Его невозможно обработать";
            }
        }

        public ContentException(string fileName)
        {
            this.fileName = fileName;
        }

        public ContentException(string message, string fileName) : base(message)
        {
            this.fileName = fileName;
        }

        public ContentException(string message, Exception inner, string fileName) : base(message, inner)
        {
            this.fileName = fileName;
        }

        protected ContentException(
            SerializationInfo info,
            StreamingContext context, string fileName) : base(info, context)
        {
            this.fileName = fileName;
        }
    }   
}
