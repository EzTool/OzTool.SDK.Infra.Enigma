﻿using OzTool.SDK.Infra.Enigma.Interfaces;

using System;
using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Utilities.Parsers
{
    public abstract class BaseParser :
        IParser<XElement>
    {

        #region -- 介面實做 ( Implements ) - [IParser] --

        public IParser<XElement> NextParser { get; set; }

        public TModel Decode<TModel>(XElement pi_objDTO)
        {
            var objReturn = default(TModel);
            var objTypeCode = Type.GetTypeCode(typeof(TModel));

            if (IsResponse(objTypeCode) && IsResponse(typeof(TModel)))
            {
                objReturn = ToDecode<TModel>(pi_objDTO);
            }
            else if (NextParser != null)
            {
                objReturn = NextParser.Decode<TModel>(pi_objDTO);
            }
            return objReturn;
        }

        public XElement Encode<TModel>(TModel pi_objModel)
        {
            var objReturn = default(XElement);
            var objTypeCode = Type.GetTypeCode(typeof(TModel));

            if (IsResponse(objTypeCode) && IsResponse(typeof(TModel)))
            {
                objReturn = ToEncode<TModel>(pi_objModel);
            }
            else if (NextParser != null)
            {
                objReturn = NextParser.Encode(pi_objModel);
            }
            return objReturn;
        }

        #endregion

        #region -- 衍生函式 ( Protected Method ) -- 

        protected virtual bool IsResponse(Type pi_objType) { return true; }
        protected abstract bool IsResponse(TypeCode pi_objTypeCode);
        protected abstract TModel ToDecode<TModel>(XElement pi_objDTO);
        protected abstract XElement ToEncode<TModel>(TModel pi_objModel);

        #endregion
    }
}
