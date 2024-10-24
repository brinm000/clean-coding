<?php
/*
 * Dit programma vraagt de gebruiker om naam, leeftijd en woonplaats.
 * De gebruiker kan een superogedkope verzekering krijgen als:
 * - De leeftijd 18 jaar of ouder is
 * - De gebruiker niet woont in Utrecht, Amsterdam, Den Haag, of Rotterdam.
 * - Daarna wordt 3 keer een simpele adressticker geprint (met echo)
 *
 * stap 1: function voor input
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


$name = getString("Wat is je naam? ");
$age = getInteger("Wat is je leeftijd? ");
$city = getString("Wat is je woonplaats? ");
if($age >= 18 &&
    !($city == "Utrecht" ||
      $city == "Amsterdam" ||
      $city == "Den Haag" ||
      $city == "Rotterdam")) {
    echo $name . " krijgt een verzekering" . PHP_EOL;
    echo "$name" . PHP_EOL;
    echo "$city" . PHP_EOL . PHP_EOL;
    echo "$name" . PHP_EOL;
    echo "$city" . PHP_EOL . PHP_EOL;
    echo "$name" . PHP_EOL;
    echo "$city" . PHP_EOL . PHP_EOL; }
else echo $name . " krijgt geen verzekering";
