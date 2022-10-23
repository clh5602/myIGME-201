using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Unit2TestQ910
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Unit 2 Test #'s 9 and 10
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: Create instances of the derived classes, and use each instance to call the same method. 
        // Restrictions: None
        static void Main(string[] args)
        {
            Me me = new Me();
            Friend friend = new Friend("John", 4);

            Perform(me);
            Perform(friend);

        }

        // Method: Perform
        // Purpose: Calls methods based on the type of object passed to perform music.
        // Restrictions: This method demonstrates polymorphism poorly, and I'd like to explain why:
        //               The BandMember abstract class would be better fit as an interface. This would allow me to cast the obj
        //               parameter as a BandMember interface. Calling .SetUpInstrument() and .Play() from the casted obj
        //               would demonstrate polymorphism, as the methods would do different things based on the original obj's type.
        static void Perform(object obj)
        {
            Type type = obj.GetType();

            if (type == typeof(Me))
            {
                Me me = (Me)obj;
                me.SetUpInstrument();
                me.Play();

            }

            if (type == typeof(Friend))
            {
                Friend friend = (Friend)obj;
                friend.SetUpInstrument();
                friend.Play();
                friend.Freestyle();
                friend.PerformStickTrick();                   

            }
        }
    }

    // Class BandMember
    // Author: Colby Heaton
    // Purpose: Provides a basic framework for the Me and Friend class.
    // Restrictions: None
    public abstract class BandMember
    {
        public string name;
        public string instrument;
        private int yearsExperienced;

        public BandMember() : this("Doe", "Flute", 0) { }

        public BandMember(string name, string instrument, int yearsExperienced)
        {
            this.name = name;
            this.instrument = instrument;
            this.yearsExperienced = yearsExperienced;
        }

        public int YearsExperienced
        {
            get { return yearsExperienced; }
            set { yearsExperienced = value; }
        }

        public abstract void SetUpInstrument();
        public virtual void Play()
        {
            Console.WriteLine("Played a lovely melody from your " + this.instrument);
        }
    }

    // Interface Trombonist
    // Author: Colby Heaton
    // Purpose: Enforces methods unique to trombone players
    // Restrictions: None
    public interface Trombonist
    {
        void MoveSlide(double distance);
    }

    // Interface Percussionist
    // Author: Colby Heaton
    // Purpose: Enforces methods unique to percussion players
    // Restrictions: None
    public interface Percussionist
    {
        void Freestyle();
        void PerformStickTrick();

    }

    // Class Me
    // Author: Colby Heaton
    // Purpose: A class based on me, Colby Heaton. Inherits from BandMember and enforces Trombonist
    // Restrictions: None
    public class Me : BandMember, Trombonist
    {
        public bool trigger;
        public double slidePosition;

        public Me() : base("Colby", "trombone", 9)
        {
            trigger = false;
            slidePosition = 1;
        }

        public void MoveSlide(double distance)
        {
            if (this.slidePosition + distance <= 7 && this.slidePosition + distance >= 1)
            {
                this.slidePosition += distance;
            }
        }

        public override void SetUpInstrument()
        {
            Console.WriteLine("Attached the bell and mouthpiece to the slide!");
        }
    }

    // Class Friend
    // Author: Colby Heaton
    // Purpose: A class based on a friend who happens to be a percussionist.
    // Restrictions: None
    public class Friend : BandMember, Percussionist
    {
        public double volume;
        public double tempo;

        public Friend(string name, int experience) : base(name, "percussion", experience)
        {
            volume = 100;
            tempo = 120;
        }
        public void Freestyle()
        {
            Console.WriteLine(this.name + " performed a rockin\' fill!");
        }

        public void PerformStickTrick()
        {
            Console.WriteLine(this.name + " twirled the drumstick into the air and caught it.");
        }

        public override void SetUpInstrument()
        {
            Console.WriteLine("Attached the snare to the harness.");
        }

        public override void Play()
        {
            Console.WriteLine(this.name + " started a beat.");
        }
    }

}
