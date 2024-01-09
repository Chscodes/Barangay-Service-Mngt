<?php
require "DataBaseConfig.php";

class DataBase
{
    public $connect;
    public $data;
    private $sql;
    protected $servername;
    protected $username;
    protected $password;
    protected $databasename;

    public function __construct()
    {
        $this->connect = null;
        $this->data = null;
        $this->sql = null;
        $dbc = new DataBaseConfig();
        $this->servername = $dbc->servername;
        $this->username = $dbc->username;
        $this->password = $dbc->password;
        $this->databasename = $dbc->databasename;
    }

    function dbConnect()
    {
        $this->connect = mysqli_connect($this->servername, $this->username, $this->password, $this->databasename);
        return $this->connect;
    }

    function prepareData($data)
    {
        return mysqli_real_escape_string($this->connect, stripslashes(htmlspecialchars($data)));
    }

    function logIn($table, $username, $pass)
    {
        $vrbl_username = $this->prepareData($username);
        $vrbl_pass = $this->prepareData($pass);
        $this->sql = "select * from " . $table . " where ctzn_col_uname = '" . $vrbl_username . "'";
        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
            $dbuname = $row['ctzn_col_uname'];
            $dbpass = $row['ctzn_col_pass'];
            $dbID = $row['ctzn_ID'];
            $_POST['ctzn_col_uname'] = $dbuname;
                          

            if ($dbuname == $vrbl_username && $vrbl_pass == $dbpass) {
                $login = true;
            } else $login = false;
        } else $login = false;

        return $login;
    }
 function verify_reqdocu($tbl_docsreq, $lname, $fname, $mname, $docu_type)
    {
        $input_lname = $this->prepareData($lname);
        $input_fname = $this->prepareData($fname);
        $input_mname = $this->prepareData($mname);
        $input_docu_type = $this->prepareData($docu_type);
 
        $this->sql = "SELECT
                        tbl_docsreq.`ID` AS 'REQID',
                        tbl_docs_settled.`col_validation` AS 'Valid',
                        tbl_docsreq.col_req_refNum AS 'RefNUm',
                        tbl_docsreq.col_rqstDOC_lname AS 'Lastname',
                        tbl_docsreq.col_rqstDOC_fname AS 'Firstname',
                        tbl_docsreq.col_rqstDOC_mname AS 'Middlename',
                        tbl_docsreq.col_rqstDOC_docsType AS 'Document'
                    FROM
                        `tbl_docsreq`
                    INNER JOIN `tbl_docs_settled` ON tbl_docsreq.ID = tbl_docs_settled.col_req_ID
                    WHERE
                        tbl_docsreq.col_rqstDOC_lname = '" . $input_lname . "' && tbl_docsreq.col_rqstDOC_fname = '" . $input_fname . "' && tbl_docsreq.col_rqstDOC_mname = '" . $input_mname . "'
                        && tbl_docsreq.col_rqstDOC_docsType = '" . $input_docu_type . "' && tbl_docs_settled.`col_validation` >= CURDATE()  ";

        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
           
            $reqdocu_validation = true;


        } else $reqdocu_validation = false;

        return $reqdocu_validation;
    }

    function verify_reqdocu_pndng($tbl_docsreq, $lname, $fname, $mname, $docu_type)
    {
        $input_lname = $this->prepareData($lname);
        $input_fname = $this->prepareData($fname);
        $input_mname = $this->prepareData($mname);
        $input_docu_type = $this->prepareData($docu_type);
 
        $this->sql = "select * from " . $tbl_docsreq . " where col_rqstDOC_lname = '" . $input_lname . "' && col_rqstDOC_fname = '" . $input_fname . "' && col_rqstDOC_mname = '" . $input_mname . "'
                        && col_rqstDOC_docsType = '" . $input_docu_type . "' && col_rqstDOC_action = 'Pending' ";

        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
            
           
            $reqdocu_validation_pndng = true;


        } else $reqdocu_validation_pndng = false;

        return $reqdocu_validation_pndng;
    }

     function verify_reqdocu_prcss($tbl_docsreq, $lname, $fname, $mname, $docu_type)
    {
        $input_lname = $this->prepareData($lname);
        $input_fname = $this->prepareData($fname);
        $input_mname = $this->prepareData($mname);
        $input_docu_type = $this->prepareData($docu_type);
 
        $this->sql = "SELECT
                        tbl_docs_processing.`col_reqID` AS 'REQID',
                        tbl_docsreq.col_req_refNum AS 'RefNUm',
                        tbl_docsreq.col_rqstDOC_lname AS 'Lastname',
                        tbl_docsreq.col_rqstDOC_fname AS 'Firstname',
                        tbl_docsreq.col_rqstDOC_mname AS 'Middlename',
                        tbl_docsreq.col_rqstDOC_docsType AS 'Document'
                    FROM
                        `tbl_docsreq`
                    INNER JOIN `tbl_docs_processing` ON tbl_docsreq.ID = tbl_docs_processing.col_reqID
                    WHERE
                        tbl_docsreq.col_rqstDOC_lname = '" . $input_lname . "' && tbl_docsreq.col_rqstDOC_fname = '" . $input_fname . "' && tbl_docsreq.col_rqstDOC_mname = '" . $input_mname . "'
                        && tbl_docsreq.col_rqstDOC_docsType = '" . $input_docu_type . "' && tbl_docs_processing.`col_action` = 'Processing' "; 

        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
           
            $reqdocu_validation_prcss = true;


        } else $reqdocu_validation_prcss = false;

        return $reqdocu_validation_prcss;
    }


