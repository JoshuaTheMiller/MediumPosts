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
sudo docker run -it --rm -p 7777:7777 --mount source=terraria,target=/world --name="terraria" ryshe/terraria:latest

# Step 5
sudo docker run -dit --rm -p 7777:7777 --mount source=terraria,target=/world --name="terraria" ryshe/terraria:latest -world /world/IngloriousNightmare.wld

// Inspect existing volume
sudo docker run -it --rm --mount source=terraria,target=/world --name="volumeinspect" ubuntu 


g.terraria.trfc.dev

# Notes

* Initially tried to run on cheapest server with Docker. Terraria server crashed as it was out of memory
  * https://vsupalov.com/debug-docker-container/
  * https://success.docker.com/article/what-causes-a-container-to-exit-with-code-137
* Links for Docker overhead. Would be good to do actual observations
  * https://medium.com/travis-on-docker/the-overhead-of-docker-run-f2f06d47c9f3
* Other hosts
  * https://nodecraft.com/pricing?currency=USD&games=terraria
  
 ## Linux Things
 
 * Create new user for running
 * Install `jq` for finding/replacing json value (for password change), install moreutils to leverage `sponge` so that the config file can be replaced after using `jq`
