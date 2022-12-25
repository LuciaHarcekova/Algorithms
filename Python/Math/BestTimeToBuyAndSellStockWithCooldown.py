"""
309. Best Time to Buy and Sell Stock with Cooldown
link: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/

You are given an array prices where prices[i] is the price of a given stock on the
ith day.

Find the maximum profit you can achieve. You may complete as many transactions as
you like (i.e., buy one and sell one share of the stock multiple times) with the
following restrictions:

After you sell your stock, you cannot buy stock on the next day (i.e., cooldown one day).
Note: You may not engage in multiple transactions simultaneously (i.e., you must sell
the stock before you buy again).


Example 1:
Input: prices = [1,2,3,0,2]
Output: 3
Explanation: transactions = [buy, sell, cooldown, buy, sell]

Example 2:
Input: prices = [1]
Output: 0

Approach:
What action you can take on the day i?
- we have 0 stock and we buy stock 
- we have 0 stock and we do nothing
- we have 1 stock and we sell it
- we have 1 stock and we do nothing
That means we can eaither sell or do nothing.

profit_grows[i] = assuming our stock grows (profit today + profit yesterday)
profit_dropped[i] = assuming our stock has dropped (profit before yesterday, so we sold
it before yesterday and yesterday we had a do-nothing day

Relationship between i and i+1 day?
profit_grows[i+1] means the profit grows, we take a maximum from the day before profit
plus today's growth, comparing price if we to do ntg today and take money from sold day before
max(profit_sell[i]+prices[i+1]-prices[i], profit_dropped[i])

profit_dropped[i+1] - on the day i was there drop, I do ntg today and take maximum
profit from the previous sell or did nothing:
max(profit_dropped[i], profit_grows[i])
"""

class Solution(object):
    def maxProfit(self, prices):
        """
        :type prices: List[int]
        :rtype: int
        """
        profit_grows = 0
        profit_dropped = 0 
  
        for i in range (1, len(prices)):
            tmp = profit_grows
            profit_grows = max(profit_grows+prices[i]-prices[i-1], profit_dropped)
            profit_dropped = max(tmp, profit_dropped)

        return max(profit_grows, profit_dropped)
