using System.Linq;

namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Hospital
    {
        private List<Department> departments;

        private List<Doctor> doctors;

        public Hospital()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }

        public List<Department> GetDepartments => departments;
        public List<Doctor> GetDoctors => doctors;

        public void CreateDepartment(string name)
        {
            if (!departments.Any(de => de.Name == name))
            {
                var department = new Department(name); 
                this.departments.Add(department);
            }
        }

        public Department ReturnDepartment(string name) => this.departments.FirstOrDefault(de => de.Name == name);

        public void CreateDoctor(string name)
        {
            if (!doctors.Any(x => x.Name == name))
            {
                var doctor = new Doctor(name);
                this.doctors.Add(doctor);
            }
        }

        public Doctor ReturnDoctor(string name) => this.doctors.FirstOrDefault(d => d.Name == name);
    }
}
