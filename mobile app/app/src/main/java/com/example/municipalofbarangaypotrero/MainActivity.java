package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.Handler;
import android.os.Looper;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.vishnusivadas.advanced_httpurlconnection.PutData;

public class MainActivity extends AppCompatActivity {
    TextView tvsignin,tvforgot, tv_lbl, tv_sec;
    EditText edt_uname, edt_pass;
    Button btnlog;
   ProgressBar pBar;
   private long pressedTime;

   int attempt = 0; //for attempt log in

   //for countdown
    CountDownTimer cd_time;
    private int remainingTime = 10;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        tvforgot = findViewById(R.id.tv_login_forgotpass);
        tvsignin = findViewById(R.id.tv_clckble_signin);

        edt_uname = findViewById(R.id.edt_login_uname);
        edt_pass = findViewById(R.id.edt_login_pass);
        pBar = findViewById(R.id.progressBar);
        btnlog = findViewById(R.id.btn_login);


        tv_lbl =findViewById(R.id.tv_label);
        tv_sec = findViewById(R.id.tv_label_sec);


        //link for sign up
        tvsignin.setOnClickListener(view -> {
            Intent i = new Intent(getApplicationContext(), SignUp.class);
            startActivity(i);
            finish();
        });
        //link for forgot pass
        tvforgot.setOnClickListener(view -> {
            Intent i = new Intent(getApplicationContext(), forgotpass.class);
            startActivity(i);
            finish();
        });

        //function for log in
        btnlog.setOnClickListener(view -> {




            String uname,pass;
            uname = String.valueOf(edt_uname.getText());
            pass = String.valueOf(edt_pass.getText());


            if(!uname.equals("") && !pass.equals("") ) {

                if (attempt < 3) {
                    pBar .setVisibility(View.VISIBLE);
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
                        data[1] = pass;
                        //PutData putData = new PutData("http://localhost/capstone/login.php", "POST", field, data);
                        PutData putData = new PutData(URLS.login_URL, "POST", field, data);
                        // http://192.168.25.20/capstone/login.php (ip address bahay)
                        //  http://192.168.131.74/capstone/login.php (ip cp ko)
                        if (putData.startPut()) {
                            if (putData.onComplete()) {
                                pBar.setVisibility(View.GONE);
                                String result = putData.getResult();
                                if(result.equals("Login Successful")){
                                    Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                                    Intent i = new Intent(getApplicationContext(),New_MainMenu.class); //baka mag error kasi sa third frag ako mag send ng uname
                                    i.putExtra("user", uname);
                                    startActivity(i);
                                    finish();
                                }
                                else {
                                    attempt++;
                                    edt_uname.setText("");
                                    edt_pass.setText("");
                                    edt_uname.findFocus();
                                    Toast.makeText(getApplicationContext(),result + "\nLog In Attempt Left: " + attempt + "/3",Toast.LENGTH_SHORT).show();
                                }
                            }
                        }
                        //End Write and Read data with URL
                    });

                }
                else if(attempt==3){
                    Toast.makeText(getApplicationContext(),"Log in session is locked!", Toast.LENGTH_SHORT).show();
                    btnlog.setEnabled(false);
                    tv_lbl.setVisibility(View.VISIBLE);
                    tv_sec.setVisibility(View.VISIBLE);

                    edt_uname.setText("");
                    edt_pass.setText("");
                    edt_uname.findFocus();

                    cd_time.start();

                }



            }
            else{
                Toast.makeText(getApplicationContext(),"All Fields are required!", Toast.LENGTH_SHORT).show();
            }

        }); //end log in code

        cd_time = new CountDownTimer(60000,1000) {
            @Override
            public void onTick(long l) {
                remainingTime = (int) l / 1000;
                tv_sec.setText(String.valueOf(remainingTime));
            }

            @Override
            public void onFinish() {
                btnlog.setEnabled(true);
                tv_lbl.setVisibility(View.GONE);
                tv_sec.setVisibility(View.GONE);
                attempt = 0;
            }
        };

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