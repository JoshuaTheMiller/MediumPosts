# Notes about adding language support to GitHub

Simple search to start off with ("add a language to github") lead me to https://stackoverflow.com/q/42593670/1542187

Good contributor looks to see if something is present 😬 search linguist repo for MonkeyC (found 1 issue from 2015 that has since been closed).

Looks like no support is there. Need to gether a few pieces of information:

- [ ] Usage in the wild (>1000 repos): `extension:mc "using Toybox.Application as App;"`
  * Using more specific `"using Toybox.Application as App;"` as it appears that folks don't duplicate this line as much as other lines.
- [ ] Grammar. I have no idea what this means, but it appears that the folks over at Garmin do, and it was on their backlog 3 years ago... https://forums.garmin.com/developer/connect-iq/f/discussion/372/monkeyc-on-github
- [ ] Samples (could be my own, or from their open docs maybe?). Could use samples from repos with proper license.
