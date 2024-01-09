<?php 

//dko pa alam magagamit ba kasi gumawa na ako bago activity para reset pass
	
	$var = $_GET['user'];
		header('content-type: application/json');

		$con = mysqli_connect("localhost", "root","","db_brgypotrero");
															//" . $var . "
		$query = "select * from tbl_ctzn where ctzn_col_uname = '" . $var . "'";

		$result = mysqli_query($con,$query);

		$json_data = array();
		
		while($row = mysqli_fetch_assoc($result)){
			$json_data[] = $row;
		}


	echo json_encode($json_data);




?>