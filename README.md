# Proton Test

### Steps taken:
1. Initiated dotnet project from nunit template and added to github
2. Added packages 
    1. [RestSharp](https://github.com/restsharp/RestSharp) - for REST API calls
    2. [FluentAssertions](https://github.com/fluentassertions/fluentassertions) - more human readable assertions (than NUnit default)
3. Added ApiHelper class - Used postman code snippet generator for quicker request creation
4. Added response model class (VPNLogicalsModel) - used [json2csharp](http://json2csharp.com) to save time describing returned object manually
5. Added TestHelper class - for validating json data
6. Added Enums - for better readability of code

### Findings:
- In task description, it is specified, that Score value of Logical Server should be float type but is double
    - I've created branch called `passing` which is checking if values are double

- It wasn't specified, if base, secure core and free server should be running (but I supposed yes)
    - In `master` branch I check if at least one server is running as well
    - In `passing` branch, there's only validation that such servers are present

### Setting up Jenkins
1. Installed recommended plugins
2. Installed MSTest plugin (for parsing *.trx rsult files)
3. Created freestyle project
    1. Changed workplace folder to one, which contains tes project
    2. Added periodical execution for one hour - could be changed to
    3. Added build step `dotnet test -l trx` command (which runs tests and logs results to trx file)
    4. Added post build result reporting
    5. Added post build mail sending
4. Used [DebugMail](https://debugmail.io/) for validating mail reporting

### Wrap up
- Model values covervage is not 100%, but should be according to task description
- ApiHelper is using hardocded values - should be modular
- Email template is not perfect but could be useful in determining which server and why are failing
- I've added couple of screenshots to show jenkins is reporting properly
    - IN las two build I've checked out `passing` branch to illustrate passing results