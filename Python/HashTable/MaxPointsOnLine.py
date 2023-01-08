"""
149. Max Points on a Line
Link: https://leetcode.com/problems/max-points-on-a-line/

Given an array of points where points[i] = [xi, yi] represents a point on
the X-Y plane, return the maximum number of points that lie on the same
straight line.

Example 1:
Input: points = [[1,1],[2,2],[3,3]]
Output: 3

Example 2:
Input: points = [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
Output: 4

Approach:
How to check if three points are on the same line?
Calculate if slopes of two pairs are the same.
"""

class Solution(object):

    # Calculate greatest common denominator
    def gcd(self, a, b):
        if b == 0: return a
        return self.gcd(b, a % b)


    # Get the slope coefficient.
    # Ensure a != b, either it should be a verticalor or 
    # horizontal line. And a and b should be distinct points
    def get_slope(self, a, b):
        Y = b[1] - a[1]
        X = b[0] - a[0]
        
        # Hack for horizontal line point
        if Y == 0: X = 1
        
        # Hack for vertical line point
        if X == 0: Y = 1
        
        # Follow convention of -ve and +ve denominators, that
        # -1/2 is same as 1/-2 for considering lines with same slopes
        if (X < 0 and Y > 0) or (X < 0 and Y < 0):
            X = -X
            Y = -Y

        gcd = self.gcd(abs(X), abs(Y))
        Y /= gcd
        X /= gcd
        
        return str(Y) + "," + str(X)

    def maxPoints(self, points):
        """
        :type points: List[List[int]]
        :rtype: int
        """

        # Edge cases
        if not points: return 0
        if len(points) <= 2: return len(points)
        
        # Save number of points with the same slope where
        # the key is a pair 'Y + " " + X' representing slope
        dict = collections.defaultdict(int)
        maxNumberOfPoints = 2
        
        for i in range(len(points)):

            # Count of maximum points on a line passing through points[i]
            tmpMax = 0
        
            for j in range(i+1, len(points)):
                slope = self.get_slope(points[i], points[j])

                # Add to dicttionary
                dict[slope] += 1

                # Check if maximum has changed
                tmpMax = max(tmpMax, dict[slope])
            
            maxNumberOfPoints = max(maxNumberOfPoints, tmpMax + 1)
            dict.clear()

        return maxNumberOfPoints;     
