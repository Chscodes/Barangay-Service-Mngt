<?php
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['ctzn_col_email']) ) {
    if ($db->dbConnect()) {
        if ($db->verify("tbl_ctzn", $_POST['ctzn_col_email'] )) {
            echo "Email already used!";
        } else echo "Email not Registered";
    } else echo "Error: Database connection";
} else echo "All fields are required sublime";
?>
