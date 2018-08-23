# Intro

PS Live is coming up! 
Wooo!
I'm excited, I love Pluralsight. I love making watchfaces. I love teaching (even though I haven't had much time for it) What better way to combine all of those loves into one, than writing a tutorial/blog post on making a Tribute Pluralsight Garmin Watchface!

By the way, if you just want a **list of the tools** that I've used, it's at the bottom of this article.

# What this article is not

A guide on best practices for MonkeyC (the language for Garmin watches). Honestly, it's been a while since I wrote a watchface from scratch, and the platform has changed drastically (for the better) since I wrote my first few back in 2015.

# Design

First things first, it's good to have a design in mine. I think the color scheme Pluralsight uses is pretty awesome, so I'm going to stick with that. I also really enjoy their fonts. I drew up a quick layout that I think I can work from. I want to support all of the latest functionality

1. Functionality
1. Layout
1. Font (keep in mind that font can impact your final layout choices)
1. Colors

# Set up environment and testing

Follow the instructions on Garmin's Website.

Alternatively, if you're feeling lazy, and are a person who is comfortable running a script, feel free to use my environment setup script. Note: It installs all of this stuff (list)

Talk about the various things the default project template (at least at version 3 or whatever) gives you (folder structure, files).

I'm going to choose the Vivoactive, Vivoactive 3, and Vivoactive 3 music as the devices to initially support, because it will allow for some topics to be more easily discussed (such as placement, I'll call this out in a later section to prove my point).

# Functionality

I want to support

* Battery display
* Heartrate (when available)
* Step Count 
* Percent of Goal
* Count of messages

## Adding layout items

First things first, I'm going to go into the layout file and change TimeLabel to TimeDisplay. I do this because I use the term "label" for other kinds of items in my projects. Don't forget to change the reference to TimeDisplay back in your view!

Now, I'm going to add 6 more items:

* BatteryDisplay
* HeartrateDisplay
* StepCountDisplay
* StepGoalDisplay
* DateDisplay
* MessageCountDisplay

Feel free to copy+paste the code provided. I suggest still reading through it to familiarize yourself with the syntax.

Oh! Remember how I mentioned I wanted to initially support the Vivoactive? The reason for that is it allowed me to use the location tags (e.g. top, right, left, bottom) with greater effect. If we had been testing this with a circular watch, like the Vivoactive 3 or a Fenix, then the items in the corners would be cut off from view.

# Layout

Now that I know my tools work, I'm going to work on the general layout.

From my initial design, I know I want my hours and minutes centered around a fancy seperator, so I'm going to split the normal time string into three parts.

Unfortunately, you can't use variables in the layout file so we're going to have to set the x coordinate of our time in the view

# Tools