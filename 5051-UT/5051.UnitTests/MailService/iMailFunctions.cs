namespace _5051.UnitTests.MailService
{
    interface iMailFunctions
    {
        string GenerateCSVFileName(string fileTitle);
        bool SendEmailService(string title, string testResult, string emailAddress);
        bool SendEmailServiceV2(string title, string testResult, string emailAddress, string fileLocation);
        string BuildHTMLBody(string testTitle, string testResult,int count);
        string BuildHTMLBodyV2(string testTitle, string testResult, int count,string sheetUrl);
        string BuildHTMLBodyV3(string testTitle, string testResult, int count, string sheetUrl, string sourceSheetUrl);
    }
}
