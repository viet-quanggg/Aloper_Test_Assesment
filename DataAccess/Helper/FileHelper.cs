using Microsoft.AspNetCore.Http;

namespace DataAccess.Helper;

public class FileHelper
{
     public static async Task<string> Upload(IFormFile file)
     {
          var filename = $"{Guid.NewGuid()}__{file.FileName}";
          var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
          string fullPath = "Uploads/" + filename;
          using (var stream = File.Create(fullPath))
          {
               await file.CopyToAsync(stream); 
          }

          return filename;
     }

     public static string GetValueAfterColon(string input)
     {
          int colonIndex = input.IndexOf(':');

          if (colonIndex != -1 && colonIndex + 1 < input.Length)
          {
               string dataAfterColon = input.Substring(colonIndex + 1).Trim();

               return dataAfterColon;
          }
          else
          {
               throw new ArgumentException("Colon not found in the input string.");
          }
     }
     
     public static string[] GetValuesAfterColon(string input)
     {
          // Find the index of ":"
          int colonIndex = input.IndexOf(':');

          if (colonIndex != -1 && colonIndex + 1 < input.Length)
          {
               // Extract the data after ":"
               string dataAfterColon = input.Substring(colonIndex + 1).Trim();

               // Split the data by space
               string[] parts = dataAfterColon.Split(new [] { ' ', '\u00a0' }, StringSplitOptions.RemoveEmptyEntries);

               return parts;
          }
          else
          {
               throw new ArgumentException("Colon not found in the input string.");
          }
     }
}