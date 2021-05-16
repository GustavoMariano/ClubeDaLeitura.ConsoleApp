using System;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    abstract public class TelaBase
    {
        private string titulo;

        public string Titulo { get { return titulo; } }

        public TelaBase(string titulo)
        {
            this.titulo = titulo;
        }

        public string ObterOpcao()
        {
            string opcao;
            do
            {
                Console.Clear();

                Console.WriteLine(titulo);
                Console.WriteLine("Digite 1 para inserir novo registro");
                Console.WriteLine("Digite 2 para visualizar registro");
                Console.WriteLine("Digite 3 para editar um registro");
                Console.WriteLine("Digite 4 para excluir um registro");

                Console.WriteLine("Digite S para sair");
                opcao = Console.ReadLine().ToUpper();

            } while (ValidaoOpcao(opcao));
            Console.Clear();            

            return opcao;
        }       

        public virtual void InserirNovoRegistro(){}
        public virtual void VisualizarRegistros() { }
        public virtual void EditarRegistro() { }
        public virtual void ExcluirRegistro() { }

        private static bool ValidaoOpcao(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "s" && opcao != "S")
            {
                Console.WriteLine("Opção inválida, tente novamente!!");
                Console.ReadLine();
                return true;
            }
            else
                return false;
        }
    }
}
