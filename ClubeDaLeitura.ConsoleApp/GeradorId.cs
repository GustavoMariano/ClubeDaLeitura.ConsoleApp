using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public  class GeradorId
    {
        private static int idAmiguinho = 0;
        private static int idCaixa = 0;
        private static int idEmprestimo = 0;
        private static int idRevista = 0;

        public static int GerarIdAmiguinho()
        {
            return ++idAmiguinho;
        }

        public static int GerarIdCaixa()
        {
            return ++idCaixa;
        }

        public static int GerarIdEmprestimo()
        {
            return ++idEmprestimo;
        }

        public static int GerarIdRevista()
        {
            return ++idRevista;
        }
    }
}