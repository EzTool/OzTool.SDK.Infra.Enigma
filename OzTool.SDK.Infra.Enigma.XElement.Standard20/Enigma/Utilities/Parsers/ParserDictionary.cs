using OzTool.SDK.Infra.Enigma.Extensions;
using OzTool.SDK.Infra.Enigma.HAL;
using OzTool.SDK.Infra.Enigma.Interfaces;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Utilities.Parsers
{
    public class ParserDictionary :
        BaseParser
    {
        #region -- 變數宣告 ( Declarations ) --   

        private IParserBundle<XElement> l_objParserBundle;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private ParserDictionary(IParserBundle<XElement> pi_objParserBundle)
        {
            this.l_objParserBundle = pi_objParserBundle;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IParser<XElement> Initial(IParserBundle<XElement> pi_objParserBundle)
        {
            return new ParserDictionary(pi_objParserBundle);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IParser] --

        protected override bool IsResponse(Type pi_objType)
        {
            return pi_objType.IsGenericType && 
                   pi_objType.GetGenericTypeDefinition().Name == "Dictionary`2";
        }
        protected override bool IsResponse(TypeCode pi_objTypeCode)
        {
            return pi_objTypeCode == TypeCode.Object;
        }

        protected override TModel ToDecode<TModel>(XElement pi_objDTO)
        {
            TModel objReturn;
            var objGenericArgs = typeof(TModel).GetGenericArguments();
            var objPropertyType = typeof(TModel);
            var objAddMethod = objPropertyType.GetMethod(nameof(IDictionary.Add));

            objReturn = (TModel)InstanceFactory.Produce(objPropertyType);
            if (objReturn != null && objAddMethod != null)
            {
                foreach (XElement objPackage in pi_objDTO.Elements())
                {
                    var objKeyElement = objPackage.Element("Key");
                    var objValueElement = objPackage.Element("Value");

                    if (objKeyElement != null && objValueElement != null)
                    {
                        var objKey = objKeyElement.Element(objGenericArgs[0].Name);
                        var objValue = objValueElement.Element(objGenericArgs[1].Name);

                        if (objKey != null && objValue != null)
                        {
                            var objKeyValue = l_objParserBundle.Decode(objGenericArgs[0], objKey);
                            var objValueValue = l_objParserBundle.Decode(objGenericArgs[1], objValue);

                            objAddMethod.Invoke(objReturn, new object[] { objKeyValue, objValueValue });
                        }
                    }
                }
            }

            return objReturn;
        }

        protected override XElement ToEncode<TModel>(TModel pi_objModel)
        {
            var objReturn = RootElement.CreateBy(typeof(TModel));
            var objGenericArgs = typeof(TModel).GetGenericArguments();
            var objKeyType = objGenericArgs[0];
            var objValueType = objGenericArgs[1];

            if (pi_objModel is IEnumerable objItems)
            {
                foreach (var objItem in objItems)
                {
                    var objKeyProperty = objItem.GetType().GetProperty(nameof(KeyValuePair<object, object>.Key)) as PropertyInfo;
                    var objValueProperty = objItem.GetType().GetProperty(nameof(KeyValuePair<object, object>.Value)) as PropertyInfo;

                    if (objKeyProperty != null && objValueProperty != null)
                    {
                        var objKeyObject = objKeyProperty.GetValue(objItem);
                        var objValueObject = objValueProperty.GetValue(objItem);

                        if (objKeyObject != null && objValueObject != null)
                        {
                            var objPackage = new XElement("Package");
                            var objKey = new XElement("Key", l_objParserBundle.Encode(objKeyType, objKeyObject));
                            var objValue = new XElement("Value", l_objParserBundle.Encode(objValueType, objValueObject));

                            objPackage.Add(objKey);
                            objPackage.Add(objValue);
                            objReturn.Add(objPackage);
                        }
                    }
                }
            }

            return objReturn;
        }

        #endregion
    }
}
