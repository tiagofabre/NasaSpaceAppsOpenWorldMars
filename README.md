# NasaSpaceAppsOpenWorldMars
## Nasa space apps challenge

Do you love building new worlds?  Wouldn’t you like to build something that is "out-of-this-world"? Even though open world/sandbox games can generate worlds of various types, wouldn’t it be great if these worlds can actually contain real-life extraterrestrial terrains, rovers, robots and points-of-interest that exist in our celestial bodies?  Well, NASA would love to challenge our international community to do something great using NASA data.  Datasets are available for Mars and Vesta that can be integrated with open world/sandbox games to bring an out-of-this-world learning experience to players.
CONSIDERATIONS
Consider popular world-based games.  Leverage existing customizations and implement as a plugin or mod.
SOLUTIONS
Project teams from 6 are solving Open World Generation using NASA Mars and Vesta Data
View all Solutions


[Read more about the challenge...](https://2016.spaceappschallenge.org/challenges/solar-system/open-world-generation-using-nasa-mars-and-vesta-data)

## Solution 

The solution used a tile system map to render just the area where the user is using instead load the map of mars complete. To generat that maps the current datasets were used:

[Colorized elevation](http://www.mars.asu.edu/data/mola_color/):

The colorized dataset has colors representing the height map of mars, so I could use this information to apply in the elevation of the vertex and generate meshes that represent the small pieces of mars map.

[Viking merged color mosaic](http://www.mars.asu.edu/data/mdim_color/):

The viking coor mosaic is used to set textures in the mashes to make it similar iwth the map os Mars.

![alt tag](https://github.com/tiagofabre/NasaSpaceAppsOpenWorldMars/blob/master/ezgif.com-crop.gif)



