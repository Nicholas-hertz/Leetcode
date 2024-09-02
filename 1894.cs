public class Solution {
    public int ChalkReplacer(int[] chalk, int k) {
        while(k >= 0){
            for(var i = 0; i < chalk.Length; i++){
                if(chalk[i] > k){
                    return i;
                }
                k = k - chalk[i];
            }
        }

        return 0;
    }
}