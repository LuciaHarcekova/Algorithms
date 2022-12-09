/*
1.6 String Compression
Link: https://www.crackingthecodinginterview.com

Implement a method to perform basic string compression using the counts
of repeated characters. For example, the string aabcccccaaa would become
a2blc5a3. If the "compressed" string would not become smaller than the
original string, your method should return the original string. You can
assume the string has only uppercase and lowercase letters (a - z).
 */

using System;
using System.Text;

public class Solution
{
    public static string StringCompression(string str) {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        for (int i = 0; i < str.Length; i++) {
           count++;
           if (i + 1 >= str.Length || str[i+1] != str[i]){
               sb.Append(str[i]).Append(count);
               count = 0;
           }
       }
       return sb.ToString().Length < str.Length ? sb.ToString() : str;
    }
}
