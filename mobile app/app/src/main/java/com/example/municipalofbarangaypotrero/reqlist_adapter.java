package com.example.municipalofbarangaypotrero;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class reqlist_adapter extends RecyclerView.Adapter<reqlist_adapter.userholder > {
    Context context;
    List<report_req_hstry> report_list;

    public reqlist_adapter(Context context, List<report_req_hstry> report_list) {
        this.context = context;
        this.report_list = report_list;

    }

    @NonNull
    @Override
    public userholder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View layout = LayoutInflater.from(parent.getContext()).inflate(R.layout.report_request_history,parent, false);
        return new userholder(layout);
    }

    @Override
    public void onBindViewHolder(@NonNull userholder holder, int position) {
        report_req_hstry report = report_list.get(position);
        holder.vrbl_docs.setText(report.getDocs());
        holder.vrbl_refnum.setText(report.getRefnum());
        holder.vrbl_lname.setText(report.getLname());
        holder.vrbl_fname.setText(report.getFname());
        holder.vrbl_mname.setText(report.getMname());

        holder.itemView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(view.getContext(), viewReq.class);
                i.putExtra("ref_num", report.getRefnum());
                view.getContext().startActivity(i);
            }
        });
    }

    @Override
    public int getItemCount() {
        return report_list.size();
    }

    public class userholder extends RecyclerView.ViewHolder {
        TextView vrbl_refnum, vrbl_docs, vrbl_lname, vrbl_fname, vrbl_mname;
        public userholder(@NonNull View itemView) {
            super(itemView);
            vrbl_refnum = itemView.findViewById(R.id.val_refnum);
            vrbl_docs = itemView.findViewById(R.id.val_docs);
            vrbl_lname = itemView.findViewById(R.id.val_lname);
            vrbl_fname = itemView.findViewById(R.id.val_fname);
            vrbl_mname = itemView.findViewById(R.id.val_mname);
        }
    }
}
