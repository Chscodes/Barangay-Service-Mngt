<?php
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['ctzn_col_uname']) && isset($_POST['ctzn_col_email'])) {
    if ($db->dbConnect()) {
        if ($db->verifyACC("tbl_ctzn", $_POST['ctzn_col_uname'], $_POST['ctzn_col_email'])) {
            echo "Account Exist";
        } else echo "Account Not Exist";
    } else echo "Error: Database connection";
} else echo "All fields are required sublime";
?>
