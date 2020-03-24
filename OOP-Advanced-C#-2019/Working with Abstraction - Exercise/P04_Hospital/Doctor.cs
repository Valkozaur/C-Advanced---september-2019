using System.Linq;
using System.Text;

namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Doctor
    {
        private List<Patient> patients;

        public Doctor(string name)
        {
            this.Name = name;
            this.patients = new List<Patient>();
        }

        public string Name { get; set; }

        public List<Patient> GetPatients => patients;

        public void AddPatient(string name)
        {
            this.patients.Add(new Patient(name));
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var patient in patients.OrderBy(p =>p.Name))
            {
                stringBuilder.AppendLine(patient.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
