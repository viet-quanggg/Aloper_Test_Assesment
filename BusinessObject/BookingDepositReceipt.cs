namespace BusinessObject;

public class BookingDepositReceipt
{
    

    
    public DateTime ReceiptDate { get; set; }
    

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