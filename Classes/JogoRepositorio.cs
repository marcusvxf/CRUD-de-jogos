using DioCRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioCRUD.Classes
{
    internal class JogoRepositorio : IRepositorio<Jogo>
    {
        private List<Jogo> listaJogo = new List<Jogo>();

        public void Atualiza(int id, Jogo objeto)
        {
            listaJogo[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaJogo[id].Excluir();
        }

        public void Insere(Jogo objeto)
        {
            listaJogo.Add(objeto);
        }

        public List<Jogo> Lista()
        {
            return listaJogo;
        }

        public int ProximoId()
        {
            return listaJogo.Count;
        }

        public Jogo ReTornoPorId(int id)
        {
            return listaJogo[id];
        }
    }
}
