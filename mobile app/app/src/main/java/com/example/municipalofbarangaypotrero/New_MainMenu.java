package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import com.vishnusivadas.advanced_httpurlconnection.PutData;

public class New_MainMenu extends AppCompatActivity {
    private long pressedTime;
    Button btn_clrnc, btn_indigency, btn_transact, btn_stat, btn_residency, btn_ID;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_new_main_menu);

        ImageView profile_Link = findViewById(R.id.IV_newmain_profile);
        btn_clrnc = findViewById(R.id.btn_clearance);
        btn_indigency = findViewById(R.id.btn_indigency);
        btn_transact = findViewById(R.id.btn_transact);
        btn_stat    = findViewById(R.id.btn_stat);
        btn_residency =findViewById(R.id.btn_residency);
        btn_ID = findViewById(R.id.btn_ID);

//PARA SA PAG PASS NG INPUT USERNAME NG USER -> STAARRTTT
        Intent secAct = getIntent();
        String inputUname = secAct.getStringExtra("user");//ito ang nag hold ng username sa log in
//PARA SA PAG PASS NG INPUT USERNAME NG USER -> ENNNNNDDDDDD

        btn_residency.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {



                //PARA MAG VALIDATE Ng docu

                Handler handler = new Handler(Looper.getMainLooper());
                handler.post(() -> {

                    String docs = "Certificate of Residency";



                    //Starting Write and Read data with URL
                    //Creating array for parameters
                    String[] field = new String[1];
                    field[0] = "docs";

                    //Creating array for data
                    String[] data = new String[1];
                    data[0] = docs;

                    //PutData putData = new PutData("http://192.168.25.20/capstone/emailverification.php", "POST", field, data);
                    PutData putData = new PutData(URLS.docverify_URL, "POST", field, data);
                    // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
                    // http://192.168.131.74/capstone/signup.php (ip add sa cp)
                    if (putData.startPut()) {
                        if (putData.onComplete()) {
                            String result = putData.getResult();
                            if(result.equals("Available")){

                                Intent i = new Intent(getApplicationContext(),request.class);
                                i.putExtra("document", "Certificate of Residency"); //para set ng docu na e req
                                i.putExtra("user", inputUname);
                                startActivity(i);
                                finish();
                            }
                            else {

                                Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();

                            }
                        }
                    }
                    //End Write and Read data with URL

                });        //PARA MAG VALIDATE NF docu (END)

            }
        });

        btn_ID.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                //PARA MAG VALIDATE Ng docu

                Handler handler = new Handler(Looper.getMainLooper());
                handler.post(() -> {

                    String docs = "Barangay ID";



                    //Starting Write and Read data with URL
                    //Creating array for parameters
                    String[] field = new String[1];
                    field[0] = "docs";

                    //Creating array for data
                    String[] data = new String[1];
                    data[0] = docs;

                    //PutData putData = new PutData("http://192.168.25.20/capstone/emailverification.php", "POST", field, data);
                    PutData putData = new PutData(URLS.docverify_URL, "POST", field, data);
                    // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
                    // http://192.168.131.74/capstone/signup.php (ip add sa cp)
                    if (putData.startPut()) {
                        if (putData.onComplete()) {
                            String result = putData.getResult();
                            if(result.equals("Available")){

                                Intent i = new Intent(getApplicationContext(),request.class);
                                i.putExtra("document", "Barangay ID"); //para set ng docu na e req
                                i.putExtra("user", inputUname);
                                startActivity(i);
                                finish();
                            }
                            else {

                                Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();

                            }
                        }
                    }
                    //End Write and Read data with URL

                });        //PARA MAG VALIDATE NF docu (END)
            }
        });

        //para sa pag open sa transaction history
        btn_transact.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(getApplicationContext(),requestH_list.class);
                i.putExtra("user", inputUname);
                startActivity(i);
                finish();
            }
        });
//para sa pag open sa transaction history (END)

        btn_stat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(getApplicationContext(),requestl_list.class);
                i.putExtra("user", inputUname);
                startActivity(i);
                finish();
            }
        });

//PARA SA PAG LINK SA PROFILE BUTTON -> STAARRTTT
        profile_Link.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Intent i = new Intent(getApplicationContext(),Profile.class);
                i.putExtra("user", inputUname);
                startActivity(i);
                finish();
            }
        });
//PARA SA PAG LINK SA PROFILE BUTTON -> ENNNNNDDDDDD

//para sa pag open ng request clearance activity -> STAARRTTT
        btn_clrnc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //PARA MAG VALIDATE Ng docu

                Handler handler = new Handler(Looper.getMainLooper());
                handler.post(() -> {

                    String docs = "Barangay Clearance";



                    //Starting Write and Read data with URL
                    //Creating array for parameters
                    String[] field = new String[1];
                    field[0] = "docs";

                    //Creating array for data
                    String[] data = new String[1];
                    data[0] = docs;

                    //PutData putData = new PutData("http://192.168.25.20/capstone/emailverification.php", "POST", field, data);
                    PutData putData = new PutData(URLS.docverify_URL, "POST", field, data);
                    // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
                    // http://192.168.131.74/capstone/signup.php (ip add sa cp)
                    if (putData.startPut()) {
                        if (putData.onComplete()) {
                            String result = putData.getResult();
                            if(result.equals("Available")){



                                Intent i = new Intent(getApplicationContext(),request.class);
                                i.putExtra("document", "Barangay Clearance"); //para set ng docu na e req
                                i.putExtra("user", inputUname);
                                startActivity(i);
                                finish();
                            }
                            else {

                                Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();

                            }
                        }
                    }
                    //End Write and Read data with URL

                });        //PARA MAG VALIDATE NF docu (END)




            }
        });
//para sa pag open ng request clearance activity -> END

        btn_indigency.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {


                //PARA MAG VALIDATE Ng docu

                Handler handler = new Handler(Looper.getMainLooper());
                handler.post(() -> {

                    String docs = "Certificate of Indigency";



                    //Starting Write and Read data with URL
                    //Creating array for parameters
                    String[] field = new String[1];
                    field[0] = "docs";

                    //Creating array for data
                    String[] data = new String[1];
                    data[0] = docs;

                    //PutData putData = new PutData("http://192.168.25.20/capstone/emailverification.php", "POST", field, data);
                    PutData putData = new PutData(URLS.docverify_URL, "POST", field, data);
                    // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
                    // http://192.168.131.74/capstone/signup.php (ip add sa cp)
                    if (putData.startPut()) {
                        if (putData.onComplete()) {
                            String result = putData.getResult();
                            if(result.equals("Available")){


                                Intent i = new Intent(getApplicationContext(),request.class);
                                i.putExtra("document", "Certificate of Indigency"); //para set ng docu na e req
                                i.putExtra("user", inputUname);
                                startActivity(i);
                                finish();
                            }
                            else {

                                Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();

                            }
                        }
                    }
                    //End Write and Read data with URL

                });        //PARA MAG VALIDATE NF docu (END)
            }
        });


    }

    //docu validation
    public void doc_validation(){




    } // docu validation  (END)

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