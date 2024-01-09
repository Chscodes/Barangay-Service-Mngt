<?php
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['ctzn_col_uname']) && isset($_POST['ctzn_col_pass']) && isset($_POST['ctzn_col_lname']) && isset($_POST['ctzn_col_fname']) && isset($_POST['ctzn_col_mname']) && isset($_POST['ctzn_col_email']) && isset($_POST['ctzn_col_addrss_Hnum']) && isset($_POST['col_ctzn_addrss_street']) && isset($_POST['col_ctzn_addrss_city']) && isset($_POST['ctzn_col_gender']) && isset($_POST['ctzn_col_bday']) ) {
    if ($db->dbConnect()) {


        if ($db->signUp("tbl_ctzn", $_POST['ctzn_col_uname'], $_POST['ctzn_col_pass'], $_POST['ctzn_col_lname'], $_POST['ctzn_col_fname'], $_POST['ctzn_col_mname'], $_POST['ctzn_col_email'], $_POST['ctzn_col_addrss_Hnum'], $_POST['col_ctzn_addrss_street'], $_POST['col_ctzn_addrss_city'] , $_POST['ctzn_col_gender'], $_POST['ctzn_col_bday'] ) ) {
            echo "Sign Up Success";
        }

         else echo "Sign up Failed";
    }

     else echo "Error: Database connection";
} 

else echo "All fields are required sublime";
?>
