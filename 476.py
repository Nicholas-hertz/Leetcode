class Solution:
    def findComplement(self, num: int) -> int:

        def decimalToBinary(num): 
            return bin(num).replace("0b", "") 

        def binaryToDecimal(num):
            return int(num,2)

        def invertBinary(binary):
            output = ""
            for num in binary:
                if num == "0":
                    output = output + "1"
                else:
                    output = output + "0"
            return output

        binary = decimalToBinary(num)
        invert = invertBinary(binary)
        output = binaryToDecimal(invert)
        return output

    