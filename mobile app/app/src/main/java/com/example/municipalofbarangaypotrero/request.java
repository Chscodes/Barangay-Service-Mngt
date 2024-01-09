package com.example.municipalofbarangaypotrero;

import androidx.annotation.Nullable;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.Manifest;
import android.app.DatePickerDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.provider.MediaStore;
import android.util.Base64;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.RequestQueue;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.squareup.okhttp.OkHttpClient;
import com.squareup.okhttp.Request;
import com.squareup.okhttp.RequestBody;
import com.squareup.okhttp.Response;
import com.squareup.picasso.Picasso;
import com.theartofdev.edmodo.cropper.CropImage;
import com.vishnusivadas.advanced_httpurlconnection.PutData;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;
import java.util.Random;

public class request extends AppCompatActivity implements AdapterView.OnItemSelectedListener {
    //ImageView imgctzn;
    private long pressedTime;
    Spinner  cmb_purp; //cmb_docu,
    RadioGroup RG_Gender, RG_resident, RG_stat;
    RadioButton RB_Gender, RB_resident, RB_stat;
    ProgressBar v_pb;
    EditText v_lname, v_fname, v_mname, v_add, v_numyr, v_cnum, v_ctzn, v_pday, v_bday, v_spouse, v_child, v_docutype, v_purp_others;
    Button btnreq;
    ImageButton btn_up,btn_down; //para sa pag change ng years or months na siya nakatira sa brgy
    TextView v_m_Y;
    String req_docu_clearance, inputUname;
    Bitmap bitmap,bitmap2;

     String value_purps = "";
     String year_m = " YEARS";

    //para sa datetime picker
    private static final String p_TAG = "request";
    private DatePickerDialog.OnDateSetListener mDataSetListener;
    //para sa datetime picker END

    //para sa pag upload ng pic as blob
    //public static final String UPLOAD_URL = "http://192.168.25.20/capstone/pic_upload.php";
    public static final String UPLOAD_KEY = "imag";
    public static final String UPLOAD_KEY1 = "vouch_pic";
    public static final String TAG = "MY MESSAGE";

    private int PICK_IMAGE_REQUEST = 1;

    private ImageView btnpic_edit;
    private Button buttonUpload;

    private ImageView imgctzn, imgVouch;

    //private Bitmap bitmap;// may na lagay  nako

    private Uri filePath, file_vouch;
    //para sa pag upload ng pic as blob END

    //para sa pag validate if may existing na same docu na hindinpa expire

    private String strJson;
    private OkHttpClient client;
    private Response response;
    private RequestBody requestBody;
    private Request request;
    private ProgressDialog progressDialog;

//para sa pag validate if may existing na same docu na hindinpa expire

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_request);


        progressDialog = new ProgressDialog(this);
        progressDialog.setTitle("Please Wait...");
        progressDialog.setCanceledOnTouchOutside(false);



        imgctzn = findViewById(R.id.imgCtzn); //pra sa image ng ctzn
        imgVouch = findViewById(R.id.IV_req_vouch); //para sa id or vouch letter

        v_docutype = findViewById(R.id.edt_req_docutype);
        //cmb_docu = findViewById(R.id.REQ_cmbdocuType);// PARA SA LAMAN NG SPINNER NG DOCUMENT TYPE


        v_lname = findViewById(R.id.edtLname_req);
        v_fname = findViewById(R.id.edtFname_req);
        v_mname = findViewById(R.id.edtMname_req);
        v_add = findViewById(R.id.edtadd_req);
        v_numyr = findViewById(R.id.edtnumyear_req);
        v_cnum = findViewById(R.id.edtcnum_req);
        v_ctzn = findViewById(R.id.edt_ctzn_req);
        v_pday = findViewById(R.id.edtplacebday_req);
        v_bday = findViewById(R.id.edt_req_bday);
        v_spouse = findViewById(R.id.edtspouse_req);
        v_child = findViewById(R.id.edtchild_req);


        cmb_purp = findViewById(R.id.REQ_cmbpurpose);// PARA SA LAMAN NG SPINNER NG PURPOSE
        v_purp_others =findViewById(R.id.edt_req_otherspurp);

