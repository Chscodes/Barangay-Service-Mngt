package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class requestH_list extends AppCompatActivity {
    private long pressedTime;
    private RecyclerView RV_report;
    private reqlist_adapter adapter;
    private List<report_req_hstry> report_list;
    private ImageView ivNULL;
    private ImageButton IB_hstryBACK;
    private TextView lblnull, lblAction;
    private ToggleButton tg_settled, tg_declined,  tg_cancel;
    private ProgressBar PB_load;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_request_hlist);

        RV_report =findViewById(R.id.ReqH_list);
        RV_report.setHasFixedSize(true);
        RV_report.setLayoutManager(new LinearLayoutManager(this));


        ivNULL = findViewById(R.id.iVNULLHH);
        lblnull =findViewById(R.id.lblnullHH);
        lblAction =findViewById(R.id.lbl_H_action);

        report_list = new ArrayList<>();
        Load_all_request_settled();

        IB_hstryBACK =findViewById(R.id.btn_h_back);


        tg_settled =findViewById(R.id.tg_Settled);
        tg_declined= findViewById(R.id.tg_Declined);
        tg_cancel = findViewById(R.id.tg_Cancel);

        PB_load =findViewById(R.id.HHpBLOAD);


        //PARA SA PAG PASS NG INPUT USERNAME NG USER -> STAARRTTT
        Intent secAct = getIntent();
        String inputUname = secAct.getStringExtra("user");//ito ang nag hold ng username sa log in
