Feature: Reservation

    Scenario: Reservation ticket successfully
        Given the user is on the website
        When the user selects the "Me interesa" button
        And selects the desired date
        And selects the desired tickets
        And clicks the "Comprar" button
        And completes personal information
        And selects "Reserva online" as the payment method
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks the "Comprar" button again
        Then a reservation email should be send successfully

    Scenario: Reservation ticket with personal information in blank unsuccessfully
        Given the user is on the website
        When the user selects the "Me interesa" button
        And selects the desired date
        And selects the desired tickets
        And clicks the "Comprar" button
        And does not completes personal information
        And selects "Reserva online" as the payment method
        And checks the Conditions checkbox
        And checks the Privacy checkbox
        And clicks the "Comprar" button again
        Then a reservation email should not be send

    Scenario: Reservation ticket without checking the checkboxes unsuccessfully
        Given the user is on the website
        When the user selects the "Me interesa" button
        And selects the desired date
        And selects the desired tickets
        And clicks the "Comprar" button
        And completes personal information
        And selects "Reserva online" as the payment method
        And does not checks the Conditions and Privacy checkboxes
        And clicks the "Comprar" button again
        Then a reservation email should not be send