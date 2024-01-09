package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.text.Editable;
import android.text.InputType;
import android.text.TextWatcher;
import android.text.method.PasswordTransformationMethod;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.vishnusivadas.advanced_httpurlconnection.PutData;

import java.util.Calendar;
import java.util.Properties;
import java.util.Random;
import java.util.regex.Pattern;

import javax.mail.Authenticator;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

public class SignUp extends AppCompatActivity implements verification_dialog.vrbl_dialoglistener {
    private long pressedTime;
    EditText vrbl_uname, vrbllname, vrblfname, vrblmname, vrblpass, vrblpass2, vrbladd_hnum, vrbladd_street, vrblemail, vrblbday, code1,code2,code3,code4;
    Button vrblbtncheck, vrblbtnconfirm, btnvrblcancel;
    TextView passchar1, passchar2, passchar3, passchar4;

    RadioGroup vrblradiogroup;
    RadioButton vrblradio;
    ProgressBar vrbl_pb;

    String codena; // nag generate ng random code

    //para sa datetime picker
    private static final String TAG = "SignUP";
    private DatePickerDialog.OnDateSetListener mDataSetListener;
    //para sa datetime picker END

    //para sa validation ng password
    Boolean pass1 = false;
    Boolean pass2_ = false;
    Boolean pass3 = false;
    Boolean pass4 = false;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_up);

        vrbl_uname = findViewById(R.id.edt_signup_uname);
        vrblpass = findViewById(R.id.edt_signup_pass);
        vrblpass2 = findViewById(R.id.edt_signup_pass2);
        vrbllname = findViewById(R.id.edt_signup_lname);
        vrblfname = findViewById(R.id.edt_signup_fname);
        vrblmname = findViewById(R.id.edt_signup_mname);
        vrbladd_hnum = findViewById(R.id.edt_signup_addrss_Hnum);
        vrbladd_street = findViewById(R.id.edt_signup_addrss_street);
        vrblemail = findViewById(R.id.edt_signup_email); // email verify
        vrblbtncheck = findViewById(R.id.btn_code_confirm);
        btnvrblcancel = findViewById(R.id.btn_code_cancel);
        vrblradiogroup = findViewById(R.id.SG_RD_gender);
        vrbl_pb = findViewById(R.id.signup_progress);
        vrblbday = findViewById(R.id.edt_signup_bday);


        passchar1 = findViewById(R.id.pass_Svalid1);
        passchar2 = findViewById(R.id.pass_Svalid2);
        passchar3 = findViewById(R.id.pass_Svalid3);
        passchar4 = findViewById(R.id.pass_Svalid4);


        vrblpass.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                String input_pass = vrblpass.getText().toString();
                validatepass(input_pass);
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        //para sa datetime picker start
        vrblbday.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Calendar cal = Calendar.getInstance();
                int year = cal.get(Calendar.YEAR);
                int month = cal.get(Calendar.MONTH);
                int day = cal.get(Calendar.DAY_OF_MONTH);

                DatePickerDialog dialog = new DatePickerDialog(
                        SignUp.this,
                        android.R.style.Theme_Holo_Light_Dialog_MinWidth,
                        mDataSetListener,
                        year,month,day);
                dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                dialog.show();
            }
        });
        mDataSetListener = new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker datePicker, int year, int month, int day) {
                month = month +1;
                Log.d(TAG, "onDateSet: yyy/mm/dd:" + year + "/" + month + "/" + day);
                String date = year + "/" + month + "/" + day;
                vrblbday.setText(date);
            }
        };
        //para sa datetime picker END


        //para sa pag fill up (REGISTRATION)
        vrblbtncheck.setOnClickListener(view -> {


            //para sa value sa radio button
            int radioid = vrblradiogroup.getCheckedRadioButtonId();
            vrblradio = findViewById(radioid);
            //para sa value sa radio button "END"

            String uname,pass,pass2,lname,fname,mname,email,address_Hnum,address_street,address_city,gender,bday;
            uname = String.valueOf(vrbl_uname.getText());
            pass = String.valueOf(vrblpass.getText());
            pass2 = String.valueOf(vrblpass2.getText());
            lname = String.valueOf(vrbllname.getText());
            fname = String.valueOf(vrblfname.getText());
            mname = String.valueOf(vrblmname.getText());
            email = String.valueOf(vrblemail.getText());
            address_Hnum = String.valueOf(vrbladd_hnum.getText());
            address_street = String.valueOf(vrbladd_street.getText());
            //address_city = "Potrero, Malabon City";
           // gender = String.valueOf(vrblradio.getText());
            bday = String.valueOf(vrblbday.getText());



            if(uname.equals("") ) {
                Toast.makeText(getApplicationContext(),"Please input an username", Toast.LENGTH_SHORT).show();
            }

            else if (pass.equals("")){
                Toast.makeText(getApplicationContext(),"Please input your desired password", Toast.LENGTH_SHORT).show();
            }
            else if (pass2.equals("")){
                Toast.makeText(getApplicationContext(),"Please confirm your password", Toast.LENGTH_SHORT).show();
            }
            else if (lname.equals("")){
                Toast.makeText(getApplicationContext(),"Please input your surname", Toast.LENGTH_SHORT).show();
            }
            else if (fname.equals("")){
                Toast.makeText(getApplicationContext(),"Please input your firstname", Toast.LENGTH_SHORT).show();
            }
            else if (email.equals("")){
                Toast.makeText(getApplicationContext(),"Please input your active email", Toast.LENGTH_SHORT).show();
            }
            else if (bday.equals("")){
                Toast.makeText(getApplicationContext(),"Please input your date of birth", Toast.LENGTH_SHORT).show();
            }
            else if (address_Hnum.equals("")){
                Toast.makeText(getApplicationContext(),"Please input your residency house number", Toast.LENGTH_SHORT).show();
            }
            else if (address_street.equals("")){
                Toast.makeText(getApplicationContext(),"Please input your residency road name", Toast.LENGTH_SHORT).show();
            }
            else if (!pass.equals(pass2)){
                Toast.makeText(getApplicationContext(),"Passwords not match! ", Toast.LENGTH_SHORT).show();
            }
            else if (pass1.equals(false)  || pass2_.equals(false)  || pass3.equals(false)   || pass4.equals(false)  ) {
                Toast.makeText(getApplicationContext(),"Please strengthen your password",Toast.LENGTH_SHORT).show();
            }
            else{

                //Checking internet connection
                ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
                if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                        connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
                    //we are connected to a network

                    uname_validation(); //VOID UNANG VALIDATION
                }
                else{
                    Toast.makeText(getApplicationContext(),"Internet Connection Problem! ", Toast.LENGTH_SHORT).show();
                }
            }
        });

        //end REGISTRATION



