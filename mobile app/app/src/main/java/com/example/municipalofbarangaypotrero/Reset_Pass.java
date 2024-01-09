package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.Handler;
import android.os.Looper;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.vishnusivadas.advanced_httpurlconnection.PutData;

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

public class Reset_Pass extends AppCompatActivity {
    private long pressedTime;
    TextView vrbl_email, lbl_rsnd, lbl_sec, passchar1, passchar2, passchar3, passchar4;
    EditText vrbl_pass1, vrbl_pass2, vrbl_code;
    Button btn_reset, btn_confirm, btn_cancel;

    String codena, OTP_code;; // nag generate ng random code
    ProgressBar pb_rsnd;

    CountDownTimer cd_time;
    private int remainingTime = 10;

    private ProgressDialog progressDialog;

    //para sa validation ng password
    Boolean pass1 = false;
    Boolean pass2 = false;
    Boolean pass3 = false;
    Boolean pass4 = false;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reset_pass);

        vrbl_email = findViewById(R.id.rest_email);
        vrbl_code= findViewById(R.id.edt_reset_code);
        vrbl_pass1 = findViewById(R.id.edt_reset_pass1);
        vrbl_pass2 = findViewById(R.id.edt_reset_pass2);

        btn_reset = findViewById(R.id.btn_reset_sndpass);
        btn_confirm = findViewById(R.id.btn_reset_confirm);
        btn_cancel = findViewById(R.id.btn_code_cancel);
        pb_rsnd = findViewById(R.id.sign_rsst_pb);

        lbl_rsnd = findViewById(R.id.lbl_rs_rsst);
        lbl_sec = findViewById(R.id.lbl_sec_rsst);


        passchar1 = findViewById(R.id.passvalid1);
        passchar2 = findViewById(R.id.passvalid2);
        passchar3 = findViewById(R.id.passvalid3);
        passchar4 = findViewById(R.id.passvalid4);



        Intent secAct = getIntent();
        String email = secAct.getStringExtra("email");
        String uname = secAct.getStringExtra("user");
         OTP_code = secAct.getStringExtra("code");

        vrbl_email.setText(email);

        btn_cancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(getApplicationContext(),forgotpass.class);
                startActivity(i);
                finish();
            }
        });


        btn_confirm.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String input_code, input_pass1,input_pass2;
                input_code = String.valueOf(vrbl_code.getText());
                input_pass1 = String.valueOf(vrbl_pass1.getText());
                input_pass2 = String.valueOf(vrbl_pass2.getText());


                if (input_code.equals("") && input_pass1.equals("") && input_pass2.equals("")){

                    Toast.makeText(getApplicationContext(),"All Fields are required",Toast.LENGTH_SHORT).show();

                }
                else if (!input_code.equals(OTP_code)) {

                    Toast.makeText(getApplicationContext(),"Please check your emailed OTP properly!",Toast.LENGTH_SHORT).show();
                }

                else if (pass1.equals(false)  || pass2.equals(false)   || pass3.equals(false)   || pass4.equals(false)  ) {
                    Toast.makeText(getApplicationContext(),"Please strengthen your password",Toast.LENGTH_SHORT).show();
                }

                else if (!input_pass1.equals(input_pass2)){
                    Toast.makeText(getApplicationContext(),"Password don't match!",Toast.LENGTH_SHORT).show();
                }


                else {

                    progressDialog = new ProgressDialog(Reset_Pass.this);
                    progressDialog.setTitle("Please Wait...");
                    progressDialog.setCanceledOnTouchOutside(false);
                    progressDialog.show();

                    Handler handler = new Handler(Looper.getMainLooper());
                    handler.post(() -> {
                        //Starting Write and Read data with URL
                        //Creating array for parameters
                        String[] field = new String[2];
                        field[0] = "ctzn_col_uname";
                        field[1] = "ctzn_col_pass";


                        //Creating array for data
                        String[] data = new String[2];
                        data[0] = uname;
                        data[1] = input_pass1;


                        //PutData putData = new PutData("http://192.168.25.20/capstone/reset_pass.php", "POST", field, data);
                        PutData putData = new PutData(URLS.resetpass_URL, "POST", field, data);
                        // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
                        // http://192.168.131.74/capstone/signup.php (ip add sa cp)
                        if (putData.startPut()) {
                            if (putData.onComplete()) {
                                //vrbl_pb.setVisibility(View.GONE);
                                String result = putData.getResult();
                                if(result.equals("Password updated sucessfully!")){
                                    progressDialog.dismiss();
                                    Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                                    Intent i = new Intent(getApplicationContext(),MainActivity.class);
                                    startActivity(i);
                                    finish();
                                }
                                else {
                                    Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                                }
                            }
                        }
                        //End Write and Read data with URL
                    });
                    //END SIGN UP
                }
            }
        });

        btn_reset.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                sendOTPcode();
                btn_reset.setVisibility(View.GONE);
                lbl_rsnd.setVisibility(View.VISIBLE);
                lbl_sec.setVisibility(View.VISIBLE);
                cd_time.start();
            }
        });


        //para sa function na after mag click ng resend code ng user ay ma lock ang button na resend
        cd_time = new CountDownTimer(30000,1000) {
            @Override
            public void onTick(long l) {
                remainingTime = (int) l / 1000;
                lbl_sec.setText(String.valueOf(remainingTime));
            }

            @Override
            public void onFinish() {
                btn_reset.setVisibility(View.VISIBLE);
                lbl_rsnd.setVisibility(View.GONE);
                lbl_sec.setVisibility(View.GONE);
                pb_rsnd.setVisibility(View.GONE);
            }
        }; //para sa function na after mag click ng resend code ng user ay ma lock ang button na resend (END)



        vrbl_pass1.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                String input_pass = vrbl_pass1.getText().toString();
                validatepass(input_pass);
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });
    }

    public void sendOTPcode(){ //para sa function after mag send ng email otp

        pb_rsnd.setVisibility(View.VISIBLE);

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
            String vrbl_toReceive = String.valueOf(vrbl_email.getText());

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
                        OTP_code = codena; //para mag change ng code ng sa otp if ni reset


                        //pb_rsnd.setVisibility(View.GONE);
                        //Toast.makeText(signup_code.this, "OTP succesfully send to your email", Toast.LENGTH_SHORT).show();


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
            pass2 = false;
        } else {
            passchar2.setTextColor(Color.parseColor("#16a085"));
            pass2 = true;
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