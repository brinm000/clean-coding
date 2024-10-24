<?php
/*
 * Dit programma vraagt de gebruiker om naam, leeftijd en woonplaats.
 * De gebruiker kan een superogedkope verzekering krijgen als:
 * - De leeftijd 18 jaar of ouder is
 * - De gebruiker niet woont in Utrecht, Amsterdam, Den Haag, of Rotterdam.
 * - Daarna wordt 3 keer een simpele adressticker geprint (met echo)
 *
 * stap 3: sticker print in function
 */

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

function printStickers($name, $city, $number = 1)
{
    for($sticker = 1; $sticker <= $number; $sticker++) {
        echo "$name" . PHP_EOL;
        echo "$city" . PHP_EOL . PHP_EOL;
    }
}

$excluded_cities = array("amsterdam", "den haag", "rotterdam", "utrecht");

$name = getString("Wat is je naam? ");
$age = getInteger("Wat is je leeftijd? ");
$city = strtolower( getString("Wat is je woonplaats? ") );
if($age >= 18 && ! in_array($city, $excluded_cities)) {
    echo $name . " krijgt een verzekering" . PHP_EOL;
    printStickers($name, $city, 3);
}
else echo $name . " krijgt geen verzekering";
