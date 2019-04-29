﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    //Scene MainMenu
    public static string sNamePlayer;
    public static int nScore;
    public static float[] fCheckIF1 = new float[]{ 0.082f, 0.652f, 1.605f, 2.151f, 3.157f, 3.674f, 4.599f, 5.783f, 6.131f, 7.606f,
                        9.160f, 10.659f, 11.797f, 13.603f, 15.078f, 16.574f, 18.107f, 19.603f, 21.097f,
                        22.206f, 22.578f, 23.331f,24.079f, 24.660f, 25.607f, 26.158f, 27.104f, 27.677f,
                        28.587f, 29.352f, 30.100f, 30.685f, 31.603f, 32.156f, 33.088f, 33.657f, 34.214f,
                        35.335f, 36.105f, 36.668f, 37.246f, 37.622f, 38.154f, 38.768f, 39.105f, 39.693f,
                        40.243f, 40.608f, 41.781f, 42.106f, 42.669f, 43.233f, 43.607f, 44.179f, 44.745f,
                        45.173f, 45.712f, 46.288f, 46.599f, 47.761f, 48.146f, 48.679f, 49.213f, 49.605f,
                        50.181f, 50.753f, 51.192f, 51.712f, 52.224f, 52.607f, 53.733f, 54.197f, 54.674f,
                        55.217f, 55.633f, 56.171f, 56.770f, 57.106f, 57.667f, 58.239f, 58.629f, 59.800f,
                        60.156f, 60.657f, 61.224f, 61.601f, 62.181f, 62.739f, 63.152f, 63.698f, 64.249f,
                        64.621f, 65.750f, 66.187f, 66.668f, 67.253f, 67.625f, 68.178f, 68.861f, 69.172f,
                        69.692f, 70.306f, 70.673f, 71.793f, 72.360f, 73.730f, 75.340f, 76.690f, 78.220f,
                        80.020f, 81.230f, 83.040f, 84.150f, 85.060f, 85.580f, 87.080f, 88.220f, 88.580f,
                        89.320f, 90.100f, 91.210f, 91.590f, 93.110f, 94.210f, 94.590f, 95.330f, 96.160f,
                        96.670f, 97.420f, 98.150f, 98.760f, 99.160f, 99.780f, 100.250f, 100.650f,
                        101.750f, 102.170f, 102.660f, 103.250f, 103.700f, 104.140f, 104.780f, 105.160f,
                        105.640f, 106.240f, 106.650f, 107.750f, 108.140f, 109.310f, 109.650f, 110.770f,
                        111.150f, 112.280f, 112.650f, 113.780f, 114.140f, 114.660f, 115.270f, 115.650f,
                        116.180f, 116.760f, 117.160f, 117.650f, 118.290f, 118.650f, 119.760f, 120.190f,
                        120.660f, 121.230f, 121.650f, 122.140f, 122.730f, 123.120f, 123.660f, 124.250f,
                        124.650f, 125.770f, 126.160f, 126.670f, 127.240f, 127.580f, 128.150f, 128.800f,
                        129.150f, 129.660f, 130.230f, 130.650f, 131.790f, 132.150f, 132.670f, 133.230f,
                        133.650f, 134.150f, 134.760f, 135.120f, 135.650f, 136.250f, 136.640f, 137.780f,
                        138.160f, 138.650f, 139.240f, 139.620f, 140.150f, 141.160f, 141.650f,
                        142.240f, 142.590f, 143.760f, 144.130f, 144.660f, 145.680f, 147.080f, 147.660f,
                        148.200f, 148.770f, 149.350f, 150.080f, 150.660f, 151.680f, 153.090f, 153.650f,
                        154.210f, 154.770f, 156.080f, 157.790f, 159.280f, 160.280f, 162.310f, 164.270f,
                        166.220f, 168.850f, 171.700f};


    public static float[] fCheckIF2 = new float[]{ 4.208f, 7.976f, 8.912f, 9.620f, 10.308f, 11.704f, 12.644f, 13.352f, 14.060f,
                        15.452f, 16.415f, 17.163f, 17.815f, 19.223f, 20.152f, 20.611f, 21.080f, 21.548f,
                        22.024f, 22.495f, 22.963f, 23.431f, 23.892f, 24.356f, 24.855f, 25.335f, 25.764f,
                        26.224f, 26.727f, 27.191f, 27.644f, 28.112f, 28.587f, 29.048f, 29.535f, 29.995f,
                        30.463f, 30.935f, 31.403f, 31.863f, 32.327f, 32.815f, 33.287f, 33.743f, 34.176f,
                        35.135f, 35.619f, 36.075f, 36.555f, 37.019f, 37.475f, 37.995f, 38.404f, 38.891f,
                        39.355f, 39.843f, 40.311f, 40.736f, 41.247f, 41.715f, 42.179f, 43.115f, 43.587f,
                        44.043f, 44.527f, 44.995f, 45.471f, 45.947f, 46.395f, 46.863f, 47.347f, 47.791f,
                        48.275f, 48.696f, 49.211f, 50.127f, 50.607f, 51.075f, 51.448f, 51.991f, 52.479f,
                        52.943f, 53.435f, 53.895f, 54.355f, 54.823f, 55.287f, 55.743f, 56.211f, 56.679f,
                        57.163f, 57.627f, 58.095f, 58.559f, 59.015f, 59.491f, 59.967f, 60.427f, 60.899f,
                        61.379f, 61.819f, 62.307f, 62.763f, 63.223f, 63.719f, 64.183f, 65.131f, 65.563f,
                        66.067f, 66.484f, 67.007f, 67.455f, 67.943f, 68.399f, 68.883f, 69.331f, 69.807f,
                        70.279f, 70.759f, 71.223f, 71.695f, 72.139f, 73.089f, 73.570f, 74.031f, 74.507f,
                        74.927f, 75.435f, 75.891f, 76.386f, 76.843f, 77.287f, 77.783f, 78.199f, 78.699f,
                        79.151f, 82.868f, 83.788f, 84.484f, 85.188f, 86.604f, 87.540f, 88.240f, 88.932f,
                        90.344f, 91.208f, 91.980f, 92.692f, 94.096f, 95.032f, 95.732f, 96.432f, 97.840f,
                        98.780f, 99.488f, 100.191f, 101.592f, 102.528f, 103.241f, 103.957f, 105.343f,
                        106.272f, 106.964f, 107.687f, 109.087f, 110.016f, 110.731f, 111.424f, 112.839f,
                        113.783f, 114.483f, 115.175f, 116.591f, 117.519f, 117.999f, 118.471f, 118.935f,
                        119.391f, 119.855f, 120.327f, 120.799f, 121.271f, 121.727f, 122.184f, 122.671f,
                        123.159f, 123.631f, 124.103f, 125.031f, 125.471f, 125.967f, 126.431f, 126.911f,
                        127.375f, 127.831f, 128.287f, 128.783f, 129.255f, 129.719f, 130.159f, 130.639f,
                        131.111f, 131.559f, 132.527f, 132.975f, 133.463f, 133.943f, 134.415f, 134.839f,
                        135.351f, 136.279f, 136.711f, 137.215f, 137.679f, 138.159f, 138.623f, 139.102f,
                        139.574f, 140.502f, 140.967f, 141.438f, 141.903f, 142.335f, 142.807f, 143.767f,
                        144.231f, 144.695f, 145.182f, 145.654f, 146.095f, 146.575f, 147.534f, 148.014f,
                        148.462f, 148.926f, 149.383f, 149.862f, 150.350f, 150.791f, 151.270f, 151.727f,
                        152.214f, 152.678f, 153.158f, 153.614f, 154.086f, 155.038f, 155.494f, 155.935f,
                        156.422f, 156.902f, 157.374f, 157.838f, 158.774f, 159.215f, 159.702f, 160.182f,
                        160.662f, 161.110f, 161.590f, 162.518f, 162.982f, 163.462f, 163.926f, 164.406f,
                        164.870f, 165.350f, 166.278f, 166.762f, 167.206f, 167.686f, 168.150f, 168.622f,
                        169.102f, 170.211f, 170.690f, 171.155f, 171.627f, 172.098f, 172.555f, 173.491f,
                        173.970f, 174.442f, 174.899f, 175.386f, 175.819f, 176.322f, 177.998f};
    public static int nMakeIf;
    
    // Use this for initialization
    void Start () {
        sNamePlayer = "";
        nScore = 0;
        nMakeIf = 0;
    }
	
}