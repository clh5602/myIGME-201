using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaton_Unit2TestQ4567
{
    // Class Program
    // Author: Colby Heaton
    // Purpose: Unit 2 Test Questions 4, 5, 6, and 7.
    // Restrictions: None
    internal static class Program
    {
        // Method: Main
        // Purpose: Create a Tardis and a PhoneBooth, and use them to call a method.
        // Restrictions: None
        static void Main(string[] args)
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            UsePhone(tardis);
            UsePhone(phoneBooth);
        }

        // Method: UsePhone
        // Purpose: Converts parameter into PhoneInterface and calls two methods using the parameter.
        //          Also calls different methods based on the type of the parameter.
        // Restrictions: None
        static void UsePhone(object obj)
        {
            Type type = obj.GetType();
            if (type == typeof(Tardis))
            {
                Tardis tardis = (Tardis)obj;
                tardis.TimeTravel();

            }
            if (type == typeof(PhoneBooth))
            {
                PhoneBooth booth = (PhoneBooth)obj;
                booth.OpenDoor();

            }
            PhoneInterface phone = (PhoneInterface)obj;
            phone.MakeCall();
            phone.HangUp();
        }
    }

    // Class Phone
    // Author: Colby Heaton
    // Purpose: Inherited by PushButtonPhone and RotaryPhone
    // Restrictions: None
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public abstract void Connect();
        public abstract void Disconnect();
    }

    // Interface PhoneInterface
    // Author: Colby Heaton
    // Purpose: Implemented by PushButtonPhone and RotaryPhone
    // Restrictions: None
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    // Class RotaryPhone
    // Author: Colby Heaton
    // Purpose: Inherited by Tardis
    // Restrictions: None
    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer() { }
        public void MakeCall() { }
        public void HangUp() { }
        public override void Connect() { }
        public override void Disconnect() { }

    }

    // Class PushButtonPhone
    // Author: Colby Heaton
    // Purpose: Inherited by PhoneBooth
    // Restrictions: None
    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer() { }
        public void MakeCall() { }
        public void HangUp() { }
        public override void Connect() { }
        public override void Disconnect() { }

    }

    // Class Tardis
    // Author: Colby Heaton
    // Purpose: Used in Main
    // Restrictions: None
    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        public byte WhichDrWho
        {
            get { return this.whichDrWho; }
        }

        public string FemaleSideKick
        {
            get { return this.femaleSideKick; }
        }

        // Methods: Operator Overrides
        // Purpose: use the whichDrWho private variable to compare multiple Tardis objects.
        //          A value of whichDrWho == 10 will be greater than all other values in comparisons.
        // Restrictions: None
        public static bool operator ==(Tardis a, Tardis b)
        {
            return a.whichDrWho == b.whichDrWho;
        }
        public static bool operator !=(Tardis a, Tardis b)
        {
            return a.whichDrWho != b.whichDrWho;
        }

        public static bool operator <(Tardis a, Tardis b)
        {
            if (a.whichDrWho == 10)
            {
                return false;
            }
            return a.whichDrWho < b.whichDrWho;
        }
        public static bool operator >(Tardis a, Tardis b)
        {
            if (b.whichDrWho == 10)
            {
                return false;
            }
            return a.whichDrWho > b.whichDrWho;
        }

        public static bool operator <=(Tardis a, Tardis b)
        {
            if (a.whichDrWho == 10 && b.whichDrWho != 10)
            {
                return false;
            }
            return a.whichDrWho <= b.whichDrWho;
        }
        public static bool operator >=(Tardis a, Tardis b)
        {
            if (b.whichDrWho == 10 && a.whichDrWho != 10)
            {
                return false;
            }
            return a.whichDrWho >= b.whichDrWho;
        }

        public void TimeTravel() { }
    }

    // Class PhoneBooth
    // Author: Colby Heaton
    // Purpose: Used in Main
    // Restrictions: None
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor() { }
        public void CloseDoor() { }
    }
}
