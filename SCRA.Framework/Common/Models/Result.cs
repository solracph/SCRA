using SCRA.Framework.Common.Errors;
using System;
using System.Collections.Generic;

namespace SCRA.Framework.Common.Models
{
    [Serializable]
    public class Result
    {
        private Result(object value, IList<Error> errors)
        {
            Value = value;
            Errors = errors;
        }

        private Result(object value)
            : this(value, new List<Error>())
        {
        }

        public bool Success
        {
            get { return Errors.Count == 0; }
        }

        public object Value { get; private set; }
        public IList<Error> Errors { get; }

        internal static Result New(object value, IList<Error> errors)
        {
            return new Result(value, errors);
        }

        public static Result New(object value)
        {
            return new Result(value);
        }

        public static Result New()
        {
            return new Result(null);
        }

        public T Get<T>()
        {
            return (T) Value;
        }

        public Result SetValue(object value)
        {
            Value = value;

            return this;
        }

        public Result SetError(string identifier, Exception exception, string message, params object[] arguments)
        {
            Errors.Add(new Error(identifier, exception, message, arguments));

            return this;
        }

        public Result SetError(string identifier, Exception exception, string message)
        {
            Errors.Add(new Error(identifier, exception, message));

            return this;
        }

        public Result SetError(string identifier, Exception exception)
        {
            return SetError(identifier, exception, exception.Message, null);
        }

        public Result SetError(string identifier, string message)
        {
            Errors.Add(new Error(identifier, message));

            return this;
        }
    }
}