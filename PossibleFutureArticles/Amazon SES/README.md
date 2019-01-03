# Why did I need to send an email?

I wanted to verify accounts, maybe reset passwords, etc.

# Why Amazon SES instead of something like SendGrid?

Simple: because I'm cheap.

This guy goes into more detail: https://easysendy.com/blog/amazon-ses-vs-sendgrid/

# Tools Used in this

* Google Domains
* LINQPad
* Amazon SES
* Amazon IAM

# Things to set up before sending your first email

1. You will need a domain (Google Domains is what I will be using for this demo, but whatever you use should be similar enough).
2. I strongly recommend setting up a new Policy and User specifically for sending email (I will show how).

# Walkthrough of LINQPad Script

# Further Considerations

* Set up the configuration set so you can monitor bounced emails
* Learn how to test email sending against dummy endpoints: https://docs.aws.amazon.com/ses/latest/DeveloperGuide/mailbox-simulator.html 