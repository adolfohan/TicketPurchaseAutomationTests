Feature: Cancellation

    Scenario: Cancellation ticket successfully
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
        And selects "Cancelar" button
        And selects "Continuar" button
        Then the cancellation should be successful