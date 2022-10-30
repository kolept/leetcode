// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Solution s = new Solution();
int[] input = new int[] { 2, 7, 11, 15 };
s.TwoSum(input, 9);

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] result = new int[10];
        Dictionary<string, int> input = new Dictionary<string, int>();
        //Input: nums = [2, 7, 11, 15], target = 9

        for (int a=0;a<nums.Length;a++) 
        {
            input.Add(a.ToString() + nums[a].ToString(), nums[a]);        
        }


        for (int a = 0; a < nums.Length; a++) 
        {
            int remain = target - nums[a];
            var key= a.ToString() + nums[a];

            int value;

            if (input.ContainsValue(remain))
            {
                input.TryGetValue(key, out value);
            
            }


        }
        

        return result;


    }
}