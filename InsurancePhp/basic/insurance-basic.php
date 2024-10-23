<?php
/*
 * Dit programma vraagt de gebruiker om naam, leeftijd en woonplaats.
 * De gebruiker kan een superogedkope verzekering krijgen als:
 * - De leeftijd 18 jaar of ouder is
 * - De gebruiker niet woont in Utrecht, Amsterdam, Den Haag, of Rotterdam.
 * - Daarna wordt 3 keer een simpele adressticker geprint (met echo)
 */

$name = readline("Wat is je naam? ");
$age = readline("Wat is je leeftijd?");
$city = readline("Wat is je woonplaats? ");
if($age >= 18 &&
    !($city == "Utrecht" ||
      $city == "Amsterdam" ||
      $city == "Den Haag" ||
      $city == "Rotterdam")) {
    echo $name . "krijgt een verzekering";
    echo "$name" . PHP_EOL;
    echo "$$city" . PHP_EOL . PHP_EOL;
    echo "$name" . PHP_EOL;
    echo "$$city" . PHP_EOL . PHP_EOL;
    echo "$name" . PHP_EOL;
    echo "$city" . PHP_EOL . PHP_EOL; }
else echo $name . "krijgt geen verzekering";
