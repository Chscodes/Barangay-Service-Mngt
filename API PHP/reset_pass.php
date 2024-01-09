<?php
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['ctzn_col_uname']) && isset($_POST['ctzn_col_pass'])) {
    if ($db->dbConnect()) {
        if ($db->reset_pass("tbl_ctzn", $_POST['ctzn_col_uname'], $_POST['ctzn_col_pass'])) {
            echo "Password updated sucessfully!";
        } else echo "Password reset failed!";
    } else echo "Error: Database connection";
} else echo "All fields are required sublime";
?>
