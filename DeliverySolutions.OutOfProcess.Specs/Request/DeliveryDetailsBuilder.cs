namespace DeliverySolutions.OutOfProcess.Specs.Request
{
    public class DeliveryDetailsBuilder
    {
        private int _addressId = 1234;
        private string _countryCode = "GB";
        private string _countryFormat = "GB";
        private string _line1 = "123 Hampstead Road ";
        private string _line2 = "London";
        private string _line3;
        private string _line4;
        private string _line5;
        private string _line6;
        private string _line7;
        private string _line8;
        private string _line9;
        private string _postalCode = "W1 1AA";

        public static DeliveryDetailsBuilder ADeliveryDetails => new DeliveryDetailsBuilder();

        public DeliveryDetails Build()
        {
            return new DeliveryDetails
            {
                AddressId = _addressId,
                CountryCode = _countryCode,
                CountryFormat = _countryFormat,
                Line1 = _line1,
                Line2 = _line2,
                Line3 = _line3,
                Line4 = _line4,
                Line5 = _line5,
                Line6 = _line6,
                Line7 = _line7,
                Line8 = _line8,
                Line9 = _line9,
                PostalCode = _postalCode
            };
        }
    }
}