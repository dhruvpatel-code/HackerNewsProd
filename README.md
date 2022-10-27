# HackerNewsAPI

Used to pull new news articles from the Hacker News API : https://hacker-news.firebaseio.com/v0/

Live site demo is hosted here on Azure: https://hackernewsnewarticles.azurewebsites.net/

## Description

This Project is made with Angular as the front end and .Net 5 C# as the backend. This projects main purpose is to pull new news  articles from the Hacker News API,
and display it on the front end. The frontend lets you filter through the articles with a search box, it also has a paging mechanism; there will be a 10 article limit before you need to go on the next page. On the Backend I added a Memory cache to store articles in cache memory for faster loading.

### Dependencies

Windows, Linux or Mac
.Net 5 runtime and SDK
Node Version 14+

### Installing

You can easily close the repository or download the files as a zip. I would recommend build the solution on Visual Studio for a smooth expierence.

### Executing program

* Visual Studio: Easily open and build the solution, build it and then click the play icon to launch with IIS.
* Unit test for backend can be done In visual studio and Angular tests done using VScode by opening the ClientApp folder and in the terminal writing 
```
ng test
```


