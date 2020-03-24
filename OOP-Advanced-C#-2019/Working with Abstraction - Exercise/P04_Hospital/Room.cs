using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        private const int bedsPerRoom = 3;

        private int currentPatientCount;

        public Room()
        {
            this.Beds = new Patient[bedsPerRoom];
            currentPatientCount = 0;
        }

        public Patient[] Beds { get; }

        public bool HasFreeBeds => currentPatientCount < bedsPerRoom;

        public void AddPatient(Patient patient) => Beds[currentPatientCount++] = patient;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var patient in this.Beds.OrderBy(p => p.Name))
            {
                stringBuilder.AppendLine(patient.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
