using OzTool.SDK.Infra.Enigma.Interfaces;
using OzTool.SDK.Infra.Enigma.Utilities.Parsers;

using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Utilities
{
    public class ParserBundle :
        IParserBundle<XElement>
    {

        #region -- 變數宣告 ( Declarations ) --   

        private readonly IParser<XElement> l_objParser;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private ParserBundle()
        {
            var objStringParser = ParserString.Initial(this);
            var objObjectParser = ParserObject.Initial(this);
            var objDefaultParser = ParserDefault.Initial();

            l_objParser = ParserList.Initial(this);
            l_objParser.NextParser = objObjectParser;
            objObjectParser.NextParser = objStringParser;
            objStringParser.NextParser = objDefaultParser;
        }

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
            return l_objParser.Decode<TModel>(pi_objDTO);   
        }

        public XElement Encode<TModel>(TModel pi_objModel)
        {
            return l_objParser.Encode(pi_objModel);
        }

        #endregion
    }
}
