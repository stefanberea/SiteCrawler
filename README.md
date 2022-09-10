# SiteCrawler

The repository contains a VS2022 solution with 3 projects: a class library for crawling web resources, a console application and a test project.

## Class library

This contains methods for handling HTTP requests, URI resources and the algorithm for recursivery reading all the web addresses on a page.

## Console application

This application takes a URL as a command line argument and calls the Crawl function from the class library. The actions a user might want to take have to be passes as parameter to the Crawl function. 

## Test library - minimal due to lack of time

#

# Notes
The operation of crawling a website is much more convoluted than searching for all < a href="#" /> tags in the markup.
- The first thing one should do is look for a Sitemap .txt .xml .json
- Read the Robots.txt in order to acknolege the owner's permission to crawl the websites pages
- Compile a list of websites together with other sibling domains ex. dev.twitter.com is different than twitter.com
- Use the SiteCrawler tool on the list of URLs created earlier