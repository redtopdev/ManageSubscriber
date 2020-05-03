DIR=~/git/
if [ -d $DIR ]; then
  # Take action if $DIR exists. #
  echo "git folder exists"
else
  ###  Control will jump here if $DIR does NOT exists ###
  echo "Folder  ${DIR} not found. Creating the same."
  #mkdir ~/git/
fi

cd ~/git
DIR=~/git/ManageSubscriber/
if [ -d $DIR ]; then
  # Take action if $DIR exists. #
  echo "Cleaning up ~/git/ManageSubscriber folder before cloning."
  rm -r -f ~/git/ManageSubscriber/
else
  ###  Control will jump here if $DIR does NOT exists ###
  echo "${DIR} not found."
  
fi

echo "Cloning https://github.com/redtopdev/ManageSubscriber.git"
git clone https://github.com/redtopdev/ManageSubscriber.git
echo "Building ~/git/RegisterAPI/All.sln"
dotnet build --configuration debug ~/git/ManageSubscriber/All.sln
echo "Publishing ~/git/ManageSubscriber/Service/Subscriber.csproj to ~/engaze/api/subscription/  folder."
dotnet publish --output ~/engaze/api/subscription/ ~/git/ManageSubscriber/Service/Subscriber.csproj
