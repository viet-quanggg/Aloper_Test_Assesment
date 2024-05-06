namespace BusinessObject;

public class BookingDepositReceipt
{
    
    
        public const int SaleNameIndex = 15;
        public const int SalePassportIndex = 16;
        public const int SalePhoneIndex = 17;
        public const int SalePositionIndex = 18;

    
        public const int CustomerNameIndex = 22;
        public const int CustomerPassportIndex = 23;
        public const int CustomerPhoneIndex = 24;
        public const int CustomerPlaceIndex = 25;
    
        
        public const int RentalAddressIndex = 30;
        public const int RoomCodeIndex = 31;
        public const int LeaseTermIndex = 31;
        public const int RentalFeeIndex = 32;
        public const int CheckinDateIndex = 32;
        public const int DepositAmountIndex = 33;
        public const int AdditionDepositAmountIndex = 34;
        public const int AdditionDepositDeadlineIndex = 36;
        public const int RewardProgramIndex = 37;
    
    

        public const int ElectricityIndex = 40;
        public const int WaterIndex = 40;
        public const int ParkingIndex = 41;
        public const int ManagementIndex = 41;
        public const int OthersIndex = 42;
    

        public const int CustomerSignature = 61;
        public const int SaleSignature = 63;
    

    
    public DateTime ReceiptDate { get; set; }
    public string CustomerSign { get; set; }
    public string SaleSign { get; set; }
    

        public string SaleFullName { get; set; }
        public string SalePassportNumber { get; set; }
        public string SalePhoneNumber { get; set; }
        public string SalePosition { get; set; }


        public string CustomerFullName { get; set; }
        public string CustomerPassportNumber { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerPlaceOfResidence { get; set; }
    


        public string Address { get; set; }
        public string RoomCode { get; set; }
        public string LeaseTerm { get; set; }
        public string RentalFee { get; set; }
        public DateTime CheckinDate { get; set; }
        public string BookingDepositAmount { get; set; }
        public string AdditionalDepositAmount { get; set; }
        public DateTime AdditionalDepositPaymentDeadline { get; set; }
        public string RewardProgram { get; set; }


        public string Electricity { get; set; }
        public string Water { get; set; }
        public string Parking { get; set; }
        public string ManagementFee { get; set; }
        public string Others { get; set; }

   
}