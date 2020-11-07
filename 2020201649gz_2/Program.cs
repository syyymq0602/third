using System;

namespace _2020201649gz_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入坡道角度（‰）：");
            // 定义下坡角度（‰）
            int angle = Convert.ToInt32(Console.ReadLine()) * (-1);
            // 定义下坡距离（m）
            Console.WriteLine("请输入下坡距离（m）：");
            double S = Convert.ToDouble(Console.ReadLine());
            // 定义限速（km/h）
            Console.WriteLine("请输入线路限速（km/h）：");
            double V_lim = Convert.ToDouble(Console.ReadLine());
            // 定义重力加速度
            const double G = 9.81;
            // 定义两车质量(t)
            const double M_loco = 200;
            const double M_veh = 9800;
            // 单一下坡坡道附加阻力为角度值
            double g = angle;
            // 定义计算初始条件
            double V = V_lim;
            double X = 0;
            double t = 0;
            // 定义计算时间间隔（由于计算精度会丢失，不适合太小）
            const double dt = 1;
            while(X<S)
            {
                double F = Force(V);
                double A = -(F-((Locomotive(V)+g)*M_loco*G-(Vehicle(V)+g)*M_veh*G)/1000)/(M_loco+M_veh);
                X = X + V / 3.6 * dt + 0.5 * A * Math.Sqrt(dt);
                V = V + 3.6 * A * dt;
                t = t + dt;
                if(V<0)
                {
                    Console.WriteLine("error!");
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("限速 {0}km/h ，单一下坡距离为 {1}m 的进坡特征速度为{2:N3}km/h。", V_lim, S, V);
        }
        public static double Locomotive(double speed)
        {
            var sp = 0.95 + 0.0023 * speed + 0.000497 * Math.Sqrt(speed);
            return sp;
        }
        public static double Vehicle(double speed)
        {
            var sp = 0.92 + 0.0048 * speed + 0.000125 * Math.Sqrt(speed);
            return sp;
        }
        // 定义制动力
        public static double Force(double speed)
        {
            if (speed > 0 && speed <= 28.8)
                return -350;
            else
                return (-3.6 * 2800 / speed);
        }
    }
}
