using System;
using System.Collections.Generic;
using cad_series.Desenhos.interfaces;

namespace cad_series.Desenhos
{
	public class SerieRepositorio : IRepositorio<Desenhos>
	{
        private List<Desenhos> listaDesenho = new List<Desenhos>();
		public void Atualiza(int id, Desenhos objeto)
		{
			listaDesenho[id] = objeto;
		}

		public void Remove(int id)
		{
			listaDesenho[id].Excluir();
		}

		public void Insere(Desenhos objeto)
		{
			listaDesenho.Add(objeto);
		}

		public List<Desenhos> Lista()
		{
			return listaDesenho;
		}

		public int ProximoId()
		{
			return listaDesenho.Count;
		}

		public Desenhos RetornaPorId(int id)
		{
			return listaDesenho[id];
		}
	}
}