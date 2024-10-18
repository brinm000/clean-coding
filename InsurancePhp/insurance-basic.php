<?php

$name = readline("Enter your name: ");
$age = readline("Enter your age: ");
$city = readline("Enter your city: ");

if($age >= 18 &&
    !(strtolower($city) == "utrecht" ||
      strtolower($city) == "amsterdam" ||
      strtolower($city) == "den haag" ||
      strtolower($city) == "rotterdam")) { echo "$name is not eligible"; }
else echo "$name is eligible for the insurance";
