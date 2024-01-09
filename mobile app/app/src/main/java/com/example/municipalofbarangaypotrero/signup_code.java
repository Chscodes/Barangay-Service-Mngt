package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.CountDownTimer;
import android.os.Handler;
import android.os.Bundle;
import android.os.Looper;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.vishnusivadas.advanced_httpurlconnection.PutData;

import java.util.Properties;
import java.util.Random;

import javax.mail.Authenticator;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

public class signup_code extends AppCompatActivity implements terns_dialog.vrbl_dialoglistener {

    TextView input_email, lbl_rsnd, lbl_sec;
    Button btn_cancel, btn_confirm, btn_resend;
    EditText i_code1, i_code2, i_code3, i_code4;
    private long pressedTime;
    String uname, pass, lname, fname, mname, email, address_Hnum, address_street, address_city, gender, bday, OTP_code;
    String codena; // nag generate ng random code
    ProgressBar pb_rsnd;

    CountDownTimer cd_time;
    private int remainingTime = 10;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_signup_code);

        Intent input_info = getIntent();

         uname = input_info.getStringExtra("uname");
         pass = input_info.getStringExtra("pass");
         lname = input_info.getStringExtra("lname");
         fname = input_info.getStringExtra("fname");
         mname = input_info.getStringExtra("mname");
         email = input_info.getStringExtra("email");

         address_Hnum = input_info.getStringExtra("address_Hnum");
         address_street = input_info.getStringExtra("address_street");
         address_city = input_info.getStringExtra("address_city");
         gender = input_info.getStringExtra("gender");
         bday = input_info.getStringExtra("bday");

         OTP_code = input_info.getStringExtra("code");

        input_email  =  findViewById(R.id.tv_code_email);
        i_code1 = findViewById(R.id.edt_code_code1);
        i_code2 = findViewById(R.id.edt_code_code2);
        i_code3 = findViewById(R.id.edt_code_code3);
        i_code4 = findViewById(R.id.edt_code_code4);
        btn_confirm = findViewById(R.id.btn_code_confirm);
        btn_cancel = findViewById(R.id.btn_code_cancel);
        btn_resend = findViewById(R.id.btn_sign_rsnd);
        pb_rsnd = findViewById(R.id.sign_code_pb);
        lbl_rsnd =findViewById(R.id.lbl_rs);
        lbl_sec = findViewById(R.id.lbl_sec);

        input_email.setText(email);

//para sa pag lipat ng focus sa edit text codes

        i_code1.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                if(i_code1.getText().toString().length() == 1){
                    i_code2.requestFocus();
                }
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        i_code2.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                if(i_code2.getText().toString().length() == 1) {
                    i_code3.requestFocus();
                }
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        i_code3.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                if(i_code3.getText().toString().length() == 1){
                    i_code4.requestFocus();
                }
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        //para sa pag lipat ng focus sa edit text codes (END)


    btn_cancel.setOnClickListener(new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            Intent i = new Intent(getApplicationContext(),SignUp.class);
            startActivity(i);
            finish();
        }
    });

    btn_confirm.setOnClickListener(new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            String input_code1, input_code2, input_code3, input_code4;

            input_code1 = String.valueOf(i_code1.getText());
            input_code2 = String.valueOf(i_code2.getText());
            input_code3 = String.valueOf(i_code3.getText());
            input_code4 = String.valueOf(i_code4.getText());

            String input_OTP = input_code1 + input_code2 + input_code3 + input_code4;


            if (input_code1.equals("") && input_code2.equals("") && input_code3.equals("") && input_code4.equals("") ){
                Toast.makeText(getApplicationContext(),"Please input the emailed OTP code", Toast.LENGTH_SHORT).show();
            }
            else if (!input_OTP.equals(OTP_code)){
                Toast.makeText(getApplicationContext(),"Please check the OTP code properly!", Toast.LENGTH_SHORT).show();
            }
            else{
                tg_dialog();
            }

        }
    });

    btn_resend.setOnClickListener(new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            sendOTPcode();
            btn_resend.setVisibility(View.GONE);
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
            btn_resend.setVisibility(View.VISIBLE);
            lbl_rsnd.setVisibility(View.GONE);
            lbl_sec.setVisibility(View.GONE);
            pb_rsnd.setVisibility(View.GONE);
        }
    }; //para sa function na after mag click ng resend code ng user ay ma lock ang button na resend (END)


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
            String vrbl_toReceive = String.valueOf(input_email.getText());

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


    //Terms and condition dialog
    public void tg_dialog() {
        //mag open ng dialog
        terns_dialog dialog = new terns_dialog();
        dialog.show(getSupportFragmentManager(), "Terms & Condition dialog");
        //mag open ng dialog (END)

    } //Terms and condition dialog (END)



    @Override
    public void texts(String agree) {
        String ctzn_agreement = agree.toString();
        input_email.setText(ctzn_agreement);

        if (!agree.equals("Agree")){
            Toast.makeText(getApplicationContext(),"You must agree to Terms & Condition!", Toast.LENGTH_SHORT).show();
        }
        else{
            //sign up function
            //vrbl_pb .setVisibility(View.VISIBLE);
            Handler handler = new Handler(Looper.getMainLooper());
            handler.post(() -> {
                //Starting Write and Read data with URL
                //Creating array for parameters
                String[] field = new String[11];
                field[0] = "ctzn_col_uname";
                field[1] = "ctzn_col_pass";
                field[2] = "ctzn_col_lname";
                field[3] = "ctzn_col_fname";
                field[4] = "ctzn_col_mname";
                field[5] = "ctzn_col_email";
                field[6] = "ctzn_col_addrss_Hnum";
                field[7] = "col_ctzn_addrss_street";
                field[8] = "col_ctzn_addrss_city";
                field[9] = "ctzn_col_gender";
                field[10] = "ctzn_col_bday";

                //Creating array for data
                String[] data = new String[11];
                data[0] = uname;
                data[1] = pass;
                data[2] = lname;
                data[3] = fname;
                data[4] = mname;
                data[5] = email;
                data[6] = address_Hnum;
                data[7] = address_street;
                data[8] = address_city;
                data[9] = gender;
                data[10] = bday;

                //PutData putData = new PutData("http://192.168.25.20/capstone/signup.php", "POST", field, data);
                PutData putData = new PutData(URLS.signup_URL, "POST", field, data);
                // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
                // http://192.168.131.74/capstone/signup.php (ip add sa cp)
                if (putData.startPut()) {
                    if (putData.onComplete()) {
                        //vrbl_pb.setVisibility(View.GONE);
                        String result = putData.getResult();
                        if(result.equals("Sign Up Success")){
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