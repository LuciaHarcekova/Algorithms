/*
1.6 String Compression
Link: https://www.crackingthecodinginterview.com

Implement a method to perform basic string compression using the counts
of repeated characters. For example, the string aabcccccaaa would become
a2blc5a3. If the "compressed" string would not become smaller than the
original string, your method should return the original string. You can
assume the string has only uppercase and lowercase letters (a - z).
 */

public class Solution {
    public static String stringCompression(String str) {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        char[] strArray = str.toCharArray();
        
        for (int i = 0; i < strArray.length; i++) {
           count++;
           if (i + 1 >= strArray.length || strArray[i+1] != strArray[i]) {
               sb.append(strArray[i]).append(count);
               count = 0;
           }
       }
       return sb.length() < strArray.length ? sb.toString() : str;
    }
}