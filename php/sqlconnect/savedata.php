<?php
include_once("utils.php");
$con = DBconnect();

$username = $_POST["username"];
$newLevel = $_POST["level"];
$newScore = $_POST["score"];

$nameCheckQuery = "SELECT * FROM players WHERE username='${username}';";
$nameCheck = mysqli_query($con, $nameCheckQuery) 
  or die("Error -> Name check query failed on save (error code #8)");

if (mysqli_num_rows($nameCheck) != 1) {
  echo "Error -> No player registered or two players with same name (error code #9)";
  exit();
}

$updateQuery = "UPDATE players SET level=${newLevel}, score=${newScore} WHERE username='${username}';";
mysqli_query($con, $updateQuery) 
  or die("Error -> Failed updating player's information (error code #10)");