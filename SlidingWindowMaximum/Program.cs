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

Console.WriteLine(MaxSlidingWindow(new int[] { 1, 3, 1, 2, 0, 5 }, 3));
//Console.WriteLine(MaxSlidingWindow(new int[] { 9,8,7,6,5,4,3,2,1,0,-1,-2,-3,-4,-5 }, 6));
static int[] MaxSlidingWindow(int[] nums, int k)
{
    var myLinkedList = new MyLinkedList();
    var result = new int[nums.Length - k + 1];

    for (int i = 0; i < nums.Length; i++)
    {
        while (myLinkedList.Count > 0 && nums[myLinkedList.GetLast()] < nums[i])
        {
            myLinkedList.RemoveLast();
        }

        if (myLinkedList.Count > 0 && myLinkedList.GetFirst() == i - k)
        {
            myLinkedList.RemoveFirst();
        }

        myLinkedList.Add(i);

        if (i < k - 1)
        {
            continue;
        }

        result[i - k + 1] = nums[myLinkedList.GetFirst()];
    }
    return result;
}

class MyLinkedList
{
    public MyNode Head { get; set; } = new MyNode();
    public MyNode Tail { get; set; } = new MyNode();
    public int Count { get; private set; } = 0;

    public int GetFirst()
    {
        return Head.Value;
    }
    public int GetLast()
    {
        return Tail.Value;
    }

    public void RemoveFirst()
    {
        Head = Head.Next ?? new MyNode();
        Count--;
    }

    public void RemoveLast()
    {
        Tail = Tail.Previous ?? new MyNode();
        Count--;
    }

    public void Add(int value)
    {
        var myNode = new MyNode
        {
            Value = value
        };

        if (Count == 0)
        {
            Head = myNode;
            Tail = myNode;
        }
        else
        {
            myNode.Previous = Tail;
            Tail.Next = myNode;
            Tail = myNode;
        }
        Count++;
    }
}

class MyNode
{
    public int Value { get; set; }
    public MyNode? Previous { get; set; }
    public MyNode? Next { get; set; }
}

#endregion