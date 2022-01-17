# climbing-capacity

An application which fetches capacity data for London climbing walls. Currently only climbing walls which use the Rock Gym Pro management software make their capacity data visible on their websites and therefore available to this application. 

Note 1: It's fully functioning, production quality code but let's call it a very early beta.

Note 2: I have a very wonky attention span, so either this readme will be the last thing I ever do in this repo, or it will become my entire life and I'll over-engineer it to the point where it attains sentience and embarks on a campaign for world domination.

## How it works

TL;DR It's an HTML scraper. If that made you pull a face, you roll a 12 and notice a hidden sunlit path circumventing the dark haunted wood ahead, which leads you straight to the next section.

Rock Gym Pro provides an HTML page with the capacity data for a given organisation, which that organsiation displays in a frame on their own website. The capacity data itself is contained in JSON as part of an inline javascript script block. This application fetches the HTML, extracts the JSON using a regular expression (because is it _really_ a scraper otherwise??), parses the JSON and displays the current and max capacity.

## Tech stack

Code: .NET 6, ASP.NET, Razor

Test: NUnit, Fluent Assertions, Moq

Hosting: Azure Web App, Docker, Linux