//PARA PAG D NA CLICK ANG YERS BA OR DAYS ANG NILAGAY







        btnreq = findViewById(R.id.btn_request_done);
        btnpic_edit = findViewById(R.id.btnimg_for_pic); //for pic

        RG_Gender = findViewById(R.id.RG_gender_req);
        RG_resident = findViewById(R.id.RG_rsdnt_req);
        RG_stat = findViewById(R.id.RGStats_req);


        //PARA SA PAG PASS NG INPUT USERNAME NG USER -> STAARRTTT
        Intent secAct = getIntent();
        inputUname = secAct.getStringExtra("user");//ito ang nag hold ng username sa log in
        req_docu_clearance = secAct.getStringExtra("document");

        v_docutype.setText(req_docu_clearance);  //para set ng docu na e req
        //PARA SA PAG PASS NG INPUT USERNAME NG USER -> ENNNNNDDDDDD





        btn_up =findViewById(R.id.IB_UP);
        v_m_Y =findViewById(R.id.lblM_Y);
        btn_up.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String M = String.valueOf(v_m_Y.getText());
                 if (M.equals("M")){
                     v_m_Y.setText("Y");
                     year_m = " YEARS";
                 }
                 else {
                     v_m_Y.setText("M");
                     year_m = " MONTHS";
                 }


                //v_m_Y.setText("M");
            }
        });


        btn_down =findViewById(R.id.IB_down);
        btn_down.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {


                String M = String.valueOf(v_m_Y.getText());
                if (M.equals("M")){
                    v_m_Y.setText("Y");
                    year_m = " YEARS";
                }
                else {
                    v_m_Y.setText("M");
                    year_m = " MONTHS";
                }


                //v_m_Y.setText("Y");
            }
        });

//PAra sa pag back button
        ImageButton btnback = findViewById(R.id.btnback_Request);

        btnback.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
         Intent i = new Intent(getApplicationContext(),New_MainMenu.class);
                i.putExtra("user", inputUname);
                startActivity(i);
                finish();
/*
            //uploadImage();

                client = new OkHttpClient();
                new request.GetUserDataRequest().execute(); //PrA mag execute ng function sa json na mag fetch ng data

                progressDialog.show();
                */



            }
        });

//PAra sa pag back button END



//PAra sa pag set ng date

        v_bday.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Calendar cal = Calendar.getInstance();
                int year = cal.get(Calendar.YEAR);
                int month = cal.get(Calendar.MONTH);
                int day = cal.get(Calendar.DAY_OF_MONTH);

                DatePickerDialog dialog = new DatePickerDialog(
                        request.this,
                        android.R.style.Theme_Holo_Light_Dialog_MinWidth,
                        mDataSetListener,
                        year, month, day);
                dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                dialog.show();
            }
        });

        mDataSetListener = new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker datePicker, int year, int month, int day) {
                month = month + 1;
                Log.d(p_TAG, "onDateSet: yyy/mm/dd:" + year + "/" + month + "/" + day);
                String date = year + "/" + month + "/" + day;
                v_bday.setText(date);
            }
        };
//PAra sa pag set ng date EnD


