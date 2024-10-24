<?php

class Applicant {
    private $name;
    private $age;
    private $city;

    function __construct($name, $age, $city) {
        $this->name = $name;
        $this->age = $age;
        $this->city = $city;
    }

    function getName()
    {
        return $this->name;
    }

    function getAge()
    {
        return $this->age;
    }

    function getCity()
    {
        return $this->city;
    }
}