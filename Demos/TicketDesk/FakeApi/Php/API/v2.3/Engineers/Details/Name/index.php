<?php
$engineers[872] = "John";
$engineers[233] = "Michael";
$engineers[421] = "Jeremy";
$engineers[104] = "Sarah";
$engineers[460] = "Simon";
$engineers[220] = "David";
$delay = rand(500000, 1000000);
usleep($delay);
echo($engineers[$_GET['engineerid']]);
?>