# GasTracker Tool

The GasTracker Tool is a .NET application designed to fetch and display gas prices from various Ethereum networks, including Mainnet, Sepolia, and Holesky. This tool is ideal for developers and analysts who need to monitor gas prices across different Ethereum testnets and mainnets efficiently.

## Features

- **Multi-Network Support**: Easily switch between different Ethereum networks by instantiating the appropriate gas tracker class.
- **Dependency Injection**: Utilizes a factory pattern with dependency injection to manage and create instances of gas tracker classes based on network requirements.
- **Logging**: Integrated with log4net for robust logging capabilities, ensuring that all operations and errors are well-documented.
- **Extensible Design**: New networks can be added with minimal changes, thanks to the modular design and use of interfaces.


### Configuration

- Update the `appsettings.json` file with your Infura project IDs and URLs for each network.
- Ensure the `log4net.config` file is correctly set up for logging.

### Usage

Run the application using the following command:
The GasTracker Tool is a .NET application designed to fetch and display gas prices from various EVM networks,
