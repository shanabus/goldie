# Goldie

This Blazor Server app is a basic structure for creating a location-based (NFC /QR tags) trivia game.  Modeled after the "Re-elect Goldie Wilson" posters from the Back to the Future movie series, this game requires a MSSQL database to store a set of questions.  Players scan the NFC or QR code then are prompted to set a player name. After that they receive questions as the interact with the tags.  An Admin screen lets the host monitor progress and review questions.

## Setup

Fork the repo then init user-secrets.  We just need one for the DB conn string currently so set it at `"ConnectionStrings:DefaultConnection"`

You will need to set a valid MSSQL connection string like:

```"Data Source=URL;Initial Catalog=DATABASE;User Id=USERID;Password=PASSWORD"```

From here you can run the EF Migration, something like this:

```dotnet ef database update```

If it all works as planned, you will have tables for Migrations, Players, Questions, and Answers.  Populate the Questions table and set some sort of unique QuestionToken value.  I used a set of 4 random alphanumeric digits like "A5G3" or "9TL7" just to obfuscate the URLs a bit.  The `CorrectChoice` column must exactly match the right answer the way its currently setup; it just does a string match when calculating scores.

Once you have a healthy set of questions you can start encoding your tags!

## Poster.razor

This file has some of the game logic as it was initially built with NFC tags hidden behind posters like this:

![Goldie Wilson poster](https://github.com/shanabus/goldie/blob/main/Goldie/wwwroot/images/goldie-wilson.png?raw=true)

## Admin

Out-of-the-box, the Admin page lives at WEBSITE/admin/88 - you know, because that's how fast the DeLorean needed to go!  Change the route by modifying the `@page` directive at the top of the Admin.razor file.

The Admin page lists the current players scores, sorted by Score value then by Time Completed.  There is also a toggle for showing/hiding the games Questions.

## Notes 
- When using NFC tags, iPhone users may have to setup an "Automation" by using the Shorcuts app.  This slowed down adoption briefly but it was a one-time task so not too painful.
- The cookie expiration may complicate game play if the trivia game lasts more than a day, if so change that in the WriteCookie method.
- If a player switches browsers, they will be prompted to create a new player (name). That may trip people up since there is no name validation or player merging.

## Potential Improvements
- Add db-functions to admin page like clear Answers / Players
- SignalR messaging to create urgency and fun by notifying others when players complete questions or the game
- Improved scoring system
- Allow hints for players
- Add images or text after answering to add context
- Alternate question types beyond multiple choice
