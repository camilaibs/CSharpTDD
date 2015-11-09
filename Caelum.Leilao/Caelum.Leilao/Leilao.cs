using System;
using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        private Lance ultimoLance()
        {
            return Lances[Lances.Count - 1];
        }

        private int qtdeLancesDo(Usuario usuario)
        {
            int total = 0;
            foreach (Lance lance in Lances)
            {
                if (lance.Usuario.Equals(usuario))
                {
                    total++;
                }
            }
            return total;
        }

        private bool podeDarLance(Usuario usuario)
        {
            return !usuario.Equals(ultimoLance().Usuario) && qtdeLancesDo(usuario) < 5;
        }

        public void Propoe(Lance lance)
        {
            if (lance.Valor < 1)
            {
                throw new ArgumentException();
            }

            if (Lances.Count == 0 || podeDarLance(lance.Usuario))
            {
                Lances.Add(lance);
            }
        }

        private Lance ultimoLanceDo(Usuario usuario)
        {
            Lance ultimo = null;
            foreach (Lance lance in Lances)
            {
                if (lance.Usuario.Equals(usuario))
                {
                    ultimo = lance;
                }
            }
            return ultimo;
        }

        public void DobraLance(Usuario usuario)
        {
            Lance ultimo = ultimoLanceDo(usuario);
            if (ultimo != null)
            {
                Propoe(new Lance(usuario, ultimo.Valor * 2));
            }
        }
    }
}