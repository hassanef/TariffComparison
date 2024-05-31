#!/bin/bash

# Ensure the script exits if any command fails
set -e

# Check if .NET is installed
if ! command -v dotnet &> /dev/null; then
    echo ".NET is not installed. Installing .NET SDK..."
    wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
    chmod +x dotnet-install.sh
    ./dotnet-install.sh --channel 8.0
    export PATH=$PATH:$HOME/.dotnet:$HOME/.dotnet/tools
    rm dotnet-install.sh
fi

# Determine the directory of the script
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Navigate to the solution directory
cd "$SCRIPT_DIR"

# Restore and build the project
echo "Restoring and building the project..."
dotnet restore
dotnet build

# Navigate to the project directory
cd src/TariffComparison

# Run the application
echo "Running the application..."
dotnet run --urls "http://localhost:5000"

echo "Setup completed. Press any key to exit."
read -n 1 -s
