<?php
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['ctzn_col_uname']) ) {
    if ($db->dbConnect()) {
        if ($db->U_verify("tbl_ctzn", $_POST['ctzn_col_uname'] )) {
            echo "Username already used!";
        } else echo "Username not Registered";
    } else echo "Error: Database connection";
} else echo "All fields are required sublime";
?>
