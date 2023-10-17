namespace UserManagementAPI.Application.Validators
{
    public static class EscolaridadeValidator
{
    public static bool IsValid(string escolaridade)
    {
        string[] niveisAceitaveis = { "Infantil", "Fundamental", "Médio", "Superior" };

        return niveisAceitaveis.Contains(escolaridade);
    }
}
}