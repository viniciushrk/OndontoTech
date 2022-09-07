namespace OndontoTech
{
    public class Paciente
    {
        public Paciente(
            string Codigo,
            string Nome,
            string SobreNome,
            int Idade,
            string Telefone,
            string Endereco)
        {
            this.Codigo = Codigo;
            this.Nome = Nome;
            this.SobreNome = SobreNome;
            this.Idade = Idade;
            this.Telefone = Telefone;
            this.Endereco = Endereco;
        }

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public int Idade { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }

        public bool marcarConsulta(string RegistroDoConselho, DateTime dataConsulta)
        {
            try
            {
                Atendimentos.marcarConsulta(RegistroDoConselho, this.Codigo, dataConsulta, "marcado");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool remarcarConsulta(string RegistroDoConselho, DateTime dataConsulta, DateTime novaDataConsulta)
        {
            try
            {
                Atendimentos.remarcarConsulta(RegistroDoConselho, this.Codigo, dataConsulta, novaDataConsulta);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool cancelarConsulta(string RegistroDoConselho, DateTime dataConsulta)
        {
            try
            {
                Atendimentos.cancelarConsulta(RegistroDoConselho, this.Codigo, dataConsulta);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Consulta> consultar(string RegistroDoConselho)
        {
            return Atendimentos.consultar(RegistroDoConselho, this.Codigo);
        }
    }
}