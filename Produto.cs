using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastroProdutos
{
    class Fruta
    {
        private string nome;
        private double preco;

        public string GetNome()
        {
            return this.nome;
        }

        public double GetPreco()
        {
            return this.preco;
        }

        public void SetPreco(double preco)
        {
            this.preco = preco;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public Fruta() { }
        public Fruta(string nome, int preco)
        {
            this.nome = nome;
            this.preco = preco;
        }
    }

    class Carne
    {
        public string nome;
        public double preco;

        public string GetNome()
        {
            return this.nome;
        }

        public double GetPreco()
        {
            return this.preco;
        }

        public void SetPreco(double preco)
        {
            this.preco = preco;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public Carne() { }

        public Carne(string nome, int preco)
        {
            this.nome = nome;
            this.preco = preco;
        }
    }
}
