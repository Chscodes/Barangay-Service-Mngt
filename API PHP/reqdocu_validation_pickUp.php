<?php 



require "DataBase.php";
$db = new DataBase();

		if (isset($_POST['col_rqstDOC_lname']) && isset($_POST['col_rqstDOC_fname']) && isset($_POST['col_rqstDOC_mname'])
			&& isset($_POST['col_rqstDOC_docsType']) 
	)  {
		    if ($db->dbConnect()) 
		    {
		        if ($db->verify_reqdocu_pickUP("tbl_docsreq", $_POST['col_rqstDOC_lname'], $_POST['col_rqstDOC_fname'], $_POST['col_rqstDOC_mname'],$_POST['col_rqstDOC_docsType']
		    					)
		    		)		 
		        {
		            echo "Request denied, you still have a document for PICK UP";
		        } else echo "Can request pickup";
		    } else echo "Error: Database connection";
		} else echo "All fields are required sublime";



?>