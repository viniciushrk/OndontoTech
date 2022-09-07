namespace OndontoTech
{
    public class Consulta
    {
        public Consulta(
            string RegistroDentista,
            string CodigoPaciente,
            DateTime Horario,
            string status)
        {
            this.RegistroDentista = RegistroDentista;
            this.CodigoPaciente = CodigoPaciente;
            this.Horario = Horario;
            this.status = status;
        }

        public string RegistroDentista{ get; private set; }
        public string CodigoPaciente{ get; private set; }
        public DateTime Horario{ get; private set; }
        public string status { get; private set; }

        public void Remarcar(DateTime Horario)
        {
            this.Horario = Horario;
            this.status = "Remarcado";
        }

        public void Atender()
        {
            this.status = "Atendido";
        }

        public void Cancelar()
        {
            this.status = "Cancelado";
        }
    }
}