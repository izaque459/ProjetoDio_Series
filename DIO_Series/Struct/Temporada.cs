namespace DIO_Series
{
    public struct Temporada
    {
        private int _Episodios;
        private bool _Degustacao;
        public Temporada(int nEpisodios, bool degustacao)
        {
            this._Episodios = nEpisodios;
            this._Degustacao = degustacao;
        }

        public int Episodios
        {
            get {return _Episodios;}
            set {_Episodios = value;}
        }

        public bool Degustacao
        {
            get {return _Degustacao;}
            set {_Degustacao = value;}
        }
    }
}