using System;
using cadastro_series.Enum;

namespace cadastro_series.Classes
{
    public class Series : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Series(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Gênero: {Genero + Environment.NewLine}";
            retorno += $"Titulo: {Titulo + Environment.NewLine}";
            retorno += $"Descrição: {Descricao + Environment.NewLine}";
            retorno += $"Ano de lançamento: {Ano + Environment.NewLine}";
            retorno += $"Excluido: {Excluido}";
            return retorno;
        }

        public string retornaTitulo() {
            return Titulo;
        }

        public int retornaId() {
            return Id;
        }

        public void Excluir() {
            Excluido = true;
        }

        public bool returnExcluido() {
            return Excluido;
        }
    }
}