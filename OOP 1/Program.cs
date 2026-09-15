using static OOP_1.Program;

namespace OOP_1
{
    internal class Program
    {
        #region Delivery address struct
        public struct DeliveryAddress
        {
            public string city;
            public string street;
            public int BuildingNumber;
            public DeliveryAddress(string city, string رstreet, int BuildingNumber)
            {
                this.city = city;
                this.street = street;
                this.BuildingNumber = BuildingNumber;
            }
            public string GetFullAddress()
            {
                return $"City: {city}, Street: {street}, Building Number: {BuildingNumber}";
            }
        }
        #endregion

        #region Shipment struct
        public struct Shipment
        {
            private string _trackingCode;
            private string _description;
            private double _weight;
            private double _deliveryFee;
            public DeliveryAddress Destination { get; set; }
            public string TrackingCode
            {
                get { return _trackingCode; }
                private set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        _trackingCode = value;
                }
            }

            public string Description
            {
                get { return _description; }
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                        _description = value;
                }
            }

            public double Weight
            {
                get { return _weight; }
                set
                {
                    if (value > 0)
                        _weight = value;
                }
            }

            public double DeliveryFee
            {
                get { return _deliveryFee; }
                private set
                {
                    if (value > 0)
                        DeliveryFee = value;
                }
            }

            public double EstimatedCost
            {
                get { return DeliveryFee + (Weight * 5); }
            }
            public Shipment(string trackingCode)
            {
                this.TrackingCode = trackingCode;
                Description = "Unknown";
                Weight = 1;
                DeliveryFee = 50;
                Destination = new DeliveryAddress("Unknown", "Unknown", 0);
            }
            public Shipment(string trackingCode, string description, double weight, double deliveryFee, DeliveryAddress destination)
            {
                this.TrackingCode = trackingCode;
                Description = "Unknown";
                Weight = 1;
                DeliveryFee = 50;
                Destination = destination;
            }
            public void UpdateDeliveryFee(double newFee)
            {
                if (newFee > 0)
                    _deliveryFee = newFee;
            }
            public void PrintShipment()
            {
                Console.WriteLine($"Tracking code: {TrackingCode}");
                Console.WriteLine($"Description: {Description}");
                Console.WriteLine($"Weight: {Weight} KG");
                Console.WriteLine($"Delivery Fee: {DeliveryFee}");
                Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
                Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            }
        }
        #endregion

        #region Delivery center class

        public class DeliveryCenter
        {
            private Shipment[] shipments;
            public DeliveryCenter()
            {
                shipments = new Shipment[10];
            }

            public Shipment this[int index]
            {
                get
                {
                    if (index >= 0 && index < shipments.Length)
                        return shipments[index];

                    return default;
                }
                set
                {
                    if (index >= 0 && index < shipments.Length)
                        shipments[index] = value;
                }
            }

        }
        #endregion


        static void Main(string[] args)
        {
            #region Theoretical questions
            //1] a) What happens when a DeliveryAddress variable is copied into another variable and the copy is modified?

            // Since that struct is a value type, it creates a new copy of struct without affecting the original struct.

            //---------------

            // b) What happens when a Customer variable is copied into another variable and one variable modifies the object 

            // Since that class is a reference type, it creates a new reference to the same customer object, so any changes in the new referece will affect the base customer object.

            //------------------------------

            //2] a) Identify at least three problems with this design from an encapsulation perspective.

            // 1. The feilds are all public, that allows any one to enter values to fields.
            // 2. There is no validation for fields, that allows unvalid values to be entered.
            // 3. The object can allow wrong data and negative values.

            //---------------

            // b) How can private fields and public properties improve this design? 

            // 1. By making private feilds.
            // 2. Add properties to access private feilds.
            // 3. Add validation to properties to ensure that data is valid.
            #endregion

            #region Entering shipments
            DeliveryCenter center = new DeliveryCenter();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Shipment {i + 1} Data");

                Console.Write("Enter tracking code: ");
                string trackingCode = Console.ReadLine();

                Console.Write("Enter description: ");
                string description = Console.ReadLine();

                Console.Write("Enter weight: ");
                double weight = double.Parse(Console.ReadLine());

                Console.Write("Enter delivery fee: ");
                double deliveryFee = double.Parse(Console.ReadLine());

                Console.Write("Enter city: ");
                string city = Console.ReadLine();

                Console.Write("Enter street: ");
                string street = Console.ReadLine();

                Console.Write("Enter building Number: ");
                int buldingNum = int.Parse(Console.ReadLine());

                DeliveryAddress address = new DeliveryAddress(city, street, buldingNum);

                Shipment shipment = new Shipment(trackingCode, description, weight, deliveryFee, address);

                DeliveryAddress address1 = new DeliveryAddress("Maadi", "Road 9", 12);
                DeliveryAddress copiedAdd = address1;

                Console.WriteLine($"Original Address: {address1.GetFullAddress()}");
                Console.WriteLine($"Copied Address: {copiedAdd.GetFullAddress()}");

                copiedAdd = new DeliveryAddress("Heliopolis", "El Hegaz Street", 25);

                Console.WriteLine($"Original Address after change: {address1.GetFullAddress()}");
                Console.WriteLine($"Copied Address after change: {copiedAdd.GetFullAddress()}");
            #endregion
            }
        }
    }
}