using OzTool.SDK.Infra.Enigma.Interfaces;

using System;
using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Extensions
{
    public static class IParserBundleExtension
    {
        public static object Encode(this IParserBundle<XElement> pi_objParserBundle, Type pi_objType, object pi_objSource)
        {
            var objReturn = default(object);
            var objEncodeMethod = typeof(IParserBundle<XElement>).GetMethod(nameof(IParserBundle<XElement>.Encode));

            if (objEncodeMethod != null)
            {
                var objMethodGeneric = objEncodeMethod.MakeGenericMethod(pi_objType);

                if (objMethodGeneric != null)
                {
                    objReturn = objMethodGeneric.Invoke(pi_objParserBundle, new object[] { pi_objSource });
                }
            }

            return objReturn;
        }

        public static object Decode(this IParserBundle<XElement> pi_objParserBundle, Type pi_objType, object pi_objSource)
        {
            var objReturn = default(object);
            var objMethod = typeof(IParserBundle<XElement>).GetMethod(nameof(IParserBundle<XElement>.Decode));

            if (objMethod != null)
            {
                var objMethodGeneric = objMethod.MakeGenericMethod(pi_objType);

                if (objMethodGeneric != null)
                {
                    objReturn = objMethodGeneric.Invoke(pi_objParserBundle, new object[] { pi_objSource });
                }
            }

            return objReturn;
        }
    }
}
