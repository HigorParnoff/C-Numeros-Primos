using System;

class MainClass {
  public static void Main (string[] args) {
    int nUm=0; // Usuário vai informar o número máximo
    int contDivisao = 0; // Conta o número de divisões realizadas para encontrar o número primo
    int tamanhoVet, posicaoVet=1; // Uso para calcular o tamanho do vetor na linha 14 ,   Uso para saber a ultima posição que guardei dados do vetor

    while((nUm<=2)||(nUm%2!=0)){
      Console.WriteLine("Informe um número Par maior que 2 ");
      nUm = Convert.ToInt32(Console.ReadLine());
    }
    tamanhoVet = nUm/2; 
    int[] vetDivisoes = new int[tamanhoVet];
    int[] vetPrimo = new int[tamanhoVet];
    vetPrimo[0] = 2;
    vetDivisoes[0] = 0;

    int[,] matrizResultados = new int[tamanhoVet, 2]; // Guarda o conjunto dos números primos que somados resultam no mesmo número par solicitado pelo úsuário.
    int linha=0; // Uso para rodar a matriz na linha 50

    // Encontra os números primos e guarda no vetor vetPrimo
    for(int i=3; i<=nUm; i++){
      for(int j=0; j<posicaoVet; j++){
        if(i%vetPrimo[j] == 0){
          contDivisao++;
          break;
        }else{
          contDivisao++;
          if(i/vetPrimo[j] < vetPrimo[j]){ // Entrou é primo
            contDivisao++;
            vetDivisoes[posicaoVet] = contDivisao - vetDivisoes[posicaoVet-1];
            vetPrimo[posicaoVet] = i;
            posicaoVet++;
            //Console.WriteLine("{0} divisões", contDivisao);
            break;
          }
          contDivisao++;
        }
      }
      System.Threading.Thread.Sleep(1);
    }

    // Encontra os números primos que somados resultam no número par
    for(int i=0; i<posicaoVet; i++){
      for(int j=posicaoVet-1; j>=0; j--){
        if(vetPrimo[i]+vetPrimo[j] <nUm){break;} // Se o menor número primo mais o maior número primo for menor que o número digitado pelo usuário roda para o próximo número primo
        if(vetPrimo[i]+vetPrimo[j] == nUm){
          matrizResultados[linha, 0] = vetPrimo[i];
          matrizResultados[linha, 1] = vetPrimo[j];
          linha++;
          break;
          } // Se entrar você tem o resultado os números primos nas posições i e j do vetPrimo
      }
    }

    //Saídas
    for(int i=0; i<posicaoVet; i++){
      Console.WriteLine("{0} é primo  -  {1} Divisões", vetPrimo[i], vetDivisoes[i]);
    }
    Console.WriteLine("Foram efetuadas {0} divisões. O tamanho Vetor = {1}\n\n Conjunto dos resultados:", contDivisao, tamanhoVet);

    for(int i=0; i<linha; i++){
      Console.Write("{0} + {1} = {2}\n", matrizResultados[i, 0], matrizResultados[i, 1], nUm);
    }
  }
}