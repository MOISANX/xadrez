
using tabuleiro;
using Pecas;

namespace jogoDeXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partidas = new PartidaDeXadrez();

                while (!partidas.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partidas);

                        Console.WriteLine();
                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partidas.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partidas.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partidas.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partidas.ValidarPosicaoDeDestino(origem, destino);

                        partidas.RealizarJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
                Console.Clear();
                Tela.imprimirPartida(partidas);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}