# CipherAppServer
C# Web api to encrypt and decrypt caesar and vignere Ciphere

## API

[POST] decrypt : 
    - CipherRequest

[POST] encrypt :
    - CipherRequest

CipherRequest type consists of the following fields
    - CipherType cipherType
    - string cipherKey
    - string data

CipherType is an enum with the following options
    - 0: Vignere
    - 1: Caesar

The user can enter either 0 or 1 to switch between the Vignere and Caesar cipher strategies respectively.

