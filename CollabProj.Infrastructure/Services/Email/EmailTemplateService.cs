using CollabProj.Application.Interfaces.Services.Email;
using Serilog;

namespace CollabProj.Infrastructure.Services.Email
{
    /// <summary>
    /// Implementation of service to create body templates for email list  
    /// </summary>
    public class EmailTemplateService : IEmailTemplateService
    {
        /// <summary>
        /// Implementation of method to create HTML body for validation code email list
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="verificationCode">Verification code</param>
        /// <returns>HTML body for validation code email list</returns>
        public string VerificationCodeTemplate(string username, int verificationCode)
        {
            Log.Debug("Forming HTML Body...");

            string htmlBody = $@"
            <html>
                <head>
                    <style>
                        body {{
                            font-family: 'Arial', sans-serif;
                            background-color: #f4f4f4;
                            margin: 0;
                            padding: 0;
                            text-align: center;
                        }}

                        .container {{
                            background-color: #ffffff;
                            max-width: 600px;
                            margin: 20px auto;
                            padding: 20px;
                            border-radius: 8px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                        }}

                        h2 {{
                            color: #333333;
                        }}

                        p {{
                            color: #555555;
                        }}

                        strong {{
                            color: #009688;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h2>Verification Code</h2>
                        <p>Dear {username},</p>
                        <p>Your verification code is: <strong>{verificationCode}</strong></p>
                        <p>Please use this code to verify your account. This code is valid for 30 minutes.</p>
                        <p>Thank you,</p>
                        <p>Your Application Team</p>
                    </div>
                </body>
            </html>";

            Log.Information("Formed HTML Body: {@htmlBody}", htmlBody);

            return htmlBody;
        }
    }
}
