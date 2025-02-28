#include <iostream>
#include <algorithm>
#include "Levenshtein.h"

using namespace std;

int main() {
    setlocale(LC_ALL, "rus");
    const char* s1 = "Сом";
    const char* s2 = "Домик";
    int lx = strlen(s1);
    int ly = strlen(s2);

    int distance1 = levenshtein(lx, s1, ly, s2);
    cout << "Дистанция Левенштейна (динамическое программирование) между \"" << s1 << "\" и \"" << s2 << "\" равна: " << distance1 << endl;

    int distance2 = levenshtein_r(lx, s1, ly, s2);
    cout << "Дистанция Левенштейна (рекурсия) между \"" << s1 << "\" и \"" << s2 << "\" равна: " << distance2 << endl;
    return 0;
}
