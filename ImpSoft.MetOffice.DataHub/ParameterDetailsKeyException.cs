using System;

namespace ImpSoft.MetOffice.DataHub
{
    public class ParameterDetailsKeyException : Exception
    {
        public ParameterDetailsKeyException(string message) : base(message)
        {
        }

        public ParameterDetailsKeyException()
        {
        }

        public ParameterDetailsKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
