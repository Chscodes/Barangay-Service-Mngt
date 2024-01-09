<?php 

//FETCH DATA
	
	$var = $_GET['user'];
		header('content-type: application/json');

		$con = mysqli_connect("localhost", "root","","db_brgypotrero");

		$query = "select * from tbl_ctzn where ctzn_col_uname = '" . $var . "'";
		//$query = "select * from tbl_ctzn where ctzn_ID = 40";
		$result = mysqli_query($con,$query);

		$json_data = array();
		while($row = mysqli_fetch_assoc($result)){
			$json_data[] = $row;
		}
	echo json_encode($json_data);

?>