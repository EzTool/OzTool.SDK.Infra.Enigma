using OzTool.SDK.Infra.Enigma.Extensions;
using OzTool.SDK.Infra.Enigma.HAL;
using OzTool.SDK.Infra.Enigma.Interfaces;

using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Utilities.Parsers
{
    public class ParserObject :
        BaseParser
    {

        #region -- 變數宣告 ( Declarations ) --   

        private IParserBundle<XElement> l_objParserBundle;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private ParserObject(IParserBundle<XElement> pi_objParserBundle)
        {
            l_objParserBundle = pi_objParserBundle;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IParser<XElement> Initial(IParserBundle<XElement> pi_objParserBundle)
        {
            return new ParserObject(pi_objParserBundle);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IParser] --

        protected override bool IsResponse(TypeCode pi_objTypeCode)
        {
            return pi_objTypeCode == TypeCode.Object;
        }

        protected override TModel ToDecode<TModel>(XElement pi_objDTO)
        {
            TModel objReturn = default;
            var objConstructorMethod = typeof(TModel).GetConstructor(Type.EmptyTypes);

            if (objConstructorMethod != null)
            {
                objReturn = (TModel)objConstructorMethod.Invoke(Type.EmptyTypes);

                if (objReturn != null)
                {
                    foreach (PropertyInfo objProperty in typeof(TModel).GetProperties())
                    {
                        var objValueElement = pi_objDTO.Element(objProperty.Name);

                        if (objValueElement != null)
                        {
                            var objValueContent = objValueElement.Elements().First();

                            if (objValueContent != null)
                            {
                                objProperty.SetValue(objReturn, l_objParserBundle.Decode(objProperty.PropertyType, objValueContent));
                            }
                        }
                    }
                }
            }
            return objReturn;
        }

        protected override XElement ToEncode<TModel>(TModel pi_objModel)
        {
            var objRootElment = RootElement.CreateBy(typeof(TModel));

            if (pi_objModel != null)
            {
                foreach (PropertyInfo objProperty in pi_objModel.GetType().GetProperties())
                {
                    var objPropertyValue = objProperty.GetValue(pi_objModel, null);

                    if (objPropertyValue != null)
                    {
                        var objPropertyContent = l_objParserBundle.Encode(objProperty.PropertyType, objPropertyValue);
                        var objPropertyElement = new XElement(objProperty.Name, objPropertyContent);

                        objRootElment.Add(objPropertyElement);
                    }
                }
            }

            return objRootElment;
        }

        #endregion

    }
}
