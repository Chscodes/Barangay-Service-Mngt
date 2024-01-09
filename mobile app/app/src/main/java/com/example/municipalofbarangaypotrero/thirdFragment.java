package com.example.municipalofbarangaypotrero;

import android.app.ProgressDialog;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import android.widget.TextView;


import com.squareup.okhttp.OkHttpClient;
import com.squareup.okhttp.Request;
import com.squareup.okhttp.RequestBody;
import com.squareup.okhttp.Response;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;

public class thirdFragment extends Fragment {


    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public thirdFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment secondFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static thirdFragment newInstance(String param1, String param2) {
        thirdFragment fragment = new thirdFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }
    }

    //---------------------------------------------------------------------------------------------------------------//
    TextView vrbl_lname, vrbl_ID, vrbl_fname;
    //try passing uname

    //Intent i = new Intent(getActivity(), MainActivity.class);
    //String username = i.getStringExtra("user");
   // String username = "testaa"; //placeholder lang sa username
    private String strJson;// , apiUrl= "http://192.168.25.20/capstone/ctzndata.php?user="+ username;
    private OkHttpClient client;
    private Response response;
    private RequestBody requestBody;
    private Request request;
    private ProgressDialog progressDialog;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View roots = inflater.inflate(R.layout.fragment_third, container, false);



        vrbl_lname = roots.findViewById(R.id.tv_f3_lname);
        vrbl_ID = roots.findViewById(R.id.tv_f3_userID);
        vrbl_fname = roots.findViewById(R.id.tv_f3_fname);

        progressDialog = new ProgressDialog(getActivity());
        progressDialog.setTitle("Please Wait...");
        progressDialog.setCanceledOnTouchOutside(false);
        progressDialog.show();

        client = new OkHttpClient();
        new GetUserDataRequest().execute();

        return roots;
    }
    public class GetUserDataRequest extends AsyncTask<Void,Void,Void>{

        @Override
        protected Void doInBackground(Void... voids) {
            Intent i = new Intent(getActivity(), MainActivity.class);
            String username = i.getStringExtra("user");
            request = new Request.Builder().url("http://192.168.25.20/capstone/ctzndata.php?user="+ username).build();
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
}