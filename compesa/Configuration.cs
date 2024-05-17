namespace compesa
{
    public static class Configuration
    {
        public static string PrivateKey { get; set; } = "5+IV)E2glD3xCH2rNTElZ_at9(TbG1N(E=pH)29*";
        public static string SearchUser(int userId)
        {
            // SELECT users.*, lig_mod_user.*, module.name AS mod_name FROM users JOIN lig_mod_user ON users.id = lig_mod_user.id_user JOIN module ON lig_mod_user.id_module = module.id WHERE users.id = 1;
            return $"SELECT * FROM usuario WHERE ID_Usuario = {userId};";
        }

        public static string GetPermissions(int userId)
        {
            return $"SELECT modulo.nome FROM usuarioModulo JOIN modulo ON usuarioModulo.ID_Modulo = modulo.ID_Modulo WHERE usuarioModulo.ID_Usuario = {userId};";
        }

        public static string GetOcorrencias()
        {
            return $"SELECT SELECT usuario.nome AS 'criador', unidade.Nome_Unidade AS 'unidade', ID_Ocorrencia AS 'id_ocorrencia', ocorrencia.ID_Usuario AS 'id_criador', tipo.nome AS 'tipo', Data_Criacao AS 'data', Estado AS 'estado', Descricao AS 'descricao' FROM ocorrencia JOIN usuario ON ocorrencia.ID_Usuario = usuario.ID_Usuario JOIN unidade ON ocorrencia.ID_Unidade = unidade.ID_Unidade JOIN tipo ON ocorrencia.ID_Tipo = tipo.ID_Tipo;";
        }

    }
}
