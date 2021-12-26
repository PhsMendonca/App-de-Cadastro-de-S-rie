namespace DIO.series
{
    public class Serie : EntidadeBase
    {
        //atributos
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        //métodos
         public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
        this.id = id;
        this.Genero = genero;
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.Ano = ano;
        this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero: " + this.Genero + Enviroment.NewLine;
            retorno += "Titulo: " + this.Titulo + Enviroment.NewLine;
            retorno += "Descricao: " + this.Descricao + Enviroment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Enviroment.NewLine;
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

        public void Excluir()
        {
            this.Excluido = true;
        } 

    }
}