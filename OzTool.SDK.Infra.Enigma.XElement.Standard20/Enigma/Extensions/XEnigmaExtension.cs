using OzTool.SDK.Infra.Enigma.Interfaces;

using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Extensions
{

    public static class XEnigmaExtension
    {

        public static TModel Decode<TModel>(this XElement pi_objDTO)
        {
            return XEnigma.Initial().Decode<TModel>(pi_objDTO);
        }

        public static TModel Decode<TModel>(this XElement pi_objDTO, IParser<XElement> pi_objCustomParser)
        {
            return XEnigma.Initial(pi_objCustomParser).Decode<TModel>(pi_objDTO);
        }

        public static XElement Encode<TModel>(this TModel pi_objModel)
        {
            return XEnigma.Initial().Encode<TModel>(pi_objModel);
        }

        public static XElement Encode<TModel>(this TModel pi_objModel, IParser<XElement> pi_objCustomParser)
        {
            return XEnigma.Initial(pi_objCustomParser).Encode<TModel>(pi_objModel);
        }
    }
}
