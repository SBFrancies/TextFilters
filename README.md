# Text filter

## Description
A console app for filtering text. The project has been built using .Net Core 3.1 in C#.

## Requirements to run

1) .Net Core 3.1

## Instructions

1) Run the application using dotnet .\pathtoapp (or in Visual Studio)

2) Enter the file path to the file containing text to be filtered

3) The filtered text is printed to the console screen

4) Repeat with more file paths

## Projects

### TextFilters

This project contains the console app.

### TextFilters.Tests

This project contains the unit tests.

## Limitations / assumptions

1) For words conatining a hyphen or apostrophe (or both), those characters are considered when calcualting the middle of the word. For example `o` would be considered the middle letter of `who's` rather than `ho`.

2) Only the English script upercase and lower case characters (a-z and A-Z) as well as apostrophes and hyphens are considered to be valid word characters. Apostrphes and hyphens cannot start or end a word. Other scripts, accents, emojis, etc will not work.

3) Why not use Regex? I am fairly sure that it would be possible to convert this application into a single regex. However that would be very hard to read and even harder to maintain. A regex could be used to identify the words rather than stepping through each character, an alternative aproach which I originally considered.

4) Why not clean double spaces after removing the words between them? It was not specified to remove anything other than the filtered words.

## If I had more time / Future changes

1) Upgrade to .Net 6.

2) Add StyleCop or some other static code analysis tool.

3) Add validation to file path / content.
