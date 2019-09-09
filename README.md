# Proton Test

### Steps taken:
1. Init dotnet project from nunit template and added to github
2. Added packages 
2. 1. RestSharp - for REST API calls
2. 2. FluentAssertions - more human readable assertions (than NUnit default)
3. Added ApiHelper class - Used postman code snippet generator for quicker request creation
4. Added response model class (VPNLogicalsModel) - used [json2csharp](http://json2csharp.com) to save time describing returned object manually
5. Added TestHelper class - for validating json data
