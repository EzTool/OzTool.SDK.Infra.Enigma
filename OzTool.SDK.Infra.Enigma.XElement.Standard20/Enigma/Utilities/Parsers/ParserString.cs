using OzTool.SDK.Infra.Enigma.Interfaces;

using System;
using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Utilities.Parsers
{
    public class ParserString :
        BaseParser
    {
        #region -- 變數宣告 ( Declarations ) --   

        private IParserBundle<XElement> l_objParserBundle;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public ParserString(IParserBundle<XElement> pi_objParserBundle)
        {
            this.l_objParserBundle = pi_objParserBundle;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IParser<XElement> Initial(IParserBundle<XElement> pi_objParserBundle)
        {
            return new ParserString(pi_objParserBundle);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [InterfaceName] --

        protected override bool IsResponse(TypeCode objTypeCode)
        {
            return objTypeCode == TypeCode.String;
        }

        protected override TModel ToDecode<TModel>(XElement pi_objDTO)
        {
            return (TModel)(object)pi_objDTO.Value;
        }

        protected override XElement ToEncode<TModel>(TModel pi_objModel)
        {
            var objReturn = RootElement.CreateBy(typeof(TModel));

            if (pi_objModel != null)
            {
                var sValue = pi_objModel.ToString();

                if (string.IsNullOrEmpty(sValue))
                {
                    objReturn.Add(new XCData(string.Empty));
                }
                else
                {
                    objReturn.Add(new XCData(sValue));
                }
            }

            return objReturn;
        }

        #endregion
    }
}
