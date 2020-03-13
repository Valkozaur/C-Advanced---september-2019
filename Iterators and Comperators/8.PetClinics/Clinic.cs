using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace _8.PetClinics
{
    public class Clinic : IEnumerable<Pet>
    {
        private int patientsCount;
        public Clinic(string name, int numberOfRooms)
        {

            if (numberOfRooms % 2 != 0)
            {
                this.Name = name;
                this.Rooms = new Pet[numberOfRooms];
                patientsCount = 0;
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public string Name { get; set; }

        public Pet[] Rooms { get; set; }

        public bool AddPet(Pet pet)
        {
            if (patientsCount == Rooms.Length)
            {
                return false;
            }

            var middleRoom = Rooms.Length / 2;

            var roomsToTheLeft = 1;
            var roomsToTheRight = 1;

            for (int i = 0; i < Rooms.Length; i++)
            {
                if(Rooms[middleRoom] == null)
                {
                    Rooms[middleRoom] = pet;
                    patientsCount++;
                    return true;
                }

                if (patientsCount % 2 != 0)
                {
                    Rooms[middleRoom - roomsToTheLeft] = pet;
                    roomsToTheLeft++;
                    patientsCount++;
                    return true;
                }
                else
                {
                    Rooms[middleRoom + roomsToTheRight] = pet;
                    roomsToTheRight++;
                    patientsCount++;
                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            if (patientsCount == 0)
            {
                return false;
            }

            var middleRoom = Rooms.Length / 2;
            for (int i = middleRoom; i < Rooms.Length; i++)
            {
                if (Rooms[i] != null)
                {
                    Rooms[i] = null;
                    patientsCount--;
                    return true;
                }
            }

            for (int i = middleRoom; i >= 0; i--)
            {
                if (Rooms[i] != null)
                {
                    Rooms[i] = null;
                    patientsCount--;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms() => patientsCount < Rooms.Length;

        public string PrintRoom(int roomNumber)
        {
            return Rooms[roomNumber].ToString();
        }
        public IEnumerator<Pet> GetEnumerator()
        {
            foreach (var pet in Rooms)
            {
                yield return pet;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}