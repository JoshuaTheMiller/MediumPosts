<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <NuGetReference>AWSSDK.SimpleEmail</NuGetReference>
  <Namespace>Amazon</Namespace>
  <Namespace>Amazon.SimpleEmail</Namespace>
  <Namespace>Amazon.SimpleEmail.Model</Namespace>
  <Namespace>System.Configuration</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="senderFriendlyName" value="" />
          <add key="senderAddress" value="" />
          <add key="recieverAddress" value="" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

async Task Main()
{
	// Amazon SES vs SendGrid: https://easysendy.com/blog/amazon-ses-vs-sendgrid/	
	// Using tutorial from: https://docs.aws.amazon.com/ses/latest/DeveloperGuide/send-using-sdk-net.html
	// To learn more about testing email sending, check out this link: https://docs.aws.amazon.com/ses/latest/DeveloperGuide/mailbox-simulator.html
	
	// Fill out all of the values before the SendEmailAsync for this to work.
	// The SendEmailAsync contains the meat of the sending logic (it's pretty small, actually).
	
	var senderFriendlyName = ConfigurationManager.AppSettings["SenderFriendlyName"];
	var senderAddress = ConfigurationManager.AppSettings["SenderAddress"];

	// The verified person you want to send an email to
	var recieverAddress = ConfigurationManager.AppSettings["RecieverAddress"];

	// The access and secrets key of a user that has the ability to SendEmail.
	// By going this route, you do not need a shared credentials file.
	var accessKey = Util.GetPassword("Amazon.SES.EmailSender.AccessKey");
	var secretsKey = Util.GetPassword("Amazon.SES.EmailSender.SecretKey");

	// Replace USWest2 with the AWS Region you're using for Amazon SES.
	// Acceptable values are EUWest1, USEast1, and USWest2.
	RegionEndpoint regionEndpoint = RegionEndpoint.USEast1;
	
	await SendEmailAsync(senderFriendlyName, senderAddress, recieverAddress, accessKey, secretsKey, regionEndpoint);	
}

async Task SendEmailAsync(string senderFriendlyName, string senderAddress, string recieverAddress, string accessKey, string secretsKey, RegionEndpoint regionEndpoint)
{
	// This is modified from the original tutorial such that a nice display name appears in most email clients.
	var source = $@"{senderFriendlyName} <{senderAddress}>";

	var subject = "Test Email from SES! :D";

	var textBody = "Amazon SES Test (.NET)\r\n"
				 + "This email was sent through Amazon SES "
				 + "using the AWS SDK for .NET.\r\n Please do not reply to this email... There is no mailbox for it.";

	var htmlBody = @"<html>
			<head></head>
			<body>
			  <h1>Amazon SES Test (AWS SDK for .NET)</h1>
			  <p>This email was sent with
			    <a href='https://aws.amazon.com/ses/'>Amazon SES</a> using the
			    <a href='https://aws.amazon.com/sdk-for-net/'>
			      AWS SDK for .NET</a>.</p>
				 <p>Please do not reply to this email... There is no mailbox for it.</p>
			</body>
			</html>";

	using (var client = new AmazonSimpleEmailServiceClient(accessKey, secretsKey, regionEndpoint))
	{
		var sendRequest = new SendEmailRequest
		{
			Source = source,
			Destination = new Destination
			{
				ToAddresses =
				new List<string> { recieverAddress }
			},
			Message = new Message
			{
				Subject = new Content(subject),
				Body = new Body
				{
					Html = new Content
					{
						Charset = "UTF-8",
						Data = htmlBody
					},
					Text = new Content
					{
						Charset = "UTF-8",
						Data = textBody
					}
				}
			},			
			// If you are not using a configuration set, comment
			// or remove the following line 
			// ConfigurationSetName = configSet
		};
		try
		{
			Console.WriteLine("Sending email using Amazon SES...");
			var response = await client.SendEmailAsync(sendRequest);
			Console.WriteLine("The email was sent successfully.");
		}
		catch (Exception ex)
		{
			Console.WriteLine("The email was not sent.");
			Console.WriteLine("Error message: " + ex.Message);
		}
	}
}