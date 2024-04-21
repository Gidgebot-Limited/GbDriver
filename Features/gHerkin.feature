Feature: gHerkin
    In order to use gherkin syntax
    As a developer
    I want to automate the browser
@tag1
Scenario: Succussful browser automation with gherkin syntax and page objects
	Given Driver is instantiated
	When <PageType> page object model is instantiated
	Then Driver URL will be set to <ExpectedURL>

Examples:
	| PageType  | ExpectedURL              |
	| Google    | https://www.google.com/  |