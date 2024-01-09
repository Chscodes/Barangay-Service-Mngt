package com.example.municipalofbarangaypotrero;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.CheckBox;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatDialogFragment;

public class terns_dialog extends AppCompatDialogFragment {

    CheckBox CB_confirm;

    private vrbl_dialoglistener listener;

    @NonNull
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {

        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());

        LayoutInflater inflater = getActivity().getLayoutInflater();
        View view = inflater.inflate(R.layout.terms_condition_dialog, null);

            CB_confirm = view.findViewById(R.id.cb_agree);


        builder.setView(view)
                .setTitle("Terms & Condition")
                .setNegativeButton("cancel", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {

                    }
                })
                .setPositiveButton("Next", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        if (CB_confirm.isChecked()){
                            String agree = "Agree";

                            listener.texts(agree);

                            } else {
                            String agree = "No Agree";
                            listener.texts(agree);
                        }


                    }
                });






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
        void texts (String agree);

    }



}
