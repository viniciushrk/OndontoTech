namespace OndontoTech
{
    public static class Atendimentos
    {
        public static List<Consulta> consultas = new List<Consulta>();

        public static List<Consulta> consultar(string RegistroDentista, string CodigoPaciente)
        {
            var resultado = consultas.FindAll((consulta) => {
                return consulta.RegistroDentista == RegistroDentista &&
                consulta.CodigoPaciente == CodigoPaciente;
            });

            return resultado;
        }


        public static List<Consulta> marcarConsulta(
            string RegistroDentista,
            string CodigoPaciente,
            DateTime Horario,
            string status)
        {
            var datasComparadas = DateTime.Compare(Horario, DateTime.Now);
            
            if (datasComparadas < 0) {
                throw new Exception("Horário da consulta deve ser uma data posterior.");   
            }

            var consulta = new Consulta(RegistroDentista, CodigoPaciente, Horario, status);

            consultas.Add(consulta);

            return consultas;
        }

        public static List<Consulta> atenderConsulta(
            string RegistroDentista,
            string CodigoPaciente,
            DateTime Horario
        ) {
            var consultaParaRemacar = consultas.First((consulta) => {
                return consulta.RegistroDentista == RegistroDentista &&
                consulta.CodigoPaciente == CodigoPaciente &&
                consulta.Horario.Equals(Horario);
            });

            consultas.Remove(consultaParaRemacar);
            consultaParaRemacar.Atender();
            consultas.Add(consultaParaRemacar);

            return consultas;
        }

        public static List<Consulta> remarcarConsulta(
            string RegistroDentista,
            string CodigoPaciente,
            DateTime Horario,
            DateTime novaDataDaConsulta
            )
        {
            var datasComparadas = DateTime.Compare(novaDataDaConsulta, DateTime.Now);

            if (datasComparadas < 0)
            {
                throw new Exception("Horário da consulta deve ser uma data posterior.");
            }

            var consultaParaRemacar = consultas.First((consulta) => {
                return consulta.RegistroDentista == RegistroDentista &&
                consulta.CodigoPaciente == CodigoPaciente &&
                consulta.Horario.Equals(Horario);
                });

            consultas.Remove(consultaParaRemacar);

            consultaParaRemacar.Remarcar(novaDataDaConsulta);

            consultas.Add(consultaParaRemacar);

            return consultas;
        }


        public static List<Consulta> cancelarConsulta(
            string RegistroDentista,
            string CodigoPaciente,
            DateTime Horario)
        {
            var consultaParaRemacar = consultas.First((consulta) => {
                return consulta.RegistroDentista == RegistroDentista &&
                consulta.CodigoPaciente == CodigoPaciente &&
                consulta.Horario.Equals(Horario);
            });

            consultas.Remove(consultaParaRemacar);

            consultaParaRemacar.Cancelar();

            consultas.Add(consultaParaRemacar);

            return consultas;
        }
    }
}