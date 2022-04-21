using System;

class class5
{
    static void Main()
    {
        var numberOfPets = 0;
        var pets = new Pet[10];

        while (true)
        {
            Console.Write("A)dd D)elete L)ist pets:");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "A":
                case "a":
                    {
                        Console.Write("Name :");
                        var name = Console.ReadLine();

                        Console.Write("Type of pet :");
                        var typeOfPet = Console.ReadLine();

                        // TODO: Always add the pet at the end of the array

                        pets[numberOfPets].Name = name;
                        pets[numberOfPets].TypeOfPet = typeOfPet;
                        numberOfPets++;
                        break;
                    }

                case "D":
                case "d":
                    {
                        if (numberOfPets == 0)
                        {
                            Console.WriteLine("No pets");
                            break;
                        }

                        for (var index = 0; index < numberOfPets; index++)
                        {
                            Console.WriteLine("{0}. {1,-10} {2}", index + 1, pets[index].Name, pets[index].TypeOfPet);
                        }

                        Console.Write("Which pet to remove (1-{0})", numberOfPets);

                        var petNumberToDelete = Console.ReadLine();
                        var indexToDelete = int.Parse(petNumberToDelete);

                        // Squish the array from index to the end
                        for (int i = 0; i < numberOfPets; i++)
                        {
                            if (i >= indexToDelete)
                            {
                                pets[i].Name = pets[i + 1].Name;
                                pets[i].TypeOfPet = pets[i + 1].TypeOfPet;
                            }
                        }

                        //for (var index = indexToDelete - 1; index < numberOfPets; index++)
                        ///{
                            // TODO: Just copy the pet from the next index into the current index
                        ///}

                        // We have one less pet
                        numberOfPets--;

                        break;
                    }

                case "L":
                case "l":
                    {
                        if (numberOfPets == 0)
                        {
                            Console.WriteLine("No pets");
                        }

                        for (int index = 0; index < numberOfPets; index++)
                        {
                            Console.WriteLine("{0}. {1,-10} {2}", index + 1, pets[index].Name, pets[index].TypeOfPet);
                        }

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option [{0}]", choice);
                        break;
                    }
            }
        }
    }
}