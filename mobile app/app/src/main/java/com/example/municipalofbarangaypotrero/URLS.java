package com.example.municipalofbarangaypotrero;

public class URLS {
    //my phone data ipaddress(192.168.127.74)


    public static final String ROOT_IP = "http://192.168.145.74/capstone/";
    //public static final String ROOT_IP = "http://chsdcode.epizy.com/";

    //random
    public static final String login_URL = ROOT_IP + "login.php";
    public static final String forgotpass_URL = ROOT_IP + "frgtPss_vrfy_ACC.php";
    public static final String profile_URL = ROOT_IP + "ctzndata.php";
    public static final String viewReq_URL = ROOT_IP + "reqdata.php";
    public static final String request_URL = ROOT_IP + "pic_upload.php";
    public static final String resetpass_URL = ROOT_IP + "reset_pass.php";
    public static final String signup_URL = ROOT_IP + "signup.php";

    //para mag verify if available ang docu
    public static final String docverify_URL = ROOT_IP + "doc_avail.php";

    //verify uname/email for sign up
    public static final String unameverify_URL = ROOT_IP + "uname_verify.php";
    public static final String emailverify_URL = ROOT_IP + "emailverification.php";
    public static final String cnclpndng = ROOT_IP + "cnclPndng.php";
    public static final String updt_action = ROOT_IP + "update_action.php";


    //validations sa pag request anti spam (request. class)
    public static final String validationPndng_URL = ROOT_IP + "reqdocu_validation_pndng.php";
    public static final String validationPrcss_URL = ROOT_IP + "reqdocu_validation_prcss.php";
    public static final String validationPck_URL = ROOT_IP + "reqdocu_validation_pickUp.php";
    public static final String validationdate_URL = ROOT_IP + "reqdocu_validation.php"; //para sa settled valid date of document

    //url para sa transactions status
    public static final String rprtPndng_URL = ROOT_IP + "req_track_history.php";
    public static final String rprtPrcss_URL = ROOT_IP + "req_track_history_prcss.php";
    public static final String rprtPck_URL = ROOT_IP + "req_track_history_pck.php";
    public static final String rprtsettled_URL = ROOT_IP + "req_track_history_settled.php";
    public static final String rprtdeclined_URL = ROOT_IP + "req_track_history_decline.php";
    public static final String rprtcancel_URL = ROOT_IP + "req_track_history_cancel.php";

}
