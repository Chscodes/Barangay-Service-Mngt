package com.example.municipalofbarangaypotrero;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MenuItem;

import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.google.android.material.navigation.NavigationBarView;

public class MainMenu extends AppCompatActivity {

    BottomNavigationView main_bot_nav;

    firstfragment bot_nav_1 = new firstfragment();
    secondFragment bot_nav_2 = new secondFragment();
    thirdFragment bot_nav_3 = new thirdFragment();


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_menu);
        main_bot_nav = findViewById(R.id.bot_nav);

        //getSupportFragmentManager().beginTransaction().replace(R.id.container,bot_nav_1).commit();

        main_bot_nav.setOnItemSelectedListener(new NavigationBarView.OnItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(MenuItem item) {
                switch (item.getItemId()){
                    case R.id.firstFrag_id:
                        getSupportFragmentManager().beginTransaction().replace(R.id.container,bot_nav_1).commit();
                        return true;
                    case R.id.secondFrag_id:
                        getSupportFragmentManager().beginTransaction().replace(R.id.container,bot_nav_2).commit();
                        return true;
                    case R.id.profile_frag_id:
                        getSupportFragmentManager().beginTransaction().replace(R.id.container,bot_nav_3).commit();
                        return true;
                }
                return false;
            }
        });

      /*
       val bottomNavigationView = findViewById(R.id.bottomNavigationView);

        Set<Integer> topLevelDestinations = new HashSet<>();
        topLevelDestinations.add(R.id.firstFrag);
        topLevelDestinations.add(R.id.secondFrag);
        topLevelDestinations.add(R.id.thirdFrag);
        AppBarConfiguration appBarConfiguration = new AppBarConfiguration.Builder(topLevelDestinations).build();
        NavigationUI.setupActionBarWithNavController(this, navController, appBarConfiguration);
       */

    }
}