function verify_reqdocu_pickUP($tbl_docsreq, $lname, $fname, $mname, $docu_type)
    {
        $input_lname = $this->prepareData($lname);
        $input_fname = $this->prepareData($fname);
        $input_mname = $this->prepareData($mname);
        $input_docu_type = $this->prepareData($docu_type);
 
        $this->sql = "SELECT
                        tbl_docs_pickup.`col_req_ID` AS 'REQID',
                        tbl_docsreq.col_req_refNum AS 'RefNUm',
                        tbl_docsreq.col_rqstDOC_lname AS 'Lastname',
                        tbl_docsreq.col_rqstDOC_fname AS 'Firstname',
                        tbl_docsreq.col_rqstDOC_mname AS 'Middlename',
                        tbl_docsreq.col_rqstDOC_docsType AS 'Document'
                    FROM
                        `tbl_docsreq`
                    INNER JOIN `tbl_docs_pickup` ON tbl_docsreq.ID = tbl_docs_pickup.col_req_ID
                    WHERE
                        tbl_docsreq.col_rqstDOC_lname = '" . $input_lname . "' && tbl_docsreq.col_rqstDOC_fname = '" . $input_fname . "' && tbl_docsreq.col_rqstDOC_mname = '" . $input_mname . "'
                        && tbl_docsreq.col_rqstDOC_docsType = '" . $input_docu_type . "' && tbl_docs_pickup.`col_action` = 'To Pick-up' "; 

        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
           
            $reqdocu_validation_pickUP = true;


        } else $reqdocu_validation_pickUP = false;

        return $reqdocu_validation_pickUP;
    }

function verify($table, $email)
    {
        $vrbl_email = $this->prepareData($email);
        $this->sql = "select * from " . $table . " where ctzn_col_email = '" . $vrbl_email . "'";
        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
            $fetch_email = $row['ctzn_col_email'];
            
            if ($fetch_email == $vrbl_email) {
                $emailverification = true;
            } else $emailverification = false;

        } else $emailverification = false;

        return $emailverification;
    }

    function cncl_pndng($table, $ref)
    {
        $andrd_ref = $this->prepareData($ref);
        $this->sql = "select * from " . $table . " where col_req_refNum = '" . $andrd_ref . "'";
        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
            $fetch_action = $row['col_rqstDOC_action'];
            
            if ($fetch_action == 'Pending') {
                $cnclPndng = true;
            } else $cnclPndng = false;

        } else $cnclPndng = false;

        return $cnclPndng;
    }

    function verify_availDOCU($table, $docu)
    {
        $vrbl_docu = $this->prepareData($docu);
        $this->sql = "select * from " . $table . " where col_Doc_name = '" . $vrbl_docu . "' &&  col_availability = 'AVAILABLE'";
        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
            $doc_avail = true;
        } else $doc_avail = false;

        return $doc_avail;
    }


function U_verify($table, $uname)
    {
        $vrbl_uname = $this->prepareData($uname);
        $this->sql = "select * from " . $table . " where ctzn_col_uname = '" . $vrbl_uname . "'";
        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
            $fetch_uname = $row['ctzn_col_uname'];
            
            if ($fetch_uname == $vrbl_uname) {
                $uname_verify = true;
            } else $uname_verify = false;

        } else $uname_verify = false;

        return $uname_verify;
    }

