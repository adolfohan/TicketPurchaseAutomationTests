Feature: Ticket Purchase

    Scenario: Purchase ticket with credit card successfully
        Given the user is on the website
        When the user selects a random "Me interesa" button
        And selects the desired date
        And selects the desired tickets
        And confirms the date
        And clicks the "Comprar" button
        And checks if it has sessions or advanced date picker
        And completes personal information
        And selects credit card as the payment method
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks the "Comprar" button again
        And completes the card information
        And clicks the "Pagar" button
        And clicks the "Enviar" button
        And clicks the "Continuar" button
        Then should be able to see a 'Gracias por tu compra' message

    Scenario: Purchase ticket with invalid credit card unsuccessfully
        Given the user is on the website
        When the user selects the "Me interesa" button
        And selects the desired date
        And selects the desired tickets
        And clicks the "Comprar" button
        And completes personal information
        And selects credit card as the payment method
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks the "Comprar" button again
        And completes with wrong "<card number>"
        And clicks the "Pagar" button
        Then the ticket purchase should be unsuccessful
        
        Examples: 
            | card number  |
            | 12345678912 |

    Scenario: Purchase ticket with personal information in blank unsuccessfully
        Given the user is on the website
        When the user selects the "Me interesa" button
        And selects the desired date
        And selects the desired tickets
        And clicks the "Comprar" button
        And does not completes personal information
        And selects credit card as the payment method
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks the "Comprar" button again
        Then the user cannot proceed to the payment with the fields in blank

    Scenario: Purchase ticket with incorrect personal information unsuccessfully
        Given the user is on the website
        When the user selects the "Me interesa" button
        And selects the desired date
        And selects the desired tickets
        And clicks the "Comprar" button
        And completes with incorrect personal information
        And selects credit card as the payment method
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        Then clicks the "Comprar" button again and the user cannot proceed to the payment

    Scenario: Purchase ticket without checking the checkboxes unsuccessfully
        Given the user is on the website
        When the user selects the "Me interesa" button
        And selects the desired date
        And selects the desired tickets
        And clicks the "Comprar" button
        And completes personal information
        And selects credit card as the payment method
        And does not checks the Conditions and Privacy checkboxes
        Then clicks the "Comprar" button again and the user cannot proceed to the payment