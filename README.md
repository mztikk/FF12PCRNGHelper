# FF12PCRNGHelper
Final Fantasy XII: The Zodiac Age RNG Helper.\
Works for the PC version of the game, initial release version, this app has to be updated when the game updates.

# 
![screenshot of app](https://puu.sh/zvbWh/6aaa784581.png)
It will read the memory of the game(which is why we require admin to work) to get the index of and the PRNG state array to calculate further values.\
This means there is no need to enter cure values to find where we are in the sequence, because we read the index straight from game memory.

Current State shows the next immediate rng value, followed by the next 1000.

# How to use
1. Start the game
2. Start app

# Dependencies
.NET Framework 4.7.1\
https://www.microsoft.com/en-us/download/details.aspx?id=56115
https://www.microsoft.com/net/download/thank-you/net471

# Credits
https://github.com/Tranquilite0/FF12RNGHelper