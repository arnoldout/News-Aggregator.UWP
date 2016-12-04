# NwsAggregatorFrontEnd

A UWP app that connects with the https://nws-mongo-api.herokuapp.com RESTful API to give users a personalized news feed. 
The users can login directly to mongo through the NWS java API with a username and password, or through Facebook, using the Facebook API. They also have the option to register an account.
An account is needed to use the service. 

When the user logs in, they will be shown a list of news stories that are personalised to their tastes. 
If no news stories are shown, the user can add more by going to the settings page.

The user can click on a news story, and they will be shown that story. 
As they click a story, the tags of the articles are added to the user's account as likes. 

These likes help mould the personalized news feed for the user. 
