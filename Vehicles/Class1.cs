namespace Vehicles
{
    public abstract class Vehicle
    {
        public virtual void LoadPassenger() { }
    }

    public interface IPassengerCarrier
    {
        public void LoadPassenger() { }
    }

    public interface IHeavyLoadCarrier { }

    public abstract class Car : Vehicle { }

    public abstract class Train : Vehicle { }

    public class Compact: Car, IPassengerCarrier { }
    public class SUV : Car, IPassengerCarrier { }
    public class Pickup : Car, IPassengerCarrier, IHeavyLoadCarrier { }
    public class PassengerTrain : Train, IPassengerCarrier { }
    public class FreightTrain : Train, IHeavyLoadCarrier { }
    public class _424DoubleBogey : Train, IHeavyLoadCarrier { }





}