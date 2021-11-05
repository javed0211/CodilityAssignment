# CodilityAssignment

### -Tool : Selenium WebDriver
### -Proramming Language : c#
IDE : Visual Studio
Test Framework : MSTest
BDD : SpecFlow
Reproting : Allure


Framework has all basic features that helps any automation tester to start automation with basic knowledge. Framwork pactices BDD using specflow and test can be written in gherkin to increase visibility of scope. 

Scripts are written in C#. 

Reporting: Every Execution will generate results in json files, these json files can be covereted into readable execution report using allure commandline. 

Commands : 
allure serve 'path of json files'
allure generate 'source of json files' -o 'destinatation of json files'
allure open 'path of report'

![image](https://user-images.githubusercontent.com/37189965/140448560-43492165-2f9e-447b-ac9e-785b493e61a7.png)
![image](https://user-images.githubusercontent.com/37189965/140448630-61694f9c-2c52-4bb4-beaf-08dac8adc71f.png)

What Can be improved :

Logs : I havent added logger library, it can be implmented using log4net. Option to add logs is must all frameworks

Screenshot in reports : I havent added code to capture screenshot but can be done using hooks easily , all we need to do is add following code
allureinstance.Addattachment("path of file");

Integration with Test Management tool : I would have add integration with JIRA or Azure DevOps if time would have permitted to enable automatic update of execution status

API integration
