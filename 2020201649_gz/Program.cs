using System;

namespace _2020201649_gz
{
    class Program
    {
        static void Main(string[] args)
        {
            const int angle = -10;
            const double S = 1000;
            const double V_lim = 80;
            const double G = 9.81;
            const double g = angle;
            double V = V_lim;
            double X = 0;
            double t = 0;
            const double dt = 0.1;
            while(X<S)
            {
                double A = -(-Resistance(V) - g) * G / 1000;
                X = X + V / 3.6 * dt + 0.5 * A * Math.Sqrt(dt);
                t = t + dt;
                V = V + 3.6 * A * dt;
                if (V<0)
                {
                    Console.WriteLine("error!");
                    break;
                }
            }
            Console.WriteLine(V);
            Console.WriteLine(t);
        }
        public static double Resistance(double speed)
        {
            var res = 2.25 + 0.019 * speed + 0.00032 * Math.Sqrt(speed);
            return res;
        }
    }
}
