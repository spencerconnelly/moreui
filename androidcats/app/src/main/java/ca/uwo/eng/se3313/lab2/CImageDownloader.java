package ca.uwo.eng.se3313.lab2;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.support.annotation.NonNull;
import android.os.AsyncTask;

import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.ExecutionException;


/**
 * Created by Spencer Connelly on 10/23/2016.
 */

public class CImageDownloader implements IImageDownloader  {

    private class BackgroundStuff extends AsyncTask<String,Void,Bitmap>{

        //AsyncTask abstract method that had to be implemented
        @Override
        protected Bitmap doInBackground(String... strings) {
            return downloadImage(strings[0]);
        }

        //The function that downloads the URL source from the web
        public Bitmap downloadImage(String src){
            try {
                URL url = new URL(src);
                HttpURLConnection connection = (HttpURLConnection)url.openConnection();
                connection.setDoInput(true);
                connection.connect();
                InputStream inputStream = connection.getInputStream();
                Bitmap myBitmap = BitmapFactory.decodeStream(inputStream);
                return  myBitmap;
            }catch (Exception e){
                e.printStackTrace();
                return null;
            }
        }
    }

    //IImageDownloader method that had to be implemented. Works with the Async extension to work.
    @Override
    public void download(@NonNull String imageUrl, @NonNull SuccessHandler handler) {
        BackgroundStuff downloader = new BackgroundStuff();
        Bitmap mBitMap = null;
        try {
            mBitMap = downloader.execute(imageUrl).get();
        } catch (InterruptedException e) {
            e.printStackTrace();
        } catch (ExecutionException e) {
            e.printStackTrace();
        }
        handler.onComplete(mBitMap);
    }




}
