namespace OzTool.SDK.Infra.Enigma.Interfaces
{
    public interface IEnigma<TDTO>
    {
        TDTO Encode<TModel>(TModel pi_objModel);
        TModel Decode<TModel>(TDTO pi_objDTO);
    }
}
