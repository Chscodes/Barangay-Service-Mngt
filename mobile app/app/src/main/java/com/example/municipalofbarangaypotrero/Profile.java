package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.squareup.okhttp.OkHttpClient;
import com.squareup.okhttp.Request;
import com.squareup.okhttp.RequestBody;
import com.squareup.okhttp.Response;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;

public class Profile extends AppCompatActivity {
    TextView vrbl_lname, vrbl_ID, vrbl_fname;
    //try passing uname
   // Intent secAct = getIntent();
    //String res = secAct.getStringExtra("user");
    //String username = res; //placeholder lang sa username
    //String username = "test"; //placeholder lang sa username
    private String strJson;// , apiUrl= "http://192.168.25.20/capstone/ctzndata.php?user="+ username; //nilagay mismo ang link sa baba
    private OkHttpClient client;
    private Response response;
    private RequestBody requestBody;
    private Request request;
    private ProgressDialog progressDialog;

    private long pressedTime;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);

        vrbl_lname = findViewById(R.id.tv_f3_lname);
        vrbl_ID = findViewById(R.id.tv_f3_userID);
        vrbl_fname = findViewById(R.id.tv_f3_fname);

        progressDialog = new ProgressDialog(this);
        progressDialog.setTitle("Please Wait...");
        progressDialog.setCanceledOnTouchOutside(false);
        progressDialog.show();

        client = new OkHttpClient();
        new GetUserDataRequest().execute(); //PrA mag execute ng function sa json na mag fetch ng data

        Button btnlogout = findViewById(R.id.btn_P_logout);
        btnlogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(getApplicationContext(),MainActivity.class);
                startActivity(i);
                finish();
            }
        });

        Button btnCancel = findViewById(R.id.btn_P_cancel);
        btnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent secAct = getIntent();
                String inputUname = secAct.getStringExtra("user");

                Intent i = new Intent(getApplicationContext(),New_MainMenu.class);
                i.putExtra("user", inputUname);
                startActivity(i);
                finish();
            }
        });

    }
    public class GetUserDataRequest extends AsyncTask<Void,Void,Void> {

        @Override
        protected Void doInBackground(Void... voids) {
            Intent secAct = getIntent();
            String username = secAct.getStringExtra("user"); //nag hold ng data sa uusername sa log in para malagay sa name as where clause
            //request = new Request.Builder().url("http://192.168.25.20/capstone/ctzndata.php?user="+ username).build(); //pinalitan ko ang apiURL variabble ng rekta na link
            request = new Request.Builder().url(URLS.profile_URL+"?user="+ username).build();
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

            String lname = child.getString("ctzn_col_lname");
            String fname = child.getString("ctzn_col_fname");
            String id = child.getString("ctzn_ID");
            vrbl_lname.setText(lname);
            vrbl_fname.setText(fname);
            vrbl_ID.setText(id);
            progressDialog.hide();


        } catch (JSONException e) {
            e.printStackTrace();
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
