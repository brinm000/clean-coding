<?php
/*
 * Dit programma vraagt de gebruiker om naam, leeftijd en woonplaats.
 * De gebruiker kan een superogedkope verzekering krijgen als:
 * - De leeftijd 18 jaar of ouder is
 * - De gebruiker niet woont in Utrecht, Amsterdam, Den Haag, of Rotterdam.
 * - Daarna wordt 3 keer een simpele adressticker geprint (met echo)
 *
 * stap 5: extract string and magic number
 */

const EXCLUDED_CITIES = ["amsterdam", "den haag", "rotterdam", "utrecht"];
const NAME_PROMPT = "Wat is je naam?";
const AGE_PROMPT = "Wat is je leeftijd?";
const CITY_PROMPT = "Wat is je woonplaats?";
const INSURANCE_GRANTED = "%s, je kan een verzekering afsluiten.";
const INSURANCE_NOT_GRANTED = "%s, je komt niet in aanmerking voor een verzekering.";

const NUMBER_OF_STICKERS = 3;

function getString(string $prompt): string
{
    do {
        $input = trim(readline($prompt));
    } while(strlen($input == 0));
    return $input;
}

function getInteger(string $prompt) : int
{
    do {
        $input = trim(readline($prompt));
    } while(strlen($input == 0) || ! is_numeric($input));
    return intval($input);
}

function printStickers(string $name, string $city, int $number = 1)
{
    for($sticker = 0; $sticker < $number; $sticker++) {
        echo "$name" . PHP_EOL;
        echo "$city" . PHP_EOL . PHP_EOL;
    }
}

function checkForInsurance(int $age, string $city) : bool
{
    if ($age < 18) return false;
    if (in_array($city, EXCLUDED_CITIES))  return false;
    return true;
}


$name = getString(NAME_PROMPT);
$age = getInteger(AGE_PROMPT);
$city = strtolower( getString(CITY_PROMPT) );
if(checkForInsurance($age, $city))  {
    echo sprintf(INSURANCE_GRANTED, $name) . PHP_EOL;
    printStickers($name, $city, NUMBER_OF_STICKERS);
}
else echo sprintf(INSURANCE_NOT_GRANTED, $name);
