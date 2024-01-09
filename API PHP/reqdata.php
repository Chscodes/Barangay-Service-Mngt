<?php 

//FETCH DATA

	//$var = '2022-12-0921005532';
	$var = $_GET['ref_num'];
		header('content-type: application/json');

		$con = mysqli_connect("localhost", "root","","db_brgypotrero");

		//$query = "select * from tbl_docsreq where col_req_refNum = '" . $var . "'";
		$query = "SELECT
					    col_rqstDOC_lname,
					    col_rqstDOC_fname,
					    col_rqstDOC_mname,
					    col_rqstDOC_address,
					    col_rqstDOC_residency,
					    col_rqstDOC_year,
					    col_rqstDOC_gender,
					    col_rqstDOC_cnum,
					    col_rqstDOC_ctznshp,
					    col_rqstDOC_bday,
					    col_rqstDOC_pday,
					    col_rqstDOC_status,
					    col_rqstDOC_spouse,
					    col_rqstDOC_childrens,
					    col_rqstDOC_docsType,
					    col_rqstDOC_purpose
					FROM
					    tbl_docsreq
					WHERE
					    col_req_refNum = '" . $var . "'";
		$result = mysqli_query($con,$query);

		$json_data = array();
		while($row = mysqli_fetch_assoc($result)){
			$json_data[] = $row;
		}
	echo json_encode($json_data);



	/*
	//$var = $_GET['ref_num'];
	$var = '2022-12-0921005532';
	header('content-type: application/json');

	$query = "select ctzn_col_vouch from tbl_docsreq where col_req_refNum = '" . $var . "'";
	//$query = "select ctzn_col_vouch from tbl_docsreq where ID = 1";

	

	$con = mysqli_connect("localhost", "root","","db_brgypotrero");
     $result = mysqli_query($con,$query) or die(mysql_error());  


    while ($row = mysqli_fetch_array($result)) {
        $vouch_Img[] = $row['ctzn_col_vouch'];

        foreach ($vouch_Img as $V_img) {
            $id_pic = base64_encode($V_img);
        }

    }

    echo json_encode ($id_pic);

    */

/*
     // Connect to database
  $host = "localhost";
  $user = "root";
  $password = "";
  $dbname = "db_brgypotrero";

  $conn = mysqli_connect($host, $user, $password, $dbname);
  if (!$conn) {
    die("Connection failed: " . mysqli_connect_error());
  }
  //$var = $_GET['ref_num'];
  $var = '2022-12-0921405345';

  // Get image from database
  $sql = "SELECT * FROM tbl_docsreq WHERE col_req_refNum = ?";
  $stmt = mysqli_prepare($conn, $sql);
  mysqli_stmt_bind_param($stmt, "i", $var);
  mysqli_stmt_execute($stmt);
  $result = mysqli_stmt_get_result($stmt);
  $row = mysqli_fetch_array($result, MYSQLI_ASSOC);
  $image = $row['ctzn_col_vouch'];
  //$imag2 = $row['ctzn_col_ctznPIC'];
   //$lname = $row['col_rqstDOC_lname'];

  // Send image to client
  header("Content-Type: image/jpeg");
  echo $image;
*/
/*
// Connect to the database
$conn = mysqli_connect("localhost", "root", "", "db_brgypotrero");

	// Check the connection
	if (!$conn) {
	    die("Connection failed: " . mysqli_connect_error());
	}


	//$var = $_GET['ref_num'];
    $var = '2022-12-0921405345';

	// Execute the query
	$result = mysqli_query($conn, "SELECT * FROM tbl_docsreq WHERE col_req_refNum = '" . $var . "'");

// Check if the query was successful
			if ($result) {
			    // Fetch the data from the result set
			    $row = mysqli_fetch_assoc($result);
			    
			    // Get the blob image from the result set
			    $imageBlob = $row['ctzn_col_vouch'];
			    $fname = $row['col_rqstDOC_fname'];
			    
			    // Encode the image as a base64 string
			    $imageData = base64_encode($imageBlob);
			    
			    // Set the response header to json
			    header("Content-type: application/json");
			    
			    // Return the image data as a JSON object
			    echo json_encode(array($fname));
			} else {
			    echo "Error: " . mysqli_error($conn);
			}

// Close the connection
mysqli_close($conn);

*/
?>