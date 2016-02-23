In order to deploy the API application out to Azure, there are a few things that need to be installed first.

1. [Install Azure SDK](https://azure.microsoft.com/en-us/downloads/)

Once you have your environment setup, you will want to open ~/deploy/MCM.KidsIdApp.Template/MCM.KidsIdApp.Template.sln

1. Once the solution file is opened - open up templates\azuredeploy.parameters.json
1. Modify parameters as needed (changing host name, etc)
1. Right click the project file (MCM.KidsIdApp.Template) and select "Deploy" -> "New Deployment..."
1. Inside the deployment window select your account and subscription
1. For Resource Group either choose an existing resource group or create a new one
1. Click on Edit Parameters to double check everything is correct
1. Click save and then click "Deploy"
1. Validate the output window, the very bottom part should say something similar to "Deployment succeeded"

You can run ARM templates via PowerShell if needed by using the New-AzureRmResourceGroupDeployment 
More information about this topic can be found here: [ARM Template MSDN Article](https://azure.microsoft.com/en-us/documentation/articles/resource-group-template-deploy/)

Once the Mobile App is inside your resource group inside [Azure Portal](http://portal.azure.com/), we will select it and modify the settings to add the social authentications

Click on "All settings"

![All Settings](https://cloud.githubusercontent.com/assets/1068431/13200424/48838696-d80c-11e5-8e89-ad5c55ea5aea.png)

Select "Authentication / Authorization"

![Select Authentication](https://cloud.githubusercontent.com/assets/1068431/13200427/b8231c50-d80c-11e5-81b5-1ae56e2286fd.png)

Select the On option
Enter in each social network key and secret
