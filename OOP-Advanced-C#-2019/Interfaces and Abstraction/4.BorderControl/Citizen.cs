namespace _4.BorderControl
{
    public abstract class Citizen : ICitizen
    {
        public string Id { get; set; }

        public bool isFakeId(string id, string lastDigitsOfFakeId)
        {
           if (id.EndsWith(lastDigitsOfFakeId))
            {
                return true;
            }

            return false;
        }
    }
}
