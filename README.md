# Run application
### PowerShell
Run PowerShell inside ./Modsen/Modsen folder and enter the following command: `dotnet run`

# Update database
### Visual Studio
- Open "Package Manager Console"(View -> Other Windows -> Package Manager Console)
- Change target project to "Modsen.DL"
- Enter command: `Update-Database`
### PowerShell
- Run PowerShell inside _./Modsen/Modsen.DL_ folder and enter the following command: `dotnet ef --startup-project ../Modsen/ database update MigrationName`

- NOTICE! If _dotnet ef_ is not installed you need to install it using the following command: `dotnet tool install --global dotnet-ef`
