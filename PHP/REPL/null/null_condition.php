<?php

$x = null;
// $x = "Alpha"; 

echo ($y = strval($x)) . "\n";

if ($y = strval($x)) {
  echo "Not Empty" . "\n";
} else {
  echo "Empty" . "\n";
}

?>