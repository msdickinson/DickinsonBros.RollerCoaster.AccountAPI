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
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyMDIwIiwibmJmIjoxNTg3ODQ5NTYwLCJleHAiOjE1ODc4NTA0NjAsImlhdCI6MTU4Nzg0OTU2MH0.bnExI37D8z4CnksOtg2yjhn3ao0Ow_gDSopXa4TSpgc",
    "accessTokenExpiresIn": 900,
    "refreshToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyMDIwIiwibmJmIjoxNTg3ODQ5NTYwLCJleHAiOjE1ODc4NTY3NjAsImlhdCI6MTU4Nzg0OTU2MH0.3LcUD32P6QgAc03sb-Ka5M74VhfWWyFZDUJFc5HytD4",
    "refreshTokenExpiresIn": 7200,
    "tokenType": "Bearer"
}

## RefreshToken

Returns a new JWT Result with accessToken and Refresh Token

Example: 

{
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyMDIwIiwibmJmIjoxNTg3ODQ5NTYwLCJleHAiOjE1ODc4NTA0NjAsImlhdCI6MTU4Nzg0OTU2MH0.bnExI37D8z4CnksOtg2yjhn3ao0Ow_gDSopXa4TSpgc",
    "accessTokenExpiresIn": 900,
    "refreshToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyMDIwIiwibmJmIjoxNTg3ODQ5NTYwLCJleHAiOjE1ODc4NTY3NjAsImlhdCI6MTU4Nzg0OTU2MH0.3LcUD32P6QgAc03sb-Ka5M74VhfWWyFZDUJFc5HytD4",
    "refreshTokenExpiresIn": 7200,
    "tokenType": "Bearer"
}

## RequestPasswordResetEmail

## ResetPassword

## UpdateEmailPreferenceWithToken

## UpdateEmailPreference

## ActivateEmail

## UpdatePassword

