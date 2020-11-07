using System;

namespace _2020201649gz_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 定义下坡距离（m）
            Console.WriteLine("请输入下坡距离（m）：");
            double S = Convert.ToDouble(Console.ReadLine());
            // 定义限速（km/h）
            Console.WriteLine("请输入运行时间（s）：");
            double T_sum = Convert.ToDouble(Console.ReadLine());
            // 定义重力加速度
            const double G = 9.81;
            // 单一下坡坡道附加阻力为角度值
            const double g = 0;
            // 定义计算初始条件
            double Vmin = 0;
            double Vmax = 100;
            const double A = 0.51;  // 惰性系数
            double a1 = 0,a2=0;
            double V2 = 0, W = Vmax;
            double[] X = new double[4];
            double[] T = new double[4];
            double U;
            double k = 1;
            const double ev = 0.001;
            while(Math.Abs(V2-W)>ev)
            {
                if (V2 < W)
                    Vmax = W;
                else
                    Vmin = W;
                W = (Vmin + Vmax) / 2;
                U = A * W;
                if (a1 == 0){
                    T[0] = 0;
                    X[0] = 0;
                }
                else{
                    T[0] = (W / 3.6) / a1;
                    X[0] = (W / 3.6) * T[0] / 2;
                }
                if (a2 == 0){
                    T[3] = 0;
                    X[3] = 0;
                }
                else{
                    T[3] = (U / 3.6) / a2;
                    X[3] = (U / 3.6) * T[3] / 2;
                }
                if(A==1){
                    T[2] = 0;
                    X[2] = 0;
                }
                else{
                    DX(out X[2],out T[2],W,U);
                }
                X[1] = S - X[0] - X[2] - X[3];
                T[1] = T_sum - T[0] - T[2] - T[3];
                V2 = X[1] / T[1] * 3.6;
                k = k + 1;
                if (k > 100)
                    break;
                Console.WriteLine(V2);
            }
            // Console.WriteLine(V2);
        }
        // 选用SS1、SS3、SS4车型计算
        public static double SS1(double speed)
        {
            var res = 2.25 + 0.019 * speed + 0.00032 * Math.Sqrt(speed);
            return res;
        }
        public static void DX(out double X ,out double t,double W,double U)
        {
            const double g = 0;
            const double G = 9.81;
            X = 0;
            t = 0;
            double V = W,A=(-SS1(V)-g)*G/1000;
            double dt = 0.01, ep = 0.05;
            while(Math.Abs(V-U)>ep)
            {
                X = X + V / 3.6 * dt + 0.5 * A * Math.Sqrt(dt);
                V = V + 3.6 * A * dt;
                t = t + dt;
                A= (-SS1(V) - g) * G / 1000;
            }
        }
    }
}
