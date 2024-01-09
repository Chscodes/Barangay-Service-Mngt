package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.ProgressDialog;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Toast;

import com.squareup.okhttp.OkHttpClient;
import com.squareup.okhttp.Request;
import com.squareup.okhttp.RequestBody;
import com.squareup.okhttp.Response;
import com.vishnusivadas.advanced_httpurlconnection.PutData;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.Calendar;
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

public class forgotpass extends AppCompatActivity  {
EditText vrbluname, vrblemail;
Button vrblbtnSubmit, vrblbtncancel;
    private long pressedTime;
    //para sa datetime picker
    private static final String TAG = "forgotpass";
    private DatePickerDialog.OnDateSetListener mDataSetListener;
    //para sa datetime picker END


    //para sa pag fetch ng data sa database
    private String strJson;
    private OkHttpClient client;
    private Response response;
    private RequestBody requestBody;
    private Request request;
    private ProgressDialog progressDialog;
    //para sa pag fetch ng data sa database (END)

    String codena; // variable ng code na ma email sa user
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_forgotpass);

        vrbluname = findViewById(R.id.edt_forgot_uname);
        vrblemail = findViewById(R.id.edt_email_forgot);
        vrblbtncancel = findViewById(R.id.btn_forgot_cancel);
        vrblbtnSubmit = findViewById(R.id.btn_forgot_submit);



        vrblbtnSubmit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String uname,email,bday;
                uname = String.valueOf(vrbluname.getText());
                email = String.valueOf(vrblemail.getText());

                if (uname.equals("") || email.equals("")) {
                    Toast.makeText(getApplicationContext(), "All fields are required!", Toast.LENGTH_SHORT).show();
                } else {




                   //client = new OkHttpClient();
                    //new GetUserDataRequest().execute(); //PrA mag execute ng function sa json na mag fetch ng data



                    Handler handler = new Handler(Looper.getMainLooper());
                    handler.post(() -> {



                        //Starting Write and Read data with URL
                        //Creating array for parameters
                        String[] field = new String[2];
                        field[0] = "ctzn_col_uname";
                        field[1] = "ctzn_col_email";

                        //Creating array for data
                        String[] data = new String[2];
                        data[0] = uname;
                        data[1] = email;

                        //PutData putData = new PutData("http://192.168.25.20/capstone/frgtPss_vrfy_ACC.php", "POST", field, data);
                        PutData putData = new PutData(URLS.forgotpass_URL, "POST", field, data);
                        // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
                        // http://192.168.131.74/capstone/signup.php (ip add sa cp)
                        if (putData.startPut()) {
                            if (putData.onComplete()) {
                                //vrbl_pb.setVisibility(View.GONE);
                                String result = putData.getResult();
                                if(result.equals("Account Exist")){


                                    sending_code(); //email verfication code

                                }
                                else {

                                    Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();

                                }
                            }
                        }
                        //End Write and Read data with URL

                    });        //PARA MAG VALIDATE NF EMAIL (END)


                }
            }
        });




/*
        //para sa datetime picker
        vrblbday.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Calendar cal = Calendar.getInstance();
                int year = cal.get(Calendar.YEAR);
                int month = cal.get(Calendar.MONTH);
                int day = cal.get(Calendar.DAY_OF_MONTH);

                DatePickerDialog dialog = new DatePickerDialog(
                        forgotpass.this,
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
        */

        //para sa cancel button
        vrblbtncancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(getApplicationContext(), MainActivity.class);
                startActivity(i);
                finish();
            }
        });
        //para sa cancel button END

    }
/*
    public class GetUserDataRequest extends AsyncTask<Void,Void,Void> {

        @Override
        protected Void doInBackground(Void... voids) {
            //Intent secAct = getIntent();
            //String username = secAct.getStringExtra("user"); //nag hold ng data sa uusername sa log in para malagay sa name as where clause

            String username = String.valueOf(vrbluname.getText());
            request = new Request.Builder().url("http://192.168.25.20/capstone/frgtPss_fetchPASS.php?user="+ username).build(); //pinalitan ko ang apiURL variabble ng rekta na link
            // http://192.168.25.20/capstone/ctzndata.php?user= (ip sa bahay)
            // http://192.168.131.74/capstone/ctzndata.php?user=  (ip sa cp)
            try {
                response = client.newCall(request).execute();
            } catch (IOException e) {
                e.printStackTrace();
            }

            return null;
        }

        @Override
        protected void onPostExecute(Void unused) {
            super.onPostExecute(unused);

            try {
                strJson = response.body().string();
                updateUserData(strJson);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    private void updateUserData(String strJson) {

        try {
            JSONArray parent = new JSONArray(strJson);
            JSONObject child = parent.getJSONObject(0);

            String fetch_pass = child.getString("ctzn_col_pass");






        } catch (JSONException e) {
            e.printStackTrace();
        }
    }






        //from dialog code passing here activity
    public void applytexts(String interface_code1, String interface_code2, String interface_code3, String interface_code4) {
        String toVerify_code = interface_code1 + interface_code2 + interface_code3 + interface_code4;

        Toast.makeText(getApplicationContext(), toVerify_code, Toast.LENGTH_SHORT).show();

    }//from dialog code passing here activity (END)
*/

    //VOID FOR OPENING DIALOG
    public void OpenDialog() {
        //mag open ng dialog
        forgot_verfy_dialog dialog = new forgot_verfy_dialog();
        dialog.show(getSupportFragmentManager(), "forgot verification dialog");
        //mag open ng dialog (END)

    }
    //VOID FOR SENDING EMAIL AND OPENING DIALOG (end)

    public void sending_code(){
//PARA SA PAG GENERATE NG RANDOM CODE SA PAG VERIFY NG EMAIL
        progressDialog = new ProgressDialog(forgotpass.this);
        progressDialog.setTitle("Please Wait...");
        progressDialog.setCanceledOnTouchOutside(false);
        progressDialog.show();

        Random rndm = new Random();
        int code  = rndm.nextInt(8999)+1000;

        codena = Integer.toString(code);

        String uname = String.valueOf(vrbluname.getText());
        String email = String.valueOf(vrblemail.getText());

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
                        progressDialog.dismiss();
                        Intent i = new Intent(getApplicationContext(),Reset_Pass.class);
                        i.putExtra("user", uname);
                        i.putExtra("email", email);
                        i.putExtra("code", codena);
                        startActivity(i);
                        finish();


                    } catch (MessagingException e) {
                        e.printStackTrace();


                    }
                }
            });
            thread.start();






        } catch (MessagingException e) {
            e.printStackTrace();
        }
//PARA SA PAG EMAIL NG CODE NA GENERATE FOR VERIFICATION (END)
    }
    //VOID FOR SENDING EMAIL (end)

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