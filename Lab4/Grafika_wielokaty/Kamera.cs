using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{
    [Serializable]
    class Kamera
    {
        public Wektor pozycja;
        public Wektor cel;
        public Wektor Uworld;
        public string name;


        public Kamera(Wektor pozycja,Wektor cel)
        {
            Uworld = new Wektor(new float[] { 0, 1, 0 });
            this.pozycja = pozycja;
            this.cel = cel;
        }
        //public Macierz macierzWidoku()
        //{
        //    float eyeX = pozycja.wek[0];
        //    float eyeY = pozycja.wek[1];
        //    float eyeZ = pozycja.wek[2];
        //    float centerX = cel.wek[0];
        //    float centerY = cel.wek[1];
        //    float centerZ = cel.wek[2];
        //    float upX = 0;
        //    float upY = 1;
        //    float upZ = 0;
        //    // Compute direction from position to lookAt
        //    float dirX, dirY, dirZ;
        //    dirX = eyeX - centerX;
        //    dirY = eyeY - centerY;
        //    dirZ = eyeZ - centerZ;
        //    // Normalize direction
        //    float invDirLength = 1.0f / (float)Math.Sqrt(dirX * dirX + dirY * dirY + dirZ * dirZ);
        //    dirX *= invDirLength;
        //    dirY *= invDirLength;
        //    dirZ *= invDirLength;
        //    // left = up x direction
        //    float leftX, leftY, leftZ;
        //    leftX = upY * dirZ - upZ * dirY;
        //    leftY = upZ * dirX - upX * dirZ;
        //    leftZ = upX * dirY - upY * dirX;
        //    // normalize left
        //    float invLeftLength = 1.0f / (float)Math.Sqrt(leftX * leftX + leftY * leftY + leftZ * leftZ);
        //    leftX *= invLeftLength;
        //    leftY *= invLeftLength;
        //    leftZ *= invLeftLength;
        //    // up = direction x left
        //    float upnX = dirY * leftZ - dirZ * leftY;
        //    float upnY = dirZ * leftX - dirX * leftZ;
        //    float upnZ = dirX * leftY - dirY * leftX;
        //    //normalize

        //    float[,] w = new float[4, 4];
        //    w[0, 0] = leftX;
        //    w[0, 1] = upnX;
        //    w[0, 2] = dirX;
        //    w[0, 3] = 0f;
        //    w[1, 0] = leftY;
        //    w[1, 1] = upnY;
        //    w[1, 2] = dirY;
        //    w[1, 3] = 0f;
        //    w[2, 0] = leftZ;
        //    w[2, 1] = upnZ;
        //    w[2, 2] = dirZ;
        //    w[2, 3] = -(dirX * eyeX + dirY * eyeY + dirZ * eyeZ);
        //    w[3, 0] = -(leftX * eyeX + leftY * eyeY + leftZ * eyeZ);
        //    w[3, 1] = -(upnX * eyeX + upnY * eyeY + upnZ * eyeZ);
        //    w[3, 2] = 0f;
        //    w[3, 3] = 1f;


        //    return new Macierz(w);
        //}
        public Macierz macierzWidoku()
        {

            float[] wynik = new float[3];
            wynik[0] = pozycja.wek[0] - cel.wek[0];
            wynik[1] = pozycja.wek[1] - cel.wek[1];
            wynik[2] = pozycja.wek[2] - cel.wek[2];
            Wektor wektorD = new Wektor(wynik);
            wektorD=wektorD.normalizacja();

            Wektor wektorR = Wektor.iloczynWektorowy(Uworld,wektorD);
            wektorR=wektorR.normalizacja();

            Wektor wektorU = Wektor.iloczynWektorowy(wektorD, wektorR);
            wektorU=wektorU.normalizacja();

            float[,] f1 = new float[4, 4];
            f1[0, 0] = 1f;
            f1[1, 1] = 1f;
            f1[2, 2] = 1f;
            f1[3, 3] = 1f;
            f1[0, 3] = -pozycja.wek[0];
            f1[1, 3] = -pozycja.wek[1];
            f1[2, 3] = -pozycja.wek[2];

            float[,] f2 = new float[4, 4];
            f2[0, 0] = wektorR.wek[0];
            f2[0, 1] = wektorR.wek[1];
            f2[0, 2] = wektorR.wek[2];
            f2[1, 0] = wektorU.wek[0];
            f2[1, 1] = wektorU.wek[1];
            f2[1, 2] = wektorU.wek[2];
            f2[2, 0] = wektorD.wek[0];
            f2[2, 1] = wektorD.wek[1];
            f2[2, 2] = wektorD.wek[2];
            f2[3, 3] = 1f;

            Macierz m1 = new Macierz(f1);
            Macierz m2 = new Macierz(f2);

            return m2.mnozenieMacierzy(m1);
        }
        //public Macierz macierzWidoku()
        //{
        //    Wektor dir = new Wektor(pozycja.wek[0] - cel.wek[0],
        //        pozycja.wek[1] - cel.wek[1], pozycja.wek[2] - cel.wek[2]);
        //    dir = dir.normalizacja();

        //    Wektor UWorld = new Wektor(0, 1, 0);
        //    Wektor R = Wektor.iloczynWektorowy(UWorld, dir);
        //    R.normalizacja();

        //    Wektor U = Wektor.iloczynWektorowy(dir,R);

        //    U.normalizacja();

        //    float[,] View = new float[4, 4];
        //    View[0, 0] = R.wek[0];
        //    View[0, 1] = R.wek[1];
        //    View[0, 2] = R.wek[2];

        //    View[1, 0] = U.wek[0];
        //    View[1, 1] = U.wek[1];
        //    View[1, 2] = U.wek[2];

        //    View[2, 0] = dir.wek[0];
        //    View[2, 1] = dir.wek[1];
        //    View[2, 2] = dir.wek[2];

        //    View[3, 3] = 1;

        //    Macierz ViewMatrix = new Macierz(View);

        //    float[,] tmp = new float[4, 4];
        //    tmp[0, 0] = 1;
        //    tmp[1, 1] = 1;
        //    tmp[2, 2] = 1;
        //    tmp[3, 3] = 1;

        //    tmp[0, 3] = -pozycja.wek[0];
        //    tmp[1, 3] = -pozycja.wek[1];
        //    tmp[2, 3] = -pozycja.wek[2];

        //    Macierz matrix = new Macierz(tmp);

        //    return ViewMatrix.mnozenieMacierzy(matrix);
        //}


    }
}
