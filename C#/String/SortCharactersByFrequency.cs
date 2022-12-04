/*
451. Sort Characters By Frequency
Link: https://leetcode.com/problems/sort-characters-by-frequency/

Given a string s, sort it in decreasing order based on the frequency of the characters.
The frequency of a character is the number of times it appears in the string.

Return the sorted string. If there are multiple answers, return any of them.

By using LINQ power:
string.Join("", s.GroupBy(c=>c).OrderByDescending(n=>n.Count()).SelectMany(n=>n));
*/

public class Solution {
    public string FrequencySort(string s) {
        Dictionary<char, int> dic = new Dictionary<char, int>();
        
        // Get frequencies
        for(int i=0; i<s.Length; i++){
            if(dic.ContainsKey(s[i]))
                dic[s[i]] +=1;
            else
                dic.Add(s[i],1);
        }
        var sdi = from c in dic orderby c.Value descending select c;
        
        // Attach chars to result 
        var result = new StringBuilder();
        foreach (var val in sdi) 
            result.Append(val.Key, val.Value);
        
        return result.ToString();
    }
}