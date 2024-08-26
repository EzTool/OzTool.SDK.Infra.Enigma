using System;
using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Utilities
{
    internal class RootElement
    {
        public static XElement CreateBy(Type pi_objType)
        {
            var sIndexMark = '`';
            var nStartIndex = 0;
            var nGenericIndex = pi_objType.Name.IndexOf(sIndexMark);
            var nLenght = nGenericIndex > 0 ? nGenericIndex : pi_objType.Name.Length;
            var sTagName = pi_objType.Name.Substring(nStartIndex, nLenght);

            return new XElement(sTagName);
        }
    }
}
