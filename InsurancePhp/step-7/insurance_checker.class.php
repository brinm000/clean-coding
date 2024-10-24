<?php

include_once("applicant.class.php");
class InsuranceChecker
{
    public static function checkForInsurance(Applicant $applicant) : bool
    {
        if ($applicant->getAge() < 18) return false;

        $city = strtolower($applicant->getCity());
        if (in_array($city, EXCLUDED_CITIES))  return false;
        return true;
    }
}