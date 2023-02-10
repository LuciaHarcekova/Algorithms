/*
2306. Naming a Company
Link: https://leetcode.com/problems/naming-a-company/

You are given an array of strings ideas that represents a list of names to
be used in the process of naming a company. The process of naming a company
is as follows:

Choose 2 distinct names from ideas, call them ideaA and ideaB.
Swap the first letters of ideaA and ideaB with each other.
If both of the new names are not found in the original ideas, then the name
ideaA ideaB (the concatenation of ideaA and ideaB, separated by a space) is
a valid company name.
Otherwise, it is not a valid name.
Return the number of distinct valid names for the company.

Example 1:
Input: ideas = ["coffee","donuts","time","toffee"]
Output: 6
Explanation: The following selections are valid:
- ("coffee", "donuts"): The company name created is "doffee conuts".
- ("donuts", "coffee"): The company name created is "conuts doffee".
- ("donuts", "time"): The company name created is "tonuts dime".
- ("donuts", "toffee"): The company name created is "tonuts doffee".
- ("time", "donuts"): The company name created is "dime tonuts".
- ("toffee", "donuts"): The company name created is "doffee tonuts".
Therefore, there are a total of 6 distinct company names.

The following are some examples of invalid selections:
- ("coffee", "time"): The name "toffee" formed after swapping already exists in the original array.
- ("time", "toffee"): Both names are still the same after swapping and exist in the original array.
- ("coffee", "toffee"): Both names formed after swapping already exist in the original array.

Example 2:
Input: ideas = ["lack","back"]
Output: 0
Explanation: There are no valid selections. Therefore, 0 is returned.

Approach:
https://leetcode.com/problems/naming-a-company/solutions/2140970/c-count-all-26-26-possible-pairs/
https://leetcode.com/problems/naming-a-company/solutions/2140967/count-pairs/
https://leetcode.com/problems/naming-a-company/solutions/2140934/c-o-n-counting-pairs-easy-to-understand/
https://leetcode.com/problems/naming-a-company/solutions/2140944/python3-solution-easy-to-understand/
*/

class Solution {
    public long distinctNames(String[] ideas) {
        long res = 0, cnt[][] = new long[26][26];
        Set<String>[] s = new HashSet[26];
        for (int i = 0; i < 26; ++i)
            s[i] = new HashSet<>();    
        for (var idea : ideas)
            s[idea.charAt(0) - 'a'].add(idea.substring(1));
        for (int i = 0; i < 26; ++i)
            for (var suff : s[i])
                for (int j = 0; j < 26; ++j)
                    cnt[i][j] += s[j].contains(suff) ? 0 : 1;
        for (int i = 0; i < 26; ++i)
            for (int j = 0; j < 26; ++j)
                res += cnt[i][j] * cnt[j][i];
        return res;
    }
}