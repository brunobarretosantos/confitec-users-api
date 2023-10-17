namespace UserManagementAPI.Application.Domain.Exceptions
{
    [Serializable]
    public class EscolaridadeInvalidaException : BadRequestException
    {
        public string Value { get; }
        
        public EscolaridadeInvalidaException(string value) : base("O valor informado para o campo Escolaridade é inválido")
        {
            Value = value;
        }        
    }
}