//Para sa pag insert ng req ng citizen
        btnreq.setOnClickListener(view -> {
            int radioidgender = RG_Gender.getCheckedRadioButtonId();
            RB_Gender = findViewById(radioidgender);

            int radioidRes = RG_resident.getCheckedRadioButtonId();
            RB_resident = findViewById(radioidRes);

            int radioidStat = RG_stat.getCheckedRadioButtonId();
            RB_stat = findViewById(radioidStat);

            String strlname, strfname, strmname, stradd, strnumYR, strnum, strcitizenship, strpday, strbirthday, strwife, strchildren, strgender, strrsdnt, strstat, strdocu, strpurp, strUser;
            String straction = "Pending";

            strlname = String.valueOf(v_lname.getText());
            strfname = String.valueOf(v_fname.getText());
            strmname = String.valueOf(v_mname.getText());
            stradd = String.valueOf(v_add.getText());
            strgender = String.valueOf(RB_Gender.getText());
            strrsdnt = String.valueOf(RB_resident.getText());
            strstat = String.valueOf(RB_stat.getText());
            strnumYR = String.valueOf(v_numyr.getText());
            strnum = String.valueOf(v_cnum.getText());
            strcitizenship = String.valueOf(v_ctzn.getText());
            strpday = String.valueOf(v_pday.getText());
            strbirthday = String.valueOf(v_bday.getText());
            strwife = String.valueOf(v_spouse.getText());
            strchildren = String.valueOf(v_child.getText());

            strdocu = String.valueOf(v_docutype.getText());
            //strdocu = cmb_docu.getSelectedItem().toString();

            strpurp = cmb_purp.getSelectedItem().toString();
            strUser = inputUname; //para sa username na ni log in ng user app


            if (strlname.equals("")) {
                Toast.makeText(getApplicationContext(), "Please indicate your surname", Toast.LENGTH_SHORT).show();
            }
            else if (strfname.equals("")){
                Toast.makeText(getApplicationContext(), "Please indicate your Firstname", Toast.LENGTH_SHORT).show();
            }
            else if (stradd.equals("")){
                Toast.makeText(getApplicationContext(), "Please indicate your residential address", Toast.LENGTH_SHORT).show();
            }
            else if (strnumYR.equals("")){
                Toast.makeText(getApplicationContext(), "Please input the number of years/months of living", Toast.LENGTH_SHORT).show();
            }
            else if (strnum.equals("")){
                Toast.makeText(getApplicationContext(), "Please input your cellphone number", Toast.LENGTH_SHORT).show();
            }
            else if (strcitizenship.equals("")){
                Toast.makeText(getApplicationContext(), "Please input your citizenship", Toast.LENGTH_SHORT).show();
            }
            else if (strpday.equals("")){
                Toast.makeText(getApplicationContext(), "Please input your place of birth", Toast.LENGTH_SHORT).show();
            }
            else if (strbirthday.equals("")){
                Toast.makeText(getApplicationContext(), "Please input your birthdate", Toast.LENGTH_SHORT).show();
            }
            else if (strwife.equals("") ){
                Toast.makeText(getApplicationContext(), "Please input your husband/wife", Toast.LENGTH_SHORT).show();
            }
            else if (strchildren.equals("") ){
                Toast.makeText(getApplicationContext(), "Please input your childrens fullname", Toast.LENGTH_SHORT).show();
            }
            else if (year_m.equals(" MONTHS")){
                int valid_date_months = Integer.parseInt(strnumYR);
                if (valid_date_months >= 13){
                    Toast.makeText(getApplicationContext(), "Please input proper number of months", Toast.LENGTH_SHORT).show();
                }
                else if (valid_date_months == 12){
                    Toast.makeText(getApplicationContext(), "Please set it as 1 year", Toast.LENGTH_SHORT).show();
                }
                else if (valid_date_months < 6){
                    Toast.makeText(getApplicationContext(), "You must a resident of this barangay for atleast 6 months", Toast.LENGTH_SHORT).show();
                }
                else {
                    //Checking internet connection
                    ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
                    if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                            connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
                        //we are connected to a network



                        //Para sa pag validate if may document paba na naka pending
                        progressDialog.show();
                        Handler handler = new Handler(Looper.getMainLooper());
                        handler.post(() -> {

                            //Starting Write and Read data with URL
                            //Creating array for parameters
                            String[] field = new String[4];
                            field[0] = "col_rqstDOC_lname";
                            field[1] = "col_rqstDOC_fname";
                            field[2] = "col_rqstDOC_mname";
                            field[3] = "col_rqstDOC_docsType";


                            //Creating array for data
                            String[] data = new String[4];
                            data[0] = strlname;
                            data[1] = strfname;
                            data[2] = strmname;
                            data[3] = strdocu;


                            //PutData putData = new PutData("http://192.168.25.20/capstone/reqdocu_validation_pndng.php", "POST", field, data);
                            PutData putData = new PutData(URLS.validationPndng_URL, "POST", field, data);
                            // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
                            // http://192.168.131.74/capstone/signup.php (ip add sa cp)
                            if (putData.startPut()) {
                                if (putData.onComplete()) {
                                    progressDialog.hide();
                                    String result = putData.getResult();
                                    if(result.equals("Denied there is still a PENDING request")){
                                        Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                                    }
                                    else {


                                        processing_validation();



                                    }
                                }
                            }
                            //End Write and Read data with URL

                        }); //Para sa pag validate if may document paba na naka pending (END)



                    }
                    else{
                        Toast.makeText(getApplicationContext(),"Please check your Internet Connection! ", Toast.LENGTH_SHORT).show();
                    }
                }
            }

            else {



                //Checking internet connection
                ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
                if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                        connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
                    //we are connected to a network



                    //Para sa pag validate if may document paba na naka pending
                    progressDialog.show();
                    Handler handler = new Handler(Looper.getMainLooper());
                    handler.post(() -> {

                        //Starting Write and Read data with URL
                        //Creating array for parameters
                        String[] field = new String[4];
                        field[0] = "col_rqstDOC_lname";
                        field[1] = "col_rqstDOC_fname";
                        field[2] = "col_rqstDOC_mname";
                        field[3] = "col_rqstDOC_docsType";


                        //Creating array for data
                        String[] data = new String[4];
                        data[0] = strlname;
                        data[1] = strfname;
                        data[2] = strmname;
                        data[3] = strdocu;


                        //PutData putData = new PutData("http://192.168.25.20/capstone/reqdocu_validation_pndng.php", "POST", field, data);
                        PutData putData = new PutData(URLS.validationPndng_URL, "POST", field, data);
                        // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
                        // http://192.168.131.74/capstone/signup.php (ip add sa cp)
                        if (putData.startPut()) {
                            if (putData.onComplete()) {
                                progressDialog.hide();
                                String result = putData.getResult();
                                if(result.equals("Denied there is still a PENDING request")){
                                    Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                                }
                                else {


                                    processing_validation();



                                }
                            }
                        }
                        //End Write and Read data with URL

                    }); //Para sa pag validate if may document paba na naka pending (END)



                }
                else{
                    Toast.makeText(getApplicationContext(),"Please check your Internet Connection! ", Toast.LENGTH_SHORT).show();
                }


            }

        });

