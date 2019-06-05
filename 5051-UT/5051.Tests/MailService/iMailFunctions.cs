namespace _5051.Tests.MailService
{
    interface iMailFunctions
    {
        string GenerateCSVFileName(string fileTitle);
        string SendEmailService(string title, string testResult, string emailAddress);
        bool SendEmailServiceV2(string title, string testResult, string emailAddress, string fileLocation);
        string BuildHTMLBody(string testTitle, string testResult,int count);
        string BuildHTMLBodyV2(string testTitle, string testResult, int count,string sheetUrl);
        string BuildHTMLBodyV3(string testTitle, string testResult, int count, string sheetUrl, string sourceSheetUrl);
        string SendEmailUsingGmailService(string title, string testResult, string emailAddress);
    }
}
