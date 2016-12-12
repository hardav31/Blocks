//Подсчитать число лесенок, которое можно построить из N кубиков.
//Ввод
//На входе записано число kubikcount(1 ≤ kubikcount ≤ 400).
//каждая следующая лестница должна быть больше чем предыдущая
//Вывод
//Вывести искомое число лесенок

//пример:
//kubikcount=6
//1 5
//2 4
//1 2 3
//ответ: 3

using System;
class Davo
{
    public static int Case2(int u,int k) 
    {
        int reslut = 0;
        if (u >= k / 2) 
        {
            return 0;
        }
        for (int i = u+1; i <=k/2 ; i++) 
        {
            for (int j = i+1; j < k; j++) 
            {
                if (i + j == k && i < j) 
                {
                    reslut = reslut + 1;
                }
            }
        }
        return reslut;
    }

    public static int[][] Cases(int u,int k) 
    {
    int[][] M=new int[Case2(u,k)][];
    if (M == null) 
    {
        return null;
    }
    for (int i = 0; i < M.Length; i++) 
    {
        M[i] = new int[2];
    }
    int index = 0;
    for (int i = u+1; i <= k/2; i++)
    {
        for (int j = i+1; j < k; j++)
        {
            if (i + j == k && i < j)
            {
                M[index][0] = i;
                M[index][1] = j;
                index++;
            }
        }
    }
    return M;
    }

    public static int dipuk(int depq,int[][] M) 
    {
        
        int[][] N;
        if (M == null) 
        {
            return 0;
        }
        for (int i = 0; i < M.Length; i++)
        {
            N = Cases(M[i][0], M[i][1]);
            depq = Case2(M[i][0], M[i][1])+dipuk(depq,N);
        }
        return depq;
    }
    static void Main()
    {
        DateTime nowtime = DateTime.Now;
        int result = 0;
        int kubikcount = 400;



        int[][] M=new int[Case2(0,kubikcount)][];
        M = Cases(0, kubikcount);
        GC.Collect(0);
        
        result = dipuk(0, M)+Case2(0,kubikcount);
        GC.Collect(0);
        
        Console.WriteLine(result);
        Console.WriteLine();
            DateTime howtime = DateTime.Now;
            TimeSpan ooo = howtime - nowtime;
            Console.WriteLine(ooo);
        
    }
}