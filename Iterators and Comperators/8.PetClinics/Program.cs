using System.Collections.Generic;
using System.Linq;

namespace _8.PetClinics
{
    using System;
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
                    if (splitCommand[1] == "Pet")
                    {
                        var petInfo = splitCommand
                            .Skip(2)
                            .ToArray();

                        var name = petInfo[0];
                        var age = int.Parse(petInfo[1]);
                        var kind = petInfo[2];

                        var pet = new Pet(name, age, kind);
                        pets.Add(pet);
                    }
                    else if (splitCommand[1] == "Clinic")
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
                    }
                }
                else if (splitCommand[0] == "Add")
                {
                    var patientName = splitCommand[1];
                    var clinicName = splitCommand[2];
                    var patient = pets.FirstOrDefault(x => x.Name == patientName);
                    var clinic = clinics.FirstOrDefault(x => x.Name == clinicName);
                    Console.WriteLine(clinic.AddPet(patient));
                }
                else if(splitCommand[0] == "Release") 
                {
                    var clinicName = splitCommand[1];
                    var clinic = clinics.FirstOrDefault(x => x.Name == clinicName);
                    Console.WriteLine(clinic.Release());
                }
                else if (splitCommand[0] == "HasEmptyRooms")
                {
                    var clinicName = splitCommand[1];
                    var clinic = clinics.FirstOrDefault(x => x.Name == clinicName);
                    Console.WriteLine(clinic.HasEmptyRooms());
                }
                else if (splitCommand[0] == "Print")
                {
                    var clinicName = splitCommand[1];
                    if (splitCommand.Length == 2)
                    {
                        var clinic = clinics.FirstOrDefault(x => x.Name == clinicName);
                        foreach (var patient in clinic)
                        {
                            if (patient == null)
                            {
                                Console.WriteLine("Room empty");
                            }
                            else
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                    else
                    {
                        var roomNumber = int.Parse(splitCommand[2]);
                        var clinic = clinics.FirstOrDefault(x => x.Name == clinicName);
                        if (clinic.Rooms[roomNumber - 1] == null)
                        {
                            Console.WriteLine("Room empty");
                        }
                        else
                        {
                            Console.WriteLine(clinic.Rooms[roomNumber - 1]);
                        }
                    }
                }
            }
        }
    }
}
