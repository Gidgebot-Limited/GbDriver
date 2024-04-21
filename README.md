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

### Coding Guidelines

Please follow the coding style and guidelines used in the project. If unsure, refer to the existing codebase.

### Branching Strategy

- `zero`: The main branch reflects the production-ready state.
- `devOne`: The develop branch is used for ongoing development.
