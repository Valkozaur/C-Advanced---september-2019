namespace _8.PetClinics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var pets = new List<Pet>();
            var clinics = new List<Clinic>();

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var splitCommand = Console.ReadLine()
                    .Split(" ");

                if (splitCommand[0] == "Create")
                {
                    switch (splitCommand[1])
                    {
                        case "Pet":
                            {
                                var petInfo = splitCommand
                                    .Skip(2)
                                    .ToArray();

                                var name = petInfo[0];
                                var age = int.Parse(petInfo[1]);
                                var kind = petInfo[2];

                                var pet = new Pet(name, age, kind);
                                pets.Add(pet);
                                break;
                            }
                        case "Clinic":
                            {
                                var clinicInfo = splitCommand
                                    .Skip(2)
                                    .ToArray();

                                var clinicName = clinicInfo[0];
                                var numberOfRooms = int.Parse(clinicInfo[1]);

                                Clinic clinic = null;
                                try
                                {
                                    clinic = new Clinic(clinicName, numberOfRooms);
                                }
                                catch (InvalidOperationException e)
                                {
                                    Console.WriteLine(e.Message);
                                    continue;
                                }

                                clinics.Add(clinic);
                                break;
                            }
                    }
                }

                var clinicNeeded = splitCommand[1];
                var clinicFound = clinics.FirstOrDefault(x => x.Name == clinicNeeded);

                switch (splitCommand[0])
                {
                    case "Add":
                        {
                            var patientName = splitCommand[1];
                            clinicNeeded = splitCommand[2];
                            clinicFound = clinics.FirstOrDefault(x => x.Name == clinicNeeded);
                            var patient = pets.FirstOrDefault(x => x.Name == patientName);
                            Console.WriteLine(clinicFound.AddPet(patient));
                            break;
                        }
                    case "Release":
                        {
                            Console.WriteLine(clinicFound.Release());
                            break;
                        }
                    case "HasEmptyRooms":
                        {
                            Console.WriteLine(clinicFound.HasEmptyRooms());
                            break;
                        }
                    case "Print":
                        {
                            if (splitCommand.Length == 2)
                            {
                                Console.WriteLine(clinicFound.Print());
                            }
                            else
                            {
                                var roomNumber = int.Parse(splitCommand[2]);
                                Console.WriteLine(clinicFound.PrintRoom(roomNumber));
                            }
                            break;
                        }
                }
            }
        }
    }
}
