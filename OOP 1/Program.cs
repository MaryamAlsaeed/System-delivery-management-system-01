namespace OOP_1
{
    internal class Program
    {
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
        }
    }
}
