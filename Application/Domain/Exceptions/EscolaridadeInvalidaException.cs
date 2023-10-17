using System.Runtime.Serialization;

namespace UserManagementAPI.Application.CommandHandlers
{
    [Serializable]
    public class EscolaridadeInvalidaException : Exception
    {
        public string Value { get; }
        
        public EscolaridadeInvalidaException(string value) : base("O valor informado para a escolaridade é inválido")
        {
            Value = value;
        }        
    }
}
