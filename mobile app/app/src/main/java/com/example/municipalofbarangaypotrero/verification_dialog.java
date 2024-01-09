package com.example.municipalofbarangaypotrero;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatDialogFragment;

public class verification_dialog  extends AppCompatDialogFragment {

    private EditText vrbl_code1, vrbl_code2, vrbl_code3, vrbl_code4, signUP_email;
    private vrbl_dialoglistener listener;

    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());

        LayoutInflater inflater = getActivity().getLayoutInflater();
        View view = inflater.inflate(R.layout.signup_dialog_layout, null);




        builder.setView(view)
                .setTitle("Email Verificatiom")
                .setNegativeButton("cancel", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                    }
                })
                .setPositiveButton("Verify", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        String interface_code1 = vrbl_code1.getText().toString();
                        String interface_code2 = vrbl_code2.getText().toString();
                        String interface_code3 = vrbl_code3.getText().toString();
                        String interface_code4 = vrbl_code4.getText().toString();

                        listener.applytexts(interface_code1, interface_code2, interface_code3, interface_code4);
                    }
                });

        vrbl_code1 = view.findViewById(R.id.edt_code_code1);
        vrbl_code2 = view.findViewById(R.id.edt_code_code2);
        vrbl_code3 = view.findViewById(R.id.edt_code_code3);
        vrbl_code4 = view.findViewById(R.id.edt_code_code4);



        return builder.create();
    }

    @Override
    public void onAttach(@NonNull Context context) {
        super.onAttach(context);

        try {
            listener = (vrbl_dialoglistener) context;
        } catch (ClassCastException e) {
            throw new ClassCastException(context.toString() + "must implement vrbl_dialoglistener");
        }
    }

    public interface vrbl_dialoglistener{
        void applytexts(String interface_code1, String interface_code2, String interface_code3, String interface_code4);
    }
}
