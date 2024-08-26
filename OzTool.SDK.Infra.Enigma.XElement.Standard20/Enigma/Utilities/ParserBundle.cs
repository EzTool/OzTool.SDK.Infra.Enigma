using OzTool.SDK.Infra.Enigma.Interfaces;

using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Utilities
{
    public class ParserBundle :
        IParserBundle<XElement>
    {

        #region -- 變數宣告 ( Declarations ) --   
        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private ParserBundle() { }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IParserBundle<XElement> Initial()
        {
            return new ParserBundle();
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IParserBundle] --

        public TModel Decode<TModel>(XElement pi_objDTO)
        {
            throw new System.NotImplementedException();
        }

        public XElement Encode<TModel>(TModel pi_objModel)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
