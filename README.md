# goldie

This Blazor Server app is a basic structure for creating a location-based (NFC /QR tags) trivia game.  Modeled after the "Re-elect Goldie Wilson" posters from the Back to the Future movie series, this game requires a MSSQL database to store a set of questions.  Players scan the NFC or QR code then are prompted to set a player name. After that they receive questions as the interact with the tags.  An Admin screen lets the host monitor progress and review questions.

## Setup

Fork the repo then init user-secrets.  You will need to set a valid MSSQL connection string like:

```"Data Source=URL;Initial Catalog=DATABASE;User Id=USERID;Password=PASSWORD"```

From here you can run the EF Migration, something like this:

```dotnet ef database update```

If it all works as planned, you will have tables for Migrations, Players, Questions, and Answers.  Populate the Questions table and set some sort of unique QuestionToken value.  I used a set of 4 random alphanumeric digits like "A5G3" or "9TL7" just to obfuscate the URLs a bit.  The `CorrectChoice` column must exactly match the right answer the way its currently setup; it just does a string match when calculating scores.

Once you have a healthy set of questions you can start encoding your tags!

## Admin

Out-of-the-box, the Admin page lives at WEBSITE/admin/88 - you know, because that's how fast the DeLorean needed to go!  Change the route by modifying the `@page` directive at the top of the Admin.razor file.

The Admin page lists the current players scores, sorted by Score value then by Time Completed.  There is also a toggle for showing/hiding the games Questions.
