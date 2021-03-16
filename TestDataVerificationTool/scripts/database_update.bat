set CONFIG_URL="https://raw.githubusercontent.com/trogersVLS/MFG-00543_wTestDataVerificationTool/master/TestDataVerificationTool/App.config"
set CONFIG_FILE="C:\Ventec\MFG-00543\MFG-00543.exe.config"

curl --output %CONFIG_FILE% --url %CONFIG_URL%