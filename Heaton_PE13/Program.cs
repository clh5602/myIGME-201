using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_PE13
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: PE_13 - create a pet-simulation application.
    internal class Program
    {
        // Method: Main
        // Purpose: play 50 rounds of randomly adopting pets and spending time with them.
        // Restrictions: None
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    string userInputName = "";
                    string userInputLicense = "";
                    int userInputAge;

                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("Congratulations! You just bought a dog!");

                        Console.Write("Give it a name: ");
                        userInputName = Console.ReadLine();

                        Console.Write("Give it a license ID: ");
                        userInputLicense = Console.ReadLine();

                        do
                        {
                            Console.Write("What is its age?: ");
                        } while (!int.TryParse(Console.ReadLine(), out userInputAge));
                        dog = new Dog(userInputLicense, userInputName, userInputAge);
                        pets.Add(dog);

                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You just bought a cat!");

                        Console.Write("Give it a name: ");
                        userInputName = Console.ReadLine();

                        do
                        {
                            Console.Write("What is its age?: ");
                        } while (!int.TryParse(Console.ReadLine(), out userInputAge));

                        cat = new Cat();
                        cat.Name = userInputName;
                        cat.age = userInputAge;

                        pets.Add(cat);

                    }
                }
                else if (pets.r != 0)
                {
                    thisPet = pets[rand.Next(0, pets.r)];

                    if (thisPet is Cat)
                    {
                        iCat = (ICat)thisPet;
                        switch (rand.Next(0, 4))
                        {
                            case 0:
                                iCat.Eat();
                                break;
                            case 1:
                                iCat.Play();
                                break;
                            case 2:
                                iCat.Purr();
                                break;
                            case 3:
                                iCat.Scratch();
                                break;
                        }
                    } 
                    else
                    {
                        iDog = (IDog)thisPet;
                        switch (rand.Next(0, 5))
                        {
                            case 0:
                                iDog.Eat();
                                break;
                            case 1:
                                iDog.Play();
                                break;
                            case 2:
                                iDog.Bark();
                                break;
                            case 3:
                                iDog.NeedWalk();
                                break;
                            case 4:
                                iDog.GotoVet();
                                break;
                        }
                    }
                }

            }
        }
    }

    // Class Pets
    // Author: Colby Heaton
    // Purpose: Holds a list of every pet you own.
    public class Pets
    {
        List<Pet> petList = new List<Pet>();

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public int r
        {
            get
            {
                return this.petList.Count;
            }
        }

        public void Add(Pet pet)
        {
            petList.Add(pet);
        }

        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }

        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }

    }

    // Class Pets
    // Author: Colby Heaton
    // Purpose: Provides basic functions for the cat and dog classes.
    public abstract class Pet
    {
        private string name;
        public int age;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                this.name = value;
            }
        }

        public abstract void Eat();
        public abstract void Play();
        public abstract void GotoVet();

        public Pet()
        {

        }

        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }


    }

    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }

    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }

    // Class Cat
    // Author: Colby Heaton
    // Purpose: Prints a unique string for various activities.
    public class Cat : Pet, ICat
    {
        public override void Eat()
        {
            Console.WriteLine("A delicious tuna dinner was had by all!");
        }
        public override void Play()
        {
            Console.WriteLine("You played a round of blackjack with " + this.Name);
        }
        public void Purr()
        {
            Console.WriteLine(this.Name + " began to purr contently.");
        }
        public void Scratch()
        {
            Console.WriteLine("It seems you were unable to avoid " + this.Name + "\'s claws today.");
        }
        public override void GotoVet()
        {
            Console.WriteLine("After the fight of your life, you arrived at the vet.");
        }
    }

    // Class Dog
    // Author: Colby Heaton
    // Purpose: Prints a unique string for various activities.
    public class Dog : Pet, IDog
    {
        public string license;
        public override void Eat()
        {
            Console.WriteLine("Show me the beef!");
        }
        public override void Play()
        {
            Console.WriteLine("I wonder if " + this.Name + " knows how to play Tetris?");
        }
        public void Bark()
        {
            Console.WriteLine(this.Name + " began making obnoxious sounds.");
        }
        public void NeedWalk()
        {
            Console.WriteLine(this.Name + " is pacing near the door. They want to go for a walk.");
        }
        public override void GotoVet()
        {
            Console.WriteLine("The vet said that " + this.Name + " is doing just fine.");
        }

        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            this.license = szLicense;
        }
    }
}
