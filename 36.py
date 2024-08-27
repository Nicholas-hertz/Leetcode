def checkRows(board):
        numsInRow = ""
        for row in board:
            for num in row:
                if num != ".":
                    if num not in numsInRow:
                        numsInRow += num
                    else:
                        return False
            numsInRow = ""
        return True

def checkCols(board):
    numsInCol = ""
    index = 0

    while index < 9:
        for row in board:
            if row[index] != ".":
                if row[index] not in numsInCol:
                    numsInCol += row[index]
                else:
                    return False
        numsInCol = ""
        index += 1
    return True
    
def checkGrids(board):
    #first index is width
    #second is height
    grids = [[3,3], [6,3], [9,3], [3,6], [6,6], [9,6], [3,9], [6,9], [9,9]]
    numsInGrid = ""

    for grid in grids:
        for height in range(grid[1] - 3, grid[1]):
            for width in range(grid[0] - 3, grid[0]):
                if board[height][width] != ".":
                    if board[height][width] not in numsInGrid:
                        numsInGrid += board[height][width]
                    else:
                        return False
        numsInGrid = ""
    return True


class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        if checkRows(board) and checkCols(board) and checkGrids(board):
            return True
        else:
            return False