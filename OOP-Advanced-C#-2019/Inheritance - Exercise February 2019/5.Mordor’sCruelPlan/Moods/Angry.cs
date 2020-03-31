namespace _5.Mordor_sCruelPlan.Moods
{
    public class Angry : Mood
    {
        private const int UpperBoundary = -5;

        public override int From => int.MinValue;

        public override int To => UpperBoundary;
    }
}
