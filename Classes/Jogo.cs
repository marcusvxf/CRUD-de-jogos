using DioCRUD.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DioCRUD.Classes
{
    internal class Jogo:EntidadeBase
    {
        private Genero Genero { get; set; } 

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private string plataforma { get; set; }

        private bool Excluido { get; set; }

        public Jogo(int id,Genero genero,string titulo,string descricao,int ano,string plataforma)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.plataforma = plataforma;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: "+this.Genero +Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Plataformas: " + this.plataforma + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public int RetornoId()
        {
            return this.Id;
        }

        public bool RetornoExcluido()
        {
            return this.Excluido;
        }
        public string RetornoTitulo()
        {
            return this.Titulo;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
