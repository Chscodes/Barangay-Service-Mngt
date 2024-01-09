<?php
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['refNum']) ) {
    if ($db->dbConnect()) {
        if ($db->cncl_pndng("tbl_docsreq", $_POST['refNum'] )) {
            echo "Can cancel";
        } else echo "You can't cancel a request that is on process";
    } else echo "Error: Database connection";
} else echo "All fields are required sublime";
?>
