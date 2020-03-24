namespace P04_Hospital
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void StartUp()
        {
            var hospital = new Hospital();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] splitInput = command.Split();
                var departmentToFind = splitInput[0];
                var doctorFullName = splitInput[1] + " " + splitInput[2];
                var patientName = splitInput[3];

                hospital.CreateDepartment(departmentToFind);
                hospital.CreateDoctor(doctorFullName);

                var department = hospital.ReturnDepartment(departmentToFind);
                department.AddPatient(new Patient(patientName));

                var doctor = hospital.ReturnDoctor(doctorFullName);
                doctor.AddPatient(patientName);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var args = command.Split();

                if (args.Length == 1)
                {
                    var departmentToFind = args[0];
                    var department = hospital.GetDepartments.FirstOrDefault(x => x.Name == departmentToFind);
                    Console.WriteLine(department.ReturnAllPatients());
                }
                else if (args.Length == 2 && int.TryParse(args[1], out var roomNumber))
                {
                    var departmentToFind = args[0];
                    var department = hospital.GetDepartments.FirstOrDefault(x => x.Name == departmentToFind);

                    var searchedRoom = department.GetRoomByNumber(roomNumber);
                    Console.WriteLine(searchedRoom);
                }
                else
                {
                    var doctorsName = args[0] + " " + args[1];
                    var doctor = hospital.GetDoctors.FirstOrDefault(x => x.Name == doctorsName);

                    Console.WriteLine(doctor);
                }
                command = Console.ReadLine();
            }
        }
    }
}
