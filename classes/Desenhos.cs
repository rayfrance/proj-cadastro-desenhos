using System;

namespace cad_series.Desenhos
{
    public class Desenhos : EntidadeBase
    {
        // Atributos
		private Materia Materia { get; set; }
		private string Titulo { get; set; }
		private string Assunto { get; set; }
		private int AnoEscolar { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Desenhos(int id, Materia materia, string titulo, string assunto, int anoEscolar)
		{
			this.Id = id;
			this.Materia = materia;
			this.Titulo = titulo;
			this.Assunto = assunto;
			this.AnoEscolar = anoEscolar;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Matéria: " + this.Materia + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Assunto: " + this.Assunto + Environment.NewLine;
            retorno += "Ano escolar (série): " + this.AnoEscolar + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}