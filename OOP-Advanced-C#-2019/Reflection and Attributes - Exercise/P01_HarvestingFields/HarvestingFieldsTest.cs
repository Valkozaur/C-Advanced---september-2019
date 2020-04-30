namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type harvestingClass = typeof(HarvestingFields);

            Func<FieldInfo, bool> fieldsFunc;
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "HARVEST")
                {
                    break;
                }

                switch (input)
                {
                    case "private":
                        fieldsFunc = f => f.IsPrivate;
                        break;
                    case "protected":
                        fieldsFunc = f => f.IsFamily;
                        break;
                    case "public":
                        fieldsFunc = f => f.IsPublic;
                        break;
                    default:
                        fieldsFunc = x => !x.IsAssembly;
                        break;
                }


                var fields = harvestingClass.GetFields(BindingFlags.Instance | BindingFlags.Static
                    | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(fieldsFunc)
                    .ToArray();

                foreach (var field in fields)
                {
                    var accessModifierToString = field.Attributes.ToString() == "Family"
                        ? "protected" : field.Attributes.ToString();

                    Console.WriteLine($"{accessModifierToString.ToLower()} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
