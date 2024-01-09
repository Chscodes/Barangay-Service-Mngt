<?php
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['refNum'])) {
    if ($db->dbConnect()) {
        if ($db->update_action("tbl_docsreq", $_POST['refNum'])) {
            echo "Request Canceled successfully!";
        } else echo "Request Canceled failed!";
    } else echo "Error: Database connection";
} else echo "All fields are required sublime";
?>
