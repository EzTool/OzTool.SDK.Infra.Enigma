using OzTool.SDK.Infra.Enigma.Extensions;
using OzTool.SDK.Infra.Enigma.HAL;
using OzTool.SDK.Infra.Enigma.Interfaces;

using System;
using System.Collections;
using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Utilities.Parsers
{
    public class ParserList :
        BaseParser
    {
        #region -- 變數宣告 ( Declarations ) --   

        private IParserBundle<XElement> l_objParserBundle;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private ParserList(IParserBundle<XElement> pi_objParserBundle)
        {
            this.l_objParserBundle = pi_objParserBundle;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static IParser<XElement> Initial(IParserBundle<XElement> pi_objParserBundle)
        {
            return new ParserList(pi_objParserBundle);
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IParser] --

        protected override bool IsResponse(Type pi_objType)
        {
            return pi_objType.IsGenericType &&
                   (pi_objType.GetGenericTypeDefinition().Name == "List`1" ||
                    pi_objType.GetGenericTypeDefinition().Name == "ObservableCollection`1");
        }

        protected override bool IsResponse(TypeCode objTypeCode)
        {
            return objTypeCode == TypeCode.Object;
        }

        protected override TModel ToDecode<TModel>(XElement pi_objDTO)
        {
            var objReturn = default(TModel);
            var objConstructorMethod = typeof(TModel).GetConstructor(Type.EmptyTypes);
            var nLenght = typeof(TModel).Name.IndexOf("`") > 0 ?
                typeof(TModel).Name.IndexOf("`") :
                typeof(TModel).Name.Length;
            var objArgementType = typeof(TModel).GetGenericArguments()[0];
            var objAddMethod = typeof(TModel).GetMethod(nameof(IList.Add));

            objReturn = (TModel)objConstructorMethod.Invoke(Type.EmptyTypes);

            foreach (XElement objElement in pi_objDTO.Elements())
            {
                objAddMethod.Invoke(objReturn, new object[] { l_objParserBundle.Decode(objArgementType, objElement) });
            }

            return objReturn;
        }

        protected override XElement ToEncode<TModel>(TModel pi_objModel)
        {
            var objReturn = RootElement.CreateBy(typeof(TModel));

            if (pi_objModel != null && pi_objModel is IEnumerable objItems)
            {
                var objItemType = pi_objModel.GetType().GetGenericArguments()[0];

                foreach (var objItem in objItems)
                {
                    objReturn.Add(l_objParserBundle.Encode(objItemType, objItem));
                }
            }

            return objReturn;
        }

        #endregion

    }
}
