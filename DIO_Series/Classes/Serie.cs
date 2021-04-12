using System;
using System.Collections.Generic;

namespace DIO_Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido{get;set;}

        List<Temporada> listaTemporadas = new List<Temporada>();
         public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }

        public override string ToString()
        {
            string retorno ="";
            retorno+="Genero: " + this.Genero + Environment.NewLine;
            retorno+="Titulo: " + this.Titulo + Environment.NewLine;
            retorno+="Descricao: " + this.Descricao + Environment.NewLine;
            retorno+="Ano de inicio: " + this.Ano + Environment.NewLine;
            retorno+="Excluido: "+this.Excluido ;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaID()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public void AdicionaTemporada(Temporada temporada)
        {
            listaTemporadas.Add(temporada);
        }

        public void RetornaTemporadas(int i,out Temporada exibicao)
        {
            exibicao = listaTemporadas[i];
        }

        public int NTemporadas()
        {
            return listaTemporadas.Count;
        }
    }
}