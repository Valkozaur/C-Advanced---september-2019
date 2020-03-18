namespace _5._Date_Modifier
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DateModifie
    {
        private DateTime firstDate;
        private DateTime secondDate;

        public DateTime FirstDate { get; set; }
        
        public DateTime SecondDate { get; set; }

        public int GetDaysDifference()
        {
            return Math.Abs((this.FirstDate.Date - this.SecondDate.Date).Days);
        }
    }
}
