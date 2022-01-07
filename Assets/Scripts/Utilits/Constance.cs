using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constance
{
    // n bo'lgan son bor n = 20
    public static int[] GetRandomIndex(int n)
    {
        int m = Random.Range(0, n); 

        List<int> temp = new List<int>();

        temp.Add(m);

        int count = 0;

        bool isLoop = true;

        while (isLoop)
        {
            m = Random.Range(0, n);
            if(!temp.Contains(m))
            {
                temp.Add(m);
            }
            else
            {
                count++;
            }

            if(count == 100 || temp.Count == n)
            {
                isLoop = false;
            }
        }


        return temp.ToArray();
    }


}
