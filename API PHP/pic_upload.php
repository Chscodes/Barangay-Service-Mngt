<?php 
/* //inserting lang sa datbase hindi blob
require "DataBase.php";
$db = new DataBase();

if (isset($_POST['pic_upload']) ) 
{
    if ($db->dbConnect()) 
    {

      if ($db->pic("tbl_docsreq", $_POST['pic_upload'])) 
        {
           
            echo "Upload sucessfully!";

        } else echo "FAiled Upload";


    }else echo "Error: Database connection";



} else echo "All fields are required sublime";


*/

require "DataBase.php";
$db = new DataBase();


if (isset($_POST['vouch_pic']) && isset($_POST['imag']) && isset($_POST['pLname']) && isset($_POST['pFname']) && isset($_POST['pMname']) 
    && isset($_POST['pAdd'])  && isset($_POST['pGender'])  && isset($_POST['pRsdnt']) 
    && isset($_POST['pStat']) && isset($_POST['pYR']) && isset($_POST['pNume']) 
    && isset($_POST['pCtzn']) && isset($_POST['pPday']) && isset($_POST['pBday']) 
    && isset($_POST['pWife']) && isset($_POST['pChild']) && isset($_POST['pDocu'])  
    && isset($_POST['pPup']) && isset($_POST['pUser']) && isset($_POST['pAction']) && isset($_POST['pRefNum']) 




) 
{
    if ($db->dbConnect()) 
    {
        if ($db->reqWPIC("tbl_docsreq", $_POST['vouch_pic'], $_POST['imag'], $_POST['pLname'], $_POST['pFname'], $_POST['pMname'], $_POST['pAdd'] 
        , $_POST['pGender'] , $_POST['pRsdnt'] , $_POST['pStat'] , $_POST['pYR']  , $_POST['pNume'] , $_POST['pCtzn'] 
        , $_POST['pPday'], $_POST['pBday'], $_POST['pWife'], $_POST['pChild'], $_POST['pDocu'], $_POST['pPup']
        , $_POST['pUser'], $_POST['pAction'], $_POST['pRefNum']

           )            ) 
        {
           
            echo "Request Upload sucessfully!";

        } else echo "Request Failed";


    }else echo "Error: Database connection";

}else echo "All fields are required sublime";




/*
$con = mysqli_connect("localhost", "root","","db_brgypotrero");
if ($con == true) {

     if(isset($_POST['imag'])  && isset($_POST['pLname'])  )
 {


        $con = mysqli_connect("localhost", "root","","db_brgypotrero");
         //$imageee = $_POST['imag'];

          $imageee = base64_decode($_POST['imag']);
          //$lname = prepareData $_POST['pLname'];
          //$fname = $_POST['pFname'];
          //$mname = $_POST['pMname'];


         
         $sql = "INSERT INTO tbl_docsreq (ctzn_col_picB, col_rqstDOC_lname) 
         VALUES (?, $lname)";
         
         $stmt = mysqli_prepare($con,$sql);
         
         mysqli_stmt_bind_param($stmt,"s",$imageee);
         mysqli_stmt_execute($stmt);
         
         $check = mysqli_stmt_affected_rows($stmt);
         
         if($check == 1)
            {
                echo "Image Uploaded Successfully";
            }
        else
            {
                echo "Error Uploading Image";
            }
                mysqli_close($con);

 }  else{
        echo "Error";
 }

}
else "not";



*/


 ?>