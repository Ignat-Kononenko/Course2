//#include <iostream>
//#include<tchar.h>
//#include "Combi.h"
//#include "Knapsack.h"
//#define NN 18
//int _tmain(int argc, _TCHAR* argv[])
//{
//    setlocale(LC_ALL, "rus");
//    int V = 300,                // ����������� �������              
//        v[] = { 10, 20, 50, 60, 70, 90, 110, 130, 150, 160, 180, 190, 200, 210, 220, 260, 280, 300 },     // ������ �������� ������� ����  
//        c[] = { 5,7, 10, 13, 15, 18,  20, 24, 25, 30,32, 35, 41, 40, 45, 50, 53, 55 };     // ��������� �������� ������� ���� 
//    short m[NN];                // ���������� ��������� ������� ����  {0,1}   
//
//    int maxcc = knapsack_s(
//
//        V,   // [in]  ����������� ������� 
//        NN,  // [in]  ���������� ����� ��������� 
//        v,   // [in]  ������ �������� ������� ����  
//        c,   // [in]  ��������� �������� ������� ����     
//        m    // [out] ���������� ��������� ������� ����  
//    );
//
//    std::cout << std::endl << "-------- ������ � ������� --------- ";
//    std::cout << std::endl << "- ���������� ��������� : " << NN;
//    std::cout << std::endl << "- ����������� �������  : " << V;
//    std::cout << std::endl << "- ������� ���������    : ";
//    for (int i = 0; i < NN; i++) std::cout << v[i] << " ";
//    std::cout << std::endl << "- ��������� ���������  : ";
//    for (int i = 0; i < NN; i++) std::cout << v[i] * c[i] << " ";
//    std::cout << std::endl << "- ����������� ��������� �������: " << maxcc;
//    std::cout << std::endl << "- ��� �������: ";
//    int s = 0; for (int i = 0; i < NN; i++) s += m[i] * v[i];
//    std::cout << s;
//    std::cout << std::endl << "- ������� ��������: ";
//    for (int i = 0; i < NN; i++) std::cout << " " << m[i];
//    std::cout << std::endl << std::endl;
//
//    system("pause");
//    return 0;
//}

//// Main 
#include <iostream>
#include <tchar.h>
#include "Combi.h"
#include "Knapsack.h"
#include <time.h>
#include <iomanip> 
#define NN 20
int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");
    int V = 600,              // ����������� �������              
        v[] = { 25, 56, 67, 40, 20, 27, 37, 33, 33, 44, 53, 12,
               60, 75, 12, 55, 54, 42, 43, 14, 30, 37, 31, 12 },
        c[] = { 15, 26, 27, 43, 16, 26, 42, 22, 34, 12, 33, 30,
               12, 45, 60, 41, 33, 11, 14, 12, 25, 41, 30, 40 };
    short m[NN];
    int maxcc = 0;
    clock_t t1, t2;
    std::cout << std::endl << "-------- ������ � ������� --------- ";
    std::cout << std::endl << "- ����������� �������  : " << V;
    std::cout << std::endl << "-- ���������� ------ ����������������� -- ";
    std::cout << std::endl << "    ���������          ����������  ";
    for (int i = 12; i <= NN; i++)
    {
        t1 = clock();
        maxcc = knapsack_s(V, i, v, c, m);
        t2 = clock();
        std::cout << std::endl << "       " << std::setw(2) << i
            << "               " << std::setw(5) << (t2 - t1);
    }
    std::cout << std::endl << std::endl;
    system("pause");
    return 0;
}
