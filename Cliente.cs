using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace computaria
{
    class Cliente
    {
        private string nome, cpf;

        private Endereco endereco;

        public string GetNome()
        {
            return this.nome;
        }

        public string GetCpf()
        {
            return this.cpf;
        }

        public Endereco GetEndereco()
        {
            return this.endereco;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public void SetCpf(string cpf)
        {
            this.cpf = cpf;
        }
        public void SetEndereco(Endereco endereco)
        {
            this.endereco = endereco;
        }

        public Cliente() { }
        public Cliente(string nome, string cpf)
        {
            this.nome = nome;
            this.cpf = cpf;
            
        }
    }
}