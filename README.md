# TheJollyMAUIApp
This is project that allowed be to bring many of my ongoing projects into one. In the below picture, I published my application to my phone. I learned how to sign the apllication and the various formats (aab) and (apk) files for Android phones. The project is work in progress and will go trhough many iterations to make it the best it can be.

In the image below, I make 3 seperate calls, 2 to established APIs from the National Oceanic and Atmospheric Administraion (NOAA) and National Weather Service, and one is a call to a web page for buoy data from NOAA, that I parse into the information I need.

The "Expected Visibility" is discussed further on down and uses the parsed data.
![IMG_2103](https://github.com/joerezo/TheJollyPhoneApp/assets/50391987/70e18a39-3931-4fa4-a757-5f21e1a5e70d)

The reason why I care about this data is becuase I dove this area many times. And since it is a fish sanctuary, it is a common place for divers to dive. The problem is the visibility can be terrible and the water is COLD. No one wants to drive all the way down to the beach, get in and not see anything. This apps helps alleviates this.

![Screenshot 2024-04-03 171544](https://github.com/joerezo/TheJollyPhoneApp/assets/50391987/e888c827-841b-4749-9726-d2c823091ad7)

So I asked many divers to give me their dive data. I ended up with observations from 2007. I then looked for open source data I could add as features to my dive set data and found NOAA had buoys and other measurements. In the following pictures you can see some the buoys and weather stations I used in my conditions page in my app.
![Screenshot 2024-03-25 144045](https://github.com/joerezo/TheJollyPhoneApp/assets/50391987/862cef96-307c-4615-b153-c0bd0a89a36a)

Previously I mentioned tables of data from NOAA. There was one buoy that was particularly important for me to experiment with. Unfortunatley it was only activated in 2013 so I couldn't some of my data from the Divers Logs.
Initially, I wanted to experiment with ML.Net but since I lost data as mentioned above. ML.Net would not let me run my models. So I went with Python scikit learn and generate LOTS of visualizations models to see which feature were the best to use.

Here is one that was more useful:

![TheJolly_LinearRegression](https://github.com/joerezo/TheJollyPhoneApp/assets/50391987/605c78b2-32d3-4cb3-bbf1-405872e0553b)

This one was not as useful for predicting:

![Screenshot 2024-03-13 230904](https://github.com/joerezo/TheJollyPhoneApp/assets/50391987/8d664336-ee1a-4f0b-9260-31a61b4e8336)

To better my model I needed a way to record depth, date and time. I created a SQLite database that does this. I included recognizable species for new divers so they know where to look and log for other new divers to explore.

Here is a video of my APP on the emulator on visual studio. The emulator was acting up and wouldn't display one of my boxes, but they do work.


https://github.com/joerezo/TheJollyPhoneApp/assets/50391987/e1db5e77-a322-4dfc-b1e1-9cb18bd6df13


