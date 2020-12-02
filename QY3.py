# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.

def main():
    global g,G,a,b,c,M
    g = 0  # 坡道角度
    G = 9.81  # 重力加速度
    a, b, c = 1.07, 0.0011, 0.000236  # 定义车型
    Vmin, Vmax = 0, 100  # 定义速度区间
    S, T_sum= 9775.53, 571.1  # 定义距离约束和时间约束
    M = 1  # 列车质量
    A = 0.51  # 定义惰性系数
    a1, a2 = 0, 0  # 定义牵引加速度和制动加速度
    V2,W=0,Vmax  # 定义迭代初始值
    X,T=[0,0,0,0],[0,0,0,0] # 定义四个状态的运行长度和时间
    E,E1,E2=0,0,0  # 定义总能耗，动能能耗，制动能耗
    k=1   # 迭代次数
    N=100  #  迭代上限
    ep = 0.001   # 定义精度
    while abs(V2-W)>ep:
        if V2>W:
            Vmin=W
        else:
            Vmax=W
        W=(Vmin+Vmax)/2
        U=A*W
        if a1==0:
            X[0]=0
            T[0]=0
        else:
            T[0]=(W/3.6)/a1
            X[0]=(W/3.6)*T[0]/2
        if a2==0:
            X[3]=0
            T[3]=0
        else:
            T[3]=(U/3.6)/a2
            X[3]=(U/3.6)*T[3]/2
        X[2],T[2]=dx(W,U)
        X[1]=S-X[0]-X[2]-X[3]
        T[1]=T_sum-T[0]-T[2]-T[3]
        V2=X[1]/T[1]*3.6
        k=k+1
        if k>N:
            break
    E1=0.5*1000*M*W*W/3.6/3.6
    E2=e_rv(W,X[1],T[0])
    E=E1+E2
    print(E)




def e_rv(W,X1,T):
    dt,E1,E2,t,V=0.1,0,0,0,0
    if T!=0:
        while t<T:
            A=W/T
            dS=V/3.6*dt+0.5*A*dt*dt
            V=V+3.6*dt*A
            t=dt+t
            E1=E1+Resistance(V)*M*G*dS
    else:
        E1=0
    E2=M*G*Resistance(W)*X1
    E=E1+E2
    return E

def dx(W,U):
    v0,x0,t=W,0,0
    a0=(-Resistance(v0)-g)*G/1000
    V,X,A=v0,x0,a0
    dt,ep=0.01,0.001
    while abs(V-U)>ep:
        X=X+V/3.6*dt+0.5*A*dt*dt
        V=V+3.6*A*dt
        t=t+dt
        A=(-Resistance(V)-g)*G/1000
    return X,t

def Resistance(v):
    return a + b * v + c * v * v

# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    main()


# See PyCharm help at https://www.jetbrains.com/help/pycharm/