//function cancel sign up
        btnvrblcancel.setOnClickListener(view -> {

            Intent i = new Intent(getApplicationContext(), MainActivity.class);
            startActivity(i);
            finish();


        });


//end function button sign up


    }


    @Override
    public void applytexts(String interface_code1, String interface_code2, String interface_code3, String interface_code4) {
        String toVerify_code = interface_code1 + interface_code2 + interface_code3 + interface_code4;



        //textView_code = findViewById(R.id.tv_lbl_acc);
        //textView_code.setText(toVerify_code);

        //MAG REGISTER NG ACCOUNT FUNCTION




        if (toVerify_code.equals(codena)) {

        } else {
            Toast.makeText(getApplicationContext(),"Please check your verification code! ", Toast.LENGTH_SHORT).show();
        }

//MAG REGISTER NG ACCOUNT FUNCTION (END)
    }
    //VOID FOR OPENING DIALOG
    public void OpenDialog() {
        //mag open ng dialog
        verification_dialog dialog = new verification_dialog();
        dialog.show(getSupportFragmentManager(), "verification dialog");
        //mag open ng dialog (END)

    }
    //VOID FOR SENDING EMAIL AND OPENING DIALOG (end)





//(First Validation) Username Validation
    public void uname_validation(){

        vrbl_pb .setVisibility(View.VISIBLE);
        Handler handler = new Handler(Looper.getMainLooper());
        handler.post(() -> {

            String uname;
            uname = String.valueOf(vrbl_uname.getText());


            //Starting Write and Read data with URL
            //Creating array for parameters
            String[] field = new String[1];
            field[0] = "ctzn_col_uname";

            //Creating array for data
            String[] data = new String[1];
            data[0] = uname;

            //PutData putData = new PutData("http://192.168.25.20/capstone/uname_verify.php", "POST", field, data);
            PutData putData = new PutData(URLS.unameverify_URL, "POST", field, data);
            // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
            // http://192.168.131.74/capstone/signup.php (ip add sa cp)
            if (putData.startPut()) {
                if (putData.onComplete()) {
                    vrbl_pb.setVisibility(View.GONE);
                    String result = putData.getResult();
                    if(result.equals("Username already used!")){
                        Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                    }
                    else {

                        email_validation(); //para mag send ng code sa email for verificartion

                    }
                }
            }
            //End Write and Read data with URL
        });

    }

    //(First Validation) Username Validation (END)


    //(SECOND VALIDATION) email validation
    public void email_validation(){
        //PARA MAG VALIDATE NF EMAIL
        vrbl_pb .setVisibility(View.VISIBLE);
        Handler handler = new Handler(Looper.getMainLooper());
        handler.post(() -> {

            String email;
            email = String.valueOf(vrblemail.getText());


            //Starting Write and Read data with URL
            //Creating array for parameters
            String[] field = new String[1];
            field[0] = "ctzn_col_email";

            //Creating array for data
            String[] data = new String[1];
            data[0] = email;

            //PutData putData = new PutData("http://192.168.25.20/capstone/emailverification.php", "POST", field, data);
            PutData putData = new PutData(URLS.emailverify_URL, "POST", field, data);
            // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
            // http://192.168.131.74/capstone/signup.php (ip add sa cp)
            if (putData.startPut()) {
                if (putData.onComplete()) {
                    vrbl_pb.setVisibility(View.GONE);
                    String result = putData.getResult();
                    if(result.equals("Email already used!")){
                        Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                    }
                    else {

                        sending_code(); //para mag send ng code sa email for verificartion

                    }
                }
            }
            //End Write and Read data with URL

        });        //PARA MAG VALIDATE NF EMAIL (END)



    } //(SECOND VALIDATION) email validation  (END)




    //(NExt for second validation) VOID FOR SENDING EMAIL

    public void sending_code(){

//PARA SA PAG GENERATE NG RANDOM CODE SA PAG VERIFY NG EMAIL
        Random rndm = new Random();
        int code  = rndm.nextInt(8999)+1000;

        codena = Integer.toString(code);
        //textview4 = findViewById(R.id.tvtvtv);
        //textview4.setText(codena);

//PARA SA PAG GENERATE NG RANDOM CODE SA PAG VERIFY NG EMAIL (END)


        //PARA SA PAG EMAIL NG CODE NA GENERATE FOR VERIFICATION
        try {

            String vrbl_emailtoSend = "bargypotrero@gmail.com";
            String vrbl_emailpass= "kuzbrbfwdkbymoaz";
            String vrbl_toReceive = String.valueOf(vrblemail.getText());

            String stringHost = "smtp.gmail.com";

            Properties vrbl_prprts = System.getProperties();

            vrbl_prprts.put("mail.smtp.host", stringHost);
            vrbl_prprts.put("mail.smtp.port", "465");
            vrbl_prprts.put("mail.smtp.ssl.enable", "true");
            vrbl_prprts.put("mail.smtp.auth", "true");

            javax.mail.Session vrbl_session = Session.getInstance(vrbl_prprts, new Authenticator() {
                @Override
                protected PasswordAuthentication getPasswordAuthentication() {
                    return new PasswordAuthentication(vrbl_emailtoSend, vrbl_emailpass);
                }
            });

            MimeMessage mimeMessage = new MimeMessage(vrbl_session);

            mimeMessage.addRecipient(Message.RecipientType.TO, new InternetAddress(vrbl_toReceive));

            mimeMessage.setSubject("One Time Password");
            mimeMessage.setText("Hello! GOOD DAY!, \n\nYour OTP code is: "+ codena);

            Thread thread = new Thread(new Runnable() {
                @Override
                public void run() {
                    try {
                        Transport.send(mimeMessage); //MAG SEND NG EMAIL

                        open_codeActivity(); //mag open ng activity para sa otp


                    } catch (MessagingException e) {
                        e.printStackTrace();
                    }
                }
            });
            thread.start();






        } catch (MessagingException e) {
            e.printStackTrace();
        }
    }  //VOID FOR SENDING EMAIL (end)



    public void open_codeActivity(){ //Mag open ng code ACtivity


        //para sa value sa radio button
        int radioid = vrblradiogroup.getCheckedRadioButtonId();
        vrblradio = findViewById(radioid);
        //para sa value sa radio button "END"

        String uname,pass,lname,fname,mname,email,address_Hnum,address_street,address_city,gender,bday;
        uname = String.valueOf(vrbl_uname.getText());
        pass = String.valueOf(vrblpass.getText());
        lname = String.valueOf(vrbllname.getText());
        fname = String.valueOf(vrblfname.getText());
        mname = String.valueOf(vrblmname.getText());
        email = String.valueOf(vrblemail.getText());
        address_Hnum = String.valueOf(vrbladd_hnum.getText());
        address_street = String.valueOf(vrbladd_street.getText());
        address_city = "Potrero, Malabon City";
        gender = String.valueOf(vrblradio.getText());
        bday = String.valueOf(vrblbday.getText());

        Intent i = new Intent(getApplicationContext(),signup_code.class);
        i.putExtra("uname", uname);
        i.putExtra("pass", pass);
        i.putExtra("lname", lname);
        i.putExtra("fname", fname);
        i.putExtra("mname", mname);
        i.putExtra("email", email);

        i.putExtra("address_Hnum", address_Hnum);
        i.putExtra("address_street", address_street);
        i.putExtra("address_city", address_city);
        i.putExtra("gender", gender);
        i.putExtra("bday", bday);

        i.putExtra("code", codena);
        startActivity(i);

        finish();

    } //Mag open ng code ACtivity (END)

    public void validatepass(String vrbl_pass1){
        Pattern lowercase = Pattern.compile("[a-z]");
        Pattern uppercase = Pattern.compile("[A-Z]");
        Pattern numerical = Pattern.compile("[0-9]");


        if (!lowercase.matcher(vrbl_pass1).find()){

            passchar4.setTextColor(Color.parseColor("#c0392b"));
            pass4 = false;
        } else {
            passchar4.setTextColor(Color.parseColor("#16a085"));
            pass4 = true;
        } // end

        if (!uppercase.matcher(vrbl_pass1).find()){

            passchar3.setTextColor(Color.parseColor("#c0392b"));
            pass3 = false;
        } else {
            passchar3.setTextColor(Color.parseColor("#16a085"));
            pass3 = true;
        } //end

        if (!numerical.matcher(vrbl_pass1).find()){

            passchar2.setTextColor(Color.parseColor("#c0392b"));
            pass2_ = false;
        } else {
            passchar2.setTextColor(Color.parseColor("#16a085"));
            pass2_ = true;
        } //end

        if (vrbl_pass1.length() < 8 ){

            passchar1.setTextColor(Color.parseColor("#c0392b"));
            pass1 = false;
        } else {
            passchar1.setTextColor(Color.parseColor("#16a085"));
            pass1 = true;
        }//end

    }



    @Override
    public void onBackPressed() {

        if (pressedTime + 2000 > System.currentTimeMillis()) {
            super.onBackPressed();
            finish();
        } else {
            Toast.makeText(getBaseContext(), "Swipe again to exit", Toast.LENGTH_SHORT).show();
        }
        pressedTime = System.currentTimeMillis();
    }
}