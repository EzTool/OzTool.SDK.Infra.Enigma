using OzTool.SDK.Infra.Enigma.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Utilities.Parsers
{
    public class ParserDefault:
        BaseParser
    {

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private ParserDefault() { }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IParser<XElement> Initial()
        {
            return new ParserDefault();
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [InterfaceName] --

        protected override bool IsResponse(TypeCode pi_objTypeCode)
        {
            return true;
        }

        protected override TModel ToDecode<TModel>(XElement pi_objDTO)
        {
            TModel objReturn = default;
            var objConverter = TypeDescriptor.GetConverter(typeof(TModel));

            if (objConverter != null)
            {
                var objResult = objConverter.ConvertFrom(pi_objDTO.Value);

                if (objResult != null)
                {
                    objReturn = (TModel)objResult;
                }
            }

            return objReturn;
        }

        protected override XElement ToEncode<TModel>(TModel pi_objModel)
        {
            var objReturn = RootElement.CreateBy(typeof(TModel));

            if (pi_objModel != null)
            {
                var sValue = pi_objModel.ToString();

                objReturn.Value = string.IsNullOrEmpty(sValue) ? string.Empty : sValue;
            }

            return objReturn;
        }

        #endregion

    }
}
