#region Problem
/*
You are given an array of integers nums, 
there is a sliding window of size k which is moving from the very left of the array to the very right. 
You can only see the k numbers in the window. Each time the sliding window moves right by one position.
Return the max sliding window.

Example 1:
Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
Output: [3,3,5,5,6,7]
Explanation: 
Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7

Example 2:
Input: nums = [1], k = 1
Output: [1]

LeetCode link: https://leetcode.com/problems/sliding-window-maximum/
*/
#endregion

#region Solution

//Console.WriteLine(MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3));
Console.WriteLine(MaxSlidingWindow(new int[] { 9,8,7,6,5,4,3,2,1,0,-1,-2,-3,-4,-5 }, 6));
static int[] MaxSlidingWindow(int[] nums, int k)
{
    var result = new int[nums.Length - k + 1];
    int maxIndex = -1;

    for (var i = 0; i <= nums.Length - k; i++)
    {
        if (maxIndex < i)
        {
            var substring = nums[i..(i + k)];
            (result[i], maxIndex) = substring.Select((n, i) => (n, i)).Max();
            maxIndex += i;
        }
        else if (result[i - 1] > nums[i + k -1])
        {
            result[i] = result[i - 1];
        }
        else
        {
            result[i] = nums[i + k - 1];
            maxIndex = i + k - 1;
        }
    }

    return result;
}

#endregion