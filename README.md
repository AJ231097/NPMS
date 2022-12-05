The main code is in Phase2 branch. Please follow the below instructions

**National Park Management System(NPMS)** <br />
Project focusing on managing national parks, passes and events in The USA.

**Requirements**

1. Windows Machine
2. Microsoft Visual Studio Code 2022
3. Web Browser(Microsoft Edge, Google Chrome, Mozilla Firefox etc..)
4. ASP.NET Core 6.0 LTS
5. Git Bash

**Packages Required**

1. Microsoft.AspNetCore.Identity.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.SqlServer
3. Microsoft.EntityFrameworkCore.Tools
4. Microsoft.VisualStudio.Web.CodeGeneration.Design
5. NReco.Logging.File by Vitalii Fedorchenko
6. Konscious.Security.Cryptography.Argon2(optional)

**Steps to setup NPMS**

1. Start by cloning the repository to the local machine using Git Bash at your desired location.
```bash
    git clone https://github.com/AJ231097/NPMS.git
```
2. Once cloned, a folder will be created with the name NPMS. Navigate into the directory in Git Bash and then checkout to Phase2 branch using
```bash
    cd NPMS && git checkout Phase2
```
3. In Visual Studio navigate to the project folder and open the NPMS.sln file which loads the project into Visual Studio.

4. To view databases, click on View =\> SQL Server Object Explorer. You can find NPMS.Models database which is used in the web application.

5. Now run the project by clicking on NPMS button at the center of the toolbar which starts building the project and opens the web application in a web browser.

6. On initial run, if the application throws an error saying NPMS.Models cannot be accessed. Follow these steps to resolve the error.

Stop the application by closing the browser.

Navigate to Tools =\> NuGet Package Manager =\> Package Manager Console

Run the following command in Package Manager Console
```bash
Update-Database
```
1. After running the command right click on NPMS.Models database and select New Query which opens SQL editor which will be used to run a SQL script.

2. Open Scripts folder present in directory NPMS which has NPMS\_Script.sql file.

3. Open the file using Notepad or Notepad ++ , copy the script and paste in the SQL Editor and execute the script using Ctrl+Shift+E or the green button at the top left corner.

4. Now run the application by clicking the NPMS button at the center of the toolbar which starts the application.

**Users** <br />
The application has 2 roles <br />
Admin: Has control over the application <br />
User: A normal user or customer who can access the application over internet. <br />
*Please use these credentials to login as admin* <br />
Username: test <br />
Password: Test@123