/*
        //FOR SPINNERS
        ArrayAdapter adptr_docu = ArrayAdapter.createFromResource(this, R.array.docu_type, R.layout.colored_spinner_layout);
        adptr_docu.setDropDownViewResource(R.layout.spinner_drop_layout);
        cmb_docu.setAdapter(adptr_docu);
        cmb_docu.setOnItemSelectedListener(this);
*/
        ArrayAdapter adptr_purp = ArrayAdapter.createFromResource(this, R.array.purpose, R.layout.colored_spinner_layout);
        adptr_purp.setDropDownViewResource(R.layout.spinner_drop_layout);
        cmb_purp.setAdapter(adptr_purp);
        cmb_purp.setOnItemSelectedListener(this);

//FOR SPINNERS end

        // para sa pag kuha ng image mula sa gallery with crop feature

        btnpic_edit.setOnClickListener(new View.OnClickListener() {
            @RequiresApi(api = Build.VERSION_CODES.M)
            @Override
            public void onClick(View view) {
               /* boolean pick  = true;

                //if (pick == true ){
                    if (!checkCameraPermission()) {
                        requestCameraPermission();



                    }//if not check camera permission(end)
                    else PickImage();




                } //if  boolean pick is true (end)
                else {
                    if (!checkStoragePermission()) {
                        requestStoragePermission();



                    }//if not check Storage permission(end)
                    else PickImage();

                }

*/
                Intent intent = new Intent();
                intent.setType("image/*");
                intent.setAction(Intent.ACTION_GET_CONTENT);
                startActivityForResult(Intent.createChooser(intent, "Select Picture"), PICK_IMAGE_REQUEST);


            }
        }); //para sa pag kuha ng picture ng nag request tru cam or gallery (END)


        imgVouch.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent();
                intent.setType("image/*");
                intent.setAction(Intent.ACTION_GET_CONTENT);
                startActivityForResult(Intent.createChooser(intent, "Select Picture"), 2);
            }
        });

    } //bawal e delete




    //PAra sa pag uupload ng picture with informations
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == PICK_IMAGE_REQUEST && resultCode == RESULT_OK && data != null && data.getData() != null)
        {

            filePath = data.getData();

            try {
                bitmap = MediaStore.Images.Media.getBitmap(getContentResolver(), filePath);
                imgctzn.setImageBitmap(bitmap);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        if (requestCode == 2 && resultCode == RESULT_OK && data != null && data.getData() != null)
        {
            file_vouch = data.getData();
            try {
                bitmap2 = MediaStore.Images.Media.getBitmap(getContentResolver(), file_vouch);
                imgVouch.setImageBitmap(bitmap2);
            } catch (IOException e) {
                e.printStackTrace();
            }

        }
    }

    public String getStringImage(Bitmap bmp) {
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        bmp.compress(Bitmap.CompressFormat.JPEG, 10, baos);
        byte[] imageBytes = baos.toByteArray();

        String encodedImage = Base64.encodeToString(imageBytes, Base64.DEFAULT);
        return encodedImage;
    }

    public String getStringImage1(Bitmap bmp1) {
        ByteArrayOutputStream baos1 = new ByteArrayOutputStream();
        bmp1.compress(Bitmap.CompressFormat.JPEG, 10, baos1);
        byte[] imageBytes1 = baos1.toByteArray();

        String encodedImage1 = Base64.encodeToString(imageBytes1, Base64.DEFAULT);
        return encodedImage1;
    }

    private void uploadImage() {
        final String uploadImage = getStringImage(bitmap);
        final String uploadImage1 = getStringImage1(bitmap2);

        class UploadImage extends AsyncTask<Bitmap, Void, String> {
            ProgressDialog loading;
            RequestHandler rh = new RequestHandler();

            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                loading = ProgressDialog.show(request.this, "Sending Request", "Please wait...",true,true);
            }

            @Override
            protected void onPostExecute(String s) {
                super.onPostExecute(s);
                loading.dismiss();
                Toast.makeText(getApplicationContext(),s,Toast.LENGTH_SHORT).show();
            }

            @Override
            protected String doInBackground(Bitmap... params) {




                int radioidgender = RG_Gender.getCheckedRadioButtonId();
                RB_Gender = findViewById(radioidgender);

                int radioidRes = RG_resident.getCheckedRadioButtonId();
                RB_resident = findViewById(radioidRes);

                int radioidStat = RG_stat.getCheckedRadioButtonId();
                RB_stat = findViewById(radioidStat);


                String strlname, strfname, strmname, stradd, strnumYR, strnum, strcitizenship, strpday, strbirthday, strwife, strchildren, strgender, strrsdnt, strstat, strdocu, stryr, strUser,str_m_Y;
                String straction = "Pending";
                //para mag generate ng unique ref number
               String currentDate = new SimpleDateFormat("yyyy-MM-ddHHmmss", Locale.getDefault()).format(new Date());
                Random rndm = new Random();
                int code  = rndm.nextInt(89)+10;

                // para mag generate ng unique ref number END



                strlname = String.valueOf(v_lname.getText());
                strfname = String.valueOf(v_fname.getText());
                strmname = String.valueOf(v_mname.getText());
                stradd = String.valueOf(v_add.getText());
                strgender = String.valueOf(RB_Gender.getText());
                strrsdnt = String.valueOf(RB_resident.getText());
                strstat = String.valueOf(RB_stat.getText());

                //para sa year or months na naka tira
                stryr  = String.valueOf(v_numyr.getText());
                strnumYR = stryr + year_m;
                //para sa year or months na naka tira (end)


                strnum = String.valueOf(v_cnum.getText());


                strcitizenship = String.valueOf(v_ctzn.getText());
                strpday = String.valueOf(v_pday.getText());
                strbirthday = String.valueOf(v_bday.getText());
                strwife = String.valueOf(v_spouse.getText());
                strchildren = String.valueOf(v_child.getText());

                strdocu = String.valueOf(v_docutype.getText());
                //strdocu = cmb_docu.getSelectedItem().toString();


                //strpurp = cmb_purp.getSelectedItem().toString();
                strUser = inputUname; //para sa username na ni log in ng user app
                String refNumm = currentDate + code;

                HashMap<String,String> data = new HashMap<>();


                data.put(UPLOAD_KEY1, uploadImage1); //for vouch letter pic
                data.put(UPLOAD_KEY, uploadImage); //for ctzn image
                data.put("pLname", strlname);
                data.put("pFname", strfname);
                data.put("pMname", strmname);

                data.put("pAdd", stradd);
                data.put("pGender", strgender);
                data.put("pRsdnt", strrsdnt);
                data.put("pStat", strstat);
                data.put("pYR", strnumYR);
                data.put("pNume", strnum);
                data.put("pCtzn", strcitizenship);
                data.put("pPday", strpday);
                data.put("pBday", strbirthday);

                data.put("pWife", strwife);
                data.put("pChild", strchildren);
                data.put("pDocu", strdocu);
                data.put("pPup", value_purps);
                data.put("pUser", strUser);
                data.put("pAction", straction);
                data.put("pRefNum", refNumm);

                //String result = rh.sendPostRequest(UPLOAD_URL,data);
                String result = rh.sendPostRequest(URLS.request_URL,data);

                return result;




            }


        }

        UploadImage ui = new UploadImage();
        ui.execute(bitmap, bitmap2);

        Intent i = new Intent(getApplicationContext(),New_MainMenu.class);
        i.putExtra("user", inputUname);
        startActivity(i);
        finish();

    } //PAra sa pag uupload ng picture with informations (END)

    //para mag validate na if may on process na req hindi pwede mag request
    public void processing_validation (){

        String  strlname = String.valueOf(v_lname.getText());
        String strfname = String.valueOf(v_fname.getText());
        String strmname = String.valueOf(v_mname.getText());

        String strdocu = String.valueOf(v_docutype.getText());
        //String strdocu = cmb_docu.getSelectedItem().toString();

        progressDialog.show();
        Handler handler = new Handler(Looper.getMainLooper());
        handler.post(() -> {

            //Starting Write and Read data with URL
            //Creating array for parameters
            String[] field = new String[4];
            field[0] = "col_rqstDOC_lname";
            field[1] = "col_rqstDOC_fname";
            field[2] = "col_rqstDOC_mname";
            field[3] = "col_rqstDOC_docsType";


            //Creating array for data
            String[] data = new String[4];
            data[0] = strlname;
            data[1] = strfname;
            data[2] = strmname;
            data[3] = strdocu;


            //PutData putData = new PutData("http://192.168.25.20/capstone/reqdocu_validation_prcss.php", "POST", field, data);
            PutData putData = new PutData(URLS.validationPrcss_URL, "POST", field, data);
            // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
            // http://192.168.131.74/capstone/signup.php (ip add sa cp)
            if (putData.startPut()) {
                if (putData.onComplete()) {
                    progressDialog.hide();
                    String result = putData.getResult();
                    if(result.equals("Request denied, you still have ON-PROCCESS request")){
                        Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                    }
                    else {

                        pickup_validation();

                    }
                }
            }
            //End Write and Read data with URL

        });

    } //para mag validate na if may on process na req hindi pwede mag request (END)


    //para mag validate if may kailangan pa e pick up bago maka request ng bago
    public void pickup_validation(){
        String  strlname = String.valueOf(v_lname.getText());
        String strfname = String.valueOf(v_fname.getText());
        String strmname = String.valueOf(v_mname.getText());

         String strdocu = String.valueOf(v_docutype.getText());
        //String strdocu = cmb_docu.getSelectedItem().toString();

        progressDialog.show();
        Handler handler = new Handler(Looper.getMainLooper());
        handler.post(() -> {

            //Starting Write and Read data with URL
            //Creating array for parameters
            String[] field = new String[4];
            field[0] = "col_rqstDOC_lname";
            field[1] = "col_rqstDOC_fname";
            field[2] = "col_rqstDOC_mname";
            field[3] = "col_rqstDOC_docsType";


            //Creating array for data
            String[] data = new String[4];
            data[0] = strlname;
            data[1] = strfname;
            data[2] = strmname;
            data[3] = strdocu;



            //PutData putData = new PutData("http://192.168.25.20/capstone/reqdocu_validation_pickUp.php", "POST", field, data);
            PutData putData = new PutData(URLS.validationPck_URL, "POST", field, data);
            // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
            // http://192.168.131.74/capstone/signup.php (ip add sa cp)
            if (putData.startPut()) {
                if (putData.onComplete()) {
                    progressDialog.hide();
                    String result = putData.getResult();
                    if(result.equals("Request denied, you still have a document for PICK UP")){
                        Toast.makeText(getApplicationContext(),result,Toast.LENGTH_SHORT).show();
                    }
                    else {
                        valid_DATE_validation();
                    }
                }
            }
            //End Write and Read data with URL

        });

    } //para mag validate if may kailangan pa e pick up bago maka request ng bago (END)


    //ParA SA PAG  validate if may document na nakuha tas  hindi pa na expire
    public void valid_DATE_validation(){
        String  strlname = String.valueOf(v_lname.getText());
        String strfname = String.valueOf(v_fname.getText());
        String strmname = String.valueOf(v_mname.getText());

        String strdocu = String.valueOf(v_docutype.getText());
        //String strdocu = cmb_docu.getSelectedItem().toString();

        //Para sa pag validate if may document paba na active na d expire bago mag request ng bago
        progressDialog.show();
        Handler handler = new Handler(Looper.getMainLooper());
        handler.post(() -> {




            //Starting Write and Read data with URL
            //Creating array for parameters
            String[] field = new String[4];
            field[0] = "col_rqstDOC_lname";
            field[1] = "col_rqstDOC_fname";
            field[2] = "col_rqstDOC_mname";
            field[3] = "col_rqstDOC_docsType";


            //Creating array for data
            String[] data = new String[4];
            data[0] = strlname;
            data[1] = strfname;
            data[2] = strmname;
            data[3] = strdocu;


            //PutData putData = new PutData("http://192.168.25.20/capstone/reqdocu_validation.php", "POST", field, data);
            PutData putData = new PutData(URLS.validationdate_URL, "POST", field, data);
            // http://192.168.25.20/capstone/signup.php (ip add sa bahay)
            // http://192.168.131.74/capstone/signup.php (ip add sa cp)
            if (putData.startPut()) {
                if (putData.onComplete()) {
                    progressDialog.dismiss();
                    String result = putData.getResult();
                    if(result.equals("Not expired Document")){
                        Toast.makeText(getApplicationContext(),"Request Denied, due to active document acquired." ,Toast.LENGTH_SHORT).show();
                        Toast.makeText(getApplicationContext(),"Please check the validation indicated to your acquired document.",Toast.LENGTH_SHORT).show();
                    }
                    else {

                        if (bitmap == null) {
                            Toast.makeText(getApplicationContext(),"Please insert a 2x2 picture!" ,Toast.LENGTH_SHORT).show();
                        }
                        else if(bitmap2 == null){

                            Toast.makeText(getApplicationContext(),"Please insert a Valid ID!" ,Toast.LENGTH_SHORT).show();

                        }
                        else if(v_purp_others.getVisibility() == View.VISIBLE ){
                            String check = String.valueOf(v_purp_others.getText());
                            if (check.equals("")) {
                                Toast.makeText(getApplicationContext(),"Please input your purpose for acquiring" ,Toast.LENGTH_SHORT).show();
                                v_purp_others.requestFocus();
                            } else {
                                value_purps = String.valueOf(v_purp_others.getText());
                                uploadImage();


                            }

                        }
                        else {
                            uploadImage(); // mag upload ng image sa ctzn with its request information


                        }


                    }
                }
            }
            //End Write and Read data with URL

        }); //Para sa pag validate if may document paba na active na d expire bago mag request ng bago (END)

    }//ParA SA PAG  validate if may document na nakuha tas  hindi pa na expire (END)



