Feature: Counter Experience

Background: 
    Given we navigate to the counter page
    Then we are on the counter page

Scenario: I can increment the value
    Given the counter value is 0
    When we click the increment button
    And we wait 0.5 seconds
    Then the counter value is 1    