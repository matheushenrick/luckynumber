using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorMegaSena
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Em um jogo de loteria onde você escolhe 6 números, a média de 1 a 48, o total
            ideal desses números seria 144. (Em uma loteria de 6/50 como é o caso da Supersena
            no Brasil por exemplo, o número do meio seria 25. Você aposta 6 números, então 6 x 24
            = 144). O fator variante permitirá 24 ou mais pontos em ambos os lados então os seis
            números apostados em 6/48 devem somar uma quantia entre 100 a 144. */

            /*Mega sena
             * Total ideal: 180
             */

            //Input ultimos 10 resultados

            //Dividir em 4 vetores 
            //vet 1 = 1 2 3 4 5 11 12 13 14 15 21 22 23 24 25
            //vet 2 = 6 7 8 9 10 16 17 18 19 20 26 27 28 29 30
            //vet 3 = 31 32 33 34 35 41 42 43 44 45 51 52 53 54 55
            //vet 4 = 36 37 38 39 40 46 47 48 49 50 56 57 58 59 60 

            //Selecionar os mais frequentes dos 10 jogos em cada vetor
            /*
             SISTEMA DE NÚMEROS(mascara): 1 2 3 4 5 6 7 8 9 10 11 12
             ----------------------------------------------------------
            NÚMEROS ESCOLHIDOS(exemplo): 48 3 1 14 33 34 28 29 31 7 23 44 
             */
            /*MODELOS
             * SISTEMA 37 (MASCARA)
                    1 1  1  1 4  4   4  7   7
                    2 2  2  2 5  5   5  8   8
                    3 3  3  3 6  6   6  9   9
                    4 7 10 13 7 10  13 10  13
                    5 8 11 14 8 11  14 11  14
                    6 9 12 15 9 12  15 12  15
             * 
             * SISTEMA 56 - arrumar para 15 numeros e n 12
                    1 1  1  1  1  1  1  1  1  1              1  1  1  1  1  1  1  1  1  1
                    2 2  2  2  2  2  2  2  2  3              3  3  3  3  3  4  4  4  4  5
                    3 3  3  4  4  5  5  6  6  4              4  5  5  6  6  5  5  6  6  6
                    4 7 10  7  9  7  9  7  9  7              8  7  8  7  8  7  8  7  8  7
                    5 8 11  8 11  8 10  8 10  9             11  9 10  9 10 10  9 10  9 11
                    6 9 12 10 12 11 12 12 11 10             12 11 12 12 11 11 12 12 11 12
                    
            
                    1  2  2  2  2  2  2  2  2  2             2  2  2  3  3  3  3  3  3 4  4  7
                    5  3  3  3  3  3  3  4  4  4             4  5  5  4  4  4  4  5  5 5  5  8
                    6  4  4  5  5  6  6  5  5  6             6  6  6  5  5  6  6  6  6 6  6  9
                    8  7  8  7  8  7  8  7  8  7             8  7  8  7  9  7  9  7  9 7 10 10
                    9 11  9 10  9 10  9  9 10  9            10  9 11  8 10  8 10  8 11 8 11 11
                   10 12 10 12 11 11 12 12 11 11            12 10 12 12 11 11 12 10 12 9 12 12  

            RESULTADOS PARA JOGOS NA VERTICAL

             * 
             */
            List<string> jogo0 = new List<string>();
            List<string> jogo1 = new List<string>();
            List<string> jogo2 = new List<string>();
            List<string> jogo3 = new List<string>();
            List<string> jogo4 = new List<string>();
            List<string> jogo5 = new List<string>();
            List<string> jogo6 = new List<string>();
            List<string> jogo7 = new List<string>();
            List<string> jogo8 = new List<string>();
            List<string> jogo9 = new List<string>();

            
            Console.WriteLine("Digite o resultado dos 10 ultimos sorteios da mega sena separado por espaços");

             for (int i = 0; i < 10; i++)
             {
                 Console.WriteLine("Resultado " + (i+1) + ":");
                 string resultado = Console.ReadLine();
                 
                 switch (i)
                 {
                     case 0:
                         jogo0.AddRange(resultado.Split(' '));
                         break;
                     case 1:
                         jogo1.AddRange(resultado.Split(' '));
                         break;
                     case 2:
                         jogo2.AddRange(resultado.Split(' '));
                         break;
                     case 3:
                         jogo3.AddRange(resultado.Split(' '));
                         break;
                     case 4:
                         jogo4.AddRange(resultado.Split(' '));
                         break;
                     case 5:
                         jogo5.AddRange(resultado.Split(' '));
                         break;
                     case 6:
                         jogo6.AddRange(resultado.Split(' '));
                         break;
                     case 7:
                         jogo7.AddRange(resultado.Split(' '));
                         break;
                     case 8:
                         jogo8.AddRange(resultado.Split(' '));
                         break;
                     case 9:
                         jogo9.AddRange(resultado.Split(' '));
                         break;

                     default:
                         break;
                 }
             } 

            //Verifico qual a frequencia de repetição de cada numero
            #region Frequencia

            IDictionary<int, int> repeticoes = new Dictionary<int, int>();

            for (int i = 0; i < 10; i++)
            {

                switch (i)
                {

                    case 0:
                        #region ComparacaoJogo0 
                        //percorrer o primeiro jogo
                        for (int b = 0; b < jogo0.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no primeiro jogo
                            repeticoes.Add(int.Parse(jogo0[b]), 1);

                            for (int z = 0; z < 6; z++)
                            {
                                //verifica se achou no jogo 1
                                if (jogo0[b] == jogo1[z])
                                {
                                    repeticoes[int.Parse(jogo0[b])] = repeticoes[int.Parse(jogo0[b])] + 1;
                                    
                                    
                                }

                                //verifica se achou no jogo 2
                                if (jogo0[b] == jogo2[z])
                                {

                                    repeticoes[int.Parse(jogo0[b])] = repeticoes[int.Parse(jogo0[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 3
                                if (jogo0[b] == jogo3[z])
                                {

                                    repeticoes[int.Parse(jogo0[b])] = repeticoes[int.Parse(jogo0[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 4
                                if (jogo0[b] == jogo4[z])
                                {

                                    repeticoes[int.Parse(jogo0[b])] = repeticoes[int.Parse(jogo0[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 5
                                if (jogo0[b] == jogo5[z])
                                {

                                    repeticoes[int.Parse(jogo0[b])] = repeticoes[int.Parse(jogo0[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 6
                                if (jogo0[b] == jogo6[z])
                                {

                                    repeticoes[int.Parse(jogo0[b])] = repeticoes[int.Parse(jogo0[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 7
                                if (jogo0[b] == jogo7[z])
                                {

                                    repeticoes[int.Parse(jogo0[b])] = repeticoes[int.Parse(jogo0[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 8
                                if (jogo0[b] == jogo8[z])
                                {

                                    repeticoes[int.Parse(jogo0[b])] = repeticoes[int.Parse(jogo0[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 9
                                if (jogo0[b] == jogo9[z])
                                {


                                    repeticoes[int.Parse(jogo0[b])] = repeticoes[int.Parse(jogo0[b])] + 1;

                                    
                                    
                                }
                            }

                        }
                        break;

                    #endregion

                    case 1:
                        #region ComparacaoJogo1
                        //percorrer o primeiro jogo
                        for (int b = 0; b < jogo1.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no primeiro jogo
                            try
                            {
                                repeticoes.Add(int.Parse(jogo1[b]), 1);
                            }
                            catch (Exception)
                            {
                                repeticoes[int.Parse(jogo1[b])] = repeticoes[int.Parse(jogo1[b])] + 1;

                            }
                            

                            for (int z = 0; z < 6; z++)
                            {
                                //verifica se achou no jogo 2
                                if (jogo1[b] == jogo2[z])
                                {


                                    repeticoes[int.Parse(jogo1[b])] = repeticoes[int.Parse(jogo1[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 3
                                if (jogo1[b] == jogo3[z])
                                {


                                    repeticoes[int.Parse(jogo1[b])] = repeticoes[int.Parse(jogo1[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 4
                                if (jogo1[b] == jogo4[z])
                                {


                                    repeticoes[int.Parse(jogo1[b])] = repeticoes[int.Parse(jogo1[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 5
                                if (jogo1[b] == jogo5[z])
                                {


                                    repeticoes[int.Parse(jogo1[b])] = repeticoes[int.Parse(jogo1[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 6
                                if (jogo1[b] == jogo6[z])
                                {


                                    repeticoes[int.Parse(jogo1[b])] = repeticoes[int.Parse(jogo1[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 7
                                if (jogo1[b] == jogo7[z])
                                {


                                    repeticoes[int.Parse(jogo1[b])] = repeticoes[int.Parse(jogo1[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 8
                                if (jogo1[b] == jogo8[z])
                                {


                                    repeticoes[int.Parse(jogo1[b])] = repeticoes[int.Parse(jogo1[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 9
                                if (jogo1[b] == jogo9[z])
                                {


                                    repeticoes[int.Parse(jogo1[b])] = repeticoes[int.Parse(jogo1[b])] + 1;

                                    
                                    
                                }
                            }

                        }
                        break;
                    #endregion
                    case 2:
                        #region ComparacaoJogo2
                        //percorrer o terceiro jogo
                        for (int b = 0; b < jogo2.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no terceiro jogo
                            try
                            {
                                repeticoes.Add(int.Parse(jogo2[b]), 1);
                            }
                            catch (Exception)
                            {

                                repeticoes[int.Parse(jogo2[b])] = repeticoes[int.Parse(jogo2[b])] + 1;
                            }
                            

                            for (int z = 0; z < 6; z++)
                            {

                                //verifica se achou no jogo 3
                                if (jogo2[b] == jogo3[z])
                                {


                                    repeticoes[int.Parse(jogo2[b])] = repeticoes[int.Parse(jogo2[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 4
                                if (jogo2[b] == jogo4[z])
                                {


                                    repeticoes[int.Parse(jogo2[b])] = repeticoes[int.Parse(jogo2[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 5
                                if (jogo2[b] == jogo5[z])
                                {


                                    repeticoes[int.Parse(jogo2[b])] = repeticoes[int.Parse(jogo2[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 6
                                if (jogo2[b] == jogo6[z])
                                {


                                    repeticoes[int.Parse(jogo2[b])] = repeticoes[int.Parse(jogo2[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 7
                                if (jogo2[b] == jogo7[z])
                                {


                                    repeticoes[int.Parse(jogo2[b])] = repeticoes[int.Parse(jogo2[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 8
                                if (jogo2[b] == jogo8[z])
                                {


                                    repeticoes[int.Parse(jogo2[b])] = repeticoes[int.Parse(jogo2[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 9
                                if (jogo2[b] == jogo9[z])
                                {


                                    repeticoes[int.Parse(jogo2[b])] = repeticoes[int.Parse(jogo2[b])] + 1;

                                    
                                    
                                }
                            }

                        }

                        break;
                    #endregion
                    case 3:
                        #region ComparacaoJogo3
                        //percorrer o terceiro jogo
                        for (int b = 0; b < jogo3.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no terceiro jogo
                            try
                            {
                                repeticoes.Add(int.Parse(jogo3[b]), 1);
                            }
                            catch (Exception)
                            {

                                repeticoes[int.Parse(jogo3[b])] = repeticoes[int.Parse(jogo3[b])] + 1;
                            }
                            

                            for (int z = 0; z < 6; z++)
                            {
                                //verifica se achou no jogo 4
                                if (jogo3[b] == jogo4[z])
                                {


                                    repeticoes[int.Parse(jogo3[b])] = repeticoes[int.Parse(jogo3[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 5
                                if (jogo3[b] == jogo5[z])
                                {


                                    repeticoes[int.Parse(jogo3[b])] = repeticoes[int.Parse(jogo3[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 6
                                if (jogo3[b] == jogo6[z])
                                {


                                    repeticoes[int.Parse(jogo3[b])] = repeticoes[int.Parse(jogo3[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 7
                                if (jogo3[b] == jogo7[z])
                                {


                                    repeticoes[int.Parse(jogo3[b])] = repeticoes[int.Parse(jogo3[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 8
                                if (jogo3[b] == jogo8[z])
                                {


                                    repeticoes[int.Parse(jogo3[b])] = repeticoes[int.Parse(jogo3[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 9
                                if (jogo3[b] == jogo9[z])
                                {


                                    repeticoes[int.Parse(jogo3[b])] = repeticoes[int.Parse(jogo3[b])] + 1;

                                    
                                    
                                }
                            }

                        }

                        break;
                    #endregion

                    case 4:
                        #region ComparacaoJogo4
                        //percorrer o quarto jogo
                        for (int b = 0; b < jogo4.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no quarto jogo
                            try
                            {
                                repeticoes.Add(int.Parse(jogo4[b]), 1);
                            }
                            catch (Exception)
                            {

                                repeticoes[int.Parse(jogo4[b])] = repeticoes[int.Parse(jogo4[b])] + 1;
                            }
                            

                            for (int z = 0; z < 6; z++)
                            {

                                //verifica se achou no jogo 5
                                if (jogo4[b] == jogo5[z])
                                {


                                    repeticoes[int.Parse(jogo4[b])] = repeticoes[int.Parse(jogo4[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 6
                                if (jogo4[b] == jogo6[z])
                                {


                                    repeticoes[int.Parse(jogo4[b])] = repeticoes[int.Parse(jogo4[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 7
                                if (jogo4[b] == jogo7[z])
                                {


                                    repeticoes[int.Parse(jogo4[b])] = repeticoes[int.Parse(jogo4[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 8
                                if (jogo4[b] == jogo8[z])
                                {


                                    repeticoes[int.Parse(jogo4[b])] = repeticoes[int.Parse(jogo4[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 9
                                if (jogo4[b] == jogo9[z])
                                {
                                    repeticoes[int.Parse(jogo4[b])] = repeticoes[int.Parse(jogo4[b])] + 1;

                                    
                                    
                                }
                            }

                        }

                        break;
                    #endregion

                    case 5:
                        #region ComparacaoJogo5
                        //percorrer o quarto jogo
                        for (int b = 0; b < jogo5.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no quarto jogo
                            try
                            {
                                repeticoes.Add(int.Parse(jogo5[b]), 1);
                            }
                            catch (Exception)
                            {

                                repeticoes[int.Parse(jogo5[b])] = repeticoes[int.Parse(jogo5[b])] + 1;
                            }
                            

                            for (int z = 0; z < 6; z++)
                            {


                                //verifica se achou no jogo 6
                                if (jogo5[b] == jogo6[z])
                                {


                                    repeticoes[int.Parse(jogo5[b])] = repeticoes[int.Parse(jogo5[b])] + 1;
                                    
                                }
                                //verifica se achou no jogo 7
                                if (jogo5[b] == jogo7[z])
                                {


                                    repeticoes[int.Parse(jogo5[b])] = repeticoes[int.Parse(jogo5[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 8
                                if (jogo5[b] == jogo8[z])
                                {


                                    repeticoes[int.Parse(jogo5[b])] = repeticoes[int.Parse(jogo5[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 9
                                if (jogo5[b] == jogo9[z])
                                {


                                    repeticoes[int.Parse(jogo5[b])] = repeticoes[int.Parse(jogo5[b])] + 1;

                                    
                                    
                                }
                            }

                        }

                        break;
                    #endregion

                    case 6:
                        #region ComparacaoJogo6
                        //percorrer o quarto jogo
                        for (int b = 0; b < jogo6.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no quarto jogo
                            try
                            {
                                repeticoes.Add(int.Parse(jogo6[b]), 1);
                            }
                            catch (Exception)
                            {

                                repeticoes[int.Parse(jogo6[b])] = repeticoes[int.Parse(jogo6[b])] + 1;
                            }
                            

                            for (int z = 0; z < 6; z++)
                            {

                                //verifica se achou no jogo 7
                                if (jogo6[b] == jogo7[z])
                                {
                                    
                                    repeticoes[int.Parse(jogo6[b])] = repeticoes[int.Parse(jogo6[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 8
                                if (jogo6[b] == jogo8[z])
                                {


                                    repeticoes[int.Parse(jogo6[b])] = repeticoes[int.Parse(jogo6[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 9
                                if (jogo6[b] == jogo9[z])
                                {


                                    repeticoes[int.Parse(jogo6[b])] = repeticoes[int.Parse(jogo6[b])] + 1;

                                    
                                    
                                }
                            }

                        }

                        break;
                    #endregion

                    case 7:
                        #region ComparacaoJogo7
                        //percorrer o quarto jogo
                        for (int b = 0; b < jogo7.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no quarto jogo
                            try
                            {
                                repeticoes.Add(int.Parse(jogo7[b]), 1);
                            }
                            catch (Exception)
                            {

                                repeticoes[int.Parse(jogo7[b])] = repeticoes[int.Parse(jogo7[b])] + 1;
                            }
                            

                            for (int z = 0; z < 6; z++)
                            {

                                //verifica se achou no jogo 8
                                if (jogo7[b] == jogo8[z])
                                {


                                    repeticoes[int.Parse(jogo7[b])] = repeticoes[int.Parse(jogo7[b])] + 1;

                                    
                                    
                                }
                                //verifica se achou no jogo 9
                                if (jogo7[b] == jogo9[z])
                                {


                                    repeticoes[int.Parse(jogo7[b])] = repeticoes[int.Parse(jogo7[b])] + 1;

                                    
                                    
                                }
                            }

                        }

                        break;
                    #endregion

                    case 8:
                        #region ComparacaoJogo8
                        //percorrer o quarto jogo
                        for (int b = 0; b < jogo8.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no quarto jogo
                            try
                            {
                                repeticoes.Add(int.Parse(jogo8[b]), 1);
                            }
                            catch (Exception)
                            {

                                repeticoes[int.Parse(jogo8[b])] = repeticoes[int.Parse(jogo8[b])] + 1;
                            }
                            

                            for (int z = 0; z < 6; z++)
                            {


                                //verifica se achou no jogo 9
                                if (jogo8[b] == jogo9[z])
                                {


                                    repeticoes[int.Parse(jogo8[b])] = repeticoes[int.Parse(jogo8[b])] + 1;

                                    
                                    
                                }
                            }

                        }

                        for (int b = 0; b < jogo9.Count; b++)
                        {
                            //adiciona que foi encontrado uma vez, no quarto jogo
                            try
                            {
                                repeticoes.Add(int.Parse(jogo9[b]), 1);
                            }
                            catch (Exception)
                            {

                                repeticoes[int.Parse(jogo9[b])] = repeticoes[int.Parse(jogo9[b])] + 1;
                            }
                           

                        }

                        break;
                    #endregion

                    default:
                        break;
                }


            }
            #endregion

            //

            //Ordenar e receber lista dos 15 numeros do maior para o menor
            var lista_ling = (from list in repeticoes
                              orderby list.Value
                              descending
                              select list.Key).ToList();
            //Adiciona 5 numeros randomicos
            for (int i = 10; i < lista_ling.Count; i++)
            {
                bool pular = false;
                while(!pular)
                {
                    Random rnd = new Random();
                    int number = rnd.Next(60);

                    if(!lista_ling.Contains(number))
                    {
                        lista_ling[i] = number;
                        pular = true;
                    }
                }
                
            }
            //montar a mascara
            /*MODELOS
             * SISTEMA 37 (MASCARA)
                    1 1  1  1 4  4   4  7   7
                    2 2  2  2 5  5   5  8   8
                    3 3  3  3 6  6   6  9   9
                    4 7 10 13 7 10  13 10  13
                    5 8 11 14 8 11  14 11  14
                    6 9 12 15 9 12  15 12  15
             */

            string jogar1 = String.Format("{0}   {1}   {2}   {3}   {4}   {5}" ,  lista_ling[0], lista_ling[1], lista_ling[2], lista_ling[3],  lista_ling[4],  lista_ling[5]);
            string jogar2 = String.Format("{0}   {1}   {2}   {3}   {4}   {5}" ,  lista_ling[0], lista_ling[1], lista_ling[2], lista_ling[6],  lista_ling[7],  lista_ling[8]);
            string jogar9 = String.Format("{0}   {1}   {2}   {3}   {4}   {5}" , lista_ling[0], lista_ling[1], lista_ling[2], lista_ling[9],  lista_ling[10], lista_ling[11]);
            string jogar3 = String.Format("{0}   {1}   {2}   {3}   {4}   {5}" , lista_ling[0], lista_ling[1], lista_ling[2], lista_ling[12], lista_ling[13], lista_ling[14]);
            string jogar4 = String.Format("{0}   {1}   {2}   {3}   {4}   {5}" ,  lista_ling[3], lista_ling[4], lista_ling[5], lista_ling[6],  lista_ling[7],  lista_ling[8]);
            string jogar5 = String.Format("{0}   {1}   {2}   {3}   {4}   {5}" , lista_ling[3], lista_ling[4], lista_ling[5], lista_ling[9],  lista_ling[10], lista_ling[11]);
            string jogar6 = String.Format("{0}   {1}   {2}   {3}   {4}   {5}" , lista_ling[3], lista_ling[4], lista_ling[5], lista_ling[12], lista_ling[13], lista_ling[14]);
            string jogar7 = String.Format("{0}   {1}   {2}   {3}   {4}   {5}" , lista_ling[6], lista_ling[7], lista_ling[8], lista_ling[9],  lista_ling[10], lista_ling[11]);
            string jogar8 = String.Format("{0}   {1}   {2}   {3}   {4}   {5}", lista_ling[6], lista_ling[7], lista_ling[8], lista_ling[12], lista_ling[13], lista_ling[14]);

            Console.WriteLine(jogar1);
            Console.WriteLine(jogar2);
            Console.WriteLine(jogar3);
            Console.WriteLine(jogar4);
            Console.WriteLine(jogar5);
            Console.WriteLine(jogar6);
            Console.WriteLine(jogar7);
            Console.WriteLine(jogar8);
            Console.WriteLine(jogar9);
            Console.ReadKey();
        }

    }

}

