using OndontoTech;

namespace Testes
{
    public class PacienteTest
    {
        [Fact]
        public void deveConsultar()
        {
            Paciente paciente = new Paciente("123", "Teste", "Paciente", 22,"9999-9999","Rua não te interessa");
            paciente.marcarConsulta("CRO-123", new DateTime(2022, 09, 20, 15, 00, 00));
            paciente.marcarConsulta("CRO-123", new DateTime(2022, 09, 20, 16, 00, 00));
            paciente.marcarConsulta("CRO-123", new DateTime(2022, 09, 20, 17, 00, 00));

            var consulta = paciente.consultar("CRO-123");

            Assert.NotNull(consulta);
            Assert.Equal(3, consulta.Count());

        }

        [Fact]
        public void deveMarcarConsulta()
        {
            Paciente paciente = new Paciente("123", "Teste", "Paciente", 22, "9999-9999", "Rua não te interessa");
            var resultadoDaMarcacao = paciente.marcarConsulta("CRO-123", new DateTime(2022, 09, 20, 15, 00, 00));

            Assert.True(resultadoDaMarcacao);
        }

        [Fact]
        public void naoDeveMarcarConsultaComDataAnteriorAAtual()
        {
            Paciente paciente = new Paciente("123", "Teste", "Paciente", 22, "9999-9999", "Rua não te interessa");
            var resultadoDaMarcacao = paciente.marcarConsulta("CRC-123", new DateTime(2022, 07, 20, 15, 00, 00));
            Assert.False(resultadoDaMarcacao);
        }

        [Fact]
        public void deveRemarcarConsulta()
        {
            var data = new DateTime(2022, 09, 20, 15, 00, 00);
            Paciente paciente = new Paciente("123", "Teste", "Paciente", 22, "9999-9999", "Rua não te interessa");
            paciente.marcarConsulta("CRC-123", data);
            
            var dataRemarcada = paciente.remarcarConsulta("CRC-123", data, new DateTime(2022, 09, 20, 16, 00, 00));

            Assert.True(dataRemarcada);
        }

        [Fact]
        public void naoDeveRemarcarConsultaComDataAnteriorAAtual()
        {
            var data = new DateTime(2022, 09, 20, 15, 00, 00);
            Paciente paciente = new Paciente("123", "Teste", "Paciente", 22, "9999-9999", "Rua não te interessa");
            paciente.marcarConsulta("1231", data);

            var dataRemarcada = paciente.remarcarConsulta("CRC-123", data, new DateTime(2022, 05, 20, 16, 00, 00));

            Assert.False(dataRemarcada);
        }

        [Fact]
        public void deveCancelarAConsulta()
        {
            var data = new DateTime(2022, 09, 20, 15, 00, 00);
            Paciente paciente = new Paciente("123", "Teste", "Paciente", 22, "9999-9999", "Rua não te interessa");
            paciente.marcarConsulta("CRC-123", data);

            var dataCancelado = paciente.cancelarConsulta("CRC-123", data);

            Assert.True(dataCancelado);
        }
    }
}