<?php

include_once("applicant.class.php");
class InsurancePrinter
{
    public static function printStickers(Applicant $applicant, $numberOfStickers)
    {
        for($sticker = 0; $sticker < $numberOfStickers; $sticker++) {
            echo $applicant->getName() . PHP_EOL;
            echo $applicant->getCity() . PHP_EOL . PHP_EOL;
        }
    }
}