public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles) {
        //init to north since thats how we start in the prompt
        int currDirectionIndex = 0;
        string direction = "NORTH";
        int[] robotPosition = new int[2] {0, 0};
        int maxDistanceRecorded = 0;

        foreach(int command in commands){
            if(command == -1){
                if(currDirectionIndex != 3)
                    currDirectionIndex++;
                else
                    currDirectionIndex = 0; //reset back to start
                direction = RotateRobot(currDirectionIndex);
            }
            else if (command == -2){
                if(currDirectionIndex != 0)
                    currDirectionIndex--;
                else
                    currDirectionIndex = 3; //reset back to end
                direction = RotateRobot(currDirectionIndex);
            }
            else{
                //move robot
                robotPosition = MoveRobot(robotPosition, command, obstacles, direction);
                var distance = DetermineEuclideanDistance(robotPosition);
                if(distance > maxDistanceRecorded){
                    maxDistanceRecorded = distance;
                }
            }
        }

        return maxDistanceRecorded;
    }

    public string RotateRobot(int index){
        //NORTH, SOUTH, EAST, WEST STORAGE
        List<string> directions = new List<string> {"NORTH", "EAST", "SOUTH", "WEST"};
        return directions[index];
    }

    public int DetermineEuclideanDistance(int[] robotPosition){
        var distance = (robotPosition[0] * robotPosition[0]) + (robotPosition[1] * robotPosition[1]);
        return distance;
    }

    public int[] MoveRobot(int[] robotPosition, int k, int[][] obstacles, string direction){
        int[] desiredPosition;
        for(int i = 0; i < k; i++){
            switch(direction)
            {
                case "NORTH":
                    desiredPosition = new int[2] { robotPosition[0], robotPosition[1] + 1};
                    if(CanProceed(desiredPosition, obstacles)){
                        robotPosition[1] = robotPosition[1] + 1;
                    }
                    else{
                        return robotPosition;
                    }
                    break;
                case "EAST":
                    desiredPosition = new int[2] { robotPosition[0] + 1, robotPosition[1]};
                    if(CanProceed(desiredPosition, obstacles)){
                        robotPosition[0] = robotPosition[0] + 1;
                    }
                    else{
                        return robotPosition;
                    }
                    break;
                case "SOUTH":
                    desiredPosition = new int[2] { robotPosition[0], robotPosition[1] - 1};
                    if(CanProceed(desiredPosition, obstacles)){
                        robotPosition[1] = robotPosition[1] - 1;
                    }
                    else{
                        return robotPosition;
                    }
                    break;
                case "WEST":
                    desiredPosition = new int[2] { robotPosition[0] - 1, robotPosition[1]};
                    if(CanProceed(desiredPosition, obstacles)){
                        robotPosition[0] = robotPosition[0] - 1;
                    }
                    else{
                        return robotPosition;
                    }
                    break;
            }
        }

        return robotPosition;
    }

    public bool CanProceed(int[] desiredPosition, int[][] obstacles){
    {
        var canProceed = true;
        for(int i = 0; i < obstacles.Length; i++){
            if(desiredPosition[0] == obstacles[i][0] &&
                desiredPosition[1] == obstacles[i][1])
                {
                    canProceed = false;
                }
        }
        return canProceed;
    }
}}