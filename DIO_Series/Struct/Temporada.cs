namespace DIO_Series
{
    public struct Temporada
    {
        private int NEpisodios;
        private bool Degustacao;
        public Temporada(int nEpisodios, bool degustacao)
        {
            this.NEpisodios = nEpisodios;
            this.Degustacao = degustacao;
        }

        public override string ToString()
        {
            if(this.Degustacao)
                return $"{NEpisodios} episodios com degustação do primeiro episodio.";
            else
                return $"{this.NEpisodios} com episodios.";
        }
    }
}