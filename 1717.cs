public class Solution {
    public int MaximumGain(string s, int x, int y) {
        int output = 0;
        string xWord = "ab";
        string yWord = "ba";

        bool containsEitherSub = DoesStringContainSubstr(s, xWord) || DoesStringContainSubstr(s, yWord);

        while(containsEitherSub){

            if(x > y){
                if(DoesStringContainSubstr(s, xWord)){
                    s = PerformSubstr(s, xWord);
                    output += x;
                } else {
                    s = PerformSubstr(s, yWord);
                    output += y;
                }
            }
            else{
                if(DoesStringContainSubstr(s, yWord)){
                    s = PerformSubstr(s, yWord);
                    output += y;
                } else {
                    s = PerformSubstr(s, xWord);
                    output += x;
                }
            }
            
            containsEitherSub = DoesStringContainSubstr(s, xWord) || DoesStringContainSubstr(s, yWord);
            
        }

        return output;
    }

    public bool DoesStringContainSubstr(string word, string sub){
        return word.Contains(sub);
    }

    public string PerformSubstr(string word, string sub){
        int index = word.LastIndexOf(sub);

        if(index == -1){
            return word;
        }

        return word.Remove(index, sub.Length);
    }

}