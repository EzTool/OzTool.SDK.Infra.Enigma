using System;

namespace OzTool.SDK.Infra.Enigma.HAL
{
    internal class EnigmaProxy
    {
        public static object Encode(Type pi_objType, object pi_objSource)
        {
            var objReturn = default(object);
            var objEncodeMethod = typeof(XEnigma).GetMethod(nameof(XEnigma.Encode));

            if (objEncodeMethod != null)
            {
                var objMethodGeneric = objEncodeMethod.MakeGenericMethod(pi_objType);

                if (objMethodGeneric != null)
                {
                    objReturn = objMethodGeneric.Invoke(null, new object[] { pi_objSource });
                }
            }

            return objReturn;
        }

        public static object Decode(Type pi_objType, object pi_objSource)
        {
            var objReturn = default(object);
            var objMethod = typeof(XEnigma).GetMethod(nameof(XEnigma.Decode));

            if (objMethod != null)
            {
                var objMethodGeneric = objMethod.MakeGenericMethod(pi_objType);

                if (objMethodGeneric != null)
                {
                    objReturn = objMethodGeneric.Invoke(null, new object[] { pi_objSource });
                }
            }

            return objReturn;
        }
    }
}
