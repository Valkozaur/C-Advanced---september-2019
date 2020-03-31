namespace _5.Mordor_sCruelPlan.Moods
{
    public class Sad : Mood
    {
        private const int LowerBoundary = -5;
        private const int UpperBoundary = 10;

        public override int From => LowerBoundary;

        public override int To => UpperBoundary;
    }
}
