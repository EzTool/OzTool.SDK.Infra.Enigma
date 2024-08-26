using System.Xml.Linq;

namespace OzTool.SDK.Infra.Enigma.Interfaces
{
    public interface IParserBundle<TDTO>
    {
        TModel Decode<TModel>(XElement pi_objDTO);
        TDTO Encode<TModel>(TModel pi_objModel);
    }
}
