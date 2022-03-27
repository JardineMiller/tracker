using System;
using Tracker.API.Infrastructure.Exceptions.Models;

namespace Tracker.API.Infrastructure.Exceptions
{
    public abstract class HandledHttpResponseException : Exception, IHandledResponseException, ILoggableException
    {
        protected HandledHttpResponseException(string message) : base(message)
        {
        }

        protected HandledHttpResponseException()
        {
        }

        public abstract ExceptionHttpResponse CreateResponse();
    }

    public interface ILoggableException
    {
    }

    public interface IHandledResponseException
    {
        ExceptionHttpResponse CreateResponse();
    }
}