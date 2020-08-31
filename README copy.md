![Ventec Life Systems](./Images/vls_logo.png)

# MFG-00543 - Revision C <br/> Cough Assist Test Data Portal

## Description

This software is intended to be used in conjunction with the leak test hardware installed at the Cough Assist Valve test bench on the manufacturing floor. This software takes user input from the assembly and testing of the cough assist valve and stores the data in a remote server located on premises at Ventec Life Systems.

## Change History

### v1.0: Revision A

- Initial release of software tool

### v1.1: Unreleased

- Removed part number drop down for tool.

### v1.2: Unreleased

- Used at the Kokomo site during the Covid-19 pandemic build. Not released to Bothell manufacturing.
- Moved database connection strings to the App.Config file so that it could changed easily between Bothell and Kokomo sites.
- Removed station id and replaced with PC hostname.
- Removed usernames from settings.xml, replaced with currently logged in user.
- Added Final Assemblies to the settings.xml file so that Final Acceptance can use the tool to verify test data.

### v1.3: Revision C

- Added README.md file.
- Added final test filter so that only the most recent test for each step in final test is shown.
- Updated SQL query so that only tests after burn in are shown.

## Installation

- Open the **MFG-00543_\<revision\>_\<location\>.msi** file and follow the on screen instructions using the default options.

## Building

- Open project in Visual Studio 2019 or greater.
- Click **Build Solution**

## Configurations

### Debug

This configuration sets the Environment key in the App.config file to 'Debug'. This allows for the program to connect to the remote database using the Debug connection string.

### Bothell

This configuration sets the Environment key in the App.config file to 'Bothell'. This allows for the program to connect to the remote database using the Bothell connection string.

### Kokomo

This configuration sets the Environment key in the App.config file to 'Kokomo'. This allows for the program to connect to the remote database using the Kokomo connection string.
