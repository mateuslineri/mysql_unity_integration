<?php
include_once("utils.php");
$con = DBconnect();

$username = $_POST['username'];
$email = $_POST['email'];
$password = $_POST['password'];

$nameCheckQuery = "SELECT username FROM players WHERE username='${username}';";
$nameCheck = mysqli_query($con, $nameCheckQuery) 
  or die("Error -> Name Check Query failed (error code #2)");

if (mysqli_num_rows($nameCheck) > 0) {
  echo ("Error -> Name already exists. Cannot register (error code #3)");
  exit();
}

$salt = "\$5\$rounds=500\$" . "steamedhams" . $username . "\$";
$hash = crypt($password, $salt);

$insertUserQuery = "INSERT INTO players (username, hash, salt, email) VALUES ('${username}', '${hash}', '${salt}', '${email}'); ";
mysqli_query($con, $insertUserQuery) 
  or die("Error -> Insert query failed (error code #4)");

echo ("teste");