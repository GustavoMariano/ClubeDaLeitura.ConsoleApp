using System;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    abstract public class TelaBase
    {
        public string ObterOpcao()
        {
            Console.Clear();

            Console.WriteLine("Digite 1 para inserir novo registro");
            Console.WriteLine("Digite 2 para visualizar registro");
            Console.WriteLine("Digite 3 para editar um registro");
            Console.WriteLine("Digite 4 para excluir um registro");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public virtual void InserirNovoRegistro()
        {
        }
        public virtual void VisualizarRegistros()
        {
        }
        public virtual void EditarRegistro()
        {
        }
        public virtual void ExcluirRegistro()
        {
        }

    }
}
