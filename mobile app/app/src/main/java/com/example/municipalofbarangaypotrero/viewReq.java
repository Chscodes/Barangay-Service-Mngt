package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.util.Base64;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.google.androidgamesdk.gametextinput.Listener;
import com.squareup.okhttp.OkHttpClient;
import com.squareup.okhttp.Request;
import com.squareup.okhttp.RequestBody;
import com.squareup.okhttp.Response;
import com.vishnusivadas.advanced_httpurlconnection.PutData;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;

public class viewReq extends AppCompatActivity {
    TextView tv_refnum;
    EditText edt_fname, edt_lname, edt_mname,  edt_docs, edt_purp, edt_address, edt_bday, edt_residency, edt_gender, edt_ctzn, edt_pday, edt_stats, edt_cpnum, edt_yrs, edt_spouse, edt_child;
    Button btn_cancel;

    private String strJson;
    private OkHttpClient client;
    private Response response;
    private RequestBody requestBody;
    private Request request;
    private ProgressDialog progressDialog;

    private long pressedTime;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_req);

        tv_refnum = findViewById(R.id.view_value_refnum);
        edt_fname = findViewById(R.id.edtFname_view);
        edt_lname = findViewById(R.id.edtLname_view);
        edt_mname = findViewById(R.id.edtMname_view);

        edt_docs = findViewById(R.id.edt_view_docutype);
        edt_purp = findViewById(R.id.edt_view_purp);

        edt_address = findViewById(R.id.edtaddress_view);
        edt_bday = findViewById(R.id.edt_view_bday);
        edt_residency =findViewById(R.id.edtrsdncy_view);
        edt_gender = findViewById(R.id.edtgender_view);
        edt_ctzn = findViewById(R.id.edtctzn_view);
        edt_pday =  findViewById(R.id.edtpday_view);
        edt_stats = findViewById(R.id.edtmarital_view);
        edt_cpnum = findViewById(R.id.edtcnum_view);
        edt_yrs= findViewById(R.id.edtdays_view);
        edt_spouse= findViewById(R.id.edtwife_view);
        edt_child = findViewById(R.id.edtchild_view);

        btn_cancel = findViewById(R.id.btn_view_cancel);



        //tv_refnum.setText(getIntent().getExtras().getString("ref_num"));
        Intent secAct = getIntent();
        String reference_num = secAct.getStringExtra("ref_num"); //nag hold ng data sa uusername sa log in para malagay sa name as where clause
        tv_refnum.setText(reference_num);

        progressDialog = new ProgressDialog(this);
        progressDialog.setTitle("Retrieving data please wait...");
        progressDialog.setCanceledOnTouchOutside(false);
        progressDialog.show();

       client = new OkHttpClient();
       new viewReq.GetUserDataRequest().execute(); //PrA mag execute ng function sa json na mag fetch ng data


        btn_cancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {



                Handler handler = new Handler(Looper.getMainLooper());
                handler.post(() -> {

                    //Starting Write and Read data with URL
                    //Creating array for parameters
                    String[] field = new String[1];
                    field[0] = "refNum";



                    //Creating array for data
                    String[] data = new String[1];
                    data[0] = reference_num;




                    PutData putData = new PutData(URLS.cnclpndng, "POST", field, data);

                    if (putData.startPut()) {
                        if (putData.onComplete()) {

                            String result = putData.getResult();
                            if(result.equals("Can cancel")){
                                cancel_req();
                            }
                            else {
                                Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                            }
                        }
                    }
                    //End Write and Read data with URL

                });

            }
        });

    }


    public void cancel_req(){

        Intent secAct = getIntent();
        String reference_num = secAct.getStringExtra("ref_num"); //nag hold ng data sa uusername sa log in para malagay sa name as where clause

        Handler handler = new Handler(Looper.getMainLooper());
        handler.post(() -> {

            //Starting Write and Read data with URL
            //Creating array for parameters
            String[] field = new String[1];
            field[0] = "refNum";



            //Creating array for data
            String[] data = new String[1];
            data[0] = reference_num;




            PutData putData = new PutData(URLS.updt_action, "POST", field, data);

            if (putData.startPut()) {
                if (putData.onComplete()) {

                    String result = putData.getResult();
                    if(result.equals("Request Canceled successfully!")){
                        Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                        finish();
                    }
                    else {
                        Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                    }
                }
            }
            //End Write and Read data with URL

        });


    }


/*
    public void setImage(String reference_num) {
        try {
            // Open connection to PHP script
            //Intent secAct = getIntent();
            //String reference_num = secAct.getStringExtra("ref_num"); //nag hold ng data sa uusername sa log in para malagay sa name as where clause

            URL url = new URL("http://192.168.127.74/capstone/reqdata.php?ref_num="+ reference_num);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setDoInput(true);
            connection.connect();

            // Get input stream and decode image
            InputStream input = connection.getInputStream();
            Bitmap image = BitmapFactory.decodeStream(input);

            // Set image to ImageView
            iv_vouch.setImageBitmap(image);
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
    */

    public class GetUserDataRequest extends AsyncTask<Void,Void,Void> {

        @Override
        protected Void doInBackground(Void... voids) {
            //String reference_num = String.valueOf(tv_refnum.getText());
            Intent secAct = getIntent();
            String reference_num = secAct.getStringExtra("ref_num"); //nag hold ng data sa uusername sa log in para malagay sa name as where clause

            request = new Request.Builder().url(URLS.viewReq_URL+"?ref_num="+ reference_num).build();

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




            String fname = child.getString("col_rqstDOC_fname");

          String lname = child.getString("col_rqstDOC_lname");
            String mname = child.getString("col_rqstDOC_mname");

            String docstype = child.getString("col_rqstDOC_docsType");
            String purpose = child.getString("col_rqstDOC_purpose");

            String address = child.getString("col_rqstDOC_address");
            String bday = child.getString("col_rqstDOC_bday");
            String rsdncy = child.getString("col_rqstDOC_residency");

            String gender = child.getString("col_rqstDOC_gender");
            String ctzn = child.getString("col_rqstDOC_ctznshp");

            String pday = child.getString("col_rqstDOC_pday");
            String stats = child.getString("col_rqstDOC_status");
            String cpnum = child.getString("col_rqstDOC_cnum");

            String yrs = child.getString("col_rqstDOC_year");
            String spouse = child.getString("col_rqstDOC_spouse");
            String children = child.getString("col_rqstDOC_childrens");

            edt_fname.setText(fname);
            edt_lname.setText(lname);
            edt_mname.setText(mname);

            edt_docs.setText(docstype);
            edt_purp.setText(purpose);


            edt_address.setText(address);
            edt_bday.setText(bday);
            edt_residency.setText(rsdncy);
            edt_gender.setText(gender);
            edt_ctzn.setText(ctzn);
            edt_pday.setText(pday);
            edt_stats.setText(stats);
            edt_cpnum.setText(cpnum);
            edt_yrs.setText(yrs);
            edt_spouse.setText(spouse);
            edt_child.setText(children);

            progressDialog.hide();


        } catch (JSONException e) {
            e.printStackTrace();
        }
    }


}