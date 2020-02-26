namespace _5._Date_Modifier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifie dates = new DateModifie();
            dates.FirstDate = DateTime.Parse(firstDate);
            dates.SecondDate = DateTime.Parse(secondDate);

            Console.WriteLine(dates.GetDaysDifference());
        }
    }
}
