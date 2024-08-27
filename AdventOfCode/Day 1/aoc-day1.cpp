
#include <iostream>
#include <fstream>
#include <stdio.h>
#include <vector>

using namespace std;


 vector<int> getCalibrationNumbers(string filename)
 {
    string textLine;
    ifstream readFile(filename);

    vector<int> calibrationVals;

    while (getline (readFile, textLine))
    {
        //loop over each line of text to determine the values (we want the first and last number in the string)
        bool firstFound = false;
        string firstNumber;
        string lastNumber;
        for(int i = 0; i < textLine.length(); i++)
        {
            //if we have a digit
            if(isdigit(textLine.at(i)))
            {
                //if this is the first digit, save it. otherwise overwrite last digit
                if(!firstFound)
                {
                    firstNumber = textLine.at(i);
                    firstFound = true;
                }
                else
                {
                    lastNumber = textLine.at(i);
                }
            }
        }

        string strCalValue;
        if(!firstNumber.empty() && !lastNumber.empty()){

            strCalValue = firstNumber + lastNumber;
        }
        else if(firstNumber.empty() && !lastNumber.empty()){

            strCalValue = lastNumber + lastNumber;
        }
        else if(!firstNumber.empty() && lastNumber.empty()){

            strCalValue = firstNumber + firstNumber;
        }

        int calValue = stoi(strCalValue);
        
        calibrationVals.push_back(calValue);
    }

    readFile.close();

    return calibrationVals;
}

int calculateSum(vector<int> values)
{
    unsigned int size = values.size();

    int sum = 0;
    for(unsigned int i = 0; i < size; i++){
        sum = sum + values[i];
    }
    return sum;

}

int main() {

    vector<int> values = getCalibrationNumbers("calibrations.txt");

    int sum = calculateSum(values);

    cout << sum << endl;

    return 0;
}