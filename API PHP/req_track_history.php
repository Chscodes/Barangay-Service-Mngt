<?php 
$con = mysqli_connect("localhost", "root","","db_brgypotrero");


$var = $_GET['user'];
$query = "SELECT * FROM `tbl_docsreq` where col_ctzn_requname = '" . $var . "' && col_rqstDOC_action = 'Pending'";
$result = mysqli_query($con, $query);
$request_ctzn = array();


//req_track_history.php
while ($row = mysqli_fetch_array($result)) {
	$index['fetch_ref_num'] = $row['col_req_refNum'];
	$index['fetch_docstype'] = $row['col_rqstDOC_docsType'];
	//$index['fetch_purpose'] = $row['col_rqstDOC_purpose'];
	$index['fetch_lname'] = $row['col_rqstDOC_lname'];
	$index['fetch_fname'] = $row['col_rqstDOC_fname'];
	$index['fetch_mname'] = $row['col_rqstDOC_mname'];
	
	array_push($request_ctzn, $index);
}
echo json_encode($request_ctzn);

 ?>