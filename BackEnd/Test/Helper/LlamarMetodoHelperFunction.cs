using System;
using System.Reflection;

namespace PlanesFamiliares.Test.Helper
{
    public static class LlamarMetodoHelperFunction
    {
        public static object LlamarMetodoHelper(Type type, string metodo, object[] parametersArray)
        {
            object result = null;
            if (type != null)
            {
                MethodInfo methodInfo = type.GetMethod(metodo);
                if (methodInfo != null)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    if (parameters.Length == 0)
                    {
                        result = methodInfo.Invoke(methodInfo, null);
                    }
                    else
                    {
                        result = methodInfo.Invoke(methodInfo, parametersArray);
                    }
                }
            }
            return result;
        }
    }
}
