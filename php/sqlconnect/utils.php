<?php 

function DBconnect($db = 'unitymysql')
{
  $env = parse_ini_file(realpath('env.ini'));
  $con = mysqli_connect($env['host'], $env['username'], $env['password'], $db);

  if (mysqli_connect_error()) {
    echo ("Error -> Connection Error on register (error code #1)");
    exit();
  }

  return $con;
}

function createDBsctructure() {
  $connection = DBconnect(null);
  $createDatabaseQuery = "CREATE DATABASE IF NOT EXISTS unitymysql;";

  $createDatabase = $connection->query($createDatabaseQuery);

  if ($createDatabase) {
    echo "Database created";

    $connection = DBconnect();
    $createTableQuery = "CREATE TABLE IF NOT EXISTS players (
      id INT(6) AUTO_INCREMENT NOT NULL PRIMARY KEY,
      username VARCHAR(50) NOT NULL UNIQUE,
      hash VARCHAR(100) NOT NULL,
      salt VARCHAR(100) NOT NULL,
      score INT(6) DEFAULT 0,
      level INT(6) DEFAULT 1,
      email VARCHAR(50) NOT NULL
    );";

    $createTable = $connection->query($createTableQuery);

    if ($createTable) {
      echo "Table created";
    }
    else {
      echo "Table not created. Error: " . $connection->error;
    }

    $connection->close();
  }
  else {
    echo "Database not created. Error: " . $connection->error;
  }

  $connection->close();
}

createDBsctructure();