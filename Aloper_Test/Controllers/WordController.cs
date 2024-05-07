using BusinessObject;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Aspose.Words;
using DocumentFormat.OpenXml;
using Microsoft.Office.Interop.Word;
using Document = Microsoft.Office.Interop.Word.Document;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;


namespace Aloper_Test.Controllers;

[ApiController]
[Route("api/word")]
public class WordController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> ReadContactFromDoc([FromBody] BookingDepositReceipt depositReceipt)
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

                var spn = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("............................................"));
                if (spn != null)
                {
                    spn.Text = spn.Text.Replace("............................................", receipt.SalePassportNumber);
                }
                
                var sphn = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("............................................................................"));
                if (sphn != null)
                {
                    sphn.Text = sphn.Text.Replace("............................................................................", receipt.SalePhoneNumber);
                }
                
                var position = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("............................................................................................."));
                if (position != null)
                {
                    position.Text = position.Text.Replace(".............................................................................................", receipt.SalePosition);
                }
                
                var cpn = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("..........................................."));
                if (cpn != null)
                {
                    cpn.Text = cpn.Text.Replace("...........................................", receipt.CustomerPassportNumber);
                }
                
                var cfn = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("........................................................................................"));
                if (cfn != null)
                {
                    cfn.Text = cfn.Text.Replace("........................................................................................", receipt.CustomerFullName);
                }
                
                var cphn = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("............................................................................"));
                if (cphn != null)
                {
                    cphn.Text = cphn.Text.Replace("............................................................................", receipt.CustomerPhoneNumber);
                }
                
                var place = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains(".............................................................\r\n.............................................................................................................................\r\n"));
                if (place != null)
                {
                    place.Text = place.Text.Replace(".............................................................\r\n.............................................................................................................................\r\n", receipt.CustomerPlaceOfResidence);
                }
                
                var address = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("................................................................................................."));
                if (address != null)
                {
                    address.Text = address.Text.Replace(".................................................................................................", receipt.Address);
                }
                
                var roomCode = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("........................"));
                if (roomCode != null)
                {
                    roomCode.Text = roomCode.Text.Replace("........................", receipt.RoomCode);
                }
                
                var leaseTerm = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("...................."));
                if (leaseTerm != null)
                {
                    leaseTerm.Text = leaseTerm.Text.Replace("....................", receipt.LeaseTerm);
                }
                
                var rentalFee = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("............................"));
                if (rentalFee != null)
                {
                    rentalFee.Text = rentalFee.Text.Replace("............................", receipt.RentalFee);
                }
                
                var checkin = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("..............."));
                if (checkin != null)
                {
                    checkin.Text = checkin.Text.Replace("...............", receipt.CheckinDate.ToLongDateString());
                }
                
                var depositAmount = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("................................................."));
                if (depositAmount != null)
                {
                    depositAmount.Text = depositAmount.Text.Replace(".................................................", receipt.BookingDepositAmount);
                }
                
                var adddepositAmount = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("................................................."));
                if (adddepositAmount != null)
                {
                    adddepositAmount.Text = depositAmount.Text.Replace(".................................................", receipt.AdditionalDepositAmount);
                }
                
                var adddepositAmountdl = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("............"));
                if (adddepositAmountdl != null)
                {
                    adddepositAmountdl.Text = adddepositAmountdl.Text.Replace("............", receipt.AdditionalDepositPaymentDeadline.ToLongDateString());
                }
                
                var elec = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("..............................."));
                if (elec != null)
                {
                    elec.Text = elec.Text.Replace("...............................", receipt.Electricity);
                }
                
                var wa = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("........................................."));
                if (wa != null)
                {
                    wa.Text = wa.Text.Replace(".........................................", receipt.Water);
                }
                
                var pa = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("................................"));
                if (pa != null)
                {
                    pa.Text = pa.Text.Replace("................................", receipt.Parking);
                }
                
                var mana = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("....................."));
                if (mana != null)
                {
                    mana.Text = mana.Text.Replace(".....................", receipt.ManagementFee);
                }
                
                var o = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("..............................................................................."));
                if (o != null)
                {
                    o.Text = o.Text.Replace("...............................................................................", receipt.Others);
                }
                
                var re = reportDocument.MainDocumentPart.Document.Descendants<Text>().FirstOrDefault(c =>
                    c.Text.Contains("...................................."));
                if (re != null)
                {
                    re.Text = re.Text.Replace("....................................", receipt.RewardProgram);
                }
                
                
                reportDocument.Save();
                reportDocument.Close();
            }

            files = System.IO.File.ReadAllBytes(newPath);

            

            try
            {
                Aspose.Words.Document doc = new Aspose.Words.Document(newPath);
                string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "PDFExports",
                    $"{Guid.NewGuid()}Export.pdf");

                doc.Save(pdfPath, SaveFormat.Pdf);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            
            
            return File(
                fileContents: files,
                contentType: "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                fileDownloadName: "export.docx"
            );
            
    }
}

