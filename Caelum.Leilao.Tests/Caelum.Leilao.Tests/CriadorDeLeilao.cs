using System;

namespace Caelum.Leilao
{
    public class CriadorDeLeilao
    {
        private Leilao leilao;

        public CriadorDeLeilao Para(string descricao)
        {
            this.leilao = new Leilao(descricao);
            return this;
        }

        public CriadorDeLeilao ComLance(Usuario usuario, double valor)
        {
            leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return leilao;
        }
    }
}