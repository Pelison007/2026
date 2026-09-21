Console.Clear();

int[] vetor = new int[100];

Random random = new Random();
for(int i = 0; i < vetor.Length; i++)
{
    vetor[i] = random.Next(1000);
}

for(int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}

Array.Sort(vetor);

Console.WriteLine("\n\n");
for(int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}
