![Ventec-Life-Systems](./vls_logo.png)
# MFG-00543 - Test Data Verification Tool

## Description

This program queries the Production Test Database and the Syspro database to verify that a sub-assembly passes test.

## Installation

Open the appropriate installer file for the location in which this program is being installed. The format is below

```
<location>_MFG-00543_<revision>.msi
```

Follow the on-screen installer and select the default installation options.

## Installation Verification

To verify that the installer works as intended and that the database connections are correct for the intended location:

1. Retrieve a sub-assembly that has been tested using a production test stand and belongs to the group of part numbers listed in this <span style="color:red">document</span>
2. Locate the serial number on the sub-assembly.
3. Open MFG-00543 from the desktop shortcut or the start menu.
4. On the main screen, enter the serial number of the sub-assembly. Confirm that the data grid below shows the existing test record(s) for the part and that no error messages occur.
5. If the test is a passing result, select the Confirm PASS button. If the test is a fail, select the Confirm FAIL button.
6. Confirm that an error message does not occur.

The tool has been confirmed to be setup correctly for the location. In the event that a SQL error occurs, check the file at:
```
C:\Program Files (x86)\Ventec Life System\MFG-00543\MFG-00543.exe.config
```
Confirm that the conection string for the location used is correct.