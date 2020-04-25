Everything required for account API is contained in this project

Account API - View, Logic and Infrastructure
Database - Contains tables, stored procs, and seed data needed for Account API.
Proxy - A libary with all APIS from Account API, and pushed as a nuget package
Integeration Tests - Uses Proxy To call all end points and in all sencrios


# Account API

Create, login and managze accounts




## Create

Creates new account and if email exists sends activation email.
Sets up email preference taken that is used in all emails allowing the user to update email preferences without logging in.

## Login

Logs user in by generating a JWT including accessToken and RefreshToken.

Example:

{
    "accessToken": "*",
    "accessTokenExpiresIn": 900,
    "refreshToken": *",
    "refreshTokenExpiresIn": 7200,
    "tokenType": "Bearer"
}

## RefreshToken

Returns a new JWT Result with accessToken and Refresh Token

Example: 

{
    "accessToken": "*",
    "accessTokenExpiresIn": 900,
    "refreshToken": *",
    "refreshTokenExpiresIn": 7200,
    "tokenType": "Bearer"
}

## RequestPasswordResetEmail

## ResetPassword

## UpdateEmailPreferenceWithToken

## UpdateEmailPreference

## ActivateEmail

## UpdatePassword

