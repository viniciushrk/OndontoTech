using OndontoTech;

namespace Testes
{
    public class DentistaTest
    {
        [Fact]
        public void deveMarcarConsulta()
        {
            Dentista dentista = new Dentista("CRO-123", "Teste", "dentista", "Sla", true);
            var resultadoDaMarcacao = dentista.marcarConsulta("1231", new DateTime(2022, 09, 20, 15, 00, 00));

            Assert.True(resultadoDaMarcacao);
        }

        [Fact]
        public void deveAtenderConsulta()
        {
            Dentista dentista = new Dentista("CRO-123", "Teste", "dentista", "Sla", true);
            dentista.marcarConsulta("1231", new DateTime(2022, 09, 20, 15, 00, 00));
            var resultado = dentista.atender("1231", new DateTime(2022, 09, 20, 15, 00, 00));

            Assert.True(resultado);
        }

        [Fact]
        public void naoDeveMarcarConsultaComDataAnteriorAAtual()
        {
            Dentista dentista = new Dentista("CRO-123", "Teste", "dentista", "Sla", true);
            var resultadoDaMarcacao = dentista.marcarConsulta("1231", new DateTime(2022, 07, 20, 15, 00, 00));
            Assert.False(resultadoDaMarcacao);
        }

        [Fact]
        public void naoDeveRemarcarConsulta()
        {
            var data = new DateTime(2022, 09, 20, 15, 00, 00);
            Dentista dentista = new Dentista("CRO-123", "Teste", "dentista", "Sla", true);
            dentista.marcarConsulta("1231", data);
            
            var dataRemarcada = dentista.remarcarConsulta("1231", data, new DateTime(2022, 09, 20, 16, 00, 00));

            Assert.True(dataRemarcada);
        }

        [Fact]
        public void naoDeveRemarcarConsultaComDataAnteriorAAtual()
        {
            var data = new DateTime(2022, 09, 20, 15, 00, 00);
            Dentista dentista = new Dentista("CRO-123", "Teste", "dentista", "Sla", true);
            dentista.marcarConsulta("1231", data);

            var dataRemarcada = dentista.remarcarConsulta("1231", data, new DateTime(2022, 05, 20, 16, 00, 00));

            Assert.False(dataRemarcada);
        }

        [Fact]
        public void deveCancelarAConsulta()
        {
            var data = new DateTime(2022, 09, 20, 15, 00, 00);
            Dentista dentista = new Dentista("CRO-123", "Teste", "dentista", "Sla", true);
            dentista.marcarConsulta("1231", data);

            var dataCancelado = dentista.cancelarConsulta("1231", data);

            Assert.True(dataCancelado);
        }
    }
}