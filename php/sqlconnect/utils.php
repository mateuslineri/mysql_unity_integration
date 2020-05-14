<?php 

function DBconnect()
{
  $con = mysqli_connect('localhost', 'root', '', 'unitymysql');

  if (mysqli_connect_error()) {
  echo ("Error -> Connection Error on register (error code #1)");
  exit();
  }

  return $con;
}