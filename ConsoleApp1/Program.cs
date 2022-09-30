// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");

//Input: strs = ["flower","zlow","flight"]
var str = new string[] { "aa", "ab" };
//var str = new string[] { "aa", "ab" };



BinarySearch sol = new BinarySearch();
sol.LongestCommonPrefix(str);


public class BinarySearch
{

    public string LongestCommonPrefix(string[] strs)
    {
        if (strs[0] == string.Empty && strs.Length == 1)
        {
            return strs[0];
        }

        var list1 = new List<string>();
        var list2 = new List<int>();



        for (int a = 0; a < strs.Length; a++)
        {
            list1.Add(strs[a]);
            list2.Add(strs[a].Length);

        }

        string[] str = list1.ToArray();

        var min = list2.Min();
        int middle = (list1.Count() + 1) / 2;


        List<char[]> arrayList = new List<char[]>();

        foreach (var item in list1)
        {
            arrayList.Add(item.ToCharArray());
        }

        bool leftHalf = isCommonPrefix(str, middle);

        int rightIndex = 0;
        if (leftHalf == true)
        {
            //check right
            for (int a = middle + 1; a <= min; a++)
            {
                bool checkRight = isCommonPrefix(str, a);

                if (checkRight == false)
                {
                    break;
                }
                rightIndex++;
            }
        }

        var result = strs[0].Substring(0, middle + rightIndex);

        return result;




        //return strs[0].Substring(0, (low + high) / 2);

    }
    //Input: strs = ["flower","flow","flight"]
    private bool isCommonPrefix(String[] strs, int len)
    {
        String str1 = strs[0].Substring(0, len);
        for (int i = 1; i < strs.Length; i++) 
        {
            Console.WriteLine(strs[i].StartsWith(str1));
            if (!strs[i].StartsWith(str1))
                return false;
        }
            
        return true;

    }
}

public class HashTableDynamic
{

    //Input: strs = ["flower","flow","flight"]
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs[0] == string.Empty)
        {
            return string.Empty;
        }

        if (strs.Length == 1)
        {
            return strs[0];
        }
        
        var list1 = new List<string>();
        for (int a = 0; a < strs.Length; a++)
        {
            list1.Add(strs[a]);
        }            


        List<char[]> arrayList = new List<char[]>();

        foreach (var item in list1) 
        {
            arrayList.Add(item.ToCharArray());        
        }

        arrayList.RemoveAt(0);

        List<Hashtable> htablesList = new List<Hashtable>();


        foreach (var item in arrayList) 
        {
            var hashTableInput = new Hashtable();
            for (int a = 0; a < item.Length; a++)
            {
                hashTableInput.Add(a, string.Format("{0}{1}",a, item[a]));
            }

            htablesList.Add(hashTableInput);           

        }


        var a1 = list1[0].ToCharArray(); 
        StringBuilder sb = new StringBuilder();
     
        for (int i = 0; i < a1.Length; i++)
        {
            var check = string.Format("{0}{1}", i, a1[i]);
            Console.WriteLine(check);
            var result = htablesList.TrueForAll(x => x.ContainsValue(check));


            if (result == true)

            {
                sb.Append(a1[i]);
            }

            else
            {
                break;

            }
        }
       

        return sb.ToString();


    }

}



