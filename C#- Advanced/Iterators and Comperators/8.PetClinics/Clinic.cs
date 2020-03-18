namespace _8.PetClinics
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Clinic : IEnumerable<Pet>
    {
        private Dictionary<int, Pet> rooms;
        private int roomsCount;

        public Clinic(string name, int numberOfRooms)
        {

            if (numberOfRooms % 2 != 0)
            {
                this.Name = name;
                this.rooms = new Dictionary<int, Pet>();
                this.roomsCount = numberOfRooms;
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public string Name { get; set; }

        public bool AddPet(Pet pet)
        {
            if (rooms.Count == this.roomsCount)
            {
                return false;
            }

            var middleRoom = this.roomsCount / 2 + 1;


            for (var i = 1; i <= this.roomsCount; i++)
            {
                if (!this.rooms.ContainsKey(middleRoom))
                {
                    this.rooms[middleRoom] = pet;
                    return true;
                }

                if (!this.rooms.ContainsKey(middleRoom - i))
                {
                    this.rooms[middleRoom - i] = pet;
                    return true;
                }
                else if (!this.rooms.ContainsKey(middleRoom + i))
                {
                    this.rooms[middleRoom + i] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            if (this.rooms.Count == 0)
            {
                return false;
            }

            var middleRoom = this.roomsCount / 2 + 1;
            for (int i = middleRoom; i <= this.roomsCount; i++)
            {
                if (this.rooms.ContainsKey(i))
                {
                    this.rooms.Remove(i);
                    return true;
                }
            }

            for (var i = middleRoom - 1; i > 0; i--)
            {
                if (this.rooms.ContainsKey(i))
                {
                    this.rooms[i] = null;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms() => this.rooms.Count < this.roomsCount;

        public string Print()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 1; i <= this.roomsCount; i++)
            {
                if (!this.rooms.ContainsKey(i))
                {
                    stringBuilder.AppendLine("Room empty");
                }
                else
                {
                    stringBuilder.AppendLine(this.rooms[i].ToString());
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string PrintRoom(int roomNumber)
        {
            var stringBuilder = new StringBuilder();
            if (!this.rooms.ContainsKey(roomNumber))
            {
                stringBuilder.AppendLine("Room empty");
            }
            else
            {
                stringBuilder.AppendLine(rooms[roomNumber].ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            foreach (var (number, pet) in this.rooms)
            {
                yield return pet;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}