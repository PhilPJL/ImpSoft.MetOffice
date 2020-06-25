using System;

namespace ImpSoft.MetOffice.DataHub
{
    public class UriGetException : Exception
    {
        public string UriString { get; }

        public UriGetException(string message, Uri uri) : base(message)
        {
            Preconditions.IsNotNull(uri, nameof(uri));

            UriString = uri.ToString();
        }

        public UriGetException()
        {
        }

        public UriGetException(string message) : base(message)
        {
        }

        public UriGetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
