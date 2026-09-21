Console.Clear();
//PASSO A PASSO DO EXERCÍCIO 06a
//1 - Criar um vetor de valores numéricos
//2 - Necessário um laço de repetição - FOR
//3 - Gerar os valores aleatórios
//4 - Guardar os valores dentro do vetor

//Criar um vetor de valores numéricos
int[] vetor = new int[100];

//Necessário um laço de repetição - FOR
Random random = new Random();
for(int i = 0; i < vetor.Length; i++)
{
    //Gerar os valores aleatórios
    //Guardar os valores dentro do vetor
    vetor[i] = random.Next(1000);
}

//Imprimir o vetor não ordenado
for(int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}

//5 - Percorrer o vetor com um laço de repetição
//6 - Comparar se a posição atual é maior que a próxima
//7 - Se for maior, realizar a troca de valores
//8 - Verificar se o maior valor está na última posição

bool troca = false;
do
{
    troca = false;
    for (int i = 0; i < vetor.Length - 1; i++)
    {
        // int atual = vetorNaoOrdenado[i];
        // int proxima = vetorNaoOrdenado[i + 1];
        if(vetor[i] > vetor[i + 1])
        {
            troca = true;
            int aux = vetor[i];
            vetor[i] = vetor[i + 1];
            vetor[i + 1] = aux; 
        }
    }    
}while(troca);

//Imprimir o vetor ordenado
Console.WriteLine("\n\n");
for(int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}
