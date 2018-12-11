
using SCRA.Common.Utilities;
using System;
using System.Collections.Generic;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace SCRA.Framework.Common.Errors
{
    public class ExceptionInterceptionBehavior : IInterceptionBehavior
    {

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            // Invoke the next handler in the chain
            var result = getNext().Invoke(input, getNext);
            // After invoking the method on the original target
            if (result.Exception != null)
            {
                WriteLog(String.Format("Method {0} threw exception {1} at {2} with StackTrace {3}",
                input.MethodBase, result.Exception.Message,
                DateTime.Now.ToLongTimeString(), result.Exception.StackTrace));
            }
            return result;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        private void WriteLog(string message)
        {
            LogHelper.WriteLog(message);
        }
    }
}
