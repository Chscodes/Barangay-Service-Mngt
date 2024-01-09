<?php
//para sana sa validate if d available ang document d maccess ng mob app (DPA NA IMPLEMENT
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['docs']) ) {
    if ($db->dbConnect()) {
        if ($db->verify_availDOCU("tbl_docu", $_POST['docs'] )) {
            echo "Available";
        } else echo "Temporarily not available";
    } else echo "Error: Database connection";
} else echo "All fields are required sublime";
?>
