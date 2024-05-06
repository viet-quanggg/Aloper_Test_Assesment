using BusinessObject;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using DocumentFormat.OpenXml;


namespace Aloper_Test.Controllers;

[ApiController]
[Route("api/word")]
public class WordController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> ReadContactFromDoc([FromForm] BookingDepositReceipt depositReceipt)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Exports", "Test Aloper.docx");
        string export = $"Export_{Guid.NewGuid()}.docx";
        string newPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", export);
        byte[] files;
        
        using FileStream streamPath = System.IO.File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            using (var word = WordprocessingDocument.Open(streamPath, true))
            {
                WordprocessingDocument reportDocument = (WordprocessingDocument)word.SaveAs(newPath);
                reportDocument.ChangeDocumentType(WordprocessingDocumentType.Document);
                var paragraphs = reportDocument.MainDocumentPart.Document.Body.Descendants<Paragraph>().ToList();
                 
                var receipt = new BookingDepositReceipt();
                receipt = depositReceipt;
          
                var sfn1 = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("........................................................................................."));
                if (sfn1 != null)
                {
                    sfn1.Text = sfn1.Text.Replace(".........................................................................................", receipt.SaleFullName);
                }

                // var sfn = paragraphs[15].InnerText.Split(":")[1].Trim();
                // sfn.Replace(sfn, receipt.SaleFullName);

                // paragraphs[16].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[16].InnerText.Split(":")[1].Trim(), receipt.SalePassportNumber);
                // paragraphs[17].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[17].InnerText.Split(":")[1].Trim(), receipt.SalePhoneNumber);
                // paragraphs[18].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[18].InnerText.Split(":")[1].Trim(), receipt.SalePosition);
                //
                // paragraphs[22].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[22].InnerText.Split(":")[1].Trim(), receipt.CustomerFullName);
                // paragraphs[23].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[23].InnerText.Split(":")[1].Trim(), receipt.CustomerPassportNumber);
                // paragraphs[24].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[24].InnerText.Split(":")[1].Trim(), receipt.CustomerPhoneNumber);
                // paragraphs[25].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[25].InnerText.Split(":")[1].Trim(), receipt.CustomerPlaceOfResidence);
                // paragraphs[26].InnerText.Replace(paragraphs[26].InnerText, "");
                //
                // paragraphs[30].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[30].InnerText.Split(":")[1].Trim(), receipt.Address);
                // paragraphs[31].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[31].InnerText.Split(":")[1].Trim(), receipt.RoomCode);
                // paragraphs[31].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[31].InnerText.Split(":")[1].Trim(), receipt.LeaseTerm);
                // paragraphs[32].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[32].InnerText.Split(":")[1].Trim(), receipt.RentalFee);
                // // paragraphs[32].InnerText.Split(":")[1].Trim()
                // //     .Replace(paragraphs[32].InnerText.Split(":")[1].Trim(), receipt.CheckinDate.ToString());
                // paragraphs[33].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[33].InnerText.Split(":")[1].Trim(), receipt.BookingDepositAmount);
                // paragraphs[34].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[34].InnerText.Split(":")[1].Trim(), receipt.AdditionalDepositAmount);
                // // paragraphs[35].InnerText.Split(":")[1].Trim()
                // //     .Replace(paragraphs[35].InnerText.Split(":")[1].Trim(), receipt.AdditionalDepositPaymentDeadline);
                // paragraphs[36].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[36].InnerText.Split(":")[1].Trim(), receipt.RewardProgram);
                //
                // paragraphs[43].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[43].InnerText.Split(":")[1].Trim(), receipt.Water);
                // paragraphs[43].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[43].InnerText.Split(":")[1].Trim(), receipt.Electricity);
                // paragraphs[44].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[44].InnerText.Split(":")[1].Trim(), receipt.Parking);
                // paragraphs[44].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[44].InnerText.Split(":")[1].Trim(), receipt.ManagementFee);
                // paragraphs[45].InnerText.Split(":")[1].Trim()
                //     .Replace(paragraphs[45].InnerText.Split(":")[1].Trim(), receipt.Others);
                reportDocument.Save();
                reportDocument.Close();
            }

            files = System.IO.File.ReadAllBytes(newPath);
            return File(
                fileContents: files,
                contentType: "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                fileDownloadName: "export.docx"
            );
            
    }
}

