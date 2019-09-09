# Proton Test

### Steps taken:
1. Init dotnet project from nunit template and added to github
2. Added packages 
2. 1. [RestSharp](https://github.com/restsharp/RestSharp) - for REST API calls
2. 2. [FluentAssertions](https://github.com/fluentassertions/fluentassertions) - more human readable assertions (than NUnit default)
3. Added ApiHelper class - Used postman code snippet generator for quicker request creation
4. Added response model class (VPNLogicalsModel) - used [json2csharp](http://json2csharp.com) to save time describing returned object manually
5. Added TestHelper class - for validating json data
6. Added Enums - for better readability of code

### Findings:
- In task description, it was specified, that Score value of Logical Server should be float type but is double
    - I've created branch called `passing` which is checking if values is double

- It wasn't specified, if base, secure core and free server should be running (but I supposed yes)
    - In `passing` branch, there's only validation that such servers are present
    - In `master` branch I check if at least one server is running as well

### Improvements
- Model values covervage is not 100%, but should be according to task description
- ApiHelper is using hardocded values - should be modular
