namespace OzTool.SDK.Infra.Enigma.Interfaces
{
    public interface IParser<TDTO> :
        IEnigma<TDTO>
    {
        IParser<TDTO> NextParser { get; set; }
    }
}
