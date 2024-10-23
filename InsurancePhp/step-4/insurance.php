<?php
/*
 * Dit programma vraagt de gebruiker om naam, leeftijd en woonplaats.
 * De gebruiker kan een superogedkope verzekering krijgen als:
 * - De leeftijd 18 jaar of ouder is
 * - De gebruiker niet woont in Utrecht, Amsterdam, Den Haag, of Rotterdam.
 * - Daarna wordt 3 keer een simpele adressticker geprint (met echo)
 *
 * stap 4: insurance check in function
 */

function getString(string $prompt)
{
    do {
        $input = readline($prompt);
    } while(strlen($input == 0));
    return $input;
}

function getInteger(string $prompt)
{
    do {
        $input = readline($prompt);
    } while(strlen($input == 0) || ! is_numeric($input));
    return $input;
}

function printStickers(string $name, string $city, int $number = 1)
{
    for($sticker = 1; $sticker <= $number; $sticker++) {
        echo "$name" . PHP_EOL;
        echo "$city" . PHP_EOL . PHP_EOL;
    }
}

function checkForInsurance(int $age, string $city) : bool
{
    $excluded_cities = array("amsterdam", "den haag", "rotterdam", "utrecht");
    if ($age < 18) return false;
    if (in_array($city, $excluded_cities)) return false;
    return true;
}


$name = getString("Wat is je naam? ");
$age = getInteger("Wat is je leeftijd? ");
$city = strtolower( getString("Wat is je woonplaats? ") );
if(checkForInsurance($name, $city))  {
    echo $name . " krijgt een verzekering";
    printStickers($name, $city, 3);
}
else echo $name . " krijgt geen verzekering";
