<?php
//para sana sa validate if d available ang document d maccess ng mob app (DPA NA IMPLEMENT)
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['col_Doc_name']) ) {
    if ($db->dbConnect()) {
        if ($db->verify_availDOCU_INDI("tbl_docu", $_POST['col_Doc_name'] )) {
            echo "AVAILABLE";
        } else echo "Temporarily not available";
    } else echo "Error: Database connection";
} else echo "All fields are required sublime";
?>
