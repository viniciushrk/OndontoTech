namespace OndontoTech
{
    public class Dentista
    {
        public Dentista(
            string RegistroDoConselho,
            string Nome,
            string SobreNome,
            string Especialidade,
            bool Ativo)
        {
            this.RegistroDoConselho = RegistroDoConselho;
            this.Nome = Nome;
            this.SobreNome = SobreNome;
            this.Especialidade = Especialidade;
            this.Ativo = Ativo;
        }

        public string RegistroDoConselho { get; private set; }
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Especialidade { get; private set; }
        public bool Ativo { get; private set; }

        public bool atender(string codigoDoPaciente, DateTime horaAtendimento)
        {
            try
            {
                Atendimentos.atenderConsulta(this.RegistroDoConselho, codigoDoPaciente, horaAtendimento);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool marcarConsulta(string codigoDoPaciente, DateTime dataConsulta)
        {
            try
            {
                Atendimentos.marcarConsulta(this.RegistroDoConselho, codigoDoPaciente, dataConsulta, "marcado");
                return true;
            } catch
            {
                return false;
            }
        }

        public bool remarcarConsulta(string codigoDoPaciente, DateTime dataConsulta, DateTime novaDataConsulta)
        {
            try
            {
                Atendimentos.remarcarConsulta(this.RegistroDoConselho, codigoDoPaciente, dataConsulta, novaDataConsulta);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool cancelarConsulta(string codigoDoPaciente, DateTime dataConsulta)
        {
            try
            {
                Atendimentos.cancelarConsulta(this.RegistroDoConselho, codigoDoPaciente, dataConsulta);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}