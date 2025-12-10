# dotnet-webapp

Minimal ASP.NET Core minimal API targeting .NET 9.

Quick start (PowerShell):

```powershell
# ensure .NET 9 SDK is installed
dotnet --version

cd dotnet-webapp
dotnet restore
# run on http://localhost:5000 by default; output shows assigned URL
dotnet run
```

Open `http://localhost:5000/` (or the URL shown) to see the greeting.

ARM deployment (optional):

```powershell
az group create --name myResourceGroup --location "West US 2"
az deployment group create --resource-group myResourceGroup --template-file ../azure/azuredeploy.json --parameters ../azure/azuredeploy.parameters.json
```

Notes:
- This repository uses `TargetFramework` `net9.0`.
- If you don't have .NET 9 installed, install the preview SDK from Microsoft.

## CI/CD (GitHub Actions)

This repository includes a GitHub Actions workflow at `.github/workflows/azure-dotnet9-ci-cd.yml` that builds the `.NET 9` app and deploys it to an Azure App Service using a publish profile.

Required repository secrets (set in GitHub -> Settings -> Secrets & variables -> Actions):

- `AZURE_WEBAPP_NAME` : the name of your Azure Web App (e.g. `my-dotnet9-webapp-12345`).
- `AZURE_WEBAPP_PUBLISH_PROFILE` : the contents of the publish profile XML you download from the Azure Portal (use the **Get publish profile** button on the Web App Overview page).

How it works:

- On push to `main` (or manual `workflow_dispatch`) the workflow:
	- sets up the .NET 9 SDK,
	- restores, builds and publishes the project in `dotnet-webapp`,
	- archives the publish output as `publish.zip`,
	- deploys the zip to Azure using the publish profile.

Get the publish profile from the portal:

1. Open the Web App in the Azure Portal.
2. On the Overview page click **Get publish profile** and save the XML file.
3. In your GitHub repo add a new secret named `AZURE_WEBAPP_PUBLISH_PROFILE` and paste the content of the XML file.
4. Add `AZURE_WEBAPP_NAME` secret with the exact app name.

Alternative authentication (service principal):

You can also authenticate the workflow with a service principal using `azure/login` and `azure/webapps-deploy` instead of the publish profile. If you'd like that alternative I can add a second workflow demonstrating a service-principal-based deployment.

Triggering and debugging:

- Push a commit to `main` to trigger the workflow or run it manually in the Actions tab.
- The workflow logs show `dotnet` output and the deploy step output from `azure/webapps-deploy`.