function verifyACC($table, $uname, $email) //for forgotpass
    {
        $vrbl_uname = $this->prepareData($uname);
        $vrbl_email = $this->prepareData($email);

        $this->sql = "select * from " . $table . " where ctzn_col_uname = '" . $vrbl_uname . "'";
        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
            $fetch_uname = $row['ctzn_col_uname'];
            $fetch_email = $row['ctzn_col_email'];
            if ($fetch_uname == $vrbl_uname && $fetch_email == $vrbl_email)  {
                $frgtPss_vrfy_ACC = true;
            } else $frgtPss_vrfy_ACC = false;

        } else $frgtPss_vrfy_ACC = false;

        return $frgtPss_vrfy_ACC;
    }

function reset_pass($table, $uname, $pass)
    {
        $input_uname = $this->prepareData($uname);
        $input_pass = $this->prepareData($pass);
        
        $this->sql =
            "UPDATE " . $table . "  SET  ctzn_col_pass = '" . $input_pass . "'WHERE ctzn_col_uname = '" . $input_uname . "'";
        if (mysqli_query($this->connect, $this->sql)) {
            return true;
        } else return false;
    } 

function update_action($table, $ref)
    {
        $andrd_ref = $this->prepareData($ref);
        
        
        $this->sql =
            "UPDATE " . $table . "  SET  col_rqstDOC_action = 'Canceled' WHERE col_req_refNum = '" . $andrd_ref . "'";
        if (mysqli_query($this->connect, $this->sql)) {
            return true;
        } else return false;
    } 




    function signUp($table, $uname, $pass, $lname, $fname, $mname,$email, $addrss_Hnum, $addrss_street, $addrss_city ,$gender, $bday)
    {
        $vrbl_uname = $this->prepareData($uname);
        $vrbl_pass = $this->prepareData($pass);
        $vrbl_fname = $this->prepareData($fname);
        $vrbl_lname = $this->prepareData($lname);
        $vrbl_mname = $this->prepareData($mname);
        $vrbl_email = $this->prepareData($email);
        $vrbl_addrss_hnum = $this->prepareData($addrss_Hnum);
        $vrbl_addrss_street = $this->prepareData($addrss_street);
        $vrbl_addrss_city = $this->prepareData($addrss_city);
        $vrbl_gender = $this->prepareData($gender);
        $vrbl_bday = $this->prepareData($bday);
        $this->sql =
            "INSERT INTO " . $table . " (ctzn_col_uname, ctzn_col_pass, ctzn_col_lname, ctzn_col_fname, ctzn_col_mname, ctzn_col_email, ctzn_col_addrss_Hnum,col_ctzn_addrss_street, col_ctzn_addrss_city, ctzn_col_gender, ctzn_col_bday) VALUES ('" . $vrbl_uname . "','" . $vrbl_pass . "','" . $vrbl_lname . "','" . $vrbl_fname . "','" . $vrbl_mname . "','" . $vrbl_email . "','" . $vrbl_addrss_hnum . "','" . $vrbl_addrss_street . "','" . $vrbl_addrss_city . "','" . $vrbl_gender . "' ,'" . $vrbl_bday . "')";
        if (mysqli_query($this->connect, $this->sql)) {
            return true;
        } else return false;
    } 



 function reqWPIC($table, $vouch_pic, $ctzn_Pic, $lname, $fname, $mname, $address,$gender,$rsdnt, $stat, $year, $cnum, $ctzn, $pday, $bday, $spouse, $childs, $docu, $purp, $uname, $action, $ref)
    {
        $imgVouch = base64_decode($vouch_pic);
        $imgctzn = base64_decode($ctzn_Pic);

        $v_lname = $this->prepareData($lname);
        $v_fname = $this->prepareData($fname);
        $v_mname = $this->prepareData($mname);
        $v_add = $this->prepareData($address);
        $v_year = $this->prepareData($year);
        $v_cnum = $this->prepareData($cnum);
        $v_ctzn = $this->prepareData($ctzn);
        $v_bday = $this->prepareData($bday);
        $v_pday = $this->prepareData($pday);
        $v_spouse = $this->prepareData($spouse);
        $v_childs = $this->prepareData($childs);
        $v_rsdnt = $this->prepareData($rsdnt);
        $v_gender = $this->prepareData($gender);
        $v_stat = $this->prepareData($stat);
        $v_docu = $this->prepareData($docu);
        $v_purp = $this->prepareData($purp);
        $v_act = $this->prepareData($action);
        $v_uname = $this->prepareData($uname);
        $v_ref = $this->prepareData($ref);

$this->sql =
            "INSERT INTO " . $table . " ( ctzn_col_vouch, ctzn_col_ctznPIC, col_rqstDOC_lname, col_rqstDOC_fname, col_rqstDOC_mname, col_rqstDOC_address, col_rqstDOC_residency, col_rqstDOC_year, col_rqstDOC_gender, col_rqstDOC_cnum, col_rqstDOC_ctznshp, col_rqstDOC_bday, col_rqstDOC_pday, col_rqstDOC_status, col_rqstDOC_spouse, col_rqstDOC_childrens, col_rqstDOC_docsType, col_rqstDOC_purpose, col_rqstDOC_action, col_ctzn_requname, col_req_refNum) 
            VALUES 
                (?, ?,  '" . $v_lname . "','" . $v_fname . "','" . $v_mname . "','" . $v_add . "','" . $v_rsdnt . "','" . $v_year . "','" . $v_gender . "','" . $v_cnum . "' ,'" . $v_ctzn . "','" . $v_bday . "','" . $v_pday . "','" . $v_stat . "','" . $v_spouse . "','" . $v_childs . "','" . $v_docu . "','" . $v_purp . "','" . $v_act . "','" . $v_uname . "','" . $v_ref . "' )";

            $stmt = mysqli_prepare($this->connect, $this->sql);
         
             mysqli_stmt_bind_param($stmt,"ss",$imgVouch,$imgctzn);
             //mysqli_stmt_bind_param($stmt,"s",$imgctzn);

            mysqli_stmt_execute($stmt);
         
         $check = mysqli_stmt_affected_rows($stmt);

            if ($check >= 1)
            {
                return true;
            } else return false;
            mysqli_close($this->connect);
     





        
/*

        $filename="IMG".rand().".jpg";
        
        file_put_contents("image/".$filename,base64_decode($pic));

       

        $put_picture = file_put_contents("image/".$filename,base64_decode($pic));
        //$image_name = mysql_real_escape_string($_FILES[$filename] ["name"]);
        //$imageData = mysql_real_escape_string(file_get_contents("image/".$filename,base64_decode($pic)));
        //$imageData = mysql_real_escape_string(file_get_contents($_FILES[$pic] ["tmp_name"]));
        //$imageType = mysql_real_escape_string($_FILES[$pic] ["type"]);

        
        
            $this->sql =
                        "INSERT INTO " . $table . " (ctzn_col_picB) VALUES ('" . $pic . "')";
                    if (mysqli_query($this->connect, $this->sql)) 
                    {
                        return true;
                    } else return false;
        */


    } 