/*
    private void PickImage() {
        CropImage.activity().start(this);

    }

    @RequiresApi(api = Build.VERSION_CODES.M)
    private void requestStoragePermission() {
        requestPermissions(new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}, 100);
    }

    @RequiresApi(api = Build.VERSION_CODES.M)
    private void requestCameraPermission() {
        requestPermissions(new String[]{Manifest.permission.CAMERA, Manifest.permission.WRITE_EXTERNAL_STORAGE}, 100);
    }

    private boolean checkStoragePermission() {
        boolean res2 = ContextCompat.checkSelfPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE) == PackageManager.PERMISSION_GRANTED;
        return res2;
    }

    private boolean checkCameraPermission() {

        boolean res1 = ContextCompat.checkSelfPermission(this, Manifest.permission.CAMERA) == PackageManager.PERMISSION_GRANTED;
        boolean res2 = ContextCompat.checkSelfPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE) == PackageManager.PERMISSION_GRANTED;

        return res1 && res2;
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == CropImage.CROP_IMAGE_ACTIVITY_REQUEST_CODE) {
            CropImage.ActivityResult result = CropImage.getActivityResult(data);
            if (resultCode == RESULT_OK) {

                Uri resultUri = result.getUri();
                //Picasso.with(this).load(resultUri).into(imgctzn);
            // Replace for picasso method (d ko lang muna delete baka magamit)
                try {
                    InputStream stream = getContentResolver().openInputStream(resultUri);
                    bitmap = BitmapFactory.decodeStream(stream);
                    imgctzn.setImageBitmap(bitmap);
                    encodeBitmapImage(bitmap);
                }catch (Exception e){
                    e.printStackTrace();
                }




            } else if (resultCode == CropImage.CROP_IMAGE_ACTIVITY_RESULT_ERROR_CODE) {
                Exception error = result.getError();
            }
        }
    } //para sa pag kuha ng image mula sa gallery with crop feature (end)
*/
    /*

    //para sa pag upload sa pic n nasa image view
    private void encodeBitmapImage(Bitmap bitmap) {

        ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.JPEG, 100, outputStream);

        byte[] bytesofImage = outputStream.toByteArray();
        encode_imageString = android.util.Base64.encodeToString(bytesofImage, Base64.DEFAULT);

    }   //para sa pag upload sa pic n nasa image view(end)


    //void para mag upload na ng image sa dgb

    private void insert_pic(){
        StringRequest S_request = new StringRequest(Request.Method.POST, pic_url, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                //imgctzn.setImageResource(R.drawable.insrtpic);
                Toast.makeText(getApplicationContext(), response.toString(),Toast.LENGTH_LONG).show();
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Toast.makeText(getApplicationContext(), error.toString(),Toast.LENGTH_LONG).show();
            }
        }){

            @Nullable
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {

                Map<String, String> map = new HashMap<String, String>();


                map.put("pic_upload", encode_imageString);

                return map;

            }
        };
        RequestQueue queue = Volley.newRequestQueue(getApplicationContext());
        queue.add(S_request);



    }//void para mag upload na ng image sa dgb (END)

*/




    //FOR SPINNERS
    @Override
    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
        //Hindi ko pa alam para san to

        String selected_purp = adapterView.getItemAtPosition(i).toString();//kuha ng value na select sa spinner
        if (selected_purp.equals("OTHERS")) {
            v_purp_others.setVisibility(View.VISIBLE);
            //value_purps = String.valueOf(v_purp_others.getText());

        }
        else {
            v_purp_others.setVisibility(View.INVISIBLE);
            value_purps = cmb_purp.getSelectedItem().toString();
        }

    }

    @Override
    public void onNothingSelected(AdapterView<?> adapterView) {

    }
//FOR SPINNERS end


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