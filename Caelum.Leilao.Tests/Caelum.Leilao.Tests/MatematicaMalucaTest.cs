using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    class MatematicaMalucaTest
    {
        [Test]
        public void DeveCalcularODobroParaNumeroMenorQue11()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            int conta = matematica.ContaMaluca(10);
            Assert.AreEqual(10 * 2, conta);
        }

        [Test]
        public void DeveCalcularOQuadruploParaNumeroMaiorQueTrinta()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            int conta = matematica.ContaMaluca(31);
            Assert.AreEqual(31 * 4, conta);
        }

        [Test]
        public void DeveCalcularOTriploParaNumeroEntre11e31()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            Assert.AreEqual(11 * 3, matematica.ContaMaluca(11));
            Assert.AreEqual(30 * 3, matematica.ContaMaluca(30));
        }
    }
}
