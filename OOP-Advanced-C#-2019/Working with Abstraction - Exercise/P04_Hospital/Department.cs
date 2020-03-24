using System.Runtime.Serialization.Formatters;

namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Department
    {
        private const int RoomsPerDepartment = 20;

        private List<Room> rooms;

        public Department(string name)
        {
            this.Name = name;
            this.rooms = new List<Room>();
            this.RoomsDeclaration();
        }

        public string Name { get; set; }

        public void AddPatient(Patient patient)
        {
            var room = this.rooms.FirstOrDefault(r => r.HasFreeBeds);
            if (room != null)
            {
                room.AddPatient(patient);
            }
        }

        public string ReturnAllPatients()
        {
            var stringBuilder = new StringBuilder();
            foreach (var room in this.rooms)
            {
                foreach (var patient in room.Beds)
                {
                    if (patient != null)
                    {
                        stringBuilder.AppendLine(patient.ToString());
                    }
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public Room GetRoomByNumber(int roomNumber) => this.rooms[roomNumber - 1];

        private void RoomsDeclaration()
        {
            for (var currentRoom = 0; currentRoom < RoomsPerDepartment; currentRoom++)
            {
                this.rooms.Add(new Room());
            }
        }
    }
}
