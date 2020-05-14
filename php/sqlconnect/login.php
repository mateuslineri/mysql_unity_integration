<?php
include_once("utils.php");
$con = DBconnect();

$username = $_POST['username'];
$password = $_POST['password'];

$nameCheckQuery = "SELECT * FROM players WHERE username='${username}';";
$nameCheck = mysqli_query($con, $nameCheckQuery) 
  or die ("Error -> Name check query failed (error code #5)");

if (mysqli_num_rows($nameCheck) != 1) {
  echo "Error -> Either no user with name, or more than one (error code #6)";
  exit();
}

$nameCheckQueryInfo = mysqli_fetch_assoc($nameCheck);
// print_r($nameCheckQueryInfo);

$salt = $nameCheckQueryInfo["salt"];
$hash = $nameCheckQueryInfo["hash"];
$loginHash = crypt($password, $salt);

if ($hash != $loginHash) {
  echo "Error -> Incorrect password (error code #7)";
  exit();
} else {
  echo $username . "\t" . $nameCheckQueryInfo["score"] . "\t" . $nameCheckQueryInfo["level"];
}