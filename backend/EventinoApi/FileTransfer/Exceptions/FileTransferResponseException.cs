using System;

namespace FileTransfer.Exceptions
{
    internal class FileTransferResponseException : FileTransferException
    {
        public FileTransferResponseException()
            : base()
        { }

        public FileTransferResponseException(string message)
            : base(message)
        { }

        public FileTransferResponseException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
