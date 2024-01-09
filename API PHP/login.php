<?php
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['ctzn_col_uname']) && isset($_POST['ctzn_col_pass'])) {
    if ($db->dbConnect()) {
        if ($db->logIn("tbl_ctzn", $_POST['ctzn_col_uname'], $_POST['ctzn_col_pass'])) {
            echo "Login Successful";
        } else echo "Incorrect Username or Password";
    } else echo "Error: Database connection";
} else echo "All fields are required sublime";
?>
