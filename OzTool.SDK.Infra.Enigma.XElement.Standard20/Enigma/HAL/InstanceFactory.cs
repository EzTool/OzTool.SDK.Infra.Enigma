using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OzTool.SDK.Infra.Enigma.HAL
{
    internal class InstanceFactory
    {
        #region -- 方法 ( Public Method ) --        

        internal static object Produce(Type pi_TargetType, params Type[] pi_objGenericParameterTypeSet)
        {
            if (pi_TargetType.Name == typeof(string).Name)
            {
                return string.Empty;
            }
            else if (pi_TargetType.IsGenericType && pi_TargetType.IsGenericTypeDefinition)
            {
                return Activator.CreateInstance(pi_TargetType.MakeGenericType(pi_objGenericParameterTypeSet), FindArguments(pi_TargetType));
            }
            else
            {
                return Activator.CreateInstance(pi_TargetType, FindArguments(pi_TargetType));
            }
        }

        #endregion

        #region -- 私有函式 ( Private Method) --

        private static object[] FindArguments(Type pi_objTargetType)
        {
            var objReturn = default(object[]);
            var objConstructors = pi_objTargetType.GetConstructors();

            if (objConstructors.Any())
            {
                var objConstructor = objConstructors.FirstOrDefault(c => c.GetParameters().Length > 0);

                if (objConstructor != null)
                {
                    var objParameters = objConstructor.GetParameters();
                    var objArgs = new List<object>();

                    foreach (ParameterInfo objParameter in objParameters)
                    {
                        objArgs.Add(Produce(objParameter.ParameterType));
                    }
                    objReturn = objArgs.ToArray();
                }
            }

            return objReturn;
        }

        #endregion
    }
}
