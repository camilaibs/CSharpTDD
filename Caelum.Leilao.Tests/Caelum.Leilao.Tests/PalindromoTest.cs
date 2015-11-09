using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    class PalindromoTest
    {
        [Test]
        public void DeveIdentificarPalindromo()
        {
            Palindromo palindromo = new Palindromo();
            bool ehPalindromo = palindromo.EhPalindromo("Socorram - me subi no onibus em Marrocos");
            Assert.IsTrue(ehPalindromo);
        }
    }
}