/* // unang request query ko pinalitan ko muna sa function (reqWPIC)

     function request($table, $lname, $fname, $mname, $address,$year, $cnum, $ctzn, $bday, $pday, $spouse, $childs, $rsdnt, $gender, $stat, $docu, $purp, $action, $uname)
    {
        $v_lname = $this->prepareData($lname);
        $v_fname = $this->prepareData($fname);
        $v_mname = $this->prepareData($mname);
        $v_add = $this->prepareData($address);
        $v_year = $this->prepareData($year);
        $v_cnum = $this->prepareData($cnum);
        $v_ctzn = $this->prepareData($ctzn);
        $v_bday = $this->prepareData($bday);
        $v_pday = $this->prepareData($pday);
        $v_spouse = $this->prepareData($spouse);
        $v_childs = $this->prepareData($childs);
        $v_rsdnt = $this->prepareData($rsdnt);
        $v_gender = $this->prepareData($gender);
        $v_stat = $this->prepareData($stat);
        $v_docu = $this->prepareData($docu);
        $v_purp = $this->prepareData($purp);
        $v_act = $this->prepareData($action);
        $v_uname = $this->prepareData($uname);

        $this->sql =
            "INSERT INTO " . $table . " (col_rqstDOC_lname, col_rqstDOC_fname, col_rqstDOC_mname, col_rqstDOC_address, col_rqstDOC_residency, col_rqstDOC_year, col_rqstDOC_gender, col_rqstDOC_cnum, col_rqstDOC_ctznshp, col_rqstDOC_bday, col_rqstDOC_pday, col_rqstDOC_status, col_rqstDOC_spouse, col_rqstDOC_childrens, col_rqstDOC_docsType, col_rqstDOC_purpose, col_rqstDOC_action, col_ctzn_requname) VALUES ('" . $v_lname . "','" . $v_fname . "','" . $v_mname . "','" . $v_add . "','" . $v_rsdnt . "','" . $v_year . "','" . $v_gender . "','" . $v_cnum . "' ,'" . $v_ctzn . "','" . $v_bday . "','" . $v_pday . "','" . $v_stat . "','" . $v_spouse . "','" . $v_childs . "','" . $v_docu . "','" . $v_purp . "','" . $v_act . "','" . $v_uname . "')";
        if (mysqli_query($this->connect, $this->sql)) {
            return true;
        } else return false;
    } 
    */

}


?>
