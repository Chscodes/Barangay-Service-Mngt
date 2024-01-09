<?php
require "DataBase.php";
$db = new DataBase();

if (
    isset($_POST['col_rqstDOC_lname']) && isset($_POST['col_rqstDOC_fname']) && isset($_POST['col_rqstDOC_mname']) && isset($_POST['col_rqstDOC_address'])  && isset($_POST['col_rqstDOC_year'])  && isset($_POST['col_rqstDOC_cnum']) && isset($_POST['col_rqstDOC_ctznshp']) && isset($_POST['col_rqstDOC_bday']) && isset($_POST['col_rqstDOC_pday']) && isset($_POST['col_rqstDOC_spouse']) && isset($_POST['col_rqstDOC_childrens']) && isset($_POST['col_rqstDOC_residency']) && isset($_POST['col_rqstDOC_gender']) && isset($_POST['col_rqstDOC_status']) && isset($_POST['col_rqstDOC_docsType'])  && isset($_POST['col_rqstDOC_purpose']) && isset($_POST['col_rqstDOC_action']) && isset($_POST['col_ctzn_requname'])


    ) {
    if ($db->dbConnect()) {


        if ($db->request("tbl_docsreq", $_POST['col_rqstDOC_lname'], $_POST['col_rqstDOC_fname'], $_POST['col_rqstDOC_mname'], $_POST['col_rqstDOC_address'], $_POST['col_rqstDOC_year'], $_POST['col_rqstDOC_cnum'], $_POST['col_rqstDOC_ctznshp'], $_POST['col_rqstDOC_bday'], $_POST['col_rqstDOC_pday'], $_POST['col_rqstDOC_spouse'], $_POST['col_rqstDOC_childrens'], $_POST['col_rqstDOC_residency'], $_POST['col_rqstDOC_gender'], $_POST['col_rqstDOC_status'], $_POST['col_rqstDOC_docsType'], $_POST['col_rqstDOC_purpose'], $_POST['col_rqstDOC_action'], $_POST['col_ctzn_requname']        ) ) {
            echo "Request Submited Successfully";
        }

         else echo "Request Failed";
    }

     else echo "Error: Database connection";
} 

else echo "All fields are required sublime";
?>