//PARA SA PAG PASS NG INPUT USERNAME NG USER -> ENNNNNDDDDDD




            IB_hstryBACK.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent i = new Intent(getApplicationContext(), New_MainMenu.class);
                    i.putExtra("user", inputUname);
                    startActivity(i);
                    finish();
                }
            });


            tg_settled.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    if (tg_settled.isChecked()) {
                        report_list.clear();
                        lblAction.setVisibility(View.GONE);
                        PB_load.setVisibility(View.VISIBLE);

                        tg_settled.setTextColor(Color.parseColor("#CC5913"));
                        tg_settled.setBackgroundResource(R.drawable.checked_btn_rprtbg); //on


                        tg_declined.setChecked(false);
                        tg_declined.setTextColor(Color.parseColor("#ffffff"));
                        tg_declined.setBackgroundResource(R.drawable.btn_rprtbg); //off


                        tg_cancel.setChecked(false);
                        tg_cancel.setTextColor(Color.parseColor("#ffffff"));
                        tg_cancel.setBackgroundResource(R.drawable.btn_rprtbg);// off
                        
                            Load_all_request_settled();

                    }
                }
            });

            tg_declined.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    if (tg_declined.isChecked()) {
                        report_list.clear();
                        lblAction.setVisibility(View.GONE);
                        PB_load.setVisibility(View.VISIBLE);


                        tg_declined.setTextColor(Color.parseColor("#CC5913"));
                        tg_declined.setBackgroundResource(R.drawable.checked_btn_rprtbg); //on


                        tg_settled.setChecked(false);
                        tg_settled.setTextColor(Color.parseColor("#ffffff"));
                        tg_settled.setBackgroundResource(R.drawable.btn_rprtbg);// off

                        tg_cancel.setChecked(false);
                        tg_cancel.setTextColor(Color.parseColor("#ffffff"));
                        tg_cancel.setBackgroundResource(R.drawable.btn_rprtbg);// off

                            Load_all_request_decline();

                    }
                }
            });


            tg_cancel.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    if (tg_cancel.isChecked()) {
                        report_list.clear();
                        lblAction.setVisibility(View.GONE);
                        PB_load.setVisibility(View.VISIBLE);

                        tg_cancel.setTextColor(Color.parseColor("#CC5913"));
                        tg_cancel.setBackgroundResource(R.drawable.checked_btn_rprtbg); //on

                        tg_declined.setChecked(false);
                        tg_declined.setTextColor(Color.parseColor("#ffffff"));
                        tg_declined.setBackgroundResource(R.drawable.btn_rprtbg); //off


                        tg_settled.setChecked(false);
                        tg_settled.setTextColor(Color.parseColor("#ffffff"));
                        tg_settled.setBackgroundResource(R.drawable.btn_rprtbg);// off

                        Load_all_request_cancel();

                    }
                }
            });
    }

    private void Load_all_request_cancel() {
        //PARA SA PAG PASS NG INPUT USERNAME NG USER -> STAARRTTT
        Intent secAct = getIntent();
        String inputUname = secAct.getStringExtra("user");//ito ang nag hold ng username sa log in
//PARA SA PAG PASS NG INPUT USERNAME NG USER -> ENNNNNDDDDDD

        //JsonArrayRequest request = new JsonArrayRequest("http://192.168.25.20/capstone/req_track_history_settled.php?user="+ inputUname, new Response.Listener<JSONArray>() {
        JsonArrayRequest request = new JsonArrayRequest(URLS.rprtcancel_URL+"?user="+ inputUname, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray array) {
                for (int i = 0; i < array.length(); i++){
                    try {
                        JSONObject obj = array.getJSONObject(i);

                        String db_docs = obj.getString("fetch_docstype").trim();
                        String db_refnum = obj.getString("fetch_ref_num").trim();
                        String db_lname = obj.getString("fetch_lname").trim();
                        String db_fname = obj.getString("fetch_fname").trim();
                        String db_mname = obj.getString("fetch_mname").trim();

                        report_req_hstry list = new report_req_hstry();
                        list.setDocs(db_docs);
                        list.setRefnum(db_refnum);
                        list.setLname(db_lname);
                        list.setFname(db_fname);
                        list.setMname(db_mname);

                        report_list.add(list);
                        ivNULL.setVisibility(View.GONE);
                        lblnull.setVisibility(View.GONE);
                        lblAction.setText("SETTLED REQUESTS");
                        lblAction.setVisibility(View.VISIBLE);
                        PB_load .setVisibility(View.GONE);

                    } catch (JSONException e) {

                        //Checking internet connection
                        ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
                        if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                                connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
                            //we are connected to a network
                            PB_load .setVisibility(View.GONE);
                            e.printStackTrace();
                        }
                        else{
                            PB_load .setVisibility(View.GONE);
                            Toast.makeText(getApplicationContext(),"Please check your internet connection! ", Toast.LENGTH_SHORT).show();
                        }
                    }

                }
                adapter = new reqlist_adapter(requestH_list.this, report_list);
                RV_report.setAdapter(adapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                //Checking internet connection
                ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
                if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                        connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
                    //we are connected to a network
                    PB_load .setVisibility(View.GONE);
                    //Toast.makeText(requestl_list.this, error.toString(), Toast.LENGTH_SHORT).show();
                    Toast.makeText(getApplicationContext(),"Please check your DATA connection! ", Toast.LENGTH_SHORT).show();
                }
                else{
                    PB_load .setVisibility(View.GONE);
                    Toast.makeText(getApplicationContext(),"Please check your internet connection! ", Toast.LENGTH_SHORT).show();
                }
            }
        });
        RequestQueue requestQueue = Volley.newRequestQueue(requestH_list.this);
        requestQueue.add(request);
    }

    //PARA SA PAG LOAD NG DATA SA ON sETTLED REQUEST
    private void Load_all_request_settled() {

        //PARA SA PAG PASS NG INPUT USERNAME NG USER -> STAARRTTT
        Intent secAct = getIntent();
        String inputUname = secAct.getStringExtra("user");//ito ang nag hold ng username sa log in
//PARA SA PAG PASS NG INPUT USERNAME NG USER -> ENNNNNDDDDDD

        //JsonArrayRequest request = new JsonArrayRequest("http://192.168.25.20/capstone/req_track_history_settled.php?user="+ inputUname, new Response.Listener<JSONArray>() {
        JsonArrayRequest request = new JsonArrayRequest(URLS.rprtsettled_URL+"?user="+ inputUname, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray array) {
                for (int i = 0; i < array.length(); i++){
                    try {
                        JSONObject obj = array.getJSONObject(i);

                        String db_docs = obj.getString("fetch_docstype").trim();
                        String db_refnum = obj.getString("fetch_ref_num").trim();
                        String db_lname = obj.getString("fetch_lname").trim();
                        String db_fname = obj.getString("fetch_fname").trim();
                        String db_mname = obj.getString("fetch_mname").trim();

                        report_req_hstry list = new report_req_hstry();
                        list.setDocs(db_docs);
                        list.setRefnum(db_refnum);
                        list.setLname(db_lname);
                        list.setFname(db_fname);
                        list.setMname(db_mname);

                        report_list.add(list);
                        ivNULL.setVisibility(View.GONE);
                        lblnull.setVisibility(View.GONE);
                        lblAction.setText("SETTLED REQUESTS");
                        lblAction.setVisibility(View.VISIBLE);
                        PB_load .setVisibility(View.GONE);

                    } catch (JSONException e) {

                        //Checking internet connection
                        ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
                        if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                                connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
                            //we are connected to a network
                            PB_load .setVisibility(View.GONE);
                            e.printStackTrace();
                        }
                        else{
                            PB_load .setVisibility(View.GONE);
                            Toast.makeText(getApplicationContext(),"Please check your internet connection! ", Toast.LENGTH_SHORT).show();
                        }
                    }

                }
                adapter = new reqlist_adapter(requestH_list.this, report_list);
                RV_report.setAdapter(adapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                //Checking internet connection
                ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
                if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                        connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
                    //we are connected to a network
                    PB_load .setVisibility(View.GONE);
                    //Toast.makeText(requestl_list.this, error.toString(), Toast.LENGTH_SHORT).show();
                    Toast.makeText(getApplicationContext(),"Please check your DATA connection! ", Toast.LENGTH_SHORT).show();
                }
                else{
                    PB_load .setVisibility(View.GONE);
                    Toast.makeText(getApplicationContext(),"Please check your internet connection! ", Toast.LENGTH_SHORT).show();
                }
            }
        });
        RequestQueue requestQueue = Volley.newRequestQueue(requestH_list.this);
        requestQueue.add(request);
    }
    //PARA SA PAG LOAD NG DATA SA ON SETTLED REQUEST (END)

    //PARA SA PAG LOAD NG DATA SA ON sETTLED REQUEST
    private void Load_all_request_decline() {

        //PARA SA PAG PASS NG INPUT USERNAME NG USER -> STAARRTTT
        Intent secAct = getIntent();
        String inputUname = secAct.getStringExtra("user");//ito ang nag hold ng username sa log in
//PARA SA PAG PASS NG INPUT USERNAME NG USER -> ENNNNNDDDDDD
        //JsonArrayRequest request = new JsonArrayRequest("http://192.168.25.20/capstone/req_track_history_decline.php?user="+ inputUname, new Response.Listener<JSONArray>() {
        JsonArrayRequest request = new JsonArrayRequest(URLS.rprtdeclined_URL+"?user="+ inputUname, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray array) {
                for (int i = 0; i < array.length(); i++){
                    try {
                        JSONObject obj = array.getJSONObject(i);

                        String db_docs = obj.getString("fetch_docstype").trim();
                        String db_refnum = obj.getString("fetch_ref_num").trim();
                        String db_lname = obj.getString("fetch_lname").trim();
                        String db_fname = obj.getString("fetch_fname").trim();
                        String db_mname = obj.getString("fetch_mname").trim();

                        report_req_hstry list = new report_req_hstry();
                        list.setDocs(db_docs);
                        list.setRefnum(db_refnum);
                        list.setLname(db_lname);
                        list.setFname(db_fname);
                        list.setMname(db_mname);

                        report_list.add(list);
                        ivNULL.setVisibility(View.GONE);
                        lblnull.setVisibility(View.GONE);
                        lblAction.setText("DECLINED REQUESTS");
                        lblAction.setVisibility(View.VISIBLE);
                        PB_load .setVisibility(View.GONE);

                    } catch (JSONException e) {

                        //Checking internet connection
                        ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
                        if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                                connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
                            //we are connected to a network
                            PB_load .setVisibility(View.GONE);
                            e.printStackTrace();
                        }
                        else{
                            PB_load .setVisibility(View.GONE);
                            Toast.makeText(getApplicationContext(),"Please check your internet connection! ", Toast.LENGTH_SHORT).show();
                        }
                    }

                }
                adapter = new reqlist_adapter(requestH_list.this, report_list);
                RV_report.setAdapter(adapter);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {

                //Checking internet connection
                ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
                if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                        connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
                    //we are connected to a network
                    PB_load .setVisibility(View.GONE);
                    //Toast.makeText(requestl_list.this, error.toString(), Toast.LENGTH_SHORT).show();
                    Toast.makeText(getApplicationContext(),"Please check your DATA connection! ", Toast.LENGTH_SHORT).show();
                }
                else{
                    PB_load .setVisibility(View.GONE);
                    Toast.makeText(getApplicationContext(),"Please check your internet connection! ", Toast.LENGTH_SHORT).show();
                }

            }
        });
        RequestQueue requestQueue = Volley.newRequestQueue(requestH_list.this);
        requestQueue.add(request);
    }
    //PARA SA PAG LOAD NG DATA SA ON SETTLED REQUEST (END)

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