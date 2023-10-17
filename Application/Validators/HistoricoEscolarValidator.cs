namespace UserManagementAPI.Application.Validators
{
    public static class HistoricoEscolarValidator
    {
        public static bool IsValid(string formato)
        {
            string[] formatosAceitaveis = { "PDF", "DOC" };

            return formatosAceitaveis.Contains(formato.ToUpper());
        }
    }

}