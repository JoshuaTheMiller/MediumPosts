# Step 1
sudo apt-get update
sudo apt-get install apt-transport-https ca-certificates curl gnupg-agent software-properties-common
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -
sudo add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable"
sudo apt-get update
sudo apt-get install docker-ce docker-ce-cli containerd.io

# Step 2
sudo docker volume create terraria

# Step 3
sudo docker run -it --rm -p 7777:7777 --mount source=terraria,target=/world --name="terraria" trfc/terraria:latest

# Step 5
sudo docker run -dit --rm -p 7777:7777 --mount source=terraria,target=/world --name="terraria" trfc/terraria:latest -world /world/IngloriousNightmare.wld

// Inspect existing volume
sudo docker run -it --rm --mount source=terraria,target=/world --name="volumeinspect" trfc/vimtainer 


g.terraria.trfc.dev

# Notes

* Initially tried to run on cheapest server with Docker. Terraria server crashed as it was out of memory
  * https://vsupalov.com/debug-docker-container/
  * https://success.docker.com/article/what-causes-a-container-to-exit-with-code-137
* Links for Docker overhead. Would be good to do actual observations
  * https://medium.com/travis-on-docker/the-overhead-of-docker-run-f2f06d47c9f3
* Other hosts
  * https://nodecraft.com/pricing?currency=USD&games=terraria
* Started with using the ryshe/terraria image, but I became tired of configuring the password after the fact
* Create a server config file that people can quickly copy in (make a new image out of it actually) that allows all players to do everything. For those small groups of friends that are just goofing around.

 ## Linux Things
 
 * Create new user for running
 * Install `jq` for finding/replacing json value (for password change), install moreutils to leverage `sponge` so that the config file can be replaced after using `jq`
 
```bash 
pass="what" && configPath="/world/config.json" && jq --arg p "$pass" '.ServerPassword=$p' $configPath | sponge $configPath
```

# Hosting Options to check out

* https://azure.microsoft.com/en-gb/pricing/details/container-instances/
* https://www.bing.com/search?q=EC2+Micro+instances&FORM=ANCMS9&PC=U531
* https://aws.amazon.com/free/?all-free-tier.sort-by=item.additionalFields.SortRank&all-free-tier.sort-order=asc&awsf.Free%20Tier%20Types=tier%2312monthsfree&awsm.page-all-free-tier=1
* https://aws.amazon.com/fargate/pricing/
* https://www.kamatera.com/express/compute/apps.php?tcampaign=35166_366160&bta=35166&nci=5427#app=Docker
* https://docs.jelastic.com/pricing-model
  * https://jelastic.com/pay-as-you-use-cloud-pricing/
* https://sloppy.io/en/pricing/
  
EC2 micro may be good for new folks. It is free for the first 12 ~years~ loool type *months*, and the offering is good enough for a small server
I'm very curious about Jelastic. More digging around their pricing is needed, but it seems very promising. Potentially the most promising.
