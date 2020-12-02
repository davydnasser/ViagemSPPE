using System;

namespace ViagemSPPE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+++++ Bem Vindo ao Seu Calculo de Viagem");
            int tanque;
            int mediaLitro;
            int autonomia;
            string simOuNao;
            int distanciaPercorrer;
            int consumo;
            int litrosNoTanque;
            int litrosNaChegada;
            int litrosAbastecidos;
            int reservaSecuranca = 5;
            int autonomiaMovel;
            string proximoDestino;

            Console.WriteLine("+++++");
            Console.WriteLine("+++++ Digite 1 para sim");
            Console.WriteLine("+++++ ou");
            Console.WriteLine("+++++ Digite 2 para não.");
            Console.WriteLine("+++++");
            Console.WriteLine("+++++ Confirme Pressionando <Enter> por favor.");
            Console.WriteLine("+++++");
            Console.WriteLine("+++++ Você está saindo para uma viagem?");
            simOuNao = Console.ReadLine();

            if (simOuNao == "1")
            {
                
                Console.WriteLine("+++++");
                Console.WriteLine("+++++ Qual a capacidade em litros do tanque de seu veículo?");
                tanque = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("+++++ Quantos quilômetros em média seu veiculo percorre por litro?");
                mediaLitro = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("+++++ Para segurança da viagem,");
                Console.WriteLine("+++++ trabalharemos com uma reserva padrão de 5 litros isolada dos Cálculos");
            lTanqueCheio:
                Console.WriteLine("");
                Console.WriteLine("+++++ Você está com o tanque do carro cheio?");
                simOuNao = Console.ReadLine();

                if (simOuNao == "1")
                {
                    litrosNoTanque = tanque - reservaSecuranca;
                lAutonomia:
                    autonomia = litrosNoTanque * mediaLitro;
                    Console.WriteLine("+++++");
                    //Console.WriteLine("+++++ Sua autonomia atual é de " + autonomia + "km");
                    Console.WriteLine("+++++");
                    Console.WriteLine("+++++ Seu proximo destino será para qual cidade?");
                    proximoDestino = Console.ReadLine();
                    Console.WriteLine("+++++");
                    Console.WriteLine("+++++ Quantos quilometros você irá percorrer até " + proximoDestino + "?");
                    distanciaPercorrer = int.Parse(Console.ReadLine());
                    consumo = distanciaPercorrer / mediaLitro;
                    autonomia = litrosNoTanque * mediaLitro;
                    litrosNaChegada = litrosNoTanque - consumo;
                    autonomiaMovel = litrosNaChegada * mediaLitro;
                   
                    
                    if (autonomiaMovel > 50)
                    {
                        Console.WriteLine("+++++");
                        Console.WriteLine("+++++ Por favor dirija até a cidade de " + proximoDestino);
                        litrosNoTanque = litrosNoTanque - consumo;
                    }
                    else if(autonomiaMovel < 50 && litrosNoTanque < (tanque - reservaSecuranca))
                    {
                        Console.WriteLine("+++++");
                        Console.WriteLine("+++++ Sua autonomia atual é " + (autonomia) + "km e não alcança esse destino.");
                        Console.WriteLine("+++++");
                        Console.WriteLine("+++++ O tanque de seu veículo não está cheio, complete para melhorar a autonomia.");
                        Console.WriteLine("+++++");
                        Console.WriteLine("+++++ Você precisa abastecer ao menos " + (consumo - litrosNoTanque) + " litros para alcançar seu destino");
                        Console.WriteLine("+++++");
                        Console.WriteLine("+++++ Quantos litros foram abastecidos?");
                        litrosAbastecidos = int.Parse(Console.ReadLine());
                        litrosNoTanque = litrosNoTanque + litrosAbastecidos;
                        
                        if((consumo - litrosNoTanque) <= litrosAbastecidos)
                        {
                            Console.WriteLine("+++++ Por favor dirija até a cidade de " + proximoDestino);
                            litrosNoTanque = litrosNoTanque - consumo;
                        }
                        else
                        {
                            goto lAutonomia;
                        }
                    }
                    else
                    {
                        Console.WriteLine("+++++");
                        Console.WriteLine("+++++ Sua autonomia não alcança esse destino.");
                        Console.WriteLine("+++++");
                        Console.WriteLine("+++++ Escolha uma cidade destino que fique no maximo à " + (autonomia) + "km de distância");
                        
                        goto lAutonomia;
                    }
                    goto lAutonomia;
                }
                else
                {
                    Console.WriteLine("+++++ Complete o tanque. É sempre melhor começar uma viagem com tanque cheio.");
                    goto lTanqueCheio;
                }
            }
            else
            {
                Console.WriteLine("+++++ Então você não precisa desse aplicativo.");
            }
        }
    }
}
