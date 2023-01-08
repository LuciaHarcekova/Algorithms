/*
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
*/

class Solution {

    // Calculate greatest common denominator
    int gcd(int a, int b) {
        if (b == 0) return a;
        return gcd(b, a % b);
    }

    // Get the slope coefficient.
    // Ensure a != b, either it should be a verticalor or 
    // horizontal line. And a and b should be distinct points
    private String getSlope(int[] a, int[] b) {
        int Y = b[1] - a[1];
        int X = b[0] - a[0];
        
        // Hack for horizontal line point
        if (Y == 0) X = 1;
        
        // Hack for vertical line point
        if (X == 0) Y = 1;
        
        // Follow convention of -ve and +ve denominators, that
        // -1/2 is same as 1/-2 for considering lines with same slopes
        if ((X < 0 && Y > 0) || (X < 0 && Y < 0)) {
            X = -X;
            Y = -Y;
        }

        int gcd = gcd(Math.abs(X), Math.abs(Y));
        Y /= gcd;
        X /= gcd;
        
        return Y + "," + X;
    }

    public int maxPoints(int[][] points) {
        
        // Edge cases
        if (points == null) return 0;
        if (points.length <= 2) return points.length;
        
        // Save number of points with the same slope where
        // the key is a pair 'Y + " " + X' representing slope
        Map<String, Integer> map = new HashMap<>();
        int maxNumberOfPoints = 2;
        
        for (int i = 0; i < points.length; i++) {

            // Count of maximum points on a line passing through points[i]
            int tmpMax = 0;
        
            for (int j = i + 1; j < points.length; j++) {
                String slope = getSlope(points[i], points[j]);
                map.put(slope, 1 + map.getOrDefault(slope, 0));
                // Check if maximum has changed
                tmpMax = Math.max(tmpMax, map.get(slope));
            }
            
            maxNumberOfPoints = Math.max(maxNumberOfPoints, tmpMax + 1);
            map.clear();
        }

        return maxNumberOfPoints;     
    }
}