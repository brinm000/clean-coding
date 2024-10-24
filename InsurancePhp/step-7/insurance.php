<?php
/*
 * Dit programma vraagt de gebruiker om naam, leeftijd en woonplaats.
 * De gebruiker kan een superogedkope verzekering krijgen als:
 * - De leeftijd 18 jaar of ouder is
 * - De gebruiker niet woont in Utrecht, Amsterdam, Den Haag, of Rotterdam.
 * - Daarna wordt 3 keer een simpele adressticker geprint (met echo)
 *
 * stap 7: use classes
 */

include("prompt.strings.php");
include_once("applicant.class.php");
include("input_helper.class.php");
include("insurance_checker.class.php");
include("insurance_printer.class.php");

const NUMBER_OF_STICKERS = 3;

$applicant = InputHelper::getApplicant();
if(InsuranceChecker::checkForInsurance($applicant))  {
    echo sprintf(INSURANCE_GRANTED, $applicant->getName()). PHP_EOL;
    InsurancePrinter::printStickers($applicant, NUMBER_OF_STICKERS);
}
else {
    echo sprintf(INSURANCE_NOT_GRANTED, $applicant->getName());
}