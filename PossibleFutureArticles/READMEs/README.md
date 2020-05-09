
Personal IP Address
A lot of tutorials will just tell you to find your IP address and share it with your friends, and then never mention it again... 
First and foremost, treat the numbers IP address lookup sites give you like your physical address. In other words, be careful about giving it out (you probably wouldn't want to post it on the internet for all to see).
Secondly, that IP address can actually change, especially if you are not a business that pays for a static IP address. Thankfully, most internet providers seem to post information about IP address renewals. I recommend looking at Xfinity's if you want an example (that is who provides my internet at the moment, I'm not endorsing them in any way).
Centering items in GitHub READMEs
A screenshot of the README of JoshuaTheMiller/TerrariaServer-ContainerI am still on the fence about whether or not I actually would recommend doing this, but for now, I do think centering items like titles and badges/shields looks pretty slick. 
To accomplish this, simply surround items to center with a div that has align="center" set like so (the following is the raw text of the image above):
<div align="center">
# 🚧 Containerized Terraria Server 🚧
[![Docker Cloud Build Status](https://img.shields.io/docker/cloud/build/trfc/terraria?style=flat-square)][dockerHub] [![Docker Cloud Automated build](https://img.shields.io/docker/cloud/automated/trfc/terraria?style=flat-square)][dockerHub] [![Docker Pulls](https://img.shields.io/docker/pulls/trfc/terraria?style=flat-square)][dockerHub]
*A containerized version of Terria Server (with [TShock](https://tshock.co/xf/index.php)) running on Linux, courtesy of [Mono](https://www.mono-project.com/)!*
</div>