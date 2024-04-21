# GbDriver

GbDriver is a .NET Core C# project using Selenium WebDriver, MSTest, and MailSlurp for monitoring test and behavior-driven development at Gidgebot.com.

## Table of Contents

- [Introduction](#introduction)
- [Prerequisites](#prerequisites)
- [Setup](#setup)
- [Project Structure](#project-structure)
- [Usage](#usage)
- [Test Data](#test-data)
- [Running Tests](#running-tests)
- [SpecFlow Gherkin Syntax Integration](#specflow-gherkin-syntax-integration)
- [Contributing](#contributing)

## Introduction

GbDriver uses Selenium WebDriver for browser automation, MSTest for unit testing, and MailSlurp for email testing by scripting Chrome browser actions and asserting test conditions.

## Prerequisites

Prerequisites that need to be installed to run the project include:
- Visual Studio 
- .NET Core SDK 
- MailSlurp account 

## Setup

Clone the repository over HTTPS:
https://Gidgebot@dev.azure.com/Gidgebot/We%20Stand%20with%20George/_git/WebDriving%20Mit%20Gidgebot

Clone the repository over SSH:
git@ssh.dev.azure.com:v3/Gidgebot/We%20Stand%20with%20George/WebDriving%20Mit%20Gidgebot

## Project Structure

.vscode 
    |
    launch.json
    tasks.json
GbDriver
    |
    .gitattributes
    .gitignore
    GbDriver.sln
    README.md <--it-me--<<<

## Usage

These webdriver tests contain page objects hardcoded to run against Gidgebot.com, and a supporting framework that can be used to maintain and compose ChromeDriver testing. 

## Test Data

The 'GbDriver/Test Data/' directory contains dummyUserData.csv and gbUserData.csv to feed user account data into the test cases.

## Running Tests

Configure your Visual Studio application as an MSTest project and run in Test Explorer.

## SpecFlow Gherkin Syntax Integration

GbDriver also integrates SpecFlow with Gherkin syntax for writing feature tests. This allows for more expressive and readable tests that can be easily understood by non-technical stakeholders.

To use SpecFlow with Gherkin syntax, follow these steps:
1. Install the SpecFlow NuGet package.
2. Write feature files using Gherkin syntax to describe test scenarios.
3. Implement step definitions in C# to map Gherkin steps to automation code.

## Contributing

Thank you for considering contributing to this project! Your contributions help make it better.

### Issue Reporting

If you find any issues or have suggestions for improvements, please check the existing issues to see if the topic has been discussed. If not, feel free to [open a new issue](https://dev.azure.com/Gidgebot/We%20Stand%20with%20George/_workitems/create/Issue) with a detailed description of the problem or enhancement.

### Feature Requests

If you have a feature you'd like to see added, you can [open a feature request](https://dev.azure.com/Gidgebot/We%20Stand%20with%20George/_workitems/create/Epic) with a clear description of the proposed functionality. Discussions around the feature are also welcome.

### Pull Requests

We welcome contributions from the community! To contribute code changes:

1. Fork the repository to your own GitHub account.
2. Create a new branch for your changes: `git checkout -b feature/your-feature-name`.
3. Make your changes and test thoroughly.
4. Commit your changes with a clear and concise commit message.
5. Push your branch to your fork: `git push origin feature/your-feature-name`.
6. Open a [Pull Request](https://dev.azure.com/Gidgebot/We%20Stand%20with%20George/_git/WebDriving%20Mit%20Gidgebot/pullrequests?_a=mine) in the Azure DevOps repository.
7. Provide a detailed description of your changes in the pull request.

### Code Review

All contributions go through code review. Be prepared to address any feedback or make necessary changes to your pull request.

### Coding Guidelines

Please follow the coding style and guidelines used in the project. If unsure, refer to the existing codebase.

### Branching Strategy

- `zero`: The main branch reflects the production-ready state.
- `devOne`: The develop branch is used for ongoing development.

By contributing to this project, you agree to abide by the [Code of Conduct](CODE_OF_CONDUCT.md).

Thank you for contributing to make this project better!
