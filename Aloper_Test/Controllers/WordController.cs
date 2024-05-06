using System.Globalization;
using BusinessObject;
using DataAccess.Helper;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using static BusinessObject.BookingDepositReceipt;
using Path = System.IO.Path;


namespace Aloper_Test.Controllers;

[ApiController]
[Route("api/word")]
public class WordController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> ReadContactFromDoc([FromBody] BookingDepositReceipt depositReceipt, IFormFile formFile)
    {
        
    // var files = Request.Form.Files;
    // if (!files.Any())
    // {
    //     return BadRequest("No file uploaded.");
    // }
    //
    // var file = files.FirstOrDefault();
    // if (file == null)
    // {
    //     return BadRequest("No file uploaded.");
    // }

    string fileName = await FileHelper.Upload(formFile);
    string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

    try
    {
        var word = WordprocessingDocument.Open(path, true);
        var paragraphs = word.MainDocumentPart.Document.Body.Descendants<Paragraph>().ToList();

        var receipt = new BookingDepositReceipt();

        // Validation for required paragraphs
        if (paragraphs.Count != null)
        {
            receipt.SaleFullName = paragraphs[15].InnerText.Split(":")[1].Trim();
        receipt.SalePassportNumber = paragraphs[16].InnerText.Split(":")[1].Trim();
        receipt.SalePhoneNumber = paragraphs[17].InnerText.Split(":")[1].Trim();
        receipt.SalePosition = paragraphs[18].InnerText.Split(":")[1].Trim();

        receipt.CustomerFullName = paragraphs[22].InnerText.Split(":")[1].Trim();
        receipt.CustomerPassportNumber = paragraphs[23].InnerText.Split(":")[1].Trim();
        receipt.CustomerPhoneNumber = paragraphs[24].InnerText.Split(":")[1].Trim();
        receipt.CustomerPlaceOfResidence = paragraphs[25].InnerText.Split(":")[1].Trim();

        receipt.Address = paragraphs[30].InnerText.Split(":")[1].Trim();
        string[] roomLease = FileHelper.GetValuesAfterColon(paragraphs[31].InnerText);
        receipt.RoomCode = roomLease[0];
        receipt.LeaseTerm = roomLease[6] + " " + roomLease[7];
        string[] RenCheckin = FileHelper.GetValuesAfterColon(paragraphs[32].InnerText);
        receipt.RentalFee = RenCheckin[0];
        receipt.CheckinDate = DateTime.ParseExact(RenCheckin[6], "dd/MM/yyyy",
            CultureInfo.InvariantCulture);
        
        receipt.BookingDepositAmount = paragraphs[33].InnerText.Split(":")[1].Trim();
        receipt.AdditionalDepositAmount = paragraphs[34].InnerText.Split(":")[1].Trim();
        receipt.AdditionalDepositPaymentDeadline = DateTime.ParseExact(
                paragraphs[36].InnerText, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        receipt.RewardProgram = paragraphs[37].InnerText.Split(":")[1].Trim();

        string[] ElecWate = FileHelper.GetValuesAfterColon(paragraphs[44].InnerText);
        receipt.Electricity = ElecWate[0];
        receipt.Water = ElecWate[1];
        string[] ParkMana = FileHelper.GetValuesAfterColon(paragraphs[45].InnerText);
        receipt.Parking = ParkMana[0]; 
        receipt.ManagementFee = ParkMana[1];
        receipt.Others = paragraphs[46].InnerText.Split(":")[1].Trim();

        receipt.CustomerSign = paragraphs[67].InnerText;
        receipt.SaleSign = paragraphs[70].InnerText;
        }
        else
        {
            return BadRequest("Document format is invalid or missing required information.");
        }

        return Ok(receipt);
    }
    catch (Exception ex)
    {
        return BadRequest($"Error while reading document: Document is not in the correct format!");
    }
    }
}