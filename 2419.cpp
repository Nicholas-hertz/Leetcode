class Solution {
public:
    int longestSubarray(vector<int>& nums) {
        int max = nums[0];

        for(int i = 1; i < nums.size(); i++)
        {
            if(nums[i] > max){
                max = nums[i];
            }
        }

        int maxArray = 0;
        int currSubArray = 0;
        for(int i = 0; i < nums.size(); i++)
        {
            if(nums[i] == max){
                currSubArray++;
            }
            else{
                if(currSubArray > maxArray){
                    maxArray = currSubArray;
                }
                currSubArray = 0;
            }
        }

        if(currSubArray > maxArray)
            return currSubArray;

        return maxArray;
    }
};