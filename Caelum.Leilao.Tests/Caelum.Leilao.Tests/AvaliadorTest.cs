using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    class AvaliadorTest
    {
        private Avaliador avaliador;
        private Usuario usuario1;
        private Usuario usuario2;
        private Usuario usuario3;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Console.WriteLine("Cria recurso usado por todos os testes, antes do primeiro teste");
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Console.WriteLine("Libera recurso usado por todos os testes, depois do ultimo teste");
        }

        [SetUp]
        public void SetUp()
        {
            this.avaliador = new Avaliador();
            this.usuario1 = new Usuario("Nome1");
            this.usuario2 = new Usuario("Nome2");
            this.usuario3 = new Usuario("Nome3");
            Console.WriteLine("Cria recurso usado por cada teste");
        }

        [TearDown]
        public void TearDown()
        {
            this.avaliador = new Avaliador();
            this.usuario1 = new Usuario("Nome1");
            this.usuario2 = new Usuario("Nome2");
            this.usuario3 = new Usuario("Nome3");
            Console.WriteLine("Libera recurso usado por cada teste");
        }

        [Test]
        public void DeveAvaliarLeilaoComApenasUmLance()
        {
            // cenario
            Leilao leilao = new CriadorDeLeilao()
                .Para("Descricao")
                .ComLance(usuario1, 1)
                .Constroi();

            // acao
            avaliador.Avalia(leilao);

            // validacao
            Assert.AreEqual(1, avaliador.MenorLance);
            Assert.AreEqual(1, avaliador.MaiorLance);
        }

        [Test]
        public void DeveAvaliarLeilaoComLancesEmOrdemCrescente()
        {
            // cenario
            Leilao leilao = new CriadorDeLeilao()
                .Para("Descricao")
                .ComLance(usuario1, 1)
                .ComLance(usuario2, 2)
                .ComLance(usuario3, 3)
                .Constroi();

            // acao
            avaliador.Avalia(leilao);

            // validacao
            Assert.AreEqual(1, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(3, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void DeveAvaliarLeilaoComLancesEmOrdemDecrescente()
        {
            // cenario
            Leilao leilao = new CriadorDeLeilao()
                .Para("Descricao")
                .ComLance(usuario3, 3)
                .ComLance(usuario2, 2)
                .ComLance(usuario1, 1)
                .Constroi();

            // acao
            avaliador.Avalia(leilao);

            // validacao
            Assert.AreEqual(1, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(3, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void DeveAvaliarLeilaoComLancesEmOrdemAleatoria()
        {
            // cenario
            Leilao leilao = new CriadorDeLeilao()
                .Para("Descricao")
                .ComLance(usuario3, 3)
                .ComLance(usuario1, 1)
                .ComLance(usuario2, 2)
                .Constroi();

            // acao
            avaliador.Avalia(leilao);

            // validacao
            Assert.AreEqual(1, avaliador.MenorLance, 0.00001);
            Assert.AreEqual(3, avaliador.MaiorLance, 0.00001);
        }

        [Test]
        public void DeveInformarOsTresMaioresLancesDeUmLeilao()
        {
            // cenario
            Leilao leilao = new CriadorDeLeilao()
                .Para("Descricao")
                .ComLance(usuario1, 1)
                .ComLance(usuario2, 2)
                .ComLance(usuario3, 3)
                .Constroi();

            // acao
            avaliador.Avalia(leilao);

            // validacao
            Assert.AreEqual(3, avaliador.TresMaiores.Count);
            Assert.AreEqual(3, avaliador.TresMaiores[0].Valor);
            Assert.AreEqual(2, avaliador.TresMaiores[1].Valor);
            Assert.AreEqual(1, avaliador.TresMaiores[2].Valor);
        }

        [Test]
        public void DeveInformarTodosOsLancesComoMaioresQuandoMenosDoQueTresLancesForemPropostos()
        {
            // cenario
            Leilao leilao = new CriadorDeLeilao()
                .Para("Descricao")
                .ComLance(usuario1, 1)
                .ComLance(usuario2, 2)
                .Constroi();

            // acao
            avaliador.Avalia(leilao);

            // validacao
            Assert.AreEqual(2, avaliador.TresMaiores.Count);
            Assert.AreEqual(2, avaliador.TresMaiores[0].Valor);
            Assert.AreEqual(1, avaliador.TresMaiores[1].Valor);
        }

        //[Test]
        //public void NaoDeveInformarLancesMaioresQuandoNenhumLanceTiverSidoProposto()
        //{
        //    Leilao leilao = new CriadorDeLeilao().Para("Descricao").Constroi();

        //    // acao
        //    avaliador.Avalia(leilao);

        //    // validacao
        //    Assert.IsEmpty(avaliador.TresMaiores);
        //}

        [Test]
        [ExpectedException(typeof(Exception))]
        public void NaoDeveAvaliarLeilaoSemLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Descricao").Constroi();
            avaliador.Avalia(leilao);
        }

        //[Test]
        //public void DeveCalcularOLanceMedioDeUmLeilao()
        //{
        //    // cenario
        //    Usuario usuario1 = new Usuario("Nome1");
        //    Usuario usuario2 = new Usuario("Nome2");
        //    Usuario usuario3 = new Usuario("Nome3");
        //    Leilao leilao = new Leilao("Descricao");
        //    leilao.Propoe(new Lance(usuario1, 1));
        //    leilao.Propoe(new Lance(usuario2, 2));
        //    leilao.Propoe(new Lance(usuario3, 3));

        //    // acao
        //    Avaliador avaliador = new Avaliador();
        //    avaliador.Avalia(leilao);

        //    // validacao
        //    double lanceMedio = avaliador.LanceMedio;
        //    Assert.AreEqual(2, lanceMedio, 0.00001);
        //}
    }
}
