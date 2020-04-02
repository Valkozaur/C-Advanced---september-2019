namespace _5.Mordor_sCruelPlan.Moods
{
    public class Happy : Mood
    {
        private const int LowerBoundary = 10;
        private const int UpperBoundary = 15;

        public override int From => LowerBoundary;

        public override int To => UpperBoundary;
    }
}
