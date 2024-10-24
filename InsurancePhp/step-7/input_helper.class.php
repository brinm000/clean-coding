<?php

include_once("applicant.class.php");

class InputHelper
{
    public static function getString(string $prompt): string
    {
        do {
            $input = trim(readline($prompt));
        } while(strlen($input == 0));
        return $input;
    }

    public static function getInteger(string $prompt) : int
    {
        do {
            $input = trim(readline($prompt));
        } while(strlen($input == 0) || ! is_numeric($input));
        return intval($input);
    }

    public static function getApplicant() : Applicant
    {
        $name = self::getString(NAME_PROMPT);
        $age = self::getInteger(AGE_PROMPT);
        $city = self::getString(CITY_PROMPT);

        return new Applicant($name, $age, $city);
    }
}