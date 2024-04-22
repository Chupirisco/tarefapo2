using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace computaria
{
    class Endereco
    {
        private string bairro, cep;

        public string Getbairro()
        {
            return this.bairro;
        }

        public string GetCep()
        {
            return this.cep;
        }

        public void Setbairro(string bairro)
        {
            this.bairro = bairro;
        }
        public void SetCep(string cep)
        {
            this.cep = cep;
        }

        public Endereco() { }
        public Endereco(string bairro, string cep)
        {

            this.cep = cep;
            this.bairro = bairro;
        }

    }
}