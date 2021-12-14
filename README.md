# address-book
A small sample of a very basic React frontend with .NET 6 backend.
Repo is meant to be a starting point to showcase some of the posibilities of .NET and React.
There are still many missing items to implement before this is anywhere near production ready.
Core idea of this application was to be an address book for a person. They can insert any number of names and attach any amount of addresses to each name.

## api
API folder contains all the backend .NET 6 code. It has the following controllers
- AddressController
- PersonController

AddressController will server all addresses given the ID of a person
PersonController will serve up all persons that exist in the database

This repo does not use an actual database. Instead, it relies on a singleton, in memory database. So whenever the application is restarted, all saved data not hardcoded is forgotten.
We have hardcoded 1 person into the database and created 1 address for this person as well.

## web
Web folder contains all React front end code. It was created using the latest create-react-app with Typescript template.
React Router v6 was used to implement our client side paging.
JSS was used to implement our CSS in Javascript solution.

Project implements the following pages:
- Home Page, which displays all "Persons" that have been inserted.
- AddPersonPage, which allows someone to post a new user into the database
- ViewPersonAddressPage, which allows someone to view the addresses tied to a person
- AddAddressForPersonPage, this is not implemented but the goal of this page was to allow users to insert a new address for a person
