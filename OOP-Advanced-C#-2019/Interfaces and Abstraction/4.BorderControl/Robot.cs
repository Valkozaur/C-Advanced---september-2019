namespace _4.BorderControl
{
    public class Robot : Citizen, ICitizen
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
    }
}
