namespace OtusHomeWork05
{
    public interface IFlyingRobot : IRobot 
    {
        public new string GetRobotType()
        {
            return "I am a flying robot.";
        }
    }
}
