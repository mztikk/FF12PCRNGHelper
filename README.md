# FF12PCRNGHelper
Final Fantasy XII: The Zodiac Age RNG Helper.\
Works for the PC version of the game, initial release version, this app has to be updated when the game updates.

# 
![screenshot of app](https://puu.sh/zzLvA/57d6b442ca.png)\
It will read the memory of the game(which is why we require admin to work) to get the index of and the PRNG state array to calculate further values.\
This means there is no need to enter cure values to find where we are in the sequence, because we read the index straight from game memory.

Current State shows the next immediate rng value, followed by the next 1000.

# How to use
1. Start the game
2. Start app

Search works like this: \
You can search for percentages directly by just entering them, seperated with commas, and it will look for exactly those.\
For example: 0,50 will search for a 0% followed by 50%.\
But you can also enter + and - for searching greater/lesser.\
80+, 95+ will search for 80 or greater followed by 95 or greater.

You can find more info in my reddit post: \
https://www.reddit.com/r/FinalFantasyXII/comments/806nmo/rng_helper_app_for_pc_version/

# Dependencies
.NET Framework 4.7.1\
https://www.microsoft.com/en-us/download/details.aspx?id=56115 \
https://www.microsoft.com/net/download/thank-you/net471

# Credits
https://github.com/Tranquilite0/FF12RNGHelper