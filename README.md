
# Setup
This alow to create selft-executable setup file from folder containing your application. You will find above availaible command line and recomanded way to package your application

## Command line

Here all available command line to run or create package for setup.exe

>Note each argument as multiple variation for convenience.
Example: Quiet will also work with this
-Quiet /Quiet -Q /Q

### Setup Option
Option to run **setup.exe** to perform install if you want to create package refert to *Packaging Option* section, you may also want take a look to *Best Pratice*  section.

| Argument  |               Description                  |
|-----------|--------------------------------------------|
| Quiet | Run **Setup.exe** silently without UI, note you can configure setup using **config.json** file |
| Config `Config Path` | This allow to specify another **config file** by default app look for **config.json** and load it if it exist. |


### Packaging Option 
Thease option are for create all the prerequisite for create the selft executable setup and create the setup itself. You may also want take a look to *Best Pratice*  section
| Argument  |               Description                  |
|-----------|--------------------------------------------|
| NewBin `Folder Path` | This allow to package a folder to a compressed **data.bin** file that can be use as data source for setup.|
| Json | This will create a new **config.json** holding all property that could be configure in setup. Note none of them are mandatory |
| Setup `Config Path` | This allow you to create a **setup.exe** that will hold both config and data, you must specify path to a valid **configuration json file**  the datasource must be set to a **.bin file**. |

## Best Pratice to package
First thing to know is that the selft executable setup is't mandatory you could also have you data in a bin file (generated using **NewBin** argument) or by creating a folder next to the setup. By default the setup will check for data.bin and data folder if one of them exist it will be use as data source. But to create a self executable you must folow these step:
> At this point it a good idea to open a command prompt as admin

 1. First run `setup.exe NewBin "C:\PathToApplication"` that will create a **data.bin** next to **setup.exe**
 2. Next run `setup.exe Json` that will create **config.json** that contain all availaible parameter and will bind DataSource to the newly created **data.bin**
 3. Configure the setup in **config.json** you may refert to *Setup configuration* the most important is probably **executableName** by default if not specify it will take the first .exe on the data source as executable for application. So application shorcut may not lauch you app if your app contain multiple .exe
 4. Finaly run `setup.exe Setup .\config.json` this will create the seflt excutable setup file.

## Setup configuration

```json
{
  "name": "My App",
  "version": "1.0.0.0",
  "publisher": "My Compagny",
  "icon": "",
  "dataSource": ".\\data.bin",
  "executableName": null,
  "architecture": "X64",
  "path": "C:\\Program Files\\My Compagny\\My App",
  "pathIsEditable": true,
  "desktopCheckBox": {
    "visible": false,
    "enable": true,
    "checked": false
  },
  "startMenuCheckBox": {
    "visible": false,
    "enable": true,
    "checked": false
  },
  "startUpCheckBox": {
    "visible": false,
    "enable": true,
    "checked": false
  },
  "registryKeys": [
    {
      "path": "HKLM\\SOFTWARE\\My App",
      "name": "MyMachineKey",
      "value": "MyMachineValue"
    },
    {
      "path": "HKCU\\SOFTWARE\\My App",
      "name": "MyUserKey",
      "value": "MyUserValue"
    }
  ]
}
```
