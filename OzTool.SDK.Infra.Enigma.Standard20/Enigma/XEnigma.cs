using OzTool.SDK.Infra.Enigma.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma
{
    public class XEnigma :
        IEnigma<XElement>
    {

        #region -- 變數宣告 ( Declarations ) --   
        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private XEnigma() { }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IEnigma<XElement> Initial()
        {
            return new XEnigma();
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IEnigma] --

        public TModel Decode<TModel>(XElement pi_objDTO)
        {
            throw new NotImplementedException();
        }

        public XElement Encode<TModel>(TModel pi_objModel)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
