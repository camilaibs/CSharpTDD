using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    class LeilaoTest
    {
        private Usuario usuario;

        [SetUp]
        public void SetUp()
        {
            this.usuario = new Usuario("Nome");
        }

        [Test]
        public void NaoDeveAceitar2LancesEmSequenciaDadoPeloMesmoUsuario()
        {
            Usuario usuario = new Usuario("Nome");
            Leilao leilao = new Leilao("Descricao");

            leilao.Propoe(new Lance(usuario, 1));
            leilao.Propoe(new Lance(usuario, 2));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(1, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        public void UmMesmoUsuarioNaoPodeDarMaisDoQue5LancesNoMesmoLeilao()
        {
            Usuario usuario1 = new Usuario("Nome1");
            Usuario usuario2 = new Usuario("Nome2");
            Leilao leilao = new Leilao("Descricao");

            leilao.Propoe(new Lance(usuario1, 1));
            leilao.Propoe(new Lance(usuario2, 2));

            leilao.Propoe(new Lance(usuario1, 2));
            leilao.Propoe(new Lance(usuario2, 3));

            leilao.Propoe(new Lance(usuario1, 4));
            leilao.Propoe(new Lance(usuario2, 5));

            leilao.Propoe(new Lance(usuario1, 6));
            leilao.Propoe(new Lance(usuario2, 7));

            leilao.Propoe(new Lance(usuario1, 8));
            leilao.Propoe(new Lance(usuario2, 9));

            leilao.Propoe(new Lance(usuario1, 10));

            int contagem = leilao.Lances.Count;
            Assert.AreEqual(10, contagem);
            Assert.AreEqual(9, leilao.Lances[contagem - 1].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveDobrarLanceParaUsuarioQueNuncaPropos()
        {
            Usuario usuario = new Usuario("Nome");
            Leilao leilao = new Leilao("Descricao");

            leilao.DobraLance(usuario);

            Assert.AreEqual(0, leilao.Lances.Count);
        }

        [Test]
        public void DeveDobrarOLanceAnteriorDeUmUsuario()
        {
            Usuario usuario1 = new Usuario("Nome1");
            Usuario usuario2 = new Usuario("Nome2");
            Leilao leilao = new Leilao("Descricao");

            leilao.Propoe(new Lance(usuario1, 1));
            leilao.Propoe(new Lance(usuario2, 3));
            leilao.DobraLance(usuario1);

            int contagem = leilao.Lances.Count;
            Assert.AreEqual(3, contagem);
            Assert.AreEqual(2, leilao.Lances[contagem - 1].Valor);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NaoDeveAvaliarLeilaoComLanceIgualAZero()
        {
            new CriadorDeLeilao()
                .Para("Descricao")
                .ComLance(usuario, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NaoDeveAvaliarLeilaoComLanceMenorQueZero()
        {
            new CriadorDeLeilao()
                .Para("Descricao")
                .ComLance(usuario, -1);
        }
    }
}
