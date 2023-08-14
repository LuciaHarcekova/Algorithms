/*
215. Kth Largest Element in an Array
Link: https://leetcode.com/problems/kth-largest-element-in-an-array/

Given an integer array nums and an integer k, return the kth largest element in the array.
Note that it is the kth largest element in the sorted order, not the kth distinct element.
Can you solve it without sorting?

Example 1:
Input: nums = [3,2,1,5,6,4], k = 2
Output: 5

Example 2:
Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4

Source:
https://leetcode.com/problems/kth-largest-element-in-an-array/solutions/3906260/100-3-approaches-video-heap-quickselect-sorting/
*/

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        Array.Sort(nums);
        return nums[nums.Length - k];
    }
}

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        MinHeap minHeap = new MinHeap(k);
        for (int i = 0; i < k; i++) {
            minHeap.Insert(nums[i]);
        }
        
        for (int i = k; i < nums.Length; i++) {
            if (nums[i] > minHeap.Peek()) {
                minHeap.Pop();
                minHeap.Insert(nums[i]);
            }
        }
        
        return minHeap.Peek();
    }
}

public class MinHeap {
    private int[] heap;
    private int size;

    public MinHeap(int capacity) {
        heap = new int[capacity];
        size = 0;
    }

    public void Insert(int val) {
        heap[size] = val;
        size++;
        BubbleUp();
    }

    public int Peek() {
        return heap[0];
    }

    public int Pop() {
        int poppedValue = heap[0];
        heap[0] = heap[size - 1];
        size--;
        BubbleDown();
        return poppedValue;
    }

    private void BubbleUp() {
        int index = size - 1;
        while (index > 0 && heap[index] < heap[Parent(index)]) {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private void BubbleDown() {
        int index = 0;
        while (HasLeftChild(index) && (heap[index] > LeftChild(index) || HasRightChild(index) && heap[index] > RightChild(index))) {
            int smallerChildIndex = LeftChildIndex(index);
            if (HasRightChild(index) && RightChild(index) < LeftChild(index)) {
                smallerChildIndex = RightChildIndex(index);
            }
            Swap(index, smallerChildIndex);
            index = smallerChildIndex;
        }
    }

    private int Parent(int index) { return (index - 1) / 2; }
    private int LeftChildIndex(int index) { return 2 * index + 1; }
    private int RightChildIndex(int index) { return 2 * index + 2; }

    private bool HasLeftChild(int index) { return LeftChildIndex(index) < size; }
    private bool HasRightChild(int index) { return RightChildIndex(index) < size; }

    private int LeftChild(int index) { return heap[LeftChildIndex(index)]; }
    private int RightChild(int index) { return heap[RightChildIndex(index)]; }

    private void Swap(int indexOne, int indexTwo) {
        int temp = heap[indexOne];
        heap[indexOne] = heap[indexTwo];
        heap[indexTwo] = temp;
    }
}