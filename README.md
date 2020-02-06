## Building the project
1. Restore the nuget packages after opening the solution.
2. Change the connectrion string inside the OnConfiguring method of the PcDbContext class to point to the desired SQL Server instance.
3. Apply the mgirations by executing the Update-Database command inside the Package Manager Console.

## Running the project
1. Start the project by hitting F5.
2. Once the web app is loaded navigate to ~/Seed in order to seed the data to the DB.
3. You could then start using the application.