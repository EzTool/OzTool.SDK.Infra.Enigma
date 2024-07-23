﻿using OzTool.SDK.Infra.Enigma.Interfaces;

using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma
{
    public class XEnigma :
        IEnigma<XElement>
    {

        #region -- 變數宣告 ( Declarations ) --   

        private readonly IParserBundle<XElement> l_objParserBundle;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private XEnigma(IParserBundle<XElement> pi_objCustomParserBundle)
        {
            l_objParserBundle = pi_objCustomParserBundle;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IEnigma<XElement> Initial(IParserBundle<XElement> pi_objCustomParserBundle)
        {
            return new XEnigma(pi_objCustomParserBundle);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IEnigma] --

        public TModel Decode<TModel>(XElement pi_objDTO)
        {
            return l_objParserBundle.Decode<TModel>(pi_objDTO);
        }

        public XElement Encode<TModel>(TModel pi_objModel)
        {
            return l_objParserBundle.Encode(pi_objModel);
        }

        #endregion
    }
}
