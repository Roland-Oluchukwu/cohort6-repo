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
