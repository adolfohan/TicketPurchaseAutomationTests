Feature: Ticket Purchase

    Scenario: Purchase ticket with credit card successfully
        Given the user is on the website
        When the user selects a random "Me interesa" button
        And selects the desired tickets
        And confirms the date
        And clicks on the "Comprar" button
        And completes personal information
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks on the "Comprar" button again
        And completes the card information
        And clicks on the "Pagar" button
        And clicks on the "Enviar" button
        And clicks on the "Continuar" button
        Then should be able to see a 'Gracias por tu compra' message

    Scenario: Purchase ticket with personal information in blank unsuccessfully
        Given the user is on the website
        When the user selects a random "Me interesa" button
        And selects the desired tickets
        And clicks on the "Comprar" button
        And does not completes personal information
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks on the "Comprar" button again
        Then the user cannot proceed to the payment with fields in blank
        
    Scenario: Purchase ticket with incorrect name and surname unsuccessfully
        When the user selects a random "Me interesa" button
        And selects the desired tickets
        And clicks on the "Comprar" button
        And completes with incorrect name and surname
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks on the "Comprar" button again
        Then the user cannot proceed to the payment with invalid name and surname
        
    Scenario: Purchase ticket with incorrect id unsuccessfully
        Given the user is on the website
        When the user selects a random "Me interesa" button
        And selects the desired tickets
        And clicks on the "Comprar" button
        And completes with incorrect id
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks on the "Comprar" button again
        Then the user cannot proceed to the payment with invalid id
        
    Scenario: Purchase ticket with incorrect email unsuccessfully
        Given the user is on the website
        When the user selects a random "Me interesa" button
        And selects the desired tickets
        And clicks on the "Comprar" button
        And completes with incorrect email
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks on the "Comprar" button again
        Then the user cannot proceed to the payment with invalid email
        
    Scenario: Purchase ticket with incorrect phone number unsuccessfully
        Given the user is on the website
        When the user selects a random "Me interesa" button
        And selects the desired tickets
        And clicks on the "Comprar" button
        And completes with incorrect phone number
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks on the "Comprar" button again
        Then the user cannot proceed to the payment with invalid phone number

    Scenario: Purchase ticket without checking the checkboxes unsuccessfully
        Given the user is on the website
        When the user selects a random "Me interesa" button
        And selects the desired tickets
        And clicks on the "Comprar" button
        And completes personal information
        And clicks on the "Comprar" button again
        Then the user cannot proceed to the payment without checking the checkboxes
        
    Scenario: Purchase ticket with invalid credit card unsuccessfully
        Given the user is on the website
        When the user selects a random "Me interesa" button
        And selects the desired tickets
        And clicks on the "Comprar" button
        And completes personal information
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks on the "Comprar" button again
        And completes with wrong card number
        And clicks on the "Pagar" button
        Then the ticket purchase should be unsuccessful
        
    Examples: 
      | CardNumber    | ExpirationMonth | ExpirationYear | SecurityCode |
      | 1234567890123 | 12              | 49             | 123          |
      | 9876543210987 | 10              | 50             | 789          |