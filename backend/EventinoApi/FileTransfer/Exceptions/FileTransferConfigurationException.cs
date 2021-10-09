using System;

namespace FileTransfer.Exceptions
{
    internal class FileTransferConfigurationException : FileTransferException
    {
        public FileTransferConfigurationException()
            : base()
        { }

        public FileTransferConfigurationException(string message)
            : base(message)
        { }

        public FileTransferConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
