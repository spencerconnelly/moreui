package ca.uwo.eng.se3313.lab2;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.CountDownTimer;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.InputType;
import android.text.TextWatcher;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.View;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.SeekBar;
import android.widget.TextView;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.LogRecord;
import android.os.Handler;

public class MainActivity extends AppCompatActivity {


    //CREATED BY SPENCER CONNELLY 250721900


    /**
     * View that showcases the image
     */
    private ImageView ivDisplay;

    /**
     * Skip button
     */
    private ImageButton skipBtn;

    /**
     * Progress bar showing how many seconds left (percentage).
     */
    private ProgressBar pbTimeLeft;

    /**
     * Label showing the seconds left.
     */
    private TextView tvTimeLeft;

    /**
     * Control to change the interval between switching images.
     */
    private SeekBar sbWaitTime;

    /**
     * Editable text to change the interval with {@link #sbWaitTime}.
     */
    private EditText etWaitTime;


    /**
     * Used to download images from the {@link #urlList}.
     */
    private IImageDownloader imgDownloader;

    /**
     * List of image URLs of cute animals that will be displayed.
     */
    private static final List<String> urlList = new ArrayList<String>() {{
        add("http://i.imgur.com/CPqbVW8.jpg");
        add("http://i.imgur.com/Ckf5OeO.jpg");
        add("http://i.imgur.com/3jq1bv7.jpg");
        add("http://i.imgur.com/8bSITuc.jpg");
        add("http://i.imgur.com/JfKH8wd.jpg");
        add("http://i.imgur.com/KDfJruL.jpg");
        add("http://i.imgur.com/o6c6dVb.jpg");
        add("http://i.imgur.com/B1bUG2K.jpg");
        add("http://i.imgur.com/AfxvVuq.jpg");
        add("http://i.imgur.com/DSDtm.jpg");
        add("http://i.imgur.com/SAVYw7S.jpg");
        add("http://i.imgur.com/4HznKil.jpg");
        add("http://i.imgur.com/meeB00V.jpg");
        add("http://i.imgur.com/CPh0SRT.jpg");
        add("http://i.imgur.com/8niPBvE.jpg");
        add("http://i.imgur.com/dci41f3.jpg");
    }};

    //Array where all the Bitmaps are saved
    private Bitmap[] imageArray = new Bitmap[16];

    //Implementation of the IImageDownloader.SuccessHandler.  Saves the bitmap to the imageArray after it is downloaded
    private class SuccessHandle implements IImageDownloader.SuccessHandler{
        int index = 0;
        @Override
        public void onComplete(@NonNull Bitmap image) {
            imageArray[index] = image;
            index++;
        }
    }

    //Implementation of the IImageDownloader.ErrorHandler
    private class ErrorHandle implements  IImageDownloader.ErrorHandler{

        @Override
        public void onError(@NonNull Throwable error) {

        }
    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        // Insert your code here (and within the class!)

        //Object of the ImageDownloader Implementation.  The IImageDownloader is set to a CImageDownloader object because of polymorphism.
        imgDownloader = new CImageDownloader();
        //SuccessHandler Implementation object that must be sent to the ImageDownloader implementation
        SuccessHandle success = new SuccessHandle();

        //Fills the array with the cat_error as a failsafe if the images cannot be downloaded
        for(int i = 0; i < urlList.size(); i++){
            imageArray[i] = BitmapFactory.decodeResource(null,R.drawable.cat_error);
        }

        //Attempts to download the image from the urlList
        for(int i = 0; i < imageArray.length; i++){
            imgDownloader.download(urlList.get(i),success);
        }

        //All the variiables assigned to their component by ID
        ivDisplay = (ImageView) findViewById(R.id.ivDisplay);
        sbWaitTime = (SeekBar) findViewById(R.id.sbWaitTime);
        etWaitTime = (EditText) findViewById(R.id.etWaitTime);
        tvTimeLeft = (TextView) findViewById(R.id.tvTimeLeft);
        pbTimeLeft = (ProgressBar) findViewById(R.id.pbTimeLeft);
        skipBtn = (ImageButton) findViewById(R.id.btnSkip);

        //Formatting to keep the text input identical to the video
        etWaitTime.setGravity(Gravity.RIGHT);
        etWaitTime.setHint("Secs");

        //skipBtn On Click Listener. Changes the progress bar and changes the picture
        skipBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                pbTimeLeft.setProgress(0);
                changePicture();
            }
        });

        //Seek bar listener
        sbWaitTime.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                progress=progress+5;
                if(fromUser == true){
                    tvTimeLeft.setText(progress+"s");
                    etWaitTime.setText(""+progress);
                    pbTimeLeft.setProgress(0);
                    pbTimeLeft.setMax(Integer.parseInt(etWaitTime.getText().toString()));
                }
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }
        });

        //EntryText listener on click.  To match the video this had to be done to replace the text currently in the input
        etWaitTime.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                etWaitTime.selectAll();
            }
        });

        //Controls the changing of the progress bar after the input text changes and when the done button is pressed
        etWaitTime.setOnEditorActionListener(new TextView.OnEditorActionListener(){
            public boolean onEditorAction(TextView v, int actionId, KeyEvent event){
                if(actionId == EditorInfo.IME_ACTION_DONE){
                    if(etWaitTime.getText().length() < 1 || etWaitTime.getText().length() > 2 || Integer.valueOf(etWaitTime.getText().toString()) > 60 || Integer.valueOf(etWaitTime.getText().toString()) < 5){
                        etWaitTime.selectAll();
                        etWaitTime.setError("Must specfiy a number between 5 and 60");
                    }
                    else{
                        sbWaitTime.setProgress(Integer.valueOf(etWaitTime.getText().toString())-5);
                        tvTimeLeft.setText(etWaitTime.getText()+"s");
                        pbTimeLeft.setProgress(0);
                        pbTimeLeft.setMax(Integer.parseInt(etWaitTime.getText().toString()));


                        InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                        imm.hideSoftInputFromWindow(etWaitTime.getWindowToken(), 0);
                    }

                    return true;
                }

                return false;
            }
        });

        //Controls the timer for the progress bar.  I found this implementaiton a lot easier for myself to understand than the CountDownTimer
        //I had a lot of issues with resetting the CountDownTimer after the progress reached the end so I made my own implementation that works just as well.
        //The image also changes from a UI thread after the progress timer reaches its max
        Runnable myRunnable = new Runnable() {
            @Override
            public void run() {

                while (true) {
                    try {
                        Thread.sleep(1000); // Waits for 1 second
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }

                    int progress = pbTimeLeft.getProgress();
                    if (progress < pbTimeLeft.getMax()) {
                        pbTimeLeft.setProgress(progress + 1);
                    } else {
                        pbTimeLeft.setProgress(0);
                        changePicture();
                    }
                }
            }

        };

        //Initiates the ImageView when the program is created
        ivDisplay.setImageBitmap(imageArray[0]);

        //Runs the progress bar thread so it updates independently
        Thread progThread = new Thread(myRunnable);
        progThread.start();



    }

    //These 2 functions are used to control the picture changes
    private int photoNum=0;
    private int getPhotoNum(){
        return photoNum;
    }
    private void incrementPhotoNum(){
        if(photoNum < imageArray.length-1){
            photoNum++;
        } else {
            photoNum = 0;
        }
    }

    //runs the UI thread to change the ImageView
    private void changePicture(){
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                incrementPhotoNum();
                ivDisplay.setImageBitmap(imageArray[getPhotoNum()]);
            }
        });
    }


}